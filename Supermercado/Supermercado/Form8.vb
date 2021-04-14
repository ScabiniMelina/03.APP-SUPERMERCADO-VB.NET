Imports MySql.Data.MySqlClient
Imports System.Data.SQLite

Public Class Form8

    Private Sub TextBox4_Click(sender As Object, e As EventArgs) Handles TextBox4.Click
        'DESAPAREZCA EL TEXTO AL HACER CLICK NE EL CUADRO DE BUSQUEDA
        TextBox4.Text = ""
    End Sub

    Private Sub Form8_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        'ACHICO  VENTANA
        AnchoVentana(Me, 506)
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        BuscarBd("Buscar empleado por Dni", TextBox4, "SELECT * FROM empleados WHERE Dni LIKE'" & ("%" + TextBox4.Text + "%") & "'", DataGridView1)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim cadena As String = "DELETE FROM  empleados WHERE Dni='" & Val(TextBox10.Text) & "'"
        'ELIMINAR ELEMENTOS A LA BASE DE DATOS 
        BotonEliminarAgregarModificar(cadena)
        CargarBd("SELECT * FROM empleados", Me, DataGridView1)
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim op As String
        If RadioButton1.Checked = True Then
            op = RadioButton1.Text
        ElseIf RadioButton2.Checked = True Then
            op = RadioButton2.Text
        Else
            op = RadioButton3.Text
        End If
        Dim cadena As String = "UPDATE empleados SET Nombre='" & TextBox1.Text & "',Apellido='" & TextBox12.Text & "',Nacimiento='" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "',Domicilio='" & TextBox2.Text & "',Sexo='" & op & "',Telefono='" & TextBox11.Text & "',Cargo='" & ComboBox1.Text & "',Email='" & TextBox3.Text & "',Contraseña='" & TextBox14.Text & "' where Dni='" & Val(TextBox10.Text) & "'"
        'EDITAR ELEMENTOS A LA BASE DE DATOS 
        BotonEliminarAgregarModificar(cadena)
        CargarBd("SELECT * FROM empleados", Me, DataGridView1)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim op As String
        If RadioButton1.Checked = True Then
            op = RadioButton1.Text
        ElseIf RadioButton2.Checked = True Then
            op = RadioButton2.Text
        Else
            op = RadioButton3.Text
        End If
        Dim cadena As String = "INSERT INTO empleados(Dni,Nombre,Apellido,Nacimiento,Domicilio,Sexo,Telefono,Cargo,Fecha_contratacion,Email,Contraseña)VALUES('" & TextBox10.Text & "','" & TextBox1.Text & "', '" & TextBox12.Text & "' ,'" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "','" & TextBox2.Text & "','" & op & "','" & TextBox11.Text & "','" & ComboBox1.Text & "','" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "','" & TextBox3.Text & "','" & TextBox14.Text & "')"
        BotonEliminarAgregarModificar(cadena)
        CargarBd("SELECT * FROM empleados", Me, DataGridView1)
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'AGRANDO  VENTANA
        AnchoVentana(Me, 901)
        BotonEditarBorrar(PictureBox1, PictureBox2, PictureBox3)
        Dim op As String
        If IsNumeric(DataGridView1.CurrentRow.Cells(0).Value) Then
            TextBox10.Text = DataGridView1.CurrentRow.Cells(0).Value
            TextBox10.Visible = True
            TextBox1.Text = DataGridView1.CurrentRow.Cells(1).Value
            TextBox12.Text = DataGridView1.CurrentRow.Cells(2).Value
            DateTimePicker1.Value = Format(DataGridView1.CurrentRow.Cells(3).Value, "yyyy-MM-dd")
            TextBox2.Text = DataGridView1.CurrentRow.Cells(4).Value
            op = DataGridView1.CurrentRow.Cells(5).Value
            TextBox11.Text = DataGridView1.CurrentRow.Cells(6).Value
            ComboBox1.Text = DataGridView1.CurrentRow.Cells(7).Value
            DateTimePicker2.Value = Format(DataGridView1.CurrentRow.Cells(8).Value, "yyyy-MM-dd")
            TextBox3.Text = DataGridView1.CurrentRow.Cells(9).Value
            TextBox14.Text = DataGridView1.CurrentRow.Cells(10).Value

            If RadioButton1.Text = op Then
                RadioButton1.Checked = True
            ElseIf op = RadioButton2.Text Then
                RadioButton2.Checked = True
            Else
                RadioButton3.Checked = True
            End If

            'If DataGridView1.SelectedCells.Item(5).Value Is DBNull.Value Then
            'PictureBox5.Image = PictureBox5.ErrorImage
            'Else
            'PictureBox5.Image = DataGridView1.SelectedCells.Item(5).FormattedValue
            'End If


        End If
        TextBox10.Enabled = False
    End Sub

    Private Sub PictureBox16_Click(sender As Object, e As EventArgs) Handles PictureBox16.Click
        'AGRANDO  VENTANA
        AnchoVentana(Me, 901)
        'FORMULARIO SIN DATOS
        TextBox10.Text = ""
        TextBox10.Enabled = True
        TextBox1.Text = ""
        TextBox12.Text = ""
        TextBox2.Text = ""
        RadioButton1.Checked = True
        TextBox11.Text = ""
        ComboBox1.SelectedIndex = 0
        TextBox3.Text = ""
        TextBox14.Text = ""
        'SACAR BOTONES  DE BORRAR Y EDITAR , APARECER EL BOTON DE AGREGAR Y PONERLO EN OTRA UBICACION
        BotonAgregar(PictureBox1, PictureBox2, PictureBox3)
    End Sub

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarBd("SELECT * FROM empleados", Me, DataGridView1)
    End Sub


End Class