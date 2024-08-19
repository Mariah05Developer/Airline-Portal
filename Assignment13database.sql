-- --------------------------------------------------------------------------------
-- Name: Mariah Jackson
 
-- Abstract: FlyMe2theMoon
-- --------------------------------------------------------------------------------

-- --------------------------------------------------------------------------------
-- Options
-- --------------------------------------------------------------------------------
USE dbFlyMe2theMoon;     
SET NOCOUNT ON;  

-- --------------------------------------------------------------------------------
--						Problem #10
-- --------------------------------------------------------------------------------

-- Drop Table Statements
IF OBJECT_ID ('TPilotFlights')			IS NOT NULL DROP TABLE TPilotFlights
IF OBJECT_ID ('TAttendantFlights')		IS NOT NULL DROP TABLE TAttendantFlights
IF OBJECT_ID ('TFlightPassengers')		IS NOT NULL DROP TABLE TFlightPassengers
IF OBJECT_ID ('TMaintenanceMaintenanceWorkers')			IS NOT NULL DROP TABLE TMaintenanceMaintenanceWorkers

IF OBJECT_ID ('TPassengers')			IS NOT NULL DROP TABLE TPassengers
IF OBJECT_ID ('TPilots')				IS NOT NULL DROP TABLE TPilots
IF OBJECT_ID ('TAttendants')			IS NOT NULL DROP TABLE TAttendants
IF OBJECT_ID ('TEmployees')				IS NOT NULL DROP TABLE TEmployees
IF OBJECT_ID ('TMaintenanceWorkers')	IS NOT NULL DROP TABLE TMaintenanceWorkers

IF OBJECT_ID ('TFlights')				IS NOT NULL DROP TABLE TFlights
IF OBJECT_ID ('TMaintenances')			IS NOT NULL DROP TABLE TMaintenances
IF OBJECT_ID ('TPlanes')				IS NOT NULL DROP TABLE TPlanes
IF OBJECT_ID ('TPlaneTypes')			IS NOT NULL DROP TABLE TPlaneTypes
IF OBJECT_ID ('TPilotRoles')			IS NOT NULL DROP TABLE TPilotRoles
IF OBJECT_ID ('TAirports')				IS NOT NULL DROP TABLE TAirports
IF OBJECT_ID ('TStates')				IS NOT NULL DROP TABLE TStates 
--IF OBJECT_ID ('TRoles')					IS NOT NULL DROP TABLE TRoles




--SELECT 'DROP PROCEDURE ' + SCHEMA_NAME(schema_id) + '.' + name + ';'
--FROM sys.procedures

--DROP PROCEDURE dbo.uspAddAttendant
--DROP PROCEDURE dbo.uspAddFlightPassengers
--DROP PROCEDURE dbo.uspAddPilot
--DROP PROCEDURE dbo.uspAddPilotFlight
-- --------------------------------------------------------------------------------
--	Step #1 : Create table 
-- --------------------------------------------------------------------------------

CREATE TABLE TPassengers
(
	 intPassengerID			INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strLoginID				VARCHAR(255)	NOT NULL
	,strPassword			VARCHAR(255)	NOT NULL
	,dtmDateofBirth			DATETIME		NOT NULL
	,strAddress				VARCHAR(255)	NOT NULL
	,strCity				VARCHAR(255)	NOT NULL
	,intStateID				INTEGER			NOT NULL
	,strZip					VARCHAR(255)	NOT NULL
	,strPhoneNumber			VARCHAR(255)	NOT NULL
	,strEmail				VARCHAR(255)	NOT NULL
	,CONSTRAINT TPassengers_PK PRIMARY KEY ( intPassengerID )
)


CREATE TABLE TPilots
(
	 intPilotID				INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strEmployeeID			VARCHAR(255)	NOT NULL
	,strLoginID				VARCHAR(255)	NOT NULL
	,strPassword			VARCHAR(255)	NOT NULL
	,dtmDateOfHire			DATETIME		NOT NULL
	,dtmDateOfTermination	DATETIME		NOT NULL
	,dtmDateOfLicense		DATETIME		NOT NULL
	,intPilotRoleID			INTEGER			NOT NULL

	,CONSTRAINT TPilots_PK PRIMARY KEY ( intPilotID )
)


CREATE TABLE TAttendants
(
	 intAttendantID			INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strEmployeeID			VARCHAR(255)	NOT NULL
	,strLoginID				VARCHAR(255)	NOT NULL
	,strPassword			VARCHAR(255)	NOT NULL
	,dtmDateOfHire			DATETIME		NOT NULL
	,dtmDateOfTermination	DATETIME		NOT NULL
	,CONSTRAINT TAttendants_PK PRIMARY KEY ( intAttendantID )
)



