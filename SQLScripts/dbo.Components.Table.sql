﻿CREATE TABLE [Components]
(
[ComponentId] INT IDENTITY(1, 1) NOT NULL,
[Name] NVARCHAR(50) NOT NULL,

CONSTRAINT [PK_Components] PRIMARY KEY CLUSTERED([ComponentId] ASC),
);