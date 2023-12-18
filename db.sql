use [master]
go

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'FPTBook')
	BEGIN
		-- Database exists. Drop it
		Drop database FPTBook
	END
ELSE
	BEGIN
		-- Database does not exist. Create it
		create database FPTBook
	END
GO

use FPTBook
go

-- categoryId and orderId are identity columns

-- Store Owner Management
create table tableStoreOwner
(
	storeOwnerId varchar(30) not null primary key,
	storeOwnerPassword varchar(300) not null,
	storeOwnerName nvarchar(30) not null,
	storeOwnerAddress nvarchar(50) not null,
	storeOwnerPhoto varchar(30) null,
	storeOwnerPhone varchar(12) null,
	storeOwnerTaxCode varchar(12) null,
	storeOwnerDetails nvarchar(300) null,
	storeOwnerEmail varchar(30) null
)
go

-- Customer Management
create table tableCustomer
(
	customerEmail varchar(30) not null primary key,
	customerPassword varchar(300) not null,
	customerFullName nvarchar(60) not null,
	customerPhoto varchar(120) null,
	customerAddress nvarchar(300) null,
	customerPhone varchar(12) null
)
go


-- Book Management
create table tableCategory
(
   categoryId int identity(1, 1) primary key,
   categoryName nvarchar(50) not null unique,
   categoryDetail nvarchar(300) null
)
go

create table tablePublisher
(
	publisherId varchar(30) not null primary key,
	publisherName nvarchar(30) not null unique,
	publisherAddress nvarchar(50) null,
	publisherLogo varchar(30) null,
	publisherDetail nvarchar(300) null
)
go

create table tableAuthor
(
	authorId varchar(30) not null primary key,
	authorName nvarchar(30) not null,
	authorAddress nvarchar(50) null,
	authorEmail varchar(30) null,
	authorPhoto varchar(30) null,
	authorDetail nvarchar(300) null
)

create table tableBook
(
	bookId varchar(30) not null primary key,
	bookTitle nvarchar(30) not null,
	categoryId int not null,
	authorId varchar(30) not null, --one book with one main author only
	-- authorName varchar(30) null, --additional authors if there are
	storeOwnerId varchar(30) not null,
	publisherId varchar(30) not null,
	bookPrice int not null default(10),
	bookDetail nvarchar(500) null,
	bookImage1 varchar(30) null,
	bookImage2 varchar(30) null,
	bookImage3 varchar(30) null,
	constraint foreignKeyName_categoryId foreign key(categoryId) references tableCategory(categoryId),
	constraint foreignKeyName_ownerId foreign key(storeOwnerId) references tableStoreOwner(storeOwnerId),
	constraint foreignKeyName_publisherId foreign key(publisherId) references tablePublisher(publisherId),
	constraint foreignKeyName_authorId foreign key(authorId) references tableAuthor(authorId)
	-- constraint foreignKeyName_authorName foreign key(authorName) references tableAuthor(authorName) --additional authors if there are
)
go

-- Order Management
create table tableOrder
(
	orderId int identity(1, 1) primary key,
	orderDate datetime not null,
	orderTotal int not null,
	orderStatus varchar(30) not null,
	customerEmail varchar(30) not null,
	constraint foreignKeyName_customerEmail foreign key(customerEmail) references tableCustomer(customerEmail)

)
go

create table tableOrderDetail
(
	orderId int not null,
	bookId varchar(30) not null,
	quantity int not null,
	constraint foreignKeyName_orderId foreign key(orderId) references tableOrder(orderId),
	constraint foreignKeyName_bookId foreign key(bookId) references tableBook(bookId),
	constraint primaryKeyName_orderId_bookId primary key(orderId, bookId)
)

-- admin management
create table tableAdmin
(
	adminId varchar(30) not null primary key,
	adminPassword varchar(300) not null,
	adminName nvarchar(30) not null,
	adminPhoto varchar(30) null,
	adminAddress nvarchar(300) null,
	adminPhone varchar(12) null,
	adminEmail varchar(30) null
)





-- add data to tables

