BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Name', N'Description', N'Price', N'Stock', N'Image', N'CategoryId') AND [object_id] = OBJECT_ID(N'[Products]'))
    SET IDENTITY_INSERT [Products] ON;
INSERT INTO [Products] ([Name], [Description], [Price], [Stock], [Image], [CategoryId])
VALUES (N'Caderno', N'Caderno espiral 100 fôlhas', 7.45, 50, N'caderno1.jpg', 1),
(N'Estojo escolar', N'Estojo escola cinza', 5.56, 70, N'estojo1.jpg', 1),
(N'Glitter', N'Glitter Em Pó 500gr Branco Furta Cor Irisado Pintar Parede Branco Furta Cor Irisado Pintar Parede', 47.08, 90, N'glitter.jpg', 1),
(N'Caderno Inteligente', N'Refil Compatível Caderno Inteligente Grande 200x275mm 300fls', 89.2, 100, N'refil.jpg', 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Name', N'Description', N'Price', N'Stock', N'Image', N'CategoryId') AND [object_id] = OBJECT_ID(N'[Products]'))
    SET IDENTITY_INSERT [Products] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230808050402_V1.0.1_DML_INSERT_SEED_PRODUCTS', N'7.0.9');
GO

COMMIT;
GO

