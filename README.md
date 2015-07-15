WinIU
======================
GUIの無いサーバー監視用ソフトです。  
スクリーンショット、キーボード操作を指定サーバーへ送信します。

# ソフトウェア詳細
- ソフト名  
WinIU  
- 著作権者  
DS1@d_s_1  
- 対応環境  
Windows Vista以上 (.Netframework4.5.1)  
- 種別  
フリーウェア  
- ジャンル  
デスクトップアプリケーション  
- E-Mail  
deiesuone@gmail.com  
- 実行ファイル名  
WinIU.exe  
WinIUSetting.exe  

# ファイル構成
~~~~
WinIU +- ExampleSettings.xml
      |  
      +- WinIU.exe  
      |  
      +- WinIUSetting.exe  
      |  
	  +- LICENSE  
	  |  
      +- README.md(本ファイル)
~~~~

# 使用方法 WinIU.exe
 -1.WinIU用のフォルダを作成し、その中にWinIU.exeを設置してください。  
 -2.WinIUSetting.exeにて設定ファイルを作成するか、レジストリに設定値を書き込んでください。  
 -3.WinIUSetting.exeにて設定ファイルを作成した場合は、同フォルダに設置、もしくは「FTPサーバーのFile Dir(後述)」に設置してください。  
 -4.WinIU.exeを実行してください。  

 ## WinIUの設定について
 WinIUSetting.exeにて行います。
 
 ## WinIUの終了について
 UIにて終了する方法はありません。  
 タスクマネージャーからWinIU.exeを終了させてください。
 次回PC起動時に自動実行されますので、自動実行させたくない場合はWinIUSetting.exeにて設定してください。

# 使用方法 WinIUSetting.exe
WinIUSetting.exeは設定値をレジストリに書き込みます。  

また、設定ファイルを作成することも出来ます。
- WinIU.exeは起動時に「同フォルダ内の設定ファイル(*.xml)」、「FTPサーバーのFile Dir内の設定ファイル(Settings.xml)」を読み込み、レジストリに値を設定します。  
予め設定ファイルを作成しておけば、WinIUSetting.exeにてレジストリに値を設定する必要がありません。  

## File>Import
設定ファイルから設定値を読み込みます。

## File>Export
入力値から設定ファイルを作成します。

## WinIU for Image
スクリーンショットの送信に関する設定です。  
有効にする場合は「Run Process」にチェックを入れ、「Interval」に何秒ごとに送信するかを入力してください。  

## WinIU for Keyboard
キーボード入力履歴の送信に関する設定です。  
有効にする場合は「Run Process」にチェックを入れ、「Interval」に何秒ごとに送信するかを入力してください。  

## Get Settings.xml for FTP  
WinIUの起動時だけでなく、実行中も定期的にFTP接続で設定ファイルを取得し設定情報を更新します。  
有効にする場合は「Run Process」にチェックを入れ、「Interval」に何秒ごとに読み込みを行うかを入力してください。  
FTPに設置する設定ファイルのファイル名は「Settings.xml」としてください。

## Make away with oneself
自己消去機能に関する設定です。  
有効にした場合、WinIU.exeはWinIUに関するレジストリ、ファイルを削除します。  

## FTP Server
FTPサーバーに関する設定です。  
 - Host  
 ホスト名を設定します。
 - User  
 ユーザー名を設定します。  
 - Password  
 パスワードを設定します。  
 - Image Dir  
 「WinIU for Image」機能にてスクリーンショットをアップロードするディレクトリを設定します。  
 - Key Dir  
 「WinIU for Keyboard」機能にてキー入力履歴をアップロードするディレクトリを設定します。  
 - File Dir  
 設定ファイルが設置されているディレクトリを設定します。  

## AutoRun
WinIUの自動起動機能に関する設定です。  
PC起動時に自動的に起動するアプリケーションのフルパスを入力します。  
この値はWinIU.exeの起動時にWinIU.exeのフルパスで必ず更新されます。  

## Apply
現在の入力値でレジストリを更新します。

## Restore
現在のレジストリの値で入力値を更新します。

## Clean
WinIU関連のレジストリを削除します。

# アンインストール
 - 1.WinIU.exeをタスクマネージャーから終了する。  
 - 2.WinIUSetting.exeからCleanを実行し終了する。  
 - 3.WinIUフォルダを削除する。

 もしくは「Make away with oneself」機能を使用してください。

# 注意事項
- ライセンスについて  
本ソフトウェアはMITライセンスに基づいて公開されています。  
LICENSEファイルを参照して下さい。  
