IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    CREATE TABLE [datAppointment] (
        [appointmentId] int NOT NULL IDENTITY,
        [appointmentDate] datetime2 NOT NULL,
        [custName] nvarchar(max) NOT NULL,
        [custPhone] nvarchar(max) NULL,
        [custEmail] nvarchar(max) NULL,
        [isConfirmed] bit NOT NULL,
        [salesRep] nvarchar(max) NULL,
        CONSTRAINT [PK_datAppointment] PRIMARY KEY ([appointmentId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    CREATE TABLE [datRole] (
        [Id] int NOT NULL IDENTITY,
        [roleId] nvarchar(max) NULL,
        [roleName] nvarchar(max) NULL,
        CONSTRAINT [PK_datRole] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    CREATE TABLE [datUserRole] (
        [userRoleId] int NOT NULL IDENTITY,
        [userId] nvarchar(max) NULL,
        [roleId] nvarchar(max) NULL,
        CONSTRAINT [PK_datUserRole] PRIMARY KEY ([userRoleId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    CREATE TABLE [infFabric] (
        [fabricId] int NOT NULL IDENTITY,
        [fabricName] nvarchar(max) NULL,
        [fabricDesc] nvarchar(max) NULL,
        CONSTRAINT [PK_infFabric] PRIMARY KEY ([fabricId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    CREATE TABLE [infFrontStyle] (
        [frontId] int NOT NULL IDENTITY,
        [frontName] nvarchar(max) NULL,
        CONSTRAINT [PK_infFrontStyle] PRIMARY KEY ([frontId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    CREATE TABLE [infLapelStyle] (
        [lapelId] int NOT NULL IDENTITY,
        [lapelName] nvarchar(max) NULL,
        CONSTRAINT [PK_infLapelStyle] PRIMARY KEY ([lapelId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    CREATE TABLE [infOccasionFit] (
        [fitId] int NOT NULL IDENTITY,
        [fitName] nvarchar(max) NULL,
        [fitDesc] nvarchar(max) NULL,
        CONSTRAINT [PK_infOccasionFit] PRIMARY KEY ([fitId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    CREATE TABLE [infOccasionLabel] (
        [labelId] int NOT NULL IDENTITY,
        [labelName] int NOT NULL,
        [labelDesc] nvarchar(max) NULL,
        CONSTRAINT [PK_infOccasionLabel] PRIMARY KEY ([labelId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    CREATE TABLE [infOccasionStyle] (
        [styleId] int NOT NULL IDENTITY,
        [styleName] nvarchar(max) NULL,
        CONSTRAINT [PK_infOccasionStyle] PRIMARY KEY ([styleId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    CREATE TABLE [infSalesTag] (
        [tagId] int NOT NULL IDENTITY,
        [tagName] nvarchar(max) NULL,
        [applyAdjust] bit NOT NULL,
        [priceAdjust] float NOT NULL,
        CONSTRAINT [PK_infSalesTag] PRIMARY KEY ([tagId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    CREATE TABLE [infSuitSize] (
        [sizeId] int NOT NULL IDENTITY,
        [sizeName] nvarchar(max) NULL,
        [adjustIndex] float NOT NULL,
        CONSTRAINT [PK_infSuitSize] PRIMARY KEY ([sizeId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    CREATE TABLE [infSuitType] (
        [suitTypeId] int NOT NULL IDENTITY,
        [typeName] nvarchar(max) NULL,
        [typeDesc] nvarchar(max) NULL,
        CONSTRAINT [PK_infSuitType] PRIMARY KEY ([suitTypeId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    CREATE TABLE [infVentStyle] (
        [ventId] int NOT NULL IDENTITY,
        [ventName] nvarchar(max) NULL,
        CONSTRAINT [PK_infVentStyle] PRIMARY KEY ([ventId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    CREATE TABLE [Users] (
        [Id] int NOT NULL IDENTITY,
        [userName] nvarchar(max) NULL,
        [passwordHash] varbinary(max) NULL,
        [gender] nvarchar(max) NULL,
        [accountConfirmed] bit NOT NULL,
        [displayName] nvarchar(max) NULL,
        [email] nvarchar(max) NULL,
        [lockoutEnabled] bit NOT NULL,
        [lockOutEnd] datetime2 NOT NULL,
        [accessFailedCount] int NOT NULL,
        [phoneNumber] nvarchar(max) NULL,
        [securityStamp] varbinary(max) NULL,
        [userId] nvarchar(max) NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    CREATE TABLE [Values] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_Values] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    CREATE TABLE [infOccasionType] (
        [typeId] int NOT NULL IDENTITY,
        [labelId] int NOT NULL,
        [colorName] nvarchar(max) NULL,
        [colorValue] nvarchar(max) NULL,
        CONSTRAINT [PK_infOccasionType] PRIMARY KEY ([typeId]),
        CONSTRAINT [FK_infOccasionType_infOccasionLabel_labelId] FOREIGN KEY ([labelId]) REFERENCES [infOccasionLabel] ([labelId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    CREATE TABLE [datSuit] (
        [suitId] int NOT NULL IDENTITY,
        [suitDesc] nvarchar(max) NULL,
        [suitImg] nvarchar(max) NULL,
        [suitTypeId] int NOT NULL,
        [typeId] int NOT NULL,
        [fitId] int NOT NULL,
        [styleId] int NOT NULL,
        [lapelId] int NOT NULL,
        [frontId] int NOT NULL,
        [ventId] int NOT NULL,
        CONSTRAINT [PK_datSuit] PRIMARY KEY ([suitId]),
        CONSTRAINT [FK_datSuit_infOccasionFit_fitId] FOREIGN KEY ([fitId]) REFERENCES [infOccasionFit] ([fitId]) ON DELETE CASCADE,
        CONSTRAINT [FK_datSuit_infFrontStyle_frontId] FOREIGN KEY ([frontId]) REFERENCES [infFrontStyle] ([frontId]) ON DELETE CASCADE,
        CONSTRAINT [FK_datSuit_infLapelStyle_lapelId] FOREIGN KEY ([lapelId]) REFERENCES [infLapelStyle] ([lapelId]) ON DELETE CASCADE,
        CONSTRAINT [FK_datSuit_infOccasionStyle_styleId] FOREIGN KEY ([styleId]) REFERENCES [infOccasionStyle] ([styleId]) ON DELETE CASCADE,
        CONSTRAINT [FK_datSuit_infSuitType_suitTypeId] FOREIGN KEY ([suitTypeId]) REFERENCES [infSuitType] ([suitTypeId]) ON DELETE CASCADE,
        CONSTRAINT [FK_datSuit_infOccasionType_typeId] FOREIGN KEY ([typeId]) REFERENCES [infOccasionType] ([typeId]) ON DELETE CASCADE,
        CONSTRAINT [FK_datSuit_infVentStyle_ventId] FOREIGN KEY ([ventId]) REFERENCES [infVentStyle] ([ventId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    CREATE TABLE [datSuitDetail] (
        [detailId] int NOT NULL IDENTITY,
        [suitId] int NOT NULL,
        [price] float NOT NULL,
        [qty] int NOT NULL,
        [tagId] int NOT NULL,
        [inStock] bit NOT NULL,
        CONSTRAINT [PK_datSuitDetail] PRIMARY KEY ([detailId]),
        CONSTRAINT [FK_datSuitDetail_datSuit_suitId] FOREIGN KEY ([suitId]) REFERENCES [datSuit] ([suitId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    CREATE TABLE [datAppointmentDetail] (
        [appointmentDetailId] int NOT NULL IDENTITY,
        [appointmentId] int NOT NULL,
        [detailId] int NOT NULL,
        CONSTRAINT [PK_datAppointmentDetail] PRIMARY KEY ([appointmentDetailId]),
        CONSTRAINT [FK_datAppointmentDetail_datAppointment_appointmentId] FOREIGN KEY ([appointmentId]) REFERENCES [datAppointment] ([appointmentId]) ON DELETE CASCADE,
        CONSTRAINT [FK_datAppointmentDetail_datSuitDetail_detailId] FOREIGN KEY ([detailId]) REFERENCES [datSuitDetail] ([detailId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    CREATE INDEX [IX_datAppointmentDetail_appointmentId] ON [datAppointmentDetail] ([appointmentId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    CREATE INDEX [IX_datAppointmentDetail_detailId] ON [datAppointmentDetail] ([detailId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    CREATE INDEX [IX_datSuit_fitId] ON [datSuit] ([fitId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    CREATE INDEX [IX_datSuit_frontId] ON [datSuit] ([frontId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    CREATE INDEX [IX_datSuit_lapelId] ON [datSuit] ([lapelId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    CREATE INDEX [IX_datSuit_styleId] ON [datSuit] ([styleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    CREATE INDEX [IX_datSuit_suitTypeId] ON [datSuit] ([suitTypeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    CREATE INDEX [IX_datSuit_typeId] ON [datSuit] ([typeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    CREATE INDEX [IX_datSuit_ventId] ON [datSuit] ([ventId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    CREATE INDEX [IX_datSuitDetail_suitId] ON [datSuitDetail] ([suitId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    CREATE INDEX [IX_infOccasionType_labelId] ON [infOccasionType] ([labelId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131193233_apiMigrationSchema')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190131193233_apiMigrationSchema', N'2.2.1-servicing-10028');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131194217_apiUserAmend')
BEGIN
    ALTER TABLE [Users] DROP CONSTRAINT [PK_Users];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131194217_apiUserAmend')
BEGIN
    EXEC sp_rename N'[Users]', N'datUser';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131194217_apiUserAmend')
BEGIN
    ALTER TABLE [datUser] ADD CONSTRAINT [PK_datUser] PRIMARY KEY ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190131194217_apiUserAmend')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190131194217_apiUserAmend', N'2.2.1-servicing-10028');
END;

GO

