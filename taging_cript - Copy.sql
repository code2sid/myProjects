WITH Ques AS (
SELECT TOP 1000 Description = ' '+CAST(Description AS NVARCHAR(max)) 
        FROM [Transtutors_QA_7.1].dbo.AssignmentTmp),
tags AS (SELECT *,crscode =  SUBSTRING(crs,CHARINDEX('-',crs)+1,LEN(crs)) FROM dbo.SchoolDeptsCrs
WHERE LEN(SUBSTRING(crs,CHARINDEX('-',crs)+1,LEN(crs))) > 3
)

--SELECT * FROM tags t 
SELECT * FROM tags t INNER JOIN Ques q ON q.Description LIKE '% '+ t.crscode +' %'