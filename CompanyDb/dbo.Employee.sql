CREATE TABLE [dbo].[Employee] (
    [EmployeeID]        INT           IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (50) NOT NULL,
    [LastName]          NVARCHAR (50) NOT NULL,
    [HireDate]          DATETIME2 (7) NOT NULL,
    [StoreID]           INT           NOT NULL,
    [DepartmentID]      INT           NOT NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([EmployeeID] ASC),
    CONSTRAINT [FK_Employee_Department_DepartmentID] FOREIGN KEY ([DepartmentID]) REFERENCES [dbo].[Department] ([DepartmentID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Employee_Store_StoreID] FOREIGN KEY ([StoreID]) REFERENCES [dbo].[Store] ([StoreID]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Employee_DepartmentID]
    ON [dbo].[Employee]([DepartmentID] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Employee_StoreID]
    ON [dbo].[Employee]([StoreID] ASC);

