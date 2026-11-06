Imports System.Data.SqlClient

Public Module Modul_Config
	Public StrConnRMPApp As String = "Server=192.168.12.5;Database=RMPApp;User Id=uKoneksi;Password=sm@rt2018;Pooling=false;Connection Timeout=300;"
	Public StrConnTimbangan As String = "Server=192.168.13.28;Database=RSUPAccounting;User Id=UKoneksi;Password=smart@2022;Pooling=false;Connection Timeout=300;"
	Public StrConnPSGRMP As String = "Server=192.168.2.3;Database=PSGRMP;User Id=appkoneksi;Password=app@1psg;Pooling=false;Connection Timeout=300;"
	Public StrConnAccounting As String = "Server=192.168.12.5;Database=RSUPAccounting;User Id=uKoneksi;Password=sm@rt2018;Pooling=false;Connection Timeout=300;"
	Public StrConnDBPancang As String = "Server=192.168.12.5;Database=DBPancang;User Id=uKoneksi;Password=sm@rt2018;Pooling=false;Connection Timeout=600;"
	Public StrConnOneLogin As String = "server=192.168.12.12;Database=RSUPKomputer;User Id=uKoneksi; Password=sm@rt2018;Pooling=false;Connection Timeout=300;"
	Public StrConnP1RMP As String = "server=192.168.3.144;Database=P1RMP;User Id=sapayroll; Password=mispwdpayroll;Pooling=false;Connection Timeout=300;"

	Public RMP_Nota As String = "" '"\\192.168.3.38\mypsg\RMP\Nota\"
	Public baseUrl As String = "http://192.168.12.168:8099/rmp1p2/v1"
	Public baseUrl_lokal As String = "http://localhost:5199/rmp1p2/v1"
	Public url_paraf As String = "file:////192.168.12.11/notapancangapi/App-Paraf/"

	Public UrlApiNotaPancang As String = "http://192.168.12.168:5006/api/file/upload?subfolder=notapancangapi\"
	Public UrlApiNotaPancangNew As String = "http://192.168.12.168:5006/api/file/uploadNEW?subfolder=notapancangapi\"
	Public UrlApiPancang As String = "http://192.168.12.168:5006/api/file/upload?subfolder=Pancang\"
	Public TokenApiNotaPancang As String = "uPzT8Q3wK1XvR5yS7zV0ZbN4oM7lT3mF6gP9rL4eR1sY2oW8uP1zT0Y3oJ6kP8"

	'Public UrlBPIAPI As String = "http://localhost:5080/bpi-api/" ' local
	Public UrlBPIAPI As String = "http://192.168.12.168:8098/bpi-api/"
	Public TokenBPIAPI As String = "D4E8A1F7C3B9D0A6E2F5C8B1A7D4E9F0C6A2B8D5F1E7C3A9B4D0F6A1E8C5B2D7"

	Public UrlNotaPancang As String = "\\192.168.12.11\notapancangapi\"
	Public UrlMasterTTPancnag As String = "\\Rsup2\MasterTT\Pancang\"
	Public urlApiAbsensiPancang As String = "http://192.168.12.168:81/AbsensiPancangAPI/source/image/"

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
