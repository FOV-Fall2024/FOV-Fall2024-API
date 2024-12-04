import psycopg2
from faker import Faker
import random
from datetime import datetime, timedelta

# Cấu hình kết nối PostgreSQL
db_config = {
    "host": "127.0.0.1",
    "port": 5433,
    "database": "RestaurantManagementDatabase",
    "user": "admin",
    "password": "admin",
}

# Danh sách UserId và ShiftId
user_ids = [
    "d9e69f16-0b7d-4119-ae79-039d94fcf410",
    "5e79601d-c2cb-4d2f-a3d2-aa1fd8e77715",
    "b12eb0bf-5487-4a09-b50a-bd29546057c9",
    "ab3ee0ff-3d0a-486b-ad1e-66fb0ff0ebba",
]

shift_ids = [
    "d9c335f9-c234-42e6-a325-c8e7b51cf147",
    "e32da7d0-eda0-4940-a902-c1fc225bc0b2",
    "7cbe6b52-4c73-4144-a888-46eaf8a737de",
]

# Hàm tạo dữ liệu giả
def generate_waiter_schedule(fake, num_records):
    records = []
    for _ in range(num_records):
        record = (
            fake.uuid4(),  # Id
            fake.date_time_between_dates(
                datetime_start=datetime(datetime.now().year, 11, 1),
                datetime_end=datetime(datetime.now().year, 12, 31),
            ).date(),  # DateTime (chỉ lấy phần ngày)
            random.choice(shift_ids),  # ShiftId
            random.choice(user_ids),  # UserId
            fake.date_time_this_year().date(),  # Created (chỉ lấy phần ngày)
            fake.name(),  # CreatedBy
            fake.date_time_this_year().date(),  # LastModified (chỉ lấy phần ngày)
            fake.name(),  # LastModifiedBy
        )
        records.append(record)
    return records

# Chèn dữ liệu vào cơ sở dữ liệu
def insert_waiter_schedules_to_db(records):
    try:
        conn = psycopg2.connect(**db_config)
        cur = conn.cursor()
        
        query = """
        INSERT INTO public."WaiterSchedules" 
        ("Id", "DateTime", "ShiftId", "UserId", "Created", "CreatedBy", "LastModified", "LastModifiedBy") 
        VALUES (%s, %s, %s, %s, %s, %s, %s, %s);
        """
        cur.executemany(query, records)
        conn.commit()
        print(f"Inserted {len(records)} waiter schedule records successfully.")
        cur.close()
        conn.close()
    except Exception as e:
        print(f"Error: {e}")

# Main program
if __name__ == "__main__":
    fake = Faker()
    num_records = 100  # Số lượng bản ghi cần tạo
    batch_size = 20    # Số lượng bản ghi chèn mỗi lần

    for i in range(0, num_records, batch_size):
        batch = generate_waiter_schedule(fake, min(batch_size, num_records - i))
        insert_waiter_schedules_to_db(batch)
        print(f"Processed {i + len(batch)} / {num_records} waiter schedule records")
