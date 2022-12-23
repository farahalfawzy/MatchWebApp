CREATE DATABASE MatchDB
GO
----------------------------------------------------------------------------------------------------
create proc ins
as
INSERT INTO SYSTEMUSER VALUES
('stadmanager1','stadmanager1'),
('stadmanager2','stadmanager2'),
('stadmanager3','stadmanager3'),
('clubrep1','clubrep1'),
('clubrep2','clubrep2'),
('clubrep3','clubrep3'),
('samanager1','samanager1'),
('sysadmn1','sysadmn1'),
('fan1','fan1'),
('fan2','fan2'),
('fan3','fan3'),
('clubrep4','clubrep4');
Insert Into SportsAssociationManager Values
('SA Manager 1','samanager1');
Insert Into SystemAdmin Values
('sys Admin 1','sysadmn1');
INSERT INTO Stadium(name,status,location,capacity) VALUES 
('Stadium1',1,'Qatar',720),
('Stadium2',0,'Brazil',1000),
('Stadium3',1,'Portugal',1500);
INSERT INTO CLUB VALUES 
('club1','Germany'),
('club2','Spain'),
('club3','Morocco'),
('club4','France');
INSERT INTO Match VALUES
('2018-11-11 13:00:00','2018-11-11 15:00:00',1,2,1),
('2020-01-13 17:00:00','2020-01-13 19:00:00',2,3,2),
('2021-07-21 12:00:00','2021-07-21 14:00:00',3,1,3),
('2022-03-11 13:00:00','2022-03-11 15:00:00',3,2,1),
('2022-11-19 14:00:00','2022-11-19 16:00:00',1,3,3);
Insert INTO StadiumManager  (name,Username) values
('StadManager 1','stadmanager1'),
('StadManager 2','stadmanager2'),
('StadManager 3','stadmanager3');
Insert INTO ClubRepresentative (name,Club_ID,username) Values
('clubRep 1',1,'clubrep1'),
('clubRep 2',2,'clubrep2'),
('clubRep 3',3,'clubrep3'),
('clubRep 4',4,'clubrep4');
Insert INTO HostRequest (status,match_ID,manager_id,Representative_ID) VALUES
('accepted',1,3,4),
('accepted',2,2,2),
('rejected',2,2,3),
('accepted',3,3,3),
('rejected',3,3,4),
('accepted',5,3,3),
('unhandled',5,3,2);
INSERT  INTO TICKET (status,match_id)VALUES
(1,1),
(0,1),
(1,2),
(0,3),
(1,4),
(0,4);
Insert Into Fan (National_ID,Name,Username,Birth_date,Phone_NO ,Address,status)Values 
(123456,'Fan 1','fan1','1980-07-12',0100836684,'Pennsylvania',1),
(234567,'Fan 2','fan2','1986-06-23',017393922,'New York',1),
(345678,'Fan 3','fan3','1996-09-23',066438729,'LA',1);


insert into TicketBuyingTransactions(ticket_id,fan_nationalID) Values 
(1,123456),
(2,234567),
(3,345678);
------------------------------------------------------------------------------------------------------------
go
CREATE PROCEDURE createAllTables
AS
Create Table SystemUser
(
userName VARCHAR(20) Primary Key ,
Password VARCHAR(20)
)
Create Table Stadium
(
Id INT IDENTITY Primary Key,
Name VARCHAR(20),
Location VARCHAR(20),
Capacity int,
Status BIT
)

Create Table Club
(
club_ID INT IDENTITY Primary Key,
Name VARCHAR(20),
Location VARCHAR(20)
);

Create Table StadiumManager
(
Id int Identity,
name VARCHAR(20),
stadium_id INT,
username VARCHAR(20),
FOREIGN KEY (stadium_id) references Stadium (ID)ON UPDATE CASCADE ON DELETE CASCADE, 
FOREIGN KEY (username) references SystemUser (username) ON UPDATE CASCADE ON DELETE CASCADE,
Primary Key(Id) --or primary key haga wahda
)

Create Table ClubRepresentative
(
Id int Identity,
name VARCHAR(20),
Club_ID INT,
username VARCHAR(20),
FOREIGN KEY (username) references SystemUser (username) ON UPDATE CASCADE ON DELETE CASCADE,
FOREIGN KEY (Club_ID) references Club (club_ID)ON UPDATE CASCADE ON DELETE CASCADE, 
Primary Key(Id)
)
Create Table SportsAssociationManager
(
Id int Identity,
name VARCHAR(20),
username VARCHAR(20),
FOREIGN KEY (username) references SystemUser (userName) ON UPDATE CASCADE ON DELETE CASCADE,
Primary Key(Id)
)

