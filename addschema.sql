use Schools
GO

SET IDENTITY_INSERT [Address] ON

INSERT [dbo].[Address] ([ID], [Country], [City], [Street], [PostalCode]) VALUES (1, N'Ukraine', N'Malynivka', N'Shkilna', 22450)
INSERT [dbo].[Address] ([ID], [Country], [City], [Street], [PostalCode]) VALUES (2, N'Ukraine', N'Lytin', N'LytinskaCentralna', 12345)
INSERT [dbo].[Address] ([ID], [Country], [City], [Street], [PostalCode]) VALUES (3, N'Ukraine', N'Vinitsya', N'Komarova', 54321)
INSERT [dbo].[Address] ([ID], [Country], [City], [Street], [PostalCode]) VALUES (4, N'Ukraine', N'Sadove', N'Vishenka', 22500)
INSERT [dbo].[Address] ([ID], [Country], [City], [Street], [PostalCode]) VALUES (5, N'Ukraine', N'Kyiv', N'Svobodi', 35000)
INSERT [dbo].[Address] ([ID], [Country], [City], [Street], [PostalCode]) VALUES (6, N'Ukraine', N'Balin', N'Richkova', 44321)
INSERT [dbo].[Address] ([ID], [Country], [City], [Street], [PostalCode]) VALUES (7, N'Ukraine', N'Vinitsya', N'Ynosti', 67000)
INSERT [dbo].[Address] ([ID], [Country], [City], [Street], [PostalCode]) VALUES (8, N'Ukraine', N'Kyiv', N'Antonovicha', 43600)
INSERT [dbo].[Address] ([ID], [Country], [City], [Street], [PostalCode]) VALUES (9, N'Ukraine', N'Vinitsya', N'Keletska', 12500)
INSERT [dbo].[Address] ([ID], [Country], [City], [Street], [PostalCode]) VALUES (10, N'Ukraine', N'Vinitsya', N'SabarivskeShoce', 89000)

SET IDENTITY_INSERT [Address] OFF


SET IDENTITY_INSERT [School] ON

INSERT [dbo].[School] ([ID], [Name], [AddressID], [OpeningDate]) VALUES (1, N'Malynivska', 1, CAST(N'2002-01-01' AS Date))
INSERT [dbo].[School] ([ID], [Name], [AddressID], [OpeningDate]) VALUES (2, N'Lytinska', 2, CAST(N'1999-01-01' AS Date))
INSERT [dbo].[School] ([ID], [Name], [AddressID], [OpeningDate]) VALUES (3, N'VinytskaSchool¹1', 3, CAST(N'2000-01-01' AS Date))
INSERT [dbo].[School] ([ID], [Name], [AddressID], [OpeningDate]) VALUES (4, N'Sadovska', 4, CAST(N'2003-01-01' AS Date))
INSERT [dbo].[School] ([ID], [Name], [AddressID], [OpeningDate]) VALUES (5, N'KyivskaSchool¹6', 5, CAST(N'2005-01-01' AS Date))
INSERT [dbo].[School] ([ID], [Name], [AddressID], [OpeningDate]) VALUES (6, N'Balynska', 6, CAST(N'1998-01-01' AS Date))
INSERT [dbo].[School] ([ID], [Name], [AddressID], [OpeningDate]) VALUES (7, N'VinytskiyLicey¹3', 7, CAST(N'2007-01-01' AS Date))
INSERT [dbo].[School] ([ID], [Name], [AddressID], [OpeningDate]) VALUES (8, N'KyivskaSchool¹2', 8, CAST(N'2001-01-01' AS Date))
INSERT [dbo].[School] ([ID], [Name], [AddressID], [OpeningDate]) VALUES (9, N'VinytskaSchool¹7', 9, CAST(N'2004-01-01' AS Date))
INSERT [dbo].[School] ([ID], [Name], [AddressID], [OpeningDate]) VALUES (10, N'VinytskaSchool¹5', 10, CAST(N'1997-01-01' AS Date))

SET IDENTITY_INSERT [School] OFF


