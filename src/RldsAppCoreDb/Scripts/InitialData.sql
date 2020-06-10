-- Role table --
SET IDENTITY_INSERT [dbo].[Role] ON;
GO

IF NOT EXISTS (SELECT TOP(1) 1 FROM [dbo].[Role] WHERE [RoleId] = 1)
	INSERT INTO [dbo].[Role] ([RoleId], [RoleName])
	VALUES (1, 'User');

IF NOT EXISTS (SELECT TOP(1) 1 FROM [dbo].[Role] WHERE [RoleId] = 2)
	INSERT INTO [dbo].[Role] ([RoleId], [RoleName])
	VALUES (2, 'SuperUser');

IF NOT EXISTS (SELECT TOP(1) 1 FROM [dbo].[Role] WHERE [RoleId] = 3)
	INSERT INTO [dbo].[Role] ([RoleId], [RoleName])
	VALUES (3, 'Admin');
GO

SET IDENTITY_INSERT [dbo].[Role] OFF;
GO

-- Currency table --
INSERT INTO [dbo].[Currency]  ([Name], [Acronym], [Symbol], [IsPrefix]) VALUES ('United States Dollar', 'USD', N'US$', 0);
INSERT INTO [dbo].[Currency]  ([Name], [Acronym], [Symbol], [IsPrefix]) VALUES ('Euro', 'EUR', N'€', 0);
INSERT INTO [dbo].[Currency]  ([Name], [Acronym], [Symbol], [IsPrefix]) VALUES ('Polish zloty', 'PLN', N'zł', 0);

-- User table --
SET IDENTITY_INSERT [dbo].[User] ON;
GO

IF NOT EXISTS (SELECT TOP(1) 1 FROM [dbo].[User] WHERE [UserId] = 1)
	INSERT INTO [dbo].[User] ([UserId], [Login], [Password], [Firstname], [LastName], [Email])
	VALUES (1, 'Alan', 'Biegun', 'Alan', 'Biegun', 'Biegun@gmail.com');

IF NOT EXISTS (SELECT TOP(1) 1 FROM [dbo].[User] WHERE [UserId] = 2)
	INSERT INTO [dbo].[User] ([UserId], [Login], [Password], [Firstname], [Lastname], [Email])
	VALUES (2, 'Konrad', 'Sladkowski', 'Konrad', 'Sladkowski', 'Sladkowski@gmail.pl');

IF NOT EXISTS (SELECT TOP(1) 1 FROM [dbo].[User] WHERE [User].[UserId] = 3)
	INSERT INTO [dbo].[User] ([UserId], [Login], [Password], [Firstname], [Lastname], [Email])
	VALUES (3, 'Damian', 'Kostrzewski', 'Damian', 'Kostrzewski', 'Kostrzewski@gmail.com');

IF NOT EXISTS (SELECT TOP(1) 1 FROM [dbo].[User] WHERE [User].[UserId] = 4)
	INSERT INTO [dbo].[User] ([UserId], [Login], [Password], [Firstname], [Lastname], [Email])
	VALUES (4, 'Jan', 'Snopek', 'Jan', 'Snopek', 'Snopek@gmail.pl');

IF NOT EXISTS (SELECT TOP(1) 1 FROM [dbo].[User] WHERE [User].[UserId] = 5)
	INSERT INTO [dbo].[User] ([UserId], [Login], [Password], [Firstname], [Lastname], [Email])
	VALUES (5, 'Patryk', 'Jóźwiak', 'Patryk', 'Jóźwiak', 'Jóźwiak@gmail.pl');

IF NOT EXISTS (SELECT TOP(1) 1 FROM [dbo].[User] WHERE [User].[UserId] = 66)
	INSERT INTO [dbo].[User] ([UserId], [Login], [Password], [Firstname], [Lastname], [Email])
	VALUES (6, 'Mariusz', 'Mariusz', 'Mariusz', 'Mariusz', 'Mariusz@gmail.pl');

SET IDENTITY_INSERT [dbo].[User] OFF;
GO

-- User role table --
INSERT INTO [dbo].[UserRole] ([UserId], [RoleId])
SELECT [UserId], 3
FROM [dbo].[User];

-- Transaction Category table --
IF NOT EXISTS (SELECT TOP(1) 1 FROM [dbo].[TransactionCategory] WHERE [TransactionCategory].[Name] = 'Shopping')
	INSERT INTO [dbo].[TransactionCategory] ([Name], [RootId])
	VALUES ('Shopping', NULL);

IF NOT EXISTS (SELECT TOP(1) 1 FROM [dbo].[TransactionCategory] WHERE [TransactionCategory].[Name] = 'Utilities')
	INSERT INTO [dbo].[TransactionCategory] ([Name], [RootId])
	VALUES ('Utilities', NULL);

IF NOT EXISTS (SELECT TOP(1) 1 FROM [dbo].[TransactionCategory] WHERE [TransactionCategory].[Name] = 'Transportation')
	INSERT INTO [dbo].[TransactionCategory] ([Name], [RootId])
	VALUES ('Transportation', NULL);

-- Account table --
SET IDENTITY_INSERT [dbo].[Account] ON;
GO

IF NOT EXISTS (SELECT TOP(1) 1 FROM [dbo].[Account] WHERE [Account].[UserId] = 1)
	INSERT INTO [dbo].[Account] ([AccountId], [Name], [UserId], [CurrencyId], [StartAmount])
	VALUES (1, 'Acc 1', 1, 1, 120);

