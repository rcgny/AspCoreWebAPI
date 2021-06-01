CREATE PROCEDURE [dbo].[spBirds_GetAll]
	AS
begin

	set nocount on;

	select [Id], [Name], [Description]
	from dbo.Bird;

end