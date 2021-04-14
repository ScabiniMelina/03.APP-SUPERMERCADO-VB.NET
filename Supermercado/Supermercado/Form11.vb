Imports MySql.Data.MySqlClient
Imports System.Data.SQLite
Public Class Form11


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = DateTime.Now.ToLongDateString().ToUpper
        Label3.Text = DateTime.Now.ToString("hh:mm:ss")
    End Sub

    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Dim cadena As String = "select `Codigo`,`Nombre`,`Precio`,`Stock`,`Categoria`,`Marca`,`Unidad` from productos where Stock <= 50 "
        CargarBd(cadena, Me, DataGridView1)
        AnchoVentana(Me, 506)
    End Sub

End Class