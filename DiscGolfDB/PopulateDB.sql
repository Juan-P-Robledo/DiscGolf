/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will populate the DB.				
--------------------------------------------------------------------------------------
*/
USE [DiscGolfDatabase]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (1, N'None')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (2, N'Putter')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (3, N'Midrange')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (4, N'Fairway')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (5, N'Driver')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (6, N'Bag')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (7, N'Retriever')
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([ProductID], [VideoID], [Code], [Name], [Brand], [Price], [Image], [Description], [CategoryID]) VALUES (1002, NULL, N'M1', N'Fuse', N'Latitude 64', CAST(10.00 AS Decimal(18, 2)), N'https://cdn.ultiworld.com/wordpress/wp-content/uploads/2020/12/Fuse-1024x1024.jpg', N'This a used Understable disc', 3)
GO
INSERT [dbo].[Products] ([ProductID], [VideoID], [Code], [Name], [Brand], [Price], [Image], [Description], [CategoryID]) VALUES (1004, NULL, N'P1', N'Proxy', N'Axiom', CAST(8.00 AS Decimal(18, 2)), N'https://m.media-amazon.com/images/I/51QJPwxX5ML._AC_SX569_.jpg', N'This is a putter that has been used.', 2)
GO
INSERT [dbo].[Products] ([ProductID], [VideoID], [Code], [Name], [Brand], [Price], [Image], [Description], [CategoryID]) VALUES (2002, NULL, N'F1', N'Falk', N'Kastaplast', CAST(21.00 AS Decimal(18, 2)), N'https://th.bing.com/th/id/OIP.41lfejfUTt0Mz-6XSMO3mgHaHa?rs=1&pid=ImgDetMain', N'This is a fairway driver', 4)
GO
INSERT [dbo].[Products] ([ProductID], [VideoID], [Code], [Name], [Brand], [Price], [Image], [Description], [CategoryID]) VALUES (3002, NULL, N'F2', N'Falk', N'Kastaplast', CAST(10.00 AS Decimal(18, 2)), N'https://th.bing.com/th/id/OIP.41lfejfUTt0Mz-6XSMO3mgHaHa?rs=1&pid=ImgDetMain', N'This a fairway driver that has been used', 4)
GO
INSERT [dbo].[Products] ([ProductID], [VideoID], [Code], [Name], [Brand], [Price], [Image], [Description], [CategoryID]) VALUES (3003, NULL, N'T3', N'test 3', N'Test', CAST(20.00 AS Decimal(18, 2)), N'https://th.bing.com/th/id/OIP.TkowSvLKt65gT8Y86YgATgHaE6?rs=1&pid=ImgDetMain', N'This a third trd', 1)
GO
INSERT [dbo].[Products] ([ProductID], [VideoID], [Code], [Name], [Brand], [Price], [Image], [Description], [CategoryID]) VALUES (4007, NULL, N'M3', N'Fuse', N'Latitude 64', CAST(30.00 AS Decimal(18, 2)), N'https://cdn.ultiworld.com/wordpress/wp-content/uploads/2020/12/Fuse-1024x1024.jpg', N'Special Edition with pretty stamp', 3)
GO
INSERT [dbo].[Products] ([ProductID], [VideoID], [Code], [Name], [Brand], [Price], [Image], [Description], [CategoryID]) VALUES (4008, NULL, N'M2', N'Fuse', N'Latitude 64', CAST(5.00 AS Decimal(18, 2)), N'https://cdn.ultiworld.com/wordpress/wp-content/uploads/2020/12/Fuse-1024x1024.jpg', N'Very used and beat in', 3)
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [Phone], [LastLoginTime], [isAdmin]) VALUES (1, N'Juan', N'Robledo', N'jr@poop.com', N'$2a$13$7D38X7ZOTqY0afuLSn7rD.iGvgBASd8u5GYMTMOW/mYEB4vo7htay', N'None', CAST(N'2024-04-29T14:59:40.267' AS DateTime), 0)
GO
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [Phone], [LastLoginTime], [isAdmin]) VALUES (1002, N'Luffy', N'D', N'Sunny@StrawHats.com', N'$2a$13$xXUXbgI3/xaNm/asGMMyyOwXwlYsYYaORfrQsBoq6HhTVCzuxxUYe', N'123-456-7890', CAST(N'2024-04-29T15:13:53.927' AS DateTime), 1)
GO
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [Phone], [LastLoginTime], [isAdmin]) VALUES (3004, N'Mark', N'Grayson', N'Viltrume@isAwesome.com', N'$2a$13$NJ.AvJuYtyApW2hHhU9iROQw9XIbUwDn4NibLhfj/MYi2gy9aP.d6', N'None', CAST(N'2024-04-29T14:40:45.077' AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
