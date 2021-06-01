CREATE PROCEDURE [dbo].[spWatch_UpdateLocation]
		@Id int,
	    @Location nvarchar(50)
AS
begin

	set nocount on;

	update dbo.[Watch]
	set Location = @Location
	where Id = @Id;

end
