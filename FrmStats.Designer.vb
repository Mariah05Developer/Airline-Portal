<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStats
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblAverage = New System.Windows.Forms.Label()
        Me.lblTotalflights = New System.Windows.Forms.Label()
        Me.lblTotalCustomers = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lstPilots = New System.Windows.Forms.ListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lstAttendants = New System.Windows.Forms.ListBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblAverage)
        Me.GroupBox1.Controls.Add(Me.lblTotalflights)
        Me.GroupBox1.Controls.Add(Me.lblTotalCustomers)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(67, 37)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(665, 288)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Customer Stat:"
        '
        'lblAverage
        '
        Me.lblAverage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAverage.Location = New System.Drawing.Point(329, 204)
        Me.lblAverage.Name = "lblAverage"
        Me.lblAverage.Size = New System.Drawing.Size(229, 47)
        Me.lblAverage.TabIndex = 8
        '
        'lblTotalflights
        '
        Me.lblTotalflights.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalflights.Location = New System.Drawing.Point(329, 130)
        Me.lblTotalflights.Name = "lblTotalflights"
        Me.lblTotalflights.Size = New System.Drawing.Size(229, 47)
        Me.lblTotalflights.TabIndex = 6
        '
        'lblTotalCustomers
        '
        Me.lblTotalCustomers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalCustomers.Location = New System.Drawing.Point(329, 55)
        Me.lblTotalCustomers.Name = "lblTotalCustomers"
        Me.lblTotalCustomers.Size = New System.Drawing.Size(229, 47)
        Me.lblTotalCustomers.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(42, 189)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(265, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Average miles flown for all customer:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(42, 130)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(255, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Total flights taken by all customers:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(207, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Total Number of Customers:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lstPilots)
        Me.GroupBox2.Location = New System.Drawing.Point(67, 362)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(328, 342)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Pilot Stats"
        '
        'lstPilots
        '
        Me.lstPilots.FormattingEnabled = True
        Me.lstPilots.ItemHeight = 20
        Me.lstPilots.Location = New System.Drawing.Point(20, 53)
        Me.lstPilots.Name = "lstPilots"
        Me.lstPilots.Size = New System.Drawing.Size(287, 264)
        Me.lstPilots.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lstAttendants)
        Me.GroupBox3.Location = New System.Drawing.Point(419, 362)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(332, 342)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Attendant Stats"
        '
        'lstAttendants
        '
        Me.lstAttendants.FormattingEnabled = True
        Me.lstAttendants.ItemHeight = 20
        Me.lstAttendants.Location = New System.Drawing.Point(16, 53)
        Me.lstAttendants.Name = "lstAttendants"
        Me.lstAttendants.Size = New System.Drawing.Size(297, 264)
        Me.lstAttendants.TabIndex = 0
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(308, 744)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(127, 77)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'FrmStats
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 873)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmStats"
        Me.Text = "FlyMe2theMoon Statistics"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblTotalCustomers As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblAverage As Label
    Friend WithEvents lblTotalflights As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lstPilots As ListBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lstAttendants As ListBox
    Friend WithEvents btnExit As Button
End Class