CREATE TABLE TEmployees
(
	 intEmployeePrimaryID	INTEGER			NOT NULL
	,strLoginID				VARCHAR(255)	NOT NULL
	,strPassword			VARCHAR(255)	NOT NULL
	,strRole				VARCHAR(255)	NOT NULL
	,intEmployeeID			INTEGER			NOT NULL
	,CONSTRAINT TEmployees_PK PRIMARY KEY ( intEmployeePrimaryID )
)


--CREATE TABLE TRoles
--(
--	 intRoleID				INTEGER			NOT NULL
--	,strRole				VARCHAR(255)	NOT NULL
--	,CONSTRAINT TRoles_PK PRIMARY KEY ( intRoleID )
--)




CREATE TABLE TMaintenanceWorkers
(
	 intMaintenanceWorkerID	INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strEmployeeID			VARCHAR(255)	NOT NULL
	,dtmDateOfHire			DATETIME		NOT NULL
	,dtmDateOfTermination	DATETIME		NOT NULL
	,dtmDateOfCertification	DATETIME		NOT NULL
	,CONSTRAINT TMaintenanceWorkers_PK PRIMARY KEY ( intMaintenanceWorkerID )
)


CREATE TABLE TStates
(
	 intStateID			INTEGER			NOT NULL
	,strState			VARCHAR(255)	NOT NULL
	,CONSTRAINT TStates_PK PRIMARY KEY ( intStateID )
)


CREATE TABLE TFlights
(
	 intFlightID			INTEGER			NOT NULL
	,strFlightNumber		VARCHAR(255)	NOT NULL
	,dtmFlightDate			DATETIME		NOT NULL
	,dtmTimeofDeparture		TIME			NOT NULL
	,dtmTimeOfLanding		TIME			NOT NULL
	,intFromAirportID		INTEGER			NOT NULL
	,intToAirportID			INTEGER			NOT NULL
	,intMilesFlown			INTEGER			NOT NULL
	,intPlaneID				INTEGER			NOT NULL
	,CONSTRAINT TFlights_PK PRIMARY KEY ( intFlightID )
)


CREATE TABLE TMaintenances
(
	 intMaintenanceID		INTEGER			NOT NULL
	,strWorkCompleted		VARCHAR(8000)	NOT NULL
	,dtmMaintenanceDate		DATETIME		NOT NULL
	,intPlaneID				INTEGER			NOT NULL
	,CONSTRAINT TMaintenances_PK PRIMARY KEY ( intMaintenanceID )
)


CREATE TABLE TPlanes
(
	 intPlaneID				INTEGER			NOT NULL
	,strPlaneNumber			VARCHAR(255)	NOT NULL
	,intPlaneTypeID			INTEGER			NOT NULL
	,CONSTRAINT TPlanes_PK PRIMARY KEY ( intPlaneID )
)


CREATE TABLE TPlaneTypes	
(
	 intPlaneTypeID			INTEGER			NOT NULL
	,strPlaneType			VARCHAR(255)	NOT NULL
	,CONSTRAINT TPlaneTypes_PK PRIMARY KEY ( intPlaneTypeID )
)


CREATE TABLE TPilotRoles	
(
	 intPilotRoleID			INTEGER			NOT NULL
	,strPilotRole			VARCHAR(255)	NOT NULL
	,CONSTRAINT TPilotRoles_PK PRIMARY KEY ( intPilotRoleID )
)


CREATE TABLE TAirports
(
	 intAirportID			INTEGER			NOT NULL
	,strAirportCity			VARCHAR(255)	NOT NULL
	,strAirportCode			VARCHAR(255)	NOT NULL
	,CONSTRAINT TAirports_PK PRIMARY KEY ( intAirportID )
)


CREATE TABLE TPilotFlights
(
	 intPilotFlightID		INTEGER			NOT NULL
	,intPilotID				INTEGER			NOT NULL
	,intFlightID			INTEGER			NOT NULL
	,CONSTRAINT TPilotFlights_PK PRIMARY KEY ( intPilotFlightID )
)


CREATE TABLE TAttendantFlights
(
	 intAttendantFlightID		INTEGER			NOT NULL
	,intAttendantID				INTEGER			NOT NULL
	,intFlightID				INTEGER			NOT NULL
	,CONSTRAINT TAttendantFlights_PK PRIMARY KEY ( intAttendantFlightID )
)