Create Table SystemAdmin
(
Id int Identity,
name VARCHAR(20),
username VARCHAR(20),
FOREIGN KEY (username) references SystemUser (userName) ON UPDATE CASCADE ON DELETE CASCADE,
Primary Key(Id)
)

Create Table Fan
(
National_Id int,
name VARCHAR(20),
Birth_date DATE,
address VARCHAR(20),
phone_no INT,  
Status Bit,
username VARCHAR(20),
FOREIGN KEY (username) references SystemUser (userName) ON UPDATE CASCADE ON DELETE CASCADE,
Primary Key(National_Id)
)

Create Table Match
(
match_ID INT IDENTITY Primary Key,
start_time DATETime, 
end_time DATETime,
Host_club_Id INT,
Guest_club_id INT,
Stadium_id INT,
FOREIGN KEY (Stadium_Id) REFERENCES Stadium(ID) ON UPDATE SET NULL ON DELETE SET NULL,
FOREIGN KEY (Guest_club_id) REFERENCES Club(club_ID) ON UPDATE NO ACTION ON DELETE NO ACTION,  
FOREIGN KEY (Host_club_Id) REFERENCES Club(club_ID) ON DELETE NO ACTION  ON UPDATE NO ACTION

--ON DELETE CASCADE ON UPDATE CASCADE GETS ERRORIN THIS CASE
)

Create Table HostRequest
(
ID INT IDENTITY Primary Key,
Representative_ID INT,
Manager_ID int,
Match_ID int,
Status VARCHAR(20),
FOREIGN KEY (Match_ID) references Match(match_ID) ON UPDATE CASCADE ON DELETE CASCADE,  
FOREIGN KEY (Manager_ID) references StadiumManager(ID) ON UPDATE NO ACTION ON DELETE NO ACTION,
FOREIGN KEY (Representative_ID) references ClubRepresentative(ID) ON UPDATE CASCADE ON DELETE CASCADE,
Check (Status  IN ('unhandled','accepted','rejected'))
)
CREATE TABLE Ticket
(
ID INT IDENTITY PRIMARY KEY,
STATUS BIT,
MATCH_ID INT,
FOREIGN KEY (Match_ID) references Match(match_ID) ON UPDATE CASCADE ON DELETE CASCADE
)
CREATE TABLE TicketBuyingTransactions(
fan_nationalID INT,
ticket_id INT 
FOREIGN KEY (fan_nationalID) references FAN(National_ID) ON UPDATE CASCADE ON DELETE CASCADE,
FOREIGN KEY (ticket_id) references Ticket(ID) ON UPDATE CASCADE ON DELETE CASCADE
);
go
CREATE PROCEDURE dropAllTables
AS
DROP TABLE HostRequest;
DROP TABLE StadiumManager;
DROP TABLE ClubRepresentative;
DROP TABLE TicketBuyingTransactions;
DROP TABLE Ticket;
DROP TABLE Match;
DROP TABLE Club;
DROP TABLE Stadium;
DROP TABLE Fan;
DROP TABLE SportsAssociationManager;
DROP TABLE SystemAdmin;
DROP TABLE SystemUser;
go
CREATE PROCEDURE dropAllProceduresFunctionsViews
AS
DROP PROCEDURE IF EXISTS createAllTables;
DROP PROCEDURE IF EXISTS dropAllTables;
DROP PROCEDURE IF EXISTS clearAllTables;
DROP VIEW [allAssocManagers];
DROP VIEW [allClubRepresentatives];
DROP VIEW [allStadiumManagers];
DROP VIEW [allFans];
DROP VIEW [allMatches];
DROP VIEW [allTickets];
DROP VIEW [allClubs];
DROP VIEW [allStadiums];
DROP VIEW [allRequests];
DROP PROCEDURE IF EXISTS addAssociationManager
DROP PROCEDURE IF EXISTS addNewMatch
DROP VIEW [clubsWithNoMatches];
DROP PROCEDURE IF EXISTS deleteMatch;
DROP PROCEDURE IF EXISTS deleteMatchesOnStadium
DROP PROCEDURE IF EXISTS addClub;
DROP PROCEDURE IF EXISTS addTicket;
DROP PROCEDURE IF EXISTS deleteClub;
DROP PROCEDURE IF EXISTS addStadium;
DROP PROCEDURE IF EXISTS deleteStadium;
DROP PROCEDURE IF EXISTS blockFan;
DROP PROCEDURE IF EXISTS unblockFan;
DROP PROCEDURE IF EXISTS addRepresentative;
DROP FUNCTION IF EXISTS viewAvailableStadiumOn;
DROP PROCEDURE IF EXISTS addHostRequest;
DROP FUNCTION IF EXISTS allUnassignedMatches;
DROP PROCEDURE IF EXISTS addStadiumManager;
DROP FUNCTION IF EXISTS allPendingRequests;
DROP PROCEDURE IF EXISTS acceptRequest;
DROP PROCEDURE IF EXISTS rejectRequest;
DROP PROCEDURE IF EXISTS addFan;
DROP FUNCTION IF EXISTS upcomingMatchesOfClub;
DROP FUNCTION IF EXISTS availableMatchesToAttend;
DROP PROCEDURE IF EXISTS purchaseTicket;
DROP PROCEDURE IF EXISTS updateMatchHost;
DROP VIEW [matchesPerTeam]
DROP VIEW [clubsNeverMatched]
DROP FUNCTION IF EXISTS clubsNeverPlayed;
DROP FUNCTION IF EXISTS matchWithHighestAttendance;
DROP FUNCTION IF EXISTS matchRankedByAttendance;
DROP FUNCTION IF EXISTS requestsFromClub;
go
CREATE PROCEDURE clearAllTables
AS
DELETE from TicketBuyingTransactions;
DELETE FROM HostRequest;
DELETE FROM Ticket;
DELETE FROM Match;
DELETE FROM Club;
DELETE FROM Stadium;
DELETE FROM StadiumManager;
DELETE FROM ClubRepresentative;
DELETE FROM Fan;
DELETE FROM SportsAssociationManager;
DELETE FROM SystemAdmin;
DELETE FROM SystemUser;
go

