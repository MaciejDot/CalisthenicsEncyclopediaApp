CREATE TABLE [Workout].[WorkoutExecutionVersion] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [UserId]      UNIQUEIDENTIFIER NOT NULL,
    [ExternalId]  UNIQUEIDENTIFIER NOT NULL,
    [IsActive]    BIT              NULL,
    [Name]        NVARCHAR (400)   NOT NULL,
    [Created]     DATETIME2 (7)    NOT NULL,
    [Executed]     DATETIME2 (7)    NOT NULL,
    [IsPublic]    BIT              NOT NULL,
    [Description] NVARCHAR (1000)  NULL,
    [MoodId]      INT              NOT NULL,
    [FatigueId]   INT              NOT NULL,
    CONSTRAINT [PK_WorkoutExecutionVersion] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CHECK_FatigueId] CHECK ([Workout].[CheckFatigueIdConstraint]([FatigueId])=(1)),
    CONSTRAINT [CHECK_MoodId] CHECK ([Workout].[CheckMoodIdConstraint]([MoodId])=(1)),
    CONSTRAINT [FK_WorkoutExecutionVersion_User] FOREIGN KEY ([UserId]) REFERENCES [Security].[Users] ([Id]) ON DELETE CASCADE
);

GO
CREATE NONCLUSTERED INDEX [IX_WorkoutExecutionVersion_UserId_External_Created]
    ON [Workout].[WorkoutExecutionVersion]([UserId] ASC,[ExternalId], [Created] DESC);

