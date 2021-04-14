Imports MySql.Data.MySqlClient
Imports System.Data.SQLite

Public Class Form9

    Private Sub TextBox8_Click(sender As Object, e As EventArgs) Handles TextBox8.Click
        'DESAPAREZCA EL TEXTO AL HACER CLICK NE EL CUADRO DE BUSQUEDA
        TextBox8.Text = ""
    End Sub

    Private Sub Form9_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        'ACHICO  VENTANA
        AnchoVentana(Me, 506)
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        BuscarBd("Buscar cliente por DNI", TextBox8, "SELECT * FROM Clientes WHERE Dni like '" & ("%" + TextBox8.Text + "%") & "'", DataGridView1)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim cadena As String = "DELETE from clientes where Dni'" & Val(TextBox4.Text) & "'"
        'ELIMINAR ELEMENTOS A LA BASE DE DATOS 
        BotonEliminarAgregarModificar(cadena)
        CargarBd("SELECT * FROM clientes", Me, DataGridView1)
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim cadena As String = "UPDATE clientes SET Nombre='" & TextBox6.Text & "',Apellido='" & TextBox7.Text & "',Telefono='" & TextBox5.Text & "' WHERE Dni='" & Val(TextBox4.Text) & "'"
        'EDITAR ELEMENTOS A LA BASE DE DATOS 
        BotonEliminarAgregarModificar(cadena)
        CargarBd("SELECT * FROM Clientes", Me, DataGridView1)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim cadena As String
        Dim Imag As Byte()
        Imag = ImagenABytes(Me.PictureBox1.Image)
        'FALTA CARGAR LA IMAGEN
        cadena = "INSERT INTO clientes (Dni, Nombre,Apellido,Telefono )VALUES('" & TextBox4.Text & "','" & TextBox6.Text & "', '" & TextBox7.Text & "' ,'" & TextBox5.Text & "')"
        BotonEliminarAgregarModificar(cadena)
        CargarBd("SELECT * FROM Clientes", Me, DataGridView1)
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'AGRANDO  VENTANA
        AnchoVentana(Me, 728)
        BotonEditarBorrar(PictureBox1, PictureBox2, PictureBox3)
        'Dim op As String
        If IsNumeric(DataGridView1.CurrentRow.Cells(0).Value) Then
            TextBox4.Text = DataGridView1.CurrentRow.Cells(0).Value
            TextBox6.Text = DataGridView1.CurrentRow.Cells(1).Value
            TextBox7.Text = DataGridView1.CurrentRow.Cells(2).Value
            TextBox5.Text = DataGridView1.CurrentRow.Cells(3).Value

            'If DataGridView1.SelectedCells.Item(5).Value Is DBNull.Value Then
            'PictureBox5.Image = PictureBox5.ErrorImage
            'Else
            'PictureBox5.Image = DataGridView1.SelectedCells.Item(5).FormattedValue
            'End If

        End If
        TextBox4.Visible = True
        TextBox4.Enabled = False
        Label6.Enabled = True
    End Sub


    Private Sub PictureBox14_Click(sender As Object, e As EventArgs) Handles PictureBox14.Click
        'AGRANDO  VENTANA
        AnchoVentana(Me, 728)
        'FORMULARIO SIN DATOS
        TextBox4.Text = ""
        TextBox4.Enabled = True


        TextBox6.Text = ""
        TextBox5.Text = ""
        TextBox7.Text = ""

        'SACAR BOTONES  DE BORRAR Y EDITAR , APARECER EL BOTON DE AGREGAR Y PONERLO EN OTRA UBICACION
        BotonAgregar(PictureBox1, PictureBox2, PictureBox3)

    End Sub

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarBd("SELECT * FROM Clientes", Me, DataGridView1)
    End Sub


End Class