<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPilotMain
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
        Me.btnUpdatePilot = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(105, 334)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(169, 62)
        Me.btnExit.TabIndex = 9
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnShowFuture
        '
        Me.btnShowFuture.Location = New System.Drawing.Point(105, 236)
        Me.btnShowFuture.Name = "btnShowFuture"
        Me.btnShowFuture.Size = New System.Drawing.Size(169, 62)
        Me.btnShowFuture.TabIndex = 8
        Me.btnShowFuture.Text = "Show Future Flights"
        Me.btnShowFuture.UseVisualStyleBackColor = True
        '
        'btnShowPast
        '
        Me.btnShowPast.Location = New System.Drawing.Point(105, 133)
        Me.btnShowPast.Name = "btnShowPast"
        Me.btnShowPast.Size = New System.Drawing.Size(169, 62)
        Me.btnShowPast.TabIndex = 7
        Me.btnShowPast.Text = "Show Past Flight"
        Me.btnShowPast.UseVisualStyleBackColor = True
        '
        'btnUpdatePilot
        '
        Me.btnUpdatePilot.Location = New System.Drawing.Point(105, 41)
        Me.btnUpdatePilot.Name = "btnUpdatePilot"
        Me.btnUpdatePilot.Size = New System.Drawing.Size(169, 62)
        Me.btnUpdatePilot.TabIndex = 5
        Me.btnUpdatePilot.Text = "Update Pilot  Information"
        Me.btnUpdatePilot.UseVisualStyleBackColor = True
        '
        'frmPilotMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(379, 467)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnShowFuture)
        Me.Controls.Add(Me.btnShowPast)
        Me.Controls.Add(Me.btnUpdatePilot)
        Me.Name = "frmPilotMain"
        Me.Text = "Pilot Main Menu"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents btnShowFuture As Button
    Friend WithEvents btnShowPast As Button
    Friend WithEvents btnUpdatePilot As Button
End Class
