' ============================================================
' Helper obfuscation sederhana untuk CLIENT_SECRET di OneLoginService.vb
'
' ⚠️ PENTING: Ini BUKAN solusi sempurna. Orang yang cukup niat & paham
' .NET decompiler (dnSpy, ILSpy -- gratis, gampang dicari) tetap BISA
' membongkar ini dalam hitungan menit. Ini cuma menaikkan sedikit
' "kesulitan" dari "tinggal buka Notepad" jadi "perlu decompiler +
' ngerti caranya" -- cukup untuk menghalangi orang iseng, TIDAK cukup
' untuk melawan penyerang yang serius menargetkan aplikasi ini.
'
' Mitigasi yang LEBIH PENTING (di luar kode ini):
'   1. Generate ulang client_secret secara BERKALA (misal tiap 3-6 bulan)
'      lewat tombol "Generate Ulang Secret" di OneLogin
'   2. Pantau Audit Log / Login History OneLogin buat aktivitas aneh
'   3. Kalau curiga secret bocor, generate ulang SEGERA
' ============================================================

Module ClsSecretObfuscation

    ' XOR sederhana dengan kunci tetap. Ganti angka key-nya sesuka Anda
    ' (asal sama antara waktu Encode dan Decode).
    Private Const XOR_KEY As Byte = 137

    ''' <summary>
    ''' Pakai ini SEKALI di luar aplikasi (misal lewat LINQPad/Immediate Window)
    ''' buat generate versi ter-obfuscate dari secret asli Anda, lalu HASIL-nya
    ''' (bukan secret aslinya) yang ditaruh di source code.
    ''' </summary>
    Public Function Encode(plainText As String) As String
        Dim bytes = System.Text.Encoding.UTF8.GetBytes(plainText)
        For i As Integer = 0 To bytes.Length - 1
            bytes(i) = bytes(i) Xor XOR_KEY
        Next
        Return Convert.ToBase64String(bytes)
    End Function

    Public Function Decode(obfuscatedText As String) As String
        Dim bytes = Convert.FromBase64String(obfuscatedText)
        For i As Integer = 0 To bytes.Length - 1
            bytes(i) = bytes(i) Xor XOR_KEY
        Next
        Return System.Text.Encoding.UTF8.GetString(bytes)
    End Function

End Module

' ============================================================
' CARA PAKAI di OneLoginService.vb:
'
' 1. Buka Immediate Window Visual Studio (Debug -> Windows -> Immediate),
'    ketik ini (ganti dengan secret asli Anda), Enter:
'
'      ? ClsSecretObfuscation.Encode("secret_asli_dari_onelogin_di_sini")
'
'    Copy hasilnya (contoh: "3RvXn8k...").
'
' 2. Ganti baris CLIENT_SECRET di OneLoginService.vb, dari:
'
'      Private Const CLIENT_SECRET As String = "secret_asli_dari_onelogin_di_sini"
'
'    Jadi:
'
'      Private Shared ReadOnly CLIENT_SECRET As String =
'          ClsSecretObfuscation.Decode("3RvXn8k...")   ' <- hasil dari langkah 1
'
' 3. Compile ulang. Secret aslinya TIDAK ada lagi sebagai teks polos di
'    dalam .exe -- tapi sekali lagi, ini cuma penghalang, bukan proteksi mutlak.
' ============================================================
