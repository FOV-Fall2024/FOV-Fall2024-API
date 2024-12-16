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

# Hàm lấy WaiterScheduleId, DateTime và StartTime từ cơ sở dữ liệu
def fetch_waiter_schedule_data():
    try:
        conn = psycopg2.connect(**db_config_server)
        cur = conn.cursor()
        
        query = '''
        SELECT ws."Id", ws."DateTime", s."StartTime"
        FROM public."WaiterSchedules" ws
        JOIN public."Shifts" s ON ws."ShiftId" = s."Id";
        '''
        cur.execute(query)
        waiter_schedule_data = cur.fetchall()
        cur.close()
        conn.close()

        # Trả về danh sách các tuple (WaiterScheduleId, DateTime, StartTime)
        return waiter_schedule_data

    except Exception as e:
        print(f"Error: {e}")
        return []

# Hàm tạo dữ liệu giả cho bảng Attendances
def generate_attendance_data(fake, waiter_schedule_data):
    records = []
    for schedule_id, schedule_date, shift_start_time in waiter_schedule_data:
        # shift_start_time là TimeSpan (hh:mm:ss), chuyển thành datetime
        shift_hours, shift_minutes, shift_seconds = map(int, str(shift_start_time).split(":"))
        check_in_time = datetime.combine(schedule_date, datetime.min.time()) + timedelta(
            hours=shift_hours, minutes=shift_minutes, seconds=shift_seconds
        )

        # Tạo thời gian CheckOutTime: CheckInTime + 4 đến 5 giờ
        check_out_time = check_in_time + timedelta(hours=random.uniform(4, 5))  # Đảm bảo CheckOutTime > CheckInTime
        
        record = (
            fake.uuid4(),  # Id
            check_in_time,  # CheckInTime
            check_out_time,  # CheckOutTime (lớn hơn CheckInTime)
            schedule_id,  # WaiterScheduleId
            None,  # UserId is NULL
            fake.date_time_this_year(),  # Created
            None,  # CreatedBy
            None,  # LastModified
            None,  # LastModifiedBy
        )
        records.append(record)
    return records

# Chèn dữ liệu vào cơ sở dữ liệu
def insert_attendance_data_to_db(records):
    try:
        conn = psycopg2.connect(**db_config_server)
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

    # Lấy dữ liệu WaiterScheduleId, DateTime và StartTime từ cơ sở dữ liệu
    waiter_schedule_data = fetch_waiter_schedule_data()
    
    if waiter_schedule_data:
        # Tạo dữ liệu cho từng WaiterScheduleId
        attendance_data = generate_attendance_data(fake, waiter_schedule_data)
        
        # Chèn dữ liệu vào bảng Attendances
        insert_attendance_data_to_db(attendance_data)
        print(f"Processed {len(attendance_data)} attendance records")
    else:
        print("No WaiterSchedule data found to generate attendance data.")
