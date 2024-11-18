import psycopg2
from faker import Faker
import random
from datetime import datetime, timedelta

db_config = {
    "host": "127.0.0.1",
    "port": "5433",
    "database": "RestaurantManagementDatabase",
    "user": "admin",
    "password": "admin",
}

def generate_fake_data(fake, num_records):
    records = []
    for _ in range(num_records):
        amount = round(random.uniform(10, 10000), 0) * 1000
        reduce_amount = round(random.uniform(0, amount / 1000), 0)  * 1000 # Format VND
        final_amount = round(amount - reduce_amount, 0)

        record = (
            fake.uuid4(),
            fake.date_time_between(start_date="-1y", end_date="now"),
            amount,
            fake.uuid4(),
            random.choice(["1", "2", "3", "4"]),
            random.choice(["1", "2"]),
            "c66122b2-37b0-4f4d-9b57-945161272694", # Cần thì thay orderId, get trong db lấy ra
            fake.date_time_this_year(),
            fake.name(),
            fake.date_time_this_year(),
            fake.name(),
            final_amount,
            reduce_amount,
        )
        records.append(record)
    return records

def insert_data_to_db(records):
    try:
        conn = psycopg2.connect(**db_config)
        cur = conn.cursor()
        
        query = """
        INSERT INTO public."Payments" 
        ("Id", "PaymentDate", "Amount", "VnpTxnRef", "PaymentStatus", 
        "PaymentMethods", "OrderId", "Created", "CreatedBy", "LastModified", 
        "LastModifiedBy", "FinalAmount", "ReduceAmount") 
        VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s);
        """
        cur.executemany(query, records)
        conn.commit()
        print(f"Inserted {len(records)} records successfully.")
        cur.close()
        conn.close()
    except Exception as e:
        print(f"Error: {e}")

if __name__ == "__main__":
    fake = Faker()
    num_records = 100000  # Số bản ghi
    batch_size = 10000     # Số lượng bản ghi chèn mỗi lần

    for i in range(0, num_records, batch_size):
        batch = generate_fake_data(fake, min(batch_size, num_records - i))
        insert_data_to_db(batch)
        print(f"Processed {i + len(batch)} / {num_records} records")
