CREATE PROCEDURE [dbo].[spWatch_GetById]
	@Id int
AS
begin
	
	set nocount on;

	select [Id], [Category], [BirdId], [Location], [Map]
	from dbo.[Watch]
	where Id = @Id;

end
