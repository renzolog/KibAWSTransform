CREATE TABLE [dbo].[LogEvent]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[ISTAT] VARCHAR(6) NOT NULL,
    [Data] DATETIME NOT NULL, 
    [Severity] SMALLINT NOT NULL, 
    [Metodo] VARCHAR(50) NULL, 
    [Messagge] VARCHAR(5000) NULL
)

GO
CREATE NONCLUSTERED INDEX [IX_LogEvent_ISTAT] ON [dbo].[LogEvent] ([ISTAT]) INCLUDE ([Id],[Data],[Severity],[Metodo],[Messagge])
