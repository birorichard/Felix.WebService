CREATE TABLE [comment].[Comment] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Text]         NVARCHAR (MAX) NOT NULL,
    [StartFrame]   INT            NOT NULL,
    [EndFrame]     INT            NOT NULL,
    [IsDeleted]    BIT            NOT NULL,
    [CreatedAt]    DATETIME2 (7)  NOT NULL,
    [CreatedById]  INT            DEFAULT ((0)) NOT NULL,
    [Priority]     INT            NOT NULL,
    [ShotCutRelId] INT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Comment_ShotCutRel_ShotCutRelId] FOREIGN KEY ([ShotCutRelId]) REFERENCES [movie].[ShotCutRel] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Comment_User_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [user].[User] ([Id]) ON DELETE CASCADE
);




GO
CREATE NONCLUSTERED INDEX [IX_Comment_CreatedById]
    ON [comment].[Comment]([CreatedById] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Comment_ShotCutRelId]
    ON [comment].[Comment]([ShotCutRelId] ASC);

