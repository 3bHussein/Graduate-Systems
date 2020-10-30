use GraduateDb


select * from  ProjectTb 
select * from DoctorTb 

go
select r.StudentName,r.StudentRegNo,r.DateReg,p.ProjectName,p.Projectcode,d.DoctorName
from RegisterTb as r
join ProjectTb as p
 on r.projectId =p.projectId
 join DoctorTb as d
 on d.id=p.DocId


 