CREATE TABLE [dbo].[Make]
(
	[MakeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Country] VARCHAR(50) NOT NULL, 
    [CustomerSupportPhoneNumber] NVARCHAR(20) NOT NULL, 
    [CustomerSupportEmailAddress] NVARCHAR(150) NOT NULL
)
