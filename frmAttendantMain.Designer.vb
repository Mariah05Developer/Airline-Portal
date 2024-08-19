<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAttendantMain
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
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnShowFuture = New System.Windows.Forms.Button()
        Me.btnShowPast = New System.Windows.Forms.Button()
        Me.btnUpdateAttendant = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(102, 328)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(169, 62)
        Me.btnExit.TabIndex = 13
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnShowFuture
        '
        Me.btnShowFuture.Location = New System.Drawing.Point(102, 230)
        Me.btnShowFuture.Name = "btnShowFuture"
        Me.btnShowFuture.Size = New System.Drawing.Size(169, 62)
        Me.btnShowFuture.TabIndex = 12
        Me.btnShowFuture.Text = "Show Future Flights"
        Me.btnShowFuture.UseVisualStyleBackColor = True
        '
        'btnShowPast
        '
        Me.btnShowPast.Location = New System.Drawing.Point(102, 127)
        Me.btnShowPast.Name = "btnShowPast"
        Me.btnShowPast.Size = New System.Drawing.Size(169, 62)
        Me.btnShowPast.TabIndex = 11
        Me.btnShowPast.Text = "Show Past Flight"
        Me.btnShowPast.UseVisualStyleBackColor = True
        '
        'btnUpdateAttendant
        '
        Me.btnUpdateAttendant.Location = New System.Drawing.Point(102, 35)
        Me.btnUpdateAttendant.Name = "btnUpdateAttendant"
        Me.btnUpdateAttendant.Size = New System.Drawing.Size(169, 62)
        Me.btnUpdateAttendant.TabIndex = 10
        Me.btnUpdateAttendant.Text = "Update Attendant  Information"
        Me.btnUpdateAttendant.UseVisualStyleBackColor = True
        '
        'frmAttendantMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(364, 425)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnShowFuture)
        Me.Controls.Add(Me.btnShowPast)
        Me.Controls.Add(Me.btnUpdateAttendant)
        Me.Name = "frmAttendantMain"
        Me.Text = "Attendant Main Menu"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents btnShowFuture As Button
    Friend WithEvents btnShowPast As Button
    Friend WithEvents btnUpdateAttendant As Button
End Class
