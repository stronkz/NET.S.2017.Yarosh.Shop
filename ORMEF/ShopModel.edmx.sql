
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/11/2017 11:57:55
-- Generated from EDMX file: c:\users\alexy\documents\visual studio 2017\Projects\ORMEF\ORMEF\ShopModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ShopDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Category] int  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Price] decimal(18,0)  NOT NULL,
    [Image] nvarchar(max)  NOT NULL,
    [Amount] int  NOT NULL,
    [Purchase_Id] int  NOT NULL
);
GO

-- Creating table 'Purchases'
CREATE TABLE [dbo].[Purchases] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NameOfBuyer] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Purchases'
ALTER TABLE [dbo].[Purchases]
ADD CONSTRAINT [PK_Purchases]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Purchase_Id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_PurchaseProduct]
    FOREIGN KEY ([Purchase_Id])
    REFERENCES [dbo].[Purchases]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PurchaseProduct'
CREATE INDEX [IX_FK_PurchaseProduct]
ON [dbo].[Products]
    ([Purchase_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------