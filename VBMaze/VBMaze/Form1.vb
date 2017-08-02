Imports System.Threading

Public Class Form1

    Public display As VBGame.Display
    Private thread As New Thread(AddressOf mazeloop)
    Public fps As Integer = 60
    Public fast As Boolean = False
    Public debug As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If MsgBox("Fullscreen?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            display = New VBGame.Display(Me, Screen.PrimaryScreen.Bounds.Size, "VBMaze", False, True)
        Else
            display = New VBGame.Display(Me, New Size(500, 500), "VBMaze")
        End If
        thread.Start()
    End Sub

    Private Sub mazeloop()
        Dim grid As New Grid(display, 20)
        grid.GenerateSquare()
        Dim generator As New Generator(grid)

        Dim options As New FormOptions(grid, generator)
        Me.Invoke(Sub() options.Show())

        display.fill(VBGame.Colors.black)
        'grid.Draw()

        While True
            If fps <> 0 Then
                SyncLock grid
                    SyncLock generator
                        If generator.running Then
                            grid.DrawDirty()
                            generator.DoStep()
                            If debug Then
                                generator.Draw(display)
                            End If
                        End If
                        display.update()
                    End SyncLock
                End SyncLock
                If fps <> -1 Then
                    display.clockTick(fps)
                End If
            End If
        End While
    End Sub

End Class
