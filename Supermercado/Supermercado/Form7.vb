Imports MySql.Data.MySqlClient
Imports System.Data.SQLite
Public Class Form7

    Private Sub TextBox4_Click(sender As Object, e As EventArgs) Handles TextBox4.Click
        'DESAPAREZCA EL TEXTO AL HACER CLICK NE EL CUADRO DE BUSQUEDA
        TextBox4.Text = ""
    End Sub

    Private Sub Form7_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        'ACHICO  VENTANA
        AnchoVentana(Me, 506)
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        BuscarBd("Buscar proveedor por ID", TextBox4, "SELECT * FROM proveedores WHERE ID like '" & ("%" + TextBox4.Text + "%") & "'", DataGridView1)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim cadena As String = "DELETE FROM proveedores WHERE ID='" & Val(TextBox6.Text) & "'"
        'ELIMINAR ELEMENTOS A LA BASE DE DATOS 
        BotonEliminarAgregarModificar(cadena)
        CargarBd("SELECT * FROM proveedores", Me, DataGridView1)
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim cadena As String = "UPDATE proveedores SET Nombre='" & TextBox5.Text & "',Direccion='" & TextBox7.Text & "',Telefono='" & TextBox8.Text & "' where ID='" & Val(TextBox6.Text) & "'"
        'EDITAR ELEMENTOS A LA BASE DE DATOS 
        BotonEliminarAgregarModificar(cadena)
        CargarBd("SELECT * FROM proveedores", Me, DataGridView1)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim cadena As String
        Dim Imag As Byte()
        Imag = ImagenABytes(Me.PictureBox1.Image)
        'FALTA CARGAR LA IMAGEN
        cadena = "INSERT INTO proveedores (ID,Nombre,Direccion,Telefono)VALUES('" & TextBox6.Text & "','" & TextBox5.Text & "', '" & TextBox7.Text & "' ,'" & TextBox8.Text & "')"
        BotonEliminarAgregarModificar(cadena)
        CargarBd("SELECT * FROM proveedores", Me, DataGridView1)
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'AGRANDO  VENTANA
        AnchoVentana(Me, 742)
        BotonEditarBorrar(PictureBox1, PictureBox2, PictureBox3)
        'Dim op As String
        If IsNumeric(DataGridView1.CurrentRow.Cells(0).Value) Then
            TextBox6.Text = DataGridView1.CurrentRow.Cells(0).Value
            TextBox5.Text = DataGridView1.CurrentRow.Cells(1).Value
            TextBox7.Text = DataGridView1.CurrentRow.Cells(2).Value
            TextBox8.Text = DataGridView1.CurrentRow.Cells(3).Value

            'If DataGridView1.SelectedCells.Item(5).Value Is DBNull.Value Then
            'PictureBox5.Image = PictureBox5.ErrorImage
            'Else
            'PictureBox5.Image = DataGridView1.SelectedCells.Item(5).FormattedValue
            'End If

        End If

        TextBox6.Enabled = False
        TextBox6.Visible = True
        Label1.Enabled = True
        Label1.Visible = True
        PictureBox13.Enabled = True
        PictureBox13.Visible = True
        Panel3.Visible = True

    End Sub
    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        'AGRANDO  VENTANA
        AnchoVentana(Me, 742)
        'FORMULARIO SIN DATOS

        TextBox6.Enabled = False
        TextBox6.Visible = False
        Label1.Enabled = False
        Label1.Visible = False
        PictureBox13.Enabled = False
        PictureBox13.Visible = False
        Panel3.Visible = False

        TextBox6.Text = ""
        TextBox5.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""

        'SACAR BOTONES  DE BORRAR Y EDITAR , APARECER EL BOTON DE AGREGAR Y PONERLO EN OTRA UBICACION
        BotonAgregar(PictureBox1, PictureBox2, PictureBox3)
    End Sub


    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarBd("SELECT * FROM proveedores", Me, DataGridView1)
    End Sub


End Class