Imports System.Drawing


Module MaskProcess

    Sub Main()
        ImageMaskProcess()
    End Sub


    Private Sub ImageMaskProcess()
        Dim img As Image = Image.FromFile("d:\inbox\check1.jpg")
        img = __DrawRectangle(img, New RectangleF(25, 25, 250, 250), Brushes.Black)
        __DrawRectangle(img, New RectangleF(300, 300, 50, 50), Brushes.Black)
        img.Save("D:\maskedimage.jpg", Imaging.ImageFormat.Jpeg)
    End Sub


    Private Function __DrawRectangle(ByRef Img As Image, ByVal Rect As RectangleF, ByVal brushcolor As Brush) As Image
        Dim intImageWidth As Integer = Img.Width
        Dim intImageHeight As Integer = Img.Height
        If (Img.PixelFormat And Imaging.PixelFormat.Indexed) = Imaging.PixelFormat.Indexed Then
            Img = New Bitmap(Img)
        End If
        Dim g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(Img)
        g.FillRectangle(brushcolor, Rect)
        Return Img
    End Function

   

End Module
