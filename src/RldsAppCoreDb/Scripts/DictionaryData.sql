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

IF NOT EXISTS(SELECT * FROM [dbo].[TransactionType] WHERE [Name] = 'Internal')
	INSERT INTO [dbo].[TransactionType]([TransactionTypeId], [Name]) VALUES (400, 'Internal');

	
IF NOT EXISTS(SELECT * FROM [dbo].[Daily]) 
BEGIN
INSERT INTO [dbo].[Daily]([DailyId], [Hour]) VALUES (1 , 1 );
INSERT INTO [dbo].[Daily]([DailyId], [Hour]) VALUES (2 , 2 );
INSERT INTO [dbo].[Daily]([DailyId], [Hour]) VALUES (3 , 3 );
INSERT INTO [dbo].[Daily]([DailyId], [Hour]) VALUES (4 , 4 );
INSERT INTO [dbo].[Daily]([DailyId], [Hour]) VALUES (5 , 5 );
INSERT INTO [dbo].[Daily]([DailyId], [Hour]) VALUES (6 , 6 );
INSERT INTO [dbo].[Daily]([DailyId], [Hour]) VALUES (7 , 7 );
INSERT INTO [dbo].[Daily]([DailyId], [Hour]) VALUES (8 , 8 );
INSERT INTO [dbo].[Daily]([DailyId], [Hour]) VALUES (9 , 9 );
INSERT INTO [dbo].[Daily]([DailyId], [Hour]) VALUES (10, 10);
INSERT INTO [dbo].[Daily]([DailyId], [Hour]) VALUES (11, 11);
INSERT INTO [dbo].[Daily]([DailyId], [Hour]) VALUES (12, 12);
INSERT INTO [dbo].[Daily]([DailyId], [Hour]) VALUES (13, 13);
INSERT INTO [dbo].[Daily]([DailyId], [Hour]) VALUES (14, 14);
INSERT INTO [dbo].[Daily]([DailyId], [Hour]) VALUES (15, 15);
INSERT INTO [dbo].[Daily]([DailyId], [Hour]) VALUES (16, 16);
INSERT INTO [dbo].[Daily]([DailyId], [Hour]) VALUES (17, 17);
INSERT INTO [dbo].[Daily]([DailyId], [Hour]) VALUES (18, 18);
INSERT INTO [dbo].[Daily]([DailyId], [Hour]) VALUES (19, 19);
INSERT INTO [dbo].[Daily]([DailyId], [Hour]) VALUES (20, 20);
INSERT INTO [dbo].[Daily]([DailyId], [Hour]) VALUES (21, 21);
INSERT INTO [dbo].[Daily]([DailyId], [Hour]) VALUES (22, 22);
INSERT INTO [dbo].[Daily]([DailyId], [Hour]) VALUES (23, 23);
END

IF NOT EXISTS(SELECT * FROM [dbo].[Weekly]) 
BEGIN
INSERT INTO [dbo].[Weekly]([WeeklyId], [Day]) VALUES (1, 1);
INSERT INTO [dbo].[Weekly]([WeeklyId], [Day]) VALUES (2, 2);
INSERT INTO [dbo].[Weekly]([WeeklyId], [Day]) VALUES (3, 3);
INSERT INTO [dbo].[Weekly]([WeeklyId], [Day]) VALUES (4, 4);
INSERT INTO [dbo].[Weekly]([WeeklyId], [Day]) VALUES (5, 5);
INSERT INTO [dbo].[Weekly]([WeeklyId], [Day]) VALUES (6, 6);
INSERT INTO [dbo].[Weekly]([WeeklyId], [Day]) VALUES (7, 7);
END

IF NOT EXISTS(SELECT * FROM [dbo].[Weekly]) 
BEGIN
INSERT INTO [dbo].[Monthly]([MonthlyId], [Month]) VALUES (1 , 1 );
INSERT INTO [dbo].[Monthly]([MonthlyId], [Month]) VALUES (2 , 2 );
INSERT INTO [dbo].[Monthly]([MonthlyId], [Month]) VALUES (3 , 3 );
INSERT INTO [dbo].[Monthly]([MonthlyId], [Month]) VALUES (4 , 4 );
INSERT INTO [dbo].[Monthly]([MonthlyId], [Month]) VALUES (5 , 5 );
INSERT INTO [dbo].[Monthly]([MonthlyId], [Month]) VALUES (6 , 6 );
INSERT INTO [dbo].[Monthly]([MonthlyId], [Month]) VALUES (7 , 7 );
INSERT INTO [dbo].[Monthly]([MonthlyId], [Month]) VALUES (8 , 8 );
INSERT INTO [dbo].[Monthly]([MonthlyId], [Month]) VALUES (9 , 9 );
INSERT INTO [dbo].[Monthly]([MonthlyId], [Month]) VALUES (10, 10);
INSERT INTO [dbo].[Monthly]([MonthlyId], [Month]) VALUES (11, 11);
INSERT INTO [dbo].[Monthly]([MonthlyId], [Month]) VALUES (12, 12);
END