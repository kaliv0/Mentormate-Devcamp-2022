USE master

CREATE DATABASE Restaurant;
GO

USE Restaurant;

--create roles----------------
CREATE TABLE Roles
(
	Id INT PRIMARY KEY IDENTITY,
	RoleType NVARCHAR(30) NOT NULL,
	IsDeleted BIT NOT NULL DEFAULT 0,
	CreateDate DATETIME,
	UpdateDate DATETIME,
);

--create users--------------------
CREATE TABLE Users
(
     Id INT PRIMARY KEY IDENTITY,
     FirstName NVARCHAR(20) NOT NULL,
     LastName NVARCHAR(20) NOT NULL,
	 Email NVARCHAR(30),
	 [Role] INT REFERENCES Roles(Id) NOT NULL,
	 IsDeleted BIT NOT NULL DEFAULT 0,
	 CreateDate DATETIME,
	 UpdateDate DATETIME,
);

--create tables--------------------
CREATE TABLE [Tables]
(
     Id INT NOT NULL PRIMARY KEY IDENTITY,	
	 Capacity INT NOT NULL,
	 IsDeleted BIT NOT NULL DEFAULT 0,
	 CreateDate DATETIME,
	 UpdateDate DATETIME,
	 CreatedBy INT REFERENCES Users(Id),
	 UpdatedBy INT REFERENCES Users(Id),
);

--create ProductCategories
CREATE TABLE ProductCategories
(
     Id INT PRIMARY KEY IDENTITY,
     [Name] NVARCHAR(30) NOT NULL,
	 IsDeleted BIT NOT NULL DEFAULT 0,
	 CreateDate DATETIME,
	 UpdateDate DATETIME,
	 CreatedBy INT REFERENCES Users(Id),
	 UpdatedBy INT REFERENCES Users(Id),
);

--create ProductTypes
CREATE TABLE CategoryTypes
(
     Id INT PRIMARY KEY IDENTITY,
	 [MainCategory] INT REFERENCES ProductCategories(Id) NOT NULL,
     [Name] NVARCHAR(30) NOT NULL,
	 IsDeleted BIT NOT NULL DEFAULT 0,
	 CreateDate DATETIME,
	 UpdateDate DATETIME,
	 CreatedBy INT REFERENCES Users(Id),
	 UpdatedBy INT REFERENCES Users(Id), 
);

--create products
/* I took the liberty the rename Code and Description collumns as Category and Type for more readabilty */
CREATE TABLE Products
(
     Id INT PRIMARY KEY IDENTITY,
     [Name] NVARCHAR(40) NOT NULL,
     Category INT REFERENCES ProductCategories(Id) NOT NULL,
	 [Type] INT REFERENCES CategoryTypes(Id) NOT NULL,
	 ImagePath VARCHAR(MAX), 
	 Price MONEY CHECK(Price > 0) NOT NULL,
	 IsDeleted BIT NOT NULL DEFAULT 0,
	 CreateDate DATETIME,
	 UpdateDate DATETIME,
	 CreatedBy INT REFERENCES Users(Id),
	 UpdatedBy INT REFERENCES Users(Id),
);

--create statusCodes
CREATE TABLE OrderStatuses
(
      Id INT PRIMARY KEY IDENTITY,
      [Name] VARCHAR(15) NOT NULL,
	  IsDeleted BIT NOT NULL DEFAULT 0,
	  CreateDate DATETIME,
	  UpdateDate DATETIME,
	  CreatedBy INT REFERENCES Users(Id),
	  UpdatedBy INT REFERENCES Users(Id),
); 

--create orders
CREATE TABLE Orders
(
	Id INT PRIMARY KEY IDENTITY,
    Waiter INT REFERENCES Users(Id) NOT NULL,
	[Table] INT REFERENCES [Tables](Id) NOT NULL,
    [Status] INT REFERENCES OrderStatuses(ID) NOT NULL,  
	IsDeleted BIT NOT NULL DEFAULT 0,
	CreateDate DATETIME,
	EndDate DATETIME,
	CreatedBy INT REFERENCES Users(Id),
	UpdatedBy INT REFERENCES Users(Id),
);

--create ordersProducts
CREATE TABLE OrdersProducts
(
	OrderId INT REFERENCES Orders(Id) NOT NULL,
	ProductId INT REFERENCES Products(Id) NOT NULL,
	ProductPrice MONEY,
	ProductQuantity INT NOT NULL,
	IsDeleted BIT NOT NULL DEFAULT 0,
	CreateDate DATETIME,
	UpdateDate DATETIME,
	CreatedBy INT REFERENCES Users(Id),
	UpdatedBy INT REFERENCES Users(Id),
	CONSTRAINT PK_OrdersProducts PRIMARY KEY(OrderId, ProductId)
);


