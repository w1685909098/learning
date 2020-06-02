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

--用户资料，新建用户资料（Profile）表，和User形成1:1关联（有无约束？）。用SQL语句演示：
--新建一个填写了用户资料的注册用户
CREATE TABLE [Profile](
    Id INT IDENTITY NOT NULL 
    CONSTRAINT PK_Profile_User PRIMARY KEY(Id),
    IsMale BIT NOT NULL,
    Birthday DATETIME ,
    SelfDescription NVARCHAR(MAX) ,
    [UserId] INT NOT NULL
    CONSTRAINT FK_Profile_User_UserId FOREIGN KEY([UserId]) REFERENCES [User](Id)
);
ALTER TABLE PROFILE
ADD CONSTRAINT UQ_Profile_UserId UNIQUE(UserId)
SELECT * FROM Profile;
SELECT * FROM [User];
--INSERT Profile(IsMale,Birthday,SelfDescription,UserId)
--        VALUES(1,'2020/2/2',N'11',1);
--INSERT Profile(IsMale,Birthday,SelfDescription,UserId)
--        VALUES(1,'2020/3/3',N'33',3);
--INSERT Profile(IsMale,Birthday,SelfDescription,UserId)
--        VALUES(1,'2020/4/4',N'44',4);
--INSERT Profile(IsMale,Birthday,SelfDescription,UserId)
--        VALUES(1,'2020/5/5',N'55',5);
--INSERT Profile(IsMale,Birthday,SelfDescription,UserId)
--        VALUES(1,'2020/6/6',N'66',6);
--INSERT Profile(IsMale,Birthday,SelfDescription,UserId)
--        VALUES(1,'2020/7/7',N'77',7);
--INSERT Profile(IsMale,Birthday,SelfDescription,UserId)
--        VALUES(1,'2020/2/2',N'22',2);
GO
--通过Id查找获得某注册用户及其用户资料
SELECT * FROM Profile WHERE UserId=2;
--删除某个Id的注册用户
--user表的ID为  profile表 userID列的外键约束  无法直接删除
--先删除profile的外键约束  或者将userID更改为其他值
DELETE Profile WHERE UserId=2;
DELETE [User] WHERE Id=2;
--帮帮点说明：新建Credit表，可以记录用户的每一次积分获得过程，
--即：某个用户，在某个时间，因为某某原因，获得若干积分
CREATE TABLE Credit(
    Id INT IDENTITY NOT NULL 
    CONSTRAINT PK_Credit_Id PRIMARY KEY(Id),
    UserId INT NOT NULL
    CONSTRAINT UQ_Credit_UserId UNIQUE(UserId)
    CONSTRAINT FK_Credit_User_UserId FOREIGN KEY(UserId) REFERENCES [User](Id),
    DateTime DATETIME NOT NULL,
    Reason NVARCHAR(MAX) NOT NULL,
    Gain INT NOT NULL 
);
--发布求助，在Problem和User之间建立1:n关联（含约束）。用SQL语句演示：
--某用户发布一篇求助，
--1:n关联   主外键约束   n为主键  1为外键约束
ALTER TABLE PROBLEM
ADD UserId INT
CONSTRAINT FK_Problem_User_UserId FOREIGN KEY(UserId) REFERENCES [User](Id);
ALTER TABLE PROBLEM
ALTER COLUMN UserId INT NOT NULL;
SELECT * FROM Problem;
SELECT * FROM [User];
--将该求助的作者改成另外一个用户
UPDATE Problem SET UserId=8
WHERE Id=14;
--删除该用户
INSERT [User](UserName,Password) VALUES(N'8',N'8');
--先修改被引用的外键约束
UPDATE Problem SET UserId=5 WHERE Id=14;
DELETE [User] WHERE Id=8;
--求助列表：新建Keyword表，和Problem形成n:n关联（含约束）。用SQL语句演示：
--查询获得：某求助使用了多少关键字，某关键字被多少求助使用
CREATE TABLE KeywordToProblem(
    KeywordId INT NOT NULL CONSTRAINT FK_KeywordToProblem_Keyword_KeywordId
        FOREIGN KEY(KeywordId) REFERENCES Keyword(Id),
    ProblemId INT NOT NULL CONSTRAINT FK_KeywordToProblem_Problem_ProblemId
        FOREIGN KEY(ProblemId) REFERENCES Problem(Id),
)
SELECT * FROM  Keyword;
SELECT * FROM KeywordToProblem;
SELECT * FROM Problem;
--INSERT Keyword(Name) VALUES(N'C#');
--INSERT Keyword(Name) VALUES(N'SQL');
--INSERT Keyword(Name) VALUES(N'Javascript');
--INSERT Keyword(Name) VALUES(N'ASP.NET');
--INSERT Keyword(Name) VALUES(N'HTML');
--INSERT KeywordToProblem(KeywordId,ProblemId) VALUES(40,8);
--INSERT KeywordToProblem(KeywordId,ProblemId) VALUES(45,8);
--INSERT KeywordToProblem(KeywordId,ProblemId) VALUES(50,8);
--INSERT KeywordToProblem(KeywordId,ProblemId) VALUES(60,8);
--INSERT KeywordToProblem(KeywordId,ProblemId) VALUES(40,9);
--INSERT KeywordToProblem(KeywordId,ProblemId) VALUES(40,10);
--INSERT KeywordToProblem(KeywordId,ProblemId) VALUES(40,11);
--INSERT KeywordToProblem(KeywordId,ProblemId) VALUES(40,12);
--INSERT KeywordToProblem(KeywordId,ProblemId) VALUES(50,13);
--INSERT KeywordToProblem(KeywordId,ProblemId) VALUES(60,13);
--INSERT KeywordToProblem(KeywordId,ProblemId) VALUES(45,14);
--INSERT KeywordToProblem(KeywordId,ProblemId) VALUES(50,14);
--INSERT KeywordToProblem(KeywordId,ProblemId) VALUES(55,8);
--INSERT KeywordToProblem(KeywordId,ProblemId) VALUES(55,11);
--INSERT KeywordToProblem(KeywordId,ProblemId) VALUES(55,13);
--INSERT KeywordToProblem(KeywordId,ProblemId) VALUES(45,12);
SELECT COUNT(*) FROM KeywordToProblem GROUP BY KeywordId;
SELECT COUNT(*) FROM KeywordToProblem GROUP BY ProblemId;

