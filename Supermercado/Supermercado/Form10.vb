Imports MySql.Data.MySqlClient
Imports System.Data.SQLite
Imports System.IO


Public Class Form10
    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        'DESAPAREZCA EL TEXTO AL HACER CLICK NE EL CUADRO DE BUSQUEDA
        TextBox1.Text = ""
    End Sub
    Private Sub Form10_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        'ACHICO  VENTANA
        AnchoVentana(Me, 506)
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        BuscarBd("Buscar productos por Codigo",
                 TextBox1,
                 "SELECT Codigo,Nombre,Precio,Stock,Categoria,Marca,Unidad FROM productos WHERE Codigo like '" & ("%" + TextBox1.Text + "%") & "'",
                 DataGridView1)

    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim cadena As String = "DELETE FROM productos where Codigo='" & Val(TextBox6.Text) & "'"
        'ELIMINAR ELEMENTOS A LA BASE DE DATOS 
        BotonEliminarAgregarModificar(cadena)
        CargarBd("SELECT Codigo,Nombre,Precio,Stock,Categoria,Marca,Unidad FROM productos", Me, DataGridView1)
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim cadena As String = "UPDATE productos SET Nombre='" & TextBox2.Text & "',Precio='" & TextBox3.Text & "',Stock='" & TextBox4.Text & "',Categoria='" & ComboBox1.Text & "',Marca='" & TextBox7.Text & "',Unidad='" & ComboBox2.Text & "' where Codigo='" & Val(TextBox6.Text) & "'"
        'EDITAR ELEMENTOS A LA BASE DE DATOS 
        BotonEliminarAgregarModificar(cadena)
        CargarBd("SELECT Codigo,Nombre,Precio,Stock,Categoria,Marca,Unidad FROM productos", Me, DataGridView1)
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim cadena As String
        Dim Imag As Byte()
        Imag = ImagenABytes(Me.PictureBox1.Image)
        'FALTA CARGAR LA IMAGEN
        cadena = "INSERT INTO productos (Nombre,Precio,Stock,Categoria,Marca,Unidad)VALUES('" & TextBox2.Text & "','" & TextBox3.Text & "', '" & TextBox4.Text & "' ,'" & ComboBox1.Text & "','" & TextBox7.Text & "','" & ComboBox2.Text & "')"
        BotonEliminarAgregarModificar(cadena)
        CargarBd("SELECT Codigo,Nombre,Precio,Stock,Categoria,Marca,Unidad FROM productos", Me, DataGridView1)
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'AGRANDO  VENTANA
        AnchoVentana(Me, 908)
        BotonEditarBorrar(PictureBox1, PictureBox2, PictureBox3)
        'Dim op As String
        If IsNumeric(DataGridView1.CurrentRow.Cells(0).Value) Then
            TextBox6.Text = DataGridView1.CurrentRow.Cells(0).Value
            TextBox6.Visible = True
            TextBox2.Text = DataGridView1.CurrentRow.Cells(1).Value
            TextBox3.Text = DataGridView1.CurrentRow.Cells(2).Value
            TextBox4.Text = DataGridView1.CurrentRow.Cells(3).Value
            ComboBox1.Text = DataGridView1.CurrentRow.Cells(4).Value
            TextBox7.Text = DataGridView1.CurrentRow.Cells(5).Value
            ComboBox2.Text = DataGridView1.CurrentRow.Cells(6).Value

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

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        'AGRANDO  VENTANA
        AnchoVentana(Me, 908)
        'FORMULARIO SIN DATOS
        TextBox6.Text = ""
        TextBox6.Enabled = False
        TextBox6.Visible = False
        Label1.Enabled = False
        Label1.Visible = False
        PictureBox13.Enabled = False
        PictureBox13.Visible = False
        Panel3.Visible = False
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox7.Text = ""
        ComboBox1.Text = "Bebidas"
        ComboBox2.Text = "kg"
        'SACAR BOTONES  DE BORRAR Y EDITAR , APARECER EL BOTON DE AGREGAR Y PONERLO EN OTRA UBICACION
        BotonAgregar(PictureBox1, PictureBox2, PictureBox3)
    End Sub


    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox5.Image = Image.FromFile(OpenFileDialog1.FileName)
            Me.Text = "Visor De Imagenes(" & OpenFileDialog1.FileName & ")"
        End If
    End Sub


End Class