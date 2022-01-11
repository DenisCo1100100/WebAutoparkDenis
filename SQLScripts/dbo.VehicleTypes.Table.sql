﻿CREATE TABLE [VehicleTypes]
(
[VehicleTypesId] INT IDENTITY(1, 1) NOT NULL,
[Name] NVARCHAR(50) NOT NULL,
[TaxCoefficient] FLOAT NOT NULL

CONSTRAINT [PK_VehicleTypes] PRIMARY KEY CLUSTERED([VehicleTypesId] ASC)
);