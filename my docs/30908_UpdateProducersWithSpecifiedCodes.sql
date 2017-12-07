
BEGIN TRY
 
	BEGIN TRANSACTION

	UPDATE Policy SET Region = 'MA' WHERE ProducerStateCode IN ('DC', 'DE', 'KY','MD', 'NC', 'PA', 'SC', 'TN', 'VA', 'WV')
	AND Region <> 'MA' 

	COMMIT
	
END TRY

BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK
    DECLARE @ErrMsg nvarchar(4000), @ErrSeverity int
    SELECT @ErrMsg = ERROR_MESSAGE(),
           @ErrSeverity = ERROR_SEVERITY()
    RAISERROR(@ErrMsg, @ErrSeverity, 1)
END CATCH