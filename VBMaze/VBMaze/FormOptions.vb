Imports System.Threading

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

    Public Sub Apply(Optional instant As Boolean = False)
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
                    If instant Then
                        generator.Generate()
                        grid.DrawBackground()
                        grid.Draw()
                    Else
                        grid.DrawBackground()
                    End If
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

    Private Sub button_apply_instantly_Click(sender As Object, e As EventArgs) Handles button_apply_instantly.Click
        Apply(True)
    End Sub

    Private Sub button_export_png_Click(sender As Object, e As EventArgs) Handles button_export_png.Click
        Dim file As New SaveFileDialog()
        file.Filter = "PNG File|*.png"
        If file.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim surface As New VBGame.BitmapSurface(grid.display.getRect().Size)
            If Form1.solution Then
                grid.Draw(surface, True, generator.start, generator.finish)
            Else
                grid.Draw(surface)
            End If
            VBGame.Images.save(surface.getImage(), file.FileName)
        End If
    End Sub

    Private Sub button_regenerate_Click(sender As Object, e As EventArgs)
        generator.running = False
        Thread.Sleep(100)
        grid.display.fill(grid.wallColor)
        grid.connections.Clear()
        grid.connected.Clear()
        grid.dirtyNodes.Clear()
        grid.dirtyConnections.Clear()
        generator.reset(grid)
        generator.running = True
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

    Private Sub check_solution_CheckedChanged(sender As Object, e As EventArgs) Handles check_solution.CheckedChanged
        If Form1.solution Then
            SyncLock grid.dirtyNodes
                SyncLock grid.dirtyConnections
                    grid.dirtyNodes = grid.connected.ToList()
                    grid.dirtyConnections = grid.connections.ToList()
                End SyncLock
            End SyncLock
        End If
        Form1.solution = check_solution.Checked
    End Sub

    Private Sub button_set_wall_color_Click(sender As Object, e As EventArgs) Handles button_set_wall_color.Click
        If ColorDialog_wall.ShowDialog() = Windows.Forms.DialogResult.OK Then
            grid.wallColor = ColorDialog_wall.Color
        End If
    End Sub

    Private Sub button_set_path_color_Click(sender As Object, e As EventArgs) Handles button_set_path_color.Click
        If ColorDialog_path.ShowDialog() = Windows.Forms.DialogResult.OK Then
            grid.pathColor = ColorDialog_path.Color
        End If
    End Sub

    Private Sub button_redraw_Click(sender As Object, e As EventArgs) Handles button_redraw.Click
        SyncLock grid.dirtyNodes
            SyncLock grid.dirtyConnections
                grid.dirtyNodes = grid.connected.ToList()
                grid.dirtyConnections = grid.connections.ToList()
            End SyncLock
        End SyncLock
    End Sub
End Class