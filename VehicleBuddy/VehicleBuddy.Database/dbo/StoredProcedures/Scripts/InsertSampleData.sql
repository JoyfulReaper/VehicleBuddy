CREATE DATABASE VehicleBuddy;
GO

USE VehicleBuddy
GO
-- Fuel Types to be inserted into the DB

CREATE TABLE FuelType 
(
	FuelTypeId int,
	[Type] varchar(50)
)

INSERT INTO FuelType 
(
	[FuelTypeId],
	[Type]
)

VALUES
	(1, 'Diesel'),
	(2, 'Electric'),
	(3, 'Gasoline'),
	(4, 'Other')

-- Make types to be inserted into the DB

CREATE TABLE Make
(
	MakeId int,
	[Name] varchar(50),
	Country varchar(50),
	CustomerSupportEmailAddress nvarchar(50),
	CustomerSupportPhoneNumber nvarchar(150)
)

INSERT INTO Make
(
	MakeId,
	[Name],
	Country,
	CustomerSupportEmailAddress,
	CustomerSupportPhoneNumber
)
VALUES
	(1, 'Toyota Motor Corporation', 'Japan', 'support@toyota.com', '+81-3-3817-7111'),
	(2, 'Ford Motor Company', 'United States', 'support@ford.com', '1-800-392-3673'),
	(3, 'Bayerische Motoren Werke AG (BMW)', 'Germany', 'support@bmw.com', '+49-89-1250-16000'),
	(4, 'Honda Motor Co., Ltd.', 'Japan', 'support@honda.com', '+81-3-3423-1111'),
	(5, 'General Motors Company', 'United States', 'support@gm.com', '1-800-462-8782'),
	(6, 'Daimler AG (Mercedes-Benz)', 'Germany', 'support@daimler.com', '+49-711-17-0'),
	(7, 'Nissan Motor Co., Ltd.', 'Japan', 'support@nissan.com', '+81-45-523-5523'),
	(8, 'Volkswagen AG', 'Germany', 'support@volkswagen.com', '+49-5361-9-0'),
	(9, 'Hyundai Motor Company', 'South Korea', 'support@hyundai.com', '+82-2-3464-1114'),
	(10, 'Tesla, Inc.', 'United States', 'support@tesla.com', '1-877-79-TESLA');

-- Model types to be inserted into the DB

CREATE TABLE Model
(
	ModelId int,
	[Name] varchar(50)
)

INSERT INTO Model
(
	ModelId,
	[Name]
)
VALUES
	(1, 'Mustang'),
	(2, '3 Series'),
	(3, 'Civic'),
	(4, 'Silverado'),
	(5, 'C-Class'),
	(6, 'Altima'),
	(7, 'Golf'),
	(8, 'Sonata'),
	(9, 'Model S')


-- Package types to be inserted into the DB

CREATE TABLE Package
(
	PackageId int,
	FuelTypeId int,
	is4WD bit,
	isHatchback bit,
	NumberOfDoors int,
	NumberOfPassengers int,
	NumberOfCylinders int,
	StartYear datetime2(7),
	EndYear datetime2(7)
)

INSERT INTO Package
(
	PackageId,
	FuelTypeId,
	is4WD,
	isHatchback,
	NumberOfDoors,
	NumberOfPassengers,
	NumberOfCylinders,
	StartYear,
	EndYear
)
VALUES
	(1, 1, 0, 1, 4, 5, 4, '2015-05-02 13:45:30.1234567', '2019-05-02 13:45:30.1234567'),
	(2, 2, 1, 0, 2, 2, 2, '2018-05-02 13:45:30.1234567', NULL),
	(3, 3, 0, 1, 4, 7, 6, '2016-05-02 13:45:30.1234567', '2020-05-02 13:45:30.1234567'),
	(4, 4, 1, 0, 4, 5, 6, '2017-05-02 13:45:30.1234567', NULL),
	(5, 1, 1, 0, 4, 5, 4, '2019-05-02 13:45:30.1234567', '2023-05-02 13:45:30.1234567'),
	(6, 3, 0, 0, 4, 5, 8, '2014-05-02 13:45:30.1234567', '2018-05-02 13:45:30.1234567'),
	(7, 2, 1, 1, 2, 4, 3, '2015-05-02 13:45:30.1234567', '2017-05-02 13:45:30.1234567'),
	(8, 4, 0, 1, 4, 7, 8, '2018-05-02 13:45:30.1234567', NULL),
	(9, 3, 1, 0, 4, 5, 4, '2020-05-02 13:45:30.1234567', NULL),
	(10, 1, 0, 0, 2, 2, 3, '2016-05-02 13:45:30.1234567', '2019-05-02 13:45:30.1234567');

-- Vehicle values to be inserted into the DB

CREATE TABLE Vehicle
(
	VehicleId int,
	MakeId int,
	ModelId int,
	PackageId int,
	VIN varchar(20),
	[Year] int,
	isAutomatic bit,
	Color varchar(50),
	DateDeleted datetime2(7),
	DateSold datetime2(7),
	DateAcquired datetime2(7),
	Mileage int
)

INSERT INTO Vehicle
(
	VehicleId,
	MakeId,
	ModelId,
	PackageId,
	VIN,
	[Year],
	isAutomatic,
	Color,
	DateDeleted,
	DateSold,
	DateAcquired,
	Mileage
)
VALUES
	(1, 1, 1, 1, '1G1PC5SB4E7267064', 2014, 1, 'Blue', NULL, '2022-01-15', '2017-06-01', 50000),
	(2, 2, 2, 2, 'WBA3B3C53EF986272', 2014, 1, 'Black', NULL, NULL, '2016-08-12', 25000),
	(3, 3, 3, 3, '5FNRL5H63EB094034', 2014, 1, 'Silver', NULL, NULL, '2018-03-02', 40000),
	(4, 4, 4, 4, '3GCUKREC2EG142431', 2014, 0, 'Red', NULL, '2021-11-28', '2016-05-15', 65000),
	(5, 5, 5, 5, 'WDDGF8AB7EA965698', 2014, 0, 'White', NULL, NULL, '2017-12-23', 30000),
	(6, 6, 6, 6, '1N4AL3AP6EC123874', 2014, 1, 'Gray', '2022-02-01', NULL, '2015-02-14', 75000),
	(7, 7, 7, 7, '3VW217AU3FM015129', 2014, 0, 'Green', NULL, '2022-05-20', '2018-11-05', 55000),
	(8, 8, 8, 8, 'KMHD74LF9KU725940', 2014, 1, 'Orange', '2022-03-10', NULL, '2016-09-30', 50000),
	(9, 9, 9, 9, '5YJSA1H14EFP48474', 2014, 0, 'Purple', NULL, NULL, '2020-02-18', 20000),
	(10, 10, 9, 10, '1FMCU9G93EUC98272', 2014, 1, 'Yellow', NULL, NULL, '2019-05-27', 35000);