CREATE TABLE TFlightPassengers
(
	 intFlightPassengerID		INTEGER			NOT NULL
	,intFlightID				INTEGER			NOT NULL
	,intPassengerID				INTEGER			NOT NULL
	,strSeat					VARCHAR(255)	NULL
	,intFlightCost				INTEGER			NOT NULL
	,CONSTRAINT TFlightPassengers_PK PRIMARY KEY ( intFlightPassengerID )
)


CREATE TABLE TMaintenanceMaintenanceWorkers
(
	 intMaintenanceMaintenanceWorkerID		INTEGER			NOT NULL
	,intMaintenanceID						INTEGER			NOT NULL
	,intMaintenanceWorkerID					INTEGER			NOT NULL
	,intHours								INTEGER			NOT NULL
	,CONSTRAINT TMaintenanceMaintenanceWorkers_PK PRIMARY KEY ( intMaintenanceMaintenanceWorkerID )
)

-- --------------------------------------------------------------------------------
--	Step #2 : Establish Referential Integrity 
-- --------------------------------------------------------------------------------
--
-- #	Child							Parent						Column
-- -	-----							------						---------
-- 1	TPassengers						TStates						intStateID	
-- 2	TFlightPassenger				TPassengers					intPassengerID
-- 3	TFlights						TPlanes						intPlaneID
-- 4	TFlights						TAirports					intFromAiportID
-- 5	TFlights						TAirports					intToAiportID
-- 6	TPilotFlights					TFlights					intFlightID
-- 7	TAttendantFlights				TFlights					intFlightID
-- 8	TPilotFlights					TPilots						intPilotID
-- 9	TAttendantFlights				TAttendants					intAttendantID
-- 10	TPilots							TPilotRoles					intPilotRoleID
-- 11	TPlanes							TPlaneTypes					intPlaneTypeID
-- 12	TMaintenances					TPlanes						intPlaneID
-- 13	TMaintenanceMaintenanceWorkers	TMaintenance				intMaintenanceID
-- 14	TMaintenanceMaintenanceWorkers	TMaintenanceWorker			intMaintenanceWorkerID
-- 15	TFlightPassenger				TFlights					intFlightID
--16	TEmployees						TRoles						intRoleID

--1
ALTER TABLE TPassengers ADD CONSTRAINT TPassengers_TStates_FK 
FOREIGN KEY ( intStateID ) REFERENCES TStates ( intStateID ) On DELETE CASCADE

--2
ALTER TABLE TFlightPassengers ADD CONSTRAINT TPFlightPassengers_TPassengers_FK 
FOREIGN KEY ( intPassengerID ) REFERENCES TPassengers ( intPassengerID ) On DELETE CASCADE

--3
ALTER TABLE TFlights	 ADD CONSTRAINT TFlights_TPlanes_FK 
FOREIGN KEY ( intPlaneID ) REFERENCES TPlanes ( intPlaneID ) On DELETE CASCADE

--4
ALTER TABLE TFlights	 ADD CONSTRAINT TFlights_TFromAirports_FK 
FOREIGN KEY ( intFromAirportID ) REFERENCES TAirports ( intAirportID ) On DELETE CASCADE

--5
ALTER TABLE TFlights	 ADD CONSTRAINT TFlights_TToAirports_FK 
FOREIGN KEY ( intToAirportID ) REFERENCES TAirports ( intAirportID )  

--6
ALTER TABLE TPilotFlights	 ADD CONSTRAINT TPilotFlights_TFlights_FK 
FOREIGN KEY ( intFlightID ) REFERENCES TFlights (intFlightID )  On DELETE CASCADE

--7
ALTER TABLE TAttendantFlights	 ADD CONSTRAINT TAttendantFlights_TFlights_FK 
FOREIGN KEY ( intFlightID ) REFERENCES TFlights (intFlightID )  On DELETE CASCADE

--8
ALTER TABLE TPilotFlights	 ADD CONSTRAINT TPilotFlights_TPilots_FK 
FOREIGN KEY ( intPilotID ) REFERENCES TPilots (intPilotID )  On DELETE CASCADE

--9
ALTER TABLE TAttendantFlights	 ADD CONSTRAINT TAttendantFlights_TAttendants_FK 
FOREIGN KEY ( intAttendantID ) REFERENCES TAttendants (intAttendantID ) On DELETE CASCADE

--10
ALTER TABLE TPilots	 ADD CONSTRAINT TPilots_TPilotRoles_FK 
FOREIGN KEY ( intPilotRoleID ) REFERENCES TPilotRoles (intPilotRoleID )   On DELETE CASCADE

--11
ALTER TABLE TPlanes	 ADD CONSTRAINT TPlanes_TPlaneTypes_FK 
FOREIGN KEY ( intPlaneTypeID ) REFERENCES TPlaneTypes (intPlaneTypeID )  On DELETE CASCADE

