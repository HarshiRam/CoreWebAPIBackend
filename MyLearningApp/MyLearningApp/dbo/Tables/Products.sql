CREATE TABLE [dbo].[Products] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [ProductName] VARCHAR (50) NOT NULL,
    [Price]       DECIMAL (18) NOT NULL,
    [Qty]         INT          NOT NULL
);

