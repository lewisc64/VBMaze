Public Class FormOptions

    Private grid As Grid
    Private generator As Generator

    Public Sub New(ByRef grid As Grid, ByRef generator As Generator)
        InitializeComponent()

        Me.grid = grid
        Me.generator = generator

    End Sub

    Private Sub FormOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ControlBox = False
    End Sub

    Public Sub FormOptions_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason <> CloseReason.FormOwnerClosing Then
            Me.Hide()
            e.Cancel = True
        End If
    End Sub

    Public Sub Apply()
        If Not IsNothing(grid) Then
            If combo_type.SelectedIndex = -1 Then
                MsgBox("Please select a maze type.", , "VBMaze")
                Return
            End If
            generator.running = False
            grid.spacing = numeric_spacing.Value
            grid.thickness = grid.spacing / 2
            SyncLock grid
                SyncLock generator
                    Select Case combo_type.Items(combo_type.SelectedIndex)
                        Case "Square"
                            grid.GenerateSquare()
                        Case "Isometric"
                            grid.GenerateIsometric()
                        Case "Circular"
                            grid.GenerateCircular()
                        Case "Random"
                            grid.GenerateRandom()
                        Case Else
                    End Select
                    generator.reset(grid, True)
                    Form1.display.fill(grid.wallColor)
                    'grid.Draw()
                    generator.running = True
                End SyncLock
            End SyncLock
        Else
            MsgBox("Please wait until grid creation has finished.", , "VBMaze")
        End If
    End Sub

    Private Sub button_apply_Click(sender As Object, e As EventArgs) Handles button_apply.Click
        Apply()
    End Sub

    Private Sub button_export_png_Click(sender As Object, e As EventArgs) Handles button_export_png.Click
        Dim file As New SaveFileDialog()
        file.Filter = "PNG File|*.png"
        If file.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim surface As New VBGame.BitmapSurface(grid.display.getRect().Size)
            grid.Draw(surface)
            VBGame.Images.save(surface.getImage(), file.FileName)
        End If
    End Sub

    Private Sub button_regenerate_Click(sender As Object, e As EventArgs) Handles button_regenerate.Click
        grid.display.fill(grid.wallColor)
        grid.connections.Clear()
        grid.connected.Clear()
        generator.reset(grid)
    End Sub

    Private Sub button_speed_0_Click(sender As Object, e As EventArgs) Handles button_speed_0.Click
        Form1.fps = 0
    End Sub

    Private Sub button_speed_1_Click(sender As Object, e As EventArgs) Handles button_speed_1.Click
        Form1.fps = 1
    End Sub

    Private Sub button_speed_2_Click(sender As Object, e As EventArgs) Handles button_speed_2.Click
        Form1.fps = 30
    End Sub

    Private Sub button_speed_3_Click(sender As Object, e As EventArgs) Handles button_speed_3.Click
        Form1.fps = 120
    End Sub

    Private Sub button_speed_4_Click(sender As Object, e As EventArgs) Handles button_speed_4.Click
        Form1.fps = 240
    End Sub

    Private Sub button_speed_5_Click(sender As Object, e As EventArgs) Handles button_speed_5.Click
        Form1.fps = -1
    End Sub

    Private Sub check_debug_CheckedChanged(sender As Object, e As EventArgs) Handles check_debug.CheckedChanged
        If Form1.debug Then
            SyncLock grid.dirtyNodes
                grid.dirtyNodes = grid.connected.ToList()
            End SyncLock
        End If
        Form1.debug = check_debug.Checked
    End Sub
End Class