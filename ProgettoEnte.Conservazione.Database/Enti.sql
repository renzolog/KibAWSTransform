CREATE TABLE [dbo].[Enti]
(
	[ISTAT] CHAR(6) NOT NULL PRIMARY KEY, 
    [Denominazione] VARCHAR(150) NOT NULL, 
    [Disattivo] BIT NOT NULL, 
    [Conservatore] SMALLINT NOT NULL DEFAULT 0, 
    [InCollaudo] BIT NOT NULL DEFAULT 1
)
