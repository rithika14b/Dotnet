CREATE DATABASE TrainReservationDB;
USE TrainReservationDB;


GO
CREATE USER [INFICS\rithikab]
FOR LOGIN [INFICS\rithikab];
ALTER ROLE db_owner ADD MEMBER [INFICS\rithikab];




CREATE TABLE TrainClassDetails
(
    ClassId INT IDENTITY(1,1) PRIMARY KEY,
    TrainNo INT NOT NULL,
    ClassType VARCHAR(20),
    AvailableSeats INT,
    Charges DECIMAL(10,2),

    FOREIGN KEY (TrainNo)
    REFERENCES TrainDetails(TrainNo)
);

SELECT * FROM TrainClassDetails;
SELECT * FROM TrainDetails;

CREATE TABLE BookingDetails
(
    BookingId INT IDENTITY(1001,1) PRIMARY KEY,
    BookingDate DATETIME,
    TravelDate DATE,
    TrainNo INT,
    ClassType VARCHAR(20),
    PassengerCount INT,
    Amount DECIMAL(10,2)
);


CREATE TABLE PassengerDetails
(
    PassengerId INT IDENTITY(1,1) PRIMARY KEY,
    BookingId INT,
    PassengerName VARCHAR(50),
    Age INT,
    Gender VARCHAR(10),
    SeatNo VARCHAR(10)
);


CREATE TABLE CancellationDetails
(
    CId INT IDENTITY(1,1) PRIMARY KEY,
    BookingId INT,
    SeatNo VARCHAR(10),
    RefundAmount DECIMAL(10,2)
);

sp_help BookingDetails;
sp_help PassengerDetails;
sp_help CancellationDetails;

