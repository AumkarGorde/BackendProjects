-- Adding Departments
INSERT INTO Departments (DepartmentName)
VALUES ('Accounts'), ('Tax'), ('Audit'), ('Human Resource');

-- Adding Projects
INSERT INTO Projects (ProjectName)
VALUES ('Journal Entries'), ('Ledgers'), ('Preparation of Trade Balance'),
       ('Balance Sheet'), ('Trading Account'), ('Profit and Loss Account');

-- Adding Employees
DECLARE @EmployeesData TABLE (
    EmployeeName NVARCHAR(100),
    DepartmentId INT
);

-- Human Resource Department (10 employees)
INSERT INTO @EmployeesData (EmployeeName, DepartmentId)
SELECT TOP 10 'HR Employee ' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS NVARCHAR(2)), 4
FROM master.dbo.spt_values;

-- Tax Department (20 employees)
INSERT INTO @EmployeesData (EmployeeName, DepartmentId)
SELECT TOP 20 'Tax Employee ' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS NVARCHAR(2)), 2
FROM master.dbo.spt_values;

-- Audit Department (15 employees)
INSERT INTO @EmployeesData (EmployeeName, DepartmentId)
SELECT TOP 15 'Audit Employee ' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS NVARCHAR(2)), 3
FROM master.dbo.spt_values;

-- Accounts Department (15 employees)
INSERT INTO @EmployeesData (EmployeeName, DepartmentId)
SELECT TOP 15 'Accounts Employee ' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS NVARCHAR(2)), 1
FROM master.dbo.spt_values;

-- Inserting the data into Employees table from the temporary table
INSERT INTO Employees (EmployeeName, DepartmentId)
SELECT EmployeeName, DepartmentId
FROM @EmployeesData;

-- Insert EmployeeProjects data
DECLARE @MaxProjectsPerEmployee INT = 3; -- Maximum number of projects per employee

-- Create a temporary table to hold the EmployeeIds and ProjectIds
CREATE TABLE #TempEmployeeProjects (EmployeeId INT, ProjectId INT);

-- Generate random EmployeeId and ProjectId combinations
;WITH RandomizedCombinations AS (
    SELECT
        E.EmployeeId,
        P.ProjectId,
        ROW_NUMBER() OVER (PARTITION BY E.EmployeeId ORDER BY NEWID()) AS RowNum
    FROM Employees E
    CROSS JOIN Projects P
)
INSERT INTO #TempEmployeeProjects (EmployeeId, ProjectId)
SELECT EmployeeId, ProjectId
FROM RandomizedCombinations
WHERE RowNum <= @MaxProjectsPerEmployee;

-- Insert the combinations into the EmployeeProjects table
INSERT INTO EmployeeProjects (EmployeeId, ProjectId)
SELECT EmployeeId, ProjectId
FROM #TempEmployeeProjects;

-- Drop the temporary table
DROP TABLE #TempEmployeeProjects;
