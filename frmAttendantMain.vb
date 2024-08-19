Public Class frmAttendantMain
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

    End Sub

    Private Sub btnUpdateAttendant_Click(sender As Object, e As EventArgs) Handles btnUpdateAttendant.Click

        Dim frmUpdateAttendant As New frmUpdateAttendant

        frmUpdateAttendant.ShowDialog()


    End Sub

    Private Sub btnShowPast_Click(sender As Object, e As EventArgs) Handles btnShowPast.Click


        Dim frmAttendantPast As New frmAttendantPast

        frmAttendantPast.ShowDialog()

    End Sub

    Private Sub btnShowFuture_Click(sender As Object, e As EventArgs) Handles btnShowFuture.Click


        Dim frmAttendantFuture As New frmAttendantFuture


        frmAttendantFuture.ShowDialog()

    End Sub
End Class