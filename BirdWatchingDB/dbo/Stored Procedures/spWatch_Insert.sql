CREATE PROCEDURE [dbo].[spWatch_Insert]
	@Category nvarchar(50),	 
	@BirdId int,
	@Location nvarchar(50),	 
	@Map nvarchar(50),	 
	@Id int output
AS
begin

	set nocount on;

	insert into dbo.[Watch](Category, BirdId, [Location], Map)
	values (@Category, @BirdId, @Location, @Map);

	set @Id = SCOPE_IDENTITY();

end