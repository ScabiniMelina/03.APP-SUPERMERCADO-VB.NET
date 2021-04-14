Imports MySql.Data.MySqlClient
Imports System.Data.SQLite
Imports System.IO


Module Module1
    Public conexion As New MySqlConnection("Server=localhost; Database=supermercado; Uid=root; Pwd=''")
    Public categoria As String

    'CONTROL DATOS Y APARIENCIA EN EL TEXTBOX
    Sub CaracterSoloLetra(e)
        If Char.IsLetter(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Sub CaracterSoloNumero(e)
        If Char.IsLetter(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Sub TextBoxGotFocus(sender As Object)
        If sender.Text = sender.tag Then
            sender.Text = ""
            sender.ForeColor = Color.Red
        End If
    End Sub
    Sub TextBoxLostFocus(sender As Object)
        If sender.Text = "" Then
            sender.Text = sender.tag
            sender.ForeColor = Color.WhiteSmoke
        End If
    End Sub

    'BD
    Sub CargarBd(cadena As String, formActual As Form, DataGridView1 As DataGridView)

        Try
            formActual.SetBounds(formActual.Location.X, formActual.Location.Y, 506, formActual.Size.Height)
            conexion.Open()
            'cadena = "select * from productos where Codigo like '" & "%" + TextBox1.Text + "%" & ", Nombre like" & "%" + TextBox1.Text + "%" & ", Precio like" & "%" + TextBox1.Text + "%" & ", categoria like" & "%" + TextBox1.Text & "% , Marca like" & "%" + TextBox1.Text + "%" & "'"
            Dim comando As New MySqlDataAdapter(cadena, conexion)
            Dim dt As DataSet
            dt = New DataSet
            comando.Fill(dt)
            DataGridView1.DataSource = dt.Tables(0).DefaultView
            conexion.Close()
        Catch ex As Exception
            conexion.Close()
            MsgBox(ex.Message)
        End Try
    End Sub



    Sub BuscarBd(texto As String, buscador As TextBox, cadena As String, DataGridView1 As DataGridView)


        Try
            If cadena = "Form10" Then
                If Module1.categoria = "Todos" Then
                    cadena = "SELECT Codigo,Nombre,Precio,Stock,Categoria,Marca,Unidad FROM productos"
                Else
                    cadena = "SELECT Codigo,Nombre,Precio,Stock,Categoria,Marca,Unidad FROM productos where Categoria='" & Module1.categoria & "'"
                End If
            End If

            conexion.Open()
            buscador.Text = texto
            Dim comando As New MySqlDataAdapter(cadena, conexion)
            Dim dt As DataSet
            dt = New DataSet
            comando.Fill(dt)
            DataGridView1.DataSource = dt.Tables(0).DefaultView
            conexion.Close()
        Catch ex As Exception
            conexion.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub BuscarEmailcontraseñaBd(cadena As String, formActual As Form)
        Try
            conexion.Open()
            Dim comando As New MySqlDataAdapter(cadena, conexion)
            Dim dt As DataSet
            dt = New DataSet
            comando.Fill(dt)
            If dt.Tables(0).Rows.Count() = 0 Then
                MsgBox("Email contraseña incorrectos")
            Else
                conexion.Close()
                Form3.Show()
                formActual.Close()
            End If
            conexion.Close()
        Catch ex As Exception
            conexion.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub BotonEliminarAgregarModificar(cadena As String)
        Try
            conexion.Open()
            Dim comando As New MySqlCommand(cadena, conexion)
            comando.ExecuteNonQuery()
            conexion.Close()
        Catch ex As Exception
            conexion.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub ComboBoxItems(ComboBox As ComboBox, cadena As String, columnaLeer As String)
        Try
            conexion.Open()
            Dim comando As New MySqlCommand(cadena, conexion)
            Dim dataReader As MySqlDataReader
            dataReader = comando.ExecuteReader
            ComboBox.Items.Clear()
            While dataReader.Read
                ComboBox.Items.Add(dataReader.Item(columnaLeer))
            End While
            dataReader.Close()
            conexion.Close()

        Catch ex As Exception
            conexion.Close()
            MsgBox(ex.Message)
        End Try

    End Sub
    Function TextboxItem(cadena As String, columnaLeer As String) As Integer
        Dim TextBox As Integer
        Try
            conexion.Open()
            Dim comando As New MySqlCommand(cadena, conexion)
            Dim dataReader As MySqlDataReader
            dataReader = comando.ExecuteReader
            While dataReader.Read
                TextBox = dataReader.Item(columnaLeer)
            End While
            dataReader.Close()
            conexion.Close()

        Catch ex As Exception
            conexion.Close()
            MsgBox(ex.Message)
        End Try
        Return TextBox
    End Function


    'ABRIR FORMULARIOS Y TAMÑO DE VENTANAS
    Sub AnchoVentana(formActual As Form, ancho As Integer)
        formActual.SetBounds(formActual.Location.X, formActual.Location.Y, ancho, formActual.Size.Height)
        Form3.SetBounds(Form3.Location.X, Form3.Location.Y, ancho + 158, Form3.Size.Height)
        Form3.PictureBox11.Location = New Point(ancho + 158 - 30, 0)
    End Sub

    Sub AbrirForm(form As Object)
        If Form3.Panel4.Controls.Count > 0 Then
            Form3.Panel4.Controls.RemoveAt(0)
        End If
        Dim formHijo As Form
        formHijo = form
        formHijo.TopLevel = False
        formHijo.Dock = DockStyle.Fill
        Form3.Panel4.Controls.Add(formHijo)
        formHijo.Show()
    End Sub

    'BOTONES
    Sub BotonAgregar(botonAgregar As PictureBox, botonBorrar As PictureBox, botonEditar As PictureBox)
        botonAgregar.Location = New Point(botonBorrar.Location.X, botonBorrar.Location.Y)
        botonAgregar.Enabled = True
        botonAgregar.Visible = True
        botonBorrar.Enabled = False
        botonBorrar.Visible = False
        botonEditar.Enabled = False
        botonEditar.Visible = False
    End Sub

    Sub BotonEditarBorrar(botonAgregar As PictureBox, botonBorrar As PictureBox, botonEditar As PictureBox)
        ' botonBorrar.Location = New Point(358, 454)
        botonBorrar.Enabled = True
        botonBorrar.Visible = True
        botonEditar.Enabled = True
        botonEditar.Visible = True
        botonAgregar.Enabled = False
        botonAgregar.Visible = False
    End Sub




    'IMAGENES

    Function BytesAImagen(ByVal Imagen As Byte()) As Image
        Try
            'si hay imagen
            If Not Imagen Is Nothing Then
                'caturar array con memorystream hacia Bin
                Dim Bin As New MemoryStream(Imagen)
                'con el método FroStream de Image obtenemos imagen
                Dim Resultado As Image = Image.FromStream(Bin)
                'y la retornamos
                Return Resultado
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    'convertir imagen a binario
    Function ImagenABytes(ByVal Imagen As Image) As Byte()
        'si hay imagen
        If Not Imagen Is Nothing Then
            'variable de datos binarios en stream(flujo)
            Dim Bin As New MemoryStream
            'convertir a bytes
            Imagen.Save(Bin, Imaging.ImageFormat.Jpeg)
            'retorna binario
            Return Bin.GetBuffer
        Else
            Return Nothing
        End If
    End Function





End Module

