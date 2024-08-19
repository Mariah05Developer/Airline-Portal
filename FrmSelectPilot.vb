Public Class FrmSelectPilot
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

    End Sub

    Private Sub FrmSelectPilot_Load(sender As Object, e As EventArgs) Handles MyBase.Load




        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dtPilot As DataTable = New DataTable

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
            strSelect = "SELECT intPilotID, strFirstName + ' ' + strLastName as PilotName FROM TPilots"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtPilot.Load(drSourceTable)

            'load the state result set into the combobox.  For VB, we do this by binding the data to the combobox

            cboPilots.ValueMember = "intPilotID"
            cboPilots.DisplayMember = "PilotName"
            cboPilots.DataSource = dtPilot

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

        Dim frmPilotMain As New frmPilotMain

        frmPilotMain.ShowDialog()


    End Sub
End Class