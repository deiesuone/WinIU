<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.grpServer = New System.Windows.Forms.GroupBox()
        Me.btnFileTestConnect = New System.Windows.Forms.Button()
        Me.lblFileDir = New System.Windows.Forms.Label()
        Me.txtFileDir = New System.Windows.Forms.TextBox()
        Me.btnKeyTestConnect = New System.Windows.Forms.Button()
        Me.lblKeyDir = New System.Windows.Forms.Label()
        Me.txtKeyDir = New System.Windows.Forms.TextBox()
        Me.lblImgDir = New System.Windows.Forms.Label()
        Me.txtImgDir = New System.Windows.Forms.TextBox()
        Me.btnImgTestConnect = New System.Windows.Forms.Button()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.lblHost = New System.Windows.Forms.Label()
        Me.menuMain = New System.Windows.Forms.MenuStrip()
        Me.FileFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitXToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpHToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InfoIToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.grpImage = New System.Windows.Forms.GroupBox()
        Me.chkRun = New System.Windows.Forms.CheckBox()
        Me.lblInterval = New System.Windows.Forms.Label()
        Me.txtInterval = New System.Windows.Forms.TextBox()
        Me.lblKeyCapInterval = New System.Windows.Forms.Label()
        Me.txtKeyInterval = New System.Windows.Forms.TextBox()
        Me.btnRestore = New System.Windows.Forms.Button()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.btnClean = New System.Windows.Forms.Button()
        Me.grpAutoRun = New System.Windows.Forms.GroupBox()
        Me.btnBrowsAutoRunDir = New System.Windows.Forms.Button()
        Me.lblWinIUDir = New System.Windows.Forms.Label()
        Me.txtAutoRunDir = New System.Windows.Forms.TextBox()
        Me.chkKeyRun = New System.Windows.Forms.CheckBox()
        Me.grpKeyboard = New System.Windows.Forms.GroupBox()
        Me.grpFTP = New System.Windows.Forms.GroupBox()
        Me.chkFTPRun = New System.Windows.Forms.CheckBox()
        Me.lblFTPInterval = New System.Windows.Forms.Label()
        Me.txtFTPInterval = New System.Windows.Forms.TextBox()
        Me.grpOneSelf = New System.Windows.Forms.GroupBox()
        Me.chkIsDelete = New System.Windows.Forms.CheckBox()
        Me.grpServer.SuspendLayout()
        Me.menuMain.SuspendLayout()
        Me.grpImage.SuspendLayout()
        Me.grpAutoRun.SuspendLayout()
        Me.grpKeyboard.SuspendLayout()
        Me.grpFTP.SuspendLayout()
        Me.grpOneSelf.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(80, 23)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(242, 19)
        Me.txtAddress.TabIndex = 1
        '
        'grpServer
        '
        Me.grpServer.Controls.Add(Me.btnFileTestConnect)
        Me.grpServer.Controls.Add(Me.lblFileDir)
        Me.grpServer.Controls.Add(Me.txtFileDir)
        Me.grpServer.Controls.Add(Me.btnKeyTestConnect)
        Me.grpServer.Controls.Add(Me.lblKeyDir)
        Me.grpServer.Controls.Add(Me.txtKeyDir)
        Me.grpServer.Controls.Add(Me.lblImgDir)
        Me.grpServer.Controls.Add(Me.txtImgDir)
        Me.grpServer.Controls.Add(Me.btnImgTestConnect)
        Me.grpServer.Controls.Add(Me.lblPassword)
        Me.grpServer.Controls.Add(Me.txtPassword)
        Me.grpServer.Controls.Add(Me.lblUser)
        Me.grpServer.Controls.Add(Me.txtUser)
        Me.grpServer.Controls.Add(Me.lblHost)
        Me.grpServer.Controls.Add(Me.txtAddress)
        Me.grpServer.Location = New System.Drawing.Point(12, 239)
        Me.grpServer.Name = "grpServer"
        Me.grpServer.Size = New System.Drawing.Size(455, 186)
        Me.grpServer.TabIndex = 5
        Me.grpServer.TabStop = False
        Me.grpServer.Text = "FTP Server"
        '
        'btnFileTestConnect
        '
        Me.btnFileTestConnect.Location = New System.Drawing.Point(328, 153)
        Me.btnFileTestConnect.Name = "btnFileTestConnect"
        Me.btnFileTestConnect.Size = New System.Drawing.Size(121, 23)
        Me.btnFileTestConnect.TabIndex = 14
        Me.btnFileTestConnect.Text = "Connection Test"
        Me.btnFileTestConnect.UseVisualStyleBackColor = True
        '
        'lblFileDir
        '
        Me.lblFileDir.AutoSize = True
        Me.lblFileDir.Location = New System.Drawing.Point(17, 158)
        Me.lblFileDir.Name = "lblFileDir"
        Me.lblFileDir.Size = New System.Drawing.Size(43, 12)
        Me.lblFileDir.TabIndex = 12
        Me.lblFileDir.Text = "File Dir"
        '
        'txtFileDir
        '
        Me.txtFileDir.Location = New System.Drawing.Point(80, 155)
        Me.txtFileDir.Name = "txtFileDir"
        Me.txtFileDir.Size = New System.Drawing.Size(242, 19)
        Me.txtFileDir.TabIndex = 13
        '
        'btnKeyTestConnect
        '
        Me.btnKeyTestConnect.Location = New System.Drawing.Point(328, 125)
        Me.btnKeyTestConnect.Name = "btnKeyTestConnect"
        Me.btnKeyTestConnect.Size = New System.Drawing.Size(121, 23)
        Me.btnKeyTestConnect.TabIndex = 11
        Me.btnKeyTestConnect.Text = "Connection Test"
        Me.btnKeyTestConnect.UseVisualStyleBackColor = True
        '
        'lblKeyDir
        '
        Me.lblKeyDir.AutoSize = True
        Me.lblKeyDir.Location = New System.Drawing.Point(17, 130)
        Me.lblKeyDir.Name = "lblKeyDir"
        Me.lblKeyDir.Size = New System.Drawing.Size(43, 12)
        Me.lblKeyDir.TabIndex = 9
        Me.lblKeyDir.Text = "Key Dir"
        '
        'txtKeyDir
        '
        Me.txtKeyDir.Location = New System.Drawing.Point(80, 127)
        Me.txtKeyDir.Name = "txtKeyDir"
        Me.txtKeyDir.Size = New System.Drawing.Size(242, 19)
        Me.txtKeyDir.TabIndex = 10
        '
        'lblImgDir
        '
        Me.lblImgDir.AutoSize = True
        Me.lblImgDir.Location = New System.Drawing.Point(17, 103)
        Me.lblImgDir.Name = "lblImgDir"
        Me.lblImgDir.Size = New System.Drawing.Size(54, 12)
        Me.lblImgDir.TabIndex = 6
        Me.lblImgDir.Text = "Image Dir"
        '
        'txtImgDir
        '
        Me.txtImgDir.Location = New System.Drawing.Point(80, 100)
        Me.txtImgDir.Name = "txtImgDir"
        Me.txtImgDir.Size = New System.Drawing.Size(242, 19)
        Me.txtImgDir.TabIndex = 7
        '
        'btnImgTestConnect
        '
        Me.btnImgTestConnect.Location = New System.Drawing.Point(328, 98)
        Me.btnImgTestConnect.Name = "btnImgTestConnect"
        Me.btnImgTestConnect.Size = New System.Drawing.Size(121, 23)
        Me.btnImgTestConnect.TabIndex = 8
        Me.btnImgTestConnect.Text = "Connection Test"
        Me.btnImgTestConnect.UseVisualStyleBackColor = True
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(17, 78)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(54, 12)
        Me.lblPassword.TabIndex = 4
        Me.lblPassword.Text = "Password"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(80, 75)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(242, 19)
        Me.txtPassword.TabIndex = 5
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(17, 53)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(29, 12)
        Me.lblUser.TabIndex = 2
        Me.lblUser.Text = "User"
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(80, 50)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(242, 19)
        Me.txtUser.TabIndex = 3
        '
        'lblHost
        '
        Me.lblHost.AutoSize = True
        Me.lblHost.Location = New System.Drawing.Point(17, 26)
        Me.lblHost.Name = "lblHost"
        Me.lblHost.Size = New System.Drawing.Size(29, 12)
        Me.lblHost.TabIndex = 0
        Me.lblHost.Text = "Host"
        '
        'menuMain
        '
        Me.menuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileFToolStripMenuItem, Me.HelpHToolStripMenuItem})
        Me.menuMain.Location = New System.Drawing.Point(0, 0)
        Me.menuMain.Name = "menuMain"
        Me.menuMain.Size = New System.Drawing.Size(479, 26)
        Me.menuMain.TabIndex = 0
        Me.menuMain.Text = "MenuStrip1"
        '
        'FileFToolStripMenuItem
        '
        Me.FileFToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportToolStripMenuItem, Me.ImportToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitXToolStripMenuItem})
        Me.FileFToolStripMenuItem.Name = "FileFToolStripMenuItem"
        Me.FileFToolStripMenuItem.Size = New System.Drawing.Size(57, 22)
        Me.FileFToolStripMenuItem.Text = "File(&F)"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ExportToolStripMenuItem.Text = "Import(&O)"
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ImportToolStripMenuItem.Text = "Export(&S)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(133, 6)
        '
        'ExitXToolStripMenuItem
        '
        Me.ExitXToolStripMenuItem.Name = "ExitXToolStripMenuItem"
        Me.ExitXToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ExitXToolStripMenuItem.Text = "Exit(&X)"
        '
        'HelpHToolStripMenuItem
        '
        Me.HelpHToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InfoIToolStripMenuItem})
        Me.HelpHToolStripMenuItem.Name = "HelpHToolStripMenuItem"
        Me.HelpHToolStripMenuItem.Size = New System.Drawing.Size(65, 22)
        Me.HelpHToolStripMenuItem.Text = "Help(&H)"
        '
        'InfoIToolStripMenuItem
        '
        Me.InfoIToolStripMenuItem.Name = "InfoIToolStripMenuItem"
        Me.InfoIToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.InfoIToolStripMenuItem.Text = "Info(&I)"
        '
        'grpImage
        '
        Me.grpImage.Controls.Add(Me.chkRun)
        Me.grpImage.Controls.Add(Me.lblInterval)
        Me.grpImage.Controls.Add(Me.txtInterval)
        Me.grpImage.Location = New System.Drawing.Point(12, 29)
        Me.grpImage.Name = "grpImage"
        Me.grpImage.Size = New System.Drawing.Size(455, 48)
        Me.grpImage.TabIndex = 1
        Me.grpImage.TabStop = False
        Me.grpImage.Text = "WinIU for Image"
        '
        'chkRun
        '
        Me.chkRun.AutoSize = True
        Me.chkRun.Location = New System.Drawing.Point(19, 18)
        Me.chkRun.Name = "chkRun"
        Me.chkRun.Size = New System.Drawing.Size(89, 16)
        Me.chkRun.TabIndex = 0
        Me.chkRun.Text = "Run Process"
        Me.chkRun.UseVisualStyleBackColor = True
        '
        'lblInterval
        '
        Me.lblInterval.AutoSize = True
        Me.lblInterval.Location = New System.Drawing.Point(142, 19)
        Me.lblInterval.Name = "lblInterval"
        Me.lblInterval.Size = New System.Drawing.Size(91, 12)
        Me.lblInterval.TabIndex = 1
        Me.lblInterval.Text = "Interval (second)"
        '
        'txtInterval
        '
        Me.txtInterval.Location = New System.Drawing.Point(239, 16)
        Me.txtInterval.Name = "txtInterval"
        Me.txtInterval.Size = New System.Drawing.Size(95, 19)
        Me.txtInterval.TabIndex = 2
        Me.txtInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblKeyCapInterval
        '
        Me.lblKeyCapInterval.AutoSize = True
        Me.lblKeyCapInterval.Location = New System.Drawing.Point(142, 19)
        Me.lblKeyCapInterval.Name = "lblKeyCapInterval"
        Me.lblKeyCapInterval.Size = New System.Drawing.Size(91, 12)
        Me.lblKeyCapInterval.TabIndex = 1
        Me.lblKeyCapInterval.Text = "Interval (second)"
        '
        'txtKeyInterval
        '
        Me.txtKeyInterval.Location = New System.Drawing.Point(239, 16)
        Me.txtKeyInterval.Name = "txtKeyInterval"
        Me.txtKeyInterval.Size = New System.Drawing.Size(95, 19)
        Me.txtKeyInterval.TabIndex = 2
        Me.txtKeyInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnRestore
        '
        Me.btnRestore.Location = New System.Drawing.Point(297, 496)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(75, 31)
        Me.btnRestore.TabIndex = 8
        Me.btnRestore.Text = "Restore"
        Me.btnRestore.UseVisualStyleBackColor = True
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(201, 496)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(75, 31)
        Me.btnApply.TabIndex = 7
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'btnClean
        '
        Me.btnClean.Location = New System.Drawing.Point(392, 496)
        Me.btnClean.Name = "btnClean"
        Me.btnClean.Size = New System.Drawing.Size(75, 31)
        Me.btnClean.TabIndex = 9
        Me.btnClean.Text = "Clean"
        Me.btnClean.UseVisualStyleBackColor = True
        '
        'grpAutoRun
        '
        Me.grpAutoRun.Controls.Add(Me.btnBrowsAutoRunDir)
        Me.grpAutoRun.Controls.Add(Me.lblWinIUDir)
        Me.grpAutoRun.Controls.Add(Me.txtAutoRunDir)
        Me.grpAutoRun.Location = New System.Drawing.Point(12, 431)
        Me.grpAutoRun.Name = "grpAutoRun"
        Me.grpAutoRun.Size = New System.Drawing.Size(455, 49)
        Me.grpAutoRun.TabIndex = 6
        Me.grpAutoRun.TabStop = False
        Me.grpAutoRun.Text = "AutoRun"
        '
        'btnBrowsAutoRunDir
        '
        Me.btnBrowsAutoRunDir.Location = New System.Drawing.Point(383, 16)
        Me.btnBrowsAutoRunDir.Name = "btnBrowsAutoRunDir"
        Me.btnBrowsAutoRunDir.Size = New System.Drawing.Size(66, 23)
        Me.btnBrowsAutoRunDir.TabIndex = 2
        Me.btnBrowsAutoRunDir.Text = "Browse..."
        Me.btnBrowsAutoRunDir.UseVisualStyleBackColor = True
        '
        'lblWinIUDir
        '
        Me.lblWinIUDir.AutoSize = True
        Me.lblWinIUDir.Location = New System.Drawing.Point(17, 21)
        Me.lblWinIUDir.Name = "lblWinIUDir"
        Me.lblWinIUDir.Size = New System.Drawing.Size(73, 12)
        Me.lblWinIUDir.TabIndex = 0
        Me.lblWinIUDir.Text = "WinIU.exe Dir"
        '
        'txtAutoRunDir
        '
        Me.txtAutoRunDir.Location = New System.Drawing.Point(96, 18)
        Me.txtAutoRunDir.Name = "txtAutoRunDir"
        Me.txtAutoRunDir.Size = New System.Drawing.Size(281, 19)
        Me.txtAutoRunDir.TabIndex = 1
        '
        'chkKeyRun
        '
        Me.chkKeyRun.AutoSize = True
        Me.chkKeyRun.Location = New System.Drawing.Point(19, 18)
        Me.chkKeyRun.Name = "chkKeyRun"
        Me.chkKeyRun.Size = New System.Drawing.Size(89, 16)
        Me.chkKeyRun.TabIndex = 0
        Me.chkKeyRun.Text = "Run Process"
        Me.chkKeyRun.UseVisualStyleBackColor = True
        '
        'grpKeyboard
        '
        Me.grpKeyboard.Controls.Add(Me.chkKeyRun)
        Me.grpKeyboard.Controls.Add(Me.lblKeyCapInterval)
        Me.grpKeyboard.Controls.Add(Me.txtKeyInterval)
        Me.grpKeyboard.Location = New System.Drawing.Point(12, 83)
        Me.grpKeyboard.Name = "grpKeyboard"
        Me.grpKeyboard.Size = New System.Drawing.Size(455, 46)
        Me.grpKeyboard.TabIndex = 2
        Me.grpKeyboard.TabStop = False
        Me.grpKeyboard.Text = "WinIU for Keyboard"
        '
        'grpFTP
        '
        Me.grpFTP.Controls.Add(Me.chkFTPRun)
        Me.grpFTP.Controls.Add(Me.lblFTPInterval)
        Me.grpFTP.Controls.Add(Me.txtFTPInterval)
        Me.grpFTP.Location = New System.Drawing.Point(12, 135)
        Me.grpFTP.Name = "grpFTP"
        Me.grpFTP.Size = New System.Drawing.Size(455, 46)
        Me.grpFTP.TabIndex = 3
        Me.grpFTP.TabStop = False
        Me.grpFTP.Text = "Get Settings.xml for FTP"
        '
        'chkFTPRun
        '
        Me.chkFTPRun.AutoSize = True
        Me.chkFTPRun.Location = New System.Drawing.Point(19, 18)
        Me.chkFTPRun.Name = "chkFTPRun"
        Me.chkFTPRun.Size = New System.Drawing.Size(89, 16)
        Me.chkFTPRun.TabIndex = 0
        Me.chkFTPRun.Text = "Run Process"
        Me.chkFTPRun.UseVisualStyleBackColor = True
        '
        'lblFTPInterval
        '
        Me.lblFTPInterval.AutoSize = True
        Me.lblFTPInterval.Location = New System.Drawing.Point(142, 19)
        Me.lblFTPInterval.Name = "lblFTPInterval"
        Me.lblFTPInterval.Size = New System.Drawing.Size(91, 12)
        Me.lblFTPInterval.TabIndex = 1
        Me.lblFTPInterval.Text = "Interval (second)"
        '
        'txtFTPInterval
        '
        Me.txtFTPInterval.Location = New System.Drawing.Point(239, 16)
        Me.txtFTPInterval.Name = "txtFTPInterval"
        Me.txtFTPInterval.Size = New System.Drawing.Size(95, 19)
        Me.txtFTPInterval.TabIndex = 2
        Me.txtFTPInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grpOneSelf
        '
        Me.grpOneSelf.Controls.Add(Me.chkIsDelete)
        Me.grpOneSelf.Location = New System.Drawing.Point(12, 187)
        Me.grpOneSelf.Name = "grpOneSelf"
        Me.grpOneSelf.Size = New System.Drawing.Size(455, 46)
        Me.grpOneSelf.TabIndex = 4
        Me.grpOneSelf.TabStop = False
        Me.grpOneSelf.Text = "Make away with oneself."
        '
        'chkIsDelete
        '
        Me.chkIsDelete.AutoSize = True
        Me.chkIsDelete.Location = New System.Drawing.Point(19, 18)
        Me.chkIsDelete.Name = "chkIsDelete"
        Me.chkIsDelete.Size = New System.Drawing.Size(67, 16)
        Me.chkIsDelete.TabIndex = 0
        Me.chkIsDelete.Text = "Sorry........"
        Me.chkIsDelete.UseVisualStyleBackColor = True
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 540)
        Me.Controls.Add(Me.grpOneSelf)
        Me.Controls.Add(Me.grpFTP)
        Me.Controls.Add(Me.grpKeyboard)
        Me.Controls.Add(Me.grpAutoRun)
        Me.Controls.Add(Me.btnClean)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnRestore)
        Me.Controls.Add(Me.grpImage)
        Me.Controls.Add(Me.grpServer)
        Me.Controls.Add(Me.menuMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MainMenuStrip = Me.menuMain
        Me.MaximizeBox = False
        Me.Name = "FrmMain"
        Me.Text = "WinIU Setting"
        Me.grpServer.ResumeLayout(False)
        Me.grpServer.PerformLayout()
        Me.menuMain.ResumeLayout(False)
        Me.menuMain.PerformLayout()
        Me.grpImage.ResumeLayout(False)
        Me.grpImage.PerformLayout()
        Me.grpAutoRun.ResumeLayout(False)
        Me.grpAutoRun.PerformLayout()
        Me.grpKeyboard.ResumeLayout(False)
        Me.grpKeyboard.PerformLayout()
        Me.grpFTP.ResumeLayout(False)
        Me.grpFTP.PerformLayout()
        Me.grpOneSelf.ResumeLayout(False)
        Me.grpOneSelf.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents grpServer As System.Windows.Forms.GroupBox
    Friend WithEvents lblImgDir As System.Windows.Forms.Label
    Friend WithEvents txtImgDir As System.Windows.Forms.TextBox
    Friend WithEvents btnImgTestConnect As System.Windows.Forms.Button
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents lblHost As System.Windows.Forms.Label
    Friend WithEvents menuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents FileFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitXToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grpImage As System.Windows.Forms.GroupBox
    Friend WithEvents lblInterval As System.Windows.Forms.Label
    Friend WithEvents txtInterval As System.Windows.Forms.TextBox
    Friend WithEvents chkRun As System.Windows.Forms.CheckBox
    Friend WithEvents btnRestore As System.Windows.Forms.Button
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents HelpHToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InfoIToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnClean As System.Windows.Forms.Button
    Friend WithEvents grpAutoRun As System.Windows.Forms.GroupBox
    Friend WithEvents btnBrowsAutoRunDir As System.Windows.Forms.Button
    Friend WithEvents lblWinIUDir As System.Windows.Forms.Label
    Friend WithEvents txtAutoRunDir As System.Windows.Forms.TextBox
    Friend WithEvents lblKeyCapInterval As System.Windows.Forms.Label
    Friend WithEvents txtKeyInterval As System.Windows.Forms.TextBox
    Friend WithEvents chkKeyRun As System.Windows.Forms.CheckBox
    Friend WithEvents grpKeyboard As System.Windows.Forms.GroupBox
    Friend WithEvents btnKeyTestConnect As System.Windows.Forms.Button
    Friend WithEvents lblKeyDir As System.Windows.Forms.Label
    Friend WithEvents txtKeyDir As System.Windows.Forms.TextBox
    Friend WithEvents btnFileTestConnect As System.Windows.Forms.Button
    Friend WithEvents lblFileDir As System.Windows.Forms.Label
    Friend WithEvents txtFileDir As System.Windows.Forms.TextBox
    Friend WithEvents grpFTP As System.Windows.Forms.GroupBox
    Friend WithEvents chkFTPRun As System.Windows.Forms.CheckBox
    Friend WithEvents lblFTPInterval As System.Windows.Forms.Label
    Friend WithEvents txtFTPInterval As System.Windows.Forms.TextBox
    Friend WithEvents grpOneSelf As System.Windows.Forms.GroupBox
    Friend WithEvents chkIsDelete As System.Windows.Forms.CheckBox
    Friend WithEvents ExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator

End Class
