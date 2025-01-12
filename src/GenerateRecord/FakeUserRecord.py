import psycopg2
from faker import Faker
import random
from datetime import datetime, timedelta

# Cấu hình kết nối PostgreSQL
db_config_server = {
    "host": "dpg-cu1jd0bqf0us73dd2hf0-a.singapore-postgres.render.com",
    "port": "5432",
    "database": "vrom",
    "user": "vrom_admin",
    "password": "8GII27UAP3ybC1BORk9s3rS4rfZ8uB3m",
}
# Tạo số điện thoại hợp lệ ở Việt Nam
def generate_vietnamese_phone_number():
    prefixes = ["03", "07", "08", "09", "05"]  # Các đầu số phổ biến
    prefix = random.choice(prefixes)
    suffix = "".join([str(random.randint(0, 9)) for _ in range(8)])
    return f"{prefix}{suffix}"

# Random ngày trong 2 tháng gần đây
def random_datetime_last_two_months():
    end_date = datetime.now()  # Thời điểm hiện tại
    start_date = end_date - timedelta(days=60)  # 2 tháng trước
    delta = end_date - start_date
    random_days = random.randint(0, delta.days)
    return start_date + timedelta(days=random_days)

# Sinh dữ liệu khách hàng
def generate_fake_customers(fake, num_records):
    records = []
    for _ in range(num_records):
        record = (
            fake.uuid4(),  # Id
            random.randint(0, 10000),  # Point (giá trị ngẫu nhiên từ 0 đến 10,000)
            fake.name(),  # FullName (Tiếng Việt)
            generate_vietnamese_phone_number(),  # PhoneNumber
            random.choice(["0", "1"]),  # Status (0 = Inactive, 1 = Active)
            random_datetime_last_two_months(),  # Created (ngẫu nhiên trong 2 tháng gần đây)
            "Admin",  # CreatedBy (Cố định là Admin)
            random_datetime_last_two_months(),  # LastModified (ngẫu nhiên trong 2 tháng gần đây)
            "Admin",  # LastModifiedBy (Cố định là Admin)
        )
        records.append(record)
    return records

# Chèn dữ liệu vào bảng Customers
def insert_customers_to_db(records):
    try:
        conn = psycopg2.connect(**db_config_server)
        cur = conn.cursor()
        
        query = """
        INSERT INTO public."Customers" 
        ("Id", "Point", "FullName", "PhoneNumber", "Status", 
        "Created", "CreatedBy", "LastModified", "LastModifiedBy") 
        VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s);
        """
        cur.executemany(query, records)
        conn.commit()
        print(f"Inserted {len(records)} customer records successfully.")
        cur.close()
        conn.close()
    except Exception as e:
        print(f"Error: {e}")

if __name__ == "__main__":
    fake = Faker("vi_VN")  # Sử dụng ngôn ngữ tiếng Việt
    num_records = 100
    batch_size = 50

    for i in range(0, num_records, batch_size):
        batch = generate_fake_customers(fake, min(batch_size, num_records - i))
        insert_customers_to_db(batch)
        print(f"Processed {i + len(batch)} / {num_records} customer records")