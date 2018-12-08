CREATE TABLE [dbo].[Data_Menu]
(
	[Id] INT NOT NULL IDENTITY, 
    [OID] VARCHAR(50) NOT NULL, 
    [ParentOID] VARCHAR(50) NULL, 
    [Layer] INT NOT NULL DEFAULT 0, 
    [Title] NVARCHAR(255) NOT NULL, 
    [LinkHref] NVARCHAR(MAX) NOT NULL DEFAULT '#', 
    [CreateTime] DATETIME NOT NULL DEFAULT GetDate(), 
    [CreateUserOID] VARCHAR(50) NULL, 
    [CreateUserName] VARCHAR(255) NULL, 
    CONSTRAINT [PK_Data_Menu] PRIMARY KEY ([OID]) 
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'父标识',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Data_Menu',
    @level2type = N'COLUMN',
    @level2name = N'ParentOID'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'等级',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Data_Menu',
    @level2type = N'COLUMN',
    @level2name = N'Layer'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'标题',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Data_Menu',
    @level2type = N'COLUMN',
    @level2name = 'Title'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'链接',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Data_Menu',
    @level2type = N'COLUMN',
    @level2name = N'LinkHref'