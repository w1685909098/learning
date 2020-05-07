CREATE TABLE [dbo].[User] (
    [Id]          INT           NOT NULL,
    [Name]        NVARCHAR (10) NOT NULL,
    [Password]    NVARCHAR (18) NOT NULL,
    [Inviter]     NVARCHAR (18) NOT NULL,
    [InviterCode] NVARCHAR (4)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

