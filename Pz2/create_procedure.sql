CREATE PROCEDURE SetMoneyAmount(@name nvarchar(100), @moneyAmount int)
AS
EXTERNAL NAME CLRSQL.[CLRSQL.Functions].SetMoneyAmount