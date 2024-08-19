Public Class frmPastFlights
    Private Sub frmPastFlights_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dtFlights As DataTable = New DataTable ' this is the table we will load from our reader
        Dim dtPassengers As DataTable = New DataTable ' this is the table we will load from our reader


        Try

            ' open the DB this is in module
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            '
            ' Build the select statement to obtain state
            strSelect = "SELECT intPassengerID, strFirstName + ' ' + strLastName as PassengerName FROM TPassengers"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtPassengers.Load(drSourceTable)

            'load the state result set into the combobox.  For VB, we do this by binding the data to the combobox

            cboPassengers.ValueMember = "intPassengerID"
            cboPassengers.DisplayMember = "PassengerName"
            cboPassengers.DataSource = dtPassengers



            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)


        End Try


    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click





        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
            Dim dt As DataTable = New DataTable            ' this is the table we will load from our reader
            'Dim objParam As OleDb.OleDbParameter           ' this will be used to add parameters needed for stored procedures


            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If



            ' Build the select statement
            strSelect = " SELECT Sum(intMilesFlown) as TotalMilesFlown  " &
                        " FROM TFlights as TF Join TFlightPassengers As TFP " &
                        " On TF.intFlightID=TFP.intFlightID " &
                        " Join TPassengers As TP " &
                        "  On TFP.intPassengerID=TP.intPassengerID " &
                         " WHERE dtmFlightDate <= GETDATE() " &
                        "  and TP.intPassengerID=  " & cboPassengers.SelectedValue


            MessageBox.Show(strSelect)


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' Read result( highest ID )
            drSourceTable.Read()

            'cmdSelect = New OleDb.OleDbCommand("uspCustomerPastFlights", m_conAdministrator)
            'cmdSelect.CommandType = CommandType.StoredProcedure

            'objParam = cmdSelect.Parameters.Add("@Passenger_id ", OleDb.OleDbType.Integer)
            'objParam.Direction = ParameterDirection.Input
            'objParam.Value = cboPassengers.Text

            'drSourceTable = cmdSelect.ExecuteReader



            ' Null? (empty table)
            If drSourceTable.IsDBNull(0) = True Then

                ' Yes, start numbering at 1
                lblMilesFlowns.Text = 0

            Else

                ' No, get the next highest ID
                lblMilesFlowns.Text = CInt(drSourceTable("TotalMilesFlown"))

            End If


            'cmdSelect = New OleDb.OleDbCommand("uspCustomerPastFlightsListbox", m_conAdministrator)
            'cmdSelect.CommandType = CommandType.StoredProcedure

            'objParam = cmdSelect.Parameters.Add("@Passenger_id ", OleDb.OleDbType.Integer)
            'objParam.Direction = ParameterDirection.Input
            'objParam.Value = cboPassengers.Text

            'drSourceTable = cmdSelect.ExecuteReader


            strSelect = " SELECT intFlightPassengerID , TF.* " &
                        " FROM TFlights as TF LEFT JOIN TFlightPassengers  as TFP " &
                        " On TF.intFlightID = TFP.intFlightID " &
                        " Join TPassengers As TP " &
                        "  On TFP.intPassengerID = TP.intPassengerID " &
                        "  WHERE dtmFlightDate <= GETDATE() " &
                        " and TP.intPassengerID=  " & cboPassengers.SelectedValue

            MessageBox.Show(strSelect)


            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader


            'loop through result set and display in Listbox

            lstFlights.Items.Add("Total Flights")
            lstFlights.Items.Add("  ")
            lstFlights.Items.Add("=======================================")

            While drSourceTable.Read()

                lstFlights.Items.Add("  ")

                lstFlights.Items.Add("FlightID: " & vbTab & drSourceTable("intFlightID"))
                lstFlights.Items.Add("FlightDate: " & vbTab & drSourceTable("dtmFlightDate"))
                lstFlights.Items.Add(" Flight Number : " & vbTab & drSourceTable("strFlightNumber"))
                lstFlights.Items.Add("Departure Time: " & vbTab & drSourceTable("dtmTimeofDeparture"))
                lstFlights.Items.Add("Landing Time: " & vbTab & drSourceTable("dtmTimeOfLanding"))
                lstFlights.Items.Add(" From Airport : " & vbTab & drSourceTable("intFromAirportID"))
                lstFlights.Items.Add("To Airport: " & vbTab & drSourceTable("intToAirportID"))
                lstFlights.Items.Add("Miles Flown: " & vbTab & drSourceTable("intMilesFlown"))
                lstFlights.Items.Add(" Plane ID : " & vbTab & drSourceTable("intPlaneID"))


                lstFlights.Items.Add("  ")
                lstFlights.Items.Add("=======================================")

            End While


            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try
    End Sub

End Class