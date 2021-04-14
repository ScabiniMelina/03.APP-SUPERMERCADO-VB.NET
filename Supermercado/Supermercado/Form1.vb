Imports MySql.Data.MySqlClient
Imports System.Data.SQLite

Public Class Form1

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'ABRIR PAGINA REGISTRAR
        Form2.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'BUSCA SI EL EMAIL Y LA CONTRASEÑA COINSIDEN CON LOS QUE ESTAN EN LA BASE DE DATOS 
        Dim email, contraseña As String
        email = TextBox1.Text
        contraseña = TextBox2.Text
        Dim cadena As String = "select Email,Contraseña from empleados where Email ='" & email & "'and contraseña = '" & contraseña & "'"
        BuscarEmailcontraseñaBd(cadena, Me)
    End Sub

    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click
        'CIERRA APP
        Me.Close()
    End Sub


    Private Sub TextBox_GotFocus(sender As Object, e As EventArgs) Handles TextBox1.GotFocus, TextBox2.GotFocus
        TextBoxGotFocus(sender)
    End Sub
    Private Sub TextBox_LostFocus(sender As Object, e As EventArgs) Handles TextBox1.LostFocus, TextBox2.LostFocus
        TextBoxLostFocus(sender)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.ForeColor = Color.WhiteSmoke
        TextBox2.ForeColor = Color.WhiteSmoke
        TextBox1.Text = "Email"
        TextBox2.Text = "Contraseña"
    End Sub

End Class
