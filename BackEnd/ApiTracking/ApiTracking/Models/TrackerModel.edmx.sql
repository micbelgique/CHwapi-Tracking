
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/07/2016 11:24:39
-- Generated from EDMX file: D:\Sources\VS2015\DevCamp2016-Team9\BackEnd\ApiTracking\ApiTracking\Models\TrackerModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Tracker];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Track_Box]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Track] DROP CONSTRAINT [FK_Track_Box];
GO
IF OBJECT_ID(N'[dbo].[FK_Track_Gate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Track] DROP CONSTRAINT [FK_Track_Gate];
GO
IF OBJECT_ID(N'[dbo].[FK_Track_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Track] DROP CONSTRAINT [FK_Track_User];
GO
IF OBJECT_ID(N'[dbo].[FK_TrackedItem_Item]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TrackedItem] DROP CONSTRAINT [FK_TrackedItem_Item];
GO
IF OBJECT_ID(N'[dbo].[FK_TrackedItem_Track]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TrackedItem] DROP CONSTRAINT [FK_TrackedItem_Track];
GO
IF OBJECT_ID(N'[dbo].[FK_TrackHistory_Gate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TrackHistory] DROP CONSTRAINT [FK_TrackHistory_Gate];
GO
IF OBJECT_ID(N'[dbo].[FK_TrackHistory_Track]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TrackHistory] DROP CONSTRAINT [FK_TrackHistory_Track];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Box]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Box];
GO
IF OBJECT_ID(N'[dbo].[Gate]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Gate];
GO
IF OBJECT_ID(N'[dbo].[Item]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Item];
GO
IF OBJECT_ID(N'[dbo].[Track]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Track];
GO
IF OBJECT_ID(N'[dbo].[TrackedItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TrackedItem];
GO
IF OBJECT_ID(N'[dbo].[TrackHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TrackHistory];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Box'
CREATE TABLE [dbo].[Box] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Description] varchar(100)  NOT NULL,
    [Barcode] varchar(20)  NOT NULL
);
GO

-- Creating table 'Gate'
CREATE TABLE [dbo].[Gate] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Description] varchar(100)  NOT NULL,
    [X] int  NULL,
    [Y] int  NULL,
    [Z] int  NULL
);
GO

-- Creating table 'Item'
CREATE TABLE [dbo].[Item] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Description] varchar(100)  NOT NULL,
    [Barcode] varchar(20)  NOT NULL
);
GO

-- Creating table 'Track'
CREATE TABLE [dbo].[Track] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [BoxID] int  NOT NULL,
    [GateID] int  NOT NULL,
    [UserID] int  NOT NULL,
    [Status] tinyint  NOT NULL
);
GO

-- Creating table 'TrackedItem'
CREATE TABLE [dbo].[TrackedItem] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TrackID] int  NOT NULL,
    [ItemID] int  NOT NULL,
    [Quantity] int  NULL
);
GO

-- Creating table 'TrackHistory'
CREATE TABLE [dbo].[TrackHistory] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TrackID] int  NOT NULL,
    [GateID] int  NULL,
    [ScanTime] datetime  NOT NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Username] varchar(20)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Box'
ALTER TABLE [dbo].[Box]
ADD CONSTRAINT [PK_Box]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Gate'
ALTER TABLE [dbo].[Gate]
ADD CONSTRAINT [PK_Gate]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Item'
ALTER TABLE [dbo].[Item]
ADD CONSTRAINT [PK_Item]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Track'
ALTER TABLE [dbo].[Track]
ADD CONSTRAINT [PK_Track]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TrackedItem'
ALTER TABLE [dbo].[TrackedItem]
ADD CONSTRAINT [PK_TrackedItem]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TrackHistory'
ALTER TABLE [dbo].[TrackHistory]
ADD CONSTRAINT [PK_TrackHistory]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BoxID] in table 'Track'
ALTER TABLE [dbo].[Track]
ADD CONSTRAINT [FK_Track_Box]
    FOREIGN KEY ([BoxID])
    REFERENCES [dbo].[Box]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Track_Box'
CREATE INDEX [IX_FK_Track_Box]
ON [dbo].[Track]
    ([BoxID]);
GO

-- Creating foreign key on [GateID] in table 'Track'
ALTER TABLE [dbo].[Track]
ADD CONSTRAINT [FK_Track_Gate]
    FOREIGN KEY ([GateID])
    REFERENCES [dbo].[Gate]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Track_Gate'
CREATE INDEX [IX_FK_Track_Gate]
ON [dbo].[Track]
    ([GateID]);
GO

-- Creating foreign key on [GateID] in table 'TrackHistory'
ALTER TABLE [dbo].[TrackHistory]
ADD CONSTRAINT [FK_TrackHistory_Gate]
    FOREIGN KEY ([GateID])
    REFERENCES [dbo].[Gate]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TrackHistory_Gate'
CREATE INDEX [IX_FK_TrackHistory_Gate]
ON [dbo].[TrackHistory]
    ([GateID]);
GO

-- Creating foreign key on [ItemID] in table 'TrackedItem'
ALTER TABLE [dbo].[TrackedItem]
ADD CONSTRAINT [FK_TrackedItem_Item]
    FOREIGN KEY ([ItemID])
    REFERENCES [dbo].[Item]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TrackedItem_Item'
CREATE INDEX [IX_FK_TrackedItem_Item]
ON [dbo].[TrackedItem]
    ([ItemID]);
GO

-- Creating foreign key on [UserID] in table 'Track'
ALTER TABLE [dbo].[Track]
ADD CONSTRAINT [FK_Track_User]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Track_User'
CREATE INDEX [IX_FK_Track_User]
ON [dbo].[Track]
    ([UserID]);
GO

-- Creating foreign key on [TrackID] in table 'TrackedItem'
ALTER TABLE [dbo].[TrackedItem]
ADD CONSTRAINT [FK_TrackedItem_Track]
    FOREIGN KEY ([TrackID])
    REFERENCES [dbo].[Track]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TrackedItem_Track'
CREATE INDEX [IX_FK_TrackedItem_Track]
ON [dbo].[TrackedItem]
    ([TrackID]);
GO

-- Creating foreign key on [TrackID] in table 'TrackHistory'
ALTER TABLE [dbo].[TrackHistory]
ADD CONSTRAINT [FK_TrackHistory_Track]
    FOREIGN KEY ([TrackID])
    REFERENCES [dbo].[Track]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TrackHistory_Track'
CREATE INDEX [IX_FK_TrackHistory_Track]
ON [dbo].[TrackHistory]
    ([TrackID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------