CREATE VIEW [allAssocManagers] AS
SELECT S.Username, U.Password,S.name
FROM SportsAssociationManager S INNER JOIN SystemUser U ON S.username=U.userName;
go

CREATE  VIEW [allClubRepresentatives] AS
SELECT R.UserName,U.Password, R.name Representative, C.name Club
FROM ClubRepresentative R INNER JOIN Club C ON R.Club_ID=C.club_ID 
INNER JOIN SystemUser U ON R.Username=U.username;
go

CREATE VIEW [allStadiumManagers] AS
SELECT M.Username,U.Password, M.name Manager, S.name Stadium 
FROM StadiumManager M, Stadium S, SystemUser U
WHERE M.stadium_Id=S.Id AND M.username=U.userName;
go

CREATE VIEW [allFans] AS
SELECT S.username, S.password, F.Name, F.National_Id, F.Birth_date, F.Status
FROM Fan F INNER JOIN SystemUser S ON F.username=S.userName;
go

CREATE VIEW [allMatches] AS
SELECT C1.name Host_Club, C2.name Guest_Club, M.start_time
FROM Match M, Club C1, Club C2
WHERE M.Host_club_Id=C1.club_ID AND M.Guest_club_id=C2.club_ID;
go

CREATE VIEW [allTickets] AS
SELECT C1.Name Host_club, C2.name Guest_club, S.name Stadium, M.start_time
FROM Ticket T, Match M, Stadium S, Club C1, Club C2
WHERE T.Match_Id=M.match_ID AND M.Stadium_Id=S.Id AND M.Host_club_Id=C1.club_ID AND M.Guest_club_id=C2.club_ID;
go

CREATE VIEW [allClubs] AS
SELECT Name, Location
FROM Club;
go

CREATE VIEW [allStadiums] AS
SELECT Name, Location, Capacity, Status
FROM Stadium;
go

CREATE VIEW [allRequests] AS
SELECT  R.username Representative, M.username Manager,H.status
FROM ClubRepresentative R, StadiumManager M, HostRequest H
WHERE H.Representative_ID =R.Id AND H.Manager_Id=M.Id;
go

CREATE PROC addAssociationManager
@name VARCHAR(20),
@username VARCHAR(20),
@password VARCHAR(20)
AS
if @username not in (select username from SystemUser)
begin
INSERT INTO SystemUser VALUES
(@username,@password);
INSERT INTO SportsAssociationManager VALUES
(@name,@username)
end
go

