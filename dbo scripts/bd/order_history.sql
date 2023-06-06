USE [qwe]
GO

/****** Object:  Table [dbo].[order_history]    Script Date: 06.06.2023 20:20:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[order_history](
	[user_id] [int] NOT NULL,
	[item_id] [int] NOT NULL,
	[total_cost] [int] NULL,
	[date] [date] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[order_history] ADD  DEFAULT (NULL) FOR [total_cost]
GO

ALTER TABLE [dbo].[order_history] ADD  DEFAULT (NULL) FOR [date]
GO

ALTER TABLE [dbo].[order_history]  WITH NOCHECK ADD  CONSTRAINT [order_history$fk_ORDER_HISTORY_ORDER1] FOREIGN KEY([user_id], [item_id])
REFERENCES [dbo].[order] ([user_id], [item_id])
GO

ALTER TABLE [dbo].[order_history] CHECK CONSTRAINT [order_history$fk_ORDER_HISTORY_ORDER1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'dbo.order_history' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'order_history'
GO

