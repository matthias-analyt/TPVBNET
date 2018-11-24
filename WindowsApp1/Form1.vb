Imports System.IO

Public Class Form1

    Dim A_, B_, Ad_, Bd_ As New PointF
    Dim selectedPoint As String = ""
    Dim comptSaveEvent As Integer
    Dim myPen As New Pen(Color.Black)

    Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()
        Me.MinimumSize = Me.Size


        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().

    End Sub

    Private Function translateCoords(ByVal point As Single, ByVal scale As Single) As Single
        Return (point + 1) * scale / 2
    End Function

    Private Function translateInverseCoords(ByVal point As Single, ByVal scale As Single) As Single
        Return (2 * point / scale) - 1
    End Function


    Private Function generatePoints(ByVal nbSeg As Integer, ByVal A As PointF, ByVal Ad As PointF, ByVal B As PointF, ByVal Bd As PointF) As PointF()

        Dim pas As Single = 1 / nbSeg
        Dim result As New List(Of PointF)
        Dim lengh As Single = 0

        For i As Integer = 0 To nbSeg
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

        curveLengh_.Text = "longeur = " & FormatNumber(CDbl(lengh.ToString), 3)


        Return result.ToArray
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




        e.Graphics.DrawLines(myPen, generatePoints(Int(nbSeg_.Value), A_, Ad_, B_, Bd_))
        rect.Location = upperleftRect(rect, A_)
        e.Graphics.FillEllipse(brush, rect)
        rect.Location = upperleftRect(rect, B_)
        e.Graphics.FillEllipse(brush, rect)
        brush.Color = Color.FromArgb(255, 0, 0, 255)
        rect.Location = upperleftRect(rect, Ad_)
        e.Graphics.FillEllipse(brush, rect)
        rect.Location = upperleftRect(rect, Bd_)
        e.Graphics.FillEllipse(brush, rect)
        penDash.Color = Color.FromArgb(255, 0, 0, 255)

        e.Graphics.DrawLine(penDash, Ad_, A_)
        e.Graphics.DrawLine(penDash, Bd_, B_)
        myPen.Color = Color.FromArgb(255, 0, 0, 0)
        penDash.Color = Color.FromArgb(255, 0, 0, 0)
        e.Graphics.DrawRectangle(myPen, frame)
        e.Graphics.DrawLine(penDash, axisXa, axisXb)
        e.Graphics.DrawLine(penDash, axisYa, axisYb)

    End Sub

    Private Sub SplitContainer1_Pannel2_Press(sender As Object, e As MouseEventArgs) Handles SplitContainer1.Panel2.MouseDown
        Dim selectDistance As Single = 25
        If (e.Button = MouseButtons.Left) Then
            Dim point As PointF = e.Location
            Dim distanceFromA_ As Single = distance(point, A_)
            Dim distanceFromB_ As Single = distance(point, B_)
            Dim distanceFromAd_ As Single = distance(point, Ad_)
            Dim distanceFromBd_ As Single = distance(point, Bd_)

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
    End Sub

    Private Sub SplitContainer1_Pannel2_Released(sender As Object, e As MouseEventArgs) Handles SplitContainer1.Panel2.MouseUp
        If (e.Button = MouseButtons.Left And selectedPoint <> "") Then
            Dim point As PointF = e.Location
            Dim distanceFromA_ As Single = distance(point, A_)
            Dim distanceFromB_ As Single = distance(point, B_)
            Dim distanceFromAd_ As Single = distance(point, Ad_)
            Dim distanceFromBd_ As Single = distance(point, Bd_)


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
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click

        ColorDialog1.ShowDialog()
        myPen.Color = ColorDialog1.Color
        reDraw()

    End Sub

    Private Sub AX__ValueChanged(sender As Object, e As EventArgs) Handles AX_.ValueChanged, MyBase.Load, MyBase.Resize
        A_.X = translateCoords(AX_.Value, SplitContainer1.Panel2.Width)
        reDraw()
    End Sub

    Private Sub AY__ValueChanged(sender As Object, e As EventArgs) Handles AY_.ValueChanged, MyBase.Load, MyBase.Resize
        A_.Y = translateCoords(-AY_.Value, SplitContainer1.Panel2.Height)
        reDraw()
    End Sub

    Private Sub AdX__ValueChanged(sender As Object, e As EventArgs) Handles AdX_.ValueChanged, MyBase.Load, MyBase.Resize
        Ad_.X = translateCoords(AdX_.Value, SplitContainer1.Panel2.Width)
        reDraw()
    End Sub

    Private Sub AdY__ValueChanged(sender As Object, e As EventArgs) Handles AdY_.ValueChanged, MyBase.Load, MyBase.Resize
        Ad_.Y = translateCoords(-AdY_.Value, SplitContainer1.Panel2.Height)
        reDraw()
    End Sub

    Private Sub BX__ValueChanged(sender As Object, e As EventArgs) Handles BX_.ValueChanged, MyBase.Load, MyBase.Resize
        B_.X = translateCoords(BX_.Value, SplitContainer1.Panel2.Width)
        reDraw()
    End Sub

    Private Sub BY__ValueChanged(sender As Object, e As EventArgs) Handles BY_.ValueChanged, MyBase.Load, MyBase.Resize
        B_.Y = translateCoords(-BY_.Value, SplitContainer1.Panel2.Height)
        reDraw()
    End Sub

    Private Sub BdX__ValueChanged(sender As Object, e As EventArgs) Handles BdX_.ValueChanged, MyBase.Load, MyBase.Resize
        Bd_.X = translateCoords(BdX_.Value, SplitContainer1.Panel2.Width)
        reDraw()
    End Sub

    Private Sub BdY__ValueChanged(sender As Object, e As EventArgs) Handles BdY_.ValueChanged, MyBase.Load, MyBase.Resize
        Bd_.Y = translateCoords(-BdY_.Value, SplitContainer1.Panel2.Height)
        reDraw()
    End Sub



    Private Sub paint__Click(sender As Object, e As EventArgs)
        reDraw()
    End Sub

    Private Sub nbSeg__ValueChanged(sender As Object, e As EventArgs) Handles nbSeg_.ValueChanged
        reDraw()
    End Sub

    Private Sub reDraw()
        SplitContainer1.Panel2.Refresh()
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
End Class
