create database shoppingmall;

use shoppingmall;

create table users(
Id int primary key auto_increment,
FirstName varchar(255) default null,
LastName varchar(255) default null,
Address varchar(255) default null,
Email varchar(255) default null,
Contact varchar(255) default null,
PasswordHash blob default null,
PasswordSalt blob default null,
CreatedAt datetime default null,
UpdatedAt datetime default null
);

drop table users;

        -- Stored Procedures

-- User Procedures
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_checkUserAvailability`(email varchar(255))
BEGIN
	select `Id`, `FirstName`, `LastName`, `Address`, `Contact` from `users` where `email` = email;
END$$
DELIMITER ;

call checkUserAvailability('tharindutd1998@gmail.com');

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_userRegister`(
FirstName varchar(255),
LastName varchar(255),
Address varchar(255),
Email varchar(255),
Contact varchar(255),
PasswordHash blob,
PasswordSalt blob,
CreatedAt datetime,
UpdatedAt datetime
)
BEGIN
	insert into `users` (`FirstName`, `LastName`, `Address`, `Email`, `Contact`, `PasswordHash`, `PasswordSalt`, `CreatedAt`, `UpdatedAt`)
	values (FirstName, LastName, Address, Email, Contact, PasswordHash, PasswordSalt, CreatedAt, UpdatedAt);
END$$
DELIMITER ;

CALL sp_userRegister('Tharindu', 'Theekshana', 'Hambantota', 'tharindutd1998@gmail.com', '+94779200039', '', '', '2022-12-22 13:56:00', '2022-12-22 13:56:00');

