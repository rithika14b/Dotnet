create database Assessment2
use Assessment2


-- 1)
select datename(weekday, '2004-10-14') as Birthday_Day;

--2)
select datediff (day, '2004-10-14', getdate()) AS Age_In_Days;



Create table Employees
(
    EmpNo int primary key,
    EName varchar(50),
    Sal decimal(10,2),
    DOJ date,
    DeptNo int,
    DeptName varchar(50)
);


INSERT INTO Employees values
(1,'Rithi',1200,'2019-05-10',10,'HR'),
(2,'Viji',1400,'2021-03-15',20,'IT'),
(3,'Sudhan',2000,'2018-05-20',10,'Sales');

--3

Select * From Employees
Where DOJ < Dateadd(Year,-5, Getdate()) And Month(DOJ) = Month(Getdate());

---------------------------------------------------------------------------------------
--4)

Begin Transaction;

-- Insert 3 rows
Insert Into Employees Values (4,'kavi',1000,'2020-05-10',20,'HR'),
                            (5,'radhi',2000,'2021-06-15',20,'Sales'),
                            (6,'mahesh',3000,'2022-07-20',20,'it');

-- Update second row salary (15% increment)
Update Employees Set Sal = Sal * 1.15 Where EmpNo = 5;
Save Transaction sp1;

-- Delete first row
Delete From Employees Where EmpNo = 4;

-- Rollback only delete
Rollback Transaction sp1;
Commit;


---------------------------------------------------------------------------------------

--5)
Go
Create Function Calculate_Bonus
(
    @Deptno Int,
    @Sal Int
)
Returns Decimal(10,2)
As
Begin
    Declare @Bonus Decimal(10,2);

    If @Deptno = 10
        Set @Bonus = @Sal * 0.15;
    Else If @Deptno = 20
        Set @Bonus = @Sal * 0.20;
    Else
        Set @Bonus = @Sal * 0.05;

    Return @Bonus;
End;
Go



Select Empno, Ename, Deptno, Sal,
dbo.Calculate_Bonus(Deptno, Sal) As Bonus
From Employees;



--6)
Create Procedure Update_Sales
As
Begin
    Update Employees
    Set Sal = Sal + 500
    Where Deptno = 30
    And Sal < 1500;
End;

Exec Update_Sales;

