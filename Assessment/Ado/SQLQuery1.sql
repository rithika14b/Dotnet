create database Employeemanagement
use Employeemanagement


CREATE TABLE Employee_Details
(
    Empno INT PRIMARY KEY,
    EmpName VARCHAR(50) NOT NULL,
    Empsal NUMERIC(10,2)
    CHECK (Empsal >= 25000),
    Emptype CHAR(1)
    CHECK (Emptype IN ('F','P'))
);
GO

--1st question

CREATE PROCEDURE sp_InsertEmployee
(
    @EmpName VARCHAR(50),
    @Empsal NUMERIC(10,2),
    @Emptype CHAR(1)
)
AS
BEGIN

    DECLARE @NewEmpno INT;
    SELECT @NewEmpno = ISNULL(MAX(Empno),1000) + 1
    FROM Employee_Details;

    INSERT INTO Employee_Details
    VALUES
    (
        @NewEmpno,
        @EmpName,
        @Empsal,
        @Emptype
    );

END;
GO



-- 2nd question
GO
CREATE PROCEDURE sp_UpdateSalary
(
    @Empid INT,
    @UpdatedSalary NUMERIC(10,2) OUTPUT
)
AS
BEGIN
    UPDATE Employee_Details
    SET Empsal = Empsal + 100
    WHERE Empno = @Empid;

    SELECT @UpdatedSalary = Empsal FROM Employee_Details
    WHERE Empno = @Empid;

END;
GO

DECLARE @Salary Decimal(10,2);
EXEC sp_UpdateSalary
     @Empid = 1001,
     @UpdatedSalary = @Salary OUTPUT;

PRINT @Salary;




select * from Employee_Details




GO
CREATE USER [INFICS\Rithikab]
FOR LOGIN [INFICS\Rithikab];
ALTER ROLE db_owner ADD MEMBER [INFICS\Rithikab];