CREATE PROC addNewMatch 
@hostClub VARCHAR(20),
@guestCLub VARCHAR(20),
@startTime DATETIME,
@endTime DateTime
AS

DECLARE @hostclubID INT
SELECT @hostclubID=C.club_ID
FROM Club C
where C.Name LIKE @hostClub

DECLARE @guestclubID INT
SELECT @guestclubID=C.club_ID
FROM Club C
where C.Name LIKE @guestCLub
--if not exists (select * from match where Host_club_Id=@hostclubID AND Guest_club_id=@guestclubID AND @startTime BETWEEN StartTime and EndTime )
INSERT INTO MATCH (start_time,Guest_club_id,Host_club_Id,end_time) VALUES 
(@startTime,@guestclubID,@hostclubID,@endTime)
go

CREATE VIEW clubsWithNoMatches AS
SELECT C.Name
FROM  CLUB C
WHERE NOT EXISTS (SELECT *
				  FROM MATCH M
				  WHERE M.Host_club_Id=C.club_ID OR M.Guest_club_id=C.club_ID)
go

CREATE PROC deleteMatch 
@hostClub VARCHAR(20),
@guestClub VARCHAR(20)
AS
DECLARE @hostClubID INT
SELECT @hostClubID=C.club_ID
FROM Club C
where C.Name LIKE @hostClub

DECLARE @guestClubID INT
SELECT @guestClubID=C.club_ID
FROM Club C
where C.Name LIKE @guestClub

DELETE FROM Match
WHERE Host_club_Id = @hostClubID AND Guest_club_id = @guestClubID
go

CREATE PROC deleteMatchesOnStadium
@stadiumName VARCHAR(20)
AS
DECLARE @stadiumID INT
SELECT @stadiumID=id
FROM Stadium
WHERE Name LIKE @stadiumName

DELETE FROM MATCH
WHERE Stadium_id= @stadiumID AND start_time > CURRENT_TIMESTAMP
go

CREATE PROC addClub
@clubName VARCHAR(20),
@location VARCHAR (20)
AS
--if @clubName not in (select name from club) 
INSERT INTO CLUB (Name,Location) VALUES (@clubName,@location)
GO

CREATE PROC addTicket
@hclubname VARCHAR(20),
@vclubname VARCHAR(20),
@timeofmatch DATETIME

AS
DECLARE @hclub_id INT
SELECT @hclub_id=Club.club_ID
FROM Club
WHERE @hclubname=Club.Name

DECLARE @vclub_id INT
SELECT @vclub_id=Club.club_ID
FROM Club
WHERE @vclubname=Club.Name

DECLARE @match_id INT

SELECT @match_id=match.match_ID
FROM Match
WHERE @timeofmatch=Match.start_time AND Match.Guest_club_id=@vclub_id  AND Match.Host_club_Id=@hclub_id

INSERT INTO Ticket(MATCH_ID,status)
VALUES(@match_id,1)
go

CREATE PROC deleteClub
@clubname VARCHAR(20)
AS
declare @clubId INT
SELECT @clubId=club_ID FROM CLUB WHERE Club.Name=@clubname
UPDATE  Match SET Host_club_Id = NULL WHERE Host_club_Id=@clubId AND start_time<=CURRENT_TIMESTAMP
UPDATE  Match SET Guest_club_id = NULL WHERE Guest_club_id =@clubId AND start_time<=CURRENT_TIMESTAMP
delete from  Match  WHERE Host_club_Id=@clubId AND start_time>CURRENT_TIMESTAMP
delete from  Match  WHERE Guest_club_id =@clubId AND start_time>CURRENT_TIMESTAMP
UPDATE HostRequest 
SET Representative_ID=NULL 
WHERE Representative_ID=(select cr.Id
						from club c ,ClubRepresentative cr
						where c.club_ID=cr.Club_ID and c.name=@clubname)

declare @cruser varchar(20)
select @cruser=cr.username
from ClubRepresentative cr, club c
where cr.Club_ID=c.club_ID and c.Name=@clubname

DELETE FROM Club WHERE Club.Name=@clubname
delete from SystemUser where username=@cruser
go

CREATE PROC addStadium
@sname VARCHAR(20),
@location VARCHAR(20),
@capacity INT
AS
--if @sname not in (select Name from Stadium)
INSERT INTO Stadium (name,location,capacity,status)
VALUES(@sname,@location,@capacity,1)
GO

