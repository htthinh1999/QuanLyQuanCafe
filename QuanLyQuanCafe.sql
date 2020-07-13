CREATE DATABASE QuanLyQuanCafe
GO

USE QuanLyQuanCafe
GO

-- Food
-- Table
-- FoodCategory
-- Account
-- Bill
-- BillInfo

CREATE TABLE TableFood
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL,
	status NVARCHAR(100) NOT NULL DEFAULT N'Trống' -- Trống / Đã có người
)
GO

CREATE TABLE Account
(
	username VARCHAR(100) PRIMARY KEY,
	password VARCHAR(1000) NOT NULL,
	displayName NVARCHAR(100) NOT NULL DEFAULT N'Nguyễn Văn A',
	type INT NOT NULL DEFAULT 1 -- 0: Quản trị viên, 1: Nhân viên
)
GO

CREATE TABLE FoodCategory
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL
)
GO

CREATE TABLE Food
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL,
	idCategory INT NOT NULL,
	price FLOAT NOT NULL DEFAULT 0,
	
	FOREIGN KEY (idCategory) REFERENCES dbo.FoodCategory(id)
)
GO

CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	idTable INT NOT NULL,
	timeIn DATETIME NOT NULL DEFAULT GETDATE(),
	timeOut DATETIME,
	status NVARCHAR(100) NOT NULL DEFAULT N'Chưa thanh toán', -- Đã thanh toán / Chưa thanh toán

	FOREIGN KEY (idTable) REFERENCES dbo.TableFood(id)
)
GO

CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idFood INT NOT NULL,
	count INT NOT NULL DEFAULT 1,
	
	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idFood) REFERENCES dbo.Food(id)
)
GO