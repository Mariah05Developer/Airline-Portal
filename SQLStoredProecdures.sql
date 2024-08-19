
--1  In form future flights (this procedure is for the label output)

CREATE PROCEDURE uspCustomerFutureFlights(
		@Passenger_id AS Varchar
		
)
As

BEGIN
			SELECT Sum(intMilesFlown) as TotalMilesFlown  
            FROM TFlights as TF Join TFlightPassengers As TFP 
                   On TF.intFlightID=TFP.intFlightID 
           Join TPassengers As TP 
                  On TFP.intPassengerID=TP.intPassengerID 
            WHERE dtmFlightDate >= GETDATE() 
            and TP.intPassengerID=  @Passenger_id 
 
  End;

--Execute   uspCustomerFutureFlights 1


--2   In form future flights (this procedure is for the list box output)

CREATE PROCEDURE uspCustomerFutureFlightsListbox(
		@Passenger_id AS INTEGER
		
)
As

BEGIN
			  SELECT TFP.intFlightPassengerID, TF.* 
              FROM TFlights as TF LEFT JOIN TFlightPassengers as TFP 
					On TF.intFlightID=TFP.intFlightID 
              Join TPassengers As TP 
                    On TFP.intPassengerID=TP.intPassengerID 
              WHERE dtmFlightDate >= GETDATE() 
                and TP.intPassengerID= @Passenger_id
  End;

  
--Execute   uspCustomerFutureFlightsListBox 4



--3 In form Past flights (this procedure is for the label output)

CREATE PROCEDURE uspCustomerPastFlights(
		@Passenger_id AS INTEGER
		
)
As

BEGIN
			SELECT Sum(intMilesFlown) as TotalMilesFlown  
            FROM TFlights as TF Join TFlightPassengers As TFP 
                   On TF.intFlightID=TFP.intFlightID 
           Join TPassengers As TP 
                  On TFP.intPassengerID=TP.intPassengerID 
            WHERE dtmFlightDate <= GETDATE() 
            and TP.intPassengerID=  @Passenger_id 
  End;

--Execute   uspCustomerPastFlights 1


--4  In form Past flights (this procedure is for the list box output)

CREATE PROCEDURE uspCustomerPastFlightsListbox(
		@Passenger_id AS INTEGER
		
)
As

BEGIN
			  SELECT TFP.intFlightPassengerID, TF.* 
              FROM TFlights as TF LEFT JOIN TFlightPassengers as TFP 
					On TF.intFlightID=TFP.intFlightID 
              Join TPassengers As TP 
                    On TFP.intPassengerID=TP.intPassengerID 
              WHERE dtmFlightDate <= GETDATE() 
                and TP.intPassengerID= @Passenger_id
  End;

  
--Execute   uspCustomerPastFlightsListBox 4


--5 In form Pilot Future flights (this procedure is for the label output)

CREATE PROCEDURE uspPilotFutureFlights(
		@Pilot_id AS INTEGER
		
)
As

BEGIN
			  SELECT Sum(intMilesFlown) as TotalMilesFlown  
              FROM TFlights as TF Join TPilotFlights As TPF 
                      On TF.intFlightID=TPF.intFlightID 
             Join TPilots As TP
                      On TPF.intPilotID=TP.intPilotID 
              WHERE dtmFlightDate >= GETDATE() 
                and TP.intPilotID= @Pilot_id 
  End;

--Execute  uspPilotFutureFlights 1


--6 In form Pilot Future flights (this procedure is for the list box output)

CREATE PROCEDURE uspPilotFutureFlightsListbox(
		@Pilot_id AS INTEGER
		
)
As

BEGIN
			  SELECT intPilotFlightID , TF.*
              FROM TFlights as TF LEFT JOIN TPilotFlights  as TPF 
                     On TF.intFlightID = TPF.intFlightID 
              Join TPilots As TP 
                     On TPF.intPilotID = TP.intPilotID 
             WHERE dtmFlightDate >= GETDATE() 
              and TP.intPilotID= @Pilot_id 
  End;

--Execute  uspPilotFutureFlightsListbox 1