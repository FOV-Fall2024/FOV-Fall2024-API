import psycopg2
from faker import Faker
import random
from datetime import datetime, timedelta

# Cấu hình kết nối PostgreSQL
db_config_server = {
    "host": "dpg-ctd6q99u0jms73f3bmjg-a.singapore-postgres.render.com",
    "port": "5432",
    "database": "vrom_db",
    "user": "vrom_db_user",
    "password": "PetEBNZhmP9sYFiyrBAEgmPariwvsp7r",
}

# Danh sách UserId và ShiftId
user_ids = [
    "944d11fd-80f4-46f6-898a-a3bf6ed24600",
    "c5a14a90-5f6b-4b13-8cac-ed85d635e24f",
    "ef918ae5-b4a2-4139-a1f4-83ea932b0691",
]

shift_ids = [
    "7346b17a-2c84-4ee5-be16-16ad90d29537",
    "d42c0840-faf3-4ee4-9b09-65a4673e270d",
    "4f8cc7f6-d331-443b-a857-f83d7fce5d0b",
]

# Hàm tạo dữ liệu giả
def generate_waiter_schedule(fake):
    records = []
    start_date = datetime(datetime.now().year, 11, 1).date()
    end_date = datetime(datetime.now().year, 12, 15).date()
    current_date = start_date

    while current_date <= end_date:
        for shift_id in shift_ids:
            assigned_users = set()  # Đảm bảo không user nào lặp lại trong 1 ca
            while len(assigned_users) < 3:
                available_users = [user for user in user_ids if user not in assigned_users]
                if available_users:
                    user_id = random.choice(available_users)
                    assigned_users.add(user_id)

                    record = (
                        fake.uuid4(),  # Id
                        current_date,  # DateTime (chỉ lấy phần ngày)
                        shift_id,      # ShiftId
                        user_id,       # UserId
                        fake.date_time_this_year().date(),  # Created (chỉ lấy phần ngày)
                        None,          # CreatedBy
                        None,          # LastModified (chỉ lấy phần ngày)
                        None,          # LastModifiedBy
                    )
                    records.append(record)

        current_date += timedelta(days=1)

    return records

# Chèn dữ liệu vào cơ sở dữ liệu
def insert_waiter_schedules_to_db(records):
    try:
        conn = psycopg2.connect(**db_config_server)
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
    records = generate_waiter_schedule(fake)
    insert_waiter_schedules_to_db(records)
    print(f"Processed {len(records)} waiter schedule records")
