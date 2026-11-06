Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Web.UI.WebControls
Imports C1.Win
Imports C1.Win.C1FlexGrid
Imports Dapper

Public Class FrmLaporanMuatKelapa
    Dim cls As New ClsDatabaseConnection

    Private Sub FrmLaporanMuatKelapa_Load(sender As Object, e As EventArgs) Handles Me.Load
        Modul_RMP.Combo.SetPancang_(cboPCG)
        Modul_RMP.Combo.SetKapal(cboKapal)
        Dim connetionString As String
        dtp1.Value = Format(Now, "yyyy-MM-dd")
        dtp1.Enabled = False
        dtp2.Value = Format(Now, "yyyy-MM-dd")
        dtp2.Enabled = False
        cboPCG.Enabled = False
        cboKapal.Enabled = False
        cboPCG.Text = ""
        cboKapal.Text = ""
    End Sub

    Private Sub chkTgl_CheckedChanged(sender As Object, e As EventArgs) Handles chkTgl.CheckedChanged
        If chkTgl.Checked = True Then
            dtp1.Enabled = True
            dtp2.Enabled = True
        Else
            dtp1.Enabled = False
            dtp2.Enabled = False
            dtp1.Value = Format(Now, "yyyy-MM-dd")
            dtp1.Value = Format(Now, "yyyy-MM-dd")
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If chkTgl.Checked = False Then
            MsgBox("Silahkan Pilih Periode !", MsgBoxStyle.Exclamation, AT)
            Exit Sub
        End If
        fetchData_Dinamis()
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim filename As String
        Me.SaveFileDialog.ShowDialog()
        filename = SaveFileDialog.FileName
        Me.fg1.SaveExcel(filename & ".xls", "Sheet1", FileFlags.IncludeFixedCells)
        MsgBox("Convert Success !", MsgBoxStyle.Information, AT)
    End Sub

    'Private Sub dtp1_ValueChanged(sender As Object, e As EventArgs) Handles dtp1.ValueChanged
    '    fg1.Rows.Count = 2
    'End Sub

    Private Sub cboPCG_KeyUp(sender As Object, e As KeyEventArgs) Handles cboPCG.KeyUp
        UI.AutoCompleteCombo_KeyUp(cboPCG, e)
    End Sub

    Private Sub cboKapal_KeyUp(sender As Object, e As KeyEventArgs) Handles cboKapal.KeyUp
        UI.AutoCompleteCombo_KeyUp(cboKapal, e)
    End Sub

    Private Sub chkPancang_CheckedChanged(sender As Object, e As EventArgs) Handles chkPancang.CheckedChanged
        If chkPancang.Checked = True Then
            cboPCG.Enabled = True
        Else
            cboPCG.Enabled = False
            cboPCG.Text = ""
        End If
    End Sub

    Private Sub chkKapal_CheckedChanged(sender As Object, e As EventArgs) Handles chkKapal.CheckedChanged
        If chkKapal.Checked = True Then
            cboKapal.Enabled = True
        Else
            cboKapal.Enabled = False
            cboKapal.Text = ""
        End If
    End Sub

    Private Sub fetchData_Dinamis()
        Dim connection As SqlConnection
        Dim adapter As SqlDataAdapter
        connection = New SqlConnection("server=192.168.12.5; database=RMPAPP; user=UKoneksi; password=sm@rt2018;  MultipleActiveResultSets=True; connect timeout=300;Max Pool Size=500000  ;")
        Dim selectedDate As String = Format(dtp1.Value, "yyyy-MM")
        Dim endDate As String = Format(dtp2.Value, "yyyy-MM")
        Console.WriteLine(selectedDate)
        Dim pancang As String = cboPCG.Text
        Dim namaKapal As String = cboKapal.Text

        Call UI.HapusGrid(1, fg1)
        fg1.Clear()
        fg1.Row = 0
        fg1.Col = 0
        fg1.DataSource = Nothing
        fg1.Clear(C1.Win.C1FlexGrid.ClearFlags.Content)

        DS.Clear()
        DS.Tables.Clear()
        DS.Tables.Clear()

        With fg1
            .AutoSizeCols()
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)
            .AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free
            .Cols.Frozen = 2
            .AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free
            .Cols(3).AllowMerging = True
            .Cols(5).AllowMerging = True
        End With

        ' SQL Dinamis untuk menghasilkan kolom pivot berdasarkan jumlah hari
        Dim sqlDynamic As String = "
  DECLARE @MaxHariLamaMuat INT;
  DECLARE @ColumnList NVARCHAR(MAX);

  -- Identifikasi Hari Maksimum Muat
  SELECT @MaxHariLamaMuat = MAX(HariLamaMuat)
  FROM (
      SELECT DATEDIFF(DAY, MIN(TransDate), MAX(TransDate)) AS HariLamaMuat
      FROM vwLaporanPancangNew
      WHERE CONVERT(VARCHAR(7), TransDate, 126) Between @selectedDate AND @endDate"

        ' Tambahkan kondisi secara dinamis berdasarkan input
        If Not String.IsNullOrEmpty(pancang) Then
            sqlDynamic &= " AND Pancang = @pancang"
        End If
        If Not String.IsNullOrEmpty(namaKapal) Then
            sqlDynamic &= " AND NamaKapal = @namaKapal"
        End If

        sqlDynamic &= "
      GROUP BY NamaKapal, Pancang, Trip
  ) AS Temp;

  -- Buat Daftar Kolom Berdasarkan @MaxHariLamaMuat
  SET @ColumnList = '';
  DECLARE @i INT = 1;
  WHILE @i <= @MaxHariLamaMuat + 1
  BEGIN
      SET @ColumnList = @ColumnList + ', [HARI ' + CAST(@i AS VARCHAR) + ']';
      SET @i = @i + 1;
  END;
  SET @ColumnList = STUFF(@ColumnList, 1, 2, '');

  -- Membuat string untuk perhitungan TotalMuatanReal
  DECLARE @TotalCalculation NVARCHAR(MAX) = '';
	SET @i = 1;
	WHILE @i <= @MaxHariLamaMuat + 1
	BEGIN
  SET @TotalCalculation = @TotalCalculation + ' + COALESCE([HARI ' + CAST(@i AS VARCHAR) + '], 0)';
  SET @i = @i + 1;
	END;
	SET @TotalCalculation = STUFF(@TotalCalculation, 1, 3, '');

  DECLARE @SQL NVARCHAR(MAX);
  SET @SQL = ';
  WITH CTE AS (
      SELECT
        A.Trip,
        MIN(A.TransDate) AS Tanggal,
        A.Pancang,
        A.NamaKapal,
        A.Kapasitas,
        CAST(B.ChekinDate AS DATE) AS TglMasukPancang,
        DATEDIFF(DAY, CAST(B.ChekinDate AS DATE), CAST(B.MuatDate AS DATE)) AS LamaAntriDay,
        DATEDIFF(HOUR, CAST(B.ChekinDate AS DATE), CAST(B.MuatDate AS DATE)) % 24 AS LamaAntriHour,
        MIN(A.TransDate) AS MulaiMuat,
        MIN(A.StartTimbang) AS AwalTimbang,
        MAX(A.EndTimbang) AS TglSelesaiMuat,
        DATEDIFF(DAY, MIN(A.StartTimbang), MAX(A.EndTimbang)) AS HariLamaMuat,
        DATEDIFF(HOUR, MIN(A.StartTimbang), MAX(A.EndTimbang)) % 24 AS JamLamaMuat,
        CASE WHEN MAX(A.FlagPenuhDate) IS NOT NULL OR MAX(A.tglmasukKapal) IS NOT NULL THEN 1 ELSE 0 END AS SudahPenuh,
        CAST(MAX(A.tglmasukKapal) AS SMALLDATETIME) AS TglMasukKapal,
        (CAST(DATEDIFF(DAY, MIN(A.StartTimbang), MAX(A.EndTimbang)) AS VARCHAR) + '' Hari '' + 
        CAST(DATEDIFF(HOUR, MIN(A.StartTimbang), MAX(A.EndTimbang)) % 24 AS VARCHAR) + '' Jam'') AS LamaMuat,
        (CAST(DATEDIFF(DAY, CAST(B.ChekinDate AS DATE), CAST(B.MuatDate AS DATE)) AS VARCHAR) + '' Hari '' + 
        CAST(DATEDIFF(HOUR, CAST(B.ChekinDate AS DATE), CAST(B.MuatDate AS DATE)) % 24 AS VARCHAR) + '' Jam'') AS LamaAntri,
        CAST(MAX(B.BerangkatDate) AS SMALLDATETIME) AS TglDariPancang,
        (CAST(DATEDIFF(DAY, CAST(B.ChekinDate AS DATE), CAST(B.BerangkatDate AS DATE)) AS VARCHAR) + '' Hari '' + 
        CAST(DATEDIFF(HOUR, CAST(B.ChekinDate AS DATE), CAST(B.BerangkatDate AS DATE)) % 24 AS VARCHAR) + '' Jam'') AS LamaPerjalanan
    FROM
        vwLaporanPancangNew AS A WITH (NOLOCK)
        LEFT JOIN Android_tblBookingKapalMuat AS B
            ON A.IDKapal = B.IDKapal
            AND A.IDPancang = B.IDPancang
            AND A.Trip = B.TripID
      WHERE
          CONVERT(VARCHAR(7), A.TransDate, 126) BETWEEN ''" & selectedDate & "'' AND ''" & endDate & "''"  ' Tambahkan tanda petik untuk tanggal

        ' Tambahkan kondisi secara dinamis berdasarkan input
        If Not String.IsNullOrEmpty(pancang) Then
            sqlDynamic &= " AND A.Pancang = ''" & pancang & "''" ' Pastikan penggunaan tanda petik ganda
        End If
        If Not String.IsNullOrEmpty(namaKapal) Then
            sqlDynamic &= " AND A.NamaKapal = ''" & namaKapal & "''" ' Pastikan penggunaan tanda petik ganda
        End If

        sqlDynamic &= "
     GROUP BY
        A.NamaKapal, A.Pancang, A.Trip, A.Kapasitas, B.ChekinDate, B.MuatDate, B.BerangkatDate
  ),
  DailyNetto AS (
    SELECT
        CTE.Trip,
        CTE.Tanggal,
        CTE.Pancang,
        CTE.NamaKapal,
        CTE.Kapasitas,
        CTE.TglMasukPancang,
        CTE.LamaAntriDay,
        CTE.LamaAntriHour,
        CTE.MulaiMuat,
        CTE.SudahPenuh,
        CTE.TglSelesaiMuat,
        CTE.HariLamaMuat,
        CTE.JamLamaMuat,
        CTE.TglDariPancang,
        CTE.TglMasukKapal,
        CTE.LamaMuat,
        CTE.LamaAntri,
        CTE.LamaPerjalanan,
        ''HARI '' + CAST(DATEDIFF(DAY, CTE.Tanggal, lpn.TransDate) + 1 AS VARCHAR) AS HariKe,
        SUM(lpn.NettoAkhir) AS NettoAkhir
    FROM
        CTE
        INNER JOIN vwLaporanPancangNew lpn 
            ON CTE.NamaKapal = lpn.NamaKapal 
            AND CTE.Pancang = lpn.Pancang 
            AND CTE.Trip = lpn.Trip 
              AND CONVERT(VARCHAR(7), lpn.TransDate, 126) BETWEEN ''" & selectedDate & "'' AND ''" & endDate & "''"

        ' Tambahkan kondisi filter berdasarkan input
        If Not String.IsNullOrEmpty(pancang) Then
            sqlDynamic &= " AND lpn.Pancang = ''" & pancang & "''"
        End If
        If Not String.IsNullOrEmpty(namaKapal) Then
            sqlDynamic &= " AND lpn.NamaKapal = ''" & namaKapal & "''"
        End If

        sqlDynamic &= "
      GROUP BY
        CTE.NamaKapal, CTE.Kapasitas, CTE.Tanggal, CTE.MulaiMuat, CTE.TglSelesaiMuat, CTE.TglMasukKapal, CTE.Pancang, CTE.SudahPenuh, CTE.Trip, 
        CTE.HariLamaMuat, CTE.JamLamaMuat, CTE.LamaPerjalanan,
        CTE.LamaAntriDay, CTE.LamaAntriHour, CTE.TglMasukPancang, CTE.TglDariPancang, CTE.LamaMuat, CTE.LamaAntri,
        DATEDIFF(DAY, CTE.Tanggal, lpn.TransDate)
  )
      SELECT 
          Tanggal AS [TANGGAL],
          Pancang AS [PANCANG],
          NamaKapal AS [NAMA KAPAL],
          Kapasitas AS [KAPASITAS],
          TglMasukPancang AS [TGL MASUK ANTRI],
          LamaAntri AS [LAMA ANTRI],
          MulaiMuat AS [TGL MULAI],
          Trip AS [TRIP],
          --LamaAntriDay,
          --LamaAntriHour,
          ' + @ColumnList + ',
          (' + @TotalCalculation + ') AS [TOTAL MUATAN REAL],
          TglSelesaiMuat AS [TGL SELESAI MUAT],
          LamaMuat AS [LAMA MUAT],
          TglDariPancang AS [TGL & JAM BERANGKAT DARI PCG],
          TglMasukKapal AS [TGL & JAM TIBA DI P2],
          LamaPerjalanan AS [LAMA PERJALANAN]
          --CAST(HariLamaMuat AS VARCHAR) AS HariLamaMuat,
          --CAST(JamLamaMuat AS VARCHAR) AS JamLamaMuat,
          --SudahPenuh,
      FROM 
          DailyNetto
      PIVOT (
          SUM(NettoAkhir)
          FOR HariKe IN (' + @ColumnList + ')
      ) AS PivotTable
      ORDER BY 
          Tanggal, Pancang ASC';
      EXEC sp_executesql @SQL;"
        Try
            connection.Open()
            adapter = New SqlDataAdapter(sqlDynamic, connection)
            adapter.SelectCommand.CommandTimeout = 120 ' Set to 120 seconds or more as needed
            adapter.SelectCommand.Parameters.AddWithValue("@selectedDate", selectedDate)
            adapter.SelectCommand.Parameters.AddWithValue("@endDate", endDate)

            If Not String.IsNullOrEmpty(pancang) Then
                adapter.SelectCommand.Parameters.AddWithValue("@pancang", pancang)
            End If

            If Not String.IsNullOrEmpty(namaKapal) Then
                adapter.SelectCommand.Parameters.AddWithValue("@namaKapal", namaKapal)
            End If

            ' Fill dataset with results and bind it to the FlexGrid
            adapter.Fill(DS)
            connection.Close()

            ' Bind the first table in dataset to FlexGrid
            If DS.Tables.Count > 0 Then
                fg1.DataSource = DS.Tables(0)

                ' Tambahkan kolom pertama sebagai kolom nomor urut (kolom Nol)
                With fg1
                    .Cols(0).Caption = "No" ' Menetapkan judul kolom sebagai "No"
                    .Cols(0).Width = 50 ' Mengatur lebar kolom No
                    .AllowEditing = False ' Menonaktifkan pengeditan untuk semua sel
                    For col As Integer = 0 To .Cols.Count - 1
                        .Cols(col).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter

                        If .Cols(col).Caption.Contains("HARI ") Then
                            ' Format angka menjadi ribuan (misalnya 1000 menjadi 1,000)
                            For row As Integer = 1 To .Rows.Count - 1
                                .Cols(col).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter
                                .Cols(col).Format = "#,###0"
                            Next
                        End If

                        If .Cols(col).Caption.Contains("TOTAL ") Then
                            ' Format angka menjadi ribuan (misalnya 1000 menjadi 1,000)
                            For row As Integer = 1 To .Rows.Count - 1
                                .Cols(col).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter
                                .Cols(col).Format = "#,###0"
                            Next
                        End If
                    Next
                    .AutoSizeCols()
                End With

                ' Isi nomor urut untuk setiap baris
                For i As Integer = 1 To fg1.Rows.Count - 1
                    fg1(i, 0) = i ' Mengisi nomor urut di kolom pertama
                Next
            Else
                MessageBox.Show("No data found for the specified criteria.", "Data Fetch", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As SqlException
            MessageBox.Show("SQL Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub
End Class