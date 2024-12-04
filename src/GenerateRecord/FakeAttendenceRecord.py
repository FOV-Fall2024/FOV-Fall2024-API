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

# Hàm lấy danh sách WaiterScheduleId và DateTime từ cơ sở dữ liệu
def fetch_waiter_schedule_data():
    try:
        conn = psycopg2.connect(**db_config)
        cur = conn.cursor()
        
        query = 'SELECT "Id", "DateTime" FROM public."WaiterSchedules";'
        cur.execute(query)
        waiter_schedule_data = cur.fetchall()
        cur.close()
        conn.close()

        # Trả về danh sách các tuple (WaiterScheduleId, DateTime)
        return waiter_schedule_data

    except Exception as e:
        print(f"Error: {e}")
        return []

# Hàm tạo dữ liệu giả cho bảng Attendances
def generate_attendance_data(fake, waiter_schedule_data):
    records = []
    for schedule_id, schedule_date in waiter_schedule_data:
        # schedule_date chỉ có ngày, nên cần kết hợp với giờ ngẫu nhiên
        check_in_hour = random.randint(9, 23)  # Chọn giờ từ 9 AM đến 11 PM
        check_in_time = datetime.combine(schedule_date, datetime.min.time()) + timedelta(hours=check_in_hour)
        
        # Tạo thời gian CheckOutTime sau 4 đến 8 giờ từ CheckInTime
        check_out_time = check_in_time + timedelta(hours=random.randint(4, 8))  # Đảm bảo CheckOutTime > CheckInTime
        
        record = (
            fake.uuid4(),  # Id
            check_in_time,  # CheckInTime
            check_out_time,  # CheckOutTime (lớn hơn CheckInTime)
            schedule_id,  # WaiterScheduleId
            None,  # UserId is NULL
            fake.date_time_this_year(),  # Created
            fake.name(),  # CreatedBy
            fake.date_time_this_year(),  # LastModified
            fake.name(),  # LastModifiedBy
        )
        records.append(record)
    return records

# Chèn dữ liệu vào cơ sở dữ liệu
def insert_attendance_data_to_db(records):
    try:
        conn = psycopg2.connect(**db_config)
        cur = conn.cursor()
        
        query = """
        INSERT INTO public."Attendances" 
        ("Id", "CheckInTime", "CheckOutTime", "WaiterScheduleId", "UserId", 
        "Created", "CreatedBy", "LastModified", "LastModifiedBy") 
        VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s);
        """
        cur.executemany(query, records)
        conn.commit()
        print(f"Inserted {len(records)} attendance records successfully.")
        cur.close()
        conn.close()
    except Exception as e:
        print(f"Error: {e}")

# Main program
if __name__ == "__main__":
    fake = Faker()

    # Lấy dữ liệu WaiterScheduleId và DateTime từ cơ sở dữ liệu
    waiter_schedule_data = fetch_waiter_schedule_data()
    
    if waiter_schedule_data:
        # Tạo dữ liệu cho từng WaiterScheduleId
        attendance_data = generate_attendance_data(fake, waiter_schedule_data)
        
        # Chèn dữ liệu vào bảng Attendances
        insert_attendance_data_to_db(attendance_data)
        print(f"Processed {len(attendance_data)} attendance records")
    else:
        print("No WaiterScheduleId found to generate attendance data.")
