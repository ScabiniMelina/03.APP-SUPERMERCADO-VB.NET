Public Class Form4


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Module1.categoria = Label2.Text
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Module1.categoria = Label1.Text
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Module1.categoria = Label3.Text
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Module1.categoria = Label4.Text
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Module1.categoria = Label8.Text
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Module1.categoria = Label7.Text
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Module1.categoria = Label6.Text
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Module1.categoria = Label16.Text
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Module1.categoria = Label12.Text
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Module1.categoria = Label11.Text
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Module1.categoria = Label10.Text
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Module1.categoria = Label9.Text
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Module1.categoria = Label15.Text
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Module1.categoria = Label5.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Module1.categoria = Label13.Text
    End Sub


    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button10.Click, Button11.Click, Button12.Click, Button13.Click, Button14.Click, Button15.Click, Button16.Click
        AbrirForm(Form10)
        AnchoVentana(Me, 506)
        BotonEditarBorrar(Form10.PictureBox1, Form10.PictureBox2, Form10.PictureBox3)
        BuscarBd("Buscar producto por ID", Form10.TextBox1, "Form10", Form10.DataGridView1)
    End Sub

End Class