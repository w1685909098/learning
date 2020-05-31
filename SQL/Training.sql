
CREATE TABLE Message
(
Id INT IDENTITY  NOT NULL,
FromUser NVARCHAR(10) NOT NULL,
ToUser NVARCHAR(10) NOT NULL, 
UrgentLevel NVARCHAR(MAX) NOT NULL, 
Kind NVARCHAR(MAX) NOT NULL,
HasRead BIT   DEFAULT 0 , 
IsDelete BIT   DEFAULT 0 ,
Content NVARCHAR(MAX) NOT NULL,
)
DROP TABLE Message
ALTER TABLE Message
--ALTER COLUMN Content NVARCHAR(MAX) NOT NULL 
ADD CONSTRAINT PK_Message_FromUser PRIMARY KEY(FromUser)
CREATE UNIQUE CLUSTERED INDEX IX_Message_ToUser ON Message(ToUser)
ALTER TABLE Message
ADD CONSTRAINT PK_Message_Id PRIMARY KEY(Id)

--利用循环，打印如下所示的等腰三角形：
--   1
--  333
-- 55555
--7777777
DECLARE @I INT=1
WHILE @I<9
BEGIN
PRINT  SPACE((7-@I)/2)+REPLICATE(@I,@I)  
SET @I+=2
END
--定义一个函数GetBigger(INT a, INT b)，可以取a和b之间的更大的一个值
--CREATE FUNCTION GetBigger(@A INT,@B INT) 
--RETURNS INT
--AS
--BEGIN
--DECLARE @Bigger INT
--IF @A>@B  SET @Bigger=@A
--ELSE SET @Bigger=@B
--RETURN @Bigger
--END
PRINT dbo.GetBigger(5,3)

SELECT * FROM Problem
--创建一个单行表值函数GetLatestPublish(INT n)，返回最近发布的n篇求助
--CREATE FUNCTION GetLatestPublish(@N INT )
--RETURNS TABLE
--RETURN SELECT TOP(@N) * FROM Problem ORDER BY PublishDateTime
 
SELECT * FROM GetLatestPublish(3) 
SELECT * FROM GetLatestPublish(3) ORDER BY PublishDateTime DESC

--创建一个多行表值函数GetByReward(INT n, BIT asc)，
--如果asc为1，返回悬赏最少的n位同学；否则，返回悬赏最多的n位同学。
--CREATE FUNCTION GetByReward(@N INT,@ASC BIT)
--RETURNS @T TABLE(Id int,Author NVARCHAR(10),Reward INT)
--BEGIN
--INSERT @T VALUES(@N,@ASC)
--IF @ASC=1 INSERT @T SELECT Id,Author,Reward FROM Problem ORDER BY Reward ASC
--ELSE INSERT @T SELECT Id,Author,Reward FROM Problem ORDER BY Reward DESC
--RETURN
--END
SELECT * FROM Problem
SELECT * FROM GetByReward(2,1)
DROP FUNCTION GetByReward

--在表TProblem中：
--找出所有周末发布的求助（添加CreateTime列，如果还没有的话）
--找出每个作者所有求助悬赏的平均值，精确到小数点后两位
--有一些标题以test、[test]后者Test-开头的求助，找到他们并把这些前缀都换成大写
PRINT GETDATE()
PRINT ROUND(2.0,2)
SELECT Author,ROUND(AVG(CONVERT(smallmoney,Reward)),2) 
FROM Problem GROUP BY Author
UPDATE Problem SET Title=UPPER(Title)
WHERE Title LIKE N'test%' OR Title LIKE N'[test]%'OR Title LIKE N'Test%'

--用户资料，新建用户资料（Profile）表，和User形成1:1关联（有无约束？）。用SQL语句演示：
--新建一个填写了用户资料的注册用户
CREATE TABLE [User]
(
    Id INT IDENTITY NOT NULL
    CONSTRAINT PK_User_Id PRIMARY KEY(Id),
    [Name] NVARCHAR(10) NOT NULL
    CONSTRAINT UQ_User_Name UNIQUE ([Name]),
    Password NVARCHAR(18) NOT NULL,
)
CREATE TABLE Profile
(
    Id INT NOT NULL
    CONSTRAINT PK_Profile_Id PRIMARY KEY(Id),
    Gender BIT ,
    Birthday DATETIME,
    Keywords NVARCHAR(MAX) NOT NULL,
    SelfDescription NVARCHAR(MAX)
)
ALTER TABLE Profile
ADD Id INT NOT NULL
CONSTRAINT PK_Profile_Id PRIMARY KEY(Id)
ALTER TABLE Profile
ADD UserId INT
CONSTRAINT FK_Profile_User_UserId FOREIGN KEY REFERENCES [User](Id);
--ALTER TABLE Profile
----DROP CONSTRAINT FK_Profile_User_UserId
--DROP COLUMN UserId
--DELETE Profile
--delete [User]
ALTER TABLE [User]
ADD ProfileId INT 
CONSTRAINT FK_User_Profile_ProfileId 
FOREIGN KEY(ProfileId) REFERENCES Profile(Id) 
ALTER TABLE [User]
ADD CONSTRAINT UQ_User_ProfileId UNIQUE (ProfileId)
SELECT * FROM [User];
SELECT * FROM Profile;
DELETE [User]

