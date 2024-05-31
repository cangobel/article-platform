USE appDatabase;

--CREATE TABLE UserPhotos(UserId VARCHAR(50), ImagePath VARCHAR(max))

--ALTER TABLE Articles ADD ArticleId INT PRIMARY KEY IDENTITY(0,1);

--ALTER TABLE Articles ALTER COLUMN Title INT NULL;
--ALTER TABLE Articles ALTER COLUMN Content INT NULL;

ALTER TABLE UserPhotos ADD PRIMARY KEY(UserId);
ALTER TABLE UserPhotos ALTER COLUMN ImagePath VARCHAR(max) NOT NULL;
ALTER TABLE UserPhotos ALTER COLUMN UserId VARCHAR(50) NOT NULL;

ALTER TABLE UserInfos ALTER COLUMN UserId VARCHAR(50) NOT NULL;

--ALTER TABLE Articles ALTER COLUMN UserId VARCHAR(50) NOT NULL;
--ALTER TABLE Articles ALTER COLUMN IsReleased BIT NOT NULL;

--ALTER TABLE Articles ALTER COLUMN Title VARCHAR(50) NULL;
--ALTER TABLE Articles ALTER COLUMN Content VARCHAR(max) NULL;

--ALTER TABLE TransitionTable ADD PRIMARY KEY (TableName);

--ALTER TABLE UserUnPublishedArticle ADD PRIMARY KEY (UserName);

--ALTER TABLE GlobalArticleId ADD PRIMARY KEY (ForTrackEFCore);

--ALTER TABLE GlobalArticleId DROP CONSTRAINT Id;

--ALTER TABLE GlobalArticleId ADD ForTrackEFCore INT;

--ALTER TABLE GlobalArticleId ALTER COLUMN ForTrackEFCore INT NULL;

--ALTER TABLE GlobalArticleId DROP COLUMN ForTrackEFCore;

--ALTER TABLE GlobalArticleId ADD ForEFCore INT DEFAULT 0 ;

--DROP TABLE GlobalArticleId

--Delete top(1) from TransitionTable where TransitionTable.ArticleId = 2
--SELECT * FROM GlobalArticleId
--ALTER TABLE Users DISABLE TRIGGER delete_user_tables;

--SELECT @@IDENTITY
--DELETE FROM Users WHERE userName = 'Hakan'

--SELECT * FROM Users
--DELETE FROM Users WHERE userName = 'Hakan'
----hangi user'ın delete edildiğini bulup ona ait olan bütün table'ları silicez.
--DECLARE @deletedUserName VARCHAR(20);
--SELECT  @deletedUserName = UserNames.UserName FROM Users INNER JOIN UserNames ON UserNames.UserName != Users.userName;

--SELECT @deletedUserName
----DELETE FROM Users WHERE Users.UserId = 1

--INSERT INTO dbo.UserNames VALUES('Hakan')

--INSERT dbo.Users VALUES (2, 'Hakan', 'abcde')

--CREATE TRIGGER [dbo].[delete_user_tables] ON [dbo].[Users]
--FOR DELETE
--AS
--	DECLARE @deletedUserName VARCHAR(20);
--	DECLARE @deleteAllUserTables NVARCHAR(max);

--	SELECT  @deletedUserName = UserNames.UserName FROM Users INNER JOIN UserNames ON UserNames.UserName != Users.userName;
--	SET @deleteAllUserTables = 'DROP TABLE' + @deletedUserName + 'Articles';

--	EXEC sp_executesql @deleteAllUserTables;
--GO

--ALTER TRIGGER [dbo].[delete_user_tables] ON [dbo].[Users]
--FOR DELETE
--AS
--	DECLARE @deletedUserName VARCHAR(20);
--	DECLARE @deleteAllUserTables NVARCHAR(max);

--	SELECT  @deletedUserName = UserNames.UserName FROM Users INNER JOIN UserNames ON UserNames.UserName != Users.userName;
--	SET @deleteAllUserTables = 'DROP TABLE ' + @deletedUserName + 'Articles';
--	DELETE FROM UserNames WHERE UserName = @deletedUserName;

--	EXEC sp_executesql @deleteAllUserTables;
--GO

--SELECT CONCAT(@lastUser,'Articles')

--SELECT * FROM INFORMATION_SCHEMA.ROUTINES

--CREATE TRIGGER [dbo].[create_table_after_insert_user] ON dbo.Users 
--FOR INSERT 
--AS 
--DECLARE @lastUser VARCHAR(20);
--DECLARE @createTable NVARCHAR(max);
--SELECT TOP 1 @lastUser = userName FROM dbo.Users ORDER BY UserId DESC

--SET @createTable = 'CREATE TABLE ' + @lastUser + 'Articles' +'(ArticleID INT PRIMARY KEY NOT NULL, 
--												 Title NVARCHAR(20) NOT NULL, Content NVARCHAR(max),
--												 ReleaseDate DATE NOT NULL)'

--EXEC sp_executesql @createTable
--GO

--ALTER TRIGGER [dbo].[create_table_after_insert_user] ON dbo.Users 
--FOR INSERT 
--AS 
--DECLARE @lastUser VARCHAR(20);
--DECLARE @createTable NVARCHAR(max);

--SELECT @lastUser = UserName FROM inserted

--SET @createTable = 'CREATE TABLE ' + @lastUser + 'Articles' + '(ArticleID INT PRIMARY KEY NOT NULL, 
--												  Title NVARCHAR(20), Content NVARCHAR(max), 
--												  ReleaseDate DATE, isReleased INT NOT NULL)'
--EXEC sp_executesql @createTable
--GO

--CREATE TRIGGER [dbo].[delete_user_tables] ON dbo.Users
--FOR DELETE
--AS
--DECLARE @deletedUser VARCHAR(20);
--DECLARE @deleteTables NVARCHAR(max);

--SELECT @deletedUser = UserName FROM deleted;

--SET @deleteTables = 'DROP TABLE ' + @deletedUser + 'Articles'

--EXEC sp_executesql @deleteTables
--GO

--CREATE TRIGGER [dbo].[transfer_user_data] ON dbo.TransitionTable
--FOR INSERT
--AS

--DECLARE @userTable VARCHAR(50);
--DECLARE @transferData NVARCHAR(max);

--SELECT @userTable = TableName FROM inserted;
--SET @transferData = 'INSERT INTO ' + @userTable + '(ArticleId, Title, Content, ReleasedDay, isReleased)' +
--												  'SELECT ArticleId, Title, Content, ReleasedDay, isReleased' + 
--												  'FROM inserted'

--EXEC sp_executesql @transferData
--GO