CREATE PROC deleteStadium
@Sname VARCHAR(20)

AS
UPDATE HostRequest SET Manager_ID =NULL 
where Manager_ID=(select sm.id
				  from StadiumManager sm, Stadium s
				  where sm.stadium_id=s.id and s.Name=@Sname)
declare @smuser varchar(20)
select @smuser=sm.username
from StadiumManager sm, Stadium s
where sm.stadium_id=s.id and s.Name=@Sname
delete from ticket where id in (select t.id
								from match m,stadium s,ticket t
								where m.Stadium_id=s.id and s.Name like @Sname 
								and m.start_time>CURRENT_TIMESTAMP and t.MATCH_ID=m.match_ID);

DELETE FROM Stadium WHERE Stadium.Name=@Sname
delete from SystemUser where username=@smuser
GO

CREATE PROC blockFan
@national_id VARCHAR(20)
AS
UPDATE Fan
SET FAN.Status=0
WHERE @national_id=fan.National_Id
GO

CREATE PROC unblockFan
@national_id VARCHAR(20)
AS
UPDATE Fan
SET FAN.Status=1
WHERE @national_id=fan.National_Id
GO

CREATE PROC addRepresentative
@Rname VARCHAR(20),
@cname VARCHAR(20),
@username VARCHAR(20),
@password VARCHAR(20)
AS

declare @clubId int
set @clubId= (select club.club_ID
from Club
where club.Name=@cname)
if @username not in (select username from SystemUser)
begin
INSERT INTO SystemUser(userName,Password)
VALUES(@username,@password)

INSERT INTO ClubRepresentative(name,username,Club_ID)
VALUES(@Rname,@username,@clubId)
end
Go

create function viewAvailableStadiumsOn
(@date DATETIME)

returns table 
as
return(
SELECT distinct (S.Name) AS 'Stadium Name' ,S.Location AS 'location' , S.Capacity AS 'Stadium Capacity'
FROM Stadium S 
WHERE S.Status=1 AND  NOT EXISTS (SELECT *
								  FROM MATCH M
								  WHERE S.Id=M.Stadium_id AND @date BETWEEN start_time AND end_time )
);
go

CREATE PROC addHostRequest
@cname VARCHAR(20),
@sname VARCHAR(20),
@timeofmatch DATETIME
AS

DECLARE @manager_id INT 
SET @manager_id=(SELECT st.Id
FROM Stadium s inner join StadiumManager st on (s.Id=st.stadium_id)
WHERE S.Name=@sname)

DECLARE @rep_id INT
SET @rep_id=(SELECT cr.Id
FROM Club c inner join ClubRepresentative cr on (c.club_ID=cr.Club_ID)
WHERE C.Name=@cname)

DECLARE @club_id INT
SET @club_id=(SELECT Club.club_ID
FROM Club
WHERE Club.Name=@cname)

DECLARE @match_id INT
SET @match_id=(SELECT MATCH.match_ID
FROM MATCH
WHERE Match.start_time=@timeofmatch AND Match.Host_club_Id=@club_id)
--IF (@match_id  IS NOT NULL AND @manager_id IS NOT NULL AND @rep_id IS NOT NULL)
INSERT INTO HostRequest(status,Match_ID,Manager_ID,Representative_ID)
VALUES('unhandled',@match_id,@manager_id,@rep_id)
go

create function allUnassignedMatches
(@club VARCHAR(20))

returns table 
as
return(
SELECT C1.Name AS 'Competing Club' , M.start_time AS 'Start time'
FROM Club C, Match M , CLUB C1
WHERE C.club_ID=M.Host_club_Id AND M.Stadium_id IS NULL AND C1.club_ID=M.Guest_club_id and c.name like @club
);
go

CREATE PROC addStadiumManager
@mname VARCHAR(20),
@sname VARCHAR(20),
@username VARCHAR(20),
@password VARCHAR(20)
AS
declare @sId int

set @sId= (select s.Id
from Stadium s 
Where S.Name=@sname )
if @username not in (select username from SystemUser)
begin
INSERT INTO SystemUser(userName,Password)
VALUES (@username,@password)

INSERT INTO StadiumManager(name,username,stadium_id)
VALUES (@mname,@username,@sId)
end
go

create function allPendingRequests
(@SMusername varchar (20))

