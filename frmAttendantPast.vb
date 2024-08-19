Public Class frmAttendantPast
    Private Sub frmAttendantPast_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dtAttendants As DataTable = New DataTable

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

            ' Build the select statement to obtain state
            strSelect = "SELECT intAttendantID, strFirstName + ' ' + strLastName as AttendantName FROM TAttendants"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtAttendants.Load(drSourceTable)

            'load the state result set into the combobox.  For VB, we do this by binding the data to the combobox

            cboAttendants.ValueMember = "intAttendantID"
            cboAttendants.DisplayMember = "AttendantName"
            cboAttendants.DataSource = dtAttendants

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click



        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
            Dim dt As DataTable = New DataTable            ' this is the table we will load from our reader


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
                        " FROM TFlights as TF Join TAttendantFlights As TAF " &
                        " On TF.intFlightID=TAF.intFlightID " &
                        " Join TAttendants As TA " &
                        "  On TAF.intAttendantID=TA.intAttendantID " &
                         " WHERE dtmFlightDate <= GETDATE() " &
                        "  and TA.intAttendantID=  " & cboAttendants.SelectedValue


            'MessageBox.Show(strSelect)


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' Read result( highest ID )
            drSourceTable.Read()

            ' Null? (empty table)
            If drSourceTable.IsDBNull(0) = True Then

                ' Yes, start numbering at 1
                lblMilesFlowns.Text = 0

            Else

                ' No, get the next highest ID
                lblMilesFlowns.Text = CInt(drSourceTable("TotalMilesFlown"))

            End If


            strSelect = " SELECT intAttendantFlightID , TF.* " &
                        " FROM TFlights as TF LEFT JOIN TAttendantFlights  as TAF " &
                        " On TF.intFlightID = TAF.intFlightID " &
                        " Join TAttendants As TA " &
                        "  On TAF.intAttendantID = TA.intAttendantID " &
                        "  WHERE dtmFlightDate <= GETDATE() " &
                        " and TA.intAttendantID=  " & cboAttendants.SelectedValue

            'MessageBox.Show(strSelect)



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


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

    End Sub
End Class