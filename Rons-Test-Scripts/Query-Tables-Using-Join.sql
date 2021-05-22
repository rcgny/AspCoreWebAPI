/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[Title]
      ,[Description]
      ,[Price]
  FROM [TimsDinerDB].[dbo].[Food]
  Select * From [dbo].[Food] f join [dbo].[Order] o on f.Id = o.FoodId