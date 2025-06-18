CREATE DATABASE QHRMProductsDB;
GO

USE QHRMProductsDB;
GO

CREATE TABLE Products (
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(255) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    Description NVARCHAR(MAX),
    CreatedDate DATETIME DEFAULT GETDATE()
);
GO

INSERT INTO Products (ProductName, Price, Description) VALUES
('iPhone 11', 699.99, 'The smartphone'),
('Vivo', 299.99, 'The smart mobile phone'),
('Oppo', 349.99, 'Its camera phone'),
('Samsung J7', 249.99, 'Its fastest mobile'),
('iPhone 12', 799.99, 'The latest smartphone');