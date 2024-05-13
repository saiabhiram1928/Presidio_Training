use pratice_db;

--Shops Table
create table Shops
(Id int identity(1,1) primary key, ShopName varchar(255), ShopAdress varchar(255), Pincode char(5));

--products table
create table Products (
    Id int primary key ,
    ProductName varchar(255),
    ProductDescription text,
    Price decimal(10,2) ,
    ShopId int,
    foreign key(ShopId) references Shops(Id)
);

--supplier table
create table Suppliers
(Id int  primary key , SupplierName varchar(255), SupplierContact varchar(20));

--product_supplier bridge for many to one relationship
CREATE TABLE ProductSupplierBridge (
    BridgeID INT PRIMARY KEY,
    ProductID INT,
    SupplierID INT,
    FOREIGN KEY (ProductID) REFERENCES Products(Id),
    FOREIGN KEY (SupplierID) REFERENCES Suppliers(Id)
);
--Table for orders
create table Orders
( Id int primary key,
Date_Of_Ordered date,
SupplierId int , 
ShopId int ,
Address varchar(255),
Totalprice decimal(10,2),
foreign key (SupplierId) references Suppliers(Id),
foreign key (ShopId) references Shops(Id));
--Table contain list of orders with quantity
create table Bills
(  OrderID int,
    ProductID int,
    Quantity int,
    FOREIGN KEY (OrderID) REFERENCES Orders(Id),
    FOREIGN KEY (ProductID) REFERENCES Products(Id),
    PRIMARY KEY (OrderID, ProductID) );

-- Inserting into Shops table
INSERT INTO Shops (ShopName, ShopAdress, Pincode) 
VALUES 
('Shop1', 'Address1', '12345'),
('Shop2', 'Address2', '23456'),
('Shop3', 'Address3', '34567');

-- Inserting into Products table
INSERT INTO Products (ProductName, ProductDescription, Price, ShopId) 
VALUES 
('Product A', 'Description A', 10.99, 1),
('Product B', 'Description B', 15.99, 2),
('Product C', 'Description C', 20.99, 3);

-- Inserting into Suppliers table
INSERT INTO Suppliers (SupplierName, SupplierContact) 
VALUES 
('Supplier X', 'Contact X'),
('Supplier Y', 'Contact Y'),
('Supplier Z', 'Contact Z');

-- Inserting into ProductSupplierBridge table
INSERT INTO ProductSupplierBridge (ProductID, SupplierID)
VALUES
(1, 1), -- Product A is supplied by Supplier X
(1, 2), -- Product A is also supplied by Supplier Y
(2, 2), -- Product B is supplied by Supplier Y
(3, 3); -- Product C is supplied by Supplier Z

--Inserting into orders table
INSERT INTO Orders (Id, Date_Of_Ordered, SupplierId, ShopId, Address) 
VALUES 
(1, '2024-05-13', 1, 1, '123 Main St'),
(2, '2024-05-14', 2, 2, '456 Elm St'),
(3, '2024-05-15', 3, 3, '789 Oak St');


--Inserting into bills table
INSERT INTO Bills (OrderID, ProductID, Quantity) 
VALUES 
(1, 1, 2),  -- Order 1, Product A, Quantity 2
(1, 2, 1),  -- Order 1, Product B, Quantity 1
(2, 3, 1),  -- Order 2, Product C, Quantity 1
(3, 1, 3);  -- Order 3, Product A, Quantity 3

update Orders 
set Totalprice = (
select SUM(b.Quantity * p.Price) from Bills as b 
inner join Products as p on p.Id = b.ProductID
where b.OrderID = Orders.Id
group by b.OrderID
);
select * from Shops;
select * from Products;
select * from Suppliers;
select * from ProductSupplierBridge;
select * from Bills;
select * from Orders;
