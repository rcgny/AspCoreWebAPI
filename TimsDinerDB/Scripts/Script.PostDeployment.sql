﻿/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
 --The insert script only runs if the table is empty
if not exists (select * from dbo.Food)
begin
    insert into dbo.Food(Title, [Description], Price)
    values ('Cheeseburger Meal', 'A cheeseburger, fries, and a drink', 5.95),
    ('Chili Dog Meal', 'Two chili dogs, fries, and a drink', 4.15),
    ('Vegan Meal', 'A large salad and a water', 1.95);
end