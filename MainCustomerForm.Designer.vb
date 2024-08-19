<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainCustomerForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnUpdateCustomer = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnShowPast = New System.Windows.Forms.Button()
        Me.btnShowFuture = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnUpdateCustomer
        '
        Me.btnUpdateCustomer.Location = New System.Drawing.Point(120, 62)
        Me.btnUpdateCustomer.Name = "btnUpdateCustomer"
        Me.btnUpdateCustomer.Size = New System.Drawing.Size(169, 62)
        Me.btnUpdateCustomer.TabIndex = 0
        Me.btnUpdateCustomer.Text = "Update Customer Information"
        Me.btnUpdateCustomer.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(120, 146)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(169, 62)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add Flight"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnShowPast
        '
        Me.btnShowPast.Location = New System.Drawing.Point(120, 239)
        Me.btnShowPast.Name = "btnShowPast"
        Me.btnShowPast.Size = New System.Drawing.Size(169, 62)
        Me.btnShowPast.TabIndex = 2
        Me.btnShowPast.Text = "Show Past Flight"
        Me.btnShowPast.UseVisualStyleBackColor = True
        '
        'btnShowFuture
        '
        Me.btnShowFuture.Location = New System.Drawing.Point(120, 336)
        Me.btnShowFuture.Name = "btnShowFuture"
        Me.btnShowFuture.Size = New System.Drawing.Size(169, 62)
        Me.btnShowFuture.TabIndex = 3
        Me.btnShowFuture.Text = "Show Future Flights"
        Me.btnShowFuture.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(120, 418)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(169, 62)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmMainCustomerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 512)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnShowFuture)
        Me.Controls.Add(Me.btnShowPast)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnUpdateCustomer)
        Me.Name = "frmMainCustomerForm"
        Me.Text = "Main Customer Form"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnUpdateCustomer As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnShowPast As Button
    Friend WithEvents btnShowFuture As Button
    Friend WithEvents btnExit As Button
End Class
