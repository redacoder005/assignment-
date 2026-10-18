insert into customers (full_name,phone_number,email,shipping_address,registration_date)
values ('mohamed reda' , '028485154545','mohamed@gmail.com' ,'giza', '2026-06-20')
 insert into suppliers(name , country, email, address , contact_number )
 values ('mohamed ahmed' ,'egypt' ,'ahmed@gmail.com ', 'cairo' ,'256587448421' ),
 ('sayed ahmed' ,'egypt' ,'sayed@gmail.com ', 'alex' ,'24515547448421' ),
 ('samir ahmed' ,'egypt' ,'samir@gmail.com ', 'giza' ,'2561554148421' )

 insert into categories( name,description)
 values ('books' ,'for reading' ),
 ('computers' ,'for tech')

insert into products (stock_quantity,name ,added_date,description,unit_price)
 values (500,'apple','2026-06-20','good for health',20)

 create table archived_stock(
 tran_id int identity(0,1) primary key,
 product_id int ,
 quantity_change varchar(20),
 tran_date date

 )


 INSERT INTO archived_stock (product_id, quantity_change, tran_date)
 select product_id,quantity_change,tran_date
 from stock_transactions
 where tran_date <'2023-01-1'

 update products
 set unit_price =unit_price +(unit_price*0.1)
 where unit_price <100

 update orders 
 set status =case 
 when total_amount >5000 then 'premium'
 else 'standard'
 end