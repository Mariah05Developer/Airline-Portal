Public Class frmCustomerSelection
    Private Sub btnReturning_Click(sender As Object, e As EventArgs) Handles btnReturning.Click

        Dim frmExistingCustomer As New frmExistingCustomer

        frmExistingCustomer.ShowDialog()


    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click

        Dim frmNewCustomer As New frmNewCustomer

        frmNewCustomer.ShowDialog()

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()

    End Sub
End Class