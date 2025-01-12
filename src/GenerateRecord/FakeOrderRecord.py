import psycopg2
import random
from faker import Faker
from datetime import datetime, timedelta

db_config_server = {
    "host": "dpg-cu1jd0bqf0us73dd2hf0-a.singapore-postgres.render.com",
    "port": "5432",
    "database": "vrom",
    "user": "vrom_admin",
    "password": "8GII27UAP3ybC1BORk9s3rS4rfZ8uB3m",
}

def fetch_data_from_db():
    try:
        conn = psycopg2.connect(**db_config_server)
        cur = conn.cursor()
        
        cur.execute('''SELECT "Id", "ComboName", "ComboDescription", "ComboStatus", "Status", "Price", "Thumbnail", "PercentReduce", "RestaurantId", "Created", "CreatedBy", "LastModified", "LastModifiedBy"
                       FROM public."Combos";''')
        combos = cur.fetchall()
        
        cur.execute('''SELECT "Id", "DishType", "PriorityDish", "CategoryId", "Status", "Price", "RestaurantId", "DishGeneralId", "Created", "CreatedBy", "LastModified", "LastModifiedBy"
                       FROM public."Dishes";''')
        dishes = cur.fetchall()

        cur.execute('''SELECT "Id", "Point", "FullName", "PhoneNumber", "Status", "Created", "CreatedBy", "LastModified", "LastModifiedBy"
                       FROM public."Customers";''')
        customers = cur.fetchall()

        cur.execute('''SELECT "Id", "TableNumber", "TableCode", "TableStatus", "TableQRCode", "RestaurantId", "IsLogin", "Created", "CreatedBy", "LastModified", "LastModifiedBy"
                       FROM public."Tables";''')
        tables = cur.fetchall()
        
        cur.close()
        conn.close()
        return dishes, combos, customers, tables
    except Exception as e:
        print(f"Error fetching data: {e}")
        return [], [], [], []

def get_month_dates():
    today = datetime.today()
    first_day_this_month = today.replace(day=1)
    first_day_last_month = (first_day_this_month - timedelta(days=1)).replace(day=1)
    return first_day_this_month, first_day_last_month

def fetch_is_refund_for_dish(dish_id):
    try:
        conn = psycopg2.connect(**db_config_server)
        cur = conn.cursor()
        
        cur.execute('''SELECT "IsRefund" FROM public."DishGenerals" WHERE "Id" = (SELECT "DishGeneralId" FROM public."Dishes" WHERE "Id" = %s);''', (dish_id,))
        is_refund = cur.fetchone()
        
        cur.close()
        conn.close()

        if is_refund:
            return is_refund[0]
        return False

    except Exception as e:
        print(f"Error fetching IsRefund for dish {dish_id}: {e}")
        return False 

def create_orders_and_details(dishes, combos, customers, tables, num_orders=10):
    fake = Faker()
    orders = []
    order_details = []

    first_day_this_month, first_day_last_month = get_month_dates()

    for _ in range(num_orders):
        order_id = fake.uuid4()
        order_status = random.choice(['5']) 
        order_type = random.choice(['1'])
        user_id = None
        order_time = random.choice([first_day_this_month, first_day_last_month]) + timedelta(days=random.randint(0, 30))
        total_price = 0 
        table_id = random.choice([table[0] for table in tables]) 
        feedback = fake.text(max_nb_chars=200)
        customer_id = random.choice([customer[0] for customer in customers])
        created_by = fake.name()
        last_modified_by = fake.name()

        orders.append(( 
            order_id, order_status, order_type, user_id, order_time, total_price, table_id, feedback,
            customer_id, order_time, created_by, order_time, last_modified_by
        ))

        num_details = random.randint(1, 5)
        for _ in range(num_details):
            is_combo = random.choice([True, False])
            if is_combo:  # Nếu là Combo
                combo = random.choice(combos)
                combo_id = combo[0]
                price = combo[5]  # Giá của Combo
                product_id = None
            else:  # Nếu là Dish
                dish = random.choice(dishes)
                combo_id = None
                price = dish[5]  # Giá của Dish
                product_id = dish[0]

            is_refund = fetch_is_refund_for_dish(product_id)  # Kiểm tra món ăn có phải hoàn trả hay không

            quantity = random.randint(1, 5)
            status = 4
            refund_quantity = 0 if status == '1' else random.randint(1, quantity)
            is_add_more = random.choice([True, False])
            note = fake.text(max_nb_chars=100)

            total_price += price * quantity

            order_details.append(( 
                fake.uuid4(), combo_id, product_id, order_id, status, quantity, refund_quantity, 
                is_refund, price, note, is_add_more, order_time, created_by, order_time, last_modified_by
            ))

        orders[-1] = orders[-1][:5] + (total_price,) + orders[-1][6:]

    insert_orders_to_db(orders)
    insert_order_details_to_db(order_details)

def insert_orders_to_db(orders):
    try:
        conn = psycopg2.connect(**db_config_server)
        cur = conn.cursor()
        
        query = """
        INSERT INTO public."Orders"(
            "Id", "OrderStatus", "OrderType", "UserId", "OrderTime", "TotalPrice", "TableId", "Feedback", 
            "CustomerId", "Created", "CreatedBy", "LastModified", "LastModifiedBy"
        ) VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s);
        """
        cur.executemany(query, orders)
        conn.commit()
        print(f"Inserted {len(orders)} orders successfully.")
        cur.close()
        conn.close()
    except Exception as e:
        print(f"Error inserting orders: {e}")

# Thêm OrderDetails vào database
def insert_order_details_to_db(order_details):
    try:
        conn = psycopg2.connect(**db_config_server)
        cur = conn.cursor()
        
        query = """
        INSERT INTO public."OrderDetails"(
            "Id", "ComboId", "ProductId", "OrderId", "Status", "Quantity", "RefundQuantity", "IsRefund", 
            "Price", "Note", "IsAddMore", "Created", "CreatedBy", "LastModified", "LastModifiedBy"
        ) VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s);
        """
        cur.executemany(query, order_details)
        conn.commit()
        print(f"Inserted {len(order_details)} order details successfully.")
        cur.close()
        conn.close()
    except Exception as e:
        print(f"Error inserting order details: {e}")

if __name__ == "__main__":
    # Fetch dữ liệu từ database
    dishes, combos, customers, tables = fetch_data_from_db()
    
    # Tạo orders và order details và thêm vào database
    create_orders_and_details(dishes, combos, customers, tables)

