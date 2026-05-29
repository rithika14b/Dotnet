create database EmployeeContactDB;
use EmployeeContactDB;

GO
CREATE USER [INFICS\rithikab] 
FOR LOGIN [INFICS\rithikab] ;
ALTER ROLE db_owner ADD MEMBER [INFICS\rithikab] ;