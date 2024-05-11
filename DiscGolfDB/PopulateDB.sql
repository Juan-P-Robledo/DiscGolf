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
INSERT [dbo].[Products] ([ProductID], [Code], [Name], [Brand], [Price], [Image], [Description], [CategoryID]) VALUES (1002, N'M1', N'Fuse', N'Latitude 64', CAST(10.00 AS Decimal(18, 2)), N'https://cdn.ultiworld.com/wordpress/wp-content/uploads/2020/12/Fuse-1024x1024.jpg', N'This a used Understable disc', 3)
GO
INSERT [dbo].[Products] ([ProductID], [Code], [Name], [Brand], [Price], [Image], [Description], [CategoryID]) VALUES (1004, N'P1', N'Proxy', N'Axiom', CAST(8.00 AS Decimal(18, 2)), N'https://m.media-amazon.com/images/I/51QJPwxX5ML._AC_SX569_.jpg', N'This is a putter that has been used.', 2)
GO
INSERT [dbo].[Products] ([ProductID], [Code], [Name], [Brand], [Price], [Image], [Description], [CategoryID]) VALUES (2002, N'F1', N'Falk', N'Kastaplast', CAST(21.00 AS Decimal(18, 2)), N'https://th.bing.com/th/id/OIP.41lfejfUTt0Mz-6XSMO3mgHaHa?rs=1&pid=ImgDetMain', N'This is a fairway driver', 4)
GO
INSERT [dbo].[Products] ([ProductID], [Code], [Name], [Brand], [Price], [Image], [Description], [CategoryID]) VALUES (3002, N'F2', N'Falk', N'Kastaplast', CAST(10.00 AS Decimal(18, 2)), N'https://th.bing.com/th/id/OIP.41lfejfUTt0Mz-6XSMO3mgHaHa?rs=1&pid=ImgDetMain', N'This a fairway driver that has been used', 4)
GO
INSERT [dbo].[Products] ([ProductID], [Code], [Name], [Brand], [Price], [Image], [Description], [CategoryID]) VALUES (4007, N'M3', N'Fuse', N'Latitude 64', CAST(30.00 AS Decimal(18, 2)), N'https://cdn.ultiworld.com/wordpress/wp-content/uploads/2020/12/Fuse-1024x1024.jpg', N'Special Edition with pretty stamp', 3)
GO
INSERT [dbo].[Products] ([ProductID], [Code], [Name], [Brand], [Price], [Image], [Description], [CategoryID]) VALUES (4008, N'M2', N'Fuse', N'Latitude 64', CAST(5.00 AS Decimal(18, 2)), N'https://cdn.ultiworld.com/wordpress/wp-content/uploads/2020/12/Fuse-1024x1024.jpg', N'Very used and beat in', 3)
GO
INSERT [dbo].[Products] ([ProductID], [Code], [Name], [Brand], [Price], [Image], [Description], [CategoryID]) VALUES (5010, N'D1', N'Destroyer', N'Innova', CAST(20.00 AS Decimal(18, 2)), N'https://infinitediscs.com/Inf_Uploads/DiscProducts/W675_Destroyer.Webp', N'This is a brand new Driver', 5)
GO
INSERT [dbo].[Products] ([ProductID], [Code], [Name], [Brand], [Price], [Image], [Description], [CategoryID]) VALUES (5011, N'B1', N'Standard Disc Bag', N'Innova', CAST(30.00 AS Decimal(18, 2)), N'https://i5.walmartimages.com/asr/4f1e1e36-7b7a-4cb7-8276-cd0272ca09fe.4839eb538af38de942ce66359edae37e.jpeg', N'Made to hold at least 5 disc ', 6)
GO
INSERT [dbo].[Products] ([ProductID], [Code], [Name], [Brand], [Price], [Image], [Description], [CategoryID]) VALUES (5012, N'R1', N'Disc Golf Retriever (20ft)', N'Max Disctance', CAST(120.00 AS Decimal(18, 2)), N'https://th.bing.com/th/id/R.da5846cee1192ecde21f450ecd372dbf?rik=acXF%2fSLOGbFqOQ&riu=http%3a%2f%2fcdn.shopify.com%2fs%2ffiles%2f1%2f1096%2f9828%2fproducts%2fScreenshot_20230118_110440_Gallery_800x.webp%3fv%3d1681434590&ehk=sdTAJqhg6p2uuxE9wq2X1Tz1n37S927XB%2f%2b%2fGQP2FPM%3d&risl=&pid=ImgRaw&r=0', N'This retriever has suction cups and can go up to 20ft in reach.', 7)
GO
INSERT [dbo].[Products] ([ProductID], [Code], [Name], [Brand], [Price], [Image], [Description], [CategoryID]) VALUES (5013, N'B2', N'Disc Golf Bag', N'Latitude 64', CAST(80.00 AS Decimal(18, 2)), N'https://th.bing.com/th/id/R.faa54d88cf39963fc07bec0d0a18653f?rik=8%2fv9Oi1bCF8m4w&pid=ImgRaw&r=0', N'This can hold up to 20+ discs', 6)
GO
INSERT [dbo].[Products] ([ProductID], [Code], [Name], [Brand], [Price], [Image], [Description], [CategoryID]) VALUES (5014, N'R2', N'Disc Retriever', N'Dynamic Discs', CAST(40.00 AS Decimal(18, 2)), N'https://www.bing.com/th?id=OPHS.IZnGThiTe%2fHRdA474C474&o=5&pid=21.1&w=148&h=245&qlt=100&dpr=1.3&bw=6&bc=FFFFFF&c=17', N'This can go up to 10ft in reach.', 7)
GO
INSERT [dbo].[Products] ([ProductID], [Code], [Name], [Brand], [Price], [Image], [Description], [CategoryID]) VALUES (5015, N'P2', N'Star Gator', N'Innova', CAST(9.00 AS Decimal(18, 2)), N'https://i5.walmartimages.com/asr/9c98c9af-44a8-4ee1-88c8-ae2ac89527f2.0648eda6d021bd881c02c2b16214206e.png', N'Used putter, slightly beat in. ', 2)
GO
INSERT [dbo].[Products] ([ProductID], [Code], [Name], [Brand], [Price], [Image], [Description], [CategoryID]) VALUES (5016, N'M4', N'Pathfinder', N'Thought Space', CAST(25.00 AS Decimal(18, 2)), N'https://kwsdiscgolf.com/wp-content/uploads/2020/10/pathAura.png', N'Brand new disc, with special edition stamp', 3)
GO
INSERT [dbo].[Products] ([ProductID], [Code], [Name], [Brand], [Price], [Image], [Description], [CategoryID]) VALUES (5017, N'F3', N'Jackal Special Edition', N'Discmania', CAST(30.00 AS Decimal(18, 2)), N'https://cdn11.bigcommerce.com/s-lbxc0rt6q3/products/6483/images/8847/66a6a3caC_FD_Jackal_Blue_2400px_144PPI_720x__85442.1696179015.386.513.jpg?c=2', N'New disc, never used.', 4)
GO
INSERT [dbo].[Products] ([ProductID], [Code], [Name], [Brand], [Price], [Image], [Description], [CategoryID]) VALUES (5018, N'D2', N'Wraith', N'Innova', CAST(20.00 AS Decimal(18, 2)), N'https://i5.walmartimages.com/asr/1dd3fdce-1887-4209-8946-01393735be4e_1.9891d797993411e4507b64bdb2e8cedf.jpeg', N'Recently released disc, New, with no use.', 5)
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [Phone], [LastLoginTime], [isAdmin]) VALUES (1, N'Juan', N'Robledo', N'jr@poop.com', N'$2a$13$7D38X7ZOTqY0afuLSn7rD.iGvgBASd8u5GYMTMOW/mYEB4vo7htay', N'None', CAST(N'2024-05-10T20:53:56.003' AS DateTime), 0)
GO
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [Phone], [LastLoginTime], [isAdmin]) VALUES (1002, N'Luffy', N'D', N'Sunny@StrawHats.com', N'$2a$13$xXUXbgI3/xaNm/asGMMyyOwXwlYsYYaORfrQsBoq6HhTVCzuxxUYe', N'123-456-7890', CAST(N'2024-05-10T20:32:41.393' AS DateTime), 1)
GO
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [Phone], [LastLoginTime], [isAdmin]) VALUES (3004, N'Mark', N'Grayson', N'Viltrume@isAwesome.com', N'$2a$13$2B7yV2a8p.GQWgltVotJUuwZFvTZ6vgAbgNhszdVmR.9NAXggmUhy', N'None', CAST(N'2024-05-10T20:55:05.023' AS DateTime), 0)
GO
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [Phone], [LastLoginTime], [isAdmin]) VALUES (3005, N'Jacob', N'Eisenbraun', N'jacob@eisenbraun.com', N'$2a$13$Rbgtq/r8Q/GOALOmw6Qs5ueDYXVHKgiZTxNUYaDT1APouLZSghkIe', N'1234567890', CAST(N'2024-05-01T15:12:24.207' AS DateTime), 0)
GO
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [Phone], [LastLoginTime], [isAdmin]) VALUES (3006, N'Admin', N'Admin', N'admin@admin.com', N'$2a$13$c9Rreqn61ryiUTlG57j5Hu9OWCKvX4eGzYaVxUvQuYiVN5CUGJzDi', N'1234567890', CAST(N'2024-05-01T15:18:19.427' AS DateTime), 1)
GO
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [Phone], [LastLoginTime], [isAdmin]) VALUES (3007, N'Demo', N'User', N'demo@gmail.com', N'$2a$13$CVNCk9iG.BzmKprWrmZhIOrw/Io2lUUJmxwIU3Jq.awwWyMkTVi7i', N'None', CAST(N'2024-05-01T15:18:01.420' AS DateTime), 0)
GO
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [Phone], [LastLoginTime], [isAdmin]) VALUES (4006, N'Testing', N'tester', N'test@test.com', N'$2a$13$CD8GJ7tqsaxahRgwVsJ0pOtv5K8ldOmY7TvJw6LnKGVt4a4qRzwJK', N'None', CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Collection] ON 
GO
INSERT [dbo].[Collection] ([CollectionID], [UserID], [ProductID]) VALUES (1, 1, 5012)
GO
INSERT [dbo].[Collection] ([CollectionID], [UserID], [ProductID]) VALUES (4, 1002, 5012)
GO
INSERT [dbo].[Collection] ([CollectionID], [UserID], [ProductID]) VALUES (5, 1002, 5016)
GO
INSERT [dbo].[Collection] ([CollectionID], [UserID], [ProductID]) VALUES (6, 1, 1002)
GO
INSERT [dbo].[Collection] ([CollectionID], [UserID], [ProductID]) VALUES (7, 1, 1004)
GO
INSERT [dbo].[Collection] ([CollectionID], [UserID], [ProductID]) VALUES (8, 1, 5011)
GO
INSERT [dbo].[Collection] ([CollectionID], [UserID], [ProductID]) VALUES (9, 3004, 5013)
GO
INSERT [dbo].[Collection] ([CollectionID], [UserID], [ProductID]) VALUES (10, 3004, 5015)
GO
INSERT [dbo].[Collection] ([CollectionID], [UserID], [ProductID]) VALUES (11, 3004, 5018)
GO
SET IDENTITY_INSERT [dbo].[Collection] OFF
GO
SET IDENTITY_INSERT [dbo].[Filter] ON 
GO
INSERT [dbo].[Filter] ([FilterID], [FilterName]) VALUES (1, N'None')
GO
INSERT [dbo].[Filter] ([FilterID], [FilterName]) VALUES (2, N'Alphabetically, A-Z')
GO
INSERT [dbo].[Filter] ([FilterID], [FilterName]) VALUES (3, N'Alphebetically, Z-A')
GO
INSERT [dbo].[Filter] ([FilterID], [FilterName]) VALUES (4, N'Price, low to high')
GO
INSERT [dbo].[Filter] ([FilterID], [FilterName]) VALUES (5, N'Price, high to low')
GO
SET IDENTITY_INSERT [dbo].[Filter] OFF
GO

