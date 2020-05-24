select * from [user];
--DELETE [User] 
BEGIN TRANSACTION
DELETE [User] 
WHERE UserName LIKE N'%管理员%' OR UserName LIKE N'%17bang%' ;
ROLLBACK
SELECT * FROM Problem
BEGIN TRANSACTION
UPDATE Problem SET Title=N'【推荐】'+Title
WHERE Reward>10
UPDATE Problem SET Reward=30
WHERE Id>1
UPDATE Problem SET Title=N'【加急】'+Title
WHERE Reward>20 AND PublishDateTime>'2019/10/19'
BEGIN TRANSACTION
DELETE Problem WHERE Title LIKE N'#【%#】%' ESCAPE'#'
ROLLBACK
SELECT * FROM Keyword
ALTER TABLE [Keyword]
ADD Used INT 
