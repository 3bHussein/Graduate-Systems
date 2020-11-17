USE [GraduateDb]
GO

ALTER table [dbo].[RegisterTb]
   add 
   CONSTRAINT UQ_StudnetPhoneNumber UNIQUE(StudnetPhoneNumber) 
 

GO


