CREATE TABLE [dbo].[TableForEmployee]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [empid] INT NULL, 
    [name] VARCHAR(50) NULL, 
    [position] VARCHAR(50) NULL, 
    [date] DATETIME NULL, 
    [thours] DECIMAL NULL, 
    [sbrut] DECIMAL NULL, 
    [tax] DECIMAL NULL, 
    [snet] DECIMAL NULL
)
