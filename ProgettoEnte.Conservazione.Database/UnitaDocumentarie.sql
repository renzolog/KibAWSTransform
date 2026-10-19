CREATE TABLE [dbo].[UnitaDocumentarie]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ISTAT] CHAR(6) NOT NULL, 
	[Conservatore] smallint NOT NULL ,
    [Disabilitato] BIT NOT NULL, 
	[Codice] VARCHAR(50) NOT NULL, 
	[DenominazioneTipologiaDocumento] VARCHAR(100) NOT NULL  ,
	[DenominazioneTipoDocumentoPrincipale] VARCHAR(100) NULL  ,

    [VersanteUserName] VARCHAR(50) NOT NULL, 
    [VersantePassword] VARCHAR(50) NOT NULL, 
    [EsibizioneUserName] VARCHAR(50) NULL, 
    [EsibizionePassword] VARCHAR(50) NULL, 
    [Tipo] SMALLINT NOT NULL DEFAULT -1, 
    [Segreteria] BIT NOT NULL DEFAULT 0, 
    [Demografici] BIT NOT NULL DEFAULT 0, 
    [Contabilita] BIT NOT NULL DEFAULT 0, 
    [Policy] VARCHAR(50) NULL, 
    [Versione] SMALLINT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_UnitaDocumentarie_Enti] FOREIGN KEY (ISTAT) REFERENCES Enti(ISTAT)
   
)
