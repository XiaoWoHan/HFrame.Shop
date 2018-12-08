CREATE TABLE [dbo].[Data_Config]
(
	[Id] INT NOT NULL IDENTITY , 
    [OID] VARCHAR(50) NOT NULL, 
    [Namespace] VARCHAR(MAX) NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Config] NVARCHAR(MAX) NOT NULL, 
    [CreateTime] DATETIME NOT NULL DEFAULT GetDate(), 
    PRIMARY KEY ([OID])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'配置内容',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Data_Config',
    @level2type = N'COLUMN',
    @level2name = N'Config'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'描述',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Data_Config',
    @level2type = N'COLUMN',
    @level2name = N'Description'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'命名空间',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Data_Config',
    @level2type = N'COLUMN',
    @level2name = N'Namespace'