/* Create a table type. */
CREATE TYPE ImageType
   AS TABLE
      ( ImageId int,
        VehicleId int,
        ImageName VARCHAR(30),
        ImagePath nvarchar(150),
        OriginalFileName nvarchar(50)
      );

/* Create a procedure to receive data for the table-valued parameter. */


--CREATE PROCEDURE dbo. usp_InsertProductionLocation
--   @TVP LocationTableType READONLY
--      AS
--      SET NOCOUNT ON
--      INSERT INTO AdventureWorks2012.Production.Location
--         (
--            Name
--            , CostRate
--            , Availability
--            , ModifiedDate
--         )
--      SELECT *, 0, GETDATE()
--      FROM @TVP;
--GO
--/* Declare a variable that references the type. */
--DECLARE @LocationTVP AS LocationTableType;
--/* Add data to the table variable. */
--INSERT INTO @LocationTVP (LocationName, CostRate)
--   SELECT Name, 0.00
--   FROM AdventureWorks2012.Person.StateProvince;
  
--/* Pass the table variable data to a stored procedure. */
--EXEC usp_InsertProductionLocation @LocationTVP;