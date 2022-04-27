CREATE TABLE [movie].[Movie] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (MAX) NULL,
    [CodeName]  NVARCHAR (450) DEFAULT (N'') NOT NULL,
    [CreatedAt] DATETIME2 (7)  DEFAULT ('0001-01-01T00:00:00.0000000') NOT NULL,
    CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Movie_CodeName]
    ON [movie].[Movie]([CodeName] ASC);

