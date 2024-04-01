CREATE TABLE [dbo].[Products] (
    [ProductID]     INT             IDENTITY (1, 1) NOT NULL,
    [VideoID]       INT             NULL,
    [Name]          VARCHAR (50)    NOT NULL,
    [Specification] VARCHAR (50)    NOT NULL,
    [Price]         DECIMAL (18, 2) NOT NULL,
    [Image]         VARBINARY (MAX) NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([ProductID] ASC),
    CONSTRAINT [FK_Products_Videos] FOREIGN KEY ([VideoID]) REFERENCES [dbo].[Videos] ([VideoID])
);