--INSERT [User] (Name,Password,ProfileId) VALUES(N'2',N'1',1)
--INSERT [User] (Name,Password,ProfileId) VALUES(N'3',N'3',2)
--INSERT [User] (Name,Password,ProfileId) VALUES(N'4',N'4',3)
--INSERT [User] (Name,Password,ProfileId) VALUES(N'5',N'5',4)
--INSERT [User] (Name,Password,ProfileId) VALUES(N'6',N'6',5)
--INSERT Profile(Id,Keywords) VALUES(1,N'AA')
--INSERT Profile(Id,Keywords) VALUES(2,N'BB')
--INSERT Profile(Id,Keywords) VALUES(3,N'CC')
--INSERT Profile(Id,Keywords) VALUES(4,N'DD')
--INSERT Profile(Id,Keywords) VALUES(5,N'EE')
GO
--通过Id查找获得某注册用户及其用户资料
SELECT * FROM [User];
SELECT * FROM Profile;
SELECT * FROM [User] WHERE Id=15;
SELECT * FROM Profile WHERE Id=
(SELECT ProfileId FROM [User] WHERE Id=15);
--删除某个Id的注册用户
DELETE [User] WHERE Id=4;
--帮帮点说明：新建Credit表，可以记录用户的每一次积分获得过程，
--即：某个用户，在某个时间，因为某某原因，获得若干积分
CREATE TABLE Credit
(
    Id INT NOT NULL
    CONSTRAINT PK_Credit_Id PRIMARY KEY(Id),
    Time DATETIME NOT NULL,
    [Reason] NVARCHAR(MAX) NOT NULL,
    Count INT NOT NULL,
)
--发布求助，在Problem和User之间建立1:n关联（含约束）。用SQL语句演示：
--某用户发布一篇求助，
SELECT * FROM [User];
SELECT * FROM Problem;
--在Problem表上添加user ID 外键约束
ALTER TABLE Problem
ADD UserId INT
CONSTRAINT FK_Problem_User_UserId 
FOREIGN KEY(UserId) REFERENCES [User](Id);
ALTER TABLE Problem
ALTER COLUMN UserId INT NOT NULL;
--在Problem表上添加user name 外键约束
ALTER TABLE Problem
ADD UserName NVARCHAR(10) 
CONSTRAINT FK_Problem_User_UserName
FOREIGN KEY (UserName) REFERENCES [User](Name);
ALTER TABLE Problem
ALTER COLUMN UserName NVARCHAR(10) NOT NULL;
--将该求助的作者改成另外一个用户
UPDATE Problem SET UserId=16
WHERE Id=1;
--删除该用户
DELETE Problem WHERE Id=34;
DELETE [User] WHERE Id=15;

--求助列表：新建Keyword表，和Problem形成n:n关联（含约束）。用SQL语句演示：
--查询获得：某求助使用了多少关键字，某关键字被多少求助使用
CREATE TABLE Keyword
(
    Id INT IDENTITY NOT NULL
    CONSTRAINT PK_Keyword_Id PRIMARY KEY(Id),
    Name NVARCHAR(MAX) NOT NULL,
)
SELECT * FROM Keyword
GO
--INSERT Keyword(Name) VALUES(N'C#');
--INSERT Keyword(Name) VALUES(N'SQL');
--INSERT Keyword(Name) VALUES(N'JAVA');
--INSERT Keyword(Name) VALUES(N'ASP.NET');
--INSERT Keyword(Name) VALUES(N'HTML');

