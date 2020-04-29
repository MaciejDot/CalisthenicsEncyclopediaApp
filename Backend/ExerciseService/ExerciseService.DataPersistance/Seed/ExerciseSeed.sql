/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
USE [ExerciseService]
GO
SET IDENTITY_INSERT [Workout].[Exercise] ON 
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (100, N'Wall Handstand')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (101, N'Free Handstand')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (102, N'Handstand On Rings')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (103, N'Wall One Arm Handstand')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (104, N'Free One Arm Handstand')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (105, N'Hollow Back')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (200, N'Pike Push Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (201, N'Elevated Pike Push Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (202, N'Wall Handstand Push Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (203, N'Free Handstand Push Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (204, N'Free Deep Handstand Push Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (205, N'Free Wide Handstand Push Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (206, N'Free 90 Degree Handstand Push Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (207, N'Free Deep 90 Degree Handstand Push Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (300, N'Bend Arm Tuck Press To Handstand')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (301, N'Straigth Arm Tuck Press To Handstand')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (302, N'Bend Arm Straddle Press To Handstand')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (303, N'Straigth Arm Straddle Press To Handstand')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (304, N'Bend Arm Pike Press To Handstand')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (305, N'Straigth Arm Pike Press To Handstand')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (306, N'Bend Arm L-sit To Handstand')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (307, N'Straigth Arm L-sit To Handstand')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (400, N'Tuck L-sit')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (401, N'L-sit')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (402, N'Straddle L-sit')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (403, N'Rings L-sit')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (404, N'Rings Straddle L-sit')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (405, N'V-Sit')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (406, N'Rings V-Sit')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (407, N'45 Degree V-Sit/Manna')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (408, N'Manna')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (500, N'German Hang')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (501, N'Tuck Back Lever')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (502, N'Advanced Tuck Back Lever')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (503, N'Straddle Back Lever')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (504, N'Half Lay Back Lever')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (505, N'Full Back Lever')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (506, N'Wide Full Back Lever')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (507, N'One Arm Back Lever')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (600, N'Tuck Back Lever Press To Reverse Hang')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (601, N'German Hang Thru Tuck Back Lever Press To Reverse Hang')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (602, N'Advanced Tuck Back Lever Press To Reverse Hang')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (603, N'German Hang Thru Advanced Tuck Back Lever Press To Reverse Hang')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (604, N'Straddle Back Lever Press To Reverse Hang')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (605, N'German Hang Thru Straddle Back Lever Press To Reverse Hang')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (606, N'Half Lay Back Lever Press To Reverse Hang')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (607, N'German Hang Thru Half Lay Back Lever Press To Reverse Hang')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (608, N'Full Back Lever Press To Reverse Hang')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (609, N'German Hang Thru Full Back Lever Press To Reverse Hang')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (700, N'German Hang Pull Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (701, N'Tuck Back Lever Pull Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (702, N'Advanced Tuck Back Lever Pull Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (703, N'Straddle Back Lever Pull Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (704, N'Half Lay Back Lever Pull Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (705, N'Full Back Lever Pull Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (800, N'Tuck Front Lever')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (801, N'Advanced Tuck Front Lever')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (802, N'Straddle Front Lever')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (803, N'Half Lay Front Lever')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (804, N'Full Front Lever')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (805, N'Wide Full Front Lever')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (806, N'One Arm Side Lever')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (807, N'One Arm Front Lever')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (900, N'Dead Hang Thru Tuck Front Lever Press To Reverse Hang Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (901, N'Tuck Front Lever Press To Reverse Hang')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (902, N'Dead Hang Thru Tuck Front Lever Press To Reverse Hang')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (903, N'Dead Hang Thru Advanced Front Back Lever Press To Reverse Hang Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (904, N'Advanced Tuck Front Lever Press To Reverse Hang')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (905, N'Dead Hang Thru Advanced Front Back Lever Press To Reverse Hang')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (906, N'Dead Hang Thru Straddle Front Lever Press To Reverse Hang Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (907, N'Straddle Front Lever Press To Reverse Hang')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (908, N'Dead Hang Thru Straddle Front Lever Press To Reverse Hang')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (909, N'Dead Hang Thru Half Lay Front Lever Press To Reverse Hang Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (910, N'Half Lay Front Lever Press To Reverse Hang')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (911, N'Dead Hang Thru Half Lay Front Lever Press To Reverse Hang')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (912, N'Dead Hang Thru Full Front Lever Press To Reverse Hang Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (913, N'Full Front Lever Press To Reverse Hang')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (914, N'Dead Hang Thru Full Front Lever Press To Reverse Hang')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (915, N'Dead Hang Press To One Arm Front Lever')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (916, N'Dead Hang Thru One Arm Front Lever Press To Reverse Hang Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (917, N'One Arm Front Lever Press To Reverse Hang')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (918, N'Dead Hang Thru One Arm Front Lever Press To Reverse Hang')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1000, N'Tuck Front Lever False Grip Pull Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1001, N'Tuck Front Lever Pull Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1002, N'Advanced Tuck Front Lever False Grip Pull Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1003, N'Advanced Tuck Front Lever Pull Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1004, N'Straddle Front Lever False Grip Pull Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1005, N'Straddle Front Lever Pull Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1006, N'Half Lay Front Lever False Grip Pull Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1007, N'Half Lay Front Lever Pull Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1008, N'Full Front Lever False Grip Pull Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1009, N'Full Front Lever Pull Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1010, N'Wide Front Lever False Grip Pull Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1011, N'Wide Front Lever Pull Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1100, N'Australian Pull Ups Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1101, N'Australian Pull Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1102, N'Wide Australian Pull Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1103, N'Archer Australian Pull Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1104, N'One Arm Australian Pull Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1200, N'Regular Pull Ups Eccentrinc')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1201, N'Regular Pull Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1202, N'Wide Pull Up Eccentrinc')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1203, N'Wide Pull Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1204, N'Archer Pull Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1205, N'One Arm Pull Ups Eccentrinc')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1206, N'One Arm Pull Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1300, N'Support Hold')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1400, N'Swedish Dips Eccentrinc')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1401, N'Swedish Dips')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1402, N'Regular Dips Eccentrinc')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1403, N'Regular Dips')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1404, N'Single Bar Dips Eccentrinc')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1405, N'Single Bar Dips')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1406, N'Korean Dips Eccentrinc')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1407, N'Korean Dips')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1408, N'Ring Dips')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1409, N'Bulgarian Dips Eccentrinc')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1500, N'Human Flag Hang')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1501, N'Human Flag Reverse Hang')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1502, N'Advanced Tuck Human Flag')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1503, N'Straddle Human Flag')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1504, N'Full Human Flag')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1600, N'Muscle Ups Eccentrinc')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1601, N'Muscle Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1602, N'Rings Muscle Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1603, N'One Arm Muscle Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1700, N'Reverse Australian Pull Ups Eccentrinc')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1701, N'Reverse Australian Pull Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1702, N'Hefesto Eccentrinc')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1703, N'Hefesto')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1704, N'Back Lever Hefesto Eccentrinc')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1705, N'Back Lever Hefesto')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1706, N'Entrade De Angelo Eccentrinc')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1707, N'Entrade De Angelo')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1708, N'Entrade De Diablo Eccentrinc')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1709, N'Entrade De Diablo')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1800, N'High Pull Ups To Chest')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1801, N'High Pull Ups To Stomach')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1802, N'High Pull Ups To Thigs')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1803, N'Terrorist Pull Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1900, N'Squat')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1901, N'Pistol Squat Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (1902, N'Pistol Squat')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2000, N'Knee Push Ups Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2001, N'Knee Push Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2002, N'Regular Push Ups Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2003, N'Regular Push Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2004, N'Diamond Push Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2005, N'Archer Push Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2006, N'One Arm Push Ups Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2007, N'One Arm Push Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2100, N'Dead Hang')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2101, N'One Arm Dead Hang')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2200, N'Reverse Hang')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2300, N'Paraller Bars L Victorian Cross (Arms On Bars)')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2301, N'Paraller Bars Advanced Tuck Victorian Cross (Arms On Bars)')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2302, N'Paraller Bars Super Advanced Tuck Victorian Cross (Arms On Bars)')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2303, N'Paraller Bars Half Lay Victorian Cross (Arms On Bars)')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2304, N'Paraller Bars Full Victorian Cross (Arms On Bars)')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2305, N'Paraller Bars L Victorian Cross (Only Hands On Bars)')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2306, N'Paraller Bars Advanced Tuck Victorian Cross (Only Hands On Bars)')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2307, N'Paraller Bars Super Advanced Tuck Victorian Cross (Only Hands On Bars)')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2308, N'Paraller Bars Half Lay Victorian Cross (Only Hands On Bars)')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2309, N'Paraller Bars Full Victorian Cross (Only Hands On Bars)')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2310, N'Rings Snake Grip Victorian Cross')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2311, N'Rings Victorian Cross')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2312, N'Paraller Bars L Victorian Cross')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2400, N'L Dragon Flag')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2401, N'Advanced Tuck Dragon Flag')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2402, N'Straddle Dragon Flag')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2403, N'Full Dragon Flag')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2404, N'One Arm Dragon Flag')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2500, N'Advanced Tuck Dragon Flag Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2501, N'Advanced Tuck Dragon Flag Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2502, N'Straddle Dragon Flag Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2503, N'Straddle Dragon Flag Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2504, N'Full Dragon Flag Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2505, N'Full Dragon Flag Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2506, N'One Arm Dragon Flag Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2507, N'One Arm Dragon Flag Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2600, N'L Dragon Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2601, N'Advanced Tuck Dragon Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2602, N'Straddle Dragon Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2603, N'Full Dragon Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2604, N'One Arm Dragon Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2700, N'Advanced Tuck Dragon Press Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2701, N'Advanced Tuck Dragon Press Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2702, N'Straddle Dragon Press Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2703, N'Straddle Dragon Press Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2704, N'Full Dragon Press Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2705, N'Full Dragon Press Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2706, N'One Arm Dragon Press Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2707, N'One Arm Dragon Press Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2800, N'Advanced Tuck Front Lever Touch')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2801, N'Straddle Front Lever Touch')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2802, N'Half Lay Front Lever Touch')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2803, N'Full Front Lever Touch')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2804, N'Wide Full Front Lever Touch')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2900, N'Tuck Planche')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2901, N'Tuck Rings Planche')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2902, N'Advanced Tuck Planche')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2903, N'Advanced Rings Tuck Planche')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2904, N'Straddle Planche')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2905, N'Half Lay Planche')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2906, N'Straddle Rings Planche')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2907, N'Full Planche')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (2908, N'Full Rings Planche')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3000, N'Tuck Planche Push Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3001, N'Tuck Rings Planche Push Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3002, N'Advanced Tuck Planche Push Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3003, N'Advanced Rings Tuck Planche Push Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3004, N'Straddle Planche Push Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3005, N'Half Lay Planche Push Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3006, N'Straddle Rings Planche Push Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3007, N'Full Planche Push Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3008, N'Full Rings Planche Push Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3100, N'Tuck Planche Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3101, N'Tuck Planche Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3102, N'Tuck Rings Planche Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3103, N'Tuck Rings Planche Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3104, N'Advanced Tuck Planche Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3105, N'Advanced Tuck Planche Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3106, N'Advanced Rings Tuck Planche Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3107, N'Advanced Rings Tuck Planche Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3108, N'Straddle Planche Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3109, N'Straddle Planche Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3111, N'Half Lay Planche Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3112, N'Half Lay Planche Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3113, N'Straddle Rings Planche Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3114, N'Straddle Rings Planche Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3115, N'Full Planche Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3116, N'Full Planche Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3117, N'Full Rings Planche Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3118, N'Full Rings Planche Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3200, N'Straddle Maltese')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3201, N'Straddle Rings Maltese')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3202, N'Full Maltese')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3203, N'Full Rings Maltese')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3300, N'Straddle Maltese Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3301, N'Straddle Maltese Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3302, N'Straddle Rings Maltese Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3303, N'Straddle Rings Maltese Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3304, N'Full Maltese Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3305, N'Full Maltese Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3306, N'Full Rings Maltese Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3307, N'Full Rings Maltese Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3400, N'30 Degrees Inverted Cross')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3401, N'45 Degrees Inverted Cross')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3402, N'75 Degrees Inverted Cross')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3403, N'Full Inverted Cross')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3500, N'30 Degrees Inverted Cross Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3501, N'30 Degrees Inverted Cross Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3502, N'45 Degrees Inverted Cross Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3503, N'45 Degrees Inverted Cross Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3504, N'75 Degrees Inverted Cross Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3505, N'75 Degrees Inverted Cross Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3506, N'Full Inverted Cross Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3507, N'Full Inverted Cross Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3600, N'Full Handstand Flag')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3601, N'Full One Arm Handstand Flag')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3700, N'Planche Lean')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3701, N'Elevated Planche Lean')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3702, N'Rings Planche Lean')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3703, N'Elevated Rings Planche Lean')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3800, N'Planche Lean Push Ups')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3900, N'Elbow Plank')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3901, N'Elevated Elbow Plank')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3902, N'Plank')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3903, N'Elevated Plank')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3904, N'One Arm Elbow Plank')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3905, N'Elevated One Arm Elbow Plank')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3906, N'One Arm Plank')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3907, N'Elevated One Arm Plank')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3908, N'Rings Plank')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3909, N'Elevated Rings Plank')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3910, N'One Arm Rings Plank')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (3911, N'Elevated Rings Plank')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4000, N'Maltese Lean')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4001, N'Elevated Maltese Lean')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4002, N'Rings Maltese Lean')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4003, N'Elevated Rings Maltese Lean')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4100, N'30 Degrees Iron Cross')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4101, N'45 Degrees Iron Cross')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4102, N'75 Degrees Iron Cross')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4103, N'Full Iron Cross')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4200, N'30 Degrees Iron Cross Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4201, N'30 Degrees Iron Cross Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4202, N'45 Degrees Iron Cross Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4203, N'45 Degrees Iron Cross Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4204, N'75 Degrees Iron Cross Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4205, N'75 Degrees Iron Cross Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4206, N'Full Iron Cross Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4207, N'Full Iron Cross Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4300, N'Reverse Planche')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4400, N'Victorian Cross Lean')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4401, N'Elevated Victorian Cross Lean')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4402, N'Rings Victorian Cross Lean')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4403, N'Elevated Rings Victorian Cross Lean')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4500, N'Advanced Hollow Body')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4501, N'Super Advanced Hollow Body')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4502, N'Straddle Hollow Body')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4503, N'Hollow Body')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4600, N'Superman')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4700, N'Tuck Leg Raises')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4701, N'Straddle Leg Raises')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4702, N'Full Leg Raises')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4703, N'One Arm Leg Raises')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4800, N'Hollow Body Rocks')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4801, N'Hollow Body Raises')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4900, N'Superman Rocks')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (4901, N'Superman Raises')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (5000, N'Impossible Dips Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (5001, N'Impossible Dips')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (5100, N'Neck Hold')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (5200, N'Christo')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (5300, N'Half Zanetti Flies')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (5400, N'Zanetti Flies')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (5500, N'Planche Hollow Body')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (5600, N'Maltese Hollow Body')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (5700, N'Bench Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (5800, N'Incline Bench Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (5900, N'OHP')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (6000, N'Biceps Curls')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (6100, N'Dead Lift')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (6200, N'Bridge')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (6300, N'Advanced Tuck Box Planche')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (6301, N'Half Lay Box Planche')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (6302, N'Full Box Planche')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (6400, N'Tuck Front Lever Raise')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (6401, N'Advanced Tuck Front Lever Raise')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (6402, N'Super Advanced Tuck Front Lever Raise')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (6403, N'Straddle Front Lever Raise')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (6404, N'Full Front Lever Raise')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (6405, N'Wide Full Front Lever Raise')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (6406, N'Assisted One Arm Front Lever Raise')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (6407, N'One Arm Front Lever Raise')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (6500, N'Advanced Tuck Box Planche Raise')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (6501, N'Half Lay Box Planche Raise')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (6502, N'Full Box Planche Raise')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (6600, N'Advanced Tuck Box Planche Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (6601, N'Advanced Tuck Box Planche Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (6602, N'Half Lay Box Planche Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (6603, N'Half Lay Box Planche Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (6604, N'Full Box Planche Press Eccentric')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (6605, N'Full Box Planche Press')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (6700, N'Box Revrse Leg Raises (Hips on Box)')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (6701, N'Box Revrse Leg Raises (Stomach on Box)')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (6702, N'Box Revrse Leg Raises (Only Chest on Box)')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (6800, N'Box Revrse Leg Raises (Hips on Box) Hold')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (6801, N'Box Revrse Leg Raises (Stomach on Box) Hold')
GO
INSERT [Workout].[Exercise] ([Id], [Name]) VALUES (6802, N'Box Revrse Leg Raises (Only Chest on Box) Hold')
GO
SET IDENTITY_INSERT [Workout].[Exercise] OFF
GO
