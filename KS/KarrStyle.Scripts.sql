USE [KarrStyle]
GO
/****** Object:  StoredProcedure [dbo].[ks_AddEditProducts]    Script Date: 7/3/2014 6:35:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author		: SG
-- Create date	: 2:59 PM April/12/2014
-- Description	: Add/Edit Products.
-- =============================================
CREATE PROCEDURE [dbo].[ks_AddEditProducts]
	@ProductID bigint=0,
	@ProductTypeID int,										
	@ProductName nvarchar(500),								
	@ProductDesc nvarchar(max),								
	@Quantity bigint,										
	@Createdby bigint,										
	@SuccessID bigint output								 
AS
BEGIN
	SET NOCOUNT ON;
	IF(@ProductID = 0)
		BEGIN
			INSERT INTO [tbl_Products]
				   ([ProductTypeID]
				   ,[ProductName]
				   ,[ProductDesc]
				   ,[Quantity]
				   ,[Createdby])
			 VALUES
				   (@ProductTypeID
				   ,@ProductName 
				   ,@ProductDesc 
				   ,@Quantity 
				   ,@Createdby)

				   set @SuccessID = IDENT_CURRENT('[tbl_Products]')

		END
	else IF(@ProductID <> 0)
		BEGIN
			UPDATE [dbo].[tbl_Products]
			   SET [ProductTypeID]	= @ProductTypeID
				  ,[ProductName]	= @ProductName 
				  ,[ProductDesc]	= @ProductDesc 
				  ,[Quantity]		= @Quantity 
				  ,[UpdatedBy]		= @Createdby
				  ,[UpdatedOn]		= GETDATE()
			 WHERE ProductID = @ProductID

				   set @SuccessID = @ProductID

		END



END

GO
/****** Object:  StoredProcedure [dbo].[ks_GetAllProducts]    Script Date: 7/3/2014 6:35:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author		: SG
-- Create date	: 4:39 PM April/12/2014
-- Description	: Get All Products
-- =============================================
CREATE PROCEDURE [dbo].[ks_GetAllProducts]
	@ProductID int=0,
	@Page int = 1,
	@RecsPerPage int = 10,
	@NoOfPages int = 0 OUTPUT,
	@NoofRec int = 0 OUTPUT , 
	@ShortOrder AS NVARCHAR(20)='',
	@ShortBy AS NVARCHAR(25)=''    

	
AS
BEGIN
	
	SET NOCOUNT ON;

	DECLARE @StartIdx INT  
  ,@EndIdx INT  
 SET @StartIdx = (@Page - 1) * @RecsPerPage + 1  
 SET @EndIdx = (@Page * @RecsPerPage)  



	SELECT        ProductID, ProductTypeID,
				  (select top 1 ProductType from tbl_ProductType WHERE TypeID = tbl_Products.ProductTypeID)ProductType,
				  ProductName, ProductDesc, Quantity, CreatedOn
	,ROW_NUMBER() OVER (  
   ORDER BY 
     CASE WHEN @ShortBy = 'ProductName' AND @ShortOrder = 'ASC' THEN ProductName END ASC  
    ,CASE WHEN @ShortBy = 'ProductName' AND @ShortOrder = 'DESC' THEN ProductName END DESC
	
	,CASE WHEN @ShortBy = 'Quantity' AND @ShortOrder = 'ASC' THEN Quantity END ASC  
    ,CASE WHEN @ShortBy = 'Quantity' AND @ShortOrder = 'DESC' THEN Quantity END DESC 

	,CASE WHEN @ShortBy = 'CreatedOn' AND @ShortOrder = 'ASC' THEN CreatedOn END ASC  
    ,CASE WHEN @ShortBy = 'CreatedOn' AND @ShortOrder = 'DESC' THEN CreatedOn END DESC 
	
	,CASE   WHEN @ShortBy IS NULL  OR @ShortBy = ''  THEN CreatedOn  END DESC  
	) ID
   INTO #temp  

	FROM  tbl_Products
	where isDeleted=0 and (@ProductID = 0 or ProductID = @ProductID)
    

	SELECT *  
 FROM #temp  
 WHERE id >= CONVERT(VARCHAR(9), @StartIdx)  
  AND id <= CONVERT(VARCHAR(9), @EndIdx);  

  SET @NoofRec = (  
   SELECT COUNT(1)  
   FROM #temp  
   );  
 SET @NoOfPages = (  
   (  
    SELECT COUNT(1)  
    FROM #temp  
    ) + @RecsPerPage - 1  
   ) / @RecsPerPage;  
 SET NOCOUNT OFF  

END

GO
/****** Object:  StoredProcedure [dbo].[ks_GetProductTypes]    Script Date: 7/3/2014 6:35:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author		: SG
-- Create date	: 2:46 PM 4/14/2014
-- Description	: Get Product Types
-- =============================================
CREATE PROCEDURE  [dbo].[ks_GetProductTypes]
	@ProductTypeID int=0
AS
BEGIN
	
	SET NOCOUNT ON;

    select TypeID,ProductType from tbl_ProductType where isDeleted=0 
	and (@ProductTypeID = 0 or @ProductTypeID = TypeID)
END

GO
/****** Object:  StoredProcedure [dbo].[ks_ValidateUser]    Script Date: 7/3/2014 6:35:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author		: SG
-- Create date	: 10/March/14
-- Description	: Validate the user accessibility to the system.
-- =============================================
CREATE PROCEDURE [dbo].[ks_ValidateUser]
@UserName nvarchar(500),
@Password nvarchar(500)

AS
BEGIN
	SET NOCOUNT ON;

	SELECT        UserID, UserName, UserPassword, Email, FirstName, LastName, DOB, Address, State, Country, Zip, Phone1, isAdmin, Phone2, isDeleted
FROM            tbl_Users where UserName = @UserName and UserPassword = @Password and isDeleted = 0
END

GO
/****** Object:  Table [dbo].[tbl_Products]    Script Date: 7/3/2014 6:35:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Products](
	[ProductID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductTypeID] [bigint] NULL,
	[ProductName] [nvarchar](500) NULL,
	[ProductDesc] [nvarchar](max) NULL,
	[Quantity] [bigint] NOT NULL CONSTRAINT [DF_tbl_Products_Quantity]  DEFAULT ((0)),
	[Createdby] [bigint] NOT NULL CONSTRAINT [DF_tbl_Products_Createdby]  DEFAULT ((1)),
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_tbl_Products_CreatedOn]  DEFAULT (getdate()),
	[UpdatedBy] [bigint] NOT NULL CONSTRAINT [DF_tbl_Products_UpdatedBy]  DEFAULT ((1)),
	[UpdatedOn] [datetime] NOT NULL CONSTRAINT [DF_tbl_Products_UpdatedOn]  DEFAULT (getdate()),
	[isDeleted] [int] NOT NULL CONSTRAINT [DF_tbl_Products_isDeleted]  DEFAULT ((0)),
 CONSTRAINT [PK_tbl_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_ProductSamples]    Script Date: 7/3/2014 6:35:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ProductSamples](
	[SampleID] [bigint] NOT NULL,
	[ProductID] [bigint] NOT NULL,
	[FilePath] [nvarchar](max) NULL,
	[FileDesc] [nvarchar](max) NULL,
	[Createdby] [bigint] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [bigint] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
	[isDeleted] [int] NOT NULL,
 CONSTRAINT [PK_tbl_ProductSamples] PRIMARY KEY CLUSTERED 
(
	[SampleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_ProductType]    Script Date: 7/3/2014 6:35:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ProductType](
	[TypeID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductType] [nvarchar](500) NULL,
	[Createdby] [bigint] NOT NULL CONSTRAINT [DF_tbl_ProductType_Createdby]  DEFAULT ((1)),
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_tbl_ProductType_CreatedOn]  DEFAULT (getdate()),
	[UpdatedBy] [bigint] NOT NULL CONSTRAINT [DF_tbl_ProductType_UpdatedBy]  DEFAULT ((1)),
	[UpdatedOn] [datetime] NOT NULL CONSTRAINT [DF_tbl_ProductType_UpdatedOn]  DEFAULT (getdate()),
	[isDeleted] [int] NOT NULL CONSTRAINT [DF_tbl_ProductType_isDeleted]  DEFAULT ((0)),
 CONSTRAINT [PK_tbl_ProductType] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Users]    Script Date: 7/3/2014 6:35:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Users](
	[UserID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](500) NULL,
	[UserPassword] [nvarchar](500) NULL,
	[Email] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](500) NULL,
	[LastName] [nvarchar](500) NULL,
	[DOB] [date] NULL,
	[Address] [nvarchar](max) NULL,
	[State] [int] NULL,
	[Country] [int] NULL,
	[Zip] [nvarchar](50) NULL,
	[Phone1] [nvarchar](50) NULL,
	[Phone2] [nvarchar](50) NULL,
	[isAdmin] [int] NOT NULL CONSTRAINT [DF_tbl_Users_isAdmin]  DEFAULT ((0)),
	[Createdby] [bigint] NOT NULL CONSTRAINT [DF_tbl_Users_Createdby]  DEFAULT ((1)),
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_tbl_Users_CreatedOn]  DEFAULT (getdate()),
	[UpdatedBy] [bigint] NOT NULL CONSTRAINT [DF_tbl_Users_UpdatedBy]  DEFAULT ((1)),
	[UpdatedOn] [datetime] NOT NULL CONSTRAINT [DF_tbl_Users_UpdatedOn]  DEFAULT (getdate()),
	[isDeleted] [int] NOT NULL CONSTRAINT [DF_tbl_Users_isDeleted]  DEFAULT ((0)),
 CONSTRAINT [PK_tbl_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tbl_Products] ON 

GO
INSERT [dbo].[tbl_Products] ([ProductID], [ProductTypeID], [ProductName], [ProductDesc], [Quantity], [Createdby], [CreatedOn], [UpdatedBy], [UpdatedOn], [isDeleted]) VALUES (1, 1, N'abc', N'abcdefgh', 1, 1, CAST(N'2014-04-12 18:19:08.823' AS DateTime), 1, CAST(N'2014-04-12 18:19:08.823' AS DateTime), 0)
GO
INSERT [dbo].[tbl_Products] ([ProductID], [ProductTypeID], [ProductName], [ProductDesc], [Quantity], [Createdby], [CreatedOn], [UpdatedBy], [UpdatedOn], [isDeleted]) VALUES (2, 1, N'abcqwe', N'', 1, 1, CAST(N'2014-04-14 18:22:07.523' AS DateTime), 1, CAST(N'2014-04-14 18:22:07.523' AS DateTime), 0)
GO
INSERT [dbo].[tbl_Products] ([ProductID], [ProductTypeID], [ProductName], [ProductDesc], [Quantity], [Createdby], [CreatedOn], [UpdatedBy], [UpdatedOn], [isDeleted]) VALUES (3, 1, N'asda2q3w', N'', 4, 1, CAST(N'2014-04-14 18:27:50.180' AS DateTime), 1, CAST(N'2014-04-14 18:27:50.180' AS DateTime), 0)
GO
INSERT [dbo].[tbl_Products] ([ProductID], [ProductTypeID], [ProductName], [ProductDesc], [Quantity], [Createdby], [CreatedOn], [UpdatedBy], [UpdatedOn], [isDeleted]) VALUES (4, 4, N'4564', N'', 3, 1, CAST(N'2014-04-14 18:28:50.947' AS DateTime), 1, CAST(N'2014-04-14 18:28:50.947' AS DateTime), 0)
GO
INSERT [dbo].[tbl_Products] ([ProductID], [ProductTypeID], [ProductName], [ProductDesc], [Quantity], [Createdby], [CreatedOn], [UpdatedBy], [UpdatedOn], [isDeleted]) VALUES (5, 4, N'4564', N'', 3, 1, CAST(N'2014-04-14 18:29:31.570' AS DateTime), 1, CAST(N'2014-04-14 18:29:31.570' AS DateTime), 0)
GO
INSERT [dbo].[tbl_Products] ([ProductID], [ProductTypeID], [ProductName], [ProductDesc], [Quantity], [Createdby], [CreatedOn], [UpdatedBy], [UpdatedOn], [isDeleted]) VALUES (6, 2, N'123', N'', 2, 1, CAST(N'2014-04-14 18:29:40.047' AS DateTime), 1, CAST(N'2014-04-14 18:29:40.047' AS DateTime), 0)
GO
INSERT [dbo].[tbl_Products] ([ProductID], [ProductTypeID], [ProductName], [ProductDesc], [Quantity], [Createdby], [CreatedOn], [UpdatedBy], [UpdatedOn], [isDeleted]) VALUES (7, 3, N'qwe', N'', 3, 1, CAST(N'2014-04-14 18:29:52.400' AS DateTime), 1, CAST(N'2014-04-14 18:29:52.400' AS DateTime), 0)
GO
INSERT [dbo].[tbl_Products] ([ProductID], [ProductTypeID], [ProductName], [ProductDesc], [Quantity], [Createdby], [CreatedOn], [UpdatedBy], [UpdatedOn], [isDeleted]) VALUES (8, 3, N'qwe', N'', 3, 1, CAST(N'2014-04-14 18:31:02.453' AS DateTime), 1, CAST(N'2014-04-14 18:31:02.453' AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[tbl_Products] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_ProductType] ON 

GO
INSERT [dbo].[tbl_ProductType] ([TypeID], [ProductType], [Createdby], [CreatedOn], [UpdatedBy], [UpdatedOn], [isDeleted]) VALUES (1, N'Lights', 1, CAST(N'2014-04-14 14:51:44.910' AS DateTime), 1, CAST(N'2014-04-14 14:51:44.910' AS DateTime), 0)
GO
INSERT [dbo].[tbl_ProductType] ([TypeID], [ProductType], [Createdby], [CreatedOn], [UpdatedBy], [UpdatedOn], [isDeleted]) VALUES (2, N'Perfume', 1, CAST(N'2014-04-14 14:52:23.903' AS DateTime), 1, CAST(N'2014-04-14 14:52:23.903' AS DateTime), 0)
GO
INSERT [dbo].[tbl_ProductType] ([TypeID], [ProductType], [Createdby], [CreatedOn], [UpdatedBy], [UpdatedOn], [isDeleted]) VALUES (3, N'Mats', 1, CAST(N'2014-04-14 14:57:05.283' AS DateTime), 1, CAST(N'2014-04-14 14:57:05.283' AS DateTime), 0)
GO
INSERT [dbo].[tbl_ProductType] ([TypeID], [ProductType], [Createdby], [CreatedOn], [UpdatedBy], [UpdatedOn], [isDeleted]) VALUES (4, N'Polish', 1, CAST(N'2014-04-14 14:57:15.533' AS DateTime), 1, CAST(N'2014-04-14 14:57:15.533' AS DateTime), 0)
GO
INSERT [dbo].[tbl_ProductType] ([TypeID], [ProductType], [Createdby], [CreatedOn], [UpdatedBy], [UpdatedOn], [isDeleted]) VALUES (5, N'Speakers', 1, CAST(N'2014-04-14 14:57:28.660' AS DateTime), 1, CAST(N'2014-04-14 14:57:28.660' AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[tbl_ProductType] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Users] ON 

GO
INSERT [dbo].[tbl_Users] ([UserID], [UserName], [UserPassword], [Email], [FirstName], [LastName], [DOB], [Address], [State], [Country], [Zip], [Phone1], [Phone2], [isAdmin], [Createdby], [CreatedOn], [UpdatedBy], [UpdatedOn], [isDeleted]) VALUES (1, N'admin', N'kVafdwjZ7bAXCSAqew+oKEGbe3DnZV0X30eiKSpy4+g=', N'admin@KarrStyle.com', N'Admin', N'Name', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, CAST(N'2014-03-31 17:28:39.717' AS DateTime), 1, CAST(N'2014-03-31 17:28:39.717' AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[tbl_Users] OFF
GO
ALTER TABLE [dbo].[tbl_ProductSamples] ADD  CONSTRAINT [DF_tbl_ProductSamples_ProductID]  DEFAULT ((0)) FOR [ProductID]
GO
ALTER TABLE [dbo].[tbl_ProductSamples] ADD  CONSTRAINT [DF_tbl_ProductSamples_Createdby]  DEFAULT ((1)) FOR [Createdby]
GO
ALTER TABLE [dbo].[tbl_ProductSamples] ADD  CONSTRAINT [DF_tbl_ProductSamples_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[tbl_ProductSamples] ADD  CONSTRAINT [DF_tbl_ProductSamples_UpdatedBy]  DEFAULT ((1)) FOR [UpdatedBy]
GO
ALTER TABLE [dbo].[tbl_ProductSamples] ADD  CONSTRAINT [DF_tbl_ProductSamples_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[tbl_ProductSamples] ADD  CONSTRAINT [DF_tbl_ProductSamples_isDeleted]  DEFAULT ((0)) FOR [isDeleted]
GO
