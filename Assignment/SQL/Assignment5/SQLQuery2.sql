create database Assignment5
use Assignment5

CREATE TABLE EMP (
    EmpID INT PRIMARY KEY,
    EmpName VARCHAR(100),
    Salary DECIMAL(10,2)
);

INSERT INTO EMP VALUES
(101, 'Ravi', 30000),
(102, 'Sita', 40000);


CREATE TABLE Holiday (
    Holiday_Date DATE,
    Holiday_Name VARCHAR(50)
);

INSERT INTO Holiday VALUES 
('2026-01-26', 'Republic Day'),
('2026-08-15', 'Independence Day'),
('2026-10-20', 'Diwali'),
('2026-12-25', 'Christmas');



CREATE PROCEDURE GeneratePaySlip
    @EmpID INT
AS
BEGIN
    DECLARE 
        @EmpName VARCHAR(100),
        @Salary DECIMAL(10,2),
        @HRA DECIMAL(10,2),
        @DA DECIMAL(10,2),
        @PF DECIMAL(10,2),
        @IT DECIMAL(10,2),
        @Deductions DECIMAL(10,2),
        @GrossSalary DECIMAL(10,2),
        @NetSalary DECIMAL(10,2);

    SELECT 
        @EmpName = EmpName,
        @Salary = Salary
    FROM EMP
    WHERE EmpID = @EmpID;

    SET @HRA = @Salary * 0.10;
    SET @DA = @Salary * 0.20;
    SET @PF = @Salary * 0.08;
    SET @IT = @Salary * 0.05;

    SET @Deductions = @PF + @IT;
    SET @GrossSalary = @Salary + @HRA + @DA;
    SET @NetSalary = @GrossSalary - @Deductions;

    PRINT '----------------------------------------';
    PRINT '            EMPLOYEE PAYSLIP             ';
    PRINT '----------------------------------------';
    PRINT 'Employee ID   : ' + CAST(@EmpID AS VARCHAR);
    PRINT 'Employee Name : ' + @EmpName;
    PRINT '----------------------------------------';
    PRINT 'Basic Salary  : ' + CAST(@Salary AS VARCHAR);
    PRINT 'HRA (10%)     : ' + CAST(@HRA AS VARCHAR);
    PRINT 'DA (20%)      : ' + CAST(@DA AS VARCHAR);
    PRINT '----------------------------------------';
    PRINT 'PF (8%)       : ' + CAST(@PF AS VARCHAR);
    PRINT 'IT (5%)       : ' + CAST(@IT AS VARCHAR);
    PRINT 'Deductions    : ' + CAST(@Deductions AS VARCHAR);
    PRINT '----------------------------------------';
    PRINT 'Gross Salary  : ' + CAST(@GrossSalary AS VARCHAR);
    PRINT 'Net Salary    : ' + CAST(@NetSalary AS VARCHAR);
    PRINT '----------------------------------------';
END;

EXEC GeneratePaySlip 101;

CREATE TRIGGER trg_RestrictHolidayDML
ON EMP
FOR INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @Today DATE = CAST(GETDATE() AS DATE);
    DECLARE @HolidayName VARCHAR(50);

    SELECT @HolidayName = Holiday_Name
    FROM Holiday
    WHERE Holiday_Date = @Today;

    IF @HolidayName IS NOT NULL
    BEGIN
        RAISERROR (
            'Due to %s, you cannot manipulate data',
            16,
            1,
            @HolidayName
        );

        ROLLBACK TRANSACTION;
    END
END;


