insert into guests (full_name , nationality,passport_number,date_of_birth)
values ('mohamed reda ','egyptian','123456','2005-05-15' ), 
('ahmed ramy' ,'german','56789 ',' 2005-08-9 ' ),
('ahmed mohamed', 'italian ','6458799','1980-06-3' )





update rooms
set daily_rate =daily_rate +(daily_rate *0.15)


update reservations
set reservation_status=case 
when check_out_date < GETDATE() then 'completed'
when check_out_date > GETDATE() then 'upcoming'
else 'active'
end