--12
ALTER TABLE TMaintenances	 ADD CONSTRAINT TMaintenances_TPlanes_FK 
FOREIGN KEY ( intPlaneID ) REFERENCES TPlanes (intPlaneID )   On DELETE CASCADE

--13
ALTER TABLE TMaintenanceMaintenanceWorkers	 ADD CONSTRAINT TMaintenanceMaintenanceWorkers_TMaintenances_FK 
FOREIGN KEY ( intMaintenanceID ) REFERENCES TMaintenances (intMaintenanceID )  On DELETE CASCADE

--14
ALTER TABLE TMaintenanceMaintenanceWorkers	 ADD CONSTRAINT TMaintenanceMaintenanceWorkers_TMaintenanceWorkers_FK 
FOREIGN KEY ( intMaintenanceWorkerID ) REFERENCES TMaintenanceWorkers (intMaintenanceWorkerID )  On DELETE CASCADE

--15
ALTER TABLE TFlightPassengers	 ADD CONSTRAINT TFlightPassengers_TFlights_FK 
FOREIGN KEY ( intFlightID ) REFERENCES TFlights (intFlightID )  On DELETE CASCADE


----16
--ALTER TABLE TEmployees	 ADD CONSTRAINT TEmployees_TRoles_FK 
--FOREIGN KEY ( intRoleID ) REFERENCES TRoles (intRoleID )  On DELETE CASCADE


-- --------------------------------------------------------------------------------
--	Step #3 : Add Data - INSERTS
-- --------------------------------------------------------------------------------
INSERT INTO TStates( intStateID, strState)
VALUES				(1, 'Ohio')
				   ,(2, 'Kentucky')
				   ,(3, 'Indiana')

--INSERT INTO TRoles ( intRoleID, strRole )
--VALUES				(1, 'Pilot')
--					   ,(2, 'Attendant')
--					  ,(3, 'Admin')


INSERT INTO TPilotRoles( intPilotRoleID, strPilotRole)
VALUES				(1, 'Co-Pilot')
				   ,(2, 'Captain')

				
INSERT INTO TPlaneTypes( intPlaneTypeID, strPlaneType)
VALUES				(1, 'Airbus A350')
				   ,(2, 'Boeing 747-8')
				   ,(3, 'Boeing 767-300F')


INSERT INTO TPlanes( intPlaneID, strPlaneNumber, intPlaneTypeID)
VALUES				(1, '4X887G', 1)
				   ,(2, '5HT78F', 2)
				   ,(3, '5TYY65', 2)
				   ,(4, '4UR522', 1)
				   ,(5, '6OP3PK', 3)
				   ,(6, '67TYHH', 3)


INSERT INTO TAirports( intAirportID, strAirportCity, strAirportCode)
VALUES				(1, 'Cincinnati', 'CVG')
				   ,(2, 'Miami', 'MIA')
				   ,(3, 'Ft. Meyer', 'RSW')
				   ,(4, 'Louisville',  'SDF')
				   ,(5, 'Denver', 'DEN')
				   ,(6, 'Orlando', 'MCO' )


INSERT INTO TPassengers (intPassengerID, strFirstName, strLastName, strLoginID, strPassword, dtmDateofBirth , strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail)
VALUES				  (1, 'Knelly', 'Nervious','Knelly', 'Apple1', '12/1/2000', '321 Elm St.', 'Cincinnati', 1, '45201', '5135553333', 'nnelly@gmail.com')
					 ,(2, 'Orville', 'Waite','Orville', 'watch1', '1/1/1990', '987 Oak St.', 'Cleveland', 1, '45218', '5135556333', 'owright@gmail.com')
					 ,(3, 'Eileen', 'Awnewe','Eileen', 'mirandaluv','5/23/2002', '1569 Windisch Rd.', 'Dayton', 1, '45069', '5135555333', 'eonewe1@yahoo.com')
					 ,(4, 'Bob', 'Eninocean','bob', 'Armyvet12', '8/6/1967', '44561 Oak Ave.', 'Florence', 2, '45246', '8596663333', 'bobenocean@gmail.com')
					 ,(5, 'Ware', 'Hyjeked','ware', 'Merdithdove', '10/5/1997', '44881 Pine Ave.', 'Aurora', 3, '45546', '2825553333', 'Hyjekedohmy@gmail.com')
					 ,(6, 'Kay', 'Oss','kay', 'bangtan', '11/11/1942', '4484 Bushfield Ave.', 'Lawrenceburg', 3, '45546', '2825553333', 'wehavekayoss@gmail.com')


