CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `DocumentStatus` (
    `DocumentStatusId` char(36) COLLATE ascii_general_ci NOT NULL,
    `Label` varchar(60) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_DocumentStatus` PRIMARY KEY (`DocumentStatusId`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `DocumentTypes` (
    `DocumentTypeId` char(36) COLLATE ascii_general_ci NOT NULL,
    `Label` varchar(60) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_DocumentTypes` PRIMARY KEY (`DocumentTypeId`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `LateMissStatus` (
    `LateMissTypeId` char(36) COLLATE ascii_general_ci NOT NULL,
    `Label` varchar(60) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_LateMissStatus` PRIMARY KEY (`LateMissTypeId`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `LateMissTypes` (
    `LateMissTypeId` char(36) COLLATE ascii_general_ci NOT NULL,
    `Label` varchar(60) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_LateMissTypes` PRIMARY KEY (`LateMissTypeId`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `NotificationTypes` (
    `NotificationTypeId` char(36) COLLATE ascii_general_ci NOT NULL,
    `Label` varchar(60) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_NotificationTypes` PRIMARY KEY (`NotificationTypeId`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `ProfessionalStatus` (
    `IdProfessionalStatus` char(36) COLLATE ascii_general_ci NOT NULL,
    `Label` varchar(60) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_ProfessionalStatus` PRIMARY KEY (`IdProfessionalStatus`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Roles` (
    `RoleId` char(36) COLLATE ascii_general_ci NOT NULL,
    `Label` varchar(60) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_Roles` PRIMARY KEY (`RoleId`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `TrainingTypes` (
    `TrainingTypeId` char(36) COLLATE ascii_general_ci NOT NULL,
    `Label` varchar(60) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_TrainingTypes` PRIMARY KEY (`TrainingTypeId`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Notifications` (
    `NotificationId` char(36) COLLATE ascii_general_ci NOT NULL,
    `Date` datetime(6) NOT NULL,
    `IsRead` tinyint(1) NOT NULL,
    `NotificationTypeId` char(36) COLLATE ascii_general_ci NOT NULL,
    CONSTRAINT `PK_Notifications` PRIMARY KEY (`NotificationId`),
    CONSTRAINT `FK_Notifications_NotificationTypes_NotificationTypeId` FOREIGN KEY (`NotificationTypeId`) REFERENCES `NotificationTypes` (`NotificationTypeId`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `Users` (
    `UserId` char(36) COLLATE ascii_general_ci NOT NULL,
    `FirstName` varchar(60) CHARACTER SET utf8mb4 NOT NULL,
    `LastName` varchar(60) CHARACTER SET utf8mb4 NOT NULL,
    `Email` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Address` varchar(60) CHARACTER SET utf8mb4 NOT NULL,
    `PostCode` varchar(60) CHARACTER SET utf8mb4 NOT NULL,
    `City` varchar(60) CHARACTER SET utf8mb4 NOT NULL,
    `Country` varchar(60) CHARACTER SET utf8mb4 NOT NULL,
    `BirthDate` datetime(6) NOT NULL,
    `NativeCity` varchar(60) CHARACTER SET utf8mb4 NOT NULL,
    `NativeCountry` varchar(60) CHARACTER SET utf8mb4 NOT NULL,
    `PhoneNumber` longtext CHARACTER SET utf8mb4 NOT NULL,
    `ProfessionalStatusId` char(36) COLLATE ascii_general_ci NOT NULL,
    CONSTRAINT `PK_Users` PRIMARY KEY (`UserId`),
    CONSTRAINT `FK_Users_ProfessionalStatus_ProfessionalStatusId` FOREIGN KEY (`ProfessionalStatusId`) REFERENCES `ProfessionalStatus` (`IdProfessionalStatus`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `DocumentTypeXTrainingType` (
    `DocumentTypeXTrainingTypeId` char(36) COLLATE ascii_general_ci NOT NULL,
    `DocumentTypeId` char(36) COLLATE ascii_general_ci NOT NULL,
    `TrainingTypeId` char(36) COLLATE ascii_general_ci NOT NULL,
    `IsRequired` tinyint(1) NOT NULL,
    CONSTRAINT `PK_DocumentTypeXTrainingType` PRIMARY KEY (`DocumentTypeXTrainingTypeId`),
    CONSTRAINT `FK_DocumentTypeXTrainingType_DocumentTypes_DocumentTypeId` FOREIGN KEY (`DocumentTypeId`) REFERENCES `DocumentTypes` (`DocumentTypeId`) ON DELETE CASCADE,
    CONSTRAINT `FK_DocumentTypeXTrainingType_TrainingTypes_TrainingTypeId` FOREIGN KEY (`TrainingTypeId`) REFERENCES `TrainingTypes` (`TrainingTypeId`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `Trainings` (
    `TrainingId` char(36) COLLATE ascii_general_ci NOT NULL,
    `StartDate` datetime(6) NOT NULL,
    `EndDate` datetime(6) NOT NULL,
    `TrainingTypeId` char(36) COLLATE ascii_general_ci NOT NULL,
    CONSTRAINT `PK_Trainings` PRIMARY KEY (`TrainingId`),
    CONSTRAINT `FK_Trainings_TrainingTypes_TrainingTypeId` FOREIGN KEY (`TrainingTypeId`) REFERENCES `TrainingTypes` (`TrainingTypeId`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `Documents` (
    `DocumentId` char(36) COLLATE ascii_general_ci NOT NULL,
    `Label` varchar(60) CHARACTER SET utf8mb4 NOT NULL,
    `Path` longtext CHARACTER SET utf8mb4 NOT NULL,
    `UploadDate` datetime(6) NOT NULL,
    `DocumentTypeId` char(36) COLLATE ascii_general_ci NOT NULL,
    `UserId` char(36) COLLATE ascii_general_ci NOT NULL,
    CONSTRAINT `PK_Documents` PRIMARY KEY (`DocumentId`),
    CONSTRAINT `FK_Documents_DocumentTypes_DocumentTypeId` FOREIGN KEY (`DocumentTypeId`) REFERENCES `DocumentTypes` (`DocumentTypeId`) ON DELETE CASCADE,
    CONSTRAINT `FK_Documents_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`UserId`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `LateMisses` (
    `LateMissId` char(36) COLLATE ascii_general_ci NOT NULL,
    `DeclarationDate` datetime(6) NOT NULL,
    `StartDate` datetime(6) NOT NULL,
    `EndDate` datetime(6) NOT NULL,
    `LateMissTypeId` char(36) COLLATE ascii_general_ci NOT NULL,
    `UserId` char(36) COLLATE ascii_general_ci NOT NULL,
    CONSTRAINT `PK_LateMisses` PRIMARY KEY (`LateMissId`),
    CONSTRAINT `FK_LateMisses_LateMissTypes_LateMissTypeId` FOREIGN KEY (`LateMissTypeId`) REFERENCES `LateMissTypes` (`LateMissTypeId`) ON DELETE CASCADE,
    CONSTRAINT `FK_LateMisses_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`UserId`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `UserXNotification` (
    `UserXNotificationId` char(36) COLLATE ascii_general_ci NOT NULL,
    `UserId` char(36) COLLATE ascii_general_ci NOT NULL,
    `NotificationId` char(36) COLLATE ascii_general_ci NOT NULL,
    CONSTRAINT `PK_UserXNotification` PRIMARY KEY (`UserXNotificationId`),
    CONSTRAINT `FK_UserXNotification_Notifications_NotificationId` FOREIGN KEY (`NotificationId`) REFERENCES `Notifications` (`NotificationId`) ON DELETE CASCADE,
    CONSTRAINT `FK_UserXNotification_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`UserId`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `UserXRole` (
    `UserXRoleId` char(36) COLLATE ascii_general_ci NOT NULL,
    `UserId` char(36) COLLATE ascii_general_ci NOT NULL,
    `RoleId` char(36) COLLATE ascii_general_ci NOT NULL,
    CONSTRAINT `PK_UserXRole` PRIMARY KEY (`UserXRoleId`),
    CONSTRAINT `FK_UserXRole_Roles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `Roles` (`RoleId`) ON DELETE CASCADE,
    CONSTRAINT `FK_UserXRole_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`UserId`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `UserXTraining` (
    `UserXTrainingId` char(36) COLLATE ascii_general_ci NOT NULL,
    `UserId` char(36) COLLATE ascii_general_ci NOT NULL,
    `TrainingId` char(36) COLLATE ascii_general_ci NOT NULL,
    CONSTRAINT `PK_UserXTraining` PRIMARY KEY (`UserXTrainingId`),
    CONSTRAINT `FK_UserXTraining_Trainings_TrainingId` FOREIGN KEY (`TrainingId`) REFERENCES `Trainings` (`TrainingId`) ON DELETE CASCADE,
    CONSTRAINT `FK_UserXTraining_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`UserId`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `DocumentXDocumentStatus` (
    `DocumentXDocumentStatusId` char(36) COLLATE ascii_general_ci NOT NULL,
    `DocumentId` char(36) COLLATE ascii_general_ci NOT NULL,
    `DocumentStatusId` char(36) COLLATE ascii_general_ci NOT NULL,
    `StatusDate` datetime(6) NOT NULL,
    `Comment` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_DocumentXDocumentStatus` PRIMARY KEY (`DocumentXDocumentStatusId`),
    CONSTRAINT `FK_DocumentXDocumentStatus_DocumentStatus_DocumentStatusId` FOREIGN KEY (`DocumentStatusId`) REFERENCES `DocumentStatus` (`DocumentStatusId`) ON DELETE CASCADE,
    CONSTRAINT `FK_DocumentXDocumentStatus_Documents_DocumentId` FOREIGN KEY (`DocumentId`) REFERENCES `Documents` (`DocumentId`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `LateMissDocuments` (
    `LateMissDocumentId` char(36) COLLATE ascii_general_ci NOT NULL,
    `Path` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Label` varchar(60) CHARACTER SET utf8mb4 NOT NULL,
    `UploadDate` datetime(6) NOT NULL,
    `LateMissId` char(36) COLLATE ascii_general_ci NOT NULL,
    CONSTRAINT `PK_LateMissDocuments` PRIMARY KEY (`LateMissDocumentId`),
    CONSTRAINT `FK_LateMissDocuments_LateMisses_LateMissId` FOREIGN KEY (`LateMissId`) REFERENCES `LateMisses` (`LateMissId`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `LateMissXLateMissStatus` (
    `LateMissXLateMissStatusId` char(36) COLLATE ascii_general_ci NOT NULL,
    `LateMissId` char(36) COLLATE ascii_general_ci NOT NULL,
    `LateMissStatusId` char(36) COLLATE ascii_general_ci NOT NULL,
    CONSTRAINT `PK_LateMissXLateMissStatus` PRIMARY KEY (`LateMissXLateMissStatusId`),
    CONSTRAINT `FK_LateMissXLateMissStatus_LateMissStatus_LateMissStatusId` FOREIGN KEY (`LateMissStatusId`) REFERENCES `LateMissStatus` (`LateMissTypeId`) ON DELETE CASCADE,
    CONSTRAINT `FK_LateMissXLateMissStatus_LateMisses_LateMissId` FOREIGN KEY (`LateMissId`) REFERENCES `LateMisses` (`LateMissId`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE INDEX `IX_Documents_DocumentTypeId` ON `Documents` (`DocumentTypeId`);

CREATE INDEX `IX_Documents_UserId` ON `Documents` (`UserId`);

CREATE INDEX `IX_DocumentTypeXTrainingType_DocumentTypeId` ON `DocumentTypeXTrainingType` (`DocumentTypeId`);

CREATE INDEX `IX_DocumentTypeXTrainingType_TrainingTypeId` ON `DocumentTypeXTrainingType` (`TrainingTypeId`);

CREATE INDEX `IX_DocumentXDocumentStatus_DocumentId` ON `DocumentXDocumentStatus` (`DocumentId`);

CREATE INDEX `IX_DocumentXDocumentStatus_DocumentStatusId` ON `DocumentXDocumentStatus` (`DocumentStatusId`);

CREATE INDEX `IX_LateMissDocuments_LateMissId` ON `LateMissDocuments` (`LateMissId`);

CREATE INDEX `IX_LateMisses_LateMissTypeId` ON `LateMisses` (`LateMissTypeId`);

CREATE INDEX `IX_LateMisses_UserId` ON `LateMisses` (`UserId`);

CREATE INDEX `IX_LateMissXLateMissStatus_LateMissId` ON `LateMissXLateMissStatus` (`LateMissId`);

CREATE INDEX `IX_LateMissXLateMissStatus_LateMissStatusId` ON `LateMissXLateMissStatus` (`LateMissStatusId`);

CREATE INDEX `IX_Notifications_NotificationTypeId` ON `Notifications` (`NotificationTypeId`);

CREATE INDEX `IX_Trainings_TrainingTypeId` ON `Trainings` (`TrainingTypeId`);

CREATE INDEX `IX_Users_ProfessionalStatusId` ON `Users` (`ProfessionalStatusId`);

CREATE INDEX `IX_UserXNotification_NotificationId` ON `UserXNotification` (`NotificationId`);

CREATE INDEX `IX_UserXNotification_UserId` ON `UserXNotification` (`UserId`);

CREATE INDEX `IX_UserXRole_RoleId` ON `UserXRole` (`RoleId`);

CREATE INDEX `IX_UserXRole_UserId` ON `UserXRole` (`UserId`);

CREATE INDEX `IX_UserXTraining_TrainingId` ON `UserXTraining` (`TrainingId`);

CREATE INDEX `IX_UserXTraining_UserId` ON `UserXTraining` (`UserId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20240415091333_DatabaseCreation', '8.0.4');

COMMIT;

