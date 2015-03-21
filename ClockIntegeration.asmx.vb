Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class ClockIntegeration
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function GetActiveSession(ByVal username As String, ByVal password As String) As String

        Try

            Dim _sqlCon As New System.Data.SqlClient.SqlConnection(My.Settings.cn)

            Dim usr As New ENI_BE.BusinessLayer.Users(_sqlCon)

            Dim s As String = usr.getNewSession(username, password, "")

            _sqlCon.Dispose()

            Return s

        Catch ex As Exception
            Return "Failure, " & ex.Message
        End Try

    End Function

    <WebMethod()> _
    Public Function GetListOfMachines() As String

        Dim _sqlCon As New System.Data.SqlClient.SqlConnection(My.Settings.cn)

        Dim _reg As New ENI_BE.BusinessLayer.CMRegister(_sqlCon)

        _reg.LoadActiveDevices()

        Dim _i As Integer = 0

        Dim _list As String = ""

        For _i = 0 To _reg.dataSet.CMRegister.Rows.Count - 1
            _reg.loadDetail(_i)

            If _list.Length > 0 Then
                _list += "|"
            End If
            _list += _reg.SerialNumber
        Next

        _sqlCon.Dispose()

        Return _list

    End Function

    <WebMethod()> _
    Public Function GetListOfMachinesForUser(ByVal activeSession As String) As String

        Dim _sqlCon As New System.Data.SqlClient.SqlConnection(My.Settings.cn)

        Dim _reg As New ENI_BE.BusinessLayer.CMRegister(_sqlCon)

        ' get the user id

        Dim _usrses As New ENI_BE.BusinessLayer.UserSessions(_sqlCon)

        _usrses.ValidateSession(activeSession)

        _reg.LoadActiveDevices(_usrses.UserId)

        Dim _i As Integer = 0

        Dim _list As String = ""

        For _i = 0 To _reg.dataSet.CMRegister.Rows.Count - 1
            _reg.loadDetail(_i)

            If _list.Length > 0 Then
                _list += "|"
            End If
            _list += _reg.SerialNumber
        Next

        _sqlCon.Dispose()

        Return _list

    End Function

    <WebMethod()> _
    Public Function GetListOfMachinesForUserGSMOnly(ByVal activeSession As String) As String

        Dim _sqlCon As New System.Data.SqlClient.SqlConnection(My.Settings.cn)

        Dim _reg As New ENI_BE.BusinessLayer.CMRegister(_sqlCon)

        ' get the user id

        Dim _usrses As New ENI_BE.BusinessLayer.UserSessions(_sqlCon)

        _usrses.ValidateSession(activeSession)

        _reg.LoadActiveDevicesGSMOnly(_usrses.UserId)

        Dim _i As Integer = 0

        Dim _list As String = ""

        For _i = 0 To _reg.dataSet.CMRegister.Rows.Count - 1
            _reg.loadDetail(_i)

            If _list.Length > 0 Then
                _list += "|"
            End If
            _list += _reg.SerialNumber
        Next

        _sqlCon.Dispose()

        Return _list

    End Function

    <WebMethod()> _
    Public Function GetMachineCnInfo(ByVal serialNumber As String) As String

        Dim _sqlCon As New System.Data.SqlClient.SqlConnection(My.Settings.cn)

        Dim _reg As New ENI_BE.BusinessLayer.CMRegister(_sqlCon)

        _reg.Load(serialNumber)

        Dim _i As Integer = 0

        Dim _list As String = ""

        For _i = 0 To _reg.dataSet.CMRegister.Rows.Count - 1
            _reg.loadDetail(_i)

            If _list.Length > 0 Then
                _list += "|"
            End If
            _list += _reg.IPNumber & "|" & _reg.Port & "|" & _reg.AllocatedToSiteId & "|" & _reg.Name.Replace("|", "") & "|" & _reg.MachineNumber & "|" & _reg.Password
        Next

        _sqlCon.Dispose()

        Return _list

    End Function

    <WebMethod()> _
    Public Function WriteClockRecord(ByVal SerialNumber As String, _
                                     ByVal activeSession As String, _
                                        ByVal payrollId As String, _
                                            ByVal Year_ As String, _
                                            ByVal month_ As String, _
                                            ByVal day_ As String, _
                                            ByVal hour_ As String, _
                                            ByVal min_ As String, _
                                            ByVal sec_ As String, _
                                            ByVal site_ As String) As String

        Throw New Exception("This method has been replaced. Please contact your system adminstrator to upgrade your Clock server")

    End Function

    <WebMethod()> _
    Public Function WriteClockRecordWithDetail(ByVal SerialNumber As String, _
                                                ByVal activeSession As String, _
                                                ByVal payrollId As String, _
                                                ByVal Year_ As String, _
                                                ByVal month_ As String, _
                                                ByVal day_ As String, _
                                                ByVal hour_ As String, _
                                                ByVal min_ As String, _
                                                ByVal sec_ As String, _
                                                ByVal site_ As String,
                                                ByVal verifyMode_ As String, _
                                                ByVal inOutMode_ As String, _
                                                ByVal wc_ As String) As String

        Dim _sqlCon As New System.Data.SqlClient.SqlConnection(My.Settings.cn)

        ' Load the user from his ID

        Dim _actSes As New ENI_BE.BusinessLayer.UserSessions(_sqlCon)

        Dim usr As ENI_BE.BusinessLayer.Users = _actSes.ValidateSession(activeSession)

        Dim _atl As New ENI_BE.BusinessLayer.AttendanceLog(_sqlCon)

        Dim s As String = _atl.WriteAttendanceEntry_R01(SerialNumber, activeSession, payrollId, Year_, month_, day_, hour_, min_, sec_, site_, _
                                         verifyMode_, inOutMode_, wc_)

        _sqlCon.Dispose()

        Return s

    End Function

End Class