GO
--发布了一个使用了若干个关键字的求助
INSERT KeywordToProblem(KeywordId,ProblemId) VALUES(55,13);
INSERT KeywordToProblem(KeywordId,ProblemId) VALUES(45,13);
INSERT KeywordToProblem(KeywordId,ProblemId) VALUES(50,13);
INSERT KeywordToProblem(KeywordId,ProblemId) VALUES(60,13);

--该求助不再使用某个关键字
DELETE KeywordToProblem WHERE KeywordId=45 AND ProblemId=13;
--删除该求助
SELECT * FROM Problem;
SELECT * FROM KeywordToProblem;
BEGIN TRAN
DELETE KeywordToProblem WHERE KeywordId=40 AND ProblemId=9;
--UPDATE KeywordToProblem SET KeywordId = 45 WHERE ProblemId=9
DELETE Problem WHERE ID=9;
PRINT @@TRANCOUNT
ROLLBACK
--删除某关键字
BEGIN TRAN
DELETE KeywordToProblem WHERE KeywordId=60 AND ProblemId=8;
--UPDATE KeywordToProblem SET KeywordId = 45 WHERE ProblemId=9
DELETE Keyword WHERE ID=60;
ROLLBACK
--以Problem中的数据为基础，使用SELECT INTO，新建一个Author和Reward都没有NULL值的新表：
--NewProblem （把原Problem里Author或Reward为NULL值的数据删掉）
SELECT * FROM Problem;
SELECT * FROM NewProblem;
SELECT * INTO NewProblem FROM Problem
WHERE Content IS NOT NULL AND Reward IS NOT NULL;
--使用INSERT SELECT, 将Problem中Reward为NULL的行再次插入到NewProblem中
INSERT NewProblem  SELECT Content,NeedRemoteHelp,Reward,PublishDateTime,
Title,Author,UserId FROM Problem WHERE Reward IS NULL OR Content IS NULL;

