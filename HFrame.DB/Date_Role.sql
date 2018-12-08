CREATE TABLE [dbo].[Date_Role]
(
	[Id] INT NOT NULL IDENTITY , 
    [OID] VARCHAR(50) NOT NULL, 
    [ParentOID] VARCHAR(50) NULL, 
    [RoleName] NVARCHAR(255) NOT NULL, 
    [Dscription] TEXT NULL, 
    [CreateTime] DATETIME NOT NULL DEFAULT GetDate(), 
    [CreateUserOID] VARCHAR(50) NULL, 
    [CreateUserName] NVARCHAR(255) NULL, 
    PRIMARY KEY ([OID])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'角色名称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Date_Role',
    @level2type = N'COLUMN',
    @level2name = 'RoleName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'角色描述',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Date_Role',
    @level2type = N'COLUMN',
    @level2name = N'Dscription'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'创建时间',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Date_Role',
    @level2type = N'COLUMN',
    @level2name = N'CreateTime'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'父代标识',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Date_Role',
    @level2type = N'COLUMN',
    @level2name = N'ParentOID'