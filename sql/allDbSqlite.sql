-- Script Date: 3/25/2018 11:14 AM  - ErikEJ.SqlCeScripting version 3.5.2.75
SELECT 1;
PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE [TeamLeaders] (
  [ID] INTEGER  NOT NULL
, [FirstName] nvarchar(100)  NOT NULL
, [LastName] nvarchar(100)  NOT NULL
, [Gender] bit NOT NULL
, CONSTRAINT [PK_TeamLeaders] PRIMARY KEY ([ID])
);
CREATE TABLE [sysdiagrams] (
  [name] nvarchar(128)  NOT NULL
, [principal_id] int  NOT NULL
, [diagram_id] INTEGER  NOT NULL
, [version] int  NULL
, [definition] image NULL
, CONSTRAINT [PK__sysdiagr__C2B05B611087377D] PRIMARY KEY ([diagram_id])
);
CREATE TABLE [Projects] (
  [ID] INTEGER  NOT NULL
, [Name] nvarchar(150)  NULL
, [Description] nvarchar(1000)  NULL
, [IDTeamLeader] bigint  NOT NULL
, CONSTRAINT [PK_Projects] PRIMARY KEY ([ID])
, FOREIGN KEY ([IDTeamLeader]) REFERENCES [TeamLeaders] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE [NGOUser] (
  [ID] INTEGER  NOT NULL
, [Name] nvarchar(50)  NOT NULL
, [Password] nvarchar(300)  NOT NULL
, CONSTRAINT [PK_NGOUser] PRIMARY KEY ([ID])
);
CREATE TABLE [Emails] (
  [ID] INTEGER  NOT NULL
, [Type] nvarchar(50)  NOT NULL
, [Email] nvarchar(200)  NOT NULL
, [IDContactDetails] bigint  NOT NULL
, CONSTRAINT [PK_Emails] PRIMARY KEY ([ID])
);
CREATE TABLE [ContactDetails] (
  [ID] INTEGER  NOT NULL
, [Website] nvarchar(200)  NULL
, CONSTRAINT [PK_ContactDetails] PRIMARY KEY ([ID])
, FOREIGN KEY ([ID]) REFERENCES [Emails] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE [Social] (
  [ID] INTEGER  NOT NULL
, [Network] nvarchar(50)  NOT NULL
, [Address] nvarchar(300)  NOT NULL
, [IDContactDetails] bigint  NOT NULL
, CONSTRAINT [PK_Social] PRIMARY KEY ([ID])
, FOREIGN KEY ([IDContactDetails]) REFERENCES [ContactDetails] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE [PhoneNumbers] (
  [ID] INTEGER  NOT NULL
, [PhoneNumber] nvarchar(20)  NOT NULL
, [IDContactDetails] bigint  NOT NULL
, CONSTRAINT [PK_PhoneNumbers] PRIMARY KEY ([ID])
, FOREIGN KEY ([IDContactDetails]) REFERENCES [ContactDetails] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE [Category] (
  [ID] INTEGER  NOT NULL
, [Name] nvarchar(100)  NOT NULL
, CONSTRAINT [PK__Category__3214EC07F909A028] PRIMARY KEY ([ID])
);
CREATE TABLE [Admin] (
  [ID] INTEGER  NOT NULL
, [Name] nvarchar(50)  NOT NULL
, [Password] nvarchar(300)  NOT NULL
, CONSTRAINT [PK_Admin] PRIMARY KEY ([ID])
);
CREATE TABLE [Address] (
  [ID] INTEGER  NOT NULL
, [Lat] float NOT NULL
, [Long] float NOT NULL
, [AddressDetails] nvarchar(500)  NOT NULL
, CONSTRAINT [PK_Adress] PRIMARY KEY ([ID])
);
CREATE TABLE [RoboticEntity] (
  [ID] INTEGER  NOT NULL
, [Name] nvarchar(500)  NOT NULL
, [IDAddress] bigint  NOT NULL
, [IDCategory] bigint  NOT NULL
, [Description] nvarchar(500)  NULL
, [MemberCount] bigint  NOT NULL
, [Rating] float NULL
, [IDContactDetails] bigint  NOT NULL
, [WomenPercentage] float NULL
, [Sentiment] int  NULL
, CONSTRAINT [PK_RoboticEntity] PRIMARY KEY ([ID])
, FOREIGN KEY ([IDAddress]) REFERENCES [Address] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
, FOREIGN KEY ([IDCategory]) REFERENCES [Category] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
, FOREIGN KEY ([IDContactDetails]) REFERENCES [ContactDetails] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE [RoboticEntityProjects] (
  [IDRoboticEntity] bigint  NOT NULL
, [IDProjects] bigint  NOT NULL
, FOREIGN KEY ([IDProjects]) REFERENCES [Projects] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
, FOREIGN KEY ([IDRoboticEntity]) REFERENCES [RoboticEntity] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE [Photos] (
  [ID] INTEGER  NOT NULL
, [Name] nvarchar(150)  NOT NULL
, [Path] nvarchar(200)  NOT NULL
, [IDRoboticEntity] bigint  NOT NULL
, CONSTRAINT [PK_Photos] PRIMARY KEY ([ID])
, FOREIGN KEY ([IDRoboticEntity]) REFERENCES [RoboticEntity] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE [Benefits] (
  [ID] INTEGER  NOT NULL
, [Name] nvarchar(200)  NULL
, [Description] nvarchar(1000)  NULL
, [IDRoboticEntity] bigint  NOT NULL
, CONSTRAINT [PK_Benefits] PRIMARY KEY ([ID])
, FOREIGN KEY ([IDRoboticEntity]) REFERENCES [RoboticEntity] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE UNIQUE INDEX [UK_principal_name] ON [sysdiagrams] ([principal_id] ASC,[name] ASC);
COMMIT;

