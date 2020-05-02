-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION Workout.CheckMoodIdConstraint
(
	@MoodId int
)
RETURNS BIT
AS
BEGIN
	 IF EXISTS (SELECT* FROM Workout.Mood WHERE MoodId = @MoodId)
        return 1
    return 0
END
