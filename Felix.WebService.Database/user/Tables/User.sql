CREATE TABLE [user].[User] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [UserName]  NVARCHAR (MAX) NOT NULL,
    [Password]  NVARCHAR (MAX) NOT NULL,
    [Salt]      NVARCHAR (MAX) NOT NULL,
    [Name]      NVARCHAR (MAX) NOT NULL,
    [IsDeleted] BIT            NOT NULL,
    [IsAdmin]   BIT            DEFAULT (CONVERT([bit],(0))) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);








GO


