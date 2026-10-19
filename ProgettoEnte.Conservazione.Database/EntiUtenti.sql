CREATE TABLE [dbo].[EntiUtenti]
(
	[ISTAT] CHAR(6) NOT NULL , 
    [UserName] VARCHAR(50) NOT NULL, 
    [Password] VARCHAR(50) NOT NULL, 
    [Disabilitato] BIT NOT NULL, 
    [Cognome] VARCHAR(50) NULL, 
    [Nome] VARCHAR(50) NULL, 
    [ROLES] VARCHAR(50) NULL, 
    [Software] SMALLINT NOT NULL DEFAULT -1, 
    PRIMARY KEY ([UserName]), 
    CONSTRAINT [FK_EntiUtenti_ToEnti] FOREIGN KEY (ISTAT) REFERENCES Enti(ISTAT)
)
