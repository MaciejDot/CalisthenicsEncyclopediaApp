CREATE TABLE [Workout].[Fatigue] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [FatigueId] INT              NOT NULL,
    [Name]      NVARCHAR (100)   NULL,
    [Created]   DATETIME2 (7)    NOT NULL,
    [IsActive]  BIT              NOT NULL,
    CONSTRAINT [PK_Fatigue] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
CREATE NONCLUSTERED INDEX [IX_Fatigue_FatigueId_Created] ON [Workout].[Fatigue]([FatigueId], [Created])

