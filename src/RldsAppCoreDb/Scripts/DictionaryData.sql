-- Role table --

if not exists(select * from dbo.Role where RoleName = 'User')
insert into dbo.Role(RoleName) values(N'User');

if not exists(select * from dbo.Role where RoleName = 'SuperUser')
insert into dbo.Role(RoleName) values(N'SuperUser');

if not exists(select * from dbo.Role where RoleName = 'Admin')
insert into dbo.Role(RoleName) values(N'Admin');


-- State Table --


if not exists(select * from dbo.TransactionStatus where Name = 'PLANNED') insert into dbo.TransactionStatus(Name, Ordinal) values(N'PLANNED', 0);

if not exists(select * from dbo.TransactionStatus where Name = 'AWAITING') insert into dbo.TransactionStatus(Name, Ordinal) values(N'AWAITING', 0);

if not exists(select * from dbo.TransactionStatus where Name = 'PAID') insert into dbo.TransactionStatus(Name, Ordinal) values(N'PAID', 0);

if not exists(select * from dbo.TransactionStatus where Name = 'OUTDATED') insert into dbo.TransactionStatus(Name, Ordinal) values(N'OUTDATED', 0);