SET IDENTITY_INSERT [Floor] ON

INSERT [dbo].[Floor] ([ID], [Number], [SchoolID]) VALUES (1, 1, 1)
INSERT [dbo].[Floor] ([ID], [Number], [SchoolID]) VALUES (2, 2, 1)
INSERT [dbo].[Floor] ([ID], [Number], [SchoolID]) VALUES (3, 3, 1)
INSERT [dbo].[Floor] ([ID], [Number], [SchoolID]) VALUES (4, 1, 2)
INSERT [dbo].[Floor] ([ID], [Number], [SchoolID]) VALUES (5, 2, 2)
INSERT [dbo].[Floor] ([ID], [Number], [SchoolID]) VALUES (6, 1, 3)
INSERT [dbo].[Floor] ([ID], [Number], [SchoolID]) VALUES (7, 2, 3)
INSERT [dbo].[Floor] ([ID], [Number], [SchoolID]) VALUES (8, 1, 4)
INSERT [dbo].[Floor] ([ID], [Number], [SchoolID]) VALUES (9, 2, 4)
INSERT [dbo].[Floor] ([ID], [Number], [SchoolID]) VALUES (10, 1, 5)
INSERT [dbo].[Floor] ([ID], [Number], [SchoolID]) VALUES (11, 1, 6)
INSERT [dbo].[Floor] ([ID], [Number], [SchoolID]) VALUES (12, 2, 6)
INSERT [dbo].[Floor] ([ID], [Number], [SchoolID]) VALUES (13, 1, 7)
INSERT [dbo].[Floor] ([ID], [Number], [SchoolID]) VALUES (14, 1, 8)
INSERT [dbo].[Floor] ([ID], [Number], [SchoolID]) VALUES (15, 1, 9)
INSERT [dbo].[Floor] ([ID], [Number], [SchoolID]) VALUES (16, 2, 9)
INSERT [dbo].[Floor] ([ID], [Number], [SchoolID]) VALUES (17, 1, 10)
INSERT [dbo].[Floor] ([ID], [Number], [SchoolID]) VALUES (18, 2, 10)
INSERT [dbo].[Floor] ([ID], [Number], [SchoolID]) VALUES (19, 3, 10)

SET IDENTITY_INSERT [Floor] OFF

SET IDENTITY_INSERT [RoomType] ON

INSERT [dbo].[RoomType] ([ID], [Name]) VALUES (1, N'Regular')
INSERT [dbo].[RoomType] ([ID], [Name]) VALUES (2, N'Math')
INSERT [dbo].[RoomType] ([ID], [Name]) VALUES (3, N'Biology')
INSERT [dbo].[RoomType] ([ID], [Name]) VALUES (4, N'Literature')
INSERT [dbo].[RoomType] ([ID], [Name]) VALUES (5, N'Informatic')
INSERT [dbo].[RoomType] ([ID], [Name]) VALUES (6, N'Gym')
INSERT [dbo].[RoomType] ([ID], [Name]) VALUES (7, N'Physics')
INSERT [dbo].[RoomType] ([ID], [Name]) VALUES (8, N'Hall')
INSERT [dbo].[RoomType] ([ID], [Name]) VALUES (9, N'Workshop')

SET IDENTITY_INSERT [RoomType] OFF

SET IDENTITY_INSERT [Room] ON

