CREATE TABLE [dbo].[Filter] (
    [FilterID]   INT          IDENTITY (1, 1) NOT NULL,
    [FilterName] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Filter] PRIMARY KEY CLUSTERED ([FilterID] ASC)
);



