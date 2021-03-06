USE [GraduateDb]
GO
/****** Object:  Table [dbo].[DoctorTb]    Script Date: 24/07/2020 8:52:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoctorTb](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DoctorName] [nvarchar](100) NULL,
	[Description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectTb]    Script Date: 24/07/2020 8:52:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectTb](
	[projectId] [int] IDENTITY(1,1) NOT NULL,
	[DocId] [int] NULL,
	[ProjectName] [nvarchar](100) NOT NULL,
	[Projectcode] [nvarchar](15) NOT NULL,
	[Description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[projectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegisterTb]    Script Date: 24/07/2020 8:52:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegisterTb](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DateReg] [date] NULL,
	[StudentName] [nvarchar](100) NOT NULL,
	[StudentRegNo] [int] NOT NULL,
	[projectId] [int] NULL,
	[Description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DoctorTb] ON 
GO
INSERT [dbo].[DoctorTb] ([id], [DoctorName], [Description]) VALUES (2, N'سعد فودة', NULL)
GO
INSERT [dbo].[DoctorTb] ([id], [DoctorName], [Description]) VALUES (1002, N'نسرين نصر الدين', NULL)
GO
SET IDENTITY_INSERT [dbo].[DoctorTb] OFF
GO
SET IDENTITY_INSERT [dbo].[ProjectTb] ON 
GO
INSERT [dbo].[ProjectTb] ([projectId], [DocId], [ProjectName], [Projectcode], [Description]) VALUES (1, 2, N'قاعدة بيانات', N'ا.دل', NULL)
GO
INSERT [dbo].[ProjectTb] ([projectId], [DocId], [ProjectName], [Projectcode], [Description]) VALUES (2, 1002, N'الاقتصاد المحلي', N'ND1', NULL)
GO
SET IDENTITY_INSERT [dbo].[ProjectTb] OFF
GO
SET IDENTITY_INSERT [dbo].[RegisterTb] ON 
GO
INSERT [dbo].[RegisterTb] ([id], [DateReg], [StudentName], [StudentRegNo], [projectId], [Description]) VALUES (1, CAST(N'2020-01-10' AS Date), N'علي سعد', 8, 1, NULL)
GO
INSERT [dbo].[RegisterTb] ([id], [DateReg], [StudentName], [StudentRegNo], [projectId], [Description]) VALUES (3, CAST(N'2020-02-20' AS Date), N'asd', 0, 2, NULL)
GO
INSERT [dbo].[RegisterTb] ([id], [DateReg], [StudentName], [StudentRegNo], [projectId], [Description]) VALUES (1003, CAST(N'2020-01-01' AS Date), N'محمد احمد سعد', 4150, 2, NULL)
GO
INSERT [dbo].[RegisterTb] ([id], [DateReg], [StudentName], [StudentRegNo], [projectId], [Description]) VALUES (1004, CAST(N'2020-10-01' AS Date), N'mohamed', 2, 2, NULL)
GO
INSERT [dbo].[RegisterTb] ([id], [DateReg], [StudentName], [StudentRegNo], [projectId], [Description]) VALUES (1005, CAST(N'2021-12-01' AS Date), N'ahmed', 20, 1, NULL)
GO
INSERT [dbo].[RegisterTb] ([id], [DateReg], [StudentName], [StudentRegNo], [projectId], [Description]) VALUES (1008, CAST(N'2020-07-24' AS Date), N'asdasd', 123, 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[RegisterTb] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_DoctorTb]    Script Date: 24/07/2020 8:52:38 PM ******/
ALTER TABLE [dbo].[DoctorTb] ADD  CONSTRAINT [UC_DoctorTb] UNIQUE NONCLUSTERED 
(
	[DoctorName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__ProjectT__CA6BAE5FD8733A5B]    Script Date: 24/07/2020 8:52:38 PM ******/
ALTER TABLE [dbo].[ProjectTb] ADD UNIQUE NONCLUSTERED 
(
	[Projectcode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Register__1EAA418FD8EA45AA]    Script Date: 24/07/2020 8:52:38 PM ******/
ALTER TABLE [dbo].[RegisterTb] ADD UNIQUE NONCLUSTERED 
(
	[StudentRegNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Register__68AEF93FBA4CAC46]    Script Date: 24/07/2020 8:52:38 PM ******/
ALTER TABLE [dbo].[RegisterTb] ADD UNIQUE NONCLUSTERED 
(
	[StudentName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ProjectTb]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTb_DoctorTb] FOREIGN KEY([DocId])
REFERENCES [dbo].[DoctorTb] ([id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[ProjectTb] CHECK CONSTRAINT [FK_ProjectTb_DoctorTb]
GO
ALTER TABLE [dbo].[RegisterTb]  WITH CHECK ADD  CONSTRAINT [FK_RegisterTb_ProjectTb] FOREIGN KEY([projectId])
REFERENCES [dbo].[ProjectTb] ([projectId])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[RegisterTb] CHECK CONSTRAINT [FK_RegisterTb_ProjectTb]
GO
