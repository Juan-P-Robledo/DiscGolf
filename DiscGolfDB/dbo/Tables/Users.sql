CREATE TABLE [dbo].[Users] (
    [UserID]        INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]     VARCHAR (50)  NOT NULL,
    [LastName]      VARCHAR (50)  NOT NULL,
    [Email]         VARCHAR (100) NOT NULL,
    [Password]      VARCHAR (100) NOT NULL,
    [Phone]         VARCHAR (20)  NULL,
    [LastLoginTime] VARCHAR (50)  NULL,
    [isAdmin]       BIT           NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserID] ASC)
);







