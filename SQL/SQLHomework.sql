--1新建一个数据库：17bang

--CREATE DATABASE [17bang]

--2建立表User：包含字段UserName（用户名），Password（密码）

--CREATE TABLE [User]
--(
--[UserName] NVARCHAR(10) NOT NULL,
--[Password] NVARCHAR(18) NOT NULL,
--)

--建立表Problem，包含：
--Id，主键，自增
--字段Title（标题），不能为空
--Content（正文），不能为空
--NeedRemoteHelp（需要远程求助），默认为需要，
--Reward（悬赏），
--PublishDateTime（发布时间）……
CREATE TABLE [Problem]
(
[Id] INT IDENTITY NOT NULL
CONSTRAINT PK_Problem_Id PRIMARY KEY(Id),
[Title] NTEXT ,
[Content] NTEXT ,
[NeedRemoteHelp] BIT CONSTRAINT DF_Problem_NeedRemoteHelp DEFAULT 1,
Reward INT  NULL,
PublishDateTime DATETIME 
)

--在Problem表的基础上：
--删除Title列，再添加Title列
--将Content的类型更改为NTEXT或NVARCHAR(MAX)
--为NeedRemoteHelp添加NOT NULL约束，再删除NeedRemoteHelp上NOT NULL的约束
--添加自定义约束，让Reward不能小于10
--备份TProblem表，再用两种方式删除/恢复TProblem中所有数据
--删除TProblem表本身（含表结构和行数据）
ALTER TABLE Problem
DROP COLUMN Title
ALTER TABLE Problem
ADD Title NTEXT NOT NULL
ALTER TABLE Problem
ALTER COLUMN Content NVARCHAR(MAX)
ALTER TABLE Problem
ALTER COLUMN  NeedRemoteHelp BIT NOT NULL
ALTER TABLE Problem
ALTER COLUMN NeedRemoteHelp  BIT NULL
ALTER TABLE Problem
ADD CONSTRAINT CK_Problem_Reward CHECK(Reward>10)
BACKUP DATABASE [17bang] TO DISK='F://实践/数据库/T17bang.bak'
--BACKUP TABLE Problem TO DISK='F://实践/数据库/TProblem.bak'
--DROP DATABASE [17bang]
RESTORE DATABASE [17bang] FROM DISK='F://实践/数据库/T17bang.bak'
BEGIN TRANSACTION
--DROP TABLE Problem
DELETE Problem 
--TRUNCATE TABLE Problem
ROLLBACK

--在User表上的基础上：
--添加Id列，让Id成为主键
--添加约束，让UserName不能重复
--将所有User的Password改为：'1234'
ALTER TABLE [User]
ADD Id INT IDENTITY 
CONSTRAINT PK_User_Id PRIMARY KEY(Id)
ALTER TABLE [User]
ADD CONSTRAINT UQ_User_UserName UNIQUE(UserName)
UPDATE [User] SET Password=N'1234'

--新建Keyword表，要求带一个自增的主键Id，起始值为10，步长为5
CREATE TABLE Keyword
(
ID INT IDENTITY(10,5)
CONSTRAINT PK_Keyword_Id PRIMARY KEY(Id)
)

--在User表中：
--查找没有录入密码的用户
--删除用户名（UserName）中包含“管理员”或者“17bang”字样的用户
ALTER TABLE [User]
ALTER COLUMN Password NVARCHAR(18) NULL
INSERT [User] (UserName,Password) VALUES(N'11',N'11')
INSERT [User] (UserName,Password) VALUES(N'17bang ',N'')
INSERT [User] (UserName,Password) VALUES(N'管理员',N'22')
INSERT [User] (UserName,Password) VALUES(N'2317bang',N'33')
INSERT [User] (UserName,Password) VALUES(N'17bang456',N'')
INSERT [User] (UserName,Password) VALUES(N'管理员123',N'')
INSERT [User] (UserName) VALUES(N'管理员444')

SELECT * FROM [User]
SELECT * FROM [User] WHERE Password IS NULL
SELECT * FROM [User] 
WHERE UserName LIKE N'%17bang%' OR UserName LIKE N'%管理员%'

--在Problem表中：
--给所有悬赏（Reward）大于10的求助标题加前缀：【推荐】
--给所有悬赏大于20且发布时间（Created）在2019年10月10日之后的求助标题加前缀：【加急】
--删除所有标题以中括号【】开头（无论其中有什么内容）的求助
--查找Title中第5个起，字符不为“数据库”且包含了百分号（%）的求助
INSERT Problem (NeedRemoteHelp,Reward,PublishDateTime,Title) 
         VALUES(0,4,'2019/1/1',N'1111数据库11%')
