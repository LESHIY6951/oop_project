USE [qwe]
GO

/****** Object:  Table [dbo].[order]    Script Date: 06.06.2023 20:20:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[order](
	[user_id] [int] NOT NULL,
	[item_id] [int] NOT NULL,
	[total_cost] [int] NULL,
	[card_num] [nvarchar](45) NULL,
	[CVV] [nvarchar](45) NULL,
	[card_name] [nvarchar](45) NULL,
	[data] [date] NULL,
 CONSTRAINT [PK_order_user_id] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC,
	[item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[order] ADD  DEFAULT (NULL) FOR [total_cost]
GO

ALTER TABLE [dbo].[order] ADD  DEFAULT (NULL) FOR [card_num]
GO

ALTER TABLE [dbo].[order] ADD  DEFAULT (NULL) FOR [CVV]
GO

ALTER TABLE [dbo].[order] ADD  DEFAULT (NULL) FOR [card_name]
GO

ALTER TABLE [dbo].[order] ADD  DEFAULT (NULL) FOR [data]
GO

ALTER TABLE [dbo].[order]  WITH NOCHECK ADD  CONSTRAINT [order$fk_ORDER_CART1] FOREIGN KEY([item_id], [user_id])
REFERENCES [dbo].[cart] ([item_id], [user_id])
GO

ALTER TABLE [dbo].[order] CHECK CONSTRAINT [order$fk_ORDER_CART1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'dbo.`order`' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'order'
GO

