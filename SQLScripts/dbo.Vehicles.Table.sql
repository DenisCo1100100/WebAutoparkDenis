USE [WebAutoparkDB]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 14.12.2021 23:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[VehicleId] [int] NOT NULL,
	[VehicleTypeId] [int] NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[RegistrationNumber] [nvarchar](50) NOT NULL,
	[Weight] [float] NOT NULL,
	[Year] [int] NOT NULL,
	[Mileage] [float] NOT NULL,
	[Color] [int] NOT NULL,
 CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED 
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
