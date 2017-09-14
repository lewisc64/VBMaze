Public Class Grid

    Public display As VBGame.DrawBase
    Private background As VBGame.BitmapSurface
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
    Public ReadOnly Property solutionColor As Color
        Get
            Dim out As New VBGame.Colors.HSV
            Dim wall As New VBGame.Colors.HSV(wallColor)
            Dim path As New VBGame.Colors.HSV(pathColor)
            out.H = (wall.H + path.H) / 2 + 180
            out.S = 100
            out.V = Math.Max(wall.V, path.V)
            Return out.toRGB()
        End Get
    End Property

    Public wallType As RenderStyle = RenderStyle.Rounded

    Enum RenderStyle
        Rounded
        Sharp
    End Enum

    Public Sub New(ByRef display As VBGame.DrawBase, spacing As Integer)
        Me.display = display
        Me.spacing = spacing
        Me.thickness = spacing / 2
        Me.neighbouring = spacing
        background = New VBGame.BitmapSurface(display.getRect().Size)
    End Sub

    Public Sub DrawBackground()
        DrawBackground(display)
    End Sub

    Public Sub DrawSolution(ByRef surface As VBGame.DrawBase, start As Integer, finish As Integer, Optional current As Integer = -1)
        If current = -1 Then
            current = finish
        End If

        Try

            surface.drawLine(nodes(current).GetXY(), nodes(nodes(current).parent).GetXY(), solutionColor, thickness)
            surface.drawCircle(New VBGame.Circle(nodes(current).GetXY(), thickness / 2), solutionColor)
            surface.drawCircle(New VBGame.Circle(nodes(nodes(current).parent).GetXY(), thickness / 2), solutionColor)

            dirtyNodes.Add(current)
            dirtyNodes.Add(nodes(current).parent)
            dirtyConnections.Add({nodes(current).parent, current})
            If nodes(current).parent <> start Then
                DrawSolution(surface, start, finish, nodes(current).parent)
            End If
        Catch ex As ArgumentOutOfRangeException
        End Try
    End Sub

    Public Sub DrawBackground(surface As VBGame.DrawBase)
        surface.blit(background.getImage(), New Point(0, 0))
    End Sub

    Public Sub Draw()
        Draw(display)
    End Sub

    Private Sub DrawNodes(surface As VBGame.DrawBase, list As List(Of Node))
        Select Case wallType
            Case RenderStyle.Rounded
                For Each Node As Node In list
                    surface.drawCircle(New VBGame.Circle(Node.x, Node.y, thickness / 2), pathColor)
                Next
            Case RenderStyle.Sharp
                For Each Node As Node In list
                    surface.drawRect(New Rectangle(Node.x - thickness / 2, Node.y - thickness / 2, thickness, thickness), pathColor)
                Next
        End Select
    End Sub

    Private Sub DrawNodes(surface As VBGame.DrawBase, list As List(Of Integer))
        Dim out As New List(Of Node)
        For Each x As Integer In list
            out.Add(nodes(x))
        Next
        DrawNodes(surface, out)
    End Sub

    Private Sub DrawConnections(surface As VBGame.DrawBase, list As List(Of Array))
        For Each connection As Array In list
            surface.drawLine(nodes(connection(0)).GetXY(), nodes(connection(1)).GetXY(), pathColor, thickness)
        Next
    End Sub

    Public Sub Draw(surface As VBGame.DrawBase, Optional solution As Boolean = False, Optional start As Integer = -1, Optional finish As Integer = -1)
        DrawBackground(surface)
        DrawNodes(surface, nodes)
        DrawConnections(surface, connections)
        If solution Then
            DrawSolution(display, start, If(nodes(finish).parent = -1, connected.Last, finish))
        End If
    End Sub

    Public Sub DrawDirty()
        DrawNodes(display, dirtyNodes)
        DrawConnections(display, dirtyConnections)
        dirtyNodes.Clear()
        dirtyConnections.Clear()
    End Sub

    Public Function GetDistance(node1 As Node, node2 As Node) As Double
        Return Math.Sqrt(Math.Pow(node1.x - node2.x, 2) + Math.Pow(node1.y - node2.y, 2))
    End Function

    Public Function GetNeighbours(node As Integer) As List(Of Integer)
        Dim neighbours As New List(Of Integer)
        For i As Integer = 0 To nodes.Count - 1
            If nodes(i) <> nodes(node) AndAlso GetDistance(nodes(node), nodes(i)) <= neighbouring Then
                neighbours.Add(i)
            End If
        Next
        Return neighbours
    End Function

    Public Function RetrieveNeighbours(node As Integer) As List(Of Integer)
        Dim neighbours As New List(Of Integer)
        neighbours = nodes(node).neighbours
        For Each i As Integer In neighbours.ToList()
            If connected.Contains(i) Then
                neighbours.Remove(i)
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
        background.fill(wallColor)
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
        background.fill(wallColor)
        Dim bar As New ProgressBar("Generating isometric grid...", (display.width * display.height) / spacing ^ 2, 100)
        nodes.Clear()
        connections.Clear()
        dirtyNodes.Clear()
        dirtyConnections.Clear()
        connected.Clear()
        neighbouring = spacing + spacing / 7
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

    Public Sub GenerateCircular()
        display.fill(VBGame.Colors.black)
        background.fill(VBGame.Colors.white)
        background.drawCircle(New VBGame.Circle(background.getCenter(), (Math.Min(background.width, background.height) - spacing / 2) / 2), wallColor)
        background.drawCircle(New VBGame.Circle(background.getCenter(), spacing * 2), pathColor)
        Dim bar As New ProgressBar("Generating circular grid...", (display.width * display.height) / spacing ^ 2, 100)
        nodes.Clear()
        connections.Clear()
        dirtyNodes.Clear()
        dirtyConnections.Clear()
        connected.Clear()
        neighbouring = spacing + 2
        Dim angleStep As Integer
        For radius As Integer = Math.Min(display.width, display.height) / 2 - spacing To spacing * 2 Step -spacing
            angleStep = CInt(360 * (spacing / (Math.PI * radius * 2)))
            For angle As Integer = 0 To 360 - angleStep / 2 Step angleStep
                nodes.Add(New Node((display.width / 2) + Math.Cos(angle * (Math.PI / 180)) * radius, (display.height / 2) + Math.Sin(angle * (Math.PI / 180)) * radius))
                bar.Update(display)
            Next
        Next
        nodes.Add(New Node(display.width / 2, display.height / 2))
        PrecomputeNeighbours()
    End Sub

    Private Function ScrambleList(ByVal l1 As List(Of Integer)) As List(Of Integer)
        l1 = l1.ToList()
        Dim l2 As New List(Of Integer)
        Dim i As Integer
        For x As Integer = 1 To l1.Count
            i = random.Next(0, l1.Count)
            l2.Add(l1(i))
            l1.RemoveAt(i)
        Next
        Return l2
    End Function

    Private Sub GeneratePoint(x As Integer, y As Integer, Optional n As Integer = -1, Optional validAngles As List(Of Integer) = Nothing)

        If IsNothing(validAngles) Then
            validAngles = New List(Of Integer)
            Dim angleStep As Integer = CInt(360 / (Math.PI * 2))
            For a As Integer = 0 To 360 - angleStep Step angleStep
                validAngles.Add(a)
            Next
        End If

        Dim angle, tx, ty, anglegap As Integer
        anglegap = validAngles(1)
        Dim valid As Boolean = False

        nodes.Add(New Node(x, y))
        'If n <> -1 Then
        '    nodes(n).neighbours.Add(nodes.Count - 1)
        '    nodes(nodes.Count - 1).neighbours.Add(n)
        'End If
        n += 1

        For Each trueAngle As Integer In ScrambleList(validAngles)
            angle = trueAngle + random.Next(0, anglegap / 2) * random.Next(-1, 2)
            tx = x + Math.Cos(angle * (Math.PI / 180)) * spacing
            ty = y + Math.Sin(angle * (Math.PI / 180)) * spacing
            If tx < spacing OrElse tx > display.width - spacing OrElse ty < spacing OrElse ty > display.height - spacing Then
                Continue For
            End If
            valid = True
            For Each Node As Node In nodes
                If GetDistance(Node, New Node(tx, ty)) < spacing Then
                    valid = False
                End If
            Next
            If valid Then
                GeneratePoint(tx, ty, n, validAngles)
            End If
        Next

    End Sub

    Public Sub GenerateRandom()
        display.fill(VBGame.Colors.black)
        background.fill(wallColor)
        Dim bar As New ProgressBar("Generating random grid...", (display.width * display.height) / spacing ^ 2, 100)
        nodes.Clear()
        connections.Clear()
        dirtyNodes.Clear()
        dirtyConnections.Clear()
        connected.Clear()
        neighbouring = spacing + 1

        bar.Update(display)
        GeneratePoint(spacing, spacing)

        nodes.Add(New Node(display.width - spacing, display.height - spacing))
        GetNeighbours(nodes.Count - 1)
        PrecomputeNeighbours()
    End Sub

    'Public Sub GenerateRandom()
    '    display.fill(VBGame.Colors.black)
    '    background.fill(VBGame.Colors.black)
    '    Dim bar As New ProgressBar("Generating random grid...", (display.width * display.height) / spacing ^ 2, 100)
    '    nodes.Clear()
    '    connections.Clear()
    '    dirtyNodes.Clear()
    '    dirtyConnections.Clear()
    '    connected.Clear()
    '    neighbouring = spacing * 1.5
    '    nodes.Add(New Node(spacing, spacing))
    '    Dim x, y, attempts As Integer
    '    For n As Integer = 1 To (display.width * display.height) / spacing
    '        attempts = 0
    '        While True
    '            If attempts > 1000 Then
    '                Exit For
    '            End If
    '            x = random.Next(spacing, display.width - spacing)
    '            y = random.Next(spacing, display.height - spacing)
    '            If nodes.Count = 0 Then
    '                Exit While
    '            End If
    '            For Each Node As Node In nodes
    '                If GetDistance(Node, New Node(x, y)) < spacing Then
    '                    attempts += 1
    '                    Continue While
    '                End If
    '            Next
    '            Exit While
    '        End While
    '        nodes.Add(New Node(x, y))
    '        bar.Update(display)
    '    Next
    '    nodes.Add(New Node(display.width - spacing, display.height - spacing))
    '    PrecomputeNeighbours()
    'End Sub

End Class
