Public Class Generator

    Private grid As Grid
    Private random As New Random

    Public running As Boolean = False

    Public start As Integer
    Public finish As Integer

    Private current As Integer
    Private backtracks As List(Of Integer)
    Private stepThrough As Boolean

    Public Sub New(grid As Grid, Optional stepThrough As Boolean = True)
        reset(grid, stepThrough)
    End Sub

    Public Sub reset(grid As Grid, Optional stepThrough As Boolean = True)
        Me.grid = grid
        Me.stepThrough = stepThrough
        start = 0
        finish = grid.nodes.Count - 1
        current = start
        grid.connected.Add(current)
        backtracks = New List(Of Integer)
    End Sub

    Public Sub Draw(display As VBGame.DrawBase)
        display.drawCircle(New VBGame.Circle(grid.nodes(start).x, grid.nodes(start).y, grid.thickness / 2), VBGame.Colors.green)
        display.drawCircle(New VBGame.Circle(grid.nodes(finish).x, grid.nodes(finish).y, grid.thickness / 2), VBGame.Colors.red)
        For Each i As Integer In backtracks
            display.drawCircle(New VBGame.Circle(grid.nodes(i).x, grid.nodes(i).y, grid.thickness / 2), VBGame.Colors.blue)
        Next
    End Sub

    Public Function Backtrack() As Boolean
        If stepThrough Then
            grid.dirtyNodes.Add(current)
        End If

        If backtracks.Count = 0 Then
            Return True
        End If

        Dim i As Integer = random.Next(0, backtracks.Count)
        current = backtracks(i)
        backtracks.RemoveAt(i)

        Return False
    End Function

    Public Function DoStep() As Boolean
        Dim neighbours As List(Of Integer) = grid.GetNeighbours(current)
        If neighbours.Count = 0 Then
            Return Backtrack()
        End If

        Dim nextNode As Integer = neighbours(random.Next(0, neighbours.Count))

        grid.connections.Add({current, nextNode})

        If stepThrough Then
            grid.dirtyConnections.Add(grid.connections.Last)
            grid.dirtyNodes.Add(current)
            grid.dirtyNodes.Add(nextNode)
        End If

        grid.connected.Add(nextNode)
        backtracks.Add(current)

        current = nextNode
        If current = finish Then
            Return Backtrack()
        End If

        Return False
    End Function

    Public Sub Generate()
        While Not DoStep()
        End While
    End Sub

End Class
