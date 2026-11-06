

Public Class ClsVariable
    Public Class COA
        Public Shared NoCOA_Awal As String = "11.01.001"
        Public Shared NoCOA_Akhir As String = "99.99.999"
    End Class
    Class Toast
        Public Error_Load_Data, Error_Choose_Data, Error_Closing_Date As String
        Public Error_Query_SQL, Error_Splash_Screen, Error_Load_Paraf As String
        Public Error_UserLogin, Error_WrongPassword As String
        Public Error_EmptyAcquisitionDate As String

        Public Error_Save_Data, Error_Delete_Data As String
        Public Success_Save_Data, Success_Delete_Data As String
        Public Success_Activation, Notif_LoadData As String
        Public Quit_Application, Question_CloseForm, Question_ChangePeriode, Question_ClosingDate, Question_Save, Question_Delete, Warning_Activation, Question_Posting As String
        Public Question_Update As String
        Public Question_SPTBaru, Question_SPTBaruBerhasil, Question_SPTBuka, Question_SPTBukaBerhasil, Question_SPTHapus, Question_SPTPembetulan As String
        Public Warning_BukaPeriode, Warning_ChooseItemProduction As String
        Public Success_Connect_Device, Error_Load_UserFinger As String
    End Class
    Class ComputerAccess
        Public ApplicationID As String
        Public CompanyID As String
        Public ComputerName As String
        Public ComputerDescriptions As String
        Public AccessInd As Integer
    End Class
    Class AppCorporateData
        Public CompanyID As String
        Public InstallationCode, SerialNumber, ActivationCode As String
    End Class
    Class AppDBLogin
        Public CompanyName, IconName As String
        Public AppServerPublic, AppUser, AppDB, AppPwd As String
        Public AppServerPublicHR, AppUserHR, AppDBHR, AppPwdHR As String
        Public RememberMe As Boolean
    End Class
    Class UserLogin
        Public LoginID, LoginName, Pass, JabatanName, GroupName, UrlParaf, BranchID, BranchName As String
        Public RegUsername, RegPassword As String, RegRememberMe As Boolean
        Public Periode, ClosingDate As Date
        Public LanguageID As String
    End Class
    Class COA_Payable
        Public WIP_NoCOA, WIP_AccountName, WIP_PelengkapCOA, WIP_PelengkapCOAID, WIP_PelengkapCOAName As String
        Public PAY_NoCOA, PAY_AccountName, PAY_PelengkapCOA, PAY_PelengkapCOAID, PAY_PelengkapCOAName As String
        Public PPN_NoCOA, PPN_AccountName, PPN_PelengkapCOA, PPN_PelengkapCOAID, PPN_PelengkapCOAName, PPNRemark As String
        Public DISC_NoCOA, DISC_AccountName, DISC_PelengkapCOA, DISC_PelengkapCOAID, DISC_PelengkapCOAName, DISC_Remark As String
        Public BIY_NoCOA, BIY_AccountName, BIY_PelengkapCOA, BIY_PelengkapCOAID, BIY_PelengkapCOAName, BIY_Remark As String
        Public STOK_NoCOA, STOK_AccountName, STOK_PelengkapCOA, STOK_PelengkapCOAID, STOK_PelengkapCOAName, STOK_Remark As String
        Public PPH_NoCOA, PPH_AccountName, PPH_PelengkapCOA, PPH_PelengkapCOAID, PPH_PelengkapCOAName, PPH_Remark As String
        Public ITEM_Remark As String
    End Class
    Class COA_Receivable
        Public RECV_NoCOA, RECV_AccountName, RECV_PelengkapCOA, RECV_PelengkapCOAID, RECV_PelengkapCOAName As String
        Public SALES_NoCOA, SALES_AccountName, SALES_PelengkapCOA, SALES_PelengkapCOAID, SALES_PelengkapCOAName As String
        Public PPN_NoCOA, PPN_AccountName, PPN_PelengkapCOA, PPN_PelengkapCOAID, PPN_PelengkapCOAName, PPN_Remark As String
        Public DISC_NoCOA, DISC_AccountName, DISC_PelengkapCOA, DISC_PelengkapCOAID, DISC_PelengkapCOAName, DISC_Remark As String
        Public BIY_NoCOA, BIY_AccountName, BIY_PelengkapCOA, BIY_PelengkapCOAID, BIY_PelengkapCOAName, BIY_Remark As String
        Public PPH22_NoCOA, PPH22_AccountName, PPH22_PelengkapCOA, PPH22_PelengkapCOAID, PPH22_PelengkapCOAName, PPH22_Remark As String
        Public ITEM_Remark As String
    End Class
    Public Enum RibbonSizeMode
        None = 0
        Overflow = 1
        Compact = 2
        Medium = 3
        Large = 4
        DropDown = 5
    End Enum
    Class Variable
        Public ServerFile, BaseUrlWebDav As String
        Public varBackdateLimit, varDaysMaksInput As Integer
        Public ProfilBPJSTK As String
        Public ClosingDate As DateTime
        Public RMP_Login, RMP_Mitra, RMP_Pembelian, RMP_Pembelian_Pulled, RMP_Penjualan, RMP_Penjualan_Pulled As String
        Public RMP_Penjualan_V2 As String
        Public QC_Token, QC_WAMessage As String
        Public PAYROLL_RekeningMandiri, PAYROLL_RekeningBCA, PAYROLL_RekeningBNI As String
    End Class
    Shared Sub SaveVariableProgram()
        Dim sql As String
        sql = "SELECT * FROM tblAppMstVariable"
        Dim dtTable As DataTable = DB.ExecuteQuery(StrConnDBPancang, sql)
        If dtTable.Rows.Count > 0 Then
            For Each dr As DataRow In dtTable.Rows
                Select Case dr!VarID
                    Case 1 : cls_VarProgram.ServerFile = "BPI.API"'dr!VarValue
                    Case 3 : cls_VarProgram.BaseUrlWebDav = dr!VarValue
                    Case 4 : cls_VarProgram.varBackdateLimit = dr!VarValue
                    Case 5 : cls_VarProgram.varDaysMaksInput = dr!VarValue
                    Case 6 : cls_VarProgram.ProfilBPJSTK = dr!VarValue

                    Case 11 : cls_VarProgram.RMP_Login = dr!VarValue
                    Case 12 : cls_VarProgram.RMP_Pembelian = dr!VarValue
                    Case 13 : cls_VarProgram.RMP_Penjualan = dr!VarValue
                    Case 14 : cls_VarProgram.RMP_Pembelian_Pulled = dr!VarValue
                    Case 15 : cls_VarProgram.RMP_Penjualan_Pulled = dr!VarValue
                    Case 16 : cls_VarProgram.RMP_Mitra = dr!VarValue
                    Case 17 : cls_VarProgram.RMP_Penjualan_V2 = dr!VarValue



                    Case 50 : cls_VarProgram.QC_Token = dr!VarValue
                    Case 51 : cls_VarProgram.QC_WAMessage = dr!VarValue

                    Case 90 : cls_VarProgram.PAYROLL_RekeningMandiri = dr!VarValue
                    Case 91 : cls_VarProgram.PAYROLL_RekeningBCA = dr!VarValue
                    Case 92 : cls_VarProgram.PAYROLL_RekeningBNI = dr!VarValue
                End Select
            Next
        End If
        cls_VarProgram.ClosingDate = DB.ExecuteScalarValue(Of String)(StrConnDBPancang, "SELECT TOP 1 CONVERT(varchar(10),ClosingDate,103) as GetValueString FROM tblAppUtlCLosingDate ORDER BY DetailID Desc")
    End Sub

    Shared Sub SetVariableToast()
        Dim sql As String
        sql = "SELECT * FROM tblAppMstVariableToast"
        Try
            Dim dtTable As DataTable = DB.ExecuteQuery(StrConnDBPancang, sql)
            If dtTable.Rows.Count > 0 Then
                For Each dr As DataRow In dtTable.Rows
                    Select Case dr!VarID
                        Case "Success_Delete_Data" : cls_VarToast.Success_Delete_Data = dr!VarValue
                        Case "Success_Save_Data" : cls_VarToast.Success_Save_Data = dr!VarValue
                        Case "Success_Activation" : cls_VarToast.Success_Activation = dr!VarValue
                        Case "Error_Choose_Data" : cls_VarToast.Error_Choose_Data = dr!VarValue
                        Case "Error_Closing_Date" : cls_VarToast.Error_Closing_Date = dr!VarValue
                        Case "Error_Load_Data" : cls_VarToast.Error_Load_Data = dr!VarValue
                        Case "Error_Load_Paraf" : cls_VarToast.Error_Load_Paraf = dr!VarValue
                        Case "Error_Query_SQL" : cls_VarToast.Error_Query_SQL = dr!VarValue
                        Case "Error_Save_Data" : cls_VarToast.Error_Save_Data = dr!VarValue
                        Case "Error_Splash_Screen" : cls_VarToast.Error_Splash_Screen = dr!VarValue
                        Case "Error_UserLogin" : cls_VarToast.Error_UserLogin = dr!VarValue
                        Case "Error_WrongPassword" : cls_VarToast.Error_WrongPassword = dr!VarValue
                        Case "Error_EmptyAcquisitionDate" : cls_VarToast.Error_EmptyAcquisitionDate = dr!VarValue
                        Case "Quit_Application" : cls_VarToast.Quit_Application = dr!VarValue
                        Case "Question_CloseForm" : cls_VarToast.Question_CloseForm = dr!VarValue
                        Case "Question_Save" : cls_VarToast.Question_Save = dr!VarValue
                        Case "Question_Delete" : cls_VarToast.Question_Delete = dr!VarValue
                        Case "Warning_Activation" : cls_VarToast.Warning_Activation = dr!VarValue
                        Case "Question_Posting" : cls_VarToast.Question_Posting = dr!VarValue
                        Case "Notif_LoadData" : cls_VarToast.Notif_LoadData = dr!VarValue
                        Case "Question_ChangePeriode" : cls_VarToast.Question_ChangePeriode = dr!VarValue
                        Case "Question_ClosingDate" : cls_VarToast.Question_ClosingDate = dr!VarValue
                        Case "Question_Update" : cls_VarToast.Question_Update = dr!Value
                        Case "Warning_BukaPeriode" : cls_VarToast.Warning_BukaPeriode = dr!VarValue

                        Case "Question_SPTBaru" : cls_VarToast.Question_SPTBaru = dr!VarValue
                        Case "Question_SPTBaruBerhasil" : cls_VarToast.Question_SPTBaruBerhasil = dr!VarValue
                        Case "Question_SPTBuka" : cls_VarToast.Question_SPTBuka = dr!VarValue
                        Case "Question_SPTBukaBerhasil" : cls_VarToast.Question_SPTBukaBerhasil = dr!VarValue
                        Case "Question_SPTPembetulan" : cls_VarToast.Question_SPTPembetulan = dr!VarValue
                        Case "Question_SPTHapus" : cls_VarToast.Question_SPTHapus = dr!VarValue

                    End Select
                Next
            End If
        Catch ex As Exception
            Call MsgBoxCustom.Show("Variable Toast Error" & vbCrLf &
                                    ex.Message & "(SetVariableToast)", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
        End Try
    End Sub
    Shared Function SetPeriodePPN(ByVal Periode As Date, ByVal PPnBMInd As Boolean) As DataTable
        Dim dtTable As DataTable
        dtTable = DB.ExecuteQuery(StrConnDBPancang, "SELECT * FROM GEN_vwMstPeriodePPN WHERE PPnBMInd='" & IIf(PPnBMInd = True, 1, 0) & "' AND CONVERT(DATE,'" & Format(Periode, "dd/MM/yyyy") & "' , 103) BETWEEN CONVERT(DATE, StartDate , 103) AND CONVERT(DATE, ENDDate , 103)")
        Return dtTable
    End Function
    Shared Function SetPeriodePPD(ByVal Periode As Date, ByVal PPnBMInd As Boolean) As DataTable
        Dim dtTable As DataTable
        dtTable = DB.ExecuteQuery(StrConnDBPancang, "SELECT * FROM GEN_vwMstPeriodePPD WHERE CONVERT(DATE,'" & Format(Periode, "dd/MM/yyyy") & "' , 103) BETWEEN CONVERT(DATE, StartDate , 103) AND CONVERT(DATE, ENDDate , 103)")
        Return dtTable
    End Function
End Class
