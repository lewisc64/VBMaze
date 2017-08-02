Public Class FormOptions

    Private grid As Grid
    Private generator As Generator

    Public Sub New(ByRef grid As Grid, ByRef generator As Generator)
        InitializeComponent()

        Me.grid = grid
        Me.generator = generator

    End Sub

    Public Sub FormOptions_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason <> CloseReason.FormOwnerClosing Then
            Me.Hide()
            e.Cancel = True
        End If
    End Sub

    Private Sub button_square_Click(sender As Object, e As EventArgs) Handles button_square.Click
        SyncLock grid
            SyncLock generator
                grid.GenerateSquare()
                generator.reset(grid, True)
                Form1.display.fill(grid.wallColor)
                'grid.Draw()
            End SyncLock
        End SyncLock
    End Sub

    Private Sub button_isometric_Click(sender As Object, e As EventArgs) Handles button_isometric.Click
        SyncLock grid
            SyncLock generator
                grid.GenerateIsometric()
                generator.reset(grid, True)
                Form1.display.fill(grid.wallColor)
                'grid.Draw()
            End SyncLock
        End SyncLock
    End Sub

    Private Sub button_random_Click(sender As Object, e As EventArgs) Handles button_random.Click
        SyncLock grid
            SyncLock generator
                grid.GenerateRandom()
                generator.reset(grid, True)
                Form1.display.fill(grid.wallColor)
                'grid.Draw()
            End SyncLock
        End SyncLock
    End Sub

    Private Sub numeric_spacing_ValueChanged(sender As Object, e As EventArgs) Handles numeric_spacing.ValueChanged
        If Not IsNothing(grid) Then
            grid.spacing = numeric_spacing.Value
            grid.thickness = grid.spacing / 2
        End If
    End Sub
End Class