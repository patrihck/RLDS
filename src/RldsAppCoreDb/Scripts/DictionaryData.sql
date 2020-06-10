-- TransactionStatus table --
IF NOT EXISTS(SELECT * FROM [dbo].[TransactionStatus] WHERE [Name] = 'Planned')
	INSERT INTO [dbo].[TransactionStatus]([TransactionStatusId], [Name], [Ordinal]) VALUES (100, 'Planned', 1);

IF NOT EXISTS(SELECT * FROM [dbo].[TransactionStatus] WHERE [Name] = 'Awaiting')
	INSERT INTO [dbo].[TransactionStatus]([TransactionStatusId], [Name], [Ordinal]) VALUES (200, 'Awaiting', 2);

IF NOT EXISTS(SELECT * FROM [dbo].[TransactionStatus] WHERE [Name] = 'Paid')
	INSERT INTO [dbo].[TransactionStatus]([TransactionStatusId], [Name], [Ordinal]) VALUES (300, 'Paid', 3);

IF NOT EXISTS(SELECT * FROM [dbo].[TransactionStatus] WHERE [Name] = 'Outdated')
	INSERT INTO [dbo].[TransactionStatus]([TransactionStatusId], [Name], [Ordinal]) VALUES (400, 'Outdated', 4);

-- TransactionType table --
IF NOT EXISTS(SELECT * FROM [dbo].[TransactionType] WHERE [Name] = 'Incoming transfer')
	INSERT INTO [dbo].[TransactionType]([TransactionTypeId], [Name]) VALUES (100, 'Incomming transfer');

IF NOT EXISTS(SELECT * FROM [dbo].[TransactionType] WHERE [Name] = 'Outgoing transfer')
	INSERT INTO [dbo].[TransactionType]([TransactionTypeId], [Name]) VALUES (200, 'Outgoing transfer');

IF NOT EXISTS(SELECT * FROM [dbo].[TransactionType] WHERE [Name] = 'Transfer')
	INSERT INTO [dbo].[TransactionType]([TransactionTypeId], [Name]) VALUES (300, 'Transfer');
