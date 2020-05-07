﻿CREATE TABLE [dbo].[Probblem] (
    [Title]        NVARCHAR (100) NOT NULL,
    [Description]  NVARCHAR (10)  NULL,
    [Keyword1]     NVARCHAR (18)  NULL,
    [Keyword2]     NVARCHAR (18)  NULL,
    [SelfKeyword2] NVARCHAR (18)  NULL,
    [Problemer]    NVARCHAR (18)  NOT NULL,
    [Reword]       INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Title] ASC)
);

