CREATE TABLE [dbo].[EntiInfoPARER]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ISTAT] CHAR(6) NOT NULL, 
    [Disabilitato] BIT NOT NULL, 
    [Ambiente] VARCHAR(50) NOT NULL, 
    [DenominazioneEnte] VARCHAR(50) NOT NULL, 
    [VersioneConservazione] VARCHAR(50) NOT NULL DEFAULT 1.4, 
    [Struttura] VARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_EntiInfoPARER_Enti] FOREIGN KEY (ISTAT) REFERENCES Enti(ISTAT)
)