INSERT Problem (Content,NeedRemoteHelp,Reward,PublishDateTime,Title) 
         VALUES(N'',1,14,'2020/1/1',N'234数据库11%')
INSERT Problem (Content,Reward,PublishDateTime,Title) 
         VALUES(N'245',30,'2020/12/1',N'1111数据库11%')
INSERT Problem (Content,NeedRemoteHelp,Reward,PublishDateTime,Title) 
         VALUES(N'124',0,20,'2019/8/1',N'11数据库11')
INSERT Problem (Content,NeedRemoteHelp,Reward,PublishDateTime,Title) 
         VALUES(N'564',0,10,'2020/10/1',N'2356数据库90%')
INSERT Problem (Content,NeedRemoteHelp,Reward,PublishDateTime,Title) 
         VALUES(N'334',0,40,'2019/10/1',N'45数据库11')
INSERT Problem (Content,NeedRemoteHelp,Reward,PublishDateTime,Title) 
         VALUES(N'1244',0,40,'2019/10/1',N'45数据库11%')

SELECT  * FROM [Problem] 
ALTER TABLE Problem
ALTER COLUMN Title NVARCHAR(MAX) NOT NULL
UPDATE Problem SET Title=N'【推荐】'+Title
WHERE Reward>10
UPDATE Problem SET Title=N'【加急】'+Title
WHERE Reward>20 AND PublishDateTime>'2019/10/10'
SELECT * FROM Problem
WHERE Title NOT LIKE N'____数据库%' AND Title LIKE N'%*%%' ESCAPE'*'
DELETE  FROM Problem WHERE Title LIKE N'【%】%'
BEGIN TRANSACTION
DELETE Problem
ROLLBACK

--在Keyword表中：
--找出所有被使用次数（Used）大于10小于50的关键字名称（Name）
--如果被使用次数（Used）小于等于0，或者是NULL值，或者大于100的，将其更新为1
--删除所有使用次数为奇数的Keyword
ALTER TABLE Keyword
ADD Name NVARCHAR(MAX) NOT NULL;
ALTER TABLE Keyword
ADD Used INT 
INSERT Keyword(Name,Used) VALUES(N'111',20)
INSERT Keyword(Name) VALUES(N'222')
INSERT Keyword(Name,Used) VALUES(N'333',0)
INSERT Keyword(Name,Used) VALUES(N'444',120)
INSERT Keyword(Name,Used) VALUES(N'111',10)
SELECT * FROM Keyword
SELECT * FROM Keyword WHERE Used>10 AND Used<50
SELECT Name FROM Keyword WHERE Used>10 AND Used<50
SELECT * FROM Keyword WHERE Used BETWEEN 11 AND 49
UPDATE Keyword SET Used=1
WHERE Used<=0 OR Used IS NULL OR Used >100
DELETE  FROM  Keyword WHERE Used%2=1
DELETE [Keyword] WHERE Used%2=1


--在Problem中插入不同作者（Author）不同悬赏（Reward）的若干条数据，以便能完成以下操作：
--查找出Author为“飞哥”的、Reward最多的3条求助
--所有求助，先按作者“分组”，然后在“分组”中按悬赏从大到小排序
--查找并统计出每个作者的：求助数量、悬赏总金额和平均值
--找出平均悬赏值少于10的作者并按平均值从小到大排序
ALTER TABLE Problem
 ADD Author NVARCHAR(10) 
 CONSTRAINT UQ_Keyword_Author UNIQUE(Author)
 DELETE Problem
 ALTER TABLE Problem
 --DROP CONSTRAINT UQ_Keyword_Author
 --ALTER COLUMN Author NVARCHAR(10) NOT NULL
 ADD CONSTRAINT UQ_Keyword_Author UNIQUE(Author)
 INSERT Problem(Content,Reward,PublishDateTime,Title,Author) 
 VALUES(N'123',14,'2020/2/4',N'ASADAS' ,N'FG')
 INSERT Problem(Content,NeedRemoteHelp,Reward,PublishDateTime,Title,Author) 
 VALUES(N'32424',0,34,'2020/2/6',N'SFSFE' ,N'FG')
  INSERT Problem(Content,NeedRemoteHelp,Reward,PublishDateTime,Title,Author) 
 VALUES(N'2424',1,77,'2020/7/4',N'SFAAD' ,N'FG')
 INSERT Problem(Content,Reward,PublishDateTime,Title,Author) 
 VALUES(N'234',32,'2020/3/4',N'SDFSEQ' ,N'FG')
 INSERT Problem(Content,Reward,PublishDateTime,Title,Author) 
 VALUES(N'524',56,'2020/6/4',N'HDDWE' ,N'XX')
 INSERT Problem(Content,Reward,PublishDateTime,Title,Author) 
 VALUES(N'565',65,'2020/2/9',N'GFDGD' ,N'ZZ')
 INSERT Problem(Content,Reward,PublishDateTime,Title,Author) 
 VALUES(N'7867',89,'2020/9/9',N'HTRF' ,N'ZZ')
