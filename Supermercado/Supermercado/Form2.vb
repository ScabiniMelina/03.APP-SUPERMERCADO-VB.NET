Imports MySql.Data.MySqlClient
Imports System.Data.SQLite

Public Class Form2
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'AL CERRAR LA PAG INICIANDO SESION HAGO QUE TODOS LOS TEXTBOX SE INICIALICEN CON EL COLOR BLANCO HUMO

        For Each text As TextBox In Me.Controls.OfType(Of TextBox)
            text.ForeColor = Color.WhiteSmoke
            text.Text = text.Tag
        Next
        RadioButton1.Checked = True
        ComboBox1.SelectedIndex = 0
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim validacion As Boolean = True
        If Not TextBox1.Text.Length = 8 Then
            validacion = False
            MsgBox("El DNI no tiene 8 caracteres")
        End If

        If Not TextBox2.Text.Length >= 1 Or TextBox2.Text = "Nombre" Then
            validacion = False
            MsgBox("NOMBRE invalido")
        End If

        If Not TextBox3.Text.Length >= 1 Or TextBox3.Text = "Apellido" Then
            validacion = False
            MsgBox("APELLIDO invalido")
        End If

        If Not TextBox4.Text.Length >= 3 Or TextBox4.Text = "Domicilio" Then
            validacion = False
            MsgBox("DOMICILIO invalido")
        End If

        If Not TextBox5.Text.Length = 10 Or TextBox5.Text = "Teléfono" Then
            validacion = False
            MsgBox("TELEFONO invalido")
        End If

        If Not TextBox6.Text.Length >= 6 Or TextBox6.Text = "Contraseña" Then
            validacion = False
            MsgBox("CONTRASEÑA invalido")
        End If

        If Not TextBox7.Text.Length >= 9 Or Not TextBox7.Text.Contains("@") Or Not TextBox7.Text.Contains(".com") Then
            validacion = False
            MsgBox("EMAIL invalido")
        End If

        If validacion = True Then
            Dim op As String
            If RadioButton1.Checked = True Then
                op = RadioButton1.Text
            ElseIf RadioButton2.Checked = True Then
                op = RadioButton2.Text
            Else
                op = RadioButton3.Text
            End If
            Dim cadena As String = "insert into empleados(Dni, Nombre,Apellido,Nacimiento,Domicilio,Sexo,Telefono,Cargo,Fecha_contratacion,Email,Contraseña) values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "','" & TextBox4.Text & "','" & op & "','" & TextBox5.Text & "','" & ComboBox1.Text & "','" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "','" & TextBox7.Text & "','" & TextBox6.Text & "')"
            BotonEliminarAgregarModificar(cadena)
            For Each text As TextBox In Me.Controls.OfType(Of TextBox)
                text.ForeColor = Color.WhiteSmoke
                text.Text = text.Tag
            Next
            RadioButton1.Checked = True
            ComboBox1.SelectedIndex = 0
            Form1.Show()
            Me.Close()

        Else
            MsgBox("Datos invalidos")
        End If

    End Sub


    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress, TextBox5.KeyPress
        ''NO SE PONEN LETRAS NI CARACTERES ESPECIALES EN EL  DNI, TELEFONO
        CaracterSoloNumero(e)
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress, TextBox3.KeyPress
        'NOMBRE APELLIDO
        CaracterSoloLetra(e)
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        'DIRECCION
        If Char.IsSymbol(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
        'EMAIL
        If Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox_GotFocus(sender As Object, e As EventArgs) Handles TextBox1.GotFocus, TextBox2.GotFocus, TextBox3.GotFocus, TextBox4.GotFocus, TextBox5.GotFocus, TextBox6.GotFocus, TextBox7.GotFocus
        TextBoxGotFocus(sender)
    End Sub
    Private Sub TextBox_LostFocus(sender As Object, e As EventArgs) Handles TextBox1.LostFocus, TextBox2.LostFocus, TextBox3.LostFocus, TextBox4.LostFocus, TextBox5.LostFocus, TextBox6.LostFocus, TextBox7.LostFocus
        TextBoxLostFocus(sender)
    End Sub

    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click
        Me.Close()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = "Dni"
        TextBox1.ForeColor = Color.WhiteSmoke
        TextBox2.Text = "Nombre"
        TextBox2.ForeColor = Color.WhiteSmoke
        TextBox3.Text = "Apellido"
        TextBox3.ForeColor = Color.WhiteSmoke
        TextBox4.Text = "Domicilio"
        TextBox4.ForeColor = Color.WhiteSmoke
        TextBox5.Text = "Teléfono"
        TextBox5.ForeColor = Color.WhiteSmoke
        TextBox6.Text = "Contraseña"
        TextBox6.ForeColor = Color.WhiteSmoke
        TextBox7.Text = "Email"
        TextBox7.ForeColor = Color.WhiteSmoke
    End Sub

End Class