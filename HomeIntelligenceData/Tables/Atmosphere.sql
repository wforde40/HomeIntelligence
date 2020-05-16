CREATE TABLE [dbo].[Atmosphere]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [Temperature] DECIMAL(18, 2) NULL, 
    [Humidity] DECIMAL(18, 2) NULL, 
    [Pressure] DECIMAL(18, 2) NULL, 
    [Location] UNIQUEIDENTIFIER NULL, 
    [Sensor] UNIQUEIDENTIFIER NULL, 
    [DateRecieved] DATETIME NULL DEFAULT GETDATE(), 
)
