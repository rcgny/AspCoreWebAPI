USE [TimsDinerDB]
GO
EXECUTE [dbo].[spOrders_Insert]  
    @Id = 1,
    @OrderName = "Ronny",
	@OrderDate =  '04-05-2021',
	@FoodId = 1,
	@Quantity = 2,
	@Total = 11.90
GO