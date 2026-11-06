Imports C1.Win.C1FlexGrid
Imports Microsoft.Reporting.WinForms
Imports Microsoft.ReportingServices.Diagnostics.Internal
Imports PdfSharp
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class FrmRptUangMakanPCG
	Public Conn As SqlConnection
	Dim _Dt As DataTable = New DataTable()
	Dim TXT As CellRange
	Dim dataTable As New DataTable()
	Private Sub FrmRptUangMakanPCG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Me.Cursor = Cursors.WaitCursor

		ReportViewer1.Reset()
		Me.ReportViewer1.RefreshReport()
		Dim newPageSetting As New System.Drawing.Printing.PageSettings
		newPageSetting.PaperSize = New PaperSize("A4", 827, 1169)
		newPageSetting.Landscape = True
		newPageSetting.Margins = New System.Drawing.Printing.Margins(1, 1, 1, 1)
		newPageSetting.Margins.Top = 40
		newPageSetting.Margins.Left = 40
		newPageSetting.Margins.Bottom = 40
		ReportViewer1.SetPageSettings(newPageSetting)
		LoadData()
		Call ReportShow()

		Me.Cursor = Cursors.Default
	End Sub
	Private Sub LoadData()
		Dim SQL As String
		Dim Bagian As String
		Dim connetionString As String = "server=192.168.12.5; database=RMPAPP; user=UKoneksi; password=sm@rt2018;  MultipleActiveResultSets=True; connect timeout=0;Max Pool Size=500000  ;"
		Dim Connection As SqlConnection = New SqlConnection(connetionString)
		If FrmMonUangMakanPCG.rdp1.Checked = True Then
			Bagian = "P1"
		End If
		If FrmMonUangMakanPCG.rdp2.Checked = True Then
			Bagian = "P2"
		End If
		Dim Status, Status_ As String
		If FrmMonUangMakanPCG.ChkKaryawan.Checked = True And FrmMonUangMakanPCG.ChkHarian.Checked = False Then
			Status = "Karyawan"
			Status_ = "Karyawan"
		ElseIf FrmMonUangMakanPCG.ChkKaryawan.Checked = False And FrmMonUangMakanPCG.ChkHarian.Checked = True Then
			Status = "Harian"
			Status_ = "Harian"
		ElseIf FrmMonUangMakanPCG.ChkKaryawan.Checked = True And FrmMonUangMakanPCG.ChkHarian.Checked = True Then
			Status = "Harian'',''Karyawan"
			Status_ = "Harian Dan Karyawan"
		End If

		SQL = "declare @StartDate DATE,@EndDate DATE,@cols AS NVARCHAR(MAX),@query  AS NVARCHAR(MAX),@Bagian AS VARCHAR(5),@Status AS VARCHAR(20)
		                    set @StartDate ='" & Format(FrmMonUangMakanPCG.dtp1.Value, "yyyy-MM-dd") & "'
		                    set @EndDate ='" & Format(FrmMonUangMakanPCG.dtp2.Value, "yyyy-MM-dd") & "'
                             set @Bagian ='" & Bagian & "'
                             set @Status ='" & Status & "'

		                     declare @WorkingDays Table 
		                     (
		                       WDate DATE
		                     )
		                    ;with d(date) as (
		                      select cast(@StartDate as datetime)
		                      union all
		                      select date+1
		                      from d
		                      where date < @EndDate
		                      )
		                     insert into @WorkingDays select  d.date from d
		                     SET @cols = STUFF((SELECT  ',' + QUOTENAME(convert(varchar,wd.WDate, 103)) 
							 --+  QUOTENAME(convert(varchar,wd.WDate, 103)) 
					                FROM @WorkingDays wd
                                    group by wd.WDate
					                order by wd.WDate asc
					                    FOR XML PATH(''), TYPE
					                    ).value('.', 'NVARCHAR(MAX)') 
				                    ,1,1,'')
		                    set  @query = ';WITH 
						     tabuangmakan(IDPancang,uang_makan,Nik,IDPersonil,NamaPersonil,Pancang,Tanggal, Status,Bagian,UangMakan ,HL,NamaRekeningBank,Bank,NoRekeningBank,KodeBank,LAYANANTRF,OrderBank) AS
                            (
							SELECT IDPancang,uang_makan,Nik,IDPersonil,nama as NamaPersonil ,Pancang,convert(varchar, Tanggal, 103) , Kehadiran, Bagian,UangMakan,HL,NamaRek,Bank,NoRekeningBank,KodeBank,LAYANANTRF,
							case 
								when Bank = ''BNI'' then ''A'' 
								when Bank = ''MANDIRI'' THEN ''B'' 
								ELSE ''C'' 
							END AS OrderBank
							FROM vwabsensimonuangmakanNEW_2024 
							WHERE  Kehadiran=''H'' and ((convert(time,JamAbsen) between ''09:58'' and ''14:02'') or (HitungUangMakan=1)) and (TidakHitungUangMakan=0 OR TIDAKHITUNGUANGMAKAN IS NULL) and uang_makan <> 0
							AND Status in ('''+ @Status +''') and cast(TANGGAL as date) BETWEEN '''+cast(@StartDate as VARCHAR)+''' AND '''+cast(@EndDate as VARCHAR)+'''  and  bagian='''+ @Bagian +'''
							
							UNION 
							
							SELECT IDPancang,uang_makan,Nik,IDPersonil,nama as NamaPersonil ,Pancang,convert(varchar, Tanggal, 103) , Kehadiran, Bagian,UangMakan,HL,NamaRek,Bank,NoRekeningBank,KodeBank,LAYANANTRF,
							case 
								when Bank = ''BNI'' then ''A'' 
								when Bank = ''MANDIRI'' THEN ''B'' 
								ELSE ''C'' 
							END AS OrderBank
							FROM vwabsensimonuangmakanNEW_2024 
							WHERE  Kehadiran=''TL'' and (TidakHitungUangMakan=0 OR TIDAKHITUNGUANGMAKAN IS NULL) and uang_makan <> 0
							AND Status in ('''+ @Status +''') and cast(TANGGAL as date) BETWEEN '''+cast(@StartDate as VARCHAR)+''' AND '''+cast(@EndDate as VARCHAR)+'''   and bagian='''+ @Bagian +'''
							
							UNION 
							
							SELECT IDPancang,uang_makan,Nik,IDPersonil,nama as NamaPersonil ,Pancang,convert(varchar, Tanggal, 103) , Kehadiran, Bagian,UangMakan,HL,NamaRek,Bank,NoRekeningBank,KodeBank,LAYANANTRF,
							case 
								when Bank = ''BNI'' then ''A'' 
								when Bank = ''MANDIRI'' THEN ''B'' 
								ELSE ''C'' 
							END AS OrderBank
							FROM vwabsensimonuangmakanNEW_2024 
							WHERE  AbsenManual=1 and (TidakHitungUangMakan=0 OR TIDAKHITUNGUANGMAKAN IS NULL) and uang_makan <> 0
							AND Status in ('''+ @Status +''') and cast(TANGGAL as date) BETWEEN '''+cast(@StartDate as VARCHAR)+''' AND '''+cast(@EndDate as VARCHAR)+'''  and bagian='''+ @Bagian +'''
                            ),
                            datauangmakan as (SELECT *
                            FROM    tabuangmakan
                            PIVOT 
                            (
                                SUM (UangMakan) 
                                FOR Tanggal IN ('+ @cols +')
                            ) AS pvtlembur


                            )
						    select NamaPersonil as Nama,
							(select count(id) from Android_tblAbsensiPancangNew where IDPersonil=a.IDPersonil and cast(PancangID as varchar)=a.IDPancang AND cast(createddate as date) BETWEEN '''+cast(@StartDate as VARCHAR)+''' AND '''+cast(@EndDate as VARCHAR)+''') as HK,
							uang_makan as RP, 
							((REPLACE(NoRekeningBank, ''FlagRekMst'', ''''))+'' ''+NamaRekeningBank) as REKENING,a.*,0 AS UangMakan
							from datauangmakan as a ORDER BY OrderBank,NamaPersonil ASC'
				     execute(@query)"

		Dim dt_ As DataTable = New DataTable
		dt_ = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, SQL)
		DS.Tables.Add(dt_.Copy())

		'menghilangkan kolom yang sudah tak di gunakan karena hanya trik
		Dim kolomHapus As String() = {"IDPancang", "uang_makan", "IDpersonil", "NamaPersonil", "Status", "HL", "NamaRekeningBank", "Bank", "NoRekeningBank", "KodeBank", "LAYANANTRF", "OrderBank"}

		If DS.Tables.Count > 0 Then
			For Each kolom As String In kolomHapus
				If DS.Tables(0).Columns.Contains(kolom) Then
					DS.Tables(0).Columns.Remove(kolom)
				End If
			Next
		End If

		fg_DS.DataSource = DS.Tables(0)

		' Atur jumlah baris dan kolom
		fg.Rows.Count = fg_DS.Rows.Count
		fg.Cols.Count = fg_DS.Cols.Count

		' Salin data cell-by-cell
		For row As Integer = 0 To fg_DS.Rows.Count - 1
			For col As Integer = 0 To fg_DS.Cols.Count - 1
				fg(row, col) = fg_DS(row, col)
			Next
		Next

		'Connection.Open()
		'DS.Reset()
		'Dim Adapter As SqlDataAdapter = New SqlDataAdapter(SQL, Connection)
		'Adapter.Fill(DS)
		'Connection.Close()
		'DS.Tables(0).Columns.Remove("IDPancang")
		'DS.Tables(0).Columns.Remove("uang_makan")
		'DS.Tables(0).Columns.Remove("IDpersonil")
		'DS.Tables(0).Columns.Remove("NamaPersonil")
		'DS.Tables(0).Columns.Remove("Status")
		'DS.Tables(0).Columns.Remove("HL")
		'DS.Tables(0).Columns.Remove("NamaRekeningBank")
		'DS.Tables(0).Columns.Remove("Bank")
		'DS.Tables(0).Columns.Remove("NoRekeningBank")
		'DS.Tables(0).Columns.Remove("KodeBank")
		'DS.Tables(0).Columns.Remove("LAYANANTRF")
		'DS.Tables(0).Columns.Remove("OrderBank")
		'fg.DataSource = DS.Tables(0)

		Dim totalrel As Decimal
		Dim COLU As Integer
		For a = 1 To fg.Rows.Count - 1
			totalrel = 0
			fg.Item(a, 0) = a

			For COLU = 8 To fg.Cols.Count - 1
				If Not IsDBNull(fg.Item(a, COLU)) Then
					If Val(fg.Item(a, COLU)) > 0 Then
						totalrel = fg.Item(a, COLU) + totalrel
					End If
				End If
			Next

			Dim totalstr As String

			fg.Item(a, fg.Cols.Count - 1) = totalrel
		Next

		For i As Integer = 8 To fg.Cols.Count - 2
			TXT = fg.GetCellRange(0, i, 0, i) : fg.Cols(i).Visible = False
		Next

		'menggabungkan jumlah data yang sama
		For i As Integer = fg.Rows.Count - 1 To 2 Step -1
			If fg.Item(i, 1) = fg.Item(i - 1, 1) AndAlso fg.Item(i, 6) = fg.Item(i - 1, 6) Then
				fg.Item(i - 1, fg.Cols.Count - 1) = fg.Item(i - 1, fg.Cols.Count - 1) + fg.Item(i, fg.Cols.Count - 1)
				'fg.Item(i - 1, 2) = fg.Item(i - 1, 2) + fg.Item(i, 2)
				fg.Rows.Remove(i)
			End If
		Next i

		'SUSUN ULANG no pada tabel
		For I = 1 To fg.Rows.Count - 1
			fg.Item(I, 0) = I
		Next

		' Menambahkan kolom-kolom yang diinginkan ke DataTable
		dataTable.Columns.Add("Nama", GetType(String))
		dataTable.Columns.Add("RP", GetType(Integer))
		dataTable.Columns.Add("REKENING", GetType(String))
		dataTable.Columns.Add("Nik", GetType(Integer))
		dataTable.Columns.Add("Pancang", GetType(String))
		dataTable.Columns.Add("Bagian", GetType(String))
		dataTable.Columns.Add("UangMakan", GetType(Long))
		dataTable.Columns.Add("HK", GetType(Integer))

		' Mengambil data dari C1FlexGrid dan memasukkan ke DataTable
		For row As Integer = 1 To fg.Rows.Count - 1
			Dim dataRow As DataRow = dataTable.NewRow()

			dataRow("Nama") = fg.Item(row, 1)
			dataRow("RP") = fg.Item(row, 3)
			dataRow("REKENING") = fg.Item(row, 4)
			dataRow("Nik") = fg.Item(row, 5)
			dataRow("Pancang") = fg.Item(row, 6)
			dataRow("Bagian") = fg.Item(row, 7)
			dataRow("UangMakan") = fg.Item(row, fg.Cols.Count - 1)
			dataRow("HK") = fg.Item(row, 2)

			dataTable.Rows.Add(dataRow)
		Next
	End Sub
	Private Sub ReportShow()
		Try
			Me.Cursor = Cursors.WaitCursor

			Dim ReportName, Ds, SQL As String
			Dim Bagian As String

			If FrmMonUangMakanPCG.rdp1.Checked = True Then
				Bagian = "P1"
			End If
			If FrmMonUangMakanPCG.rdp2.Checked = True Then
				Bagian = "P2"
			End If

			Dim Status, Status_ As String
			If FrmMonUangMakanPCG.ChkKaryawan.Checked = True And FrmMonUangMakanPCG.ChkHarian.Checked = False Then
				Status = "Karyawan"
				Status_ = "KARYAWAN"
			ElseIf FrmMonUangMakanPCG.ChkKaryawan.Checked = False And FrmMonUangMakanPCG.ChkHarian.Checked = True Then
				Status = "Harian"
				Status_ = "HARIAN"
			ElseIf FrmMonUangMakanPCG.ChkKaryawan.Checked = True And FrmMonUangMakanPCG.ChkHarian.Checked = True Then
				Status = "Harian'',''Karyawan"
				Status_ = "HARIAN DAN KARYAWAN"
			End If

			Dim Periode As String
			If FrmMonUangMakanPCG.dtp1.Value.Day <= 15 Then
				Periode = "1"
			Else
				Periode = "2"
			End If

			Dim TglPeriode As String = (Format(FrmMonUangMakanPCG.dtp1.Value, "dd/MM/yyyy") & " SD " & Format(FrmMonUangMakanPCG.dtp2.Value, "dd/MM/yyyy")).ToString
			Dim PeriodeV2 As String = (Format(FrmMonUangMakanPCG.dtp1.Value, "dd") & "-" & Format(FrmMonUangMakanPCG.dtp2.Value, "dd MMMM yyyy")).ToString
			Dim ParamList As New Generic.List(Of ReportParameter)

			Dim Hasil As Integer = 0
			For Each row As DataRow In dataTable.Rows
				Hasil += row("UangMakan")
			Next

			Dim number As Integer = Hasil
			Dim TotTerbilang As String = NumberToWords(number)
			Dim textInfo As Globalization.TextInfo = New Globalization.CultureInfo("id-ID", False).TextInfo
			TotTerbilang = textInfo.ToTitleCase(TotTerbilang)
			TotTerbilang = TotTerbilang.Replace("Nol", "")

			Me.ReportViewer1.LocalReport.EnableExternalImages = True

			ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Periode", Periode, True))
			ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("TglPeriode", TglPeriode, True))
			ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Status", Status_, True))
			ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Bagian", Bagian, True))
			ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("PeriodeV2", PeriodeV2, True))
			ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("TotTerbilang", TotTerbilang, True))



			ReportName = ".RptUangMakanPCG.rdlc"
			Ds = "DtUangMakanPCG"
			Dim DSource = New ReportDataSource(Ds, dataTable)

			Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)

			Me.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ReportName
			Me.ReportViewer1.LocalReport.SetParameters(ParamList)
			Me.ReportViewer1.LocalReport.DataSources.Add(DSource)
			Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
			Me.ReportViewer1.RefreshReport()
		Catch ex As Exception
			Me.Cursor = Cursors.Arrow
			MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
		Me.Cursor = Cursors.Arrow
	End Sub
	Function NumberToWords(ByVal number As Integer) As String
		If number = 0 Then
			Return "nol"
		End If

		Dim unitsMap As String() = {"", "satu", "dua", "tiga", "empat", "lima", "enam", "tujuh", "delapan", "sembilan", "sepuluh", "sebelas"}
		Dim text As String = ""

		If number < 12 Then
			text = unitsMap(number)
		ElseIf number < 20 Then
			text = NumberToWords(number Mod 10) & " belas"
		ElseIf number < 100 Then
			text = NumberToWords(number \ 10) & " puluh " & NumberToWords(number Mod 10)
		ElseIf number < 200 Then
			text = "seratus " & NumberToWords(number - 100)
		ElseIf number < 1000 Then
			text = NumberToWords(number \ 100) & " ratus " & NumberToWords(number Mod 100)
		ElseIf number < 2000 Then
			text = "seribu " & NumberToWords(number - 1000)
		ElseIf number < 1000000 Then
			text = NumberToWords(number \ 1000) & " ribu " & NumberToWords(number Mod 1000)
		ElseIf number < 2000000 Then
			text = "satu juta " & NumberToWords(number - 1000000)
		ElseIf number < 1000000000 Then
			text = NumberToWords(number \ 1000000) & " juta " & NumberToWords(number Mod 1000000)
		ElseIf number < 2000000000 Then
			text = "satu miliar " & NumberToWords(number - 1000000000)
		ElseIf number < 1000000000000 Then
			text = NumberToWords(number \ 1000000000) & " miliar " & NumberToWords(number Mod 1000000000)
		ElseIf number < 2000000000000 Then
			text = "satu triliun " & NumberToWords(number - 1000000000000)
		Else
			text = "Angka terlalu besar"
		End If

		Return text.Trim()
	End Function

	Private Sub Button1_Click(sender As Object, e As EventArgs)
		MsgBox(fg.Item(1, 7))
	End Sub
End Class