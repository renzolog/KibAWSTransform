CREATE TABLE [dbo].[Registro]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ISTAT] CHAR(6) NOT NULL, 
 [IDUnitaDocumentaria] INT NOT NULL, 
    [Data] DATETIME NOT NULL, 
    [AnnoChiave] INT NOT NULL, 
    [NumeroChiave] VARCHAR(50) NOT NULL, 
   
    [Token] VARCHAR(500) NULL, 
    CONSTRAINT [FK_Registro_Enti] FOREIGN KEY (ISTAT) REFERENCES Enti(ISTAT), 
    CONSTRAINT [FK_Registro_UnitaDocumentarie] FOREIGN KEY (IDUnitaDocumentaria) REFERENCES UnitaDocumentarie(Id)
)

GO
CREATE NONCLUSTERED INDEX [IX_Registro_Data] ON [dbo].[Registro] ([Data]) INCLUDE ([Id],[ISTAT],[IDUnitaDocumentaria],[AnnoChiave],[NumeroChiave],[Token])

GO
CREATE NONCLUSTERED INDEX [IX_Registro_IDUnitaDocumentariaData] ON [dbo].[Registro] ([IDUnitaDocumentaria],[Data]) INCLUDE ([Id],[ISTAT],[AnnoChiave],[NumeroChiave],[Token])

