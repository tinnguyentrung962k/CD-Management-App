if exists (select * from sysdatabases where name='CDStore')
begin
  raiserror('Dropping existing CDStore database ....',0,1)
  DROP database CDStore
end
GO

raiserror('Creating CDStore database....',0,1)
SET NOCOUNT ON
CREATE DATABASE [CDStore]
GO
USE [CDStore]
GO

CREATE TABLE [dbo].[Role](
	[roleId][varchar](2) PRIMARY KEY NOT NULL,
	[roleName][varchar](50) NOT NULL,
)
GO

CREATE TABLE [dbo].[Account](
	[accountId] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[userName] [varchar](200) NOT NULL,
	[passWord] [char](64) NOT NULL,
	[roleId]   [varchar](2)  FOREIGN KEY REFERENCES Role(roleId) NOT NULL,
	[fullName] [nvarchar](200) NOT NULL,
	[email] [varchar](200) NOT NULL,
	[address] [nvarchar](200) NOT NULL,
	[phoneNumber] [varchar](200) NOT NULL,
)
GO


CREATE TABLE [dbo].[CDAlbum](
	[albumId] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[albumName] [nvarchar](200) NOT NULL,
	[releaseYear][int] NOT NULL,
	[author][nvarchar](200) NOT NULL,
	[albumGenre][nvarchar](200) NOT NULL,
	[price] [float] NOT NULL,
	[quantity][int] NOT NULL,
	[description][nvarchar](4000),
	[imgSrc][nvarchar](4000),
)
GO

CREATE TABLE [dbo].[Song](
	[songId] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[songName] [nvarchar](200) NOT NULL,
	[duration][nvarchar](10) NOT NULL,
	[albumId][int] references CDAlbum(albumId) NOT NULL,
)
GO

CREATE TABLE [dbo].[CustomerRequest](
	[requestId] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[customerName] [nvarchar](200) NOT NULL,
	[phoneNumber] [varchar](200) NOT NULL,
	[email][varchar](200) NOT NULL,
	[description][nvarchar](4000) NOT NULL,
	[status] [varchar] NOT NULL,
	[submitDate][date] NOT NULL,
)
GO

CREATE TABLE [dbo].[ActivityLog](
	[activityId] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[activityDate] [date] NOT NULL,
	[activity] [nvarchar](200),
)
GO


INSERT [dbo].[Role] ([roleId],[roleName]) VALUES ('MG','Manager')
INSERT [dbo].[Role] ([roleId],[roleName]) VALUES ('EM','Employee')

INSERT [dbo].[Account] ([userName],[passWord],[roleId],[fullName],[email],[address],[phoneNumber]) VALUES ('admin','abc12345','MG','Manager','cdstore@gmail.com',N'FPT University','0886647866')
INSERT [dbo].[Account] ([userName],[passWord],[roleId],[fullName],[email],[address],[phoneNumber]) VALUES ('trungtin','6969696','EM','Employee','trungtin9620@gmail.com',N'Thu Duc City','0123456789')

