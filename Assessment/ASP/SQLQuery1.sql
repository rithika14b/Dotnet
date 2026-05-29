CREATE DATABASE FoodOrderManagementDB;
USE FoodOrderManagementDB;



CREATE TABLE MenuItems
(
    MenuId INT IDENTITY(1,1) PRIMARY KEY,
    ItemName NVARCHAR(100) NOT NULL,
    Category NVARCHAR(50) NOT NULL,
    FoodType NVARCHAR(20) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    AvailableQuantity INT NOT NULL,
    IsAvailable BIT NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE()
);

INSERT INTO MenuItems ( ItemName, Category, FoodType, Price, AvailableQuantity, IsAvailable)
VALUES
('Veg Burger', 'Fast Food', 'Veg', 120, 20, 1),
('Chicken Pizza', 'Pizza', 'Non-Veg', 350, 15, 1),
('Pasta', 'Italian', 'Veg', 220, 10, 1),
('Burger', 'Fast Food', 'Non-Veg', 150, 20, 1),
('Pizza', 'Pizza', 'Veg', 300, 15, 1);

CREATE TABLE Orders
(
    OrderId INT IDENTITY(1,1) PRIMARY KEY,
    MenuId INT,
    Quantity INT,
    OrderDate DATETIME DEFAULT GETDATE()
);

GO
CREATE USER [INFICS\rithikab]
FOR LOGIN [INFICS\rithikab];
ALTER ROLE db_owner ADD MEMBER [INFICS\rithikab];