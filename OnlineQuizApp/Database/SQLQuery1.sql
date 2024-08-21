CREATE PROCEDURE DeleteQuizAndQuestions
    @QId INT
AS
BEGIN
    -- Start a transaction
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Delete questions associated with the quiz
        DELETE FROM QuestionTbl
        WHERE Quiz = @QId;

        -- Delete the quiz itself
        DELETE FROM QuizTbl
        WHERE QId = @QId;

        -- Commit the transaction
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Rollback the transaction if an error occurs
        ROLLBACK TRANSACTION;

        -- Rethrow the error
        THROW;
    END CATCH;
END;
