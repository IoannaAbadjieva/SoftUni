SELECT MIN(avs.AvgSalaryByDeps) AS MinAverageSalary
FROM
(
    SELECT AVG(Salary) AS AvgSalaryByDeps
    FROM Employees
    GROUP BY DepartmentID
) AS avs