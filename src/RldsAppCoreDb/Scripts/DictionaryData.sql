-- Role table --

if not exists(select * from dbo.Role where RoleName = 'User')
insert into dbo.Role(RoleName) values(N'User');

if not exists(select * from dbo.Role where RoleName = 'SuperUser')
insert into dbo.Role(RoleName) values(N'SuperUser');

if not exists(select * from dbo.Role where RoleName = 'Admin')
insert into dbo.Role(RoleName) values(N'Admin');


-- State Table --


if not exists(select * from dbo.TransactionState where Name = 'Not Started') insert into dbo.TransactionState(Name, Ordinal) values(N'Not Started', 0);

if not exists(select * from dbo.TransactionState where Name = 'In Progress') insert into dbo.TransactionState(Name, Ordinal) values(N'In Progress', 0);

if not exists(select * from dbo.TransactionState where Name = 'Completed') insert into dbo.TransactionState(Name, Ordinal) values(N'Completed', 0);


