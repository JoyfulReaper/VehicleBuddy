CREATE TABLE [dbo].[ModelPackage]
(
	[ModelPackageId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ModelId] INT NOT NULL, 
    [PackageId] INT NOT NULL, 
    CONSTRAINT [FK_ModelPackage_Model] FOREIGN KEY ([ModelId]) REFERENCES [Model]([ModelId]), 
    CONSTRAINT [FK_ModelPackage_Package] FOREIGN KEY ([PackageId]) REFERENCES [Package]([PackageId])
)
