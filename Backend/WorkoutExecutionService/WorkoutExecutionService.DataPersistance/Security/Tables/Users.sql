﻿CREATE TABLE [Security].[Users] (
    [Id]      UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]    NVARCHAR (100)   NOT NULL,
    [Created] DATETIME2 (7)    NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Users_Name]
    ON [Security].[Users]([Name] ASC);