INSERT INTO TPilots (intPilotID, strFirstName, strLastName, strEmployeeID, strLoginID, strPassword,  dtmDateofHire, dtmDateofTermination, dtmDateofLicense, intPilotRoleID)
VALUES				  (1, 'Tip', 'Seenow', '12121','Tippy', 'brown', '1/1/2015', '1/1/2099', '12/1/2014', 1)
					 ,(2, 'Ima', 'Soring', '13322','soring', '112345', '1/1/2016', '1/1/2099', '12/1/2015', 1)
					 ,(3, 'Hugh', 'Encharge', '16666', '1enchhug', 'password','1/1/2017', '1/1/2099', '12/1/2016', 2)
					 ,(4, 'Iwanna', 'Knapp', '17676','iwnaa', 'iwana1', '1/1/2014', '1/1/2015', '12/1/2013', 1)
					 ,(5, 'Rose', 'Ennair', '19909','cricketloveu', '9876password', '1/1/2012', '1/1/2099', '12/1/2011', 2)


INSERT INTO TAttendants (intAttendantID, strFirstName, strLastName, strEmployeeID, strLoginID, strPassword, dtmDateofHire, dtmDateofTermination)
VALUES				  (1, 'Miller', 'Tyme', '22121','Tyme', 'password', '1/1/2015', '1/1/2099')
					 ,(2, 'Sherley', 'Ujest', '23322','sher', '12345', '1/1/2016', '1/1/2099')
					 ,(3, 'Buhh', 'Biy', '26666','billy', '0000', '1/1/2017', '1/1/2099')
					 ,(4, 'Myles', 'Amanie', '27676','myles', 'mylesamanie', '1/1/2014', '1/1/2015')
					 ,(5, 'Walker', 'Toexet', '29909','walkerT', 'wt10', '1/1/2012', '1/1/2099')




INSERT INTO TEmployees (intEmployeePrimaryID, strLoginID, strPassword, strRole, intEmployeeID)
VALUES				  (1, 'Tippy', 'brown', 'Pilot','1')
					 ,(2, 'soring', '112345', 'Pilot','2')
					 ,(3, '1enchhug', 'password', 'Pilot','3')
					 ,(4, 'iwnaa', 'iwana1', 'Pilot','4')
					 ,(5, 'cricketloveu', '9876password',  'Pilot', '5')
					 , (6, 'Tyme', 'password', 'Attendant','1')
					 ,(7, 'sher', '12345', 'Attendant','2')
					 ,(8, 'billy', '0000', 'Attendant','3')
					 ,(9, 'myles', 'mylesamanie', 'Attendant','4')
					 ,(10, 'walkerT', 'wt10',  'Attendant', '5')
					 ,(11, 'RM', 'Bangtan', 'Admin','1')
					 ,(12, 'SeokJin', 'Jinnie', 'Admin','2')
					 ,(13, 'Seven', 'SSHNJTJ',  'Admin', '3')


INSERT INTO TMaintenanceWorkers (intMaintenanceWorkerID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination, dtmDateOfCertification)
VALUES				  (1, 'Gressy', 'Nuckles', '32121', '1/1/2015', '1/1/2099', '12/1/2014')
					 ,(2, 'Bolt', 'Izamiss', '33322', '1/1/2016', '1/1/2099', '12/1/2015')
					 ,(3, 'Sharon', 'Urphood', '36666', '1/1/2017', '1/1/2099','12/1/2016')
					 ,(4, 'Ides', 'Racrozed', '37676', '1/1/2014', '1/1/2015','12/1/2013')
					

INSERT INTO TMaintenances (intMaintenanceID, strWorkCompleted, dtmMaintenanceDate, intPlaneID)
VALUES				  (1, 'Fixed Wing', '1/1/2022', 1)
					 ,(2, 'Repaired Flat Tire', '3/1/2022', 2)
					 ,(3, 'Added Wiper Fluid', '4/1/2022', 3)
					 ,(4, 'Tightened Engine to Wing', '5/1/2022', 2)
					 ,(5, '100,000 mile checkup', '3/10/2022', 4)
					 ,(6, 'Replaced Loose Door', '4/10/2022', 6)
					 ,(7, 'Trapped Raccoon in Cargo Hold', '5/1/2022', 6)


