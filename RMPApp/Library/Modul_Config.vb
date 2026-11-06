Imports System.Data.SqlClient

Public Module Modul_Config
	Public StrConnRMPApp As String = "Server=999.999.99.99;Database=RMPApp;User Id=uKoneksi;Password=sm@rt2018;Pooling=false;Connection Timeout=300;"
	Public StrConnTimbangan As String = "Server=999.999.99.99;Database=RSUPAccounting;User Id=UKoneksi;Password=smart@2022;Pooling=false;Connection Timeout=300;"
	Public StrConnPSGRMP As String = "Server=999.999.99.99;Database=PSGRMP;User Id=appkoneksi;Password=app@1psg;Pooling=false;Connection Timeout=300;"
	Public StrConnAccounting As String = "Server=999.999.99.99;Database=RSUPAccounting;User Id=uKoneksi;Password=sm@rt2018;Pooling=false;Connection Timeout=300;"
	Public StrConnDBPancang As String = "Server=999.999.99.99;Database=DBPancang;User Id=uKoneksi;Password=sm@rt2018;Pooling=false;Connection Timeout=600;"
	Public StrConnOneLogin As String = "server=999.999.99.99;Database=RSUPKomputer;User Id=uKoneksi; Password=sm@rt2018;Pooling=false;Connection Timeout=300;"
	Public StrConnP1RMP As String = "server=999.999.99.99;Database=P1RMP;User Id=sapayroll; Password=mispwdpayroll;Pooling=false;Connection Timeout=300;"

	Public RMP_Nota As String = ""
	Public baseUrl As String = ""
	Public baseUrl_lokal As String = ""
	Public url_paraf As String = ""

	Public UrlApiNotaPancang As String = ""
	Public UrlApiNotaPancangNew As String = ""
	Public UrlApiPancang As String = ""
	Public TokenApiNotaPancang As String = ""

	'Public UrlBPIAPI As String = "" ' local
	Public UrlBPIAPI As String = ""
	Public TokenBPIAPI As String = ""

	Public UrlNotaPancang As String = ""
	Public UrlMasterTTPancnag As String = ""
	Public urlApiAbsensiPancang As String = ""

	Public pathBarcode As String = UrlMasterTTPancnag & "QRBarcode2023\Barcode"
	Public pathQRCode As String = UrlMasterTTPancnag & "QRBarcode2023\QRCode"

	Public DS As New DataSet
	Public Periode As Date
	Public RD As SqlDataReader
	Public DS2 As New DataSet
	Public DS3 As New DataSet
	Public CqD As SqlCommand
	Public connp21 As SqlConnection
	Public connp2 As SqlConnection
End Module
