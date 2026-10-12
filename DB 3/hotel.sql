

DROP TABLE IF EXISTS reservation_payment;
DROP TABLE IF EXISTS reservation_rooms;
DROP TABLE IF EXISTS reservation_guest;
DROP TABLE IF EXISTS reservation_service;
DROP TABLE IF EXISTS payments;
DROP TABLE IF EXISTS reservations;
DROP TABLE IF EXISTS services;
DROP TABLE IF EXISTS amenities;
DROP TABLE IF EXISTS guest_contact_details;
DROP TABLE IF EXISTS staff;
DROP TABLE IF EXISTS rooms;
DROP TABLE IF EXISTS hotels;
DROP TABLE IF EXISTS guests;
create table guests(
Guest_Id int identity(0,1) primary key,
full_name char(50) not null,
nationality varchar(50) not null,
passport_number varchar(20) not null ,
date_of_birth date not null
);

create table guest_contact_details (
guest_id int identity(0,1) references guests (Guest_Id),
detail varchar(40) not null,
primary key(guest_id ,detail)
)

create table hotels (
hotel_id int identity(0,1) primary key,
hotel_name varchar(30) not null,
hotel_address varchar(20) not null ,
city varchar (10) not null ,
star_rating varchar(10) not null,
contact_number varchar(15) not null
)


create table staff(
staff_id int identity(0,10) primary key,
full_name varchar(50) not null ,
position varchar(20) not null,
salary int not null,
hotelid_fk int  references hotels (hotel_id)
)


create table rooms (
room_number int identity (0,1) primary key ,
room_type varchar(10) not null ,
capacity int not null,
daily_rate int not null ,
availability bit not null ,
hotel_id_fk int  references hotels (hotel_id)
)

create table amenities (
room_number int identity (0,1) references rooms (room_number),
amenity varchar(10) not null,
primary key (room_number,amenity)

)

create table services (
service_id int identity(0,1) primary key,
service_name varchar(50) not null,
charge float not null,
request_date date not null,
staff_id int references staff (staff_id)


)
create table reservations (
reservation_id int identity(0,1) primary key,
booking_date date not null,
check_in_date date not null,
check_out_date date not null ,
reservation_status bit not null,
total_price decimal not null ,
number_of_adults int not null,
number_of_children int not null

)

create table reservation_service(
service_id int references services (service_id),
reservation_id int references reservations (reservation_id),
primary key (service_id ,reservation_id)

)
create table payments(
payment_id int identity(0,1) primary key,
mehtod varchar(20) not null,
date date not null,
amount decimal not null,
confirmation_number int not null 


)
create table reservation_guest(
guest_id int references guests (guest_id),
reservation_id int references reservations (reservation_id),
primary key (guest_id ,reservation_id)

)
create table reservation_rooms(
room_number int references rooms (room_number),
reservation_id int references reservations (reservation_id),
primary key (room_number ,reservation_id)

)
create table reservation_payment(
payment_id int references payments (payment_id),
reservation_id int references reservations (reservation_id),
primary key (payment_id ,reservation_id)

)