INSERT INTO TFlights (intFlightID, dtmFlightDate, strFlightNumber,  dtmTimeofDeparture, dtmTimeOfLanding, intFromAirportID, intToAirportID, intMilesFlown, intPlaneID)
VALUES				  (1, '4/1/2022', '111', '10:00:00', '12:00:00', 1, 2, 1200, 2)
					 ,(2, '4/4/2022', '222','13:00:00', '15:00:00', 1, 3, 1000, 2)
					 ,(3, '4/5/2022', '333','15:00:00', '17:00:00', 1, 5, 1200, 3)
					 ,(4, '4/16/2022','444', '10:00:00', '12:00:00', 4, 6, 1100, 3)
					 ,(5, '3/14/2022','555', '18:00:00', '20:00:00', 2, 1, 1200, 3)
					 ,(6, '3/21/2022','666', '19:00:00', '21:00:00', 3, 1, 1000, 1)
					 ,(7, '3/11/2022', '777','20:00:00', '22:00:00', 3, 6, 1400, 4)
					 ,(8, '3/17/2028', '888','09:00:00', '11:00:00', 6, 4, 1100, 5)
					 ,(9, '4/19/2024', '999','08:00:00', '10:00:00', 4, 2, 1000, 6)
					 ,(10, '4/22/2024', '123','10:00:00', '12:00:00', 2, 1, 1200, 6)
					 ,(11, '3/21/2024','456', '19:00:00', '21:00:00', 3, 1, 1000, 1)
					 ,(12, '3/11/2025', '450','20:00:00', '22:00:00', 3, 6, 1400, 4)
					 ,(13, '3/17/2025', '452','09:00:00', '11:00:00', 6, 4, 1100, 5)
					 ,(14, '4/19/2028', '453','08:00:00', '10:00:00', 4, 2, 1000, 6)
					 ,(15, '4/22/2030', '090','10:00:00', '12:00:00', 2, 1, 1200, 6)


INSERT INTO TPilotFlights ( intPilotFlightID, intPilotID, intFlightID)
VALUES				 ( 1, 1, 2 )
					,( 2, 1, 3 )
					,( 3, 3, 3 )
					,( 4, 3, 2 )
					,( 5, 5, 1 )
					,( 6, 2, 1 )
					,( 7, 3, 4 )
					,( 8, 2, 4 )
					,( 9, 2, 5 )
					,( 10, 3, 5 )
					,( 11, 5, 6 )
					,( 12, 1, 6 )


INSERT INTO TAttendantFlights ( intAttendantFlightID, intAttendantID, intFlightID)
VALUES				( 1, 1, 2 )
					,( 2, 2, 3 )
					,( 3, 3, 3 )
					,( 4, 4, 2 )
					,( 5, 5, 1 )
					,( 6, 1, 1 )
					,( 7, 2, 4 )
					,( 8, 3, 4 )
					,( 9, 4, 5 )
					,( 10, 5, 5 )
					,( 11, 5, 6 )
					,( 12, 1, 6 )
					

INSERT INTO TFlightPassengers ( intFlightPassengerID, intFlightID, intPassengerID, strSeat,intFlightCost)
VALUES				 ( 1, 1, 1, '1A', 450)
					,( 2, 1, 2, '2A' ,890)
					,( 3, 1, 3, '1B' ,209)
					,( 4, 1, 4, '1C' ,179)
					,( 5, 1, 5, '1D' ,678)
					,( 6, 2, 5, '1A' ,678)
					,( 7, 2, 4, '2A' ,456)
					,( 8, 2, 3, '1B' ,345)
					,( 9, 3, 1, '1B' ,223)
					,( 10, 3, 2, '2A',567)
					,( 11, 3, 3, '1B',789)
					,( 12, 3, 4, '1C' ,789)
					,( 13, 3, 5, '1D' ,234)
					,( 14, 4, 2, '1A' ,567)
					,( 15, 4, 3, '1B' ,341)
					,( 16, 4, 4, '1C' ,789)
					,( 17, 4, 5, '1D' ,189)
					,( 18, 5, 1, '1A' ,567)
					,( 19, 5, 2, '2A' ,198)
					,( 20, 5, 3, '1B' ,789)
					,( 21, 5, 4, '2B' ,543)
					,( 22, 6, 1, '1A' ,590)
					,( 23, 6, 2, '2A' ,378)
					,( 24, 6, 3, '3A' ,985)
					

INSERT INTO TMaintenanceMaintenanceWorkers ( intMaintenanceMaintenanceWorkerID, intMaintenanceID, intMaintenanceWorkerID, intHours)
VALUES				 ( 1, 2, 1, 2 )
					,( 2, 4, 1, 3 )
					,( 3, 2, 3, 4 )
					,( 4, 1, 4, 2 )
					,( 5, 3, 4, 2 )
					,( 6, 4, 3, 5 )
					,( 7, 5, 1, 7 )
					,( 8, 6, 1, 2 )
					,( 9, 7, 3, 4 )
					,( 10, 4, 4, 1 )
					,( 11, 3, 3, 4 )
					,( 12, 7, 3, 8 )

 
 --SELECT strLoginID, strPassword
 --FROM TPassengers
 --WHERE strLoginID = 'Knelly' 
 --and strPassword= 'Apple1'




