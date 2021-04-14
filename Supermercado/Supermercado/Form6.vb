Imports MySql.Data.MySqlClient
Imports System.Data.SQLite

Public Class Form6

    Private Sub TextBox4_Click(sender As Object, e As EventArgs) Handles TextBox4.Click
        'DESAPAREZCA EL TEXTO AL HACER CLICK NE EL CUADRO DE BUSQUEDA
        TextBox4.Text = ""
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        BuscarBd("Buscar factura por ID", TextBox4, "SELECT * FROM factura WHERE ID like '" & ("%" + TextBox4.Text + "%") & "'", DataGridView1)
    End Sub

    Private Sub Form6_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        'ACHICO  VENTANA
        AnchoVentana(Me, 506)
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim cadena As String = "delete from factura where ID='" & Val(TextBox10.Text) & "'"
        'ELIMINAR ELEMENTOS A LA BASE DE DATOS 
        BotonEliminarAgregarModificar(cadena)
        CargarBd("SELECT * FROM factura", Me, DataGridView1)
    End Sub


    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Dim cadena As String = "UPDATE factura SET Fecha_Emision='" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "',Dni_empleado='" & ComboBox1.Text & "',Dni_cliente='" & ComboBox2.Text & " ' where ID='" & Val(TextBox10.Text) & "'"
        'EDITAR ELEMENTOS A LA BASE DE DATOS 
        BotonEliminarAgregarModificar(cadena)
        CargarBd("SELECT * FROM factura", Me, DataGridView1)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim cadena As String
        Dim Imag As Byte()
        Imag = ImagenABytes(Me.PictureBox1.Image)
        'FALTA CARGAR LA IMAGEN
        cadena = "INSERT INTO factura (ID,Fecha_emision,Dni_empleado,Dni_cliente)VALUES('" & TextBox10.Text & "','" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "', '" & ComboBox1.Text & "','" & ComboBox2.Text & "')"
        BotonEliminarAgregarModificar(cadena)
        CargarBd("SELECT * FROM factura", Me, DataGridView1)

        IrTicketVentas()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'AGRANDO  VENTANA
        AnchoVentana(Me, 724)
        BotonEditarBorrar(PictureBox2, PictureBox3, PictureBox6)
        'Dim op As String
        If IsNumeric(DataGridView1.CurrentRow.Cells(0).Value) Then
            TextBox10.Text = DataGridView1.CurrentRow.Cells(0).Value
            TextBox10.Visible = True
            DateTimePicker1.Value = Format(DataGridView1.CurrentRow.Cells(1).Value, "yyyy-MM-dd")
            ComboBox1.Text = DataGridView1.CurrentRow.Cells(2).Value

            ComboBox2.Text = DataGridView1.CurrentRow.Cells(3).Value

            'If DataGridView1.SelectedCells.Item(5).Value Is DBNull.Value Then
            'PictureBox5.Image = PictureBox5.ErrorImage
            'Else
            'PictureBox5.Image = DataGridView1.SelectedCells.Item(5).FormattedValue
            'End If

        End If

        TextBox10.Enabled = False
        TextBox10.Visible = True
        Label1.Enabled = True
        Label1.Visible = True
        PictureBox8.Enabled = True
        PictureBox8.Visible = True
        Panel3.Visible = True
        PictureBox10.Enabled = True
        PictureBox10.Visible = True

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        'AGRANDO  VENTANA
        AnchoVentana(Me, 724)
        'FORMULARIO SIN DATOS
        TextBox10.Text = ""
        TextBox10.Enabled = False
        TextBox10.Visible = False
        Label1.Enabled = False
        Label1.Visible = False
        PictureBox8.Enabled = False
        PictureBox8.Visible = False
        Panel3.Visible = False
        PictureBox10.Enabled = False
        PictureBox10.Visible = False
        ComboBoxItems(ComboBox1, "SELECT Dni FROM empleados", "Dni")
        If ComboBox1.Items.Count >= 0 Then
            ComboBox1.SelectedIndex = 0
        End If

        ComboBoxItems(ComboBox2, "SELECT Dni FROM clientes", "Dni")
        If ComboBox2.Items.Count >= 0 Then
            ComboBox2.SelectedIndex = 0
        End If


        'SACAR BOTONES  DE BORRAR Y EDITAR , APARECER EL BOTON DE AGREGAR Y PONERLO EN OTRA UBICACION
        BotonAgregar(PictureBox2, PictureBox3, PictureBox6)
    End Sub

    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.DropDown
        ComboBoxItems(sender, "SELECT Dni FROM empleados", "Dni")
    End Sub

    Private Sub ComboBox2_DropDown(sender As Object, e As EventArgs) Handles ComboBox2.DropDown
        ComboBoxItems(sender, "SELECT Dni FROM clientes", "Dni")
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarBd("SELECT * FROM factura", Me, DataGridView1)
    End Sub


    Sub IrTicketVentas()
        Form12.TextBox1.Text = TextBox10.Text

        Form12.TextBox10.Enabled = False
        Form12.TextBox10.Visible = False
        Form12.Label5.Enabled = False
        Form12.Label5.Visible = False
        Form12.PictureBox10.Enabled = False
        Form12.PictureBox10.Visible = False
        Form12.Panel4.Visible = False
        Form12.TextBox1.Enabled = False
        Form12.TextBox2.Text = 1


        AbrirForm(Form12)
        CargarBd(" SELECT * FROM detalle_factura WHERE ID_factura = '" & (TextBox10.Text) & "'", Form12, DataGridView1)


    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click
        IrTicketVentas()
    End Sub
End Class