CREATE TABLE [dbo].[Data_GoodsType]
(
	[Id] INT NOT NULL  IDENTITY, 
    [OID] VARCHAR(50) NOT NULL, 
    [TypeName] NVARCHAR(255) NOT NULL, 
    [Sort] INT NOT NULL DEFAULT 0, 
    [CreateTime] DATETIME NOT NULL, 
    [CreateUserOID] VARCHAR(50) NULL, 
    [CreateUserName] VARCHAR(255) NULL, 
    CONSTRAINT [PK_Data_GoodsType] PRIMARY KEY ([OID])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'类型名称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Data_GoodsType',
    @level2type = N'COLUMN',
    @level2name = N'TypeName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'排序',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Data_GoodsType',
    @level2type = N'COLUMN',
    @level2name = N'Sort'