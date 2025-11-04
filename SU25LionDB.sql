USE master
GO

CREATE DATABASE SU25LionDB
GO

USE SU25LionDB
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LionAccount](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](100) NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_LionAccount] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LionProfile](
	[LionProfileId] [int] IDENTITY(1,1) NOT NULL,
	[LionTypeId] [int] NOT NULL,
	[LionName] [nvarchar](150) NOT NULL,
	[Weight] [float] NOT NULL,
	[Characteristics] [nvarchar](2000) NOT NULL,
	[Warning] [nvarchar](1500) NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_LionProfile] PRIMARY KEY CLUSTERED 
(
	[LionProfileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LionType](
	[LionTypeId] [int] IDENTITY(1,1) NOT NULL,
	[LionTypeName] [nvarchar](250) NULL,
	[Origin] [nvarchar](250) NULL,
	[Description] [nvarchar](1000) NULL,
 CONSTRAINT [PK_LionType] PRIMARY KEY CLUSTERED 
(
	[LionTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[LionAccount] ON 
INSERT [dbo].[LionAccount] ([AccountID], [UserName], [Password], [FullName], [Email], [Phone], [RoleId]) VALUES (2, N'manager', N'@1', N'manager', N'manager@lion.com', N'09011223440', 2)
INSERT [dbo].[LionAccount] ([AccountID], [UserName], [Password], [FullName], [Email], [Phone], [RoleId]) VALUES (3, N'staff', N'@1', N'staff', N'staff@lion.com', N'09011223450', 3)
SET IDENTITY_INSERT [dbo].[LionAccount] OFF
GO
SET IDENTITY_INSERT [dbo].[LionProfile] ON 

INSERT [dbo].[LionProfile] ([LionProfileId], [LionTypeId], [LionName], [Weight], [Characteristics], [Warning], [ModifiedDate]) VALUES (1, 1, N'Panthera leo persica', 120, N'The Asiatic lion is smaller than the largest of the African lions but is similar in size to the Central African lion. The weight of adult male Asiatic lions ranges between 160 kg and 190 kg while that of females ranges from 110 kg to 120 kg', N'These lions are classified as endangered by the IUCN', CAST(N'2025-03-01T00:00:00.000' AS DateTime))
INSERT [dbo].[LionProfile] ([LionProfileId], [LionTypeId], [LionName], [Weight], [Characteristics], [Warning], [ModifiedDate]) VALUES (2, 1, N'Africancial', 110, N' A longitudinal fold of skin running along the belly is the striking morphological feature that helps in the identification of the Asiatic lion. The fur color of the Asiatic lion ranges from ruddy-tawny, buffish-gray or sandy to heavily speckled with black', N'These lions are classified as endangered by the IUCN', CAST(N'2025-03-01T00:00:00.000' AS DateTime))
INSERT [dbo].[LionProfile] ([LionProfileId], [LionTypeId], [LionName], [Weight], [Characteristics], [Warning], [ModifiedDate]) VALUES (3, 1, N'Asiaticial', 100, N'The fur color of the Asiatic lion ranges from ruddy-tawny, buffish-gray or sandy to heavily speckled with black. The lions have a moderate mane growth unlike the African subspecies, and their ears are always visible', N'These lions are classified as endangered by the IUCN', CAST(N'2025-03-01T00:00:00.000' AS DateTime))
INSERT [dbo].[LionProfile] ([LionProfileId], [LionTypeId], [LionName], [Weight], [Characteristics], [Warning], [ModifiedDate]) VALUES (4, 2, N'Melanochaita', 130, N'The Ethiopian lion or the Abyssinian lion or the Addis Ababa lion (Panthera leo roosevelti) is a type of lion that though originally considered to be the East African lion', N'These lions are classified as endangered by the IUCN', CAST(N'2025-03-01T00:00:00.000' AS DateTime))
INSERT [dbo].[LionProfile] ([LionProfileId], [LionTypeId], [LionName], [Weight], [Characteristics], [Warning], [ModifiedDate]) VALUES (5, 2, N'Ababa', 90, N'Ethiopian lions have darker manes and smaller bodies compared to other lion subspecies, but this could also be the result of living in captivity', N'These lions are classified as endangered by the IUCN', CAST(N'2025-03-01T00:00:00.000' AS DateTime))
INSERT [dbo].[LionProfile] ([LionProfileId], [LionTypeId], [LionName], [Weight], [Characteristics], [Warning], [ModifiedDate]) VALUES (6, 2, N'Addis', 90, N'The lion that though originally considered to be the East African lion was classified as a separate subspecies after phenotypic and genotypic analysis on lions kept in captivity in the Addis Ababa''s zoo', N'These lions are classified as endangered by the IUCN', CAST(N'2025-03-01T00:00:00.000' AS DateTime))
INSERT [dbo].[LionProfile] ([LionProfileId], [LionTypeId], [LionName], [Weight], [Characteristics], [Warning], [ModifiedDate]) VALUES (7, 3, N'Kenyalia', 100, N'The Masai lions have less curved backs and longer legs than other subspecies of lion. Moderate tufts of hair are present in the knee joints of males', N'These lions are classified as endangered by the IUCN', CAST(N'2025-03-01T00:00:00.000' AS DateTime))
INSERT [dbo].[LionProfile] ([LionProfileId], [LionTypeId], [LionName], [Weight], [Characteristics], [Warning], [ModifiedDate]) VALUES (8, 3, N'Mozambique', 120, N'The manes of the Masai lion appear to be combed backwards, and older males have fuller manes than the younger ones', N'These lions are classified as endangered by the IUCN', CAST(N'2025-03-01T00:00:00.000' AS DateTime))
INSERT [dbo].[LionProfile] ([LionProfileId], [LionTypeId], [LionName], [Weight], [Characteristics], [Warning], [ModifiedDate]) VALUES (9, 3, N'Tanzania', 120, N'Male Masai lions living in highlands above 2,600 feet, and have heavier manes than those living in the lowland areas. Male Masai lions attain a length between 8.2 feet and 9.8 feet. Lionesses are smaller with length ranging from 7.5 feet to 8.5 feet', N'These lions are classified as endangered by the IUCN', CAST(N'2025-03-01T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[LionProfile] OFF
GO
SET IDENTITY_INSERT [dbo].[LionType] ON 

INSERT [dbo].[LionType] ([LionTypeId], [LionTypeName], [Origin], [Description]) VALUES (1, N'Asiatic Lion', N'Turkey', N'The Asiatic lion or the Indian lion (Panthera leo persica) though once widespread from Turkey across Southwest Asia to the Indian subcontinent, is currently confined to the Gir National Park and Wildlife Sanctuary in the Indian state of Gujarat. Only about 523 of this type of lion remain in this forest.')
INSERT [dbo].[LionType] ([LionTypeId], [LionTypeName], [Origin], [Description]) VALUES (2, N'Ethiopian Lion', N'Ethiopi', N'The Ethiopian lion or the Abyssinian lion or the Addis Ababa lion (Panthera leo roosevelti) is a type of lion that though originally considered to be the East African lion was classified as a separate subspecies after phenotypic and genotypic analysis on lions kept in captivity in the Addis Ababa''s zoo')
INSERT [dbo].[LionType] ([LionTypeId], [LionTypeName], [Origin], [Description]) VALUES (3, N'Masai Lion', N'Kenya', N'The East African lion or the Masai lion (Panthera leo nubica) is found in East Africa where it occurs in the countries of Kenya, Ethiopia, Mozambique, and Tanzania')
SET IDENTITY_INSERT [dbo].[LionType] OFF
GO
ALTER TABLE [dbo].[LionProfile]  WITH CHECK ADD  CONSTRAINT [FK_LionProfile_LionType] FOREIGN KEY([LionTypeId])
REFERENCES [dbo].[LionType] ([LionTypeId])
GO
ALTER TABLE [dbo].[LionProfile] CHECK CONSTRAINT [FK_LionProfile_LionType]
GO