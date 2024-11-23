import psycopg2
from faker import Faker
import random
from datetime import datetime

# Cấu hình kết nối PostgreSQL
# db_config = {
#     "host": "127.0.0.1",
#     "port": 5433,  # Cổng PostgreSQL
#     "database": "RestaurantManagementDatabase",
#     "user": "admin",
#     "password": "admin",
# }

db_config_server = {
    "host": "dpg-csov56t6l47c7396dqdg-a.singapore-postgres.render.com",
    "port": "5432",
    "database": "restaurantmanagementdb",
    "user": "restaurantmanagementdb_user",
    "password": "V0XThBwwbEzNZa3XBqZV8VEXyFCcfrH2",
}

def generate_fake_customers(fake, num_records):
    records = []
    for _ in range(num_records):
        record = (
            fake.uuid4(),  # Id
            random.randint(0, 10000),  # Point (giá trị ngẫu nhiên từ 0 đến 10,000)
            fake.name(),  # FullName
            fake.phone_number(),  # PhoneNumber
            random.choice(["0", "1"]),  # Status
            fake.date_time_this_year(),  # Created
            fake.name(),  # CreatedBy
            fake.date_time_this_year(),  # LastModified
            fake.name(),  # LastModifiedBy
        )
        records.append(record)
    return records

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
    fake = Faker()
    num_records = 100
    batch_size = 50

    for i in range(0, num_records, batch_size):
        batch = generate_fake_customers(fake, min(batch_size, num_records - i))
        insert_customers_to_db(batch)
        print(f"Processed {i + len(batch)} / {num_records} customer records")
