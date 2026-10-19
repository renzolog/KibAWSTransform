CREATE TABLE [dbo].[EntiInfoPARERUnitaDocumentarie]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ISTAT] CHAR(6) NOT NULL, 
    [Disabilitato] BIT NOT NULL, 
	[Codice] VARCHAR(20) NOT NULL, 
	[DenominazioneTipologiaDocumento] VARCHAR(100) NOT NULL  ,
	[DenominazioneTipoDocumentoPrincipale] VARCHAR(100) NOT NULL  ,

    [VersanteUserName] VARCHAR(50) NOT NULL, 
    [VersantePassword] VARCHAR(50) NOT NULL, 
    [EsibizioneUserName] VARCHAR(50) NULL, 
    [EsibizionePassword] VARCHAR(50) NULL, 
    [TipoFile] SMALLINT NOT NULL DEFAULT -1, 
    [Segreteria] BIT NOT NULL DEFAULT 0, 
    [Demografici] BIT NOT NULL DEFAULT 0, 
    [Contabilita] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_EntiInfoPARERUnitaDocumentarie_Enti] FOREIGN KEY (ISTAT) REFERENCES Enti(ISTAT)
)
