SELECT
TOP 10
    e.FirstName	, e.LastName, e.DepartmentID
FROM Employees AS e
WHERE e.Salary > 
                (
                    SELECT
                        AVG(eSubQuery.Salary)
                    FROM Employees AS eSubQuery
                    WHERE eSubQuery.DepartmentID = e.DepartmentID
                    GROUP BY eSubQuery.DepartmentID
                )
ORDER BY e.DepartmentID