CREATE PROCEDURE [Workout].[sp_Fatigue_Add]
	@FatigueId INT,
	@Name NVARCHAR(100),
	@Created DATETIME2(7),
	@IsActive BIT
AS
	INSERT INTO [Workout].[Fatigue]
		([FatigueId], [Name], [Created], [IsActive])
	VALUES
		(@FatigueId, @Name, @Created, @IsActive)
RETURN 0