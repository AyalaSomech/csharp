

CREATE DATABASE PhotoManagmentDB_Sara

--USE PhotoManagmentMaxTeam;

USE PhotoManagmentDB_Sara;

-- טבלת סטטוסים
CREATE TABLE Statuse (
    ProcessStatus INT  NOT NULL IDENTITY(1,1) PRIMARY KEY ,
    StatusDescription NVARCHAR(255) NOT NULL
);


-- טבלת לקוחות
CREATE TABLE Customers (
    CustomerCode NVARCHAR(50) NOT NULL PRIMARY KEY,
    NameE NVARCHAR(100) NOT NULL,
    Phone INT NOT NULL
);


-- טבלת קצינים
CREATE TABLE Officer (
    OfficerCode NVARCHAR(50) NOT NULL PRIMARY KEY,
    NameE NVARCHAR(100) NOT NULL,
    Phone INT NOT NULL
);


-- טבלת ניהול הזמנות
CREATE TABLE OrderManagement (
    OrderCode NVARCHAR(50)  NOT NULL PRIMARY KEY,
    ProcessStatus INT NOT NULL ,-- CONSTRAINT FK_OrderManagement_Status FOREIGN KEY (ProcessStatus) REFERENCES Statuse(ProcessStatus),
    OfficerCode NVARCHAR(50) NOT NULL  ,--   CONSTRAINT FK_OrderManagement_Officer FOREIGN KEY (OfficerCode) REFERENCES Officer(OfficerCode),
    CustomerCode NVARCHAR(50) NOT NULL --CONSTRAINT FK_OrderManagement_Customer FOREIGN KEY (CustomerCode) REFERENCES Customers(CustomerCode)
);

-- טבלת שמירת תמונות
CREATE TABLE SavingImages (
    Id INT IDENTITY(1,1) ,
    OrderCode NVARCHAR(50) NOT NULL, -- CONSTRAINT FK_SavingImages_Order FOREIGN KEY (OrderCode) REFERENCES OrderManagement(OrderCode),
    Images VARBINARY(MAX) NOT NULL,
    ProcessStatus INT NOT NULL, --CONSTRAINT FK_SavingImages_Status FOREIGN KEY (ProcessStatus) REFERENCES Statuse(ProcessStatus),
	SizeImage FLOAT NOT NULL
);

