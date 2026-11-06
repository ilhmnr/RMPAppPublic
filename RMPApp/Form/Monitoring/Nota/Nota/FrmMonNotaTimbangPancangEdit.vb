Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class FrmMonNotaTimbangPancangEdit
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If cboRekening.Text = "" Then
            MsgBoxCustom.Show("Rekening harus diisi", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            cboRekening.Focus()
            Exit Sub
        End If

        If cboJenis.Text = "" Then
            MsgBoxCustom.Show("Jenis harus diisi", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            cboJenis.Focus()
            Exit Sub
        End If

        If cboJenisKB.Text = "" Then
            MsgBoxCustom.Show("Jenis KB harus diisi", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            cboJenisKB.Focus()
            Exit Sub
        End If

        If txtHarga.Text = "0" Then
            MsgBoxCustom.Show("Harga harus diisi", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            txtHarga.Focus()
            Exit Sub
        End If

        If Replace(txtRemark.Text, " ", "") = "" Then
            MsgBoxCustom.Show("Remark harus diisi", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            txtRemark.Focus()
            Exit Sub
        End If

        Using conn As New SqlConnection(StrConnRMPApp)

            conn.Open()

            Using trans As SqlTransaction = conn.BeginTransaction()

                Try

                    Using cmd As New SqlCommand("dbo.spMonNotaTimbangPancang", conn, trans)

                        cmd.CommandType = CommandType.StoredProcedure

                        cmd.Parameters.Add("@TransID", SqlDbType.BigInt).Value = txtTransID.Text
                        cmd.Parameters.Add("@TanggalNota", SqlDbType.Date).Value = Format(dtpTglNota.Value, "yyyy-MM-dd")
                        cmd.Parameters.Add("@IDRelasi", SqlDbType.VarChar, 30).Value = txtKodeSupRelasi.Text
                        cmd.Parameters.Add("@NoRekening", SqlDbType.VarChar, 30).Value = cboRekening.SelectedValue.ToString
                        cmd.Parameters.Add("@IDSubPetani", SqlDbType.VarChar, 30).Value = txtKodeSupPetani.Text
                        cmd.Parameters.Add("@Jenis", SqlDbType.VarChar, 50).Value = cboJenis.Text
                        cmd.Parameters.Add("@JenisKB", SqlDbType.VarChar, 30).Value = cboJenisKB.Text
                        cmd.Parameters.Add("@NotaVia", SqlDbType.Int).Value = IIf(rdLaut.Checked, 1, 2)
                        cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = txtRemark.Text
                        cmd.Parameters.Add("@TaraPersen", SqlDbType.Int).Value = txtTaraPersen.Text
                        cmd.Parameters.Add("@TaraPotong", SqlDbType.BigInt).Value = Replace(txtTaraPotong.Text, ".", "")
                        cmd.Parameters.Add("@Neto2", SqlDbType.BigInt).Value = Replace(txtNeto2.Text, ".", "")
                        cmd.Parameters.Add("@Harga", SqlDbType.Int).Value = Replace(txtHarga.Text, ".", "")
                        cmd.Parameters.Add("@TotalHarga", SqlDbType.BigInt).Value = Replace(txtTotalHarga.Text, ".", "")
                        cmd.Parameters.Add("@HargaSubsidiKarung", SqlDbType.BigInt).Value = Replace(txtHargaSubsidiKarung.Text, ".", "")
                        cmd.Parameters.Add("@JumlahKarung", SqlDbType.BigInt).Value = Replace(txtJumlahKarung.Text, ".", "")
                        cmd.Parameters.Add("@UpdatedBy", SqlDbType.VarChar).Value = ClsSession.UserID
                        Dim pFlag As SqlParameter = cmd.Parameters.Add("@Flag", SqlDbType.Int)
                        pFlag.Direction = ParameterDirection.Output
                        pFlag.Value = 0

                        cmd.ExecuteNonQuery()

                        Dim flag As Integer = 0

                        If Not IsDBNull(pFlag.Value) Then
                            flag = Convert.ToInt32(pFlag.Value)
                        End If

                        If flag <> 1 Then
                            trans.Rollback()
                            MsgBoxCustom.Show("Proses gagal diproses.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                            Exit Sub
                        End If

                        trans.Commit()

                        MsgBoxCustom.Show("Data berhasil disimpan.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)

                        FrmMonNotaTimbangPancang.btnRefresh.PerformClick()

                        Me.Close()

                    End Using

                Catch ex As Exception

                    If trans.Connection IsNot Nothing Then
                        trans.Rollback()
                    End If

                    MsgBoxCustom.Show(ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)

                End Try

            End Using

        End Using
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub FrmMonNotaTimbangPancangEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetNumberOnly(txtTaraPersen)
        SetNumberOnly(txtHarga)
        SetNumberOnly(txtJumlahKarung)
        SetNumberOnly(txtHargaSubsidiKarung)

        Combo.SetJenis(cboJenis)
        Combo.SetJenisKB(cboJenisKB)

        Call LoadData()
    End Sub

    Private Sub LoadData()
        Dim dt As DataTable = New DataTable
        dt = DB.ExecuteQuery(StrConnRMPApp, "select * from TblTrnKelapaHdr where TransID='" & txtTransID.Text & "'")

        txtNoNota.Text = dt.Rows(0).Item("NoNota").ToString
        dtpTglNota.Value = Convert.ToDateTime(dt.Rows(0).Item("TanggalNota"))
        txtKodeSupRelasi.Text = dt.Rows(0).Item("IDRelasi").ToString
        txtNamaSupRelasi.Text = dt.Rows(0).Item("NamaRelasi").ToString
        cboRekening.SelectedValue = dt.Rows(0).Item("RekeningPenerima").ToString
        txtKodeSupPetani.Text = dt.Rows(0).Item("IDSubPetani").ToString
        txtNamaSupPetani.Text = dt.Rows(0).Item("SubPetani").ToString
        cboJenis.Text = dt.Rows(0).Item("Jenis").ToString
        cboJenisKB.Text = dt.Rows(0).Item("JenisKB").ToString
        If dt.Rows(0).Item("NotaVia") = 1 Then
            rdLaut.Checked = True
        Else
            rdDarat.Checked = True
        End If
        txtNeto1.Text = Format(dt.Rows(0).Item("Netto"), "#,##0")
        txtTaraPersen.Text = CInt(dt.Rows(0).Item("TarraPersen"))
        txtTaraPotong.Text = Format(dt.Rows(0).Item("TarraKg"), "#,##0")
        txtNeto2.Text = Format(dt.Rows(0).Item("NettoAkhir"), "#,##0")
        txtHargaAwal.Text = Format(dt.Rows(0).Item("HargaSil"), "#,##0")
        txtHarga.Text = Format(dt.Rows(0).Item("Harga"), "#,##0")
        txtTotalHarga.Text = Format(dt.Rows(0).Item("TotalHarga"), "#,##0")
        txtRemark.Text = dt.Rows(0).Item("Remark").ToString
        txtJumlahKarung.Text = Format(dt.Rows(0).Item("JumlahKarung"), "#,##0")
        txtHargaSubsidiKarung.Text = Format(dt.Rows(0).Item("HargaSubsidiKarung"), "#,##0")
        txtTotalHargaSubsidiKarung.Text = CInt(txtJumlahKarung.Text) * CInt(txtHargaSubsidiKarung.Text)
    End Sub

    Private Sub btnFindRelasi_Click(sender As Object, e As EventArgs) Handles btnFindRelasi.Click
        Using frm As New FrmDlgSupplier()

            If frm.ShowDialog(Me) = DialogResult.OK Then
                txtKodeSupRelasi.Text = frm.KodeSup
                txtNamaSupRelasi.Text = frm.NamaSup
            End If

        End Using
    End Sub

    Private Sub btnFindPetani_Click(sender As Object, e As EventArgs) Handles btnFindPetani.Click
        Using frm As New FrmDlgSupplier()

            If frm.ShowDialog(Me) = DialogResult.OK Then
                txtKodeSupPetani.Text = frm.KodeSup
                txtNamaSupPetani.Text = frm.NamaSup
            End If

        End Using
    End Sub

    Private Sub cboJenis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboJenis.SelectedIndexChanged
        txtHarga.Text = 0
        Kalkulasi()
    End Sub

    Private Sub cboJenisKB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboJenisKB.SelectedIndexChanged
        txtHarga.Text = 0
        Kalkulasi()
    End Sub

    Private Sub rdDarat_CheckedChanged(sender As Object, e As EventArgs) Handles rdDarat.CheckedChanged, rdLaut.CheckedChanged
        txtHarga.Text = 0
        Kalkulasi()
    End Sub

    Private Sub txtTaraPersen_TextChanged(sender As Object, e As EventArgs) Handles txtTaraPersen.TextChanged, txtJumlahKarung.TextChanged, txtHargaSubsidiKarung.TextChanged
        Kalkulasi()
    End Sub

    Private Sub txtHarga_TextChanged(sender As Object, e As EventArgs) Handles txtHarga.TextChanged
        Kalkulasi()
    End Sub

    Private Sub Kalkulasi()
        Try
            txtRemark.Clear()
            txtTaraPotong.Text = Format(Math.Round(CDec(txtNeto1.Text) * CDec(txtTaraPersen.Text) / 100, 0, MidpointRounding.AwayFromZero), "#,##0")
            txtNeto2.Text = Format(txtNeto1.Text - txtTaraPotong.Text, "#,##0")
            txtTotalHarga.Text = Format(txtNeto2.Text * IIf(txtHarga.Text = "", 0, CDec(txtHarga.Text)), "#,##0")

            txtTotalHargaSubsidiKarung.Text = Format(txtJumlahKarung.Text * IIf(txtHargaSubsidiKarung.Text = "", 0, CDec(txtHargaSubsidiKarung.Text)), "#,##0")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtKodeSupRelasi_TextChanged(sender As Object, e As EventArgs) Handles txtKodeSupRelasi.TextChanged
        If txtKodeSupRelasi.Text <> "" Then

            cboRekening.DataSource = Nothing

            Dim dt As DataTable = New DataTable()
            dt = Modul_RMP.DB.ExecuteQuery(StrConnAccounting, "SELECT NoRekening as ValueMember, (NoRekening + ' | ' + NamaRekening + ' | ' + JenisBank + ' | ' + IDPetani) AS DisplayMember FROM TblRMMstRekRM WHERE IDPetani='" & txtKodeSupRelasi.Text & "' and ID_Jenis_Rek=1 and Approval = '2' AND isnull(InActive,0)=0 ORDER BY NamaRekening")

            With cboRekening
                .DataSource = dt
                .DisplayMember = "DisplayMember"
                .ValueMember = "ValueMember"
                .SelectedIndex = 0
            End With

        End If
    End Sub
End Class