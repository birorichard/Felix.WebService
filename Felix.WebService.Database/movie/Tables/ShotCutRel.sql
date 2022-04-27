CREATE TABLE [movie].[ShotCutRel] (
    [Id]     INT IDENTITY (1, 1) NOT NULL,
    [CutId]  INT NOT NULL,
    [ShotId] INT NOT NULL,
    CONSTRAINT [PK_ShotCutRel] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ShotCutRel_Cut_CutId] FOREIGN KEY ([CutId]) REFERENCES [movie].[Cut] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ShotCutRel_Shot_ShotId] FOREIGN KEY ([ShotId]) REFERENCES [movie].[Shot] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ShotCutRel_ShotId]
    ON [movie].[ShotCutRel]([ShotId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ShotCutRel_CutId]
    ON [movie].[ShotCutRel]([CutId] ASC);

