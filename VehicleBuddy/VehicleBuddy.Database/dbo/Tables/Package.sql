CREATE TABLE [dbo].[Package]
(
	[PackageId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FuelTypeId] INT NOT NULL, 
    [is4WD] BIT NOT NULL, 
    [isHatchback] BIT NOT NULL, 
    [NumberOfDoors] INT NOT NULL, 
    [NumberOfPassengers] INT NOT NULL, 
    [NumberOfCylinders] INT NOT NULL, 
    [StartYear] VARCHAR(20) NOT NULL, 
    [EndYear] VARCHAR(20) NULL, 
    CONSTRAINT [FK_Package_FuelType] FOREIGN KEY ([FuelTypeId]) REFERENCES [FuelType]([FuelTypeId])
)
