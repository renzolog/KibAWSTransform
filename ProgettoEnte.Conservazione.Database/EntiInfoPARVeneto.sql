CREATE TABLE [dbo].[EntiInfoPARVeneto]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ISTAT] VARCHAR(6) NULL, 
    [IdentificativoEnte] VARCHAR(100) NULL, 
    [Intestazione] VARCHAR(500) NULL, 
    [Label] VARCHAR(500) NULL, 
    [Disabilitato] BIT NOT NULL DEFAULT 0
)
