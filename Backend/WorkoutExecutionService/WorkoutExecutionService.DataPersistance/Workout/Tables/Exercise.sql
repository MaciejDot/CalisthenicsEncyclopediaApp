CREATE TABLE [Workout].[Exercise] (
    [Id]         UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    [ExerciseId] INT              NOT NULL,
    [Name]       NVARCHAR (400)   NULL,
    [Created]    DATETIME2 (7)    NOT NULL,
    [IsActive]   BIT              NOT NULL,
    CONSTRAINT [PK_Exercise] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
CREATE NONCLUSTERED INDEX [IX_Exercise_ExerciseId_Created] ON [Workout].[Exercise]([ExerciseId], [Created])