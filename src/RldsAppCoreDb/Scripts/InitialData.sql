declare 
	@projectId int,
	@userId int,
	@statusId int,
	@taskId int

	/* Defalut Values */
if not exists (select * from [User] where Login = 'Piotr' )
	insert into [dbo].[User] ([Login], [Password], [Firstname], [Lastname],[Email],[ts],[UserId])
		values(N'LogPiotr', N'qwerty',N',Piotr',N'Zubu',N'email@test.com')

if not exists (select * from [User] where Login = 'Mariusz' )
	insert into [dbo].[User] ([Login], [Password], [Firstname], [Lastname],[Email],[ts],[UserId])
		values(N'LogMariusz', N'password',N',Mariusz',N'Chochol',N'email@test.com')

if not exists (select * from [User] where Login = 'Jon' )
	insert into [dbo].[User] ([Login], [Password], [Firstname], [Lastname],[Email],[ts],[UserId])
		values(N'LogJon', N'qwerty',N',Jon',N'Jonas',N'email@test.com')

if not exists (select * from [User] where Login = 'Alan' )
	insert into [dbo].[User] ([Login], [Password], [Firstname], [Lastname],[Email],[ts],[UserId])
		values(N'LogAlan', N'qwerty',N',Alan',N'Zubu',N'email@test.com')

if not exists (select * from [User] where Login = 'Konrad' )
	insert into [dbo].[User] ([Login], [Password], [Firstname], [Lastname],[Email],[ts],[UserId])
		values(N'LogKonrad', N'qwerty',N',Konrad',N'Sladko',N'email@test.com')

if not exists (select * from [User] where Login = 'Damian' )
	insert into [dbo].[User] ([Login], [Password], [Firstname], [Lastname],[Email],[ts],[UserId])
		values(N'LogDamian', N'qwerty',N',Damian',N'Dam',N'email@test.com')

if not exists (select * from [User] where Login = 'Patryk' )
	insert into [dbo].[User] ([Login], [Password], [Firstname], [Lastname],[Email],[ts],[UserId])
		values(N'LogPatryk', N'qwerty',N',Patryk',N'Zubu',N'email@test.com')


/* Roles */

if not exists (select * from [UserRole] where UserId = 1)
begin
	insert into [dbo].[UserRole] ( [UserId], [RoleId]) 
		values ( 1, 1)
			insert into [dbo].[UserRole] ( [UserId], [RoleId]) 
		values ( 1, 2)
			insert into [dbo].[UserRole] ( [UserId], [RoleId]) 
		values ( 1, 3)
end

if not exists (select * from [UserRole] where UserId = 2)
begin
	insert into [dbo].[UserRole] ( [UserId], [RoleId]) 
		values ( 2, 1)
			insert into [dbo].[UserRole] ( [UserId], [RoleId]) 
		values ( 2, 2)
			insert into [dbo].[UserRole] ( [UserId], [RoleId]) 
		values ( 2, 3)
end

if not exists (select * from [UserRole] where UserId = 3)
begin
	insert into [dbo].[UserRole] ( [UserId], [RoleId]) 
		values ( 3, 1)
			insert into [dbo].[UserRole] ( [UserId], [RoleId]) 
		values ( 3, 2)
			insert into [dbo].[UserRole] ( [UserId], [RoleId]) 
		values ( 3, 3)
end

if not exists (select * from [UserRole] where UserId = 3)
begin
	insert into [dbo].[UserRole] ( [UserId], [RoleId]) 
		values ( 3, 1)
			insert into [dbo].[UserRole] ( [UserId], [RoleId]) 
		values ( 3, 2)
			insert into [dbo].[UserRole] ( [UserId], [RoleId]) 
		values ( 3, 3)
end

if not exists (select * from [UserRole] where UserId = 4)
begin
	insert into [dbo].[UserRole] ( [UserId], [RoleId]) 
		values ( 4, 1)
			insert into [dbo].[UserRole] ( [UserId], [RoleId]) 
		values ( 4, 2)
			insert into [dbo].[UserRole] ( [UserId], [RoleId]) 
		values ( 4, 3)
end

if not exists (select * from [UserRole] where UserId = 5)
begin
	insert into [dbo].[UserRole] ( [UserId], [RoleId]) 
		values ( 5, 1)
			insert into [dbo].[UserRole] ( [UserId], [RoleId]) 
		values ( 5, 2)
			insert into [dbo].[UserRole] ( [UserId], [RoleId]) 
		values ( 5, 3)
end

if not exists (select * from [UserRole] where UserId = 6)
begin
	insert into [dbo].[UserRole] ( [UserId], [RoleId]) 
		values ( 6, 1)
			insert into [dbo].[UserRole] ( [UserId], [RoleId]) 
		values ( 6, 2)
			insert into [dbo].[UserRole] ( [UserId], [RoleId]) 
		values ( 6, 3)
end

if not exists (select * from [UserRole] where UserId = 7)
begin
	insert into [dbo].[UserRole] ( [UserId], [RoleId]) 
		values ( 7, 1)
			insert into [dbo].[UserRole] ( [UserId], [RoleId]) 
		values ( 7, 2)
			insert into [dbo].[UserRole] ( [UserId], [RoleId]) 
		values ( 7, 3)
end