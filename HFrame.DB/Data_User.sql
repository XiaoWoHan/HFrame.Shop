CREATE TABLE [dbo].[Data_User] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [OID]        VARCHAR (50)  NOT NULL,
    [Name]       NVARCHAR(500) NOT NULL,
    [UserName]   VARCHAR (255) NOT NULL,
    [Password]   VARCHAR (255) NOT NULL,
    [Telephone]  VARCHAR (50)  NOT NULL,
    [IsDeleted]  BIT           DEFAULT ((0)) NOT NULL,
    [IsLocked]   BIT           DEFAULT ((0)) NOT NULL,
    [CreateTime] DATETIME      DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([OID] ASC)
);


GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'用户标识',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Data_User',
    @level2type = N'COLUMN',
    @level2name = N'OID'