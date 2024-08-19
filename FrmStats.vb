Public Class FrmStats
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

    End Sub

    Private Sub FrmStats_Load(sender As Object, e As EventArgs) Handles MyBase.Load






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
            strSelect = "SELECT Count(*) as TotalCustomers " &
                        "FROM TPassengers as TP"


            'MessageBox.Show(strSelect)


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' Read result( highest ID )
            drSourceTable.Read()

            ' Null? (empty table)
            If drSourceTable.IsDBNull(0) = True Then

                ' Yes, start numbering at 1
                lblTotalCustomers.Text = 0

            Else

                ' No, get the next highest ID
                lblTotalCustomers.Text = CInt(drSourceTable("TotalCustomers"))

            End If



            ' Build the select statement
            strSelect = "SELECT Count(*) as TotalFlights " &
                        "FROM TFlights as TF"


            'MessageBox.Show(strSelect)


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' Read result( highest ID )
            drSourceTable.Read()

            ' Null? (empty table)
            If drSourceTable.IsDBNull(0) = True Then

                ' Yes, start numbering at 1
                lblTotalflights.Text = 0

            Else

                ' No, get the next highest ID
                lblTotalflights.Text = CInt(drSourceTable("TotalFlights"))

            End If




            ' Build the select statement
            strSelect = "SELECT AVG(intMilesFLown) as AverageMiles " &
                        "FROM TFlights as TF"


            'MessageBox.Show(strSelect)


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' Read result( highest ID )
            drSourceTable.Read()

            ' Null? (empty table)
            If drSourceTable.IsDBNull(0) = True Then

                ' Yes, start numbering at 1
                lblAverage.Text = 0

            Else

                ' No, get the next highest ID
                lblAverage.Text = CInt(drSourceTable("AverageMiles"))

            End If


            strSelect = " SELECT Sum(TF.intMilesFlown) as TotalperPilot,TP.strFirstName, TP.strLastName " &
                        " FROM TFlights as TF JOIN TPilotFlights as TPF " &
                        " ON TF.intFlightID = TPF.intFlightID " &
                        " Right Join TPilots As TP " &
                        " ON TPF.intPilotID=TP.intPilotID " &
                        " Group By TP.strFirstName, TP.strLastName "


            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            'loop through result set and display in Listbox

            lstPilots.Items.Add("Total Miles Flown per Pilot")
            lstPilots.Items.Add("  ")
            lstPilots.Items.Add("=======================================")

            While drSourceTable.Read()

                lstPilots.Items.Add("  ")

                lstPilots.Items.Add("First Name: " & vbTab & drSourceTable("strFirstName"))
                lstPilots.Items.Add(" Last Name: " & vbTab & drSourceTable("strLastName"))
                lstPilots.Items.Add(" Miles Flown: " & vbTab & drSourceTable("TotalperPilot"))


                lstPilots.Items.Add("  ")
                lstPilots.Items.Add("=======================================")

            End While





            strSelect = " SELECT Sum(TF.intMilesFlown) as TotalperAttendant,TA.strFirstName, TA.strLastName " &
                        " FROM TFlights as TF LEFT JOIN TAttendantFlights as TAF " &
                        " ON TF.intFlightID = TAF.intFlightID " &
                        "  Right Join TAttendants As TA " &
                        " ON TAF.intAttendantID=TA.intAttendantID " &
                        " Group By  TA.strFirstName, TA.strLastName "


            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            'loop through result set and display in Listbox

            lstAttendants.Items.Add("Total Miles Flown per Attendant")
            lstAttendants.Items.Add("  ")
            lstAttendants.Items.Add("=======================================")

            While drSourceTable.Read()

                lstAttendants.Items.Add("  ")

                lstAttendants.Items.Add("First Name: " & vbTab & drSourceTable("strFirstName"))
                lstAttendants.Items.Add(" Last Name: " & vbTab & drSourceTable("strLastName"))
                lstAttendants.Items.Add(" Miles Flown: " & vbTab & drSourceTable("TotalperAttendant"))


                lstAttendants.Items.Add("  ")
                lstAttendants.Items.Add("=======================================")

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