--使用OVER，统计出求助里每个Author悬赏值的平均值、最大值和最小值，
--然后用新表ProblemStatus存放上述数据
SELECT * FROM Problem;
SELECT Author,AVG(Reward) AVG,MAX(Reward) MAX,
MIN(Reward) MIN FROM Problem GROUP BY Author
--使用CASE.WHEN，颠倒Problem中的NeedRemote（以前是1的，现在变成0；以前是0的，现在变成1）
SELECT * FROM Problem;
UPDATE Problem SET NeedRemoteHelp=CASE NeedRemoteHelp
WHEN 1 THEN 0  ELSE 1 END;

--使用CASE...WHEN，用一条SQL语句，完成SQL入门-7：函数中第4题第3小题

--找到从未成为邀请人的用户（当心NULL值）
SELECT * FROM [User];
ALTER TABLE [User]  
--ADD InvitedBy INT 
 ALTER COLUMN InvitedBy INT  NOT NULL
 --DROP COLUMN UserId
 --DROP CONSTRAINT FK_User_User_UserId
--CONSTRAINT FK_User_User_UserId FOREIGN KEY(InvitedBy) REFERENCES [User](Id);
SELECT * FROM [User] WHERE Id  NOT IN (
SELECT InvitedBy FROM [User]);
--查出这些文章：其作者总共只发布过这一篇文章
SELECT * FROM Problem;
SELECT * FROM Problem WHERE Author NOT IN (
SELECT Author FROM Problem GROUP BY Author
HAVING COUNT(Title)>1)
--为求助添加一个发布时间（PublishTime），查找每个作者最近发布的一篇求助
SELECT * FROM Problem OP WHERE PublishDateTime=(
SELECT MAX(PublishDateTime) FROM Problem  IP
WHERE OP.Author=IP.Author);
SELECT * FROM Problem ORDER BY Author,PublishDateTime;
--查出每个作者悬赏最多的3篇求助
SELECT  * FROM Problem WHERE  Id IN(
SELECT TOP 3 Reward,Id FROM Problem OP WHERE Reward=(
SELECT Reward FROM Problem IP
WHERE OP.Author=IP.Author) )


SELECT * FROM (
SELECT ROW_NUMBER() OVER(PARTITION BY Author ORDER BY Reward DESC) GID,
* FROM Problem) PP
WHERE PP.GID BETWEEN 1 AND 3

--SELECT * FROM Problem OP WHERE  Reward IN (
--SELECT TOP 3 Reward FROM Problem  IP
--WHERE OP.Author=IP.Author ORDER BY Reward DESC
--)

--删除悬赏相同的求助（只要相同的全部删除一个不留）
DELETE Problem WHERE Id=(
SELECT Id FROM Problem WHERE Id NOT IN(
SELECT MAX(Id)  Reward FROM Problem GROUP BY Reward)   )
--删除每个作者悬赏最低的求助

BEGIN TRANSACTION
DELETE Problem WHERE Id  IN (
SELECT Id FROM Problem OP WHERE Reward=
(SELECT MIN(Reward) FROM Problem IP
WHERE OP.Author=IP.Author))
ROLLBACK

--查出每一篇求助的悬赏都大于5个帮帮币的作者
SELECT  MIN(Reward),Author FROM Problem GROUP BY Author HAVING MIN(Reward)>5
 
--分别使用派生表和CTE，查询求助表（表中只有一列整体的发布时间，没有年月的列），以获得：
SELECT * FROM Problem
--一起帮每月各发布了求助多少篇
SELECT YearPublish,MonthPublish,COUNT(*) FROM (
SELECT YEAR(PublishDateTime) YearPublish,MONTH(PublishDateTime) MonthPublish,
*  FROM Problem 
) AS DP
GROUP BY YearPublish,MonthPublish;

WITH MonthPublished  AS(
SELECT  YEAR(PublishDateTime) YearPublish,MONTH(PublishDateTime) MonthPublish,
* FROM Problem
)
SELECT YearPublish,MonthPublish,COUNT(*) FROM MonthPublished
GROUP BY YearPublish,MonthPublish;

