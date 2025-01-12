import psycopg2
from faker import Faker
import random
from datetime import datetime, timedelta

db_config_server = {
    "host": "dpg-cu1jd0bqf0us73dd2hf0-a.singapore-postgres.render.com",
    "port": "5432",
    "database": "vrom",
    "user": "vrom_admin",
    "password": "8GII27UAP3ybC1BORk9s3rS4rfZ8uB3m",
}

def fetch_orders_from_db():
    try:
        conn = psycopg2.connect(**db_config_server)
        cur = conn.cursor()
        
        cur.execute('''SELECT "Id" FROM public."Orders" WHERE "OrderStatus" = '5';''')
        order_ids = cur.fetchall()

        cur.close()
        conn.close()
        return [order_id[0] for order_id in order_ids]
    except Exception as e:
        print(f"Error fetching orders: {e}")
        return []

def generate_payment_data(order_ids):
    fake = Faker()
    payment_records = []

    for order_id in order_ids:
        total_amount = fetch_total_amount_for_order(order_id)
        
        reduce_amount = 0
        final_amount = total_amount - reduce_amount

        payment_records.append((
            fake.uuid4(),
            fake.date_time_this_year(),
            total_amount,
            fake.uuid4(),
            random.choice(["1", "2", "3", "4"]),  # PaymentStatus
            random.choice(["1", "2"]),  # PaymentMethods
            order_id,
            fake.date_time_this_year(),
            fake.name(),
            fake.date_time_this_year(),
            fake.name(),
            final_amount,
            reduce_amount,
            random.choice(["0", "1"])
        ))

    return payment_records

def fetch_total_amount_for_order(order_id):
    try:
        conn = psycopg2.connect(**db_config_server)
        cur = conn.cursor()
        
        cur.execute('''SELECT "TotalPrice" FROM public."Orders" WHERE "Id" = %s;''', (order_id,))
        total_amount = cur.fetchone()
        
        cur.close()
        conn.close()

        if total_amount:
            return total_amount[0]
        return 0

    except Exception as e:
        print(f"Error fetching total amount for order {order_id}: {e}")
        return 0


def insert_payment_data_to_db(records):
    try:
        conn = psycopg2.connect(**db_config_server)
        cur = conn.cursor()
        
        query = """
        INSERT INTO public."Payments" 
        ("Id", "PaymentDate", "Amount", "VnpTxnRef", "PaymentStatus", 
        "PaymentMethods", "OrderId", "Created", "CreatedBy", "LastModified", 
        "LastModifiedBy", "FinalAmount", "ReduceAmount", "IsAdminConfirm") 
        VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s);
        """
        cur.executemany(query, records)
        conn.commit()
        print(f"Inserted {len(records)} payment records successfully.")
        cur.close()
        conn.close()
    except Exception as e:
        print(f"Error inserting payment records: {e}")

if __name__ == "__main__":
    order_ids = fetch_orders_from_db()

    payment_records = generate_payment_data(order_ids)

    insert_payment_data_to_db(payment_records)
