CREATE TYPE dbo.ImageType
   AS TABLE
      ( ImageId int,
        VehicleId int,
        ImageName VARCHAR(30),
        ImagePath nvarchar(150),
        OriginalFileName nvarchar(50)
      );