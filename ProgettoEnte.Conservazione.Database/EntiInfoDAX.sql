CREATE TABLE [dbo].[EntiInfoDAX]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Istat] VARCHAR(6) NOT NULL, 
    [Intestazione] VARCHAR(500) NOT NULL, 
    [Label ] VARCHAR(500) NULL, 
    [Disabilitato] BIT NOT NULL DEFAULT 0 
)
