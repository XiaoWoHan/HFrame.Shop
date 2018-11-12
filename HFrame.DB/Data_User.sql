CREATE TABLE [dbo].[Data_User] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [OID]        VARCHAR (50)  NOT NULL,
    [Name]       VARCHAR (500) NOT NULL,
    [UserName]   VARCHAR (255) NOT NULL,
    [Password]   VARCHAR (255) NOT NULL,
    [Telephone]  VARCHAR (50)  NOT NULL,
    [IsDeleted]  BIT           DEFAULT ((0)) NOT NULL,
    [IsLocked]   BIT           DEFAULT ((0)) NOT NULL,
    [CreateTime] DATETIME      DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([OID] ASC)
);

