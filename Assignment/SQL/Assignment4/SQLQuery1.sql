create database Assignment4
use Assignment4


CREATE TABLE Student (Sid INT PRIMARY KEY,Sname VARCHAR(50));


CREATE TABLE Marks (Mid INT PRIMARY KEY,Sid INT,Score INT,
FOREIGN KEY (Sid) REFERENCES Student(Sid));


INSERT INTO Student (Sid, Sname) VALUES
(1, 'Jack'),(2, 'Rithvik'),(3, 'Jaspreeth'),
(4, 'Praveen'),(5, 'Bisa'),(6, 'Suraj');


INSERT INTO Marks (Mid, Sid, Score) VALUES
(1, 1, 23),(2, 6, 95),(3, 4, 98),
(4, 2, 17),(5, 3, 53),(6, 5, 13);


--1)

DECLARE @num INT = 5;
DECLARE @fact BIGINT = 1;
WHILE @num > 0
BEGIN
    SET @fact = @fact * @num;
    SET @num = @num - 1;
END
PRINT 'Factorial = ' + CAST(@fact AS VARCHAR);


--2)

CREATE PROCEDURE GenerateMultiplicationTable
    @number INT,@limit INT
AS
BEGIN
    DECLARE @i INT = 1;
    WHILE @i <= @limit
    BEGIN
        PRINT CAST(@number AS VARCHAR) + ' x ' + 
              CAST(@i AS VARCHAR) + ' = ' + 
              CAST(@number * @i AS VARCHAR);
        SET @i = @i + 1;
    END
END;


--3)

CREATE FUNCTION dbo.GetStatus (@score INT)
RETURNS VARCHAR(10)
AS
BEGIN
    DECLARE @status VARCHAR(10);
    IF @score >= 50
        SET @status = 'Pass';
    ELSE
        SET @status = 'Fail';
    RETURN @status;
END;


SELECT s.Sid,s.Sname,m.Score,dbo.GetStatus(m.Score) 
AS Status FROM Student s
JOIN Marks m ON s.Sid = m.Sid;