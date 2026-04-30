create database Assessment
use Assessment

Create table books (
    id int primary key,
    title varchar(100),
    author varchar(100),
    isbn bigint unique,
    published_date datetime);

insert into books (id, title, author, isbn, published_date) values
(1, 'My First SQL book', 'Mary Parker', 981483029127, '2012-02-22 12:08:17'),
(2, 'My Second SQL book', 'John Mayer', 857300923713, '1972-07-03 09:22:46'),
(3, 'My Third SQL book', 'Cory Flint', 523120967812, '2015-10-18 14:05:44');
 

--first question

select * from books where author LIKE '%er';


create table reviews(   
         id int primary key,book_id int,reviewer_name varchar(50),content varchar(50),    
         rating int,published_date datetime,foreign key(book_id) references Books(id));

insert into reviews values (1,1,'John Smith','My First SQL book',4,'2017-12-10 05:50:11'),
                           (2,2,'John SMith','My Second SQL book',5,'2017-10-13 15:05:12'),
                           (3,3,'Alice Walker','My Third SQL book',1,'2017-10-22 23:47:10');

-- second question

select b.title,b.author,r.reviewer_name from Books b join Reviews r on b.id=r.book_id;

--third question
select reviewer_name from reviews group by reviewer_name
having count (distinct book_id) > 1;




 create table customer(id int primary key,name varchar(50),age int,address varchar(30),salary decimal(10,2));
 
 insert into customer values(1,'Ramesh',32,'Ahmedabad',2000.00),
 (2,'Khilan',25,'Delhi',1500.00),
 (3,'Kaushik',23,'Kota',2000.00),
 (4,'Chaitali',25,'Mumbai',6500.00),
 (5,'Hardik',27,'Bhopal',8500.00),
 (6,'Komal',22,'MP',4500.00),
 (7,'Muffy',24,'Indore',10000.00);
 
-- fourth question
select name from customer where address like '%o%'and address in(select address from customer
 group by address having count(*)>1);



create table orders (oid int primary key,date datetime,customer_id int,amount int);
 
insert into orders (oid, date, customer_id, amount) values
(102, '2009-10-08 00:00:00', 3, 3000),
(100, '2009-10-08 00:00:00', 3, 1500),
(101, '2009-11-20 00:00:00', 2, 1560),
(103, '2008-05-20 00:00:00', 4, 2060);
 
--five question
select date, count(distinct customer_id) AS total_customers
from orders group by date;
 


create table Employee (
    ID INT PRIMARY KEY,
    Name VARCHAR(50),
    Age INT,
    Address VARCHAR(100),
    Salary DECIMAL(10,2)
);


INSERT INTO Employee (ID, Name, Age, Address, Salary) VALUES
(1, 'Ramesh', 32, 'Ahmedabad', 2000.00),
(2, 'Khilan', 25, 'Delhi', 1500.00),
(3, 'Kaushik', 23, 'Kota', 2000.00),
(4, 'Chaitali', 25, 'Mumbai', 6500.00),
(5, 'Hardik', 27, 'Bhopal', 8500.00),
(6, 'Komal', 22, 'MP', NULL),
(7, 'Muffy', 24, 'Indore', NULL);

-- six question

select LOWER(Name) AS EmployeeName FROM Employee
WHERE Salary IS NULL;


CREATE TABLE Studentdetails (
    RegisterNo INT PRIMARY KEY,
    Name VARCHAR(50),
    Age INT,
    Qualification VARCHAR(20),
    MobileNo BIGINT,
    Mail_id VARCHAR(100),
    Location VARCHAR(50),
    Gender CHAR(1)
);

INSERT INTO Studentdetails (RegisterNo, Name, Age, Qualification, MobileNo, Mail_id, Location, Gender) VALUES
(2, 'Sai', 22, 'B.E', 9952836777, 'Sai@gmail.com', 'Chennai', 'M'),
(3, 'Kumar', 20, 'BSC', 7890125648, 'Kumar@gmail.com', 'Madurai', 'M'),
(4, 'Selvi', 22, 'B.Tech', 8904567342, 'selvi@gmail.com', 'Selam', 'F'),
(5, 'Nisha', 25, 'M.E', 7834672310, 'Nisha@gmail.com', 'Theni', 'F'),
(6, 'SaiSaran', 21, 'B.A', 7890345678, 'saran@gmail.com', 'Madurai', 'F'),
(7, 'Tom', 23, 'BCA', 8901234675, 'Tom@gmail.com', 'Pune', 'M');


--seven question
SELECT Gender, COUNT(*) AS TotalCount
FROM Studentdetails GROUP BY Gender;