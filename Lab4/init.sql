CREATE TABLE [dbo].[ToDo] (
    [Id]          INT            NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [IsDone]      BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);