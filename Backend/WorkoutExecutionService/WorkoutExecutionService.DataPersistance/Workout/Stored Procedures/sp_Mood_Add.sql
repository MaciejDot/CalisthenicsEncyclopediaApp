CREATE PROCEDURE [Workout].[sp_Mood_Add]
	@MoodId INT,
	@Name NVARCHAR(100),
	@Created DATETIME2(7),
	@IsActive BIT
AS
	INSERT INTO [Workout].[Mood]
		([MoodId], [Name], [Created], [IsActive])
	VALUES
		(@MoodId, @Name, @Created, @IsActive)
RETURN 0