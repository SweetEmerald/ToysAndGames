IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Companies] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Companies] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Products] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    [Description] nvarchar(100) NOT NULL,
    [AgeRestriction] int NOT NULL,
    [CompanyId] int NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [Image] nvarchar(max) NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Products_Companies_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Companies] ([Id]) ON DELETE NO ACTION
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Companies]'))
    SET IDENTITY_INSERT [Companies] ON;
INSERT INTO [Companies] ([Id], [Name])
VALUES (1, N'Mattel'),
(2, N'Disney'),
(3, N'Lego'),
(4, N'Fisher-Price'),
(5, N'Bandai'),
(6, N'Hasbro');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Companies]'))
    SET IDENTITY_INSERT [Companies] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AgeRestriction', N'CompanyId', N'Description', N'Image', N'Name', N'Price') AND [object_id] = OBJECT_ID(N'[Products]'))
    SET IDENTITY_INSERT [Products] ON;
INSERT INTO [Products] ([Id], [AgeRestriction], [CompanyId], [Description], [Image], [Name], [Price])
VALUES (1, 6, 1, N'Matchbox Work Team Pack 4 cars', NULL, N'Match box2', 125.0),
(2, 3, 3, N'Display base for the Mandalorian LEGO Star Wars minifigures', NULL, N'The Razor Crest2', 3000.0),
(3, 3, 6, N'Potato Head - Mr. Potato Head', NULL, N'Potato Head', 1000.0),
(4, 6, 5, N'DC Comics Stylized Superman', NULL, N'Superman 2', 524.0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AgeRestriction', N'CompanyId', N'Description', N'Image', N'Name', N'Price') AND [object_id] = OBJECT_ID(N'[Products]'))
    SET IDENTITY_INSERT [Products] OFF;
GO

CREATE INDEX [IX_Products_CompanyId] ON [Products] ([CompanyId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230131185537_Initial_Migration', N'7.0.2');
GO

COMMIT;
GO

