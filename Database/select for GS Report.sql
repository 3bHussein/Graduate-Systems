select r.StudentName,StudentRegNo,r.StudnetPhoneNumber,d.DoctorName
,p.ProjectName,p.Projectcode

from RegisterTb as r
join ProjectTb as p on r.projectId=p.projectId
join DoctorTb as d on p.DocId=d.id