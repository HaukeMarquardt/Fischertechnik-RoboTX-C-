Imports System
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Diagnostics
Imports System.Windows.Forms
Imports System.Threading
Imports FischerTechnik.FtMscLib.API
Imports FischerTechnik.FtMscLib.Enumurations
Imports FischerTechnik.FtMscLib.Events
Imports FischerTechnik.FtMscLib.Exception
'http://www.developerfusion.com/article/5251/delegates-in-vbnet/3/
' http://www.codeproject.com/Articles/23517/How-to-Properly-Handle-Cross-thread-Events-and-Upd
'http://www.developerfusion.com/article/5184/multithreading-in-vbnet/3/
'http://stackoverflow.com/questions/22356/cleanest-way-to-invoke-cross-thread-events
''' <summary>
''' Example of: How to use the FtMscLibExNet library
''' </summary>
''' <remarks></remarks>
Partial Public Class Form1

    Private Sub btnStartConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenConnetion.Click
        StartConnection(txtComPort.Text)
    End Sub

    Private Sub btnStopConnection_Click(sender As System.Object, e As System.EventArgs) Handles btnCloseConnection.Click
        StopConnection(Me.txtInfo)
    End Sub

    Private Sub btnStartMotor_Click(sender As System.Object, e As System.EventArgs) Handles btnStartMotor.Click
        StartMotor(txtInfo)
    End Sub

    Private Sub btnStopMotor_Click(sender As System.Object, e As System.EventArgs) Handles btnStopMotor.Click
        StopMotor(txtInfo)
    End Sub

    Private Sub btnInitSystem_Click(sender As System.Object, e As System.EventArgs) Handles btnInitSystem.Click
        InitSystem(txtInfo)
    End Sub

    Private Sub btnStartExMotor_Click(sender As System.Object, e As System.EventArgs) Handles btnStartExMotor.Click
        StartEncoderMotor()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


    ''' <summary>
    ''' Define the TX-Controller.<br/>
    ''' We are going to use the Events.
    ''' </summary>
    ''' <remarks></remarks>
    Dim WithEvents myController As FtMscLibEx
    ''' <summary>
    ''' Attached the FtMscLib and connect to the TX-Controller
    ''' </summary>
    ''' <param name="strComPort">The com port as string</param>
    ''' <remarks></remarks>
    Sub StartConnection(ByVal strComPort As String)
        Dim Len As UInteger
        Dim buff As StringBuilder = New StringBuilder(45) : Dim buff2 As StringBuilder = New StringBuilder(45)
        Me.txtInfo.AppendText(If(File.Exists(FtMscLibEx.dllPath), "File exists." + vbCrLf, "File does not exist." + vbCrLf))
        Me.txtInfo.AppendText(FtMscLibEx.dllPath + vbCrLf)
        Try
            myController = New FtMscLibEx()
        Catch ex As Exception
            txtInfo.AppendText("Exception 1 " + vbCrLf)
            txtInfo.AppendText(ex.Source + vbCrLf)
            txtInfo.AppendText(ex.Message + vbCrLf)
            txtInfo.AppendText(ex.StackTrace + vbCrLf)
            Throw New Exception(ex.Message)
        End Try
        btnInitSystem.Enabled = True : btnStartExMotor.Enabled = True : btnStartMotor.Enabled = True : btnStopMotor.Enabled = True : btnCloseConnection.Enabled = True
        btnOpenConnetion.Enabled = False
        ' Lib is connected, get info
        Len = myController.ftxGetLibVersionStr(buff, 40UI)
        Me.Label7.Text = (" FtMscLibExb Version " + buff.ToString())
        Dim LibVersion As UInteger = myController.ftxGetLibVersion()
        Me.Label7.Text += (" Version 0X" + LibVersion.ToString("X"))
        If (LibVersion < &H1050DUI) Then
            Throw New Exception("Wrong version of FtMscLibEx.dll")
        End If
        Len = myController.ftxGetLongNameStrg(buff, 40UI)
        Me.Label1.Text = (" GetLongName " + buff.ToString())
        Len = myController.ftxGetFirmwareStrg(buff, 40UI)
        Me.Label2.Text = (" GetFirmware " + buff.ToString())
        ' Lib is connected, get overview availble ports
        myController.GetDeviceInfo(Me.txtInfo)
        'Try to connect to the TX-C
        Try
            myController.OpenConnection(strComPort)
        Catch ex As Exception
            txtInfo.AppendText("Exception OpenConnection " + vbCrLf)
            txtInfo.AppendText(ex.Source + vbCrLf)
            txtInfo.AppendText(ex.Message + vbCrLf)
            txtInfo.AppendText(ex.StackTrace + vbCrLf)
            Throw New Exception(ex.Message)
        End Try
        'Get info from the master TX-C
        Len = myController.GetRoboTxDevName(FtDeviceID.Master, buff, 40UI)
        Me.Label3.Text = (" GetRoboTxDevName " + buff.ToString())
        Len = myController.GetRoboTxFwStr(FtDeviceID.Master, buff, 40UI)
        Me.Label4.Text = (" GetRoboTxFwStr " + buff.ToString())
        Len = myController.GetRoboTxHwStr(FtDeviceID.Master, buff, 40UI)
        Me.Label5.Text = (" GetRoboTxHwStr " + buff.ToString())
        Len = myController.GetRoboTxSerialStr(FtDeviceID.Master, buff, 40UI)
        Me.Label6.Text = (" GetRoboTxSerialStr " + buff.ToString())
        ' Start the Transfer area
        Try
            myController.StartTransferArea()
        Catch ex As Exception
            txtInfo.AppendText("Exception StartTransferArea" + vbCrLf)
            txtInfo.AppendText(ex.Source + vbCrLf)
            txtInfo.AppendText(ex.Message + vbCrLf)
            txtInfo.AppendText(ex.StackTrace + vbCrLf)
            Throw New Exception(ex.Message)
        End Try



    End Sub
    ''' <summary>
    ''' Stop the Transfer Area<br/>
    ''' Close the connection with the TX-C
    ''' </summary>
    ''' <param name="txtInfox"></param>
    ''' <remarks></remarks>
    Sub StopConnection(txtInfox As TextBox)
        Try
            myController.StopTransferArea()
 
        Catch ex As Exception
            Me.txtInfo.AppendText("Exception StopTransferArea " + ex.Message + vbCrLf)
        End Try
        Try
            myController.CloseConnection()

        Catch ex As Exception
            Me.txtInfo.AppendText("Exception CloseConnection " + ex.Message + vbCrLf)
        End Try
        btnInitSystem.Enabled = False : btnStartExMotor.Enabled = False : btnStartMotor.Enabled = False : btnStopMotor.Enabled = False : btnCloseConnection.Enabled = False
        btnOpenConnetion.Enabled = True

    End Sub
    ''' <summary>
    ''' Example system,
    ''' M1 = Encoder motor
    ''' O3 =  actuator (pinball machine, Compressor)
    ''' O4, O5 = actuators (pinball machine, flippers)
    ''' O6, O7 = actuators (pinball machine, leds)
    ''' I1, I2 = Switches  (pinball machine, flippers activators)
    ''' </summary>
    ''' <param name="txtInfox"></param>
    ''' <remarks></remarks>
    Sub InitSystem(txtInfox As TextBox)

        Dim errCode, Len As UInteger
        Dim buff As StringBuilder = New StringBuilder(45), buff2 As StringBuilder = New StringBuilder(45)

        '===================================================================================
        'Initalize the I1 and I2 as digital inputs passive
        errCode = myController.SetFtUniConfig(devId:=FtDeviceID.Master, ioId:=FtInput.I1, _
                                              mode:=FtInputMode.Resistance, digital:=True)
        Len = FtMscLibEx.ftxGetLibErrorString(errCode, 1, buff, 40)
        Me.txtInfo.AppendText(" Set Uni 1 to dig resistence " + buff.ToString() + vbCrLf)
        errCode = myController.SetFtUniConfig(devId:=FtDeviceID.Master, ioId:=FtInput.I2, _
                                              mode:=FtInputMode.Resistance, digital:=True)
        Len = FtMscLibEx.ftxGetLibErrorString(errCode, 1, buff, 40)
        Me.txtInfo.AppendText(" Set Uni 2 to dig resistence " + buff.ToString() + vbCrLf)
        '===================================================================================
        'Events mask: Activate the I1 and I2 event
        'errCode = myController.SetCBMaskUniChanged(devId:=FtDeviceID.Master, mask:=&H3UI)
        errCode = myController.EnableCBMaskUniChanged(devId:=FtDeviceID.Master, inputIndex:=FtInput.I1, enable:=True)
        Len = FtMscLibEx.ftxGetLibErrorString(errCode, 1, buff, 40)
        Me.txtInfo.AppendText(" EnableCBMaskUniChanged I1 " + buff.ToString() + vbCrLf)
        errCode = myController.EnableCBMaskUniChanged(devId:=FtDeviceID.Master, inputIndex:=FtInput.I2, enable:=True)
        Len = FtMscLibEx.ftxGetLibErrorString(errCode, 1, buff, 40)
        Me.txtInfo.AppendText(" EnableCBMaskUniChanged I2" + buff.ToString() + vbCrLf)
        '===================================================================================
        'Events mask: Activate the C1 Cnt change event
        ' errCode = myController.SetCBMaskCntInChanged(devId:=FtDeviceID.Master, mask:=&H1UI)
        errCode = myController.EnableCBMaskCntInChanged(devId:=FtDeviceID.Master, counterIndex:=FtFastCounterInput.C1, enable:=True)
        Len = FtMscLibEx.ftxGetLibErrorString(errCode, 1, buff, 40)
        Me.txtInfo.AppendText(" EnableCBMaskCntInChanged C1 " + buff.ToString() + vbCrLf)
        '===================================================================================
        'Events mask: Activate the C1 and C2 Counter change event
        'errCode = myController.SetCBMaskCounterChanged(devId:=FtDeviceID.Master, mask:=&H1UI)
        errCode = myController.EnableCBMaskCounterChanged(devId:=FtDeviceID.Master, counterIndex:=FtFastCounterInput.C1, enable:=True)
        Len = FtMscLibEx.ftxGetLibErrorString(errCode, 1, buff, 40)
        Me.txtInfo.AppendText(" EnableCBMaskCntInChanged C1 " + buff.ToString() + vbCrLf)
        '===================================================================================
        'For testing (remove comment quotes):
        'Dim UniMask As UInteger
        'errCode = myController.GetCBMaskUniChanged(devId:=FtDeviceID.Master, mask:=UniMask)
        'Len = FtMscLibEx.ftxGetLibErrorString(errCode, 1, buff, 40)
        'Me.txtInfo.AppendText(" GetCBMask UniChanged mask=" + UniMask.ToString() + "  " + buff.ToString() + vbCrLf)
        'errCode = myController.GetCBMaskCntInChanged(devId:=FtDeviceID.Master, mask:=UniMask)
        'Len = FtMscLibEx.ftxGetLibErrorString(errCode, 1, buff, 40)
        'Me.txtInfo.AppendText(" GetCBMask CntIn mask=" + UniMask.ToString() + "  " + buff.ToString() + vbCrLf)
        ''errCode = myController.GetCBMaskCounterChanged(devId:=FtDeviceID.Master, mask:=UniMask)
        'Len = FtMscLibEx.ftxGetLibErrorString(errCode, 1, buff, 40)
        'Me.txtInfo.AppendText(" GetCBMask CntIn mask=" + UniMask.ToString() + "  " + buff.ToString() + vbCrLf)
        '===================================================================================
        ' Add a handler for Input Changed
        ' Example of adding and removing an event handler in a methode
        ' The alternative is doing this directly at the event handler definition
        AddHandler myController.OnInputChanged, AddressOf Me.MyInput2_Changed
        'Removing an event handler, example: (remove comment quote)
        'RemoveHandler myController.OnInputChanged, AddressOf Me.MyInput2_Changed
        'RemoveHandler myController.OnInputChanged, AddressOf Me.MyInput1_Changed
        '===================================================================================

        'Initialize the M1 as Motor output and O3..O8 as single outputs
        errCode = myController.SetFtMotorConfig(devId:=FtDeviceID.Master, motorId:=FtMotor.M1, status:=True)
        Len = FtMscLibEx.ftxGetLibErrorString(errCode, 0, buff, 40)
        Me.txtInfo.AppendText(" Set M1  " + buff.ToString() + vbCrLf)
        'initialize the M2 as O3, O4 independent outputs
        errCode = myController.SetFtMotorConfig(devId:=FtDeviceID.Master, motorId:=FtMotor.M2, status:=False)
        Len = FtMscLibEx.ftxGetLibErrorString(errCode, 1, buff, 40)
        Me.txtInfo.AppendText(" Set M2 to [O3, O4] " + buff.ToString() + vbCrLf)
        errCode = myController.SetFtMotorConfig(devId:=FtDeviceID.Master, motorId:=FtMotor.M3, status:=False)
        Len = FtMscLibEx.ftxGetLibErrorString(errCode, 1, buff, 40)
        Me.txtInfo.AppendText(" Set M3 to [O5, O6] " + buff.ToString() + vbCrLf)
        errCode = myController.SetFtMotorConfig(devId:=FtDeviceID.Master, motorId:=FtMotor.M4, status:=False)
        Len = FtMscLibEx.ftxGetLibErrorString(errCode, 1, buff, 40)
        Me.txtInfo.AppendText(" Set M4 to [O7, O8] " + buff.ToString() + vbCrLf)

    End Sub

    ''' <summary>
    ''' Starts encoder motor M1 as normal motor<br/>
    ''' Starts actuator on O3
    ''' </summary>
    ''' <param name="txtInfox"></param>
    ''' <remarks></remarks>
    Sub StartMotor(txtInfox As TextBox)

        Dim errCode As UInteger
        Dim Len As UInteger
        Dim buff As StringBuilder = New StringBuilder(45)
        Dim buff2 As StringBuilder = New StringBuilder(45)
        'Stop encoder motor M1
        errCode = myController.StopMotorExCmd(devId:=FtDeviceID.Master, mtrId:=FtMotor.M1)
        Len = FtMscLibEx.ftxGetLibErrorString(errCode, 1, buff, 40)
        Me.txtInfo.AppendText(" Stop M1 Ex " + buff.ToString() + vbCrLf)
        'Start encoder motor M1 as normal motor
        errCode = myController.SetOutMotorValues(devId:=FtDeviceID.Master, motorId:=FtMotor.M1, duty_p:=500, duty_m:=0, brake:=False)
        Len = FtMscLibEx.ftxGetLibErrorString(errCode, 1, buff, 40)
        Me.txtInfo.AppendText(" Set M1 to Run " + buff.ToString() + vbCrLf)
        'Start actuator on O3
        'set O3  on
        errCode = myController.SetOutPwmValues(devId:=FtDeviceID.Master, outId:=FtOutput.O3, duty:=500)
        'errCode = myController.SetOutPwmValues(devId:=0, outId:=3, duty:=500)
        Len = FtMscLibEx.ftxGetLibErrorString(errCode, 1, buff, 40)
        Me.txtInfo.AppendText(" Set O3 (actuator) to On " + buff.ToString() + vbCrLf)

    End Sub
    ''' <summary>
    ''' Stops encoder motor M1 as normal motor<br/>
    ''' Stops actuator on O3
    ''' </summary>
    ''' <param name="txtInfo"></param>
    ''' <remarks></remarks>
    Sub StopMotor(txtInfo As TextBox)
        Dim errCode, Len As UInteger
        Dim buff As StringBuilder = New StringBuilder(45), buff2 As StringBuilder = New StringBuilder(45)
        ' M1
        errCode = myController.SetOutMotorValues(devId:=FtDeviceID.Master, motorId:=FtMotor.M1, duty_p:=0, duty_m:=0, brake:=False)
        Len = FtMscLibEx.ftxGetLibErrorString(errCode:=errCode, typ:=1, buff:=buff, maxLen:=40)
        Me.txtInfo.AppendText(" Set M1 to 0 " + buff.ToString() + vbCrLf)
        'set O3  off
        errCode = myController.SetOutPwmValues(devId:=FtDeviceID.Master, outId:=FtOutput.O3, duty:=0)
        Len = FtMscLibEx.ftxGetLibErrorString(errCode, 1, buff, 40)
        Me.txtInfo.AppendText(" Set M2 O3 and O4 to 0 " + buff.ToString() + vbCrLf)

        '=================================================================
        'Reads the values of I1,I2,C1 and the Display buttons. Example of poling.
        Dim value0, value1 As Int16
        Dim overrun0, overrun1 As UInt32
        errCode = myController.GetInIOValue(devId:=FtDeviceID.Master, ioId:=FtInput.I1, value:=value0, overrun:=overrun0)
        Len = FtMscLibEx.ftxGetLibErrorString(errCode, 1, buff, 40)
        errCode = myController.GetInIOValue(devId:=FtDeviceID.Master, ioId:=FtInput.I2, value:=value1, overrun:=overrun1)
        Len = FtMscLibEx.ftxGetLibErrorString(errCode, 1, buff, 40)
        Me.txtInfo.AppendText(" s1 " + value0.ToString() + "o= " + overrun0.ToString() _
                              + " s2 " + value1.ToString() + "o= " + overrun1.ToString() _
                              + " error=" + buff.ToString() + vbCrLf)
        'Get buttons info
        Dim iLeft, iRight As Int16
        errCode = myController.GetInDisplayButtonValue(devId:=FtDeviceID.Master, right:=iRight, left:=iLeft)
        Len = FtMscLibEx.ftxGetLibErrorString(errCode, 1, buff, 40)
        Me.txtInfo.AppendText(" but left=" + iLeft.ToString() + " but right=" + iRight.ToString() + " error=" + buff.ToString() + vbCrLf)
        'Get Counter C1 info
        Dim count, state As Int16
        errCode = myController.GetInCounterValue(devId:=FtDeviceID.Master, cntId:=FtFastCounterInput.C1, count:=count, state:=state)
        Len = FtMscLibEx.ftxGetLibErrorString(errCode, 1, buff, 40)
        Me.txtInfo.AppendText(" count=" + count.ToString() + " state=" + state.ToString() + " error=" + buff.ToString() + vbCrLf)

    End Sub
    ''' <summary>
    ''' Starts the encoder motor in the extended mode (for 100 counts)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StartEncoderMotor()
        Dim errCode, Len As UInteger
        Dim buff As StringBuilder = New StringBuilder(45)
        'Both fuction are usable for 1 encoder motor.
        'errCode = myController.StartMotorExCmd(devId:=FtDeviceID.Master, mIdx:=FtMotor.M1, duty:=512, mdirection:=FtMotorDirection.CCW, _
        '                                       sIdx:=FtMotor.NotUsed, sDirection:=FtMotorDirection.CCW, pulseCnt:=100)

        errCode = myController.StartMotorExCmd4(devId:=FtDeviceID.Master, _
                                                mIdx:=FtMotor.M1, duty:=512, mdirection:=FtMotorDirection.CCW, _
                                                s1Idx:=FtMotor.NotUsed, s1Direction:=FtMotorDirection.CCW, _
                                                s2Idx:=FtMotor.NotUsed, s2Direction:=FtMotorDirection.CCW, _
                                                s3Idx:=FtMotor.NotUsed, s3Direction:=FtMotorDirection.CCW, _
                                                pulseCnt:=100)

        Len = FtMscLibEx.ftxGetLibErrorString(errCode, 1, buff, 40)
        Me.Invoke((Sub(t As String) Me.txtInfo.AppendText(t)), "StartMotorEx: " + buff.ToString() + vbCrLf)
        ActivatesO6O7()



    End Sub
    ''' <summary>
    ''' Activated the O6 and O7
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ActivatesO6O7()
        Dim errCode, Len As UInteger
        Dim buff As StringBuilder = New StringBuilder(45)
        errCode = myController.SetOutPwmValues(devId:=FtDeviceID.Master, outId:=FtOutput.O6, duty:=500)
        Len = FtMscLibEx.ftxGetLibErrorString(errCode, 1, buff, 40)
        Me.Invoke((Sub(t As String) Me.txtInfo.AppendText(t)), "Led 1" + buff.ToString() + vbCrLf)
        errCode = myController.SetOutPwmValues(devId:=FtDeviceID.Master, outId:=FtOutput.O7, duty:=500)
        Len = FtMscLibEx.ftxGetLibErrorString(errCode, 1, buff, 40)
        Me.Invoke((Sub(t As String) Me.txtInfo.AppendText(t)), "Led 2 " + buff.ToString() + vbCrLf)
    End Sub
    ''' <summary>
    ''' Event handler for Fast Counter Changed<br/>
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="args"></param>
    ''' <remarks>Direct added to the myController.OnCounterChanged event</remarks>
    Public Sub MyCounter_Changed(ByVal sender As Object, args As CounterChangedEventArgs) Handles myController.OnCounterChanged
        Dim result As String = ("MyCounter_Changed " + args.devId.ToString() + _
                                "  " + args.cntId.ToString() + _
                                "  count=" + args.count.ToString() + "  mode=" + args.mode.ToString() + vbCrLf)

        Me.Invoke((Sub(t As String) Me.txtInfo.AppendText(t)), result)
    End Sub
    ''' <summary>
    '''  Event handler for Cnt Input Changed
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="args"></param>
    ''' <remarks>Direct added to the myController.OnCntInputChanged event</remarks>
    Public Sub MyCntInput_Changed(ByVal sender As Object, args As CntInputChangedEventArgs) Handles myController.OnCntInputChanged
        Dim result As String = ("MyCntInput_Changed " + args.devId.ToString() + _
                                "  " + args.cntId.ToString() + "  " + args.state.ToString() + vbCrLf)

        Me.Invoke((Sub(t As String) Me.txtInfo.AppendText(t)), result)
    End Sub
    ''' <summary>
    ''' Event handler for Motor Reached (extended motor control)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="args"></param>
    ''' <remarks>Direct added to the myController.OnMotorExReached event</remarks>
    Public Sub MyMotor_Reached(ByVal sender As Object, args As MotorReachedEventArgs) Handles myController.OnMotorExReached
        Dim result As String = ("MyMotor_Reached event dev=" + args.devId.ToString() + " motor=" + args.mtrIdx.ToString() + vbCrLf)
        'Patron for working with more Encoder motors
        Select Case (Convert.ToInt32(args.devId))
            Case FtDeviceID.Master
                Select Case (Convert.ToInt32(args.mtrIdx))
                    Case FtMotor.M1
                        result += " switch master,M1=" + vbCrLf
                        myController.SetOutPwmValues(devId:=FtDeviceID.Master, outId:=FtOutput.O6, duty:=0)
                        myController.SetOutPwmValues(devId:=FtDeviceID.Master, outId:=FtOutput.O7, duty:=0)
                    Case FtMotor.M2
                        result += " switch master,M2" + vbCrLf
                    Case FtMotor.M3
                        result += " switch master,M3" + vbCrLf
                    Case FtMotor.M4
                        result += " switch master,M4" + vbCrLf

                End Select
            Case Else
                result += " slave device used" + vbCrLf
        End Select
        'End patron
        Me.Invoke((Sub(t As String) Me.txtInfo.AppendText(t)), result)
    End Sub
    ''' <summary>
    ''' Event handler for input changes
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="args"></param>
    ''' <remarks>Direct added to the myController.OnInputChanged event</remarks>
    Private Sub MyInput1_Changed(ByVal sender As Object, args As InputChangedEventArgs) Handles myController.OnInputChanged
        Dim result As String = ("MyInput1_Change event dev=" + args.devId.ToString() + " ioId=" + args.ioId.ToString() + _
                                " value=" + args.value.ToString() + "  dig/ana=" + args.digital.ToString() + vbCrLf)
        Me.Invoke((Sub(t As String) Me.txtInfo.AppendText(t)), result)
    End Sub
    ''' <summary>
    ''' Event handler for input changes
    ''' Based on the state of the two switches
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="args"></param>
    ''' <remarks>Will be added to the myController.OnInputChanged event later in the program</remarks>
    Public Sub MyInput2_Changed(ByVal sender As Object, args As InputChangedEventArgs)
        Dim result As String = "MyInput2_Changed event dev=" + args.devId.ToString() + _
                                " ioId=" + args.ioId.ToString() + _
                                " value=" + args.value.ToString() + "  dig/ana=" + args.digital.ToString()
        Me.Invoke((Sub(t As String) Me.txtInfo.AppendText(t)), "Invoke: " + result + vbCrLf)
        If ((args.devId = FtDeviceID.Master) And (args.ioId = FtInput.I1)) Then
            If (args.value = 1) Then
                myController.SetOutPwmValues(devId:=FtDeviceID.Master, outId:=FtOutput.O4, duty:=512)
            Else
                myController.SetOutPwmValues(devId:=0, outId:=FtOutput.O4, duty:=0)
            End If
        End If
        If ((args.devId = FtDeviceID.Master) And (args.ioId = FtInput.I2)) Then
            If (args.value = 1) Then
                myController.SetOutPwmValues(devId:=FtDeviceID.Master, outId:=FtOutput.O5, duty:=512)
            Else
                myController.SetOutPwmValues(devId:=FtDeviceID.Master, outId:=FtOutput.O5, duty:=0)
            End If
        End If
    End Sub
    ''' <summary>
    ''' Event handler for the display buttons
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="args"></param>
    ''' <remarks>Direct added to the myController.OnButtonChanged event</remarks>
    Public Sub MyButton_Changed(ByVal sender As Object, args As ButtonChangedEventArgs) Handles myController.OnButtonChanged
        Me.Invoke((Sub(t As String) Me.txtInfo.AppendText(t)), _
                  "Button changed event [" + args.devId.ToString() + " , " + args.buttonId.ToString() + _
                 "] duration=" + args.duration.ToString() + " pressed=" + args.pressed.ToString() + vbCrLf)

    End Sub
    Dim res As String


    Private Sub txtComPort_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtComPort.TextChanged

    End Sub
End Class