-- Store Owner Management
-- add data to tableStoreOwner
insert into tableStoreOwner (storeOwnerId, storeOwnerPassword, storeOwnerName, storeOwnerAddress,
 storeOwnerPhoto, storeOwnerPhone, storeOwnerTaxCode, storeOwnerDetails, storeOwnerEmail)
values (N'SO123', '123456', N'Cửa hàng Thành Phát', N'12 Hai Bà Trưng',null, null, null, null, null),
       (N'SO456', '123456', N'Phương Nam BookStore', N'56 Lý Thường Kiệt', null, null, null, null, null),
	   (N'SO789', '123456', N'Ngọc Mai BookStore', N'245 Hùng Vương', null, null, null, null, null)
go

-- Customer Management
-- add data to tableCustomer
insert into tableCustomer (customerEmail, customerPassword, customerFullName, customerPhoto, customerAddress, customerPhone)
values ('hacker@gmail.com',123, N'hack tới chết', null, N'12 Hai Bà Trưng', null)
go

-- Book Management
-- add data to tableCategory
insert into tableCategory (categoryName, categoryDetail)
values (N'Information Technology',null), (N'Children',null), (N'Science', null), (N'Business', null)
go

-- add data to tablePublisher
insert into tablePublisher (publisherId, publisherName, publisherAddress, publisherLogo, publisherDetail)
values ('NXBKD',N'Kim Dong', null, null, null),
		('NXBGD',N'Giao Duc', null, null, null),
		('NXBPN',N'Phuong Nam', null, null, null), 
		('NXBHN',N'Ha Noi', null, null, null)
go

-- add data to tableAuthor
insert into tableAuthor (authorId, authorName, authorAddress, authorEmail, authorPhoto, authorDetail)
values (N'A123', N'Nguyễn Văn A', N'12 Hai Bà Trưng', null, null, null),
	   (N'A456', N'Nguyễn Văn B', N'56 Lý Thường Kiệt', null, null, null),
	   (N'A789', N'Nguyễn Văn C', N'245 Hùng Vương', null, null, null)
go

-- add data to tableBook
insert into tableBook (bookId, bookTitle, categoryId, authorId, storeOwnerId, publisherId, bookPrice, bookDetail, bookImage1, bookImage2, bookImage3)
values ('B0001', N'ASP.NET Core MVC', 1, 'A123', 'SO123', 'NXBKD', 350, N'ASP.NET Core MVC', 'book01.jpg', null, null),
	   ('B0002', N'C# Programming', 1, 'A456', 'SO123', 'NXBGD', 200, N'C# Programming', 'book02.jpg', null, null),
	   ('B0003', N'Thinking in Java', 1, 'A789', 'SO123', 'NXBPN', 150, N'Thinking in Java', 'book03.jpg', null, null),
	   ('B0004', N'Microsoft SQL Server 2023', 1, 'A123', 'SO123', 'NXBHN', 300, N'Microsoft SQL Server 2023', 'book04.jpg', null, null),
	   ('B0005', N'Laravel Framework in Action', 1, 'A456', 'SO123', 'NXBKD', 370, N'Laravel Framework in Action', 'book05.jpg', null, null),
	   ('B0006', N'AI with Python ', 1, 'A789', 'SO123', 'NXBGD', 450, N'AI with Python ', 'book06.jpg', null, null),
	   ('B0007', N'Marchine Learning in PyThon', 1, 'A789', 'SO123', 'NXBPN', 480, N'Marchine Learning in PyThon', 'book07.jpg', null, null)
go

-- Admin Management
-- add data to tableAdmin
insert into tableAdmin (adminId, adminPassword, adminName, adminPhoto, adminAddress, adminPhone, adminEmail)
values (N'AD123', '123456', N'Nguyễn Văn A', N'admin01.jpg', N'12 Hai Bà Trưng', NULL, null),
	   (N'AD456', '123456', N'Nguyễn Văn B', N'admin02.jpg', N'56 Lý Thường Kiệt', NULL, null),
	   (N'AD789', '123456', N'Nguyễn Văn C', N'admin03.jpg', N'245 Hùng Vương', NULL, null)
go


select * from tableCategory
go
select * from tablePublisher
go
select * from tableStoreOwner
go
select * from tableBook
go
