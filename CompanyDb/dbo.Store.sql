CREATE TABLE [dbo].[Store] (
    [StoreID]       INT            IDENTITY (1, 1) NOT NULL,
    [StoreLocation] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED ([StoreID] ASC)
);