CREATE TABLE KeywordToProblem
(
    KeywordId INT NOT NULL
    CONSTRAINT FK_KeywordToProblem_KeywordId
    FOREIGN KEY REFERENCES Keyword(Id),
    ProblemId INT NOT NULL
    CONSTRAINT FK_KeywordToProblem_ProblemId
    FOREIGN KEY REFERENCES Problem(Id),
)
select * from Keyword;
select * from Problem;
select * from KeywordToProblem;
--INSERT KeywordToProblem(KeywordId,ProblemId) 
--VALUES(1,6);
--INSERT KeywordToProblem(KeywordId,ProblemId) 
--VALUES(2,6);
--INSERT KeywordToProblem(KeywordId,ProblemId) 
--VALUES(3,6);
--INSERT KeywordToProblem(KeywordId,ProblemId) 
--VALUES(1,9);
--INSERT KeywordToProblem(KeywordId,ProblemId) 
--VALUES(1,23);
SELECT ProblemId,COUNT(KeywordId) Keywords FROM KeywordToProblem GROUP BY ProblemId;
SELECT KeywordId,COUNT(ProblemId) Problems FROM KeywordToProblem GROUP BY KeywordId;
GO
--发布了一个使用了若干个关键字的求助
--思路 插入一行新数据 然后在联合表里面分配关键字
INSERT Problem (Content,NeedRemoteHelp,Reward,PublishDateTime,Title,Author,UserId)
VALUES(N'PUB',0,11,'2020/1/1',N'PUB',N'11',16);
INSERT KeywordToProblem(KeywordId,ProblemId) VALUES(5,35);
--该求助不再使用某个关键字
UPDATE  KeywordToProblem  SET KeywordId =3
WHERE ProblemId=35;
DELETE KeywordToProblem  WHERE ProblemId=35;
--删除该求助
DELETE Problem WHERE Id=35;
--删除某关键字
DELETE Keyword WHERE Name=N'HTML';
SELECT * FROM TEST
SELECT AGE,COUNT(*) FROM TEST GROUP BY AGE;
SELECT ROW_NUMBER() OVER(PARTITION  BY AGE ORDER BY ID) AS GID,* FROM TEST;
SELECT ROW_NUMBER() OVER(ORDER BY ID) AS GID,* FROM TEST;
SELECT MAX(Id) OVER(PARTITION BY AGE ) ,* FROM TEST;

SELECT * FROM TEST;
--SELECT  
--CASE IsMale
--    WHEN 1 THEN N'男'
--    ELSE N'女'

--END,Id
--FROM TEST

GO
--CREATE TABLE TSCORE
--(
--[Name] NVARCHAR(20),
--[Subject] NVARCHAR(20),
--Score INT
--)

--INSERT TSCORE VALUES(N'飞哥','SQL', 98)
--INSERT TSCORE VALUES(N'飞哥','C#', 89)
--INSERT TSCORE VALUES(N'飞哥','Javascript',76)
--INSERT TSCORE VALUES(N'路炜','C#',87)
--INSERT TSCORE VALUES(N'路炜','SQL',95)
--INSERT TSCORE VALUES(N'路炜','Javascript',88)
SELECT  * FROM TSCORE

SELECT Name,
MAX(CASE WHEN Subject=N'SQL' THEN Score ELSE 0 END) AS SQL,
MAX(CASE WHEN Subject=N'Javascript' THEN Score ELSE 0 END )AS Javascript,
MAX(CASE WHEN Subject=N'C#' THEN Score ELSE 0 END) AS C#
FROM TSCORE GROUP BY Name

--以Problem中的数据为基础，使用SELECT INTO，新建一个Author和Reward都没有NULL值的新表：
--NewProblem （把原Problem里Author或Reward为NULL值的数据删掉）
SELECT * FROM Problem;
SELECT * FROM NEWProblem;
SELECT * INTO NEWProblem FROM Problem 
WHERE Author IS NOT NULL AND Reward IS NOT NULL;
--使用INSERT SELECT, 将Problem中Reward为NULL的行再次插入到NewProblem中
INSERT NEWProblem SELECT Content,NeedRemoteHelp,Reward,PublishDateTime,Title,Author,UserId
FROM Problem 
WHERE Reward IS NULL;
--使用OVER，统计出求助里每个Author悬赏值的平均值、最大值和最小值，
--然后用新表ProblemStatus存放上述数据
SELECT * FROM Problem
SELECT Author,AVG(Reward),MAX(Reward),MIN(Reward)
FROM Problem GROUP BY Author

--SELECT * INTO ProblemStatus FROM 
SELECT Author,AVG(Reward)OVER(PARTITION BY Author),
MAX(Reward)OVER(PARTITION BY Author),
MIN(Reward) OVER(PARTITION BY Author)
FROM Problem
--使用CASE...WHEN，颠倒Problem中的NeedRemote
--（以前是1的，现在变成0；以前是0的，现在变成1）
SELECT * FROM Problem
SELECT  
CASE NeedRemoteHelp
    WHEN 1 THEN 0
    ELSE 1
