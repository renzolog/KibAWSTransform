CREATE TABLE [dbo].[RegistroDettaglio]
(
	[IdRegistro] INT NOT NULL , 
    [NomeFile] VARCHAR(255) NOT NULL, 
    [Hash] VARCHAR(150) NULL, 
    [Token] VARCHAR(500) NULL, 
	[Id] INT NOT NULL IDENTITY, 
    PRIMARY KEY ([IdRegistro], [NomeFile]), 
    CONSTRAINT [FK_RegistroDettaglio_Registro] FOREIGN KEY (IdRegistro) REFERENCES Registro(Id)
)
