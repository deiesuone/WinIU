Namespace WinIUSuicide

    Public Class Suicide

#Region "定数"

        ''' <summary>
        ''' OpenProcess用引数
        ''' </summary>
        ''' <remarks></remarks>
        Private Const SYNCHRONIZE = &H100000

        ''' <summary>
        ''' WinExec用引数
        ''' </summary>
        ''' <remarks></remarks>
        Private Const SW_HIDE = 0

#End Region

#Region "静的メソッド"

        ''' <summary>
        ''' 自殺する。
        ''' </summary>
        ''' <param name="bat_path">自殺用バッチファイルの場所。フルパス</param>
        ''' <remarks></remarks>
        Public Shared Sub Start(bat_path As String)

            ' プロセスハンドルを得る
            Dim pHandle As Long = NativeMethods.OpenProcess(SYNCHRONIZE, False, NativeMethods.GetCurrentProcessId)

            ' プロセスハンドルを閉じる
            NativeMethods.CloseHandle(pHandle)

            ' バッチファイルで自殺開始
            NativeMethods.WinExec(String.Concat("""", bat_path, """"), SW_HIDE)

        End Sub

#End Region

    End Class

    Friend NotInheritable Class NativeMethods

#Region "Win32API"

        Public Declare Function OpenProcess Lib "kernel32" (ByVal dwDesiredAccess As Integer, ByVal bInheritHandle As Integer, ByVal dwProcessId As Integer) As UIntPtr
        Public Declare Function CloseHandle Lib "kernel32" (ByVal hObject As IntPtr) As UInteger
        Public Declare Function WinExec Lib "kernel32" (ByVal lpCmdLine As String, ByVal nCmdShow As Integer) As Integer
        Public Declare Function GetCurrentProcessId Lib "kernel32" () As Integer

#End Region

    End Class

End Namespace