﻿CREATE TABLE [dbo].[ToDo]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Name] TEXT NOT NULL,
	[Description] TEXT NOT NULL,
	[IsDone] BIT NOT NULL
)