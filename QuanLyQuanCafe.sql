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

CREATE TABLE AccountType
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(50) NOT NULL
)
GO

CREATE TABLE Account
(
	username VARCHAR(100) PRIMARY KEY,
	password VARCHAR(1000) NOT NULL DEFAULT 'c4ca4238a0b923820dcc509a6f75849b', -- default password = '1'
	displayName NVARCHAR(100) NOT NULL,
	typeID INT REFERENCES dbo.AccountType(id) NOT NULL DEFAULT 2, -- 1: Quản trị viên, 2: Nhân viên
	sex NVARCHAR(5) NOT NULL DEFAULT N'Nam', -- Nam / Nữ
	birthday DATE NOT NULL,
	address NVARCHAR(100) NOT NULL
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
	totalPrice FLOAT NOT NULL DEFAULT 0,
	discount INT NOT NULL DEFAULT 0,
	timeIn DATETIME NOT NULL DEFAULT GETDATE(),
	timeOut DATETIME DEFAULT NULL,
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

------------------------------------------ INSERT DATA ------------------------------------------
SELECT username [Tên tài khoản], displayName [Tên hiển thị], t.name [Loại tài khoản], sex [Giới tính], birthday [Ngày sinh], address [Địa chỉ]
FROM Account a INNER JOIN dbo.AccountType t ON t.id = a.typeID

INSERT INTO dbo.AccountType
(
    name
)
VALUES
(N'Quản trị viên' -- name - nvarchar(50)
    )
GO

INSERT INTO dbo.AccountType
(
    name
)
VALUES
(N'Nhân viên' -- name - nvarchar(50)
    )
GO    

INSERT INTO dbo.Account
(
    username,
    password,
    displayName,
    typeID,
    sex,
    birthday,
    address
)
VALUES
(   'admin',        -- username - varchar(100)
    '21232f297a57a5a743894a0e4a801fc3',        -- password - varchar(1000) = 'admin'
    N'ADMIN',       -- displayName - nvarchar(100)
    1,         -- type - int
    N'Nam',       -- sex - nvarchar(5)
    '19990927', -- birthday - date
    N'Khánh Hòa'        -- address - nvarchar(50)
    )
GO

INSERT INTO dbo.Account
(
    username,
    password,
    displayName,
    typeID,
    sex,
    birthday,
    address
)
VALUES
(   'htthinh',        -- username - varchar(100)
    '202cb962ac59075b964b07152d234b70',        -- password - varchar(1000) = '123'
    N'Huỳnh Tấn Thịnh',       -- displayName - nvarchar(100)
    2,         -- type - int
    N'Nam',       -- sex - nvarchar(5)
    '19990927', -- birthday - date
    N'Khánh Hòa'        -- address - nvarchar(50)
    )
GO

INSERT INTO dbo.Account
(
    username,
    password,
    displayName,
    typeID,
    sex,
    birthday,
    address
)
VALUES
(   'thoathoa',        -- username - varchar(100)
    '202cb962ac59075b964b07152d234b70',        -- password - varchar(1000) = '123'
    N'Nguyễn Thị Kim Thoa',       -- displayName - nvarchar(100)
    1,         -- typeID - int
    N'Nữ',       -- sex - nvarchar(5)
    '19990512', -- birthday - date
    N'Khánh Hòa'        -- address - nvarchar(100)
    )
GO

DECLARE @i INT = 1
WHILE(@i <= 20)
BEGIN
    INSERT INTO dbo.TableFood(name) VALUES (N'Bàn số ' + CAST(@i AS NVARCHAR(3)))
	SELECT @i = @i + 1
END
GO

INSERT INTO dbo.FoodCategory
(
    name
)
VALUES
(N'Thức ăn' -- name - nvarchar(100)
    )

INSERT INTO dbo.FoodCategory
(
    name
)
VALUES
(N'Thức uống' -- name - nvarchar(100)
    )

INSERT INTO dbo.Food
(
    name,
    idCategory,
    price
)
VALUES
(   N'Bánh mì thịt', -- name - nvarchar(100)
    1,   -- idCategory - int
    20000.0  -- price - float
    )

INSERT INTO dbo.Food
(
    name,
    idCategory,
    price
)
VALUES
(   N'Bò né', -- name - nvarchar(100)
    1,   -- idCategory - int
    50000.0  -- price - float
    )

INSERT INTO dbo.Food
(
    name,
    idCategory,
    price
)
VALUES
(   N'Cafe đen', -- name - nvarchar(100)
    2,   -- idCategory - int
    15000.0  -- price - float
    )

INSERT INTO dbo.Food
(
    name,
    idCategory,
    price
)
VALUES
(   N'Cafe sữa', -- name - nvarchar(100)
    2,   -- idCategory - int
    20000.0  -- price - float
    )

INSERT INTO dbo.Food
(
    name,
    idCategory,
    price
)
VALUES
(   N'Cafe đá xay', -- name - nvarchar(100)
    2,   -- idCategory - int
    30000.0  -- price - float
    )

INSERT INTO dbo.Bill(idTable) VALUES(1)
INSERT INTO dbo.Bill(idTable) VALUES(4)
INSERT INTO dbo.Bill(idTable) VALUES(5)
INSERT INTO dbo.Bill(idTable) VALUES(10)

INSERT INTO dbo.BillInfo
(
    idBill,
    idFood,
    count
)
VALUES
(   1, -- idBill - int
    2, -- idFood - int
    5  -- count - int
    )

INSERT INTO dbo.BillInfo
(
    idBill,
    idFood,
    count
)
VALUES
(   1, -- idBill - int
    4, -- idFood - int
    5  -- count - int
    )

INSERT INTO dbo.BillInfo
(
    idBill,
    idFood,
    count
)
VALUES
(   2, -- idBill - int
    1, -- idFood - int
    4  -- count - int
    )

INSERT INTO dbo.BillInfo
(
    idBill,
    idFood,
    count
)
VALUES
(   2, -- idBill - int
    3, -- idFood - int
    2  -- count - int
    )

INSERT INTO dbo.BillInfo
(
    idBill,
    idFood,
    count
)
VALUES
(   2, -- idBill - int
    4, -- idFood - int
    2  -- count - int
    )

INSERT INTO dbo.BillInfo
(
    idBill,
    idFood,
    count
)
VALUES
(   3, -- idBill - int
    3, -- idFood - int
    1  -- count - int
    )

INSERT INTO dbo.BillInfo
(
    idBill,
    idFood,
    count
)
VALUES
(   3, -- idBill - int
    4, -- idFood - int
    1  -- count - int
    )

INSERT INTO dbo.BillInfo
(
    idBill,
    idFood,
    count
)
VALUES
(   3, -- idBill - int
    5, -- idFood - int
    1  -- count - int
    )

INSERT INTO dbo.BillInfo
(
    idBill,
    idFood,
    count
)
VALUES
(   4, -- idBill - int
    4, -- idFood - int
    1  -- count - int
    )

UPDATE dbo.TableFood
SET status = N'Đã có người'
WHERE id = 1 OR id = 4 OR id = 5 OR id = 10
GO

------------------------------------------ END INSERT DATA ------------------------------------------


------------------------------------------ CREATE PROCEDURES ------------------------------------------

CREATE PROC USP_Login
@username VARCHAR(100),
@password VARCHAR(100)
AS
BEGIN
	SELECT username
	FROM dbo.Account
	WHERE username = @username AND password = @password
END
GO

CREATE PROC USP_LoadTableStatus
@tableID INT
AS
BEGIN
    SELECT id, name, status
	FROM dbo.TableFood
	WHERE id = @tableID
END
GO

CREATE PROC USP_LoadTableList
AS
BEGIN
	SELECT id, name, status FROM dbo.TableFood
END
GO

CREATE PROC USP_GetBillByTableID
@idTable INT
AS
BEGIN
	SELECT f.name, bi.count, f.price, totalPrice = f.price * count
	FROM dbo.Food f INNER JOIN dbo.BillInfo bi ON bi.idFood = f.id
					INNER JOIN dbo.Bill b ON b.id = bi.idBill
	WHERE b.idTable = @idTable AND b.status = N'Chưa thanh toán'
END
GO

CREATE PROC USP_AddFoodToTable
@foodID INT,
@count INT,
@tableID INT
AS
BEGIN
	DECLARE @billID INT, @numberOfFoodNameOnTable INT
	
	SELECT @billID = id
	FROM dbo.Bill
	WHERE idTable = @tableID AND status = N'Chưa thanh toán'
	
	SELECT @numberOfFoodNameOnTable = COUNT(*)
	FROM dbo.BillInfo
	WHERE idBill = @billID

	IF (@numberOfFoodNameOnTable > 0)
	BEGIN
		DECLARE @existFood INT
		
		SELECT @existFood = COUNT(*)
		FROM dbo.BillInfo
		WHERE idBill = @billID AND idFood = @foodID
		
		IF (@existFood > 0)
		BEGIN
			DECLARE @rest INT

			SELECT @rest = count + @count
			FROM dbo.BillInfo
			WHERE idBill = @billID AND idFood = @foodID

			IF (@rest <= 0)
				DELETE dbo.BillInfo
				WHERE idBill = @billID AND idFood = @foodID
			ELSE
				UPDATE dbo.BillInfo
				SET count = @rest
				WHERE idBill = @billID AND idFood = @foodID
		END
		ELSE
        BEGIN
            INSERT INTO dbo.BillInfo
            (
                idBill,
                idFood,
                count
            )
            VALUES
            (   @billID, -- idBill - int
                @foodID, -- idFood - int
                @count  -- count - int
                )
        END
	END
	ELSE
	BEGIN
		IF (@count > 0)
		BEGIN
			INSERT INTO dbo.Bill(idTable) VALUES (@tableID)

			SELECT @billID = MAX(id)
			FROM dbo.Bill

			INSERT INTO dbo.BillInfo
			(
				idBill,
				idFood,
				count
			)
			VALUES
			(   @billID, -- idBill - int
				@foodID, -- idFood - int
				@count  -- count - int
				)
		END
	END
END
GO

CREATE PROC USP_CheckOutTable
@tableID INT,
@totalPrice FLOAT,
@discount INT
AS
BEGIN
    DECLARE @billID INT
	
	SELECT @billID = id
	FROM dbo.Bill
	WHERE idTable = @tableID AND status = N'Chưa thanh toán'

	UPDATE dbo.Bill
	SET timeOut = GETDATE(), totalPrice = @totalPrice, discount = @discount, status = N'Đã thanh toán'
	WHERE id = @billID

	UPDATE dbo.TableFood
	SET status = N'Trống'
	WHERE id = @tableID
END
GO

CREATE PROC USP_MoveTable
@firstTableID INT,
@secondTableID INT
AS
BEGIN
	DECLARE @oldBillID INT, @newBillID int
	
	SELECT @oldBillID = id
	FROM dbo.Bill
	WHERE idTable = @firstTableID AND status = N'Chưa thanh toán'

	SELECT @newBillID = id
	FROM dbo.Bill
	WHERE idTable = @secondTableID AND status = N'Chưa thanh toán'

	IF(@newBillID IS NULL)
	BEGIN
	    INSERT INTO dbo.Bill(idTable) VALUES (@secondTableID)
		
		SELECT @newBillID = MAX(id)
		FROM dbo.Bill
	END

	UPDATE dbo.BillInfo
	SET idBill = @newBillID
	WHERE idBill = @oldBillID

	UPDATE dbo.TableFood
	SET status = N'Trống'
	WHERE id = @firstTableID

	UPDATE dbo.TableFood
	SET status = N'Đã có người'
	WHERE id = @secondTableID
END
GO

-- This procdure load all bill -> slow
/*
CREATE PROC USP_GetListBillByDate
@fromDate DATETIME,
@toDate DATETIME
AS
BEGIN
    SELECT name [Tên bàn], CONVERT(VARCHAR(20), timeIn, 100) [Thời gian vào], CONVERT(VARCHAR(20), timeOut, 100) [Thời gian ra], totalPrice [Tổng hóa đơn], discount [Giảm giá]
	FROM dbo.Bill INNER JOIN dbo.TableFood ON TableFood.id = Bill.idTable
	WHERE Bill.status = N'Đã thanh toán' AND timeOut >= @fromDate AND timeOut <= @toDate + 1
END
GO
*/

CREATE PROC USP_GetListBillByDateAndPage
@fromDate DATETIME,
@toDate DATETIME,
@page INT,
@rowsPerPage int
AS
BEGIN
    SELECT rowNumber [STT] ,name [Tên bàn], CONVERT(VARCHAR(20), timeIn, 100) [Thời gian vào], CONVERT(VARCHAR(20), timeOut, 100) [Thời gian ra], totalPrice [Tổng hóa đơn], discount [Giảm giá]
	FROM (SELECT ROW_NUMBER() OVER(ORDER BY Bill.ID) rowNumber, name, timeIn, timeOut, totalPrice, discount
			FROM dbo.Bill INNER JOIN dbo.TableFood ON TableFood.id = Bill.idTable
			WHERE Bill.status = N'Đã thanh toán' AND timeOut >= @fromDate AND timeOut <= @toDate + 1) tableWithPage
	WHERE rowNumber BETWEEN (@page-1)*@rowsPerPage+1 AND @page*@rowsPerPage
END
GO

CREATE PROC USP_GetAccountInfoByUsername
@username VARCHAR(100)
AS
BEGIN
    SELECT *
	FROM dbo.Account
	WHERE username = @username
END
GO

CREATE PROC USP_UpdateAccountInfo
@username VARCHAR(100),
@displayName NVARCHAR(100),
@typeID INT,
@sex NVARCHAR(5),
@birthday DATE,
@address NVARCHAR(100)
AS
BEGIN
    UPDATE dbo.Account
	SET displayName = @displayName, typeID = @typeID, sex = @sex, birthday = @birthday, address = @address
	WHERE username = @username
END
GO

CREATE PROC USP_UpdatePassword
@username VARCHAR(100),
@newPass VARCHAR(100)
AS
BEGIN
	UPDATE dbo.Account
	SET password = @newPass
	WHERE username = @username
END
GO

CREATE PROC USP_AddAccount
@username VARCHAR(100),
@displayName NVARCHAR(100),
@typeID INT,
@sex NVARCHAR(5),
@birthday DATE,
@address NVARCHAR(100)
AS
BEGIN
    INSERT INTO dbo.Account
    (username, displayName, typeID, sex, birthday, address)
    VALUES
    (@username, @displayName, @typeID, @sex, @birthday, @address)
END
GO

CREATE PROC USP_DeleteAccount
@username VARCHAR(100)
AS
BEGIN
    DELETE FROM dbo.Account
	WHERE username = @username
END
GO

CREATE PROC USP_ResetPassword
@username VARCHAR(100)
AS
BEGIN
    UPDATE dbo.Account
	SET password = 'c4ca4238a0b923820dcc509a6f75849b'
	WHERE username = @username
END

------------------------------------------ END CREATE PROCEDURES ------------------------------------------


------------------------------------------ CREATE TRIGGERS ------------------------------------------

CREATE TRIGGER UTG_UpdateBillInfo
ON dbo.BillInfo FOR INSERT, UPDATE
AS
BEGIN
    DECLARE @billID INT

	SELECT @billID = idBill
	FROM Inserted

	UPDATE dbo.Bill
	SET status = N'Chưa thanh toán'
	WHERE id = @billID

	DECLARE @tableID INT

	SELECT @tableID = idTable
	FROM dbo.Bill
	WHERE id = @billID

	UPDATE dbo.TableFood
	SET status = N'Đã có người'
	WHERE id = @tableID
	
	DECLARE @existFoodOnTable INT = 0

	SELECT @existFoodOnTable = COUNT(*)
	FROM dbo.BillInfo
	WHERE idBill = @billID

	IF (@existFoodOnTable = 0)
	BEGIN
	    UPDATE dbo.TableFood
		SET status = N'Trống'
		WHERE id = @tableID
	END

	-- Check duplicate, update and delete it

	DECLARE @numberFoodToCheckDuplicate INT

	SELECT @numberFoodToCheckDuplicate = COUNT(*)
	FROM Inserted

	WHILE @numberFoodToCheckDuplicate > 0
	BEGIN
	    DECLARE @duplicateFood INT, @idFoodInserted INT

		SELECT @idFoodInserted = idFood
		FROM (
			SELECT ROW_NUMBER() OVER (ORDER BY id) [RowNum], idFood
			FROM Inserted
		) TableNthRow
		WHERE RowNum = @numberFoodToCheckDuplicate

		SELECT @duplicateFood = COUNT(*)
		FROM dbo.BillInfo
		WHERE idBill = @billID AND idFood = @idFoodInserted

		IF(@duplicateFood>1)
		BEGIN
			DECLARE @firstDuplicateID INT, @secondDuplicateID INT

			SELECT @firstDuplicateID = MIN(id)
			FROM dbo.BillInfo
			WHERE idBill = @billID AND idFood = @idFoodInserted

			SELECT @secondDuplicateID = MAX(id)
			FROM dbo.BillInfo
			WHERE idBill = @billID AND idFood = @idFoodInserted

			UPDATE dbo.BillInfo
			SET count = count + (SELECT count FROM dbo.BillInfo WHERE id = @secondDuplicateID)
			WHERE id = @firstDuplicateID

			DELETE dbo.BillInfo
			WHERE id = @secondDuplicateID
		END

		SET @numberFoodToCheckDuplicate = @numberFoodToCheckDuplicate - 1
	END
END
GO


------------------------------------------ END CREATE TRIGGERS ------------------------------------------


------------------------------------------ CREATE FUNCTIONS ---------------------------------------------

CREATE FUNCTION [dbo].[fuConvertToUnsign]
(
@strInput NVARCHAR(4000)
)
RETURNS NVARCHAR(4000)
AS
BEGIN 
	IF @strInput IS NULL RETURN @strInput
	IF @strInput = '' RETURN @strInput
	DECLARE @RT NVARCHAR(4000)
	DECLARE @SIGN_CHARS NCHAR(136)
	DECLARE @UNSIGN_CHARS NCHAR (136)
	SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế
	ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý
	ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ
	ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ'
	+NCHAR(272)+ NCHAR(208)
	SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee
	iiiiiooooooooooooooouuuuuuuuuuyyyyy
	AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII
	OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD'
	DECLARE @COUNTER int
	DECLARE @COUNTER1 int
	SET @COUNTER = 1
	WHILE (@COUNTER <=LEN(@strInput))
	BEGIN 
		SET @COUNTER1 = 1
		WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1)
		BEGIN
			IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1))
			= UNICODE(SUBSTRING(@strInput,@COUNTER ,1) )
			BEGIN 
				IF @COUNTER=1
					SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1)
					+ SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) 
				ELSE
					SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1)
					+SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1)
					+ SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER)
				BREAK
			END
			SET @COUNTER1 = @COUNTER1 +1
		END
		SET @COUNTER = @COUNTER +1
	END
	SET @strInput = replace(@strInput,' ','-')
	RETURN @strInput
END
GO

------------------------------------------ END CREATE FUNCTIONS -----------------------------------------
