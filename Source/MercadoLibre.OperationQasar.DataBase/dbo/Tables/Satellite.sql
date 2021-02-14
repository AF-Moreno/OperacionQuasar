CREATE TABLE [dbo].[Satellite] (
    [Id]             INT          IDENTITY (1, 1) NOT NULL,
    [Name]           VARCHAR (30) NOT NULL,
    [PositionX]      FLOAT (53)   NOT NULL,
    [PositionY]      FLOAT (53)   NOT NULL,
    [Enable]         BIT          NOT NULL,
    [CreatedOn]      DATETIME     NOT NULL,
    [LastModifiedOn] DATETIME     NULL,
    [LastModifiedBy] VARCHAR (64) NULL,
    [DeletedOn]      DATETIME     NULL,
    [DeletedBy]      VARCHAR (64) NULL,
    CONSTRAINT [PK_Satellite] PRIMARY KEY CLUSTERED ([Id] ASC)
);



