/*
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
if not exists (select * from dbo.Bird)
begin
    insert into dbo.Bird([Name], [Description])
    values ('Great-Tailed Grackle','Large black bird with iridescent purple sheen' ),
           ('California Quail','Plump gray bird, that is a ground dweller' ),
           ('Annas Humming Bird','Iridescent green body with dark head' );  
end