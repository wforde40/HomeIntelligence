CREATE TABLE [dbo].[Location] (
    [Id]   INT              IDENTITY (1, 1) NOT NULL,
    [Guid] UNIQUEIDENTIFIER DEFAULT (newid()) NULL,
    [Name] NVARCHAR (50)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);