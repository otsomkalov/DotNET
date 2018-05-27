CREATE TABLE [dbo].[ToDo] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [IsDone]      BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);