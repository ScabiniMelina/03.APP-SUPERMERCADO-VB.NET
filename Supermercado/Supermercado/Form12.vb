﻿Public Class Form12

    Private Sub TextBox4_Click(sender As Object, e As EventArgs) Handles TextBox4.Click
        'DESAPAREZCA EL TEXTO AL HACER CLICK NE EL CUADRO DE BUSQUEDA
        TextBox4.Text = ""
    End Sub

    Private Sub Form12_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        'ACHICO  VENTANA
        AnchoVentana(Me, 506)
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim cadena As String
        Dim Stock As Integer = TextboxItem("SELECT Stock FROM productos WHERE Codigo =  '" & ComboBox1.Text & "' ", "Stock")
        Stock = TextBox2.Text + Stock
        'EDITAR STOCK A LA BASE DE DATOS PRODUCTOS
        cadena = "UPDATE productos SET Stock = '" & Stock & "' where Codigo='" & ComboBox1.Text & "'"
        BotonEliminarAgregarModificar(cadena)

        cadena = "delete from detalle_factura where ID='" & Val(TextBox10.Text) & "'"
        'ELIMINAR ELEMENTOS A LA BASE DE DATOS 
        BotonEliminarAgregarModificar(cadena)
        CargarBd(" SELECT * FROM detalle_factura WHERE ID_factura = '" & TextBox1.Text & "'", Me, DataGridView1)
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        BuscarBd("Buscar producto del ticket por ID", TextBox4, " SELECT * FROM detalle_factura WHERE ID like '" & ("%" + TextBox10.Text + "%") & "'", DataGridView1)
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click



        Dim precioUnidad As Integer = TextboxItem("SELECT Precio from productos where Codigo=  '" & (ComboBox1.Text) & "'", "Precio")
        TextBox5.Text = TextBox2.Text * precioUnidad

        Dim cadena As String

        Dim Stock As Integer = TextboxItem("SELECT Stock FROM productos WHERE Codigo =  '" & ComboBox1.Text & "' ", "Stock")
        Dim venta As Integer = TextboxItem("SELECT Cantidad FROM detalle_factura WHERE id_factura =  '" & TextBox1.Text & "' ", "Cantidad")
        If TextBox2.Text < Stock Then
            Stock = Stock - (TextBox2.Text - venta)
            cadena = "UPDATE productos SET Stock = '" & Stock & "' where Codigo='" & ComboBox1.Text & "'"

            BotonEliminarAgregarModificar(cadena)
        ElseIf TextBox2.Text > Stock Then
            Stock = Stock + (TextBox2.Text - venta)
            cadena = "UPDATE productos SET Stock = '" & Stock & "' where Codigo='" & ComboBox1.Text & "'"
            BotonEliminarAgregarModificar(cadena)
        End If

        cadena = "UPDATE detalle_factura SET ID_factura='" & TextBox1.Text & "',Codigo_Producto='" & ComboBox1.Text & "',Cantidad='" & TextBox2.Text & "',Total_producto='" & TextBox5.Text & " ' where ID='" & Val(TextBox10.Text) & "'"
        'EDITAR ELEMENTOS A LA BASE DE DATOS 
        BotonEliminarAgregarModificar(cadena)
        CargarBd(" SELECT * FROM detalle_factura WHERE ID_factura = '" & TextBox1.Text & "'", Me, DataGridView1)

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim cadena As String
        Dim Stock As Integer = TextboxItem("SELECT Stock FROM productos WHERE Codigo =  '" & ComboBox1.Text & "' ", "Stock")
        Stock = Stock - TextBox2.Text
        'EDITAR STOCK A LA BASE DE DATOS PRODUCTOS
        cadena = "UPDATE productos SET Stock = '" & Stock & "' where Codigo='" & ComboBox1.Text & "'"
        BotonEliminarAgregarModificar(cadena)


        Dim precioUnidad As Integer = TextboxItem("SELECT Precio from productos where Codigo=  '" & (ComboBox1.Text) & "'", "Precio")
        TextBox5.Text = TextBox2.Text * precioUnidad
        cadena = "INSERT INTO detalle_factura (ID_factura,Codigo_producto,Cantidad,Total_Producto)VALUES('" & TextBox1.Text & "','" & ComboBox1.Text & "', '" & TextBox2.Text & "' ,'" & TextBox5.Text & "')"
        BotonEliminarAgregarModificar(cadena)
        CargarBd(" SELECT * FROM detalle_factura WHERE ID_factura = '" & TextBox1.Text & "'", Me, DataGridView1)
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'AGRANDO  VENTANA
        AnchoVentana(Me, 724)
        BotonEditarBorrar(PictureBox2, PictureBox3, PictureBox6)
        'Dim op As String
        If IsNumeric(DataGridView1.CurrentRow.Cells(0).Value) Then
            TextBox10.Text = DataGridView1.CurrentRow.Cells(0).Value
            TextBox1.Text = DataGridView1.CurrentRow.Cells(1).Value
            ComboBox1.Text = DataGridView1.CurrentRow.Cells(2).Value
            TextBox2.Text = DataGridView1.CurrentRow.Cells(3).Value
            TextBox5.Text = DataGridView1.CurrentRow.Cells(4).Value

            'If DataGridView1.SelectedCells.Item(5).Value Is DBNull.Value Then
            'PictureBox5.Image = PictureBox5.ErrorImage
            'Else
            'PictureBox5.Image = DataGridView1.SelectedCells.Item(5).FormattedValue
            'End If


        End If

        TextBox10.Enabled = False
        TextBox10.Visible = True
        Label5.Enabled = True
        Label5.Visible = True
        PictureBox10.Enabled = True
        PictureBox10.Visible = True
        Panel4.Visible = True

        TextBox1.Enabled = False
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        'AGRANDO  VENTANA
        AnchoVentana(Me, 724)
        'FORMULARIO SIN DATOS

        TextBox10.Enabled = False
        TextBox10.Visible = False
        Label5.Enabled = False
        Label5.Visible = False
        PictureBox10.Enabled = False
        PictureBox10.Visible = False
        Panel4.Visible = False

        TextBox1.Enabled = False

        ComboBoxItems(ComboBox1, "SELECT Codigo FROM productos", "Codigo")
        If ComboBox1.Items.Count >= 0 Then
            ComboBox1.SelectedIndex = 0
        End If



        'SACAR BOTONES  DE BORRAR Y EDITAR , APARECER EL BOTON DE AGREGAR Y PONERLO EN OTRA UBICACION
        BotonAgregar(PictureBox2, PictureBox3, PictureBox6)
    End Sub

    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.DropDown
        ComboBoxItems(sender, "SELECT Codigo FROM productos", "Codigo")
    End Sub

    Private Sub TextBox2_LostFocus(sender As Object, e As EventArgs) Handles TextBox2.LostFocus, ComboBox1.LostFocus
        Dim precioUnidad As Integer = TextboxItem("SELECT Precio from productos where Codigo=  '" & (ComboBox1.Text) & "'", "Precio")
        TextBox5.Text = TextBox2.Text * precioUnidad
    End Sub

    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles Me.Load
        CargarBd(" SELECT * FROM detalle_factura WHERE ID_factura = '" & TextBox1.Text & "'", Me, DataGridView1)
    End Sub


End Class