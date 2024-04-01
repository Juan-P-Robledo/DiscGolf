CREATE TABLE [dbo].[Collection] (
    [CollectionID] INT IDENTITY (1, 1) NOT NULL,
    [UserID]       INT NOT NULL,
    [ProductID]    INT NOT NULL,
    CONSTRAINT [PK_Collection] PRIMARY KEY CLUSTERED ([CollectionID] ASC),
    CONSTRAINT [FK_Collection_Products] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ProductID]),
    CONSTRAINT [FK_Collection_Users] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID])
);



