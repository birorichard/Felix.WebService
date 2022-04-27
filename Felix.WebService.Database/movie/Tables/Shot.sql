CREATE TABLE [movie].[Shot] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (450) NULL,
    [StartFrame] INT            NOT NULL,
    [EndFrame]   INT            NOT NULL,
    [FileName]   NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Shot] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Shot_Name]
    ON [movie].[Shot]([Name] ASC) WHERE ([Name] IS NOT NULL);

