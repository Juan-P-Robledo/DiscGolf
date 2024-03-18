CREATE TABLE [dbo].[Videos] (
    [VideoID]     INT           NOT NULL,
    [Link]        VARCHAR (50)  NOT NULL,
    [Description] VARCHAR (200) NOT NULL,
    [Duration]    INT           NOT NULL,
    CONSTRAINT [PK_Videos] PRIMARY KEY CLUSTERED ([VideoID] ASC)
);

