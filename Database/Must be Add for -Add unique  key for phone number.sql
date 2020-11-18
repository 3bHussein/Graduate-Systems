USE [GraduateDb]
GO

ALTER table [dbo].[RegisterTb]
   add 
   CONSTRAINT UQ_StudnetPhoneNumber UNIQUE(StudnetPhoneNumber) 
 ,   CONSTRAINT UQ_StudnetName UNIQUE([StudentName]) 


GO

select * from RegisterTb where StudnetPhoneNumber = '01226906931'