END
FROM Problem
UPDATE Problem SET NeedRemoteHelp =
CASE NeedRemoteHelp
    WHEN 0 THEN 1
    ELSE 0
END
GO
--使用CASE...WHEN，用一条SQL语句，完成SQL入门-7：函数中第4题第3小题
--有一些标题以test、[test]后者Test-开头的求助，找到他们并把这些前缀都换成大写
UPDATE Problem SET Title=
CASE Title
    WHEN  N''THEN N''
END
SELECT * FROM Problem
UPDATE Problem SET Reward=(SELECT Reward FROM Problem WHERE Id=24)
WHERE Id=23;
DELETE Problem WHERE Id NOT IN (SELECT MAX(Id) FROM Problem GROUP BY Reward)

--使用子查询：
--删除悬赏相同的求助（只要相同的全部删除一个不留）
SELECT * INTO TPROBLEM FROM Problem
SELECT * FROM TPROBLEM
BEGIN TRANSACTION
DELETE TPROBLEM WHERE Reward=(SELECT Reward FROM TPROBLEM WHERE ID NOT IN
(SELECT MAX(Id) FROM TPROBLEM GROUP BY Reward))
ROLLBACK
--删除每个作者悬赏最低的求助
BEGIN TRANSACTION
DELETE TPROBLEM WHERE Id IN (
--SELECT * FROM TPROBLEM ORDER BY Author,Reward
SELECT Id FROM TPROBLEM ot
WHERE Reward=(
SELECT MIN(Reward) FROM TPROBLEM it
WHERE OT.Author=it.Author
))
ROLLBACK

--找到从未成为邀请人的用户
SELECT * FROM TPROBLEM
SELECT * FROM [User]
ALTER TABLE [User]
ADD InvitedBy INT
CONSTRAINT FK_User_InvitedBy FOREIGN KEY(InvitedBy) REFERENCES [User](Id)

UPDATE [User] SET InvitedBy=12 WHERE Id=12;
--UPDATE [User] SET InvitedBy=13 WHERE Id=14;
--UPDATE [User] SET InvitedBy=14 WHERE Id=16;
SELECT * FROM [User]
SELECT * FROM [User] WHERE Id NOT IN (SELECT InvitedBy FROM [User]) 

--查出所有发布一篇以上（不含一篇）文章的用户信息
SELECT * FROM TProblem
--SELECT Author FROM TProblem
--WHERE (SELECT COUNT(Title),Author FROM TPROBLEM GROUP BY Author)>1
SELECT DISTINCT Author FROM TPROBLEM WHERE Id IN (
--SELECT Id FROM TPROBLEM WHERE ID   IN(  
SELECT Id FROM TPROBLEM 
WHERE  Id NOT IN (
SELECT MAX(Id) FROM TPROBLEM GROUP BY Author ))
--GROUP BY Author)

