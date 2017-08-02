Public Class Node

    Public x As Integer
    Public y As Integer
    Public neighbours As New List(Of Integer)

    Public Sub New(x As Integer, y As Integer)
        Me.x = x
        Me.y = y
    End Sub

    Shared Operator =(node1 As Node, node2 As Node)
        Return node1.x = node2.x And node1.y = node2.y
    End Operator

    Shared Operator <>(node1 As Node, node2 As Node)
        Return Not node1 = node2
    End Operator

    Public Function GetXY() As Point
        Return New Point(x, y)
    End Function

End Class