returns table 
as
return(
select Cr.name AS 'Club Represantative', GC.name AS 'Guest Club name' , M.start_time AS 'Match Start_Time'
from clubRepresentative Cr , hostRequest H , match M,StadiumManager SM,club GC--,CLUB HC
where Cr.id=H.Representative_ID AND 
	  H.match_ID=M.match_ID AND 
	  GC.club_ID=M.Guest_club_id AND 
	  SM.username= @SMusername AND  
	  H.Manager_ID=SM.ID AND 
	  H.Status='unhandled' 
	  --HC.ID=M.Host_club_Id AND CR.Club_ID=HC.ID 
);
go

CREATE PROC acceptRequest
@SMusername VARCHAR (20),
@hostClub VARCHAR(20),
@competeClub VARCHAR(20),
@startTime DATETIME
AS
DECLARE @StadManager_Id INT
SELECT @StadManager_Id=S.Id
FROM StadiumManager S
WHERE S.username LIKE @SMusername

declare @stadID INT
SELECT @stadID=stadium_id
FROM StadiumManager
WHERE username LIKE @SMusername

DECLARE @ClubREp_id INT
SELECT @ClubREp_id=CR.Id
FROM ClubRepresentative CR , Club C
WHERE C.NAME LIKE @hostClub AND C.club_ID=CR.Club_ID

DECLARE @Match_Id INT 
SELECT @Match_Id =M.match_ID
FROM Match M, Club HC,CLUB GC
WHERE M.Host_club_Id=HC.club_ID AND M.Guest_club_id=GC.club_ID AND M.start_time = @startTime 
AND HC.Name=@hostClub AND GC.Name=@competeClub

DECLARE @capacity int
 set @capacity= ( select s.capacity
from match m inner join stadium s on(s.ID=m.stadium_Id)
where m.match_ID=@Match_Id)

UPDATE  HostRequest
set status='accepted'
where Match_Id=@Match_Id  AND Representative_ID=@ClubREp_id AND manager_id =@StadManager_Id

UPDATE MATCH
set Stadium_id=@stadID
where match_ID=@Match_Id

DECLARE @i int=@capacity
WHILE @i >0
begin
INSERT INTO Ticket(MATCH_ID,status)
VALUES(@Match_Id,1)
set @i = @i-1
end
go

CREATE PROC rejectRequest
@SMusername VARCHAR (20),
@hostClub VARCHAR(20),
@competeClub VARCHAR(20),
@startTime DATETIME
AS
DECLARE @StadManager_Id INT
SELECT @StadManager_Id=S.Id
FROM StadiumManager S
WHERE S.username LIKE @SMusername

DECLARE @ClubREp_id INT
SELECT @ClubREp_id=CR.Id
FROM ClubRepresentative CR , Club C
WHERE C.NAME LIKE @hostClub AND C.club_ID=CR.Club_ID

DECLARE @Match_Id INT 
SELECT @Match_Id =M.match_ID
FROM Match M, Club HC,CLUB GC
WHERE M.Host_club_Id=HC.club_ID AND M.Guest_club_id=GC.club_ID AND M.start_time = @startTime 
AND HC.Name=@hostClub AND GC.Name=@competeClub

UPDATE  HostRequest
set status='rejected'
where Match_Id=@Match_Id  AND Representative_ID=@ClubREp_id AND manager_id =@StadManager_Id
go

CREATE PROC addFan
@Fname VARCHAR(20),
@username VARCHAR(20),
@password VARCHAR(20),
@n_id VARCHAR(20),
@birth_date DATETIME,
@address VARCHAR(20),
@phone_no INT
AS
if @username not in (select username from SystemUser) AND @n_id not in (select National_Id from fan)
begin
INSERT INTO SystemUser(userName,Password)
VALUES (@username,@password)
INSERT INTO Fan(name,National_Id,Birth_date,Address,phone_no,status)
VALUES(@Fname,@n_id,@birth_date,@address,@phone_no,1)
END
go

create function upcomingMatchesOfClub
(@clubname varchar (20))

returns table 
as
return(
select   C.Name AS 'club Name' , C2.Name AS 'Competing Club', M.start_time AS 'Start Time',S.Name AS 'Stadium Name'
FROM CLUB C INNER JOIN MATCH M ON  M.Host_club_Id=C.club_ID 
INNER JOIN CLUB C2 ON  M.Guest_club_id=C2.club_ID
LEFT OUTER JOIN STADIUM S  ON S.Id=M.Stadium_id 
WHERE M.start_time>CURRENT_TIMESTAMP AND ( C.Name=@clubname )
UNION
select   C2.Name AS 'club Name' , C.Name AS 'Competing Club', M.start_time AS 'Start Time',S.Name AS 'Stadium Name'
FROM CLUB C INNER JOIN MATCH M ON  M.Host_club_Id=C.club_ID
INNER JOIN CLUB C2 ON  M.Guest_club_id=C2.club_ID
LEFT OUTER JOIN STADIUM S  ON S.Id=M.Stadium_id 
WHERE M.start_time>CURRENT_TIMESTAMP AND ( C2.Name=@clubname)
);
GO