SELECT  YearPublish,MonthPublish,COUNT(GID) FROM (
SELECT ROW_NUMBER() OVER(PARTITION BY YEAR(PublishDateTime)
,MONTH(PublishDateTime)) AS GID,YEAR(PublishDateTime) YearPublish,
MONTH(PublishDateTime) MonthPublish,* FROM Problem)TP
GROUP BY TP.YearPublish,TP.MonthPublish
--每月发布的求助中，悬赏最多的3篇
SELECT   * FROM ( SELECT ROW_NUMBER() OVER(PARTITION BY YEAR(PublishDateTime),
MONTH(PublishDateTime)ORDER BY Reward DESC) AS GID,YEAR(PublishDateTime) YearPublish,
MONTH(PublishDateTime) MonthPublish,* FROM Problem)TP
WHERE TP.GID BETWEEN 1 AND 3;


--每个作者，每月发布的，悬赏最多的3篇
SELECT * FROM (
SELECT ROW_NUMBER() OVER(PARTITION BY YEAR(PublishDateTime),MONTH(PublishDateTime),
Author ORDER BY Reward DESC) AS GID,YEAR(PublishDateTime) YearPublish,
MONTH(PublishDateTime) MonthPublish ,* FROM Problem) TP
WHERE GID BETWEEN 1 AND 3;

--分别按发布时间和悬赏数量进行分页查询的结果
SELECT TOP 3 * FROM Problem  WHERE Id NOT IN (
SELECT TOP 3 Id  FROM Problem ORDER BY PublishDateTime DESC)
ORDER BY PublishDateTime DESC

SELECT * FROM (
SELECT ROW_NUMBER() OVER(ORDER BY PublishDateTime DESC) AS GID,* FROM Problem) AS TP
WHERE GID BETWEEN 4 AND 6;

SELECT * FROM Problem ORDER BY PublishDateTime DESC
OFFSET 3 ROWS FETCH NEXT 3 ROWS ONLY;

SELECT TOP 3* FROM Problem WHERE Id NOT IN (
SELECT TOP 3 Id FROM Problem ORDER BY Reward DESC)
ORDER BY Reward DESC;

SELECT * FROM (
SELECT ROW_NUMBER() OVER(ORDER BY Reward DESC) AS GID ,* FROM Problem ) TP
WHERE GID BETWEEN 4 AND 6

SELECT * FROM Problem ORDER BY  Reward DESC
OFFSET 3 ROWS FETCH NEXT 3 ROWS ONLY;

 
--创建求助的应答表 Response(Id, Content, AuthorId, ProblemId, CreateTime)
CREATE TABLE Response(
Id INT IDENTITY  CONSTRAINT PK_Response_Id PRIMARY KEY(Id),
Content NVARCHAR(MAX),-- NOT NULL,
AuthorId INT NOT NULL 
CONSTRAINT FK_Response_User_AuthorId FOREIGN KEY REFERENCES [User](Id),
ProblemId INT NOT NULL
CONSTRAINT FK_Response_Prolem_ProblemId FOREIGN KEY REFERENCES Problem(Id),
CreateTime DATETIME
)
--然后生成一个视图 VResponse(ResponseId, Content, ResponseAuthorId，
--ReponseAuthorName,ProblemId, ProblemAuthorName, ProblemTitle, CreateTime)，要求该视图：
--能展示应答作者的用户名、应答对应求助的标题和作者用户名 （JOIN）
 GO
-- CREATE VIEW  VResponse(ResponseId, Content, ResponseAuthorId,
--ReponseAuthorName,ProblemId, ProblemAuthorName, ProblemTitle, CreateTime)
--WITH ENCRYPTION,SCHEMABINDING
--AS
--SELECT R.Id,R.Content,U.Id,U.UserName,P.Id,PU.UserName,P.Title,R.CreateTime
--FROM dbo.Response R JOIN dbo.[User] U ON R.AuthorId=U.Id
--JOIN dbo.Problem P ON R.ProblemId=P.Id
--JOIN dbo.[User] PU ON P.UserId=PU.Id
--WHERE R.CreateTime>'2020/5/27'
--WITH CHECK OPTION
SELECT * FROM VResponse
--只显示应答时间在2020年5月27日之后的数据 （JOIN）
--where column>
--已被加密
--with encryption
--保证其使用的基表结构无法更改
--with schemabinding
--演示：在VResponse中插入一条数据（注意业务逻辑正确性），却不能在视图中显示