--Select  Count(strFirstName)
--From  TFlightPassengers As TFP Join TPassengers As TP
--On    TFP.intPassengerID=TP.intPassengerID
--Where intFlightID =4
--Group By strFirstName

--Select strPlaneType
--From TPlaneTypes As TPT Join TPlanes As TP
--On  TPT.intPlaneTypeID = TP.intPlaneTypeID

--Join  TFLights As TF
--On  TF.intPlaneID= TP.intPlaneID
--Where intFlightID =1

--Select intAirportID
--From TAirports As TA Join TFlights As TF
--On  TA.intAirportID=TF.intToAirportID
--Where intFlightID =1





--Select intMilesFlown
--From TFLights
--Where intFlightID =


--Select  strLoginID, strPassword, intPassengerID, strFirstName,strLastName
--  From   TPassengers 
--Where	strLoginID  =  'Knelly'
--   and  strPassword = 'Apple1'


--   go


----1  In form future flights (this procedure is for the label output)

--CREATE PROCEDURE uspCustomerFutureFlights(
--		@Passenger_id AS INTEGER
		
--)
--As

--BEGIN
--			SELECT Sum(intMilesFlown) as TotalMilesFlown  
--            FROM TFlights as TF Join TFlightPassengers As TFP 
--                   On TF.intFlightID=TFP.intFlightID 
--           Join TPassengers As TP 
--                  On TFP.intPassengerID=TP.intPassengerID 
--            WHERE dtmFlightDate >= GETDATE() 
--            and TP.intPassengerID=  @Passenger_id 
 
--  End;

--  go

----Execute   uspCustomerFutureFlights 1


----2   In form future flights (this procedure is for the list box output)

--CREATE PROCEDURE uspCustomerFutureFlightsListbox(
--		@Passenger_id AS INTEGER
		
--)
--As

--BEGIN
--			  SELECT TFP.intFlightPassengerID, TF.* 
--              FROM TFlights as TF LEFT JOIN TFlightPassengers as TFP 
--					On TF.intFlightID=TFP.intFlightID 
--              Join TPassengers As TP 
--                    On TFP.intPassengerID=TP.intPassengerID 
--              WHERE dtmFlightDate >= GETDATE() 
--                and TP.intPassengerID= @Passenger_id
--  End;

--  go
  
----Execute   uspCustomerFutureFlightsListBox 4



----3 In form Past flights (this procedure is for the label output)

--CREATE PROCEDURE uspCustomerPastFlights(
--		@Passenger_id AS INTEGER
		
--)
--As

--BEGIN
--			SELECT Sum(intMilesFlown) as TotalMilesFlown  
--            FROM TFlights as TF Join TFlightPassengers As TFP 
--                   On TF.intFlightID=TFP.intFlightID 
--           Join TPassengers As TP 
--                  On TFP.intPassengerID=TP.intPassengerID 
--            WHERE dtmFlightDate <= GETDATE() 
--            and TP.intPassengerID=  @Passenger_id 
--  End;
--   go

----Execute   uspCustomerPastFlights 1


----4  In form Past flights (this procedure is for the list box output)

--CREATE PROCEDURE uspCustomerPastFlightsListbox(
--		@Passenger_id AS INTEGER
		
--)
--As

--BEGIN
--			  SELECT TFP.intFlightPassengerID, TF.* 
--              FROM TFlights as TF LEFT JOIN TFlightPassengers as TFP 
--					On TF.intFlightID=TFP.intFlightID 
--              Join TPassengers As TP 
--                    On TFP.intPassengerID=TP.intPassengerID 
--              WHERE dtmFlightDate <= GETDATE() 
--                and TP.intPassengerID= @Passenger_id
--  End;

--  go

----Execute   uspCustomerPastFlightsListBox 4


----5 In form Pilot Future flights (this procedure is for the label output)

--CREATE PROCEDURE uspPilotFutureFlights(
--		@Pilot_id AS INTEGER
		
--)
--As

--BEGIN
--			  SELECT Sum(intMilesFlown) as TotalMilesFlown  
--              FROM TFlights as TF Join TPilotFlights As TPF 
--                      On TF.intFlightID=TPF.intFlightID 
--             Join TPilots As TP
--                      On TPF.intPilotID=TP.intPilotID 
--              WHERE dtmFlightDate >= GETDATE() 
--                and TP.intPilotID= @Pilot_id 
--  End;

--  go

----Execute  uspPilotFutureFlights 1


----6 In form Pilot Future flights (this procedure is for the list box output)

