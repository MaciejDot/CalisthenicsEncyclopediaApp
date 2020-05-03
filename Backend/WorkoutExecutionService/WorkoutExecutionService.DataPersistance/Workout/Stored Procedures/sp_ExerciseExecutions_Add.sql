CREATE PROCEDURE [Workout].[sp_ExerciseExecutions_Add]
	@WorkoutExecutionVersionId    UNIQUEIDENTIFIER,
    @Series                  INT             ,
    @Reps                 INT             ,
    @AdditionalKgs        INT             ,
    @ExerciseId              INT             ,
    @Order                   INT             ,
    @Description             NVARCHAR (1000) ,
    @Break                   INT             
AS
	INSERT INTO [Workout].[ExerciseExecution]
        ( [WorkoutExecutionVersionId], [Series], [Repetitions], [AdditionalKgs],[ExerciseId], [Order], [Description], [Break])
    VALUES
        ( @WorkoutExecutionVersionId, @Series, @Reps, @AdditionalKgs, @ExerciseId, @Order, @Description, @Break)
RETURN 0