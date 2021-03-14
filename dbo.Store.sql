CREATE TABLE [dbo].[Store] (
    [StoreID]       NVARCHAR (450)  NOT NULL,
    [StoreLocation] NVARCHAR (MAX)  NULL,
    [ItemCost]      DECIMAL (18, 2) NOT NULL,
    [SaleID]        INT             NULL,
    [EmployeeID]    INT             NULL,
    CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED ([StoreID] ASC),
    CONSTRAINT [FK_Store_Employee_EmployeeID] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID]),
    CONSTRAINT [FK_Store_Sale_SaleID] FOREIGN KEY ([SaleID]) REFERENCES [dbo].[Sale] ([SaleID])
);


GO
CREATE NONCLUSTERED INDEX [IX_Store_EmployeeID]
    ON [dbo].[Store]([EmployeeID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Store_SaleID]
    ON [dbo].[Store]([SaleID] ASC);

