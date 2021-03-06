CREATE TABLE [1474_Smerfetka].Portfel (ID NVARCHAR(450)  NOT NULL, Balance decimal(10, 2) DEFAULT 0 NOT NULL, Status bit NOT NULL, UserID int NOT NULL, PRIMARY KEY (ID));
CREATE TABLE [1474_Smerfetka].Account (ID NVARCHAR(450) NOT NULL, Type varchar(255) NOT NULL, Balance decimal(10, 2) NOT NULL, CreationDate datetime NOT NULL, DiscardDate datetime NULL, Expenses decimal(10, 2) DEFAULT 0 NOT NULL, Income decimal(10, 2) DEFAULT 0 NOT NULL, UserID int NOT NULL, PortfelID int NOT NULL, PRIMARY KEY (ID));
CREATE TABLE [1474_Smerfetka].Expense (ID int IDENTITY NOT NULL, Amount decimal(10, 2) DEFAULT 0 NOT NULL, Time date NOT NULL, IsCyclical bit NOT NULL, DaysCycle int DEFAULT 0 NULL, CurrencyCurrency varchar(3) NOT NULL, CategoryID int NOT NULL, AccountID int NOT NULL, PRIMARY KEY (ID));
CREATE TABLE [1474_Smerfetka].Currency (Currency varchar(3) NOT NULL, PRIMARY KEY (Currency));
CREATE TABLE [1474_Smerfetka].Category (ID int IDENTITY NOT NULL, Name varchar(255) NOT NULL, Description varchar(255) NULL, PRIMARY KEY (ID));
CREATE TABLE [1474_Smerfetka].Income (ID int IDENTITY NOT NULL, Amount decimal(10, 2) DEFAULT 0 NOT NULL, Time date NOT NULL, IsCyclical bit NOT NULL, DaysCycle int DEFAULT 0 NULL, CurrencyCurrency varchar(3) NOT NULL, CategoryID int NOT NULL, AccountID int NOT NULL, PRIMARY KEY (ID));
CREATE TABLE [1474_Smerfetka].Place(ID int IDENTITY NOT NULL,Name varchar(255) NOT NULL, PRIMARY KEY(ID));
CREATE UNIQUE INDEX Portfel_ID ON Portfel (ID);
CREATE UNIQUE INDEX Account_ID ON Account (ID);
CREATE UNIQUE INDEX Expense_ID ON Expense (ID);
CREATE UNIQUE INDEX Category_ID ON Category (ID);
CREATE UNIQUE INDEX Income_ID ON Income (ID);
CREATE UNIQUE INDEX Place_ID ON Place(ID);
ALTER TABLE Portfel ADD CONSTRAINT FKPortfel991300 FOREIGN KEY (UserID) REFERENCES AspNetUsers(Id);
ALTER TABLE Account ADD CONSTRAINT FKAccount182293 FOREIGN KEY (UserID) REFERENCES AspNetUsers(Id);
ALTER TABLE Account ADD CONSTRAINT FKAccount344745 FOREIGN KEY (PortfelID) REFERENCES Portfel (ID);
ALTER TABLE Expense ADD CONSTRAINT FKExpense355057 FOREIGN KEY (CurrencyCurrency) REFERENCES Currency (Currency);
ALTER TABLE Expense ADD CONSTRAINT FKExpense519020 FOREIGN KEY (CategoryID) REFERENCES Category (ID);
ALTER TABLE Expense ADD CONSTRAINT FKExpense571011 FOREIGN KEY (AccountID) REFERENCES Account (ID);
ALTER TABLE Income ADD CONSTRAINT FKIncome926286 FOREIGN KEY (CurrencyCurrency) REFERENCES Currency (Currency);
ALTER TABLE Income ADD CONSTRAINT FKIncome762323 FOREIGN KEY (CategoryID) REFERENCES Category (ID);
ALTER TABLE Income ADD CONSTRAINT FKIncome119235 FOREIGN KEY (AccountID) REFERENCES Account (ID);
ALTER TABLE Place ADD CONSTRAINT FKPlace1 FOREIGN KEY (UserID) REFERENCES AspNetUsers(Id);
ALTER TABLE Expense ADD CONSTRAINT FKExpense1 FOREIGN KEY(Place) REFERENCES Place(ID);
ALTER TABLE Income ADD CONSTRAINT FKPIncome1 FOREIGN KEY(Place) REFERENCES Place(ID);