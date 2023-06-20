CREATE PROCEDURE [dbo].[spVehicle_ImageUpload]
	@ImageTVP ImageType READONLY
AS
BEGIN
    SET NOCOUNT ON;

    -- Insert images from the TVP into the target table
    INSERT INTO dbo.[Image] (ImageId, VehicleId, ImageName, ImagePath, OriginalFileName)
    SELECT ImageId, VehicleId, ImageName, ImagePath, OriginalFileName
    FROM @ImageTVP;

    -- Return a success code
    RETURN 0;
END
