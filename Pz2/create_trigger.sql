﻿CREATE TRIGGER InitUser ON dbo.Users FOR INSERT 
AS 
EXTERNAL NAME CLRSQL.[CLRSQL.Functions].InitUser 