--修改VResponse，让其能避免上述情形
--with check option
--创建视图VProblemKeyword(ProblemId, ProblemTitle, 
--ProblemReward, KeywordAmount)，要求该视图：
SELECT * FROM Problem
SELECT * FROM KeywordToProblem;
SELECT * FROM Keyword;
GO
--ALTER VIEW VProblemKeyword(ProblemId, ProblemTitle, 
--ProblemReward, KeywordAmount)
--WITH SCHEMABINDING
--AS 
--SELECT P.Id,P.Title,P.Reward,COUNT_BIG(*)
--FROM dbo.KeywordToProblem KP 
--JOIN dbo.Problem P ON KP.ProblemId=P.Id
--JOIN dbo.Keyword K ON KP.KeywordId=K.Id
--GROUP BY P.Id,P.Title,P.Reward
SELECT * FROM VProblemKeyword
--能反映求助的标题、使用关键字数量和悬赏

--在ProblemId上有一个唯一聚集索引
CREATE UNIQUE CLUSTERED INDEX IX_VProblemKeyword_ProblemId ON VProblemKeyword(ProblemId)
--在ProblemReward上有一个非聚集索引
CREATE    INDEX IX_VProblemKeyword_ProblemReward ON VProblemKeyword(ProblemReward)
--在基表中插入/删除数据，观察VProblemKeyword是否相应的发生变化

--联表查出求助的标题和作者用户名
SELECT P.Id,P.Title,U.UserName  FROM Problem P JOIN [User] U ON P.UserId=U.Id

--查找并删除从未发布过求助的用户
SELECT * FROM [User] U LEFT JOIN Problem P ON U.Id=P.UserId WHERE P.Title IS NULL

--用一句SELECT显示出用户和他的邀请人用户名
SELECT U.UserName,U2.UserName FROM [User] U LEFT JOIN [User] U2 ON U.InvitedBy=U2.Id

--17bang的关键字有“一级”“二级”和其他“普通（三）级”的区别：
--请在表Keyword中添加一个字段，记录这种关系
SELECT * FROM Keyword;
EXECUTE sp_rename 'dbo.Keyword.Used','Upper','column'

--然后用一个SELECT语句查出所有普通关键字的上一级、以及上上一级的关键字名称，比如：
SELECT L1.Name   ,L2.Name 上一级,L3.Name 上上一级
FROM Keyword L1 LEFT JOIN Keyword L2 ON L1.Upper=L2.ID
LEFT JOIN Keyword L3 ON L2.Upper=L3.ID

--17bang中除了求助（Problem），还有意见建议（Suggest）和文章（Article），
--他们都包含Title、Content、PublishTime和Auhthor四个字段，但是：
--建议和文章没有悬赏（Reward）
--建议多一个类型：Kind NVARCHAR(20)）
--文章多一个分类：Category INT）
--请按上述描述建表。
CREATE TABLE Suggset(
Id INT IDENTITY CONSTRAINT PK_Suggest_Id PRIMARY KEY(Id),
Title NVARCHAR(MAX),
Content NVARCHAR(MAX),
Author NVARCHAR(MAX) NOT NULL,
AuthorId INT  NOT NULL 
CONSTRAINT FK_Suggest_User_AuthorId FOREIGN KEY REFERENCES [User](Id),
PublishTime DATETIME,
Kind NVARCHAR(20) ,
)
CREATE TABLE Article(
Id INT IDENTITY CONSTRAINT PK_Article_Id PRIMARY KEY(Id),
Title NVARCHAR(MAX),
Content NVARCHAR(MAX),
Author NVARCHAR(MAX) NOT NULL,
AuthorId INT  NOT NULL 
CONSTRAINT FK_Article_User_AuthorId FOREIGN KEY REFERENCES [User](Id),
PublishTime DATETIME,
Category INT,
)
--用一个SQL语句显示某用户发表的求助、建议和文章的Title、Content，并按PublishTime降序排列
SELECT N'Problem',Author,Title,Content,PublishDateTime
FROM Problem  UNION SELECT N'Suggest',Author,Title,Content,PublishTime FROM Suggset UNION
SELECT N'Article',Author,Title,Content,PublishTime FROM Article
ORDER BY Author,PublishDateTime
--用户（Reigister）发布一篇悬赏币若干的求助（Problem），他的帮帮币（BMoney）也会相应减少，
--但他的帮帮币总额不能少于0分：请综合使用TRY...CATCH和事务完成上述需求。
SELECT * FROM Problem
SELECT * FROM [User]
ALTER TABLE [User]
--ADD BMoney INT
ADD CONSTRAINT CK_User_BMoney CHECK(BMoney>0)
BEGIN TRY
    BEGIN TRANSACTION
    INSERT Problem VALUES(N'TRANSACTION',1,23,'2020/6/2',N'11',N'11',1)
    UPDATE [User] SET BMoney -=23 WHERE Id=1;
    COMMIT
