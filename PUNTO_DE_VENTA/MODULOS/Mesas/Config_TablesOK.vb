Imports System.Data.SqlClient

Public Class Config_TablesOK
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        dibujarSalones()
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Config_TablesOK_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Dim Foco_seleccionador As String
    Sub dibujarSalones()
        FlowLayoutPanel1.Controls.Clear()
        Try
            abrir()
            Dim query As String = "mostrar_salon"
            Dim cmd As New SqlCommand(query, conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@buscar", txtSalon.Text)
            Dim rdr As SqlDataReader = cmd.ExecuteReader
            While rdr.Read
                Dim b As New Button()
                Dim panelC1 As New Panel
                Dim panelLanteral As New Panel

                b.Text = rdr("Salon").ToString()
                b.Name = rdr("idSalon").ToString()
                b.Dock = DockStyle.Fill
                b.BackColor = Color.Transparent
                b.Font = New System.Drawing.Font(10, 12)
                b.FlatStyle = FlatStyle.Flat
                b.FlatAppearance.BorderSize = 0
                b.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64)
                b.FlatAppearance.MouseOverBackColor = Color.FromArgb(43, 43, 43)
                b.ForeColor = Color.White
                b.TextAlign = ContentAlignment.MiddleLeft

                panelC1.Size = New System.Drawing.Size(252, 74)
                panelLanteral.Size = New System.Drawing.Size(3, 74)
                panelLanteral.Dock = DockStyle.Left

                If Foco_seleccionador = b.Text Then
                    panelLanteral.BackColor = Color.Orange
                    b.BackColor = Color.FromArgb(43, 43, 43)
                Else
                    panelLanteral.BackColor = Color.Transparent
                    b.BackColor = Color.Transparent
                End If
                panelC1.Controls.Add(b)
                panelC1.Controls.Add(panelLanteral)
                FlowLayoutPanel1.Controls.Add(panelC1)
                b.BringToFront()
                panelLanteral.SendToBack()

                AddHandler b.Click, AddressOf miEvento_Salon_Button

            End While
            Cerrar()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Dim idSalon As Integer
    Private Sub miEvento_Salon_Button(ByVal sender As System.Object, ByVal e As EventArgs)
        Try
            Foco_seleccionador = DirectCast(sender, Button).Text
            idSalon = DirectCast(sender, Button).Name
            dibujarSalones()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs)

    End Sub
End Class