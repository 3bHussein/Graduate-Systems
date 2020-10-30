CREATE TRIGGER TR_InsertToStudnet ON RegisterTb
after   Insert
AS
BEGIN
DECLARE @StudentRegNo  AS int
DECLARE @StudentName  AS nvarchar(max)

   SELECT TOP 1 @StudentRegNo=StudentRegNo,
   @StudentName=StudentName FROM RegisterTb ORDER BY ID DESC;
   print @StudentName
      print @StudentRegNo

INSERT INTO StudentTb (StundentRegNo,StundentName) values (@StudentRegNo,@StudentName)

   print @StudentName

 END

--*TO Select last row effect*
SELECT TOP 1 StudentRegNo, StudentName FROM RegisterTb ORDER BY ID DESC
go

INSERT INTO StudentTb (StundentRegNo,StundentName) values (3,'2')