END TRY
BEGIN CATCH
    ROLLBACK
END CATCH

--编写存储过程模拟“一起帮用户注册”的过程，包含以下逻辑：
--检查用户名是否重复。如果重复，返回错误代码：1
--检查用户名密码是否符合“长度不小于4位”的要求。如果不符合，返回错误代码：2
--如果有邀请人：
--检查邀请人是否存在，如果不存在，返回错误代码：10
--检查邀请码是否正确，如果邀请码不正确，返回错误代码：11
--将用户名、密码和邀请人存入数据库（Register）
--给邀请人增加10个帮帮点积分
--通知邀请人（在Message表中生成一条数据）某人使用了他作为邀请人。
GO
CREATE PROCEDURE Register
@UserName NVARCHAR(10),
@Password NVARCHAR(10),
@InviterName NVARCHAR(10),
@InviterCode NVARCHAR(10),
@ErrorTip INT OUTPUT
AS
SET NOCOUNT ON
    IF LEN(@Password)<=4 OR LEN(@UserName)<=4 BEGIN SET @ErrorTip=2  END
    ELSE IF ( EXISTS  (SELECT * FROM [User] WHERE UserName=@UserName)) BEGIN SET @ErrorTip=1 END
    ELSE IF (EXISTS (SELECT @InviterName FROM [User])) BEGIN SET @ErrorTip=10 END
    ELSE  
    BEGIN
    DECLARE @Code INT =(SELECT Id FROM [User] WHERE UserName=@InviterName)
    END
    IF @Code IS NULL SET @ErrorTip=10
    ELSE IF @InviterCode<>@Code SET @ErrorTip=11
    ELSE
    BEGIN TRY
        BEGIN TRANSACTION
        INSERT [User] (UserName,Password,InvitedBy) 
                VALUES(@UserName,@Password,@InviterCode)
        UPDATE [User] SET BMoney +=10 WHERE UserName=@UserName;
        INSERT Message(FromUser,ToUser,Content)
     VALUES (@UserName,@InviterName,@UserName+N'某人使用了'+@InviterName+N'作为邀请人')
        COMMIT
    END TRY
    BEGIN CATCH
        ROLLBACK
    END CATCH
SET NOCOUNT OFF 

CREATE TABLE Message(
Id INT IDENTITY CONSTRAINT PK_Message_Id PRIMARY KEY(Id), 
FromUser NVARCHAR(MAX),
ToUser NVARCHAR(MAX), 
UrgentLevel INT,
Kind NVARCHAR(MAX), 
HasRead BIT, 
IsDelete BIT,
Content NVARCHAR(MAX)
)

--确保Problem有“发布时间（PublishTime）”和
--“最后更新时间（LatestUpdateTime）”两列，创建触发器实现：
--更新一条数据，自动将当前时间计入该行数据的LatestUpdateTime
--插入一条数据，自动将当前时间计入该行数据的PublishTime（提示：INSERTED伪表）

SELECT * FROM Problem
ALTER TABLE Problem
ADD LatestUpdateTime DATETIME 
UPDATE Problem SET   LatestUpdateTime=GETDATE()

GO
CREATE TRIGGER  UpdateTime ON Problem
AFTER INSERT
AS  
UPDATE Problem SET PublishDateTime=GETDATE() WHERE Id=@@IDENTITY

INSERT Problem (Content,NeedRemoteHelp,Reward,Title,Author,UserId)
        VALUES(N'INSERT',N'1',11,N'INSERT',N'1',1)

GO
CREATE TRIGGER  UpdateLastedTime ON Problem
AFTER UPDATE
AS  
UPDATE Problem SET LatestUpdateTime=GETDATE() WHERE Id=@@IDENTITY

UPDATE Problem SET Reward =111 WHERE Id=20