INSERT [dbo].[Room] ([ID], [Number], [FloorID]) VALUES (1, 101, 1)
INSERT [dbo].[Room] ([ID], [Number], [FloorID]) VALUES (2, 205, 2)
INSERT [dbo].[Room] ([ID], [Number], [FloorID]) VALUES (3, 301, 3)
INSERT [dbo].[Room] ([ID], [Number], [FloorID]) VALUES (4, 102, 4)
INSERT [dbo].[Room] ([ID], [Number], [FloorID]) VALUES (5, 201, 5)
INSERT [dbo].[Room] ([ID], [Number], [FloorID]) VALUES (6, 101, 6)
INSERT [dbo].[Room] ([ID], [Number], [FloorID]) VALUES (7, 102, 6)
INSERT [dbo].[Room] ([ID], [Number], [FloorID]) VALUES (8, 201, 7)
INSERT [dbo].[Room] ([ID], [Number], [FloorID]) VALUES (9, 101, 8)
INSERT [dbo].[Room] ([ID], [Number], [FloorID]) VALUES (10, 102, 8)
INSERT [dbo].[Room] ([ID], [Number], [FloorID]) VALUES (11, 103, 8)
INSERT [dbo].[Room] ([ID], [Number], [FloorID]) VALUES (12, 201, 9)
INSERT [dbo].[Room] ([ID], [Number], [FloorID]) VALUES (13, 202, 9)
INSERT [dbo].[Room] ([ID], [Number], [FloorID]) VALUES (14, 101, 10)
INSERT [dbo].[Room] ([ID], [Number], [FloorID]) VALUES (15, 102, 10)
INSERT [dbo].[Room] ([ID], [Number], [FloorID]) VALUES (16, 101, 11)
INSERT [dbo].[Room] ([ID], [Number], [FloorID]) VALUES (17, 201, 12)
INSERT [dbo].[Room] ([ID], [Number], [FloorID]) VALUES (18, 101, 13)
INSERT [dbo].[Room] ([ID], [Number], [FloorID]) VALUES (19, 101, 14)
INSERT [dbo].[Room] ([ID], [Number], [FloorID]) VALUES (20, 101, 15)
INSERT [dbo].[Room] ([ID], [Number], [FloorID]) VALUES (21, 201, 16)
INSERT [dbo].[Room] ([ID], [Number], [FloorID]) VALUES (22, 101, 17)
INSERT [dbo].[Room] ([ID], [Number], [FloorID]) VALUES (23, 102, 17)
INSERT [dbo].[Room] ([ID], [Number], [FloorID]) VALUES (24, 201, 18)
INSERT [dbo].[Room] ([ID], [Number], [FloorID]) VALUES (25, 202, 18)
INSERT [dbo].[Room] ([ID], [Number], [FloorID]) VALUES (26, 301, 19)

SET IDENTITY_INSERT [Room] OFF

SET IDENTITY_INSERT [Employee] ON

INSERT [dbo].[Employee] ([ID], [FirstName], [LastName], [Age]) VALUES (1, N'Sichenko', N'Volodimyr', 38)
INSERT [dbo].[Employee] ([ID], [FirstName], [LastName], [Age]) VALUES (2, N'Ostrikov', N'Artur', 18)
INSERT [dbo].[Employee] ([ID], [FirstName], [LastName], [Age]) VALUES (3, N'Pupkin', N'Pup', 99)
INSERT [dbo].[Employee] ([ID], [FirstName], [LastName], [Age]) VALUES (4, N'Zelenskyy', N'Volodimyr', 20)
INSERT [dbo].[Employee] ([ID], [FirstName], [LastName], [Age]) VALUES (5, N'Stepanov', N'Oleg', 23)
INSERT [dbo].[Employee] ([ID], [FirstName], [LastName], [Age]) VALUES (6, N'Sidyk', N'Valentyn', 43)
INSERT [dbo].[Employee] ([ID], [FirstName], [LastName], [Age]) VALUES (7, N'Privilov', N'Vladyslav', 32)
INSERT [dbo].[Employee] ([ID], [FirstName], [LastName], [Age]) VALUES (8, N'Petrovich', N'Petro', 33)
INSERT [dbo].[Employee] ([ID], [FirstName], [LastName], [Age]) VALUES (9, N'Polishchuk', N'Oleksandr', 35)
INSERT [dbo].[Employee] ([ID], [FirstName], [LastName], [Age]) VALUES (10, N'Stavniichuk', N'Valeriy', 30)
INSERT [dbo].[Employee] ([ID], [FirstName], [LastName], [Age]) VALUES (11, N'Maliy', N'Stanislav', 30)

SET IDENTITY_INSERT [Employee] OFF