IF NOT EXISTS (SELECT TOP(1) 1 FROM [dbo].[Account] WHERE [Account].[UserId] = 2)
	INSERT INTO [dbo].[Account] ([AccountId], [Name], [UserId], [CurrencyId], [StartAmount])
	VALUES (2, 'Acc 2', 2, 2, 50);

IF NOT EXISTS (SELECT TOP(1) 1 FROM [dbo].[Account] WHERE [Account].[UserId] = 3)
	INSERT INTO [dbo].[Account] ([AccountId], [Name], [UserId], [CurrencyId], [StartAmount])
	VALUES (3, 'Acc 3', 3, 1, 300);

IF NOT EXISTS (SELECT TOP(1) 1 FROM [dbo].[Account] WHERE [Account].[UserId] = 4)
	INSERT INTO [dbo].[Account] ([AccountId], [Name], [UserId], [CurrencyId], [StartAmount])
	VALUES (4, 'Acc 4', 4, 3, 666);

IF NOT EXISTS (SELECT TOP(1) 1 FROM [dbo].[Account] WHERE [Account].[UserId] = 5)
	INSERT INTO [dbo].[Account] ([AccountId], [Name], [UserId], [CurrencyId], [StartAmount])
	VALUES (5, 'Acc 5', 5, 2, 1234);

SET IDENTITY_INSERT [dbo].[Account] OFF;
GO

-- Currency Rate table --
IF NOT EXISTS (SELECT TOP(1) 1 FROM [dbo].[CurrencyRate] WHERE [CurrencyRate].[SourceCurrencyId] = 1 AND [CurrencyRate].[TargetCurrencyId] = 2 
	AND [CurrencyRate].[Date] = '2019-12-15')
INSERT INTO [dbo].[CurrencyRate] ([SourceCurrencyId], [TargetCurrencyId], [Date], [Rate])
	VALUES (1, 2, '2019-12-15', 2.58);

IF NOT EXISTS (SELECT TOP(1) 1 FROM [dbo].[CurrencyRate] WHERE [CurrencyRate].[SourceCurrencyId] = 10 AND [CurrencyRate].[TargetCurrencyId] = 16 
	AND [CurrencyRate].[Date] = '2019-12-10')
INSERT INTO [dbo].[CurrencyRate] ([SourceCurrencyId], [TargetCurrencyId], [Date], [Rate])
	VALUES (2, 3, '2019-12-10', 5.20);

IF NOT EXISTS (SELECT TOP(1) 1 FROM [dbo].[CurrencyRate] WHERE [CurrencyRate].[SourceCurrencyId] = 34 AND [CurrencyRate].[TargetCurrencyId] = 2 
	AND [CurrencyRate].[Date] = '2019-11-25')
INSERT INTO [dbo].[CurrencyRate] ([SourceCurrencyId], [TargetCurrencyId], [Date], [Rate])
	VALUES (1, 3, '2019-11-25', 3);

IF NOT EXISTS (SELECT TOP(1) 1 FROM [dbo].[CurrencyRate] WHERE [CurrencyRate].[SourceCurrencyId] = 24 AND [CurrencyRate].[TargetCurrencyId] = 15 
	AND [CurrencyRate].[Date] = '2019-12-12')
INSERT INTO [dbo].[CurrencyRate] ([SourceCurrencyId], [TargetCurrencyId], [Date], [Rate])
	VALUES (3, 2, '2019-12-12', 3.50);

IF NOT EXISTS (SELECT TOP(1) 1 FROM [dbo].[CurrencyRate] WHERE [CurrencyRate].[SourceCurrencyId] = 20 AND [CurrencyRate].[TargetCurrencyId] = 21 
	AND [CurrencyRate].[Date] = '2019-12-15')
INSERT INTO [dbo].[CurrencyRate] ([SourceCurrencyId], [TargetCurrencyId], [Date], [Rate])
	VALUES (2, 1, '2019-12-15', 120.50);


-- Transactions --
INSERT INTO [dbo].[Transaction](Date, UserId, SenderId, ReceiverId, TypeId, CategoryId, StatusId, CurrencyId, Description, Amount) 
VALUES ('2020-06-09 02:53:53', 1, 3, 3, 200, 1, 300, 1, '1', '331.32');
INSERT INTO [dbo].[Transaction](Date, UserId, SenderId, ReceiverId, TypeId, CategoryId, StatusId, CurrencyId, Description, Amount) 
VALUES ('2020-05-22 04:25:09', 2, 3, 3, 300, 2, 100, 2, '2', '441');
INSERT INTO [dbo].[Transaction](Date, UserId, SenderId, ReceiverId, TypeId, CategoryId, StatusId, CurrencyId, Description, Amount) 
VALUES ('2020-07-21 17:06:04', 3, 5, 5, 100, 1, 100, 3, '3', '45.48');
INSERT INTO [dbo].[Transaction](Date, UserId, SenderId, ReceiverId, TypeId, CategoryId, StatusId, CurrencyId, Description, Amount) 
VALUES ('2020-07-21 06:41:29', 5, 1, 1, 100, 1, 300, 1, '4', '10');
INSERT INTO [dbo].[Transaction](Date, UserId, SenderId, ReceiverId, TypeId, CategoryId, StatusId, CurrencyId, Description, Amount) 
VALUES ('2020-04-10 04:09:28', 3, 4, 4, 100, 1, 200, 2, '11.', '3.25');
INSERT INTO [dbo].[Transaction](Date, UserId, SenderId, ReceiverId, TypeId, CategoryId, StatusId, CurrencyId, Description, Amount) 
VALUES ('2020-08-30 20:41:37', 3, 4, 4, 200, 1, 300, 2, '12', '441.00');