CREATE TABLE [movie].[Cut] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [MovieId]    INT            NOT NULL,
    [CreatedAt]  DATETIME2 (7)  DEFAULT ('0001-01-01T00:00:00.0000000') NOT NULL,
    [ModifiedAt] DATETIME2 (7)  NULL,
    [Name]       NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Cut] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Cut_Movie_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [movie].[Movie] ([Id]) ON DELETE CASCADE
);




GO
CREATE NONCLUSTERED INDEX [IX_Cut_MovieId]
    ON [movie].[Cut]([MovieId] ASC);

