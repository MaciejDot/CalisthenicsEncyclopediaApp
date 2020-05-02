-- =============================================
CREATE FUNCTION Workout.CheckFatigueIdConstraint
(
	@FatigueId int
)
RETURNS BIT
AS
BEGIN
	 IF EXISTS (SELECT* FROM Workout.Fatigue WHERE FatigueId = @FatigueId)
        return 1
    return 0
END