INSERT [dbo].[CDAlbum] ([albumName],[releaseYear],[author],[albumGenre],[price],[quantity],[description],[imgSrc]) VALUES (N'99%',2023,N'MCK',N'Rap',420000,100,N'Sau thời gian chuẩn bị, MCK tung album phòng thu đầu tay “99%” vào thời khắc quan trọng nhất trong đời người đàn ông: Khi anh bước qua tuổi 24. Sản phẩm cho thấy tư duy âm nhạc mới mẻ của rapper sinh năm 1999, đồng thời chứng minh anh là một dấu ấn không thể thiếu trong thị trường rap Việt hiện nay.','dsadsadsadasdsad')
INSERT [dbo].[CDAlbum] ([albumName],[releaseYear],[author],[albumGenre],[price],[quantity],[description],[imgSrc]) VALUES (N'Loser2Lover',2020,N'Bray',N'Rap',500000,100,N'Từ 1 kẻ thua cuộc trở thành 1 người biết yêu','dsadsadsadasdsad')
INSERT [dbo].[CDAlbum] ([albumName],[releaseYear],[author],[albumGenre],[price],[quantity],[description],[imgSrc]) VALUES (N'Qua Khung Cửa Sổ',2021,N'Chillies',N'Indie',300000,100,N'“Qua khung cửa sổ” như tuyển tập các ca khúc của Chillies hơn là một concept album (Album chủ đề) hoàn chỉnh. Nhiều khả năng có những ca khúc đơn thành công về mặt thương mại, biểu hiện là 3 MV dạng lyric video mới phát hành trên YouTube đã lọt Top 30 Trending. ','dsadsadsadasdsad')
INSERT [dbo].[CDAlbum] ([albumName],[releaseYear],[author],[albumGenre],[price],[quantity],[description],[imgSrc]) VALUES (N'Trên những đám mây',2023,N'Chillies',N'Indie',300000,100,N'Lý giải về cái tên “Trên Những Đám Mây”, giọng ca chính Trần Duy Khang chia sẻ: “Là nghệ sĩ, chúng tôi thường phải đi lưu diễn ở rất nhiều nơi. Mỗi khi lên máy bay, chúng tôi luôn có một thói quen vô thức là chụp hình những đám mây qua khung cửa sổ. Hình ảnh đám mây như tượng trưng cho những dịp được trình diễn cho khán giả, những lần ban nhạc được gặp gỡ những người bạn mới, hay nói đúng hơn là những dịp hội ngộ. Do đó, chúng tôi quyết định lấy hình ảnh này để thể hiện sự kết nối giữa nghệ sĩ chúng tôi và khán giả”.','dsadsadsadasdsad')
INSERT [dbo].[CDAlbum] ([albumName],[releaseYear],[author],[albumGenre],[price],[quantity],[description],[imgSrc]) VALUES (N'Yêu 6',2022,N'Rhymastic',N'Rap RnB',350000,100,N'EP LOV6 là chuỗi sản phẩm âm nhạc của Rhymastic bao gồm 6 ca khúc: “Y6u” (Yêu 6), “Líu La Líu Lo”, “Side Effects” (tác dụng phụ), “Ngổn Ngang”, “Vẫn Yêu” và “Thêm Đứa Nữa”. Trước đó, vào tối 12/9, chủ nhân hit Yêu 5 chính thức công bố dự án mới, đồng thời tung sản phẩm đầu tiên để “chạy đà” cho EP là “Ngổn Ngang”','dsadsadsadasdsad')
INSERT [dbo].[CDAlbum] ([albumName],[releaseYear],[author],[albumGenre],[price],[quantity],[description],[imgSrc]) VALUES (N'Ba Tháng Quân Trường',2020,N'Chế Linh','Vietnamese Pop, Vietnamese Bolero',1200000,100,N'Legendary vocals and immortal love songs will last forever with time.','dsadsadsadasdsad')
INSERT [dbo].[CDAlbum] ([albumName],[releaseYear],[author],[albumGenre],[price],[quantity],[description],[imgSrc]) VALUES (N'Honky Chateau',1905,N'Elton John',N'Rock, Pop',840000,100,N'Honky Chateau is the fifth studio album by English musician Elton John.','dsadsadsadasdsad')
INSERT [dbo].[CDAlbum] ([albumName],[releaseYear],[author],[albumGenre],[price],[quantity],[description],[imgSrc]) VALUES (N'Booker Little',1960,N'Booker Little',N'Jazz',350000,100,N'A crucial jazz record from 1961, led by a lyrical trumpeter and composer who captured the many overlapping currents of the genre.','dsadsadsadasdsad')
INSERT [dbo].[CDAlbum] ([albumName],[releaseYear],[author],[albumGenre],[price],[quantity],[description],[imgSrc]) VALUES (N'Love All Serve All',2022,N'Fuji Kaze',N'Funk, Soul, Pop, Folk, World',3666000,100,N'Love All Serve All is the second studio album by Japanese singer-songwriter Fujii Kaze. It was released on March 23, 2022, through Hehn Records and Universal Sigma.','dsadsadsadasdsad')
INSERT [dbo].[CDAlbum] ([albumName],[releaseYear],[author],[albumGenre],[price],[quantity],[description],[imgSrc]) VALUES (N'Back In Black',1980,N'AC/DC',N'Rock',770000,100,N'Red label with yellow strobe marks. Embossed logo and album title on cover.','dsadsadsadasdsad')
INSERT [dbo].[CDAlbum] ([albumName],[releaseYear],[author],[albumGenre],[price],[quantity],[description],[imgSrc]) VALUES (N'The Book',2021,N'YOASOBI',N'J-Pop',1130000,100,N'The Book is the debut extended play by Japanese duo Yoasobi.','dsadsadsadasdsad')
INSERT [dbo].[CDAlbum] ([albumName],[releaseYear],[author],[albumGenre],[price],[quantity],[description],[imgSrc]) VALUES (N'POP CUBE',2022,N'imase',N'J-Pop',625000,100,N'On February 24, 2023, "NIGHT DANCER" ranked 93rd in the Korean distribution site "Melon" comprehensive daily ranking. It is the first time in the history of J-POP that it has entered the TOP 100 on the Melon general chart.','dsadsadsadasdsad')
INSERT [dbo].[CDAlbum] ([albumName],[releaseYear],[author],[albumGenre],[price],[quantity],[description],[imgSrc]) VALUES (N'Fantastic Magic',2014,N'Kitajima Toru',N'J-Rock',740000,100,N'A solo project that unleashes itself from the moment and rain, TK as a dignified center of the rain and winter season. The long-awaited second album includes "contrast" which became the title of the EP and the opening theme of the TV anime "Tokyo Ghoul" and the latest single song "unravel", which is only seen in live live.','dsadsadsadasdsad')
INSERT [dbo].[CDAlbum] ([albumName],[releaseYear],[author],[albumGenre],[price],[quantity],[description],[imgSrc]) VALUES (N'LITMUS',2020,N'Cö shu Nie',N'J-Rock',575000,100,N'After the release of the 1st album "PURE", the release following "FLARE", which has been written down to the animation "PSYCHO-PASS3 FIRST INSPECTOR" in place of the tour final, which was released to the fan instead of the touring final, which was completely discontinued by the coronavirus influence of the coronavirus, is a mini album. It is a motivation to inscribed the title "Litmus" and introduce new instruments and sounds to traditional band sounds.','dsadsadsadasdsad')
INSERT [dbo].[CDAlbum] ([albumName],[releaseYear],[author],[albumGenre],[price],[quantity],[description],[imgSrc]) VALUES (N'Traveler',2019,N'Cö shu Nie',N'J-Rock',470000,100,N'Official HIGE DANdism brings the first album from a major label! Includes "Stand By You," "FIRE GROUND" (intro theme song of anime series "Hinomaru Sumo"), "Bad For Me," "Pretender" (theme song of the film "Confidence Man JP - Romance Hen -") , "Yesterday" (theme song of the film "HELLO WORLD" and more for 13 tracks in total (subject to change).','dsadsadsadasdsad')
INSERT [dbo].[CDAlbum] ([albumName],[releaseYear],[author],[albumGenre],[price],[quantity],[description],[imgSrc]) VALUES (N'Bad example',2020,N'Takayan',N'Hip Hop',830000,100,N'“反面教師 (Bad Example)” by たかやん (Takayan) was produced by PapaPedro Beats.','dsadsadsadasdsad')
INSERT [dbo].[CDAlbum] ([albumName],[releaseYear],[author],[albumGenre],[price],[quantity],[description],[imgSrc]) VALUES (N'Rừng Đom Đóm',2021,N'The Casette',N'Indie Rock',250000,30,N'Sau “mini-album” PiCK gần hai năm, The Cassette mới cho ra mắt album trọn vẹn đầu tay mang tên Rừng đom đóm. Dự án giúp khẳng định “tiếng nói” của ban nhạc với tất cả sự mới mẻ, nghiêm túc trong lao động nghệ thuật.','dsadsadsadasdsad')
INSERT [dbo].[CDAlbum] ([albumName],[releaseYear],[author],[albumGenre],[price],[quantity],[description],[imgSrc]) VALUES (N'3',2019,N'Ngọt',N'Indie Rock',390000,20,N'Album phòng thu thứ ba của Ngọt.','dsadsadsadasdsad')
INSERT [dbo].[CDAlbum] ([albumName],[releaseYear],[author],[albumGenre],[price],[quantity],[description],[imgSrc]) VALUES (N'Hiệu ứng trốn chạy',2019,N'Cá Hồi Hoang',N'Indie Rock',350000,6,N'Thay vì nhìn nó như bước chuyển mình trong nhãn mác, từ một nhóm nhạc phát hành album chui, không tem lên album dán tem đàng hoàng - như báo chí vẫn đang khai thác, ta cũng nên nhìn nó như một bước chuyển mình can đảm trong chất rock.','dsadsadsadasdsad')
INSERT [dbo].[CDAlbum] ([albumName],[releaseYear],[author],[albumGenre],[price],[quantity],[description],[imgSrc]) VALUES (N'Một Vạn Năm',2022,N'Vũ.',N'Vietnamese Pop',360000,59,N'Ca sĩ Vũ hát về những cuộc tình đẹp nhưng không trọn vẹn trong album "Một vạn năm".','dsadsadsadasdsad')
INSERT [dbo].[CDAlbum] ([albumName],[releaseYear],[author],[albumGenre],[price],[quantity],[description],[imgSrc]) VALUES (N'Cái Đầu Tiên',2023,N'Thắng',N'Vietnamese Pop',250000,100,N'Không cần phải đặt tham vọng vươn ra nước ngoài, nhưng Thắng - trưởng nhóm của ban nhạc Ngọt - đã đánh dấu sự nghiệp solo bằng một album đầu tay mang không khí của một đô thị quốc tế giữa ngã ba đường.','dsadsadsadasdsad')
INSERT [dbo].[CDAlbum] ([albumName],[releaseYear],[author],[albumGenre],[price],[quantity],[description],[imgSrc]) VALUES (N'Everything I Know About Love - Cream Vinyl',2023,N'Laufey',N'Pop',700000,100,N'It’s about dealing with growing-up. It’s also very hopeless romantic.','dsadsadsadasdsad')
INSERT [dbo].[CDAlbum] ([albumName],[releaseYear],[author],[albumGenre],[price],[quantity],[description],[imgSrc]) VALUES (N'Honey Weed',2019,N'Summer Salt',N'Pop, Rock',587500,100,N'Starting off with a sweet, melodic guitar riff, “Honeyweed” is the perfect song to imagine yourself floating down a lazy river to instead of sitting at your day-job. The music opens up as the song continues, sounding as refreshing as a cool breeze or a glass of lemonade. With light and upbeat vocals singing about unexpected love, this cute tune will have you hooked in no time. It won’t be long before you find yourself referring to your own special someone as your lovable Honeyweed. Check out this charming new song by Summer Salt below!','dsadsadsadasdsad')
INSERT [dbo].[CDAlbum] ([albumName],[releaseYear],[author],[albumGenre],[price],[quantity],[description],[imgSrc]) VALUES (N'Gieo',2022,N'Ngọt',N'Pop, Indie',390000,100,N'Qua album “Gieo”, Ngọt có lẽ là một trong những nhóm nhạc chịu khó làm mới bản thân nhất tại nhạc Việt. Kể từ album đầu tay đến nay, người nghe ít khi thấy nhóm lặp lại chính mình. Từ chất liệu indie rock có chút thô ráp và lạ lẫm với người nghe trong album “Ngọt”, nhóm bắt đầu làm mềm âm nhạc của mình khi mang đến một số chất liệu cổ điển trong “Ngbthg”. Đến “3” thì thực sự là một “tuyển tập” âm nhạc vô cùng chất lượng khi mỗi bài lại đi theo một hướng khác nhau mà âm thanh tổng thể vẫn thống nhất, không đối chọi, lúc thăng hoa lúc nhẹ nhàng rất đa dạng.','dsadsadsadasdsad')
INSERT [dbo].[CDAlbum] ([albumName],[releaseYear],[author],[albumGenre],[price],[quantity],[description],[imgSrc]) VALUES (N'Gabriel',2022,N'keshi',N'Pop, Indie',280000,100,N'Monikered as keshi (a phonetic play on his name Casey Luong), the Vietnamese-American artist from Houston is set to release his debut album, GABRIEL, on March 25, 2022, via Island Records. This most personal effort is a fusion of keshi s real self and his artistic persona. The songs are written from the lens of Casey and keshi and speak on both his personal life and of allowing the ego of keshi to take over. The album was co-produced by keshi and Elie Rizk (Bella Poarch s "Build a Bitch").','dsadsadsadasdsad')
INSERT [dbo].[CDAlbum] ([albumName],[releaseYear],[author],[albumGenre],[price],[quantity],[description],[imgSrc]) VALUES (N'17',2017,N'Xxxtentacion',N'Hip hop, Rock',800000,100,N'17 is the debut studio album by American rapper and singer XXXTentacion.[5] It was released on August 25, 2017, by Bad Vibes Forever and Empire Distribution. With a runtime of just under 22 minutes, 17 is a brief album and does not feature a song longer than three minutes.','dsadsadsadasdsad')



INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'00 (Intro)',N'00:33',1)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Chìm sâu',N'02:38',1)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Suit & Tie',N'03:58',1)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Va vào giai điệu này',N'05:56',1)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Chỉ một đêm nữa thôi',N'02:21',1)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Thôi Em Đừng Đi',N'02:53',1)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'50/50 (Interlude)',N'01:00',1)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Cuốn Cho Anh Một Điếu Nữa Đi',N'03:05',1)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Show Me Love',N'02:34',1)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Tại Vì Sao',N'03:51',1)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Thờ er',N'01:38',1)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Ai là kẻ xấu xa',N'03:14',1)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Anh đã ổn hơn',N'03:14',1)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Badtrip',N'02:38',1)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'99%',N'03:14',1)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Tối nay ta đi đâu nhờ',N'01:44',1)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Thua cuộc (Intro)',N'02:34',2)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Nào có sẽ trả',N'02:50',2)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Con gái rượu',N'04:07',2)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Do for Love',N'03:10',2)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Đừng đổ lỗi bọn trẻ',N'03:19',2)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Dư tiền',N'02:41',2)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Finale 3 (Outro)',N'03:05',2)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Ms.May',N'03:24',3)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Bao Nhiêu',N'03:50',3)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Vùng Ký Ức',N'04:57',3)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Em Đừng Khóc',N'04:28',3)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Một Cái Tên',N'04:02',3)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Mộng Du',N'04:01',3)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Mascara',N'04:54',3)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Giá Như',N'04:57',3)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Giấc Mơ Khác',N'03:44',4)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Tầng Mây Thứ 8',N'04:56',4)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Trên Những Đám Mây',N'03:56',4)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Vì Sao',N'04:35',4)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Tình Yêu Mới',N'04:03',4)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Y6U',N'03:53',5)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Líu La Líu Lo',N'03:05',5)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Side Effects',N'04:34',5)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Ngổn Ngang',N'03:15',5)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Vẫn Yêu',N'03:03',5)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Thêm đứa nữa',N'03:28',5)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Ba Tháng Quân Trường',N'04:48',6)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Nước Mắt Quê Hương',N'05:00',6)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Tình Như Mây Khói',N'05:28',6)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Ngoại Ô Đèn Vàng',N'04:14',6)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Thành Phố Buồn',N'06:10',6)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Em Ơi Đừng Đến Nữa Em Ơi',N'05:01',6)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Con Đường Mang Tên Em',N'05:28',6)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Nửa Đêm Biên Giới',N'04:28',6)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Tà Áo Đêm Noel',N'04:16',6)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Giọt Sầu Trinh Nữ',N'04:21',6)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Honky Cat',N'05:13',7)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Honky Cat',N'05:13',7)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Mellow',N'05:32',7)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'I Think I am Going To Kill Myself',N'03:35',7)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Susie (Dramas)',N'03:24',7)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Rocket Man (I Think It is Going To Be A',N'04:41',7)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Salvation',N'03:58',7)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Slave',N'04:22',7)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Amy',N'04:03',7)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Mona Lias And Mad Hatters',N'05:00',7)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Hercules',N'05:20',7)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Slave - ',N'02:53',7)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Opening Statement',N'06:42',8)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Minor Sweet',N'05:38',8)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Bee Tee s Minor Plea',N'05:40',8)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Life is A Little Blue',N'06:53',8)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'The Grand Valse',N'04:57',8)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Who Can I Turn To',N'05:52',8)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Kirari',N'03:47',9)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Matsuri',N'03:45',9)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Hedemo Ne-Yo - LASA edit',N'03:47',9)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'YABA',N'04:11',9)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'MO-EH-YO (Ignite)',N'04:37',9)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Garden',N'03:49',9)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Damn',N'04:19',9)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Lonely Rhapsody',N'04:46',9)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Bye For Now',N'03:50',9)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Seishun Sick',N'05:24',9)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Tabiji',N'04:37',9)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Hell s Bells',N'05:10',10)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Shoot To Thrill',N'05:17',10)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'What Do You Do For Money Honey',N'03:36',10)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Given The Dog A Bone',N'03:31',10)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Let Me Put My Love Into You',N'04:12',10)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Back In Black',N'04:17',10)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'You Shook Me All Night Long',N'03:29',10)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Have A Drink On Me',N'04:01',10)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Shake A Leg',N'04:04',10)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Rock And Roll Aint Noise Pollution',N'04:12',10)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Encore',N'04:30',11)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Halzion',N'03:18',11)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Ano Yume o Nazotte',N'04:03',11)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Tabun',N'04:23',11)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Gunjō',N'04:08',11)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Hakura',N'04:04',11)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Yoru ni Kakeru',N'04:21',11)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Have a nice day',N'02:56',12)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Analog Life',N'03:14',12)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Demone Tamaniwa',N'03:07',12)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'NIGHT DANCER',N'03:31',12)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Escape',N'03:13',12)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Abekobe',N'03:21',12)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Holy Light',N'03:18',12)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Fantastic Magic',N'04:08',13)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'unravel',N'03:58',13)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'kalei de scope',N'03:17',13)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'an artist',N'04:01',13)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'tokio',N'04:42',13)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Shinkiro',N'05:03',13)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Dramatic Slow Motion',N'03:51',13)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Spiral Parade',N'04:14',13)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'fragile',N'04:08',13)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'contrast',N'04:58',13)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Golden dream',N'02:05',14)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'FLARE',N'02:35',14)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Fool in tank',N'03:08',14)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Black sand',N'02:45',14)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'ice melt',N'03:11',14)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Forever together',N'04:07',14)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Stand By You',N'04:16',15)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Pretender',N'05:26',15)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Rowan',N'04:44',15)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Travelers',N'01:46',15)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'FIRE GROUND',N'03:43',15)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Amazing',N'03:51',15)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'It is okay to be dumb',N'01:48',16)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Bad Example',N'01:44',16)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Scream',N'01:43',16)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Back to childhood',N'01:44',16)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Underground',N'01:47',16)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'If I die',N'01:50',16)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Get lost! Face-judgers',N'01:32',16)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'It is true love',N'01:44',16)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'I wanna kill you',N'01:41',16)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Magic room',N'01:32',16)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Curse',N'01:45',16)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Not afraid',N'01:36',16)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Cá Rô',N'02:58',17)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Vùng Đất Linh Hồn',N'05:51',17)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Nắng',N'04:29',17)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Espresso',N'03:55',17)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Ánh Đèn Phố',N'04:42',17)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Khoảng Cách',N'05:08',17)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Nếu Ngày Mai Tôi Không Trở Về',N'03:53',17)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Tựa Đêm Nay',N'04:58',17)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Interlude: 9:00 PM',N'02:11',17)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Rừng Đom Đóm',N'04:41',17)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Màu(đen trắng)',N'03:36',18)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'MẾU MÁO (T.T)',N'03:37',18)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'EM CÓ CHẮC KHÔNG(?) ',N'04:35',18)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'GIẢ VỜ',N'02:58',18)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'CHUÔNG BÁO THỨC (sáng rồi)',N'04:07',18)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'(sau đây là) DỰ BÁO THỜI TIẾT (cho các vùng vào ngày mai)',N'03:18',18)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'CHUYỂN KÊNH (sản phẩm này không phải là thuốc)',N'04:33',18)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'HẾT THỜI',N'04:38',18)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'VỀ ĐI THIÊN ĐƯỜNG (một chiều)',N'02:45',18)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'(tôi) ĐI TRÚ ĐÔNG',N'04:05',18)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'(bé) ',N'04:36',18)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'LẦN CUỐI (đi bên em xót xa người ơi)',N'03:42',18)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'NỨT (đôi chân đôi tay đôi mắt trái tim)',N'04:32',18)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'RU MÌNH',N'02:06',18)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Hiệu ứng bắt đầu',N'02:04',19)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'5AM',N'04:22',19)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Bin',N'03:03',19)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Inside Mr.Bin',N'03:46',19)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Khô Khan',N'03:49',19)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Cô Ấy',N'04:15',19)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Bên Trái',N'03:18',19)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Acid8',N'05:02',19)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Hiệu Ứng Ngược',N'03:22',19)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Hiệu Ứng Trốn Chạy',N'04:20',19)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Cần Một Ngày',N'04:00',19)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Tỉnh Táo',N'04:35',19)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Hiệu Ứng Cuối Cùng',N'02:57',19)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Cân Bằng',N'03:32',19)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Gap',N'04:32',19)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Cô Ta',N'03:34',20)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Nhường Lại Em (feat. Phúc Du)',N'03:34',20)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Chậm Lại',N'03:43',20)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Cuộc Đối Thoại Không Hồi Kết (feat. Mạc Mai Sương)',N'04:35',20)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Chợt Nhìn Nhau',N'03:00',20)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Bước Qua Nhau',N'04:17',20)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Bước Qua Mùa Cô Đơn',N'04:38',20)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Sau Chia Tay Ta Còn Gì?',N'04:41',20)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Anh Nhớ Ra (feat. Trang)',N'04:36',20)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Sober Song',N'02:09',21)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Trước Khi Em Tồn Tại',N'03:14',21)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Limo',N'02:34',21)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Tinkerbell',N'03:21',21)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Mất Thời Gian',N'03:20',21)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Save it for your boyfriends',N'02:27',21)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Phải Lòng',N'04:21',21)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Xin Lỗi',N'02:07',21)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Fragile',N'04:01',22)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Beautiful Stranger',N'03:21',22)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Valentine',N'02:48',22)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Above The Chinese Restaurant',N'03:43',22)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Dear Soulmate',N'04:20',22)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'What Love Will Do To You',N'02:51',22)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'I Have Never Been In Love Before',N'03:42',22)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Just Like Chet',N'03:36',22)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Everything I Know About Love',N'03:29',22)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Falling Behind',N'02:53',22)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Hi',N'03:13',22)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Dance With You Tonight',N'02:38',22)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Night Light',N'04:02',22)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Honeyweed',N'03:31',23)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Fading Away',N'03:23',23)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Magic Boy',N'03:44',23)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Little Chimmy',N'03:55',23)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Coming Up',N'04:07',23)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Full Catastrophe',N'04:04',23)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Bạn thỏ TV nhỏ',N'04:28',24)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Mấy khi',N'02:57',24)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Em trang trí',N'02:45',24)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Điểm đến cuối cùng',N'03:33',24)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Em trong đầu',N'03:18',24)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Chào buổi sáng',N'01:40',24)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Thấy chưa',N'03:52',24)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Đá tan',N'03:22',24)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Đêm hôm qua',N'03:48',24)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Gieo',N'03:27',24)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Mất tích',N'04:31',24)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Get It',N'02:31',25)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Somebody',N'02:44',25)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Westside',N'03:04',25)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Touch',N'03:25',25)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Milli',N'02:15',25)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Pere',N'00:48',25)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Hell/Heaven',N'02:40',25)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Angostura',N'02:51',25)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Understand',N'02:30',25)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Limbo',N'03:32',25)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Angel',N'04:07',25)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Gabriel',N'02:08',25)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'The Explanation',N'00:50',26)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Jocelyn Flores',N'01:59',26)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Depression & Obsession',N'02:24',26)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Everybody Dies In Their Nightmares',N'01:35',26)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Revenge',N'02:00',26)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Save Me',N'02:43',26)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Dead Inside (Interlude)',N'01:26',26)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Fuck Love',N'02:26',26)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Carry On',N'02:09',26)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Orlando',N'02:43',26)
INSERT [dbo].[Song] ([songName],[duration],[albumId]) VALUES (N'Ayala (Outro)',N'01:39',26)


raiserror('The PCStore database in now ready for use.',0,1)