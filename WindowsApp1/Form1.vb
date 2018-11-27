Imports System.IO

Public Class Form1

    Dim selectedPoint As String = ""
    Dim comptSaveEvent As Integer
    Dim myPen As New Pen(Color.Black)

    Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()
        Me.MinimumSize = Me.Size

        Dim A, B, Ad, Bd As New PointF(SplitContainer1.Panel2.Width / 2, SplitContainer1.Panel2.Height / 2)

        ListBox1.Items.Add(New Bezier(A, B, Ad, Bd))
        ListBox1.Items.Add(New Bezier(A, B, Ad, Bd))


        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().

    End Sub

    Private Function getCurrentCurve() As Bezier
        Return CType(ListBox1.SelectedItem, Bezier)
    End Function

    Private Function getCurrentCurves() As List(Of Bezier)
        Dim items As New List(Of Bezier)
        For Each item As Object In ListBox1.Items
            items.Add(CType(item, Bezier))
        Next

        Return items
    End Function


    Private Function translateCoords(ByVal point As Single, ByVal scale As Single) As Single
        Return (point + 1) * scale / 2
    End Function

    Private Function translateInverseCoords(ByVal point As Single, ByVal scale As Single) As Single
        Return (2 * point / scale) - 1
    End Function


    Private Function generatePoints(ByVal nbSeg As Integer, ByVal A As PointF, ByVal Ad As PointF, ByVal B As PointF, ByVal Bd As PointF, ByRef curve As Bezier) As PointF()
        If getCurrentCurve() IsNot Nothing Then
            Dim pas As Single = 1 / curve.nbseg
            Dim result As New List(Of PointF)
            Dim lengh As Single = 0

            For i As Integer = 0 To curve.nbseg
                result.Add(bezierCoord(i * pas, A, Ad, B, Bd))

                If i > 0 Then
                    Dim p1 As PointF = result.ElementAt(i)
                    p1.X = translateInverseCoords(p1.X, SplitContainer1.Panel2.Width)
                    p1.Y = translateInverseCoords(p1.Y, SplitContainer1.Panel2.Height)
                    Dim p2 As PointF = result.ElementAt(i - 1)
                    p2.X = translateInverseCoords(p2.X, SplitContainer1.Panel2.Width)
                    p2.Y = translateInverseCoords(p2.Y, SplitContainer1.Panel2.Height)

                    lengh += System.Math.Sqrt((p1.X - p2.X) ^ 2 + (p1.Y - p2.Y) ^ 2)
                End If
            Next
            If curve.Equals(getCurrentCurve()) Then
                curveLengh_.Text = "longeur = " & FormatNumber(CDbl(lengh.ToString), 3)
            End If



            Return result.ToArray
        End If
    End Function

    Private Function bezierCoord(ByVal t As Single, ByVal A As PointF, ByVal Ad As PointF, ByVal B As PointF, ByVal Bd As PointF) As PointF

        Dim point As New PointF

        point.X = ((1 - t) ^ 3) * A.X + 3 * t * ((1 - t) ^ 2) * Ad.X + 3 * (t ^ 2) * (1 - t) * Bd.X + (t ^ 3) * B.X
        point.Y = ((1 - t) ^ 3) * A.Y + 3 * t * ((1 - t) ^ 2) * Ad.Y + 3 * (t ^ 2) * (1 - t) * Bd.Y + (t ^ 3) * B.Y

        Return point
    End Function
    Private Function distance(ByVal X As PointF, ByVal Y As PointF) As Single
        Return System.Math.Sqrt((X.X - Y.X) ^ 2 + (X.Y - Y.Y) ^ 2)
    End Function
    Private Function upperleftRect(ByVal rect As RectangleF, ByVal point As PointF) As PointF

        Dim result As PointF
        result.X = point.X - rect.Width / 2
        result.Y = point.Y - rect.Height / 2

        Return result
    End Function

    Private Sub SplitContainer1_Panel2_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel2.Paint

        Dim axisXa, axisXb, axisYa, axisYb As PointF
        axisXa.X = translateCoords(-1, SplitContainer1.Panel2.Width)
        axisXa.Y = translateCoords(0, SplitContainer1.Panel2.Height)

        axisXb.X = translateCoords(1, SplitContainer1.Panel2.Width)
        axisXb.Y = translateCoords(0, SplitContainer1.Panel2.Height)

        axisYa.X = translateCoords(0, SplitContainer1.Panel2.Width)
        axisYa.Y = translateCoords(-1, SplitContainer1.Panel2.Height)

        axisYb.X = translateCoords(0, SplitContainer1.Panel2.Width)
        axisYb.Y = translateCoords(1, SplitContainer1.Panel2.Height)


        Dim penDash As New Pen(Color.FromArgb(255, 0, 0, 0))
        penDash.DashPattern = {5, 5, 5, 5}
        Dim brush As New SolidBrush(Color.FromArgb(255, 255, 0, 0))

        Dim rect As New RectangleF
        rect.Width = 5
        rect.Height = 5

        Dim frame As New Rectangle
        frame.Width = SplitContainer1.Panel2.Width - 1
        frame.Height = SplitContainer1.Panel2.Height - 1
        frame.X = 0
        frame.Y = 0


        ' Iterate through the list.
        For Each courbe As Bezier In getCurrentCurves()
            ' e.Graphics.DrawLines(myPen, generatePoints(Int(nbSeg_.Value), courbe.A, courbe.Ad, courbe.B, courbe.Bd, courbe))
            Dim p() As PointF
            p = generatePoints(Int(nbSeg_.Value), courbe.A, courbe.Ad, courbe.B, courbe.Bd, courbe)

            Try
                e.Graphics.DrawLines(myPen, p)

            Catch ex As Exception

            End Try
            rect.Location = upperleftRect(rect, courbe.A)
            e.Graphics.FillEllipse(brush, rect)
            rect.Location = upperleftRect(rect, courbe.B)
            e.Graphics.FillEllipse(brush, rect)
            brush.Color = Color.FromArgb(255, 0, 0, 255)
            rect.Location = upperleftRect(rect, courbe.Ad)
            e.Graphics.FillEllipse(brush, rect)
            rect.Location = upperleftRect(rect, courbe.Bd)
            e.Graphics.FillEllipse(brush, rect)
            penDash.Color = Color.FromArgb(255, 0, 0, 255)

            e.Graphics.DrawLine(penDash, courbe.Ad, courbe.A)
            e.Graphics.DrawLine(penDash, courbe.Bd, courbe.B)
        Next



        myPen.Color = Color.FromArgb(255, 0, 0, 0)
        penDash.Color = Color.FromArgb(255, 0, 0, 0)
        '
        e.Graphics.DrawRectangle(myPen, frame)
        e.Graphics.DrawLine(penDash, axisXa, axisXb)
        e.Graphics.DrawLine(penDash, axisYa, axisYb)

    End Sub

    Private Sub SplitContainer1_Pannel2_Press(sender As Object, e As MouseEventArgs) Handles SplitContainer1.Panel2.MouseDown
        If getCurrentCurve() IsNot Nothing Then
            Dim selectDistance As Single = 25
            If (e.Button = MouseButtons.Left) Then
                Dim point As PointF = e.Location
                Dim distanceFromA_ As Single = distance(point, getCurrentCurve.A)
                Dim distanceFromB_ As Single = distance(point, getCurrentCurve.B)
                Dim distanceFromAd_ As Single = distance(point, getCurrentCurve.Ad)
                Dim distanceFromBd_ As Single = distance(point, getCurrentCurve.Bd)

                If (distanceFromA_ < selectDistance) Then
                    selectedPoint = "A"
                ElseIf (distanceFromB_ < selectDistance) Then
                    selectedPoint = "B"
                ElseIf (distanceFromAd_ < selectDistance) Then
                    selectedPoint = "Ad"
                ElseIf (distanceFromBd_ < selectDistance) Then
                    selectedPoint = "Bd"
                Else
                    selectedPoint = ""
                End If
            End If
        End If
    End Sub

    Private Sub SplitContainer1_Pannel2_Released(sender As Object, e As MouseEventArgs) Handles SplitContainer1.Panel2.MouseMove
        If getCurrentCurve() IsNot Nothing Then
            If (e.Button = MouseButtons.Left And selectedPoint <> "" And SplitContainer1.Panel2.DisplayRectangle.Contains(e.Location)) Then
                Dim point As PointF = e.Location
                Dim distanceFromA_ As Single = distance(point, getCurrentCurve.A)
                Dim distanceFromB_ As Single = distance(point, getCurrentCurve.B)
                Dim distanceFromAd_ As Single = distance(point, getCurrentCurve.Ad)
                Dim distanceFromBd_ As Single = distance(point, getCurrentCurve.Bd)


                If (selectedPoint = "A") Then
                    AX_.Value = translateInverseCoords(e.Location.X, SplitContainer1.Panel2.Width)
                    AY_.Value = -translateInverseCoords(e.Location.Y, SplitContainer1.Panel2.Height)
                ElseIf (selectedPoint = "Ad") Then
                    AdX_.Value = translateInverseCoords(e.Location.X, SplitContainer1.Panel2.Width)
                    AdY_.Value = -translateInverseCoords(e.Location.Y, SplitContainer1.Panel2.Height)
                ElseIf (selectedPoint = "B") Then
                    BX_.Value = translateInverseCoords(e.Location.X, SplitContainer1.Panel2.Width)
                    BY_.Value = -translateInverseCoords(e.Location.Y, SplitContainer1.Panel2.Height)
                ElseIf (selectedPoint = "Bd") Then
                    BdX_.Value = translateInverseCoords(e.Location.X, SplitContainer1.Panel2.Width)
                    BdY_.Value = -translateInverseCoords(e.Location.Y, SplitContainer1.Panel2.Height)
                End If
            End If
        End If
    End Sub


    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click

        ColorDialog1.ShowDialog()
        myPen.Color = ColorDialog1.Color
        reDraw()

    End Sub

    Private Sub AX__ValueChanged(sender As Object, e As EventArgs) Handles AX_.ValueChanged, MyBase.Resize

        If getCurrentCurve() IsNot Nothing Then
            Dim point As New PointF
            point = getCurrentCurve.A
            point.X = translateCoords(AX_.Value, SplitContainer1.Panel2.Width)
            getCurrentCurve.A = point
            reDraw()
        End If

    End Sub

    Private Sub AY__ValueChanged(sender As Object, e As EventArgs) Handles AY_.ValueChanged, MyBase.Resize



        If getCurrentCurve() IsNot Nothing Then
            Dim point As New PointF
            point = getCurrentCurve.A
            point.Y = translateCoords(-AY_.Value, SplitContainer1.Panel2.Height)
            getCurrentCurve.A = point

            reDraw()
        End If

    End Sub

    Private Sub AdX__ValueChanged(sender As Object, e As EventArgs) Handles AdX_.ValueChanged, MyBase.Resize



        If getCurrentCurve() IsNot Nothing Then
            Dim point As New PointF
            point = getCurrentCurve.Ad
            point.X = translateCoords(AdX_.Value, SplitContainer1.Panel2.Width)
            getCurrentCurve.Ad = point
            reDraw()
        End If

    End Sub

    Private Sub AdY__ValueChanged(sender As Object, e As EventArgs) Handles AdY_.ValueChanged, MyBase.Resize



        If getCurrentCurve() IsNot Nothing Then
            Dim point As New PointF
            point = getCurrentCurve.Ad
            point.Y = translateCoords(-AdY_.Value, SplitContainer1.Panel2.Height)
            getCurrentCurve.Ad = point

            reDraw()
        End If

    End Sub

    Private Sub BX__ValueChanged(sender As Object, e As EventArgs) Handles BX_.ValueChanged, MyBase.Resize
        '   B_.X = translateCoords(BX_.Value, SplitContainer1.Panel2.Width)

        If getCurrentCurve() IsNot Nothing Then
            Dim point As New PointF
            point = getCurrentCurve.B
            point.X = translateCoords(BX_.Value, SplitContainer1.Panel2.Width)
            getCurrentCurve.B = point

            reDraw()
        End If

    End Sub

    Private Sub BY__ValueChanged(sender As Object, e As EventArgs) Handles BY_.ValueChanged, MyBase.Resize

        If getCurrentCurve() IsNot Nothing Then
            Dim point As New PointF
            point = getCurrentCurve.B
            point.Y = translateCoords(-BY_.Value, SplitContainer1.Panel2.Height)
            getCurrentCurve.B = point

            reDraw()
        End If

    End Sub

    Private Sub BdX__ValueChanged(sender As Object, e As EventArgs) Handles BdX_.ValueChanged, MyBase.Resize
        ' Bd_.X = translateCoords(BdX_.Value, SplitContainer1.Panel2.Width)

        If getCurrentCurve() IsNot Nothing Then
            Dim point As New PointF
            point = getCurrentCurve.Bd
            point.X = translateCoords(BdX_.Value, SplitContainer1.Panel2.Width)
            getCurrentCurve.Bd = point

            reDraw()
        End If

    End Sub

    Private Sub BdY__ValueChanged(sender As Object, e As EventArgs) Handles BdY_.ValueChanged, MyBase.Resize
        '   Bd_.Y = translateCoords(-BdY_.Value, SplitContainer1.Panel2.Height)

        If getCurrentCurve() IsNot Nothing Then
            Dim point As New PointF
            point = getCurrentCurve.Bd
            point.Y = translateCoords(-BdY_.Value, SplitContainer1.Panel2.Height)
            getCurrentCurve.Bd = point

            reDraw()
        End If

    End Sub



    Private Sub paint__Click(sender As Object, e As EventArgs)
        reDraw()
    End Sub

    Private Sub nbSeg__ValueChanged(sender As Object, e As EventArgs) Handles nbSeg_.ValueChanged
        If getCurrentCurve() IsNot Nothing Then
            getCurrentCurve.nbseg = nbSeg_.Value
        End If

        reDraw()
    End Sub

    Private Sub reDraw()
        SplitContainer1.Panel2.Refresh()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click

        Dim myPath As String
        SaveFileDialog1.FileName = "myText"

        SaveFileDialog1.DefaultExt = "csv"
        SaveFileDialog1.Filter = "Csv files (*.csv)|*.csv|All files (*.*)|*.*"
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then

            myPath = SaveFileDialog1.FileName
            Try




                If File.Exists(myPath) Then
                    File.Delete(myPath)
                End If

                Dim sw As New StreamWriter(myPath)
                Dim s As String = String.Empty

                s = AX_.Value.ToString + ";" + AY_.Value.ToString + ";" + BX_.Value.ToString + ";" + BY_.Value.ToString + ";" + AdX_.Value.ToString + ";" + AdY_.Value.ToString + ";" + BdX_.Value.ToString + ";" + BdY_.Value.ToString + ";" + nbSeg_.Value.ToString


                sw.Write(s)
                sw.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try



        End If



    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click

        Dim myPath As String
        OpenFileDialog1.FileName = "myText"

        OpenFileDialog1.DefaultExt = "csv"
        OpenFileDialog1.Filter = "Csv files (*.csv)|*.csv|All files (*.*)|*.*"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

            myPath = OpenFileDialog1.FileName
            Try

                Dim fileReader As String
                fileReader = My.Computer.FileSystem.ReadAllText(myPath)

                Dim csvRead() As String = Split(fileReader, ";")

                If csvRead.Count = 9 Then
                    AX_.Value = Single.Parse(csvRead(0))
                    AY_.Value = Single.Parse(csvRead(1))
                    BX_.Value = Single.Parse(csvRead(2))
                    BY_.Value = Single.Parse(csvRead(3))
                    AdX_.Value = Single.Parse(csvRead(4))
                    AdY_.Value = Single.Parse(csvRead(5))
                    BdX_.Value = Single.Parse(csvRead(6))
                    BdY_.Value = Single.Parse(csvRead(7))
                    nbSeg_.Value = Single.Parse(csvRead(8))
                End If


            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

        Dim myPath As String

        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            myPath = FolderBrowserDialog1.SelectedPath
        Else
            myPath = ""
        End If

        myPath = createFolder(myPath)
        comptSaveEvent = My.Computer.FileSystem.GetFiles(myPath, FileIO.SearchOption.SearchTopLevelOnly, "screenshot*").Count
        TakeScreenShot(SplitContainer1.Panel2).Save(myPath + "\screenshot_" + comptSaveEvent.ToString + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg)

        MsgBox("courbe sauvegardée dans le répertoire : " + myPath)
    End Sub

    Private Function TakeScreenShot(ByVal Control As Control) As Bitmap
        Dim tmpImg As New Bitmap(Control.Width, Control.Height)
        Using g As Graphics = Graphics.FromImage(tmpImg)
            g.CopyFromScreen(SplitContainer1.Panel2.PointToScreen(New Point(0, 0)), New Point(0, 0), New Size(SplitContainer1.Panel2.Width, SplitContainer1.Panel2.Height))
        End Using
        Return tmpImg
    End Function

    Private Function createFolder(mypath As String) As String


        Dim todaysdate As String = DateTime.Today.ToString("yyyy-MM-dd")
        mypath = mypath + "\" + todaysdate


        'Création du répertoire de sauvegarde
        If (Not System.IO.Directory.Exists(mypath)) Then
            System.IO.Directory.CreateDirectory(mypath)
        End If

        Return mypath

    End Function

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If getCurrentCurve() IsNot Nothing Then
            Dim b As Bezier = getCurrentCurve()
            Dim w As Single = SplitContainer1.Panel2.Width
            Dim h As Single = SplitContainer1.Panel2.Height


            nbSeg_.Value = b.nbseg
            AX_.Value = (2 * b.A.X / w) - 1
            AY_.Value = -((2 * b.A.Y / h) - 1)
            AdX_.Value = (2 * b.Ad.X / w) - 1
            AdY_.Value = -((2 * b.Ad.Y / h) - 1)
            BX_.Value = (2 * b.B.X / w) - 1
            BY_.Value = -((2 * b.B.Y / h) - 1)
            BdX_.Value = (2 * b.Bd.X / w) - 1
            BdY_.Value = -((2 * b.Bd.Y / h) - 1)

        End If
    End Sub
End Class
