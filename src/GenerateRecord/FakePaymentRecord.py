import psycopg2
from faker import Faker
import random
from datetime import datetime, timedelta

# db_config = {
#     "host": "127.0.0.1",
#     "port": "5433",
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
            # "c66122b2-37b0-4f4d-9b57-945161272694", # Cần thì thay orderId, get trong db lấy ra
            random.choice(["97a0efad-5a5d-45d6-9024-16ca6b6b5587", "2bbaa813-25d9-4e74-9afd-cdc483cc0987", "f2be982f-ab51-4d79-9c8c-afc1ce8a4df4", "8b211e82-d6a7-4a51-81fe-41f59bceb99e"]),
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
        conn = psycopg2.connect(**db_config_server)
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
    num_records = 300  # Số bản ghi
    batch_size = 100     # Số lượng bản ghi chèn mỗi lần

    for i in range(0, num_records, batch_size):
        batch = generate_fake_data(fake, min(batch_size, num_records - i))
        insert_data_to_db(batch)
        print(f"Processed {i + len(batch)} / {num_records} records")
