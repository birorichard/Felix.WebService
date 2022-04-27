CREATE TABLE [business].[Seed] (
    [Guid]        UNIQUEIDENTIFIER NOT NULL,
    [CreatedDate] DATETIME2 (7)    NOT NULL,
    [Id]          INT              IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_Seed] PRIMARY KEY CLUSTERED ([Id] ASC)
);

