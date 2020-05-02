CREATE TABLE [Workout].[ExerciseExecution] (
    [Id]                        UNIQUEIDENTIFIER NOT NULL,
    [ExerciseId]                INT              NOT NULL,
    [Order]                     INT              NOT NULL,
    [Repetitions]               INT              NOT NULL,
    [AdditionalKgs]             INT              NOT NULL,
    [Break]                     INT              NOT NULL,
    [Series]                    INT              NOT NULL,
    [WorkoutExecutionVersionId] UNIQUEIDENTIFIER NOT NULL,
    [Description]               NVARCHAR (1000)  NULL,
    CONSTRAINT [PK_ExerciseExecution] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ExerciseExecution_WorkoutExecutionVersionId] FOREIGN KEY ([WorkoutExecutionVersionId]) REFERENCES [Workout].[WorkoutExecutionVersion] ([Id]),
    CONSTRAINT [CHECK_ExerciseId] CHECK ([Workout].[CheckExerciseIdConstraint]([ExerciseId]) = 1)
);
GO
CREATE NONCLUSTERED INDEX [IX_ExerciseExecution_WorkoutExecutionVersionId_Order] ON [Workout].[ExerciseExecution] ([WorkoutExecutionVersionId], [Order], [ExerciseId])

