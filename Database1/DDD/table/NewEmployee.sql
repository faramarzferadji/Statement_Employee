CREATE TABLE [dbo].[NewEmployee]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [empid] INT NOT NULL, 
    [name] VARCHAR(50) NOT NULL, 
    [position] VARCHAR(50) NOT NULL, 
    [date] DATETIME NOT NULL, 
    [thours] DECIMAL NOT NULL, 
    [sbrut] DECIMAL NOT NULL, 
    [tax] DECIMAL NOT NULL, 
    [snet] DECIMAL NULL
)
