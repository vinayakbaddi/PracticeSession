WITH EmployeeSalaryRank AS
(
    SELECT
        Name,
        Salary,        
        DENSE_RANK() OVER (ORDER BY SALARY DESC) AS SalaryRank
    FROM Employees
)
SELECT Name, Salary
FROM EmployeeSalaryRank
WHERE SalaryRank = 2;

WITH CTE_SalaryRank AS
(
Select Name, Salary, DENSE_RANK() OVER (ORDER BY Salary DESC) AS SalaryRank from Employees
)
Select Name, Salary from CTE_SalaryRank where SalaryRank=2;

WITH CTE1 AS (
    SELECT Name, Salary, Dense_Rank() OVER (Order By Salary Desc) as Salary from Employees
)
select S.Name , m.Name from Employee S
left join Employee M on S.Id = M.Id


select name, salary, managerId, 1 as [Level] from Employee where managerId is null
union all
select e.name, e.salary,e.managerId, eh.Level+1 from Employee e 
inner join EmpHierarchy eh on e.managerId = eh.Id