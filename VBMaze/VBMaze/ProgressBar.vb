Public Class ProgressBar

    Private text As String
    Private max As Integer
    Public value As Integer = 0
    Public interval As Integer

    Private width As Integer

    Public Sub New(text As String, max As Integer, steps As Integer)
        Me.text = text
        Me.max = max
        Me.interval = max \ steps
    End Sub

    Public Sub Draw(display As VBGame.Display)
        display.drawText(New Rectangle(0, 0, display.width, display.height / 8), text, VBGame.Colors.white, New Font("Consolas", 12))
        display.drawRect(New Rectangle(0, display.height * (1 / 8), display.width * value / max, 20), VBGame.Colors.white)
    End Sub

    Public Sub Update(display As VBGame.Display)
        If value Mod interval = 0 Then
            Draw(display)
            display.update()
        End If
    End Sub
End Class