Create function availableMatchesToAttend
(@Date date)

returns table
AS
return(

SELECT HC.Name AS 'Host Club' ,GC.Name AS 'Guest Club' ,M.start_time AS 'Start Time',S.Name AS 'Stadium' 
FROM Match M , Club HC, Club GC ,Stadium S
WHERE M.start_time>=@Date AND 
	  M.Host_club_Id=HC.club_ID AND
	  M.Guest_club_id=GC.club_ID AND
	  M.Stadium_id = S.Id AND
	  EXISTS (SELECT * 
			  FROM Ticket T
			  WHERE T.STATUS=1 AND T.MATCH_ID=M.match_ID)
)
Go

Create Procedure purchaseTicket
@nId int,
@hostClub varChar(20),
@compClub varChar(20),
@Date DateTime
As
DECLARE @host_id INT
SET @host_id=(SELECT Club.club_ID
FROM Club
WHERE Club.Name=@hostClub)

DECLARE @club_id INT
SET @club_id=(SELECT Club.club_ID
FROM Club
WHERE Club.Name=@compClub)

DECLARE @Match_Id INT 
SELECT @Match_Id =M.match_ID
FROM Match M
WHERE M.Host_club_Id=@host_id and M.Guest_club_id=@club_id and M.start_time=@Date

declare @TicketId int
set @TicketId=  (select Min( T.ID)
from  MATCH M , TICKET T
where T.MATCH_ID=M.match_ID AND T.STATUS=1)

update Ticket 
set 
STATUS='0'
where ticket.ID=@TicketId

INSERT INTO TicketBuyingTransactions(fan_nationalID,ticket_id)
VALUES (@nId,@TicketId)
go

create proc updateMatchHost
@hostName varchar(20),
@guestName varchar(20),
@date datetime 

AS

DECLARE @host_id INT
SET @host_id=(SELECT Club.club_ID
FROM Club
WHERE Club.Name=@hostName)

DECLARE @club_id INT
SET @club_id=(SELECT Club.club_ID
FROM Club
WHERE Club.Name=@guestName)


DECLARE @Match_Id INT 
SELECT @Match_Id =M.match_ID
FROM Match M
WHERE M.Host_club_Id=@host_id and M.Guest_club_id=@club_id and M.start_time=@Date

update match
set 
match.Host_club_Id=@club_id,
match.Guest_club_id=@host_id,
match.Stadium_id=NULL
where match.match_ID=@Match_Id
go

create view matchesPerTeam
AS
select Distinct (c.Name) clubName ,count(m.match_ID) NumberOfMatches
from club c left outer join match m on (c.club_ID=m.Host_club_Id or c.club_ID=m.Guest_club_id) and (m.end_time < (current_timestamp))
GROUP BY C.name
go

Create View clubsNeverMatched
As

select c1.Name AS 'first club name', C2.Name AS 'second club name'
from club c1 ,club c2 
where  c2.club_ID > c1.club_ID AND --OR C2.ID <> C1.ID (ALLOWS DUPS)
	  NOT EXISTS ( SELECT *
				   FROM MATCH M 
				   WHERE M.end_time<CURRENT_TIMESTAMP AND
				   ((M.Guest_club_id=C2.club_ID AND M.Host_club_Id=C1.club_ID) OR
				   (M.Guest_club_id=C1.club_ID AND M.Host_club_Id=C2.club_ID)))
Go

create function clubsNeverPlayed
(@clubname varchar (20))


returns table 
as
return(
select c1.Name AS 'Club Name'
from club c1,club c2
where C2.Name=@clubname AND c2.club_ID <> c1.club_ID AND
	  NOT EXISTS ( SELECT *
				   FROM MATCH M 
				   WHERE M.start_time<CURRENT_TIMESTAMP AND
				   ((M.Guest_club_id=C2.club_ID AND M.Host_club_Id=C1.club_ID) OR
				   (M.Guest_club_id=C1.club_ID AND M.Host_club_Id=C2.club_ID)))
);
GO

