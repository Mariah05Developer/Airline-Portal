Public Class frmAddflight
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click


        Call Calculate_Seats(dblReserved, dblNotReserved)

        Call Display_Totals(dblReserved, dblNotReserved)

        Call FlightCalculations(dblReserved, dblNotReserved)

    End Sub

    Public Sub FlightCalculations(ByVal dblReserved As Double, ByVal dblNotReserved As Double)

        Dim strSelect As String
        Dim strInsert As String
        Dim intPassenger As Integer
        Dim intFlight As Integer

        Dim cmdSelect As OleDb.OleDbCommand ' select command object
        Dim cmdInsert As OleDb.OleDbCommand ' insert command object
        Dim drSourceTable As OleDb.OleDbDataReader ' data reader for pulling info
        Dim intNextPrimaryKey As Integer ' holds next highest PK value
        Dim intRowsAffected As Integer  ' how many rows were affected when sql executed

        Dim result As DialogResult

        Try


            ' validate data is entered


            ' put values into strings

            intPassenger = cboPassengers.SelectedValue
            intFlight = cboFutureFlights.SelectedValue


            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                        "The application will now close.",
                                        Me.Text + " Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            result = MessageBox.Show("Are you sure you want to Add Flight: " & cboPassengers.Text & "?", "Confirm Selection", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            ' this will figure out which button was selected. Cancel and No does nothing, Yes will allow deletion
            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes

                    strSelect = "SELECT MAX(intFlightPassengerID) + 1 AS intNextPrimaryKey " &
                                    " FROM TFlightPassengers"

                    ' Execute command
                    cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                    drSourceTable = cmdSelect.ExecuteReader

                    ' Read result( highest ID )
                    drSourceTable.Read()

                    ' Null? (empty table)
                    If drSourceTable.IsDBNull(0) = True Then

                        ' Yes, start numbering at 1
                        intNextPrimaryKey = 1

                    Else

                        ' No, get the next highest ID
                        intNextPrimaryKey = CInt(drSourceTable("intNextPrimaryKey"))

                    End If
                    ' build insert statement (columns must match DB columns in name and the # of columns)


                    If rbnReserved.Checked = True Then
                        strInsert = "INSERT INTO TFlightPassengers  (intFlightPassengerID, intFlightID, intPassengerID,intFlightCost)" &
                        " VALUES (" & intNextPrimaryKey & "," & intPassenger & "," & intFlight & "," & dblReserved & ")"
                    ElseIf rbnNotReserved.Checked = True Then
                        strInsert = "INSERT INTO TFlightPassengers  (intFlightPassengerID, intFlightID, intPassengerID,intFlightCost)" &
                        " VALUES (" & intNextPrimaryKey & "," & intPassenger & "," & intFlight & "," & dblNotReserved & ")"
                    End If

                    MessageBox.Show(strInsert)

                    ' use insert command with sql string and connection object
                    cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

                    ' execute query to insert data
                    intRowsAffected = cmdInsert.ExecuteNonQuery()

                    ' If not 0 insert successful
                    If intRowsAffected > 0 Then
                        MessageBox.Show(cboPassengers.Text & " has been added to flight " & cboFutureFlights.Text)    ' let user know success
                        ' close new player form
                    End If


            End Select



            CloseDatabaseConnection()       ' close connection if insert didn't work
            Close()



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub




    Private Sub frmAddflight_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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


            ' Build the select statement
            strSelect = "SELECT intFlightID, strFlightNumber  FROM TFlights" &
                        " Where dtmFlightDate > GETDATE() "
            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                drSourceTable = cmdSelect.ExecuteReader

                ' load table from data reader
                dtFlights.Load(drSourceTable)

                ' Add the item to the combo box. We need the player ID associated with the name so 
                ' when we click on the name we can then use the ID to pull the rest of the players data.
                ' We are binding the column name to the combo box display and value members. 
                cboFutureFlights.ValueMember = "intFlightID"
            cboFutureFlights.DisplayMember = "strFlightNumber"
            cboFutureFlights.DataSource = dtFlights


                ' Clean up
                drSourceTable.Close()

                ' close the database connection
                CloseDatabaseConnection()

                      Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)


        End Try

    End Sub


    Dim dblReserved As Double
    Dim dblNotReserved As Double



    Private Sub Calculate_Seats(ByRef dblReserved As Double, ByRef dblNotReserved As Double)

        If rbnReserved.Checked = True Then
            dblReserved = Calculate_Reserved(dblReserved)
        Else
            dblNotReserved = 300
        End If


    End Sub

    Public Function Calculate_Reserved(dblReserved) As Double

        Dim Flight As Double
        Dim strSelect As String
        Dim strSelect2 As String
        Dim strSelect3 As String
        Dim strSelect4 As String


        Dim datevalue1 As Date
        Dim datevalue2 As Date
        Dim datet As TimeSpan
        Dim diff As Double

        '250 base price then 150 for reserved seat
        If rbnReserved.Checked = True Then
            dblReserved = 250 + 150
        End If


        If strSelect = "Select intMilesFlown" &
                       "From TFLights" &
                       " Where intFlightID = " & cboFutureFlights.SelectedValue Then
            If strSelect > 750 Then
                dblReserved += 50
            End If
        End If

        If strSelect2 = "Select strPlaneType" &
                             "From TPlaneTypes As TPT Join TPlanes As TP" &
                             "On TPT.intPlaneTypeID = TP.intPlaneTypeID" &
                             "Join TFLights As TF" &
                              "On TF.intPlaneID= TP.intPlaneID" &
                              "Where intFlightID = " & cboFutureFlights.SelectedValue Then
            If strSelect2 = "Airbus A350" Then
                dblReserved += 50
            Else
                If strSelect2 = "Boeing 747-8" Then
                    dblReserved += -25
                End If

            End If
        End If

        If strSelect3 = " Select intAirportID" &
                        "From TAirports As TA Join TFlights As TF" &
                        "On TA.intAirportID=TF.intToAirportID" &
                         "Where intFlightID =" & cboFutureFlights.SelectedValue Then
            If strSelect3 = "2" Then
                dblReserved += 15
            Else
                dblReserved += dblReserved
            End If

        End If


        If strSelect4 = "Select & " & cboPassengers.SelectedValue & " DateOfBirth, DATEDIFF(YY,DateOfBirth,GETDATE()) FROM TPassengers" Then
            If strSelect4 > 65 Then
                dblReserved += (dblReserved * 0.2) - dblReserved
            Else
                If strSelect4 <= 5 Then
                    dblReserved += (dblReserved * 0.65) - dblReserved

                End If
            End If
        End If


        Return dblReserved

    End Function



    Public Function Calculate_NotReserved(dblNotReserved) As Double

        Dim Flight As Double
        Dim strSelect As String
        Dim strSelect2 As String
        Dim strSelect3 As String
        Dim strSelect4 As String


        Dim datevalue1 As Date
        Dim datevalue2 As Date
        Dim datet As TimeSpan
        Dim diff As Double

        '250 base price 
        If rbnReserved.Checked = True Then
            dblNotReserved = 250
        End If


        If strSelect = "Select intMilesFlown" &
                       "From TFLights" &
                       " Where intFlightID = " & cboFutureFlights.SelectedValue Then
            If strSelect > 750 Then
                dblNotReserved += 50
            End If
        End If


        If strSelect2 = "Select strPlaneType" &
                             "From TPlaneTypes As TPT Join TPlanes As TP" &
                             "On TPT.intPlaneTypeID = TP.intPlaneTypeID" &
                             "Join  TFLights As TF" &
                              "On  TF.intPlaneID= TP.intPlaneID" &
                              "Where intFlightID = " & cboFutureFlights.SelectedValue Then
            If strSelect2 = "Airbus A350" Then
                dblNotReserved += 50
            Else
                If strSelect2 = "Boeing 747-8" Then
                    dblNotReserved += -25
                End If

            End If
        End If

        If strSelect3 = " Select intAirportID" &
                        "From TAirports As TA Join TFlights As TF" &
                        "On TA.intAirportID=TF.intToAirportID" &
                         "Where intFlightID =" & cboFutureFlights.SelectedValue.ToString Then
            If strSelect3 = "2" Then
                dblNotReserved += 15
            Else
                dblNotReserved += dblNotReserved
            End If

        End If


        If strSelect4 = "Select & " & cboPassengers.SelectedValue.ToString() & " DateOfBirth, DATEDIFF(YY,DateOfBirth,GETDATE()) FROM TPassengers" Then
            If strSelect4 > 65 Then
                dblNotReserved += (dblNotReserved * 0.2) - dblNotReserved
            Else
                If strSelect4 <= 5 Then
                    dblNotReserved += (dblNotReserved * 0.65) - dblNotReserved

                End If
            End If
        End If


        Return dblNotReserved
    End Function


    Private Sub Display_Totals(ByVal dblReserved As Double, ByVal dblNotReserved As Double)

        lblReserved.Text = FormatCurrency(dblReserved)

        lblNotReserved.Text = FormatCurrency(dblNotReserved)

    End Sub
End Class