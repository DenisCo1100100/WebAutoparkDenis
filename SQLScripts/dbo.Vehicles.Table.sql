CREATE TABLE [Vehicles]
(
[VehicleId] INT IDENTITY(1, 1) NOT NULL,
[VehicleTypeId] INT NOT NULL,
[Model] NVARCHAR(50) NOT NULL,
[RegistrationNumber] NVARCHAR(50) NOT NULL,
[Weight] FLOAT NOT NULL,
[Year] INT NOT NULL,
[Mileage] FLOAT NOT NULL,
[Color] INT NOT NULL,
[FuelConsumption] FLOAT NOT NULL,
[TankCapacity] FLOAT NOT NULL,

CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED([VehicleId] ASC),
CONSTRAINT [FK_Vehicles_VehicleTypes] FOREIGN KEY([VehicleTypeId]) REFERENCES [VehicleTypes]([VehicleTypesId]) ON DELETE CASCADE
);