--SELECT * FROM TPROBLEM WHERE Author=(
--SELECT * FROM TPROBLEM ot
--WHERE Author=(
--SELECT Title FROM TPROBLEM it
--WHERE ot.Author=it.Author)
----HAVING COUNT(*)>2)
--)
--为求助添加一个发布时间（PublishTime），查找每个作者最近发布的一篇求助
SELECT * FROM TPROBLEM order by Author, PublishDateTime;
SELECT * FROM TPROBLEM ot
WHERE PublishDateTime=(SELECT MAX(PublishDateTime) FROM TPROBLEM it
WHERE ot.Author=it.Author
);
--查出每一篇求助的悬赏都大于5个帮帮币的作者
SELECT * FROM TPROBLEM;
--SELECT  Reward FROM  (
SELECT Reward,Author FROM TPROBLEM ot
WHERE Reward=(
SELECT MIN(Reward) FROM TPROBLEM it
WHERE ot.Author=it.Author
HAVING MIN(Reward) >5)

--表子查询  列 需要别名    select结果表 需要别名     
SELECT * FROM TPROBLEM
SELECT * FROM (
    SELECT 
    Id,Id+1 AS  CID
    FROM TPROBLEM
) AS M
WHERE M.CID<20

SELECT * FROM TEST
SELECT * FROM (SELECT ROW_NUMBER() OVER(PARTITION BY AGE ORDER BY EDIT) AS GID,*
FROM TEST
) AS ST
WHERE ST.GID<3
--公用表表达式  语法  with 表别名  as select 语句  列需要别名
--SELECT * FROM TPROBLEM

WITH EnrollTime 
AS
(
    SELECT *,MONTH(PublishDateTime) AS MonthEnroll FROM TPROBLEM
)
SELECT * FROM EnrollTime
WHERE MonthEnroll>2

--分页
SELECT * FROM TPROBLEM
--三个一页
SELECT TOP 3 * FROM TPROBLEM
WHERE Id NOT IN (SELECT TOP 3 Id FROM TPROBLEM ORDER BY Id);

SELECT * FROM (
SELECT ROW_NUMBER() OVER( ORDER BY Id) AS GID,* FROM TPROBLEM) AS TT
WHERE TT.GID BETWEEN 4 AND 6;

SELECT * FROM TPROBLEM ORDER BY Id 
OFFSET 3 ROWS FETCH NEXT 3 ROWS ONLY;

--分别使用派生表和CTE，查询求助表（表中只有一列整体的发布时间，没有年月的列），以获得：
--一起帮每月各发布了求助多少篇
SELECT * FROM TPROBLEM

SELECT YearPublish,COUNT(*) YearPublishCount,
MonthPublish,COUNT(*) MonthPublishCount FROM 
 (  SELECT YEAR(PublishDateTime) YearPublish,MONTH(PublishDateTime) MonthPublish,*
    FROM TPROBLEM) AS PT
 GROUP BY YearPublish,MonthPublish;

 WITH PublishCount--(这里面可以给列设置指定列名)
 AS
 ( SELECT YEAR(PublishDateTime) AS YearPublish,MONTH(PublishDateTime) MonthPublish
    ,* FROM TPROBLEM)
SELECT YearPublish,COUNT(YearPublish) YearPublishCount,
MonthPublish,COUNT(MonthPublish)  MonthPublishCount 
FROM PublishCount GROUP BY YearPublish,MonthPublish

--每月发布的求助中，悬赏最多的3篇
SELECT * FROM TPROBLEM
SELECT * FROM (
SELECT   ROW_NUMBER() OVER(PARTITION BY YEAR(PublishDateTime),
MONTH(PublishDateTime) ORDER BY PublishDateTime,  Reward DESC) GID,
YEAR(PublishDateTime) YearPublish,MONTH(PublishDateTime) MonthPubish,
* FROM TPROBLEM) OT
WHERE OT.GID<=3;

WITH PublishTop
AS
(
SELECT  ROW_NUMBER()  OVER(PARTITION BY YEAR(PublishDateTime),
MONTH(PublishDateTime) ORDER BY Reward DESC) GID,
YEAR(PublishDateTime) YearPublish,MONTH(PublishDateTime) MonthPubish,
* FROM TPROBLEM)
SELECT * FROM PublishTop WHERE PublishTop.GID BETWEEN 1 AND 3

--每个作者，每月发布的，悬赏最多的3篇
SELECT * FROM TPROBLEM
SELECT   * FROM(
SELECT ROW_NUMBER() OVER(PARTITION BY Author,YEAR(PublishDateTime),
MONTH(PublishDateTime) ORDER BY PublishDateTime,Reward DESC
) AS GID,YEAR(PublishDateTime) YearPublish,MONTH(PublishDateTime) MonthPubish,
* FROM TPROBLEM
) AS TT
WHERE TT.GID BETWEEN 1 AND 3
--分别按发布时间和悬赏数量进行分页查询的结果
SELECT * FROM TPROBLEM ORDER BY PublishDateTime DESC
--查找发布时间 从大到小 的5-7
SELECT TOP 3 * FROM TPROBLEM WHERE PublishDateTime NOT IN 
(SELECT TOP 4 PublishDateTime FROM TPROBLEM ORDER BY PublishDateTime DESC)
ORDER BY PublishDateTime DESC;

SELECT * FROM (
SELECT ROW_NUMBER() OVER(ORDER BY PublishDateTime DESC) AS GID,
* FROM TPROBLEM) AS TT
WHERE TT.GID BETWEEN 5 AND 7;

SELECT * FROM TPROBLEM ORDER BY PublishDateTime DESC
OFFSET 4 ROWS 
FETCH NEXT 3 ROWS ONLY;
--查找悬赏额从小到大 的3-8
SELECT TOP 6 * FROM TPROBLEM WHERE Reward NOT IN
(SELECT TOP 2 Reward FROM TPROBLEM ORDER BY Reward )
ORDER BY Reward;

SELECT * FROM (
SELECT ROW_NUMBER() OVER(ORDER BY Reward ) AS GID,
* FROM TPROBLEM) AS TT
WHERE TT.GID>2 AND TT.GID<=8;

SELECT *  FROM TPROBLEM ORDER BY Reward 
OFFSET 2 ROWS
FETCH  NEXT 6 ROWS ONLY ;

--视图理解
GO
--CREATE TABLE [LA](Id INT ,Name NVARCHAR(10),Time DATETIME,Password INT) 
--CREATE VIEW V_LA
--AS SELECT * FROM [LA]
--SELECT * FROM V_LA
--UPDATE V_LA SET Time='2020/1/1' WHERE Id=1
--UPDATE V_VLA SET DayTime=1 WHERE DayTime=1
--DROP TABLE LA
--DROP VIEW V_LA,V_VLA
--SELECT * FROM V_VLA
--ALTER VIEW V_VLA
--AS SELECT Id,Name,Password,
--Time,YEAR(Time) YearTime,MONTH(Time) MonthTiem,DAY(Time) DayTime FROM [LA] 
--CREATE TABLE [ASD](ID INT,NAME NVARCHAR(10),AGE INT,TIME DATETIME)
--ALTER VIEW V_ASD_SCHEMA
--WITH SCHEMABINDING
--AS
--SELECT ID,NAME FROM dbo.ASD
--WHERE ID>10
--WITH CHECK OPTION
--INSERT V_ASD_SCHEMA VALUES(1,N'1')
--INSERT V_ASD_SCHEMA VALUES(10,N'10')
--INSERT V_ASD_SCHEMA VALUES(101,N'101')
--INSERT V_ASD_SCHEMA VALUES(6,N'6')
--INSERT ASD VALUES(2,N'2',2,2020/2/2)
--SELECT * FROM V_ASD_SCHEMA
--SELECT * FROM ASD
DROP TABLE ASD
DROP VIEW V_ASD_SCHEMA

--SELECT * FROM [User]
--SELECT * FROM PROFILE
----SELECT * FROM Problem

--SELECT *  FROM [User] U  JOIN Profile P
--ON U.ProfileId=P.Id 
--ON
--WHERE U.Id=12

SELECT *  FROM [User] U  JOIN Profile P
ON U.ProfileId=P.Id 
AND U.Id=12
--SELECT *  FROM [User] U LEFT JOIN Profile P
--ON U.ProfileId=P.Id 

--SELECT *  FROM [User] U RIGHT JOIN Profile P
--ON U.ProfileId=P.Id 

--SELECT *  FROM [User] U FULL JOIN Profile P
--ON U.ProfileId=P.Id 
DBCC USEROPTIONS
 SELECT * FROM TSCORE
 
 --BEGIN TRY
 --   BEGIN TRANSACTION
 --   --SAVE TRAN SAD
 --   UPDATE TSCORE SET Score=92
 --   WHERE Name=N'飞哥' AND Subject=N'Javascript'
 --   COMMIT 
 -- END TRY
 -- BEGIN CATCH
 --   ROLLBACK 
 -- END CATCH

 -- SET IMPLICIT_TRANSACTIONS ON
 --SET IMPLICIT_TRANSACTIONS OFF

 --DBCC USEROPTIONS
 --SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
 --BEGIN TRANSACTION
 -- SELECT * FROM TSCORE
 -- UPDATE TSCORE SET Score=92
 --   WHERE Name=N'飞哥' AND Subject=N'Javascript' 
 -- PRINT @@TRANCOUNT

  --ROLLBACK
  GO
--创建求助的应答表 Response(Id, Content, AuthorId, ProblemId, CreateTime)
SELECT * FROM Problem;
SELECT * FROM [User];
CREATE TABLE Response(
    Id INT  IDENTITY NOT NULL
    CONSTRAINT PK_Response_Id PRIMARY KEY(Id) ,
    Content NVARCHAR(MAX) NOT NULL,
    AuthorId INT NOT NULL
    --CONSTRAINT UQ_Profile_Id UNIQUE(AuthorId)
    CONSTRAINT FK_Response_User_AuthorId FOREIGN KEY(AuthorId) REFERENCES [User](Id),
    ProblemId INT NOT NULL
    --CONSTRAINT UQ_Response_ProblemId UNIQUE(ProblemId)
    CONSTRAINT FK_Response_Problem_PorblemId FOREIGN KEY(ProblemId) REFERENCES Problem(Id),
    CreateTime DATETIME NOT NULL,
)
--然后生成一个视图 VResponse(ResponseId, Content, ResponseAuthorId，ReponseAuthorName,
--ProblemId, ProblemAuthorName, ProblemTitle, CreateTime)，要求该视图：
--能展示应答作者的用户名、应答对应求助的标题和作者用户名 （JOIN）
SELECT * FROM Response;
GO
ALTER VIEW VResponse(ResponseId, Content,ResponseAuthorId,ReponseAuthorName,
ProblemId, ProblemAuthorName, ProblemTitle, CreateTime,ProblemReward) 
WITH SCHEMABINDING , ENCRYPTION
AS 
(SELECT R.Id,R.Content,U.Id,U.[Name],P.Id,UU.Name,P.Title,R.CreateTime,P.Reward 
FROM dbo.Response R JOIN dbo.[User] U
ON R.AuthorId=U.Id  JOIN dbo.Problem P ON R.ProblemId=P.Id  JOIN dbo.[User] UU ON P.UserId=UU.Id
WHERE P.Reward>5)
--WITH CHECK OPTION
GO
SELECT * FROM dbo.VResponse
SELECT * FROM Response;
SELECT * FROM [User]
SELECT * FROM Response R JOIN [User] U
ON R.AuthorId=U.Id  JOIN Problem P ON R.ProblemId=P.Id  JOIN [User] UU ON P.UserId=UU.Id
 
  SELECT * FROM Problem P JOIN [User] U ON P.UserId=U.Id 
--只显示求助悬赏值大于5的数据 （JOIN）
--WHERE P.Reward>5

--已被加密
--WITH ENCRYPTION
--保证其使用的基表结构无法更改
 --WITH SCHEMABINDING
-- GO
--ALTER VIEW V_Response_Schema(ResponseId, Content,ResponseAuthorId,ReponseAuthorName,
--ProblemId, ProblemAuthorName, ProblemTitle, CreateTime) 
--WITH SCHEMABINDING , ENCRYPTION
--AS 
--(SELECT R.Id,R.Content,U.Id,U.[Name],P.Id,UU.Name,P.Title,R.CreateTime
--FROM dbo.Response R JOIN dbo.[User] U
--ON R.AuthorId=U.Id  JOIN dbo.Problem P ON R.ProblemId=P.Id  JOIN dbo.[User] UU ON P.UserId=UU.Id
--WHERE P.Reward>5)

--演示：在VResponse中插入一条数据，却不能在视图中显示
--SELECT * FROM VResponse
--select * from Response
INSERT VResponse(Content,ResponseAuthorId,ReponseAuthorName,ProblemId,ProblemAuthorName,ProblemTitle,CreateTime)
VALUES(N'123',12,2,1,6,N'testssdd','2020/5/27',4);
--修改VResponse，让其能避免上述情形
--WITH CHECK OPTION
--创建视图VProblemKeyword(ProblemId, ProblemTitle, ProblemReward, KeywordAmount)，
--要求该视图：
--能反映求助的标题、使用关键字数量和悬赏

--在ProblemId上有一个唯一聚集索引

--在ProblemReward上有一个非聚集索引

--试一下，能不能在KeywordAmount上建索引

--在基表中插入/删除数据，观察VProblemKeyword是否相应的发生变化


--联表查出求助的标题和作者用户名
SELECT * FROM Problem;
SELECT * FROM [User];

SELECT P.Id,P.Content,P.Reward,P.PublishDateTime,P.Title,U.Id,
U.Name FROM Problem P JOIN [User] U ON P.UserId=U.Id
--查找并删除从未发布过求助的用户
--WITH SelfJoin AS
--(SELECT * FROM Problem  P RIGHT JOIN [User] U ON P.UserId=U.Id)
--SELECT * FROM SelfJoin  
--WHERE P.UserId NOT IN (SELECT U.Id FROM SelfJoin)
SELECT * FROM Problem  P RIGHT JOIN [User] U ON P.UserId=U.Id
WHERE P.UserId IS NULL
--WHERE 
--用一句SELECT显示出用户和他的邀请人用户名
SELECT * FROM [User];
SELECT  * FROM [User] U JOIN [User] UU ON U.Id=UU.InvitedBy
SELECT U.Id UserId,U.Name UserName,U.InvitedBy Inviter,UU.Name  InviterName
FROM [User] U JOIN [User] UU ON U.InvitedBy=UU.Id
--17bang的关键字有“一级”“二级”和其他“普通（三）级”的区别：
--请在表Keyword中添加一个字段，记录这种关系
SELECT * FROM Keyword;
ALTER TABLE Keyword
ADD KeywordLevel INT 
CONSTRAINT FK_Keyword_Keyword_KeywordLevel
FOREIGN KEY(KeywordLevel) REFERENCES Keyword(Id);
--然后用一个SELECT语句查出所有普通关键字的上一级、以及上上一级的关键字名称，比如：
SELECT * FROM Keyword;
SELECT * FROM Keyword K LEFT JOIN Keyword KK ON K.KeywordLevel=KK.Id 
LEFT JOIN Keyword KKK ON KK.KeywordLevel=KKK.Id
--WHERE K.KeywordLevel IS NULL 
--17bang中除了求助（Problem），还有意见建议（Suggest）和文章（Article），
--他们都包含Title、Content、PublishTime和Auhthor四个字段，但是：
--建议和文章没有悬赏（Reward）
--建议多一个类型：Kind NVARCHAR(20)）
--文章多一个分类：Category INT）
--请按上述描述建表。然后，用一个SQL语句
--显示某用户发表的求助、建议和文章的Title、Content，并按PublishTime降序排列
CREATE TABLE Suggest(
    Id INT IDENTITY NOT NULL
    CONSTRAINT PK_Suggest_Id PRIMARY KEY(Id),
    Title  NVARCHAR(MAX) NOT NULL,
    Content NVARCHAR(MAX) NOT NULL,
    PublishTime DATETIME NOT NULL,
    Author NVARCHAR(10) NOT NULL,
    Kind NVARCHAR(20) ,
    UserId INT  NOT NULL
    CONSTRAINT FK_Suggest_User_UserId FOREIGN KEY(UserId) REFERENCES [User](Id)
);
CREATE TABLE Article(
    Id INT IDENTITY NOT NULL
    CONSTRAINT PK_Article_Id PRIMARY KEY(Id),
    Title  NVARCHAR(MAX) NOT NULL,
    Content NVARCHAR(MAX) NOT NULL,
    PublishTime DATETIME NOT NULL,
    Author NVARCHAR(10) NOT NULL,
    Category INT ,
    UserId INT  NOT NULL
    CONSTRAINT FK_Article_User_UserId FOREIGN KEY(UserId) REFERENCES [User](Id)
);

SELECT * FROM [User];
SELECT * FROM Problem;
SELECT * FROM Suggest;
SELECT * FROM Article;

SELECT N'Problem',P.Title Title,P.Content Content,P.PublishDateTime PublishTime,U.[Name] [Name]
FROM Problem P JOIN [User] U ON P.UserId=U.Id
UNION
SELECT N'Suggest',S.Title Title,S.Content Content,S.PublishTime PublishTime,U.[Name] [Name]
FROM Suggest S JOIN [User] U ON S.UserId=U.Id
UNION
SELECT N'Article',A.Title Title,A.Content Content,A.PublishTime PublishTime,U.[Name] [Name]
FROM Article A JOIN [User] U ON A.UserId=U.Id
ORDER BY Name,PublishTime DESC
--SELECT * FROM [User] U JOIN Problem P ON U.Id=P.UserId
--JOIN Suggest S ON U.Id=S.UserId     JOIN  Article A ON U.Id=A.UserId
--ORDER BY U.Id ASC,P.PublishDateTime DESC,
--S.PublishTime DESC,A.PublishTime DESC

--用户（Reigister）发布一篇悬赏币若干的求助（Problem），他的帮帮币（BMoney）也会相应减少，
--但他的帮帮币总额不能少于0分：请综合使用TRY...CATCH和事务完成上述需求。
SELECT * FROM [User]
ALTER TABLE [USER]
ADD BMoney INT  
CONSTRAINT CK_User_BMoney CHECK (BMoney>0)
UPDATE [User] SET BMoney =88 
SELECT * FROM Problem
BEGIN TRY
    BEGIN TRANSACTION
    --INSERT Problem VALUES()
    UPDATE [User] SET BMoney-=22 WHERE Id=12
    UPDATE [User] SET BMoney-=100 
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
END CATCH
PRINT @@TRANCOUNT
--存储过程理解
SELECT * FROM COPY;
ALTER TABLE COPY
ADD Reward INT;
GO
ALTER PROCEDURE ZXC
@INT INT,
@Out INT OUTPUT
AS
SET NOCOUNT ON
    UPDATE COPY SET Reward -=@INT;
    SELECT COUNT(*) FROM COPY WHERE Reward>10;
    SET @Out=(SELECT COUNT(*) FROM COPY WHERE Reward>10);
SET NOCOUNT OFF

DECLARE @RES INT
--EXECUTE ZXC 2,@RES OUTPUT
EXECUTE ZXC  @Out=@RES OUTPUT,@INT=2

EXECUTE sp_rename'COPY.Name','UserName','COLUMN'


