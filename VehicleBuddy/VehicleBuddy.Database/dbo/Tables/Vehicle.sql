CREATE TABLE [dbo].[Vehicle]
(
	[VehicleId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MakeId] INT NOT NULL, 
    [ModelId] INT NOT NULL, 
    [PackageId] INT NOT NULL,
    [VIN] VARCHAR(20) NOT NULL, 
    [Year] INT NOT NULL, 
    [isAutomatic] BIT NOT NULL, 
    [Color] VARCHAR(50) NOT NULL, 
    [DateDeleted] DATETIME2 NULL, 
    [DateSold] DATETIME2 NULL, 
    [DateAcquired] DATETIME2 NOT NULL, 
    [Mileage] INT NULL, 
    CONSTRAINT [FK_Vehicle_Make] FOREIGN KEY ([MakeId]) REFERENCES [Make]([MakeId]), 
    CONSTRAINT [FK_Vehicle_Model] FOREIGN KEY ([ModelId]) REFERENCES [Model]([ModelId]), 
    CONSTRAINT [FK_Vehicle_Package] FOREIGN KEY ([PackageId]) REFERENCES [Package]([PackageId]), 
)
