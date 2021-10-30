<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnOpenConnetion = New System.Windows.Forms.Button()
        Me.txtInfo = New System.Windows.Forms.TextBox()
        Me.btnCloseConnection = New System.Windows.Forms.Button()
        Me.btnStartMotor = New System.Windows.Forms.Button()
        Me.btnStopMotor = New System.Windows.Forms.Button()
        Me.btnInitSystem = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnStartExMotor = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtComPort = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnOpenConnetion
        '
        Me.btnOpenConnetion.Location = New System.Drawing.Point(12, 334)
        Me.btnOpenConnetion.Name = "btnOpenConnetion"
        Me.btnOpenConnetion.Size = New System.Drawing.Size(168, 49)
        Me.btnOpenConnetion.TabIndex = 0
        Me.btnOpenConnetion.Text = "Open Connection"
        Me.btnOpenConnetion.UseVisualStyleBackColor = True
        '
        'txtInfo
        '
        Me.txtInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInfo.Location = New System.Drawing.Point(25, 69)
        Me.txtInfo.Multiline = True
        Me.txtInfo.Name = "txtInfo"
        Me.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfo.Size = New System.Drawing.Size(537, 242)
        Me.txtInfo.TabIndex = 1
        Me.txtInfo.UseWaitCursor = True
        '
        'btnCloseConnection
        '
        Me.btnCloseConnection.Enabled = False
        Me.btnCloseConnection.Location = New System.Drawing.Point(434, 334)
        Me.btnCloseConnection.Name = "btnCloseConnection"
        Me.btnCloseConnection.Size = New System.Drawing.Size(168, 49)
        Me.btnCloseConnection.TabIndex = 2
        Me.btnCloseConnection.Text = "CLose Connection"
        Me.btnCloseConnection.UseVisualStyleBackColor = True
        '
        'btnStartMotor
        '
        Me.btnStartMotor.Enabled = False
        Me.btnStartMotor.Location = New System.Drawing.Point(599, 152)
        Me.btnStartMotor.Name = "btnStartMotor"
        Me.btnStartMotor.Size = New System.Drawing.Size(137, 31)
        Me.btnStartMotor.TabIndex = 3
        Me.btnStartMotor.Text = "StartMotor"
        Me.btnStartMotor.UseVisualStyleBackColor = True
        '
        'btnStopMotor
        '
        Me.btnStopMotor.Enabled = False
        Me.btnStopMotor.Location = New System.Drawing.Point(599, 189)
        Me.btnStopMotor.Name = "btnStopMotor"
        Me.btnStopMotor.Size = New System.Drawing.Size(137, 27)
        Me.btnStopMotor.TabIndex = 4
        Me.btnStopMotor.Text = "StopMotor"
        Me.btnStopMotor.UseVisualStyleBackColor = True
        '
        'btnInitSystem
        '
        Me.btnInitSystem.Enabled = False
        Me.btnInitSystem.Location = New System.Drawing.Point(229, 334)
        Me.btnInitSystem.Name = "btnInitSystem"
        Me.btnInitSystem.Size = New System.Drawing.Size(168, 49)
        Me.btnInitSystem.TabIndex = 5
        Me.btnInitSystem.Text = "Init "
        Me.btnInitSystem.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Label2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(315, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Label3"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(315, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Label4"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Label5"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(315, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Label6"
        '
        'btnStartExMotor
        '
        Me.btnStartExMotor.Enabled = False
        Me.btnStartExMotor.Location = New System.Drawing.Point(599, 274)
        Me.btnStartExMotor.Name = "btnStartExMotor"
        Me.btnStartExMotor.Size = New System.Drawing.Size(137, 27)
        Me.btnStartExMotor.TabIndex = 12
        Me.btnStartExMotor.Text = "Start Ex Motor"
        Me.btnStartExMotor.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Label7"
        '
        'txtComPort
        '
        Me.txtComPort.Location = New System.Drawing.Point(599, 100)
        Me.txtComPort.Name = "txtComPort"
        Me.txtComPort.Size = New System.Drawing.Size(49, 20)
        Me.txtComPort.TabIndex = 14
        Me.txtComPort.Text = "COM9"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 405)
        Me.Controls.Add(Me.txtComPort)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnStartExMotor)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnInitSystem)
        Me.Controls.Add(Me.btnStopMotor)
        Me.Controls.Add(Me.btnStartMotor)
        Me.Controls.Add(Me.btnCloseConnection)
        Me.Controls.Add(Me.txtInfo)
        Me.Controls.Add(Me.btnOpenConnetion)
        Me.Name = "Form1"
        Me.Text = "Example for FtMscLibExNet with native events"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOpenConnetion As System.Windows.Forms.Button
    Friend WithEvents txtInfo As System.Windows.Forms.TextBox
    Friend WithEvents btnCloseConnection As System.Windows.Forms.Button
    Friend WithEvents btnStartMotor As System.Windows.Forms.Button
    Friend WithEvents btnStopMotor As System.Windows.Forms.Button
    Friend WithEvents btnInitSystem As System.Windows.Forms.Button
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnStartExMotor As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtComPort As System.Windows.Forms.TextBox

End Class
