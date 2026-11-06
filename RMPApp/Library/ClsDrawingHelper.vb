Imports System.Drawing.Drawing2D
Public Class ClsDrawingHelper
    Public _newColor As Color
    Public Sub GradiantHorizontal(pnl As Object, e As PaintEventArgs, clr1 As Color, clr2 As Color)
        Dim graphics As Graphics = e.Graphics()

        Dim rectBrush As New Rectangle(0, 0, pnl.Width, pnl.Height)
        Dim brush As LinearGradientBrush
        brush = New LinearGradientBrush(rectBrush, clr1, clr2, LinearGradientMode.Horizontal)
        graphics.FillRectangle(brush, rectBrush)
    End Sub
    Public Sub GradiantVertical(pnl As Object, e As PaintEventArgs, clr1 As Color, clr2 As Color)
        Dim graphics As Graphics = e.Graphics()

        Dim rectBrush As New Rectangle(0, 0, pnl.Width, pnl.Height)
        Dim brush As LinearGradientBrush
        brush = New LinearGradientBrush(rectBrush, clr1, clr2, LinearGradientMode.Vertical)
        graphics.FillRectangle(brush, rectBrush)
    End Sub

    Public Sub GradiantForwad(pnl As Object, e As PaintEventArgs, clr1 As Color, clr2 As Color)
        Dim graphics As Graphics = e.Graphics()

        Dim rectBrush As New Rectangle(0, 0, pnl.Width, pnl.Height)
        Dim brush As LinearGradientBrush
        brush = New LinearGradientBrush(rectBrush, clr1, clr2, LinearGradientMode.ForwardDiagonal)
        graphics.FillRectangle(brush, rectBrush)
    End Sub

    Public Sub GradiantBackward(pnl As Object, e As PaintEventArgs, clr1 As Color, clr2 As Color)
        Dim graphics As Graphics = e.Graphics()

        Dim rectBrush As New Rectangle(0, 0, pnl.Width, pnl.Height)
        Dim brush As LinearGradientBrush
        brush = New LinearGradientBrush(rectBrush, clr1, clr2, LinearGradientMode.BackwardDiagonal)
        graphics.FillRectangle(brush, rectBrush)
    End Sub

    Public Sub RoundButton(btn As Object, e As PaintEventArgs)
        Dim grPath As GraphicsPath = New GraphicsPath()
        grPath.AddEllipse(0, 0, btn.width, btn.height)
        btn.region = New System.Drawing.Region(grPath)
    End Sub

    Public Sub RoundPicture(pic As Object, e As PaintEventArgs)
        Dim grPath As GraphicsPath = New GraphicsPath()
        grPath.AddEllipse(0, 0, pic.width, pic.height)
        pic.region = New System.Drawing.Region(grPath)
    End Sub

End Class
