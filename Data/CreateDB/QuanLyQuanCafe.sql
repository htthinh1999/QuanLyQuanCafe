CREATE DATABASE QuanLyQuanCafe
GO

USE QuanLyQuanCafe
GO

--**************************************** CREATE TABLES ****************************************--

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
	typeID INT NOT NULL DEFAULT 2, -- 1: Quản trị viên, 2: Nhân viên
	sex NVARCHAR(5) NOT NULL DEFAULT N'Nam', -- Nam / Nữ
	birthday DATE NOT NULL,
	address NVARCHAR(100) NOT NULL,

	FOREIGN KEY(typeID) REFERENCES dbo.AccountType(id)
)
GO

CREATE TABLE State
(
	id INT IDENTITY PRIMARY KEY, -- 1: Sử dụng, 2: Ngưng sử dụng
	name NVARCHAR(50) NOT NULL
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
	stateID INT NOT NULL DEFAULT 1,
	
	FOREIGN KEY (idCategory) REFERENCES dbo.FoodCategory(id),
	FOREIGN KEY (stateID) REFERENCES dbo.State(id)
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

--**************************************** END CREATE TABLES ****************************************--


--**************************************** INSERT DATA ****************************************--

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

INSERT INTO dbo.State(name) VALUES(N'Sử dụng')
INSERT INTO dbo.State(name) VALUES(N'Ngưng sử dụng')

INSERT INTO dbo.FoodCategory(name) VALUES(N'Thức ăn')
INSERT INTO dbo.FoodCategory(name) VALUES(N'Thức uống')

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

--**************************************** END INSERT DATA ****************************************--


--**************************************** CREATE PROCEDURES ****************************************--

------------------------------ PROCEDURES OF dbo.State ------------------------------

CREATE PROC USP_LoadStateList
AS
	SELECT * FROM State
GO

------------------------------ END PROCEDURES OF dbo.State ------------------------------

------------------------------ PROCEDURES OF dbo.FoodCategory ------------------------------

CREATE PROC USP_LoadFoodCategoryList
AS
	SELECT * FROM dbo.FoodCategory
GO

CREATE PROC	USP_ExistCategory
@categoryName NVARCHAR(100)
AS
	SELECT *
	FROM dbo.FoodCategory
	WHERE Name = @categoryName
GO

CREATE PROC USP_AddFoodCategory
@categoryName NVARCHAR(100)
AS
    INSERT INTO dbo.FoodCategory
	VALUES(@categoryName)
GO

CREATE PROC USP_UpdateFoodCategory
@id INT,
@categoryName NVARCHAR(100)
AS
    UPDATE dbo.FoodCategory SET name = @categoryName
	WHERE id = @id
GO

CREATE PROC USP_DeleteFoodCategory
@id INT
AS
	DELETE dbo.FoodCategory WHERE id = @id
GO

------------------------------ END PROCEDURES OF dbo.FoodCategory ------------------------------

------------------------------ PROCEDURES OF dbo.Food ------------------------------

CREATE PROC USP_LoadFoodList
AS
	SELECT f.id [ID], f.name [Tên món], fc.name [Danh mục], price [Giá tiền], s.name [Trạng thái]
    FROM dbo.Food f INNER JOIN dbo.FoodCategory fc ON fc.id = f.idCategory
				INNER JOIN dbo.State s ON f.stateID = s.id
GO

CREATE PROC USP_LoadFoodListByCategoryID
@idCategory INT
AS
	SELECT *
	FROM dbo.Food
	WHERE idCategory = @idCategory AND stateID = 1
GO

CREATE PROC USP_ExistFood
@foodName NVARCHAR(100)
AS
	SELECT * FROM dbo.Food where name = @foodName
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

CREATE PROC USP_SearchFood
@text NVARCHAR(100)
AS
	SELECT f.id [ID], f.name [Tên món], fc.name [Loại món], price [Giá tiền]
	FROM dbo.Food f INNER JOIN dbo.FoodCategory fc ON fc.id = f.idCategory
	WHERE dbo.fuConvertToUnsign(f.name) LIKE dbo.fuConvertToUnsign(@text)
GO

CREATE PROC USP_AddFood
@foodName NVARCHAR(100),
@idCategory INT,
@price FLOAT
AS
	INSERT INTO dbo.Food(name, idCategory, price) VALUES(@foodName, @idCategory, @price)
GO

CREATE PROC USP_UpdateFood
@idFood INT,
@foodName NVARCHAR(100),
@idCategory INT,
@price FLOAT,
@stateID INT
AS
	UPDATE dbo.Food
	SET name = @foodName, idCategory = @idCategory, price = @price, stateID = @stateID
	WHERE id = @idFood
GO

CREATE PROC USP_DeleteFood
@idFood INT
AS
	DELETE dbo.Food WHERE id = @idFood
GO

CREATE PROC USP_FoodWasUsing
@idFood INT
AS
	SELECT id FROM dbo.BillInfo WHERE idFood = @idFood
GO

------------------------------ END PROCEDURES OF dbo.Food ------------------------------

------------------------------ PROCEDURES OF dbo.Bill & dbo.BillInfo ------------------------------

CREATE PROC USP_GetBillUnCheckOutByTableID
@idTable INT
AS
	SELECT *
	FROM Bill
	WHERE status = N'Chưa thanh toán' AND idTable = @idTable
GO

CREATE PROC USP_CheckoutTable
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

-- This procdure load all bill -> slow
CREATE PROC USP_GetListBillCheckedOutByDate
@fromDate DATETIME,
@toDate DATETIME
AS
BEGIN
    SELECT name [Tên bàn], CONVERT(VARCHAR(20), timeIn, 100) [Thời gian vào], CONVERT(VARCHAR(20), timeOut, 100) [Thời gian ra], totalPrice [Tổng hóa đơn], discount [Giảm giá]
	FROM dbo.Bill INNER JOIN dbo.TableFood ON TableFood.id = Bill.idTable
	WHERE Bill.status = N'Đã thanh toán' AND timeOut >= @fromDate AND timeOut <= @toDate + 1
END
GO

CREATE PROC USP_GetListBillCheckedOutByDateAndPage
@fromDate DATETIME,
@toDate DATETIME,
@page INT,
@rowsPerPage int
AS
    SELECT rowNumber [STT] ,name [Tên bàn], CONVERT(VARCHAR(20), timeIn, 100) [Thời gian vào], CONVERT(VARCHAR(20), timeOut, 100) [Thời gian ra], totalPrice [Tổng hóa đơn], discount [Giảm giá]
	FROM (SELECT ROW_NUMBER() OVER(ORDER BY Bill.ID) rowNumber, name, timeIn, timeOut, totalPrice, discount
			FROM dbo.Bill INNER JOIN dbo.TableFood ON TableFood.id = Bill.idTable
			WHERE Bill.status = N'Đã thanh toán' AND timeOut >= @fromDate AND timeOut <= @toDate + 1) tableWithPage
	WHERE rowNumber BETWEEN (@page-1)*@rowsPerPage+1 AND @page*@rowsPerPage
GO

CREATE PROC USP_GetMaxPageOfListBillCheckedOutByDate
@fromDate DATETIME,
@toDate DATETIME
AS
    SELECT COUNT(*)
	FROM dbo.Bill INNER JOIN dbo.TableFood ON dbo.TableFood.id = Bill.idTable
	WHERE Bill.status = N'Đã thanh toán' AND timeOut >= @fromDate AND timeOut <= @toDate + 1
GO

CREATE PROC USP_GetBillByTableID
@idTable INT
AS
	SELECT f.name, bi.count, f.price, totalPrice = f.price * count
	FROM dbo.Food f INNER JOIN dbo.BillInfo bi ON bi.idFood = f.id
					INNER JOIN dbo.Bill b ON b.id = bi.idBill
	WHERE b.idTable = @idTable AND b.status = N'Chưa thanh toán'
GO

------------------------------ END PROCEDURES OF dbo.Bill & dbo.BillInfo ------------------------------

------------------------------ PROCEDURES OF dbo.Account & dbo.AccountInfo ------------------------------

CREATE PROC USP_LoadAccountList
AS
	SELECT username [Tên tài khoản], displayName [Tên hiển thị], t.name [Loại tài khoản], sex [Giới tính], birthday [Ngày sinh], address [Địa chỉ]
    FROM dbo.Account a INNER JOIN dbo.AccountType t ON t.id = a.typeID
GO

CREATE PROC USP_LoadAccountTypeList
AS
	SELECT *
	FROM AccountType
GO

CREATE PROC USP_ExistAccount
@username VARCHAR(100)
AS
	SELECT *
	FROM Account
	WHERE username = @username
GO

CREATE PROC USP_Login
@username VARCHAR(100),
@password VARCHAR(100)
AS
	SELECT username
	FROM dbo.Account
	WHERE username = @username AND password = @password
GO

CREATE PROC USP_GetAccountInfoByUsername
@username VARCHAR(100)
AS
    SELECT *
	FROM dbo.Account
	WHERE username = @username
GO

CREATE PROC USP_UpdateAccountInfo
@username VARCHAR(100),
@displayName NVARCHAR(100),
@typeID INT,
@sex NVARCHAR(5),
@birthday DATE,
@address NVARCHAR(100)
AS
    UPDATE dbo.Account
	SET displayName = @displayName, typeID = @typeID, sex = @sex, birthday = @birthday, address = @address
	WHERE username = @username
GO

CREATE PROC USP_UpdatePassword
@username VARCHAR(100),
@newPass VARCHAR(100)
AS
	UPDATE dbo.Account
	SET password = @newPass
	WHERE username = @username
GO

CREATE PROC USP_AddAccount
@username VARCHAR(100),
@displayName NVARCHAR(100),
@typeID INT,
@sex NVARCHAR(5),
@birthday DATE,
@address NVARCHAR(100)
AS
    INSERT INTO dbo.Account
    (username, displayName, typeID, sex, birthday, address)
    VALUES
    (@username, @displayName, @typeID, @sex, @birthday, @address)
GO

CREATE PROC USP_DeleteAccount
@username VARCHAR(100)
AS
    DELETE FROM dbo.Account
	WHERE username = @username
GO

CREATE PROC USP_ResetPassword
@username VARCHAR(100)
AS
    UPDATE dbo.Account
	SET password = 'c4ca4238a0b923820dcc509a6f75849b'
	WHERE username = @username
GO

------------------------------ END PROCEDURES OF dbo.Account & dbo.AccountInfo ------------------------------

------------------------------ PROCEDURES OF dbo.TableFood ------------------------------

CREATE PROC USP_LoadTableList
AS
	SELECT * FROM dbo.TableFood
GO

CREATE PROC USP_ExistTableFood
@tableName NVARCHAR(100)
AS
BEGIN
    SELECT *
	FROM dbo.TableFood
	WHERE name = @tableName
END
GO

CREATE PROC USP_LoadTableStatusByID
@tableID INT
AS
    SELECT id, name, status
	FROM dbo.TableFood
	WHERE id = @tableID
GO

CREATE PROC USP_LoadTableStatusList
AS
    SELECT DISTINCT(status) FROM TableFood
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

CREATE PROC USP_AddTableFood
@tableName NVARCHAR(100)
AS
BEGIN
    INSERT INTO dbo.TableFood
    (name) VALUES(@tableName)
END
GO

CREATE PROC USP_UpdateTableFood
@id INT,
@tableName NVARCHAR(100)
AS
BEGIN
    UPDATE dbo.TableFood
	SET name = @tableName
	WHERE id = @id
END
GO

CREATE PROC USP_DeleteTableFood
@id INT
AS
	DELETE dbo.TableFood
	WHERE id = @id
GO
------------------------------ END PROCEDURES OF dbo.TableFood ------------------------------

--**************************************** END CREATE PROCEDURES ****************************************--


--**************************************** CREATE TRIGGERS ****************************************--

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

--**************************************** END CREATE TRIGGERS ****************************************--


--**************************************** CREATE FUNCTIONS ****************************************--

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

--**************************************** END CREATE FUNCTIONS ****************************************--
