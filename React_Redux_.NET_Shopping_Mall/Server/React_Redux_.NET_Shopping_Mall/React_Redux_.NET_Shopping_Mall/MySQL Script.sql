create database shoppingmall;

use shoppingmall;

create table stock(
Id integer primary key auto_increment,
ItemName varchar(255) default null,
Description varchar(255) default null,
Unit varchar(255) default null,
AvailableQty integer default null,
UnitPrice double default null,
CreatedAt datetime default null,
UpdatedAt datetime default null
);

drop table stock;

        -- Stored Procedures

-- Stock Procedures

call sp_getAllStock;
call sp_getStockById(1);
call sp_postStock('Soap', '100g', 'NOS', 10, 225.50, '', '');
call sp_putStock(1, 'Soap', '100g', 'NOS', 10, 225.50, '', '');
call sp_deleteStock(1);