CREATE TABLE [dbo].[Products] (
    [ProductID]   INT             IDENTITY (1, 1) NOT NULL,
    [VideoID]     INT             NULL,
    [Code]        VARCHAR (5)     NOT NULL,
    [Name]        VARCHAR (50)    NOT NULL,
    [Brand]       VARCHAR (50)    NOT NULL,
    [Price]       DECIMAL (18, 2) NOT NULL,
    [Image]       VARCHAR (300)   NULL,
    [Description] VARCHAR (200)   NOT NULL,
    [CategoryID]  INT             NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([ProductID] ASC),
    CONSTRAINT [FK_Products_Category] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Category] ([CategoryID]),
    CONSTRAINT [FK_Products_Videos] FOREIGN KEY ([VideoID]) REFERENCES [dbo].[Videos] ([VideoID])
);













