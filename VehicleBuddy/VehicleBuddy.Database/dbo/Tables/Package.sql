CREATE TABLE [dbo].[Package]
(
	[PackageId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FuelTypeId] INT NOT NULL, 
    [is4WD] BIT NOT NULL, 
    [isHatchback] BIT NOT NULL, 
    [NumberOfDoors] INT NOT NULL, 
    [NumberOfPassengers] INT NOT NULL, 
    [NumberOfCylinders] INT NOT NULL, 
    [StartYear] DATETIME2 NOT NULL, 
    [EndYear] DATETIME2 NULL, 
    CONSTRAINT [FK_Package_FuelType] FOREIGN KEY ([FuelTypeId]) REFERENCES [FuelType]([FuelTypeId])
)
