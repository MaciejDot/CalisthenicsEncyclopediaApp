CREATE PROCEDURE [Workout].[sp_WorkoutExecutions_Delete]
	@Username NVARCHAR(100),
	@ExternalId UNIQUEIDENTIFIER,
	@Created DATETIME2(7)

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
		([Id], [Name], [IsActive],[UserId], [Created], [Description], [IsPublic], [ExternalId])
	VALUES
		(newid(), N'-- deleted --', 0, @UserId, @Created, NULL, 0, @ExternalId)

RETURN 0
