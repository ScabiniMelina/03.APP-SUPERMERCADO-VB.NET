Imports MySql.Data.MySqlClient
Imports System.Data.SQLite
Public Class Form3

    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click
        'CERRAR APP
        Me.Close()
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        abrirForm(Form11)
    End Sub

    Private Sub ButtonMenu_Click(sender As Object, e As EventArgs) Handles MyBase.Load, Button1.Click, Button1.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, PictureBox1.Click
        Me.SetBounds(Me.Location.X, Me.Location.Y, 664, Me.Size.Height)
        PictureBox11.Location = New Point(634, 0)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Module1.categoria = "Todos"
        abrirForm(Form4)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CargarBd("SELECT * FROM ingreso_mercaderia", Form5, Form5.DataGridView1)
        AbrirForm(Form5)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CargarBd("SELECT * FROM factura", Form6, Form6.DataGridView1)
        AbrirForm(Form6)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        CargarBd("SELECT * FROM proveedores", Form7, Form7.DataGridView1)
        AbrirForm(Form7)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        CargarBd("SELECT * FROM empleados", Form8, Form8.DataGridView1)
        AbrirForm(Form8)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        CargarBd("SELECT * FROM Clientes", Form9, Form9.DataGridView1)
        AbrirForm(Form9)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim cadena As String = "select `Codigo`,`Nombre`,`Precio`,`Stock`,`Categoria`,`Marca`,`Unidad` from productos where Stock <= 50 "
        CargarBd(cadena, Form11, Form11.DataGridView1)
        AbrirForm(Form11)
    End Sub

End Class