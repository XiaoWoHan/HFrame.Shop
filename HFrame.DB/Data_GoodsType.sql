﻿CREATE TABLE [dbo].[Data_GoodsType]
(
	[Id] INT NOT NULL  IDENTITY, 
    [OID] VARCHAR(50) NOT NULL, 
    [TypeName] NVARCHAR(255) NOT NULL, 
    [ParentOID] VARCHAR(50) NOT NULL DEFAULT 0, 
    [Sort] INT NOT NULL DEFAULT 0, 
    [CreateTime] DATETIME NOT NULL, 
    [CreateUserOID] VARCHAR(50) NOT NULL, 
    [CreateUserName] VARCHAR(255) NOT NULL, 
    CONSTRAINT [PK_Data_GoodsType] PRIMARY KEY ([OID])
)
