 drop database ARBAJWEBAPIDB

create database ARBAJWEBAPIDB
go
use ARBAJWEBAPIDB
go
create table product
(
Id int primary key identity,
Name varchar(50),
Price decimal,
AvailableQuantity int 
)
go
insert into product values('Mens Shirt',599,10)
go
Select * from Product
go
 go
create table Category
(
Id int primary key identity,
Name varchar(500)
)
go
insert into Category values('Mens Wear'),('Kids Wear')
go
alter table product
add CategoryId int foreign key references Category(Id)
go
select * from product
select * from Category
go
update product set CategoryId=1 where Id=1

 