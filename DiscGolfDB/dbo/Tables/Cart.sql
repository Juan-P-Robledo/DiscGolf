CREATE TABLE [dbo].[Cart] (
    [CartID]    INT IDENTITY (1, 1) NOT NULL,
    [UserID]    INT NULL,
    [ProductID] INT NOT NULL,
    CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED ([CartID] ASC),
    CONSTRAINT [FK_Table_1_Products] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ProductID]),
    CONSTRAINT [FK_Table_1_Users] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID])
);