Create function matchWithHighestAttendance
()
returns table
AS
return(
SELECT c1.Name as 'host' ,c2.name as 'guest' 
from Ticket t inner join Match m on (m.match_ID=t.MATCH_ID) 
inner join club c1 on (c1.club_ID=m.Host_club_Id) 
inner join club c2 on(c2.club_ID=m.Guest_club_id)
where t.STATUS ='0'
group by t.MATCH_ID,c1.Name,c2.name
having count(t.ID) =(select max(table2.x)
					from  (SELECT count(t1.ID) as x
					       from Ticket t1 
					       inner join Match m1 on (m1.match_ID=t1.MATCH_ID) 
					       inner join club c11 on (c11.club_ID=m1.Host_club_Id) 
					       inner join club c22 on(c22.club_ID=m1.Guest_club_id)
					       where t1.STATUS ='0'
					       group by t1.MATCH_ID)AS table2
					       )
);
GO

 Create function matchesRankedByAttendance
()
returns table
AS
return(
select  host, guest from(
SELECT c1.Name as 'host' ,c2.name as 'guest' ,count(t.ID) as 'highest'
from Match m 
left outer join club c1 on (c1.club_ID=m.Host_club_Id) 
left outer join club c2 on(c2.club_ID=m.Guest_club_id)
left outer join ticket t on (m.match_ID=t.MATCH_ID AND T.STATUS='0' )
where  m.start_time<CURRENT_TIMESTAMP
group by m.match_ID,c1.Name,c2.name
) AS TAB
order by TAB.highest DESC
offset 0 rows

);
go

Create function requestsFromClub
(@stadName varchar(20),@clubName varchar(20))
returns table
AS
return(
select C1.Name AS'Host Club',C2.Name AS 'Guest Club'
from HostRequest h 
inner join match m on(m.match_ID=h.Match_ID) 
inner join club c1 on(c1.club_ID=m.Host_club_Id) 
inner join club c2 on (c2.club_ID=m.Guest_club_id)
inner join StadiumManager sm on h.Manager_ID =sm.id
inner join stadium s on (s.Id=sm.stadium_id) 
where s.name =@stadName and c1.Name=@clubName AND H.Status='unhandled'
)
GO
----------------------------------------------------------------------------------------------------
------------------------------------added proc and functions-----------------------------------------
-----------------------------------------------------------------------------------------------------
Create Procedure userLogin
@username varchar(20),
@password Varchar(20),
@type VARCHAR(20) OUTPUT,
@success int OUTPUT
AS

begin
IF @username NOT IN (SELECT username FROM SystemUser )
	begin
		set @success=0
		set @type='Wrong username'
	end
else
	begin
	IF @password NOT IN (SELECT password FROM SystemUser Where username=@username AND Password=@password)
		begin
			set @type='Wrong pass';
			set @success=0
		end
	else
		begin
			set @success=1;
			if exists (SELECT username FROM fan Where username=@username)
				set @type='fan';
			if exists (SELECT username FROM sportsAssociationManager Where username=@username)
				set @type='SportsAssocManager';
			if exists (SELECT username FROM StadiumManager Where username=@username)
				set @type='StadiumManager';
			if exists (SELECT username FROM ClubRepresentative Where username=@username)
				set @type='ClubRepresentative';
			if exists (SELECT username FROM SystemAdmin Where username=@username)
				set @type='SystemAdmin';
		end
	end
end

--select * from systemUser
--declare @t varchar(20)
--declare @suc int
--exec userLogin 'fan1','fan1',@t OUTPUT,@suc OUTPUT
--select @t
--select(@suc)
--drop proc userLogin
GO
Create proc registerstadiummanager
@mname VARCHAR(20),
@sname VARCHAR(20),
@username VARCHAR(20),
@password VARCHAR(20),
@suc int output,
@type varchar(50) OUTPUT
AS 
BEGIN
if @username in (select userName from SystemUser)
	begin
		set @suc=0;
		set @type='username is taken';
	end
else
	begin
		if exists(select * from stadium s, StadiumManager sm where s.id=sm.stadium_id and s.Name = @sname)
			begin
				print ('here')
				set @suc=0;
				set @type='stadium already has a manager';
			end
		else 
			begin
				exec addStadiumManager @mname ,@sname ,@username,@password
				set @suc=1;
				set @type=' Your registration was successful!';
			end
	end
END