SELECT * FROM Problem
SELECT TOP 3 * FROM Problem 
WHERE Author=N'FG' ORDER BY Reward DESC
SELECT Author,Reward FROM Problem ORDER BY Author , Reward DESC
SELECT Author,COUNT(*),SUM(Reward) SUM,AVG(Reward) AVG FROM Problem
GROUP BY Author
SELECT Author,COUNT(*),SUM(Reward) SUM,AVG(Reward) AVG FROM Problem
GROUP BY Author
HAVING AVG(Reward)>40
ORDER BY AVG 

--利用循环，打印如下所示的等腰三角形：
--   1
--  333
-- 55555
--7777777

DECLARE @I INT=1
WHILE @I<=7
BEGIN 
    PRINT SPACE((7-@I)/2)+REPLICATE(@I,@I)
    SET @I+=2
END
--定义一个函数GetBigger(INT a, INT b)，可以取a和b之间的更大的一个值
GO
--ALTER FUNCTION GetBigger(@A INT,@B INT )
--RETURNS INT
--AS
--BEGIN
--     IF @A>@B RETURN @A
--     ELSE RETURN @B
--     RETURN NULL
--END
GO
--CREATE FUNCTION GetBiggerMy(@A INT,@B INT )
--RETURNS INT
--AS
--BEGIN
--    DECLARE @MAX INT
--     IF @A>@B SET @MAX=@A 
--     ELSE SET @MAX= @B
--     RETURN @MAX
--END
PRINT dbo.GetBiggerMy(1,3)
PRINT dbo.GetBigger(1,3)

--创建一个单行表值函数GetLatestPublish(INT n)，返回最近发布的n篇求助
GO
--CREATE FUNCTION GetLatestPublish(@N INT )
--RETURNS TABLE
--RETURN SELECT TOP(@N) * FROM Problem ORDER BY PublishDateTime DESC

SELECT  * FROM Problem ORDER BY PublishDateTime DESC
SELECT * FROM GetLatestPublish(3)
--创建一个多行表值函数GetByReward(INT n, BIT asc)，
--如果asc为1，返回悬赏最少的n位同学；否则，返回悬赏最多的n位同学。
GO
--CREATE FUNCTION GetByReward(@N INT ,@ASC BIT)
--RETURNS @T TABLE(Id INT,Reward INT,Author NVARCHAR(10))
--BEGIN
--    IF @ASC=1 INSERT @T SELECT TOP(@N) Id,Reward,Author FROM Problem ORDER BY Reward ASC
--    ELSE INSERT @T SELECT TOP(@N) Id,Reward,Author FROM Problem ORDER BY Reward DESC
--    RETURN
--END
SELECT * FROM GetByReward(3,1)
SELECT * FROM Problem ORDER BY Reward ASC
SELECT * FROM GetByReward(3,0)
SELECT * FROM Problem ORDER BY Reward DESC
--在表TProblem中：
--找出所有周末发布的求助（添加CreateTime列，如果还没有的话）
--获取当前日期为星期几 DATEPART()
PRINT DATEPART(WEEKDAY,DATEADD(DAY,-3,GETDATE()))
SELECT * FROM Problem
WHERE DATEPART(WEEKDAY,PublishDateTime)=6 OR DATEPART(WEEKDAY,PublishDateTime)=7
--找出每个作者所有求助悬赏的平均值，精确到小数点后两位
SELECT AVG(ROUND(CONVERT(smallmoney,Reward),2)),Author  FROM Problem GROUP BY Author
--有一些标题以test、[test]后者Test-开头的求助，找到他们并把这些前缀都换成大写
UPDATE Problem SET  Title=UPPER(N'TEST')+SUBSTRING(Title,LEN(N'TEST')+1,100)
WHERE Title LIKE N'test%'
