CREATE DATABASE DbProyectGbm

go

use DbProyectGbm

go

CREATE TABLE cat_genery
(
	id_genery int identity(1,1),
	name varchar(50)
	primary key(id_genery)
)

go

CREATE TABLE tbl_album
(
	id_album int identity(1,1),
	name varchar(50),
	year_album int,
	id_genery int
	primary key(id_album) 
)

go
CREATE TABLE tbl_songs
(
	id_song int identity(1,1),
	song varchar(8000),
	duration varchar(5),
	autor varchar(50),
	id_album int,
	primary key(id_song),
  	foreign key(id_album)  references tbl_album(id_album)
)

GO

CREATE TABLE tbl_list
(
	id_list int identity(1,1),
	name varchar(50),
	dateCreate datetime
	primary key(id_list)
)


go

CREATE TABLE tbl_play_list
(
	tbl_play_list int identity(1,1),
	id_song int,
	id_list int,
	dateCreate datetime,
	primary key(tbl_play_list),
	foreign key(id_song)  references tbl_songs(id_song),
	foreign key(id_list)  references tbl_list(id_list)
)


GO


go

CREATE PROCEDURE spTblSongsGetAll
AS
BEGIN
	SELECT 	
			id_song 
			song,
			duration,
			autor,
			id_album 
	FROM 
			tbl_songs songs 
END

go

CREATE PROCEDURE spTblAlbumGetAll
AS
BEGIN
	SELECT 		
			id_album,
			name,
			year_album,
			id_genery 
	FROM 
			tbl_album  
END

go

CREATE PROCEDURE spCatGeneryGetAll
AS
BEGIN
	SELECT 		
			cat_genery.id_genery,
			cat_genery.name
	FROM 
			cat_genery  
END


go

CREATE PROCEDURE spTblSongsGetAllComplete
AS
BEGIN
	SELECT 	
			songs.id_song, 
			songs.song,
			songs.duration,
			songs.autor,
			album.id_album,
			album.name,
			album.year_album,
			genery.id_genery,
			genery.name			 
	FROM 
			tbl_songs songs 
	left join 
		tbl_album album
	on 
		album.id_album = songs.id_album
	left join 
		cat_genery genery
	on
		genery.id_genery = album.id_genery
END


go


CREATE PROCEDURE spTblListGetAll
AS
BEGIN
	SELECT 	
			list.id_list,
			list.name,
			list.dateCreate
	FROM 
			tbl_list list 
END


go

CREATE PROCEDURE spTblSongsGetByIdList
(
	@id_list int
)
AS
BEGIN
	SELECT 	
			songs.id_song, 
			songs.song,
			songs.duration,
			songs.autor,
			album.id_album,
			album.name,
			album.year_album,
			genery.id_genery,
			genery.name			 
	FROM 
			tbl_songs songs 
	left join 
		tbl_album album
	on 
		album.id_album = songs.id_album
	left join 
		cat_genery genery
	on
		genery.id_genery = album.id_genery
	join 
		tbl_play_list list
	on
		list.id_song = songs.id_song		
WHERE
	list.id_list = @id_list
		
END

go

CREATE PROCEDURE spTblListAdd
(
	@description varchar(100),
	@date datetime
)
AS
BEGIN
	insert into tbl_list values (@description,@date)
	select @@IDENTITY
END

go
CREATE PROCEDURE spTblPlayListAdd
(
	@id_song int,
	@id_list int,
	@date datetime
)
AS
BEGIN
	insert into tbl_play_list values (@id_song,@id_list,@date)
	select @@IDENTITY		
END


GO

insert into cat_genery values('Metal')
insert into cat_genery values('Rock')
insert into cat_genery values('Regueton')
insert into cat_genery values('Salsa')
insert into cat_genery values('Bachata')
insert into cat_genery values('Guaracha')


insert into tbl_album values('Lo mejor del recodo',1992,1)
insert into tbl_album values('TENGO TODO',2001,1)
insert into tbl_album values('Exitos 2012',1923,2)
insert into tbl_album values('Hay aja',1992,2)
insert into tbl_album values('Crossfit',1992,3)
insert into tbl_album values('Salsa para cancun',1992,4)
insert into tbl_album values('Cositas',1996,5)
insert into tbl_album values('Puras',1998,5)
insert into tbl_album values('Chicas bonitas vol 2',1992,6)
insert into tbl_album values('No tengo dinero',1992,6)
insert into tbl_album values('Bon jovi',2014,3)

insert into tbl_songs VALUES('Absurda Falsedad','3:00','Warcry',2)
insert into tbl_songs VALUES('Luna','3:00','JP',3)
insert into tbl_songs VALUES('Carrigas','0:01','LP',4)
insert into tbl_songs VALUES('Tesis','2:11','Maria',5)
insert into tbl_songs VALUES('Toscana','3:23','Codplay',6)
insert into tbl_songs VALUES('Verduro','3:32','Tenis',1)
insert into tbl_songs VALUES('Apocaliptica','3:23','Warcry',2)
insert into tbl_songs VALUES('casi casi','2:00','Warcry',1)
insert into tbl_songs VALUES('La guaracha ','1:00','Wishin',1)
insert into tbl_songs VALUES('Tescos','3:00','Warcry',6)

insert into tbl_list values('para la fiesta',GETDATE())
insert into tbl_list values('GYM',GETDATE())
insert into tbl_list values('Crossfit',GETDATE())


insert into  tbl_play_list values(1,1,GETDATE())
insert into  tbl_play_list values(2,1,GETDATE())


insert into  tbl_play_list values(3,2,GETDATE())
insert into  tbl_play_list values(4,2,GETDATE())
insert into  tbl_play_list values(1,2,GETDATE())






