Imports MySql.Data.MySqlClient
Imports System.Data.SQLite

Public Class Form5

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        'DESAPAREZCA EL TEXTO AL HACER CLICK NE EL CUADRO DE BUSQUEDA
        TextBox1.Text = ""
    End Sub

    Private Sub Form5_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        'ACHICO  VENTANA
        AnchoVentana(Me, 509)
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        BuscarBd("Buscar ingreso por ID", TextBox1, "SELECT * FROM ingreso_mercaderia WHERE  ID like '" & ("%" + TextBox1.Text + "%") & "'", DataGridView1)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim cadena As String = "DELETE FROM ingreso_mercaderia WHERE ID='" & Val(TextBox2.Text) & "'"
        'ELIMINAR ELEMENTOS A LA BASE DE DATOS 
        BotonEliminarAgregarModificar(cadena)
        CargarBd("SELECT * FROM ingreso_mercaderia", Me, DataGridView1)
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim cadena As String = "UPDATE ingreso_mercaderia SET ID_provedor='" & ComboBox1.Text & "',Costo_total='" & TextBox4.Text & "',Fecha_entrega='" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' where ID='" & Val(TextBox2.Text) & "'"
        'EDITAR ELEMENTOS A LA BASE DE DATOS 
        BotonEliminarAgregarModificar(cadena)
        CargarBd("SELECT * FROM ingreso_mercaderia", Me, DataGridView1)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim cadena As String = "INSERT INTO ingreso_mercaderia (ID,ID_provedor,Costo_total,Fecha_entrega)VALUES('" & TextBox6.Text & "','" & ComboBox1.Text & "', '" & TextBox4.Text & "' ,'" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "')"
        BotonEliminarAgregarModificar(cadena)
        CargarBd("SELECT * FROM ingreso_mercaderia", Me, DataGridView1)
        IrTicketIngreso()
    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'AGRANDO  VENTANA
        AnchoVentana(Me, 732)
        BotonEditarBorrar(PictureBox1, PictureBox2, PictureBox3)
        'Dim op As String
        If IsNumeric(DataGridView1.CurrentRow.Cells(0).Value) Then
            TextBox2.Text = DataGridView1.CurrentRow.Cells(0).Value
            TextBox2.Visible = True
            ComboBox1.Text = DataGridView1.CurrentRow.Cells(1).Value
            TextBox4.Text = DataGridView1.CurrentRow.Cells(2).Value
            DateTimePicker1.Value = DataGridView1.CurrentRow.Cells(3).Value


            'If DataGridView1.SelectedCells.Item(5).Value Is DBNull.Value Then
            'PictureBox5.Image = PictureBox5.ErrorImage
            'Else
            'PictureBox5.Image = DataGridView1.SelectedCells.Item(5).FormattedValue
            'End If
        End If
        TextBox2.Enabled = False
        TextBox2.Visible = True
        Label1.Enabled = True
        Label1.Visible = True
        PictureBox8.Enabled = True
        PictureBox8.Visible = True
        Panel3.Visible = True
        PictureBox10.Visible = True
        PictureBox10.Enabled = True
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        'AGRANDO  VENTANA
        AnchoVentana(Me, 732)
        'FORMULARIO SIN DATOS
        TextBox2.Text = ""
        TextBox2.Enabled = False
        TextBox2.Visible = False
        Label1.Enabled = False
        Label1.Visible = False
        PictureBox8.Enabled = False
        PictureBox8.Visible = False
        Panel3.Visible = False
        TextBox4.Text = ""
        PictureBox10.Visible = False
        PictureBox10.Enabled = False
        ComboBoxItems(ComboBox1, "SELECT ID FROM proveedores", "ID")
        If ComboBox1.Items.Count > 0 Then
            ComboBox1.SelectedIndex = 1
        End If

        'SACAR BOTONES  DE BORRAR Y EDITAR , APARECER EL BOTON DE AGREGAR Y PONERLO EN OTRA UBICACION
        BotonAgregar(PictureBox1, PictureBox2, PictureBox3)
    End Sub

    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.DropDown
        ComboBoxItems(sender, "SELECT ID FROM proveedores", "ID")
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarBd("SELECT * FROM ingreso_mercaderia", Me, DataGridView1)

    End Sub

    Sub IrTicketIngreso()
        Form13.TextBox1.Text = TextBox2.Text

        Form13.TextBox10.Enabled = False
        Form13.TextBox10.Visible = False
        Form13.Label5.Enabled = False
        Form13.Label5.Visible = False
        Form13.PictureBox10.Enabled = False
        Form13.PictureBox10.Visible = False
        Form13.Panel4.Visible = False
        Form13.TextBox1.Enabled = False
        Form13.TextBox2.Text = 1


        AbrirForm(Form13)
        CargarBd(" SELECT * FROM detalle_ingreso_mercaderia WHERE ID_detalle_ingreso = '" & (TextBox2.Text) & "'", Form13, DataGridView1)
    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click
        IrTicketIngreso()
    End Sub
End Class