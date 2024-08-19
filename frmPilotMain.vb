Public Class frmPilotMain
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

    End Sub

    Private Sub btnUpdatePilot_Click(sender As Object, e As EventArgs) Handles btnUpdatePilot.Click

        Dim frmPilotUpdate As New frmUpdatePilot

        frmPilotUpdate.ShowDialog()

    End Sub

    Private Sub btnShowPast_Click(sender As Object, e As EventArgs) Handles btnShowPast.Click


        Dim frmPilotPast As New frmPilotPast

        frmPilotPast.ShowDialog()
    End Sub

    Private Sub btnShowFuture_Click(sender As Object, e As EventArgs) Handles btnShowFuture.Click


        Dim frmPilotfuture As New frmPilotFuture

        frmPilotfuture.ShowDialog()

    End Sub
End Class