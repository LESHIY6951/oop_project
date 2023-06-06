USE [qwe]
GO

/****** Object:  Table [dbo].[cart]    Script Date: 06.06.2023 20:19:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[cart](
	[user_id] [int] NOT NULL,
	[item_id] [int] NOT NULL,
	[total_cost] [int] NULL,
 CONSTRAINT [PK_cart_item_id] PRIMARY KEY CLUSTERED 
(
	[item_id] ASC,
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[cart] ADD  DEFAULT (NULL) FOR [total_cost]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'dbo.cart' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cart'
GO

