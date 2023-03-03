# ThingsApp.API
Proyecto que gestiona toda la funcionalidad backend de apuestas virtuales en linea

ThingsApp es una app de apuestas en linea, que cuentas con todas validaciones descritas en el documento de requerimientos.

Para subir el aplicativo seguir pasos:

Backend
1. Crear manualmente la base de datos del hangfire con el siguiente query
	create database HangFireTest;

2. Recompilar todas las soluciones y subir los microservicios al mismo tiempo.

3. Ejecutar los siguientes scripts para alimentar maestras y tablas transaccionales de prueba

USE [ThingsApp]
GO
INSERT [dbo].[Profiles] ([ID], [Name], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy], [Code]) VALUES (N'131fd7ee-6c8d-4c53-a7f4-369997da18f8', N'USER', 0, CAST(N'2023-02-25T19:53:20.6533333' AS DateTime2), CAST(N'2023-02-25T19:53:20.6533333' AS DateTime2), N'manager', N'manager', N'USER')
GO
INSERT [dbo].[Profiles] ([ID], [Name], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy], [Code]) VALUES (N'dcf538fe-214d-486c-8889-dbf0d13abc68', N'ADMIN', 0, CAST(N'2023-02-25T19:53:20.6533333' AS DateTime2), CAST(N'2023-02-25T19:53:20.6533333' AS DateTime2), N'manager', N'manager', N'ADMIN')
GO
INSERT [dbo].[Users] ([ID], [Name], [DocumentNumber], [Password], [Loggued], [Profile], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'c784f5de-8c82-4e62-9177-44b8e5568d67', N'JOZSEF', N'123456', N'123456', 0, N'dcf538fe-214d-486c-8889-dbf0d13abc68', 0, CAST(N'2023-02-25T19:53:20.6533333' AS DateTime2), CAST(N'2023-02-25T19:53:20.6533333' AS DateTime2), N'manager', N'manager')
GO
INSERT [dbo].[Users] ([ID], [Name], [DocumentNumber], [Password], [Loggued], [Profile], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'5989bf8d-9dec-4170-90f8-e4b2ae5d2034', N'Usuario1', N'11111', N'11111', 1, N'131fd7ee-6c8d-4c53-a7f4-369997da18f8', 0, CAST(N'2023-02-25T19:53:20.6533333' AS DateTime2), CAST(N'2023-02-25T19:53:20.6533333' AS DateTime2), N'manager', N'manager')
GO
INSERT [dbo].[Users] ([ID], [Name], [DocumentNumber], [Password], [Loggued], [Profile], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'5989bf8d-9dec-4170-90f8-e4b2ae5d2035', N'Usuario2', N'22222', N'22222', 0, N'131fd7ee-6c8d-4c53-a7f4-369997da18f8', 0, CAST(N'2023-02-25T19:53:20.6533333' AS DateTime2), CAST(N'2023-02-25T19:53:20.6533333' AS DateTime2), N'manager', N'manager')
GO
INSERT [dbo].[Users] ([ID], [Name], [DocumentNumber], [Password], [Loggued], [Profile], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'5989bf8d-9dec-4170-90f8-e4b2ae5d2039', N'Usuario3', N'33333', N'33333', 1, N'131fd7ee-6c8d-4c53-a7f4-369997da18f8', 0, CAST(N'2023-02-25T19:53:20.6533333' AS DateTime2), CAST(N'2023-02-25T19:53:20.6533333' AS DateTime2), N'manager', N'manager')
GO
INSERT [dbo].[Users] ([ID], [Name], [DocumentNumber], [Password], [Loggued], [Profile], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'5989bf8d-9dec-4170-90f8-e4b2ae5d2040', N'Usuario4', N'44444', N'44444', 0, N'131fd7ee-6c8d-4c53-a7f4-369997da18f8', 0, CAST(N'2023-02-25T19:53:20.6533333' AS DateTime2), CAST(N'2023-02-25T19:53:20.6533333' AS DateTime2), N'manager', N'manager')
GO
INSERT [dbo].[Users] ([ID], [Name], [DocumentNumber], [Password], [Loggued], [Profile], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'5989bf8d-9dec-4170-90f8-e4b2ae5d2041', N'Usuario5', N'55555', N'55555', 0, N'131fd7ee-6c8d-4c53-a7f4-369997da18f8', 0, CAST(N'2023-02-25T19:53:20.6533333' AS DateTime2), CAST(N'2023-02-25T19:53:20.6533333' AS DateTime2), N'manager', N'manager')
GO
INSERT [dbo].[Teams] ([ID], [Description], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'8955b389-335e-4dae-8d10-27ff4679e84d', N'CANADA', 0, CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), N'manager', N'manager')
GO
INSERT [dbo].[Teams] ([ID], [Description], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'f72b341b-048a-4b65-8b79-37e51a20210d', N'COLOMBIA', 0, CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), N'manager', N'manager')
GO
INSERT [dbo].[Teams] ([ID], [Description], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'3dd812d3-306c-4702-8a93-3a5af27a5f71', N'CROACIA', 0, CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), N'manager', N'manager')
GO
INSERT [dbo].[Teams] ([ID], [Description], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'3d4b93c3-9a2f-4bdf-bdbf-3ca89979feff', N'URUGUAY', 0, CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), N'manager', N'manager')
GO
INSERT [dbo].[Teams] ([ID], [Description], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'd9bb5fce-0460-4cf9-90de-44e29d0b87ca', N'CHILE', 0, CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), N'manager', N'manager')
GO
INSERT [dbo].[Teams] ([ID], [Description], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'c70a6856-1c6d-4e81-bb97-5c7ca8576d56', N'ALEMANIA', 0, CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), N'manager', N'manager')
GO
INSERT [dbo].[Teams] ([ID], [Description], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'd4403b9d-7ebd-4800-8b14-624ac849b04a', N'ECUADOR', 0, CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), N'manager', N'manager')
GO
INSERT [dbo].[Teams] ([ID], [Description], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'a7f2a0d4-b739-427e-a0df-73098685a878', N'PARAGUAY', 0, CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), N'manager', N'manager')
GO
INSERT [dbo].[Teams] ([ID], [Description], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'604fa4e8-dd2c-4a20-93a6-815ebbe7e25c', N'MARRUECOS', 0, CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), N'manager', N'manager')
GO
INSERT [dbo].[Teams] ([ID], [Description], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'ac1a8ea8-53a8-42b6-bb61-8d90917f6b39', N'FRANCIA', 0, CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), N'manager', N'manager')
GO
INSERT [dbo].[Teams] ([ID], [Description], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'756c137c-5cea-46dd-be9d-a27f88647f22', N'VENEZUELA', 0, CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), N'manager', N'manager')
GO
INSERT [dbo].[Teams] ([ID], [Description], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'e953ead8-9b79-4c1d-a1d1-a286e54ad31e', N'ARGENTINA', 0, CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), N'manager', N'manager')
GO
INSERT [dbo].[Teams] ([ID], [Description], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'21d25a7d-b135-41c9-81dd-bf148347c424', N'BOLIVIA', 0, CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), N'manager', N'manager')
GO
INSERT [dbo].[Teams] ([ID], [Description], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'd844cb87-9c93-4546-b4f3-d3a11d923880', N'CHINA', 0, CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), N'manager', N'manager')
GO
INSERT [dbo].[Teams] ([ID], [Description], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'd93fd6cb-b0c6-4832-9361-e342ac4cd7ab', N'EE UU', 0, CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), N'manager', N'manager')
GO
INSERT [dbo].[Teams] ([ID], [Description], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'd77e6729-7b6d-44e8-a0ab-ff4a0a4b59d6', N'BRASIL', 0, CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), CAST(N'2023-02-25T19:45:55.3100000' AS DateTime2), N'manager', N'manager')
GO
INSERT [dbo].[Games] ([ID], [TeamA], [TeamB], [GoalsA], [GoalsB], [DateInitial], [Finalized], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy], [DateFinal]) VALUES (N'f10963ed-8332-4e83-8aa5-1023583e064d', N'3d4b93c3-9a2f-4bdf-bdbf-3ca89979feff', N'd9bb5fce-0460-4cf9-90de-44e29d0b87ca', 1, 0, CAST(N'2023-03-02T10:10:00.0000000' AS DateTime2), 1, 0, CAST(N'2023-03-02T10:01:17.7445905' AS DateTime2), CAST(N'2023-03-02T11:41:24.9798451' AS DateTime2), N'MANAGER', N'MANAGER', CAST(N'2023-03-02T12:10:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Games] ([ID], [TeamA], [TeamB], [GoalsA], [GoalsB], [DateInitial], [Finalized], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy], [DateFinal]) VALUES (N'4af3bc93-8b79-4548-9abc-2ffda9b5a32c', N'21d25a7d-b135-41c9-81dd-bf148347c424', N'd77e6729-7b6d-44e8-a0ab-ff4a0a4b59d6', 2, 1, CAST(N'2023-03-02T13:31:00.0000000' AS DateTime2), 0, 0, CAST(N'2023-03-02T13:28:12.4504877' AS DateTime2), CAST(N'2023-03-02T13:31:17.5669793' AS DateTime2), N'MANAGER', N'MANAGER', CAST(N'2023-03-02T15:31:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Games] ([ID], [TeamA], [TeamB], [GoalsA], [GoalsB], [DateInitial], [Finalized], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy], [DateFinal]) VALUES (N'9a0d9e39-e6db-4885-b707-3e1807e9867a', N'ac1a8ea8-53a8-42b6-bb61-8d90917f6b39', N'756c137c-5cea-46dd-be9d-a27f88647f22', 1, 1, CAST(N'2023-03-02T10:10:00.0000000' AS DateTime2), 1, 0, CAST(N'2023-03-02T10:02:07.4583043' AS DateTime2), CAST(N'2023-03-02T11:41:41.5610045' AS DateTime2), N'MANAGER', N'MANAGER', CAST(N'2023-03-02T12:10:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Games] ([ID], [TeamA], [TeamB], [GoalsA], [GoalsB], [DateInitial], [Finalized], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy], [DateFinal]) VALUES (N'2ac90dd9-6bc9-4c06-90a5-5917d3b983ee', N'a7f2a0d4-b739-427e-a0df-73098685a878', N'd844cb87-9c93-4546-b4f3-d3a11d923880', 3, 2, CAST(N'2023-03-02T13:39:00.0000000' AS DateTime2), 0, 0, CAST(N'2023-03-02T11:41:00.0745174' AS DateTime2), CAST(N'2023-03-02T11:41:48.9880272' AS DateTime2), N'MANAGER', N'MANAGER', CAST(N'2023-03-02T15:39:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Games] ([ID], [TeamA], [TeamB], [GoalsA], [GoalsB], [DateInitial], [Finalized], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy], [DateFinal]) VALUES (N'8b7b1e00-e0a6-4ab1-aa53-5bf8a0d13517', N'd77e6729-7b6d-44e8-a0ab-ff4a0a4b59d6', N'21d25a7d-b135-41c9-81dd-bf148347c424', 6, 3, CAST(N'2023-03-02T10:12:00.0000000' AS DateTime2), 1, 0, CAST(N'2023-03-02T10:07:52.1259563' AS DateTime2), CAST(N'2023-03-02T11:42:21.1404413' AS DateTime2), N'MANAGER', N'MANAGER', CAST(N'2023-03-02T12:12:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Games] ([ID], [TeamA], [TeamB], [GoalsA], [GoalsB], [DateInitial], [Finalized], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy], [DateFinal]) VALUES (N'4d6a8524-e9f6-4182-9537-a4629c668f5d', N'c70a6856-1c6d-4e81-bb97-5c7ca8576d56', N'604fa4e8-dd2c-4a20-93a6-815ebbe7e25c', 0, 0, CAST(N'2023-03-02T15:05:00.0000000' AS DateTime2), 0, 0, CAST(N'2023-03-02T15:02:24.7226023' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'MANAGER', CAST(N'2023-03-02T17:05:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Games] ([ID], [TeamA], [TeamB], [GoalsA], [GoalsB], [DateInitial], [Finalized], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy], [DateFinal]) VALUES (N'ff31db75-8679-45be-bf30-a53593e1a967', N'8955b389-335e-4dae-8d10-27ff4679e84d', N'f72b341b-048a-4b65-8b79-37e51a20210d', 4, 0, CAST(N'2023-03-02T10:05:00.0000000' AS DateTime2), 1, 0, CAST(N'2023-03-02T10:00:51.8262640' AS DateTime2), CAST(N'2023-03-02T10:06:13.7803111' AS DateTime2), N'MANAGER', N'MANAGER', CAST(N'2023-03-02T12:05:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Games] ([ID], [TeamA], [TeamB], [GoalsA], [GoalsB], [DateInitial], [Finalized], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy], [DateFinal]) VALUES (N'b4b3a2c9-1fb8-4006-a613-e250c8fde8ef', N'd93fd6cb-b0c6-4832-9361-e342ac4cd7ab', N'd844cb87-9c93-4546-b4f3-d3a11d923880', 2, 2, CAST(N'2023-03-02T11:38:00.0000000' AS DateTime2), 1, 0, CAST(N'2023-03-02T11:37:54.1583186' AS DateTime2), CAST(N'2023-03-02T11:41:16.0565842' AS DateTime2), N'MANAGER', N'MANAGER', CAST(N'2023-03-02T13:38:00.0000000' AS DateTime2))
GO
INSERT [dbo].[SessionBets] ([ID], [Name], [Code], [Game], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'4c94a1eb-e085-4d02-8d86-6d9f714bd255', N'brasilcampeon', N'60593b02-3424-4c48-8eec-efae540cc95b', N'8b7b1e00-e0a6-4ab1-aa53-5bf8a0d13517', 0, CAST(N'2023-03-02T10:08:16.0459842' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'MANAGER')
GO
INSERT [dbo].[SessionBets] ([ID], [Name], [Code], [Game], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'747d6501-becd-4e5b-8750-8ae14cb2938c', N'APUESTA1', N'ff83d38e-ef93-4dc2-bec5-eadf1a1a9460', N'ff31db75-8679-45be-bf30-a53593e1a967', 0, CAST(N'2023-03-02T10:03:23.1331073' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'MANAGER')
GO
INSERT [dbo].[SessionBets] ([ID], [Name], [Code], [Game], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'62df55df-fc3e-4aea-b06a-c8d01179a4d9', N'APUESTA123', N'bcc22b0c-ef79-4f9c-9372-64a2cdd9b211', N'4d6a8524-e9f6-4182-9537-a4629c668f5d', 0, CAST(N'2023-03-02T15:03:16.7747083' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'MANAGER')
GO
INSERT [dbo].[RecordBets] ([ID], [SessionBet], [User], [GoalsA], [GoalsB], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'bfc522bc-c711-4f57-aaf1-318c728b6b79', N'747d6501-becd-4e5b-8750-8ae14cb2938c', N'5989bf8d-9dec-4170-90f8-e4b2ae5d2034', 1, 0, 0, CAST(N'2023-03-02T10:03:36.7720479' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'MANAGER')
GO
INSERT [dbo].[RecordBets] ([ID], [SessionBet], [User], [GoalsA], [GoalsB], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'dd9509dc-a76f-4bbd-b37a-47f876a09943', N'4c94a1eb-e085-4d02-8d86-6d9f714bd255', N'5989bf8d-9dec-4170-90f8-e4b2ae5d2034', 4, 0, 0, CAST(N'2023-03-02T10:08:30.3332060' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'MANAGER')
GO
INSERT [dbo].[RecordBets] ([ID], [SessionBet], [User], [GoalsA], [GoalsB], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'98a9c3b0-60da-40a3-a94a-7c2db4a82718', N'747d6501-becd-4e5b-8750-8ae14cb2938c', N'5989bf8d-9dec-4170-90f8-e4b2ae5d2035', 4, 0, 0, CAST(N'2023-03-02T10:03:57.0553124' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'MANAGER')
GO
INSERT [dbo].[RecordBets] ([ID], [SessionBet], [User], [GoalsA], [GoalsB], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'873b729d-159c-4e36-8a90-92ab150c04ef', N'62df55df-fc3e-4aea-b06a-c8d01179a4d9', N'5989bf8d-9dec-4170-90f8-e4b2ae5d2034', 2, 0, 0, CAST(N'2023-03-02T15:03:40.7605175' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'MANAGER')
GO
INSERT [dbo].[RecordBets] ([ID], [SessionBet], [User], [GoalsA], [GoalsB], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'bbffe6f8-3f7f-4d26-bfae-af70cf5e2894', N'4c94a1eb-e085-4d02-8d86-6d9f714bd255', N'5989bf8d-9dec-4170-90f8-e4b2ae5d2035', 6, 3, 0, CAST(N'2023-03-02T10:08:48.9200211' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'MANAGER')
GO
INSERT [dbo].[RecordBets] ([ID], [SessionBet], [User], [GoalsA], [GoalsB], [Inactive], [CreatedAt], [ModifyDate], [ModifiedBy], [CreatedBy]) VALUES (N'cfe452b0-c9c2-41d9-a039-fe7a50cf517a', N'62df55df-fc3e-4aea-b06a-c8d01179a4d9', N'5989bf8d-9dec-4170-90f8-e4b2ae5d2039', 3, 3, 0, CAST(N'2023-03-02T15:04:06.0162152' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'MANAGER')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230226152051_AddEntitys', N'5.0.17')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230226180154_AddFinalGame', N'5.0.17')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230226205957_UpdateLengthField', N'5.0.17')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230227223328_CodePerfil', N'5.0.17')
GO


4. Front
npm i para instalar dependencias y subir el proyecto para el comando ng serve
