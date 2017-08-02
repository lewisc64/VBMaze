Public Class Grid

    Public display As VBGame.DrawBase
    Private random As New Random

    Public nodes As New List(Of Node)
    Public connections As New List(Of Array)
    Public connected As New List(Of Integer)
    Public dirtyConnections As New List(Of Array)
    Public dirtyNodes As New List(Of Integer)

    Public spacing As Integer
    Public thickness As Integer
    Public neighbouring As Integer
    Public pathColor As Color = VBGame.Colors.white
    Public wallColor As Color = VBGame.Colors.black

    Public Sub New(ByRef display As VBGame.DrawBase, spacing As Integer)
        Me.display = display
        Me.spacing = spacing
        Me.thickness = spacing / 2
        Me.neighbouring = spacing
    End Sub

    Public Sub Draw()
        display.fill(wallColor)
        For Each Node As Node In nodes
            display.drawCircle(New VBGame.Circle(Node.x, Node.y, thickness / 2), pathColor)
        Next
        For Each connection As Array In connections
            display.drawLine(nodes(connection(0)).GetXY(), nodes(connection(1)).GetXY(), pathColor, thickness)
        Next
    End Sub

    Public Sub DrawDirty()
        For Each node As Integer In dirtyNodes
            display.drawCircle(New VBGame.Circle(nodes(node).GetXY(), thickness / 2), pathColor)
        Next
        dirtyNodes.Clear()
        For Each connection As Array In dirtyConnections
            display.drawLine(nodes(connection(0)).GetXY(), nodes(connection(1)).GetXY(), pathColor, thickness)
        Next
        dirtyConnections.Clear()
    End Sub

    Public Function GetDistance(node1 As Node, node2 As Node) As Double
        Return Math.Sqrt(Math.Pow(node1.x - node2.x, 2) + Math.Pow(node1.y - node2.y, 2))
    End Function

    Public Function GetNeighbours(node As Integer) As List(Of Integer)
        Dim neighbours As New List(Of Integer)
        If nodes(node).neighbours.Count <> 0 Then
            neighbours = nodes(node).neighbours
            For Each i As Integer In neighbours.ToList()
                If connected.Contains(i) Then
                    neighbours.Remove(i)
                End If
            Next
            Return neighbours
        End If
        For i As Integer = 0 To nodes.Count - 1
            If Not connected.Contains(i) AndAlso nodes(i) <> nodes(node) AndAlso GetDistance(nodes(node), nodes(i)) <= neighbouring Then
                neighbours.Add(i)
            End If
        Next
        Return neighbours
    End Function

    Public Sub PrecomputeNeighbours()
        display.fill(VBGame.Colors.black)
        Dim bar As New ProgressBar("Precomputing neighbours...", nodes.Count - 1, 100)
        For i As Integer = 0 To nodes.Count - 1
            nodes(i).neighbours = GetNeighbours(i)
            bar.value = i
            bar.Update(display)
        Next
    End Sub

    Public Sub GenerateSquare()
        display.fill(VBGame.Colors.black)
        Dim bar As New ProgressBar("Generating square grid...", (display.width * display.height) / spacing ^ 2, 100)
        nodes.Clear()
        connections.Clear()
        dirtyNodes.Clear()
        dirtyConnections.Clear()
        connected.Clear()
        neighbouring = spacing
        For tx As Integer = spacing To display.width - spacing Step spacing
            For ty As Integer = spacing To display.height - spacing Step spacing
                nodes.Add(New Node(tx, ty))
                bar.value += 1
                bar.Update(display)
            Next
        Next
        PrecomputeNeighbours()
    End Sub

    Public Sub GenerateIsometric()
        display.fill(VBGame.Colors.black)
        Dim bar As New ProgressBar("Generating isometric grid...", (display.width * display.height) / spacing ^ 2, 100)
        nodes.Clear()
        connections.Clear()
        dirtyNodes.Clear()
        dirtyConnections.Clear()
        connected.Clear()
        neighbouring = spacing + 3
        Dim ymod As Integer = spacing / 4
        For tx As Integer = spacing To display.width - spacing Step spacing
            ymod = -ymod
            For ty As Integer = spacing To display.height - spacing Step spacing
                nodes.Add(New Node(tx, ty + ymod))
                bar.value += 1
                bar.Update(display)
            Next
        Next
        PrecomputeNeighbours()
    End Sub

    Public Sub GenerateRandom()
        nodes.Clear()
        connections.Clear()
        dirtyNodes.Clear()
        dirtyConnections.Clear()
        connected.Clear()
        neighbouring = spacing * 2
        For x As Integer = 1 To (display.width * display.height) / spacing ^ 2
            nodes.Add(New Node(random.Next(spacing, display.width - spacing), random.Next(spacing, display.height - spacing)))
        Next
        PrecomputeNeighbours()
    End Sub

End Class
