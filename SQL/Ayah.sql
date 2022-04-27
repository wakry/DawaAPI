


USE [QURAN]
GO

/****** Object:  Table [dbo].[Ayah]    Script Date: 9/18/2021 2:24:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Ayah](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdInSurah] [int] NOT NULL,
	[PageNumber] [int] NOT NULL,
	[Text] [nvarchar](1192) NULL,
	[Text_Emlaey] [nvarchar](678) null,
	[Text_For_Html] [nvarchar](1188) null,
	[SurahId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Ayah]  WITH CHECK ADD FOREIGN KEY([SurahId])
REFERENCES [dbo].[Surah] ([Id])
GO


