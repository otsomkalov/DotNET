SP_CONFIGURE 'clr enabled', 1
GO
RECONFIGURE
GO

CREATE TABLE [dbo].[Users]
(
	[Name] NVARCHAR(100) NOT NULL,
	[MoneyAmount] int
)
GO

CREATE ASSEMBLY CLRSQL
	FROM 'D:\Documents\Projects\DotNET\CLRSQL\bin\Debug\CLRSQL.dll'
GO