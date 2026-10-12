CREATE DATABASE online_store








create table suppliers(
supplier_id int identity(0,1) primary key,
name varchar(20) not null,
country varchar(10) not null,
email varchar(30) not null,
address varchar(20) not null,
contact_number varchar(20) not null,
)
create table customers (
customer_id int identity(0,1) primary key,
full_name varchar(50) not null,
phone_number varchar(20) not null,
email varchar(20) not null ,
shipping_address varchar(40) not null,
registration_date date not null

)
create table payments(
payment_id int identity(0,1) primary key,
payment_date date not null,
amount decimal not null,
status bit not null,
method varchar(20) not null
)
create table categories(
category_id int identity(0,1) primary key,
name varchar(20) not null,
description varchar(20) not null,
main_category int references categories (category_id)
)

create table products(
product_id int identity(0,1) primary key,
stock_quantity int not null,
name varchar(20) not null,
added_date date not null,
description varchar(20) not null,
unit_price decimal not null,
category_id int references categories( category_id)

)
drop table suppliers ;
create table suppliers(
supplier_id int identity(0,1) primary key,
name varchar(20) not null,
country varchar(10) not null,
email varchar(30) not null,
address varchar(20) not null,
contact_number varchar(20) not null,
)
create table stock_transactions (
tran_id int identity(0,1) primary key,
tran_date date not null,
quantity_change varchar(20) not null,
type varchar(10) not null,
reference varchar(10) not null,
product_id int references products (product_id)

)
create table products_suppliers(
supplier_id int references suppliers (supplier_id),
product_id int references products (product_id),
primary key(supplier_id,product_id)

)
create table reviews(
review_id int identity(0,1) primary key,
rating varchar(10) not null,
date date not null,
comment varchar(20) not null,
product_id int references products (product_id),
customer_id int references customers (customer_id)
)
create table orders(
order_id int identity(0,1) primary key,
status varchar(20) not null,
total_amount decimal not null,
order_date date not null,
cutomer_id int references customers ( customer_id) 

)
create table order_items(
order_item_id int identity(0,1) primary key,
quantity int not null,
unit_price decimal not null,
product_id int references products (product_id),
order_id int references orders (order_id)
)
create table shipments(
shipment_id int identity(0,1) primary key,
shipment_date date not null,
status varchar(20) not null,
delivery_date date not null,
carrier_name varchar(20) not null,
tracking_number int not null,
order_id int references orders(order_id)

)
create table orders_payments(
order_id int references orders (order_id),
payment_id int references payments(payment_id),
primary key(order_id,payment_id) 
)
