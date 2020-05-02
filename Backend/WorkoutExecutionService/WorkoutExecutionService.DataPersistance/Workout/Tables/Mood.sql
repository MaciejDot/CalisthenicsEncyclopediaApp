CREATE TABLE [Workout].[Mood] (
    [Id]       UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [MoodId]   INT              NOT NULL,
    [Name]     NVARCHAR (100)   NULL,
    [Created]  DATETIME2 (7)    NOT NULL,
    [IsActive] BIT              NOT NULL,
    CONSTRAINT [PK_Mood] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE NONCLUSTERED INDEX [IX_Mood_MoodId_Created] ON [Workout].[Mood]([MoodId], [Created])
