CREATE TABLE [dbo].[Image]
(
	[ImageId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [VehicleId] INT NULL,
    [ImageName] varchar(30) NOT NULL,
    [ImagePath] NVARCHAR(150) NOT NULL, 
    [OriginalFileName] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_ImageTable_Vehicle] FOREIGN KEY ([VehicleId]) REFERENCES [Vehicle]([VehicleId]),
)
