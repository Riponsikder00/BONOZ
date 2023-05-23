
INSERT INTO [dbo].[Users]([LoginId],[Password],[IsTeamMember],[IsTempPassword],[Name],[ModifiedOn])
VALUES('BonozSuperAdmin','8GywMSVcDMZEsN4Bw0XK5KXOc9LKPs6s/jxUAvh6HlE=',1,0,'Software','05-05-2023')

INSERT INTO [dbo].[AppRoles]([Id],[Description],[Role]) VALUES (1,'Banaz Super Admin','SuperAdmin')
INSERT INTO [dbo].[AppRoles]([Id],[Description],[Role]) VALUES (2,'Banaz Admin','Admin')
INSERT INTO [dbo].[AppRoles]([Id],[Description],[Role]) VALUES (3,'Shop Owner','ShopOwner')
INSERT INTO [dbo].[AppRoles]([Id],[Description],[Role]) VALUES (4,'Customer','Customer')
INSERT INTO [dbo].[AppUserRoles] ([AppUserId], [AppRoleId]) VALUES(1,1)


CREATE TABLE [dbo].[AutoGen](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LastCode] [nvarchar](100) NOT NULL,
	[Type] [int] NOT NULL,
	[Description] [nvarchar](250) NULL
) ON [PRIMARY]
GO


