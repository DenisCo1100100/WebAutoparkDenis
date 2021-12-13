﻿USE [WebAutoparkDB]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 08.12.2021 21:31:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[VehicleId] [int] NOT NULL,
	[VehicleTypeId] [int] NULL,
	[Model] [nchar](50) NULL,
	[RegistrationNumber] [nchar](50) NULL,
	[Weight] [float] NULL,
	[Year] [int] NULL,
	[Mileage] [float] NULL,
	[Color] [int] NULL,
 CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED 
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO