CREATE TRIGGER TR_DEL_Locations ON RegisterTb
after   Insert
AS
BEGIN
DECLARE @TestVariable  AS int
  SELECT TOP 1 @TestVariable=projectId FROM RegisterTb ORDER BY ID DESC;
  DECLARE @doc  AS int

  select @doc=DocId from ProjectTb where projectId=@TestVariable
  print @doc
 	  UPDATE DoctorTb set [Maximum of Reg]=[Maximum of Reg]-1 where id=@doc
END

--*TO Select last row effect*
SELECT TOP 1 projectId FROM RegisterTb ORDER BY ID DESC

