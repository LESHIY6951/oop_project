USE [qwe]
GO

/****** Object:  Table [dbo].[forum]    Script Date: 06.06.2023 20:20:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[forum](
	[forum_id] [int] IDENTITY(1,1) NOT NULL,
	[cert_id] [int] NOT NULL,
	[name] [nvarchar](45) NULL,
	[score] [int] NULL,
	[text] [nvarchar](45) NULL,
	[likes] [int] NULL,
	[dislikes] [int] NULL,
 CONSTRAINT [PK_forum_1] PRIMARY KEY NONCLUSTERED 
(
	[forum_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [forum$cert_id_UNIQUE] UNIQUE CLUSTERED 
(
	[cert_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[forum] ADD  CONSTRAINT [DF__forum__name__01142BA1]  DEFAULT (NULL) FOR [name]
GO

ALTER TABLE [dbo].[forum] ADD  CONSTRAINT [DF__forum__score__02084FDA]  DEFAULT (NULL) FOR [score]
GO

ALTER TABLE [dbo].[forum] ADD  CONSTRAINT [DF__forum__text__02FC7413]  DEFAULT (NULL) FOR [text]
GO

ALTER TABLE [dbo].[forum] ADD  CONSTRAINT [DF__forum__likes__03F0984C]  DEFAULT (NULL) FOR [likes]
GO

ALTER TABLE [dbo].[forum] ADD  CONSTRAINT [DF__forum__dislikes__04E4BC85]  DEFAULT (NULL) FOR [dislikes]
GO

ALTER TABLE [dbo].[forum]  WITH NOCHECK ADD  CONSTRAINT [forum$fk_FORUM_CERTIFICATE1] FOREIGN KEY([cert_id])
REFERENCES [dbo].[certificate] ([cert_id])
GO

ALTER TABLE [dbo].[forum] CHECK CONSTRAINT [forum$fk_FORUM_CERTIFICATE1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'dbo.forum' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'forum'
GO