INSERT [dbo].[SchoolEmployee] ([EmployeeID], [SchoolID]) VALUES (1, 1)
INSERT [dbo].[SchoolEmployee] ([EmployeeID], [SchoolID]) VALUES (1, 2)
INSERT [dbo].[SchoolEmployee] ([EmployeeID], [SchoolID]) VALUES (2, 3)
INSERT [dbo].[SchoolEmployee] ([EmployeeID], [SchoolID]) VALUES (1, 4)
INSERT [dbo].[SchoolEmployee] ([EmployeeID], [SchoolID]) VALUES (3, 2)
INSERT [dbo].[SchoolEmployee] ([EmployeeID], [SchoolID]) VALUES (4, 1)
INSERT [dbo].[SchoolEmployee] ([EmployeeID], [SchoolID]) VALUES (4, 6)
INSERT [dbo].[SchoolEmployee] ([EmployeeID], [SchoolID]) VALUES (4, 7)
INSERT [dbo].[SchoolEmployee] ([EmployeeID], [SchoolID]) VALUES (5, 10)
INSERT [dbo].[SchoolEmployee] ([EmployeeID], [SchoolID]) VALUES (5, 9)
INSERT [dbo].[SchoolEmployee] ([EmployeeID], [SchoolID]) VALUES (5, 8)
INSERT [dbo].[SchoolEmployee] ([EmployeeID], [SchoolID]) VALUES (6, 8)
INSERT [dbo].[SchoolEmployee] ([EmployeeID], [SchoolID]) VALUES (6, 7)
INSERT [dbo].[SchoolEmployee] ([EmployeeID], [SchoolID]) VALUES (7, 6)
INSERT [dbo].[SchoolEmployee] ([EmployeeID], [SchoolID]) VALUES (8, 5)
INSERT [dbo].[SchoolEmployee] ([EmployeeID], [SchoolID]) VALUES (9, 6)
INSERT [dbo].[SchoolEmployee] ([EmployeeID], [SchoolID]) VALUES (10, 4)
INSERT [dbo].[SchoolEmployee] ([EmployeeID], [SchoolID]) VALUES (11, 3)

INSERT [dbo].[Director] ([ID], [Job]) VALUES (1, N'Director')
INSERT [dbo].[Director] ([ID], [Job]) VALUES (7, N'Director')
INSERT [dbo].[Director] ([ID], [Job]) VALUES (10, N'Director')
INSERT [dbo].[Director] ([ID], [Job]) VALUES (11, N'Director')

INSERT [dbo].[Teacher] ([ID], [Job]) VALUES (2, N'Teacher')
INSERT [dbo].[Teacher] ([ID], [Job]) VALUES (3, N'Teacher')
INSERT [dbo].[Teacher] ([ID], [Job]) VALUES (4, N'Teacher')
INSERT [dbo].[Teacher] ([ID], [Job]) VALUES (5, N'Teacher')
INSERT [dbo].[Teacher] ([ID], [Job]) VALUES (6, N'Teacher')
INSERT [dbo].[Teacher] ([ID], [Job]) VALUES (8, N'Teacher')
INSERT [dbo].[Teacher] ([ID], [Job]) VALUES (9, N'Teacher')

INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (1, 1)
INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (2, 1)
INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (2, 2)
INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (3, 1)
INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (4, 5)
INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (5, 1)
INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (5, 3)
INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (6, 3)
INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (7, 1)
INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (7, 8)
INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (8, 9)
INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (9, 8)
INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (10, 1)
INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (11, 1)
INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (11, 7)
INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (12, 1)
INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (12, 6)
INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (13, 1)
INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (14, 6)
INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (15, 1)
INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (15, 5)
INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (15, 2)
INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (16, 1)
INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (16, 4)
INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (17, 1)
INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (18, 1)
INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (19, 1)
INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (20, 1)
INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (21, 1)
INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (21, 8)
INSERT [dbo].[RoomRoomType] ([RoomId], [RoomTypeId]) VALUES (22, 1)
