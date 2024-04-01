CREATE TABLE [dbo].[Orders] (
    [OrderID]   INT             IDENTITY (1, 1) NOT NULL,
    [UserID]    INT             NOT NULL,
    [ProductID] INT             NOT NULL,
    [Price]     DECIMAL (18, 2) NOT NULL,
    [Date]      DATE            NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([OrderID] ASC),
    CONSTRAINT [FK_Orders_Products] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ProductID]),
    CONSTRAINT [FK_Orders_Users] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID])
);



