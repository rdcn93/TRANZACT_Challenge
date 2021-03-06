USE [tranzact_challenge]
GO
/****** Object:  StoredProcedure [dbo].[GetPremiers]    Script Date: 13/02/2022 01:10:00 ******/
DROP PROCEDURE IF EXISTS [dbo].[GetPremiers]
GO
/****** Object:  Table [dbo].[tb_state]    Script Date: 13/02/2022 01:10:00 ******/
DROP TABLE IF EXISTS [dbo].[tb_state]
GO
/****** Object:  Table [dbo].[tb_premium]    Script Date: 13/02/2022 01:10:00 ******/
DROP TABLE IF EXISTS [dbo].[tb_premium]
GO
/****** Object:  Table [dbo].[tb_plan]    Script Date: 13/02/2022 01:10:00 ******/
DROP TABLE IF EXISTS [dbo].[tb_plan]
GO
/****** Object:  Table [dbo].[tb_period]    Script Date: 13/02/2022 01:10:00 ******/
DROP TABLE IF EXISTS [dbo].[tb_period]
GO
/****** Object:  Table [dbo].[tb_period]    Script Date: 13/02/2022 01:10:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_period](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](10) NULL,
	[Text] [nvarchar](20) NULL,
	[Monthly] [int] NULL,
	[Annual] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_plan]    Script Date: 13/02/2022 01:10:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_plan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](10) NULL,
	[Text] [nvarchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_premium]    Script Date: 13/02/2022 01:10:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_premium](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Carrier] [nvarchar](10) NULL,
	[Plan] [nvarchar](10) NULL,
	[State] [nvarchar](10) NULL,
	[MonthOfBirth] [nvarchar](10) NULL,
	[Age] [nvarchar](10) NULL,
	[PremiumAmount] [money] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_state]    Script Date: 13/02/2022 01:10:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_state](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](10) NULL,
	[Text] [nvarchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[GetPremiers]    Script Date: 13/02/2022 01:10:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Raul Dario Castañeda Najar
-- Create date: <Create Date,,>
-- Description:	Procedure to get the value of premier
-- =============================================
CREATE PROCEDURE [dbo].[GetPremiers]
	@MonthOfBirth AS varchar(15), 
	@State AS varchar(10),
	@Age AS int,
	@Plan AS varchar(1),
	@Period AS varchar(1)
AS
BEGIN
	SET NOCOUNT ON;

    SELECT *,  
		(P.PremiumAmount * 1) AS Annual,
		(P.PremiumAmount * 1) AS Monthly
	FROM dbo.tb_premium P
	WHERE
	(P.[Plan] like '%'+ @Plan + '%') AND
	P.[State] = (CASE WHEN P.[State] = '*' THEN P.[State] ELSE @State END) AND
	P.[MonthOfBirth] = (CASE WHEN P.[MonthOfBirth] = '*' THEN P.[MonthOfBirth] ELSE @MonthOfBirth END)

END
GO


-- INSERTS

INSERT INTO dbo.tb_premium VALUES ('Qwerty','A','NY','September','21-45',150.00)
INSERT INTO dbo.tb_premium VALUES ('Qwerty','B','NY','January','46-65',200.50)
INSERT INTO dbo.tb_premium VALUES ('Qwerty','A, C','NY','*','18-65',120.99)
INSERT INTO dbo.tb_premium VALUES ('Qwerty','A','AL','November','18-65',85.5)
INSERT INTO dbo.tb_premium VALUES ('Qwerty','C','AL','*','18-65',100.00)
INSERT INTO dbo.tb_premium VALUES ('Qwerty','A','AK','December','65+',175.20)
INSERT INTO dbo.tb_premium VALUES ('Qwerty','A','AK','December','18-64',125.16)
INSERT INTO dbo.tb_premium VALUES ('Qwerty','B','AK','*','18-65',100.80)
INSERT INTO dbo.tb_premium VALUES ('Qwerty','A, C','*','*','18-65',90.00)
INSERT INTO dbo.tb_premium VALUES ('Asdf','A','NY','October','21-45',150.00)
INSERT INTO dbo.tb_premium VALUES ('Asdf','B','NY','January','46-65',184.50)
INSERT INTO dbo.tb_premium VALUES ('Asdf','A','NY','*','18-65',129.95)
INSERT INTO dbo.tb_premium VALUES ('Asdf','A','AL','November','18-65',84.5)
INSERT INTO dbo.tb_premium VALUES ('Asdf','B','WY','*','18-65',100.00)
INSERT INTO dbo.tb_premium VALUES ('Asdf','B, C','AK','*','18-65',100.80)
INSERT INTO dbo.tb_premium VALUES ('Asdf','A, C','*','*','18-65',89.99)

INSERT INTO dbo.tb_state VALUES ('AL','AL - Alabama')
INSERT INTO dbo.tb_state VALUES ('AK','AK - Alaska')
INSERT INTO dbo.tb_state VALUES ('NY','NY - New York')
INSERT INTO dbo.tb_state VALUES ('WY','WY - Wyoming')

INSERT INTO dbo.tb_plan VALUES ('A','A')
INSERT INTO dbo.tb_plan VALUES ('B','B')
INSERT INTO dbo.tb_plan VALUES ('C','C')

INSERT INTO dbo.tb_period VALUES ('M','Monthly',1,12)
INSERT INTO dbo.tb_period VALUES ('Q','Quarterly',3,4)
INSERT INTO dbo.tb_period VALUES ('S','Semi-Annual',6,2)
INSERT INTO dbo.tb_period VALUES ('A','Annual',12,1)