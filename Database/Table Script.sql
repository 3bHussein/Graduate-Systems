 
/*old code
 create database GraduateDb
go
use GraduateDb
go 
create table DoctorTb(id int primary key identity,DoctorName nvarchar(max) UNIQUE,Description nvarchar(max))
go

create table ProjectTb(projectId int identity,DocId int ,ProjectName nvarchar(100)   NOT NULL,
Projectcode nvarchar(15)  NOT NULL,Description nvarchar(max)
,CONSTRAINT PK_ProjectTb primary key (projectId,ProjectName,Projectcode))
go

drop ProjectTb

create table RegisterTb(id int identity,DateReg Date,StudentName nvarchar(100)NOT NULL,StudentRegNo int NOT NULL
,projectId int,Description1 nvarchar(max),ProjectName nvarchar(100),Projectcode nvarchar(15)
,constraint Pk_Register primary key (StudentName,StudentRegNo)

,CONSTRAINT  FK_RegisterTb_ProjectTb FOREIGN KEY (projectId,ProjectName,Projectcode) 
REFERENCES ProjectTb (projectId,ProjectName,Projectcode))

*/
create database GraduateDb
go
use GraduateDb
go 
create table DoctorTb(id int primary key identity,DoctorName nvarchar(100) ,Description nvarchar(max)
, CONSTRAINT UC_DoctorTb UNIQUE (DoctorName)
)
go

create table ProjectTb(projectId int  primary key  identity,DocId int ,ProjectName nvarchar(100)   NOT NULL,
Projectcode nvarchar(15)UNIQUE  NOT NULL,Description nvarchar(max))
go

 

create table RegisterTb(id int primary key identity,DateReg Date,StudentName nvarchar(100)UNIQUE NOT NULL,StudentRegNo int UNIQUE NOT NULL
,projectId int,Description nvarchar(max) )
 
 
 /**
  CONSTRAINT fk_student_files                     --- constraint name (optional)
    FOREIGN KEY (batch_id, dept_id, student_id)  
      REFERENCES student (batch_id, dept_id, student_id)


 go



 drop table RegisterTb


