CREATE TABLE [dbo].[Employee] (
    [EmployeeID]        INT            IDENTITY (1, 1) NOT NULL,
    [LastName]          NVARCHAR (MAX) NULL,
    [First_Middle_Name] NVARCHAR (MAX) NULL,
    [HireDate]          DATETIME2 (7)  NOT NULL,
    [StoreID] INT NOT NULL, 
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([EmployeeID] ASC)
);

