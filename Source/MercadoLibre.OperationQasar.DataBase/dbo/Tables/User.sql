CREATE TABLE [dbo].[User] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [Name]           VARCHAR (30)  NOT NULL,
    [Email]          VARCHAR (30)  NOT NULL,
    [Password]       VARCHAR (MAX) NOT NULL,
    [Enable]         BIT           NOT NULL,
    [CreatedOn]      DATETIME      NOT NULL,
    [LastModifiedOn] DATETIME      NULL,
    [LastModifiedBy] VARCHAR (64)  NULL,
    [DeletedOn]      DATETIME      NULL,
    [DeletedBy]      VARCHAR (64)  NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC)
);

