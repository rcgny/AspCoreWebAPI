CREATE PROCEDURE [dbo].[spWatch_Delete]
	@Id int
AS
begin

	set nocount on;

	delete
	from dbo.[Watch]
	where Id = @Id;

end