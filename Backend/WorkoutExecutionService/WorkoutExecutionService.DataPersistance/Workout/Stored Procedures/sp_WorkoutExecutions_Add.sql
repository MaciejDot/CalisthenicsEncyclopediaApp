CREATE PROCEDURE [Workout].[sp_WorkoutExecutions_Add]
	@Username NVARCHAR(100),
	@WorkouExecutionVersionId UNIQUEIDENTIFIER,
	@ExternalId UNIQUEIDENTIFIER,
	@WorkoutName NVARCHAR(400),
	@Description NVARCHAR(1000),
	@IsPublic BIT,
	@Created DATETIME2(7),
	@IsActive BIT,
	@MoodId INT,
	@FatigueId INT

AS
	DECLARE @UserId UNIQUEIDENTIFIER =
	(
		SELECT TOP 1
			[Id]
		FROM
			[Security].[Users]
		WHERE
			[Name] = @Username
	)
	INSERT INTO [Workout].[WorkoutExecutionVersion]
		([Id], [Name], [IsActive], [UserId], [Created], [Description], [IsPublic], [ExternalId], [MoodId], [FatigueId])
	VALUES
		(@WorkouExecutionVersionId, @WorkoutName, @IsActive, @UserId, @Created, @Description, @IsPublic, @ExternalId, @MoodId, @FatigueId)

