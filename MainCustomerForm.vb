Public Class frmMainCustomerForm
    Private Sub btnUpdateCustomer_Click(sender As Object, e As EventArgs) Handles btnUpdateCustomer.Click

        Dim frmUpdateCustomer As New frmUpdateCustomer

        frmUpdateCustomer.ShowDialog()

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim frmAddFlight As New frmAddflight

        frmAddFlight.ShowDialog()


    End Sub

    Private Sub btnShowPast_Click(sender As Object, e As EventArgs) Handles btnShowPast.Click


        Dim frmPastFlight As New frmPastFlights

        frmPastFlight.ShowDialog()
    End Sub

    Private Sub btnShowFuture_Click(sender As Object, e As EventArgs) Handles btnShowFuture.Click


        Dim frmFutureFlight As New frmFutureFlights

        frmFutureFlight.ShowDialog()
    End Sub
End Class