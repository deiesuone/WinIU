Imports System.Runtime.InteropServices
Imports System.Text

Namespace WinIUWindow

    Public Class WindowControl

        ''' <summary>
        ''' アクティブウィンドウの名前を取得する
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetActiveWindowName() As String
            Dim ret As String = String.Empty

            Try
                Dim hWnd As IntPtr = NativeMethods.GetForegroundWindow()
                Dim title As StringBuilder = New StringBuilder(1048)
                NativeMethods.GetWindowText(hWnd, title, 1024)
                ret = title.ToString
            Catch
            End Try

            Return ret
        End Function

    End Class

    Friend NotInheritable Class NativeMethods

        <DllImport("user32.dll")> _
        Public Shared Function GetForegroundWindow() As IntPtr
        End Function

        <DllImport("user32.dll", CharSet:=CharSet.Unicode)> _
        Public Shared Function GetWindowText(ByVal hwnd As IntPtr, ByVal lpString As StringBuilder, ByVal cch As Integer) As Integer
        End Function

    End Class

End Namespace