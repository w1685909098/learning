CREATE TABLE [dbo].[Problem] (
    [Id]              INT          IDENTITY (1, 1) NOT NULL,
    [Title]           NVARCHAR (1) NOT NULL,
    [Content]         NTEXT        NOT NULL,
    [NeedRemoteHelp]  BIT          CONSTRAINT [DF_NeedRemoteHelp] DEFAULT ((1)) NULL,
    [Reward]          INT          NOT NULL,
    [PublishDateTime] DATETIME     NOT NULL,
    CONSTRAINT [PK_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_Title] CHECK ([Title]>(0)),
    CONSTRAINT [CK_Reward] CHECK ([Reward]>(0)),
    CONSTRAINT [CK_PublishDateTime] CHECK ([PublishDateTime]>(0))
);