--CREATE PROCEDURE uspPilotFutureFlightsListbox(
--		@Pilot_id AS INTEGER
		
--)
--As

--BEGIN
--			  SELECT intPilotFlightID , TF.*
--              FROM TFlights as TF LEFT JOIN TPilotFlights  as TPF 
--                     On TF.intFlightID = TPF.intFlightID 
--              Join TPilots As TP 
--                     On TPF.intPilotID = TP.intPilotID 
--             WHERE dtmFlightDate >= GETDATE() 
--              and TP.intPilotID= @Pilot_id 
--  End;

--  go

--Execute  uspPilotFutureFlightsListbox 1



  --SELECT Sum(intMilesFlown) as TotalMilesFlown  
  --          FROM TFlights as TF Join TFlightPassengers As TFP 
  --                 On TF.intFlightID=TFP.intFlightID 
  --         Join TPassengers As TP 
  --                On TFP.intPassengerID=TP.intPassengerID 
  --          WHERE dtmFlightDate >= GETDATE() 
  --          and TP.intPassengerID=  2

 --SELECT Sum(intMilesFlown) as TotalMilesFlown 
 --                       FROM TFlights as TF Join TFlightPassengers As TFP
 --                       On TF.intFlightID=TFP.intFlightID 
 --                       Join TPassengers As TP 
 --                       On TFP.intPassengerID=TP.intPassengerID
 --                       where TP.intPassengerID= 2


-- SELECT   Sum(TF.intMilesFlown) as TotalMilesFlown
-- FROM     TFlights as TF Join TFlightPassengers As TFP 
-- On			TF.intFlightID=TFP.intFlightID 
--			Join TPassengers As TP 
--On TFP.intPassengerID=TP.intPassengerID 
		 
--WHERE		dtmFlightDate <= GETDATE() 
--	and   TP.intPassengerID=   1
  

--SELECT   TFP.intFlightPassengerID, TF.*
--FROM TFlights as TF LEFT JOIN TFlightPassengers as TFP 
--On TF.intFlightID=TFP.intFlightID 
--Join TPassengers As TP 
--On TFP.intPassengerID=TP.intPassengerID 
----Where TP.intPassengerID= 1


-- SELECT Count(intPassengerID) as TotalCustomers  
-- From TPassengers


--  SELECT AVG(intMilesFlown) as AverageMiles 
--   FROM TFlights as TF


    --SELECT Sum (TF.intMilesFlown)as TotalperPilot,TP.strFirstName, TP.strLastName 
    --                    FROM TFlights as TF  JOIN TPilotFlights as TPF 
    --                    ON TF.intFlightID = TPF.intFlightID 
    --                     Right  Join TPilots As TP 
    --                     oN TPF.intPilotID=TP.intPilotID 
    --                     Group By  TP.strFirstName, TP.strLastName 



	  --SELECT Sum(intMilesFlown) as TotalMilesFlown  
   --                     FROM TFlights as TF Join TPilotFlights As TPF 
   --                     On TF.intFlightID = TPF.intFlightID 
   --                     Join TPilots As TP 
   --                      On TPF.intPilotID=TP.intPilotID 
   --                      WHERE dtmFlightDate <= GETDATE() 
   --                       and TP.intPilotID= 2


			--			   SELECT intPilotFlightID , TF.*
   --                     FROM TFlights as TF LEFT JOIN TPilotFlights  as TPF 
   --                      On TF.intFlightID=TPF.intFlightID 
   --                      Join TPilots As TP 
   --                       On TPF.intPilotID=TP.intPilotID 
   --                      WHERE dtmFlightDate <= GETDATE() 
   --                      and TP.intPilotID= 2


     --SELECT Sum(intMilesFlown) as TotalMilesFlown  
     --                   FROM TFlights as TF Join TAttendantFlights As TAF 
     --                   On TF.intFlightID=TAF.intFlightID 
     --                 Right  Join TAttendants As TA 
     --                     On TAF.intAttendantID=TA.intAttendantID 
     --                     WHERE dtmFlightDate >= GETDATE() 
     --                     and TA.intAttendantID=  4

						    --SELECT intAttendantFlightID , TF.* 
          --               FROM TFlights as TF LEFT JOIN TAttendantFlights  as TAF 
          --              On TF.intFlightID = TAF.intFlightID 
          --              Join TAttendants As TA 
          --                On TAF.intAttendantID = TA.intAttendantID 
          --               WHERE dtmFlightDate >= GETDATE() 
          --               and TA.intAttendantID=  4

		  --			SELECT intFlightID, strFlightNumber  FROM TFlights
		  --            Where dtmFlightDate >= GETDATE()
