Imports System.Threading

Public Class Form1

    Public display As VBGame.Display
    Private thread As New Thread(AddressOf mazeloop)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display = New VBGame.Display(Me, New Size(500, 500), "VBMaze")
        thread.Start()
    End Sub

    Private Sub mazeloop()
        Dim grid As New Grid(display, 20)
        grid.GenerateSquare()
        Dim generator As New Generator(grid)

        Dim options As New FormOptions(grid, generator)

        display.fill(VBGame.Colors.black)
        'grid.Draw()

        Dim fps As Integer = 60
        Dim fpsStep As Integer = 10
        Dim fast As Boolean = False

        While True

            For Each e As KeyEventArgs In display.getKeyDownEvents()
                If e.KeyCode = Keys.F Then
                    fast = True
                End If
            Next

            For Each e As KeyEventArgs In display.getKeyUpEvents()
                If e.KeyCode = Keys.Enter Then
                    grid.display.fill(grid.wallColor)
                    grid.connections.Clear()
                    grid.connected.Clear()
                    generator = New Generator(grid)
                ElseIf e.KeyCode = Keys.M Then
                    grid.display.fill(grid.wallColor)
                    grid.connections.Clear()
                    grid.connected.Clear()
                    generator = New Generator(grid, False)
                    generator.Generate()
                    grid.Draw()
                ElseIf e.KeyCode = Keys.F Then
                    fast = False
                ElseIf e.KeyCode = Keys.O Then
                    Me.Invoke(Sub() options.Show())
                End If
            Next

            For Each e As VBGame.MouseEvent In display.getMouseEvents()
                If e.action = VBGame.MouseEvent.actions.scroll Then
                    If e.button = VBGame.MouseEvent.buttons.scrollUp Then
                        If fps = 1 Then
                            fps = fpsStep
                        Else
                            fps += fpsStep
                        End If
                    ElseIf e.button = VBGame.MouseEvent.buttons.scrollDown Then
                        fps = Math.Max(fps - fpsStep, 1)
                    End If
                End If
            Next

            SyncLock grid
                SyncLock generator
                    grid.DrawDirty()
                    generator.DoStep()
                    'generator.Draw(display)
                    display.update()
                End SyncLock
            End SyncLock

            If Not fast Then
                display.clockTick(fps)
            End If
        End While
    End Sub

End Class
