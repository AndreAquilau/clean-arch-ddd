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

CREATE TABLE [Categories] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(256) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Products] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(256) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [Price] decimal(10,2) NOT NULL,
    [Stock] int NOT NULL,
    [Image] nvarchar(max) NULL,
    [CategoryId] int NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
    SET IDENTITY_INSERT [Categories] ON;
INSERT INTO [Categories] ([Id], [Name])
VALUES (1, N'Material Escolar'),
(2, N'Eletrônicos'),
(3, N'Acessórios');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
    SET IDENTITY_INSERT [Categories] OFF;
GO

CREATE INDEX [IX_Products_CategoryId] ON [Products] ([CategoryId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230805035311_V1.0.0_DDL_DATABASE_INITIAL', N'7.0.9');
GO

COMMIT;
GO

