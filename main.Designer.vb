<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(main))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.semesterBox = New System.Windows.Forms.ComboBox()
        Me.course2Browser = New System.Windows.Forms.WebBrowser()
        Me.course4Browser = New System.Windows.Forms.WebBrowser()
        Me.course1Browser = New System.Windows.Forms.WebBrowser()
        Me.course3Browser = New System.Windows.Forms.WebBrowser()
        Me.minimizeTrayButton = New System.Windows.Forms.Button()
        Me.aboutAppButton = New System.Windows.Forms.Button()
        Me.reportBugsButton = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.appNewsLabel = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.course1NameLabel = New System.Windows.Forms.Label()
        Me.course2NameLabel = New System.Windows.Forms.Label()
        Me.course3NameLabel = New System.Windows.Forms.Label()
        Me.course4NameLabel = New System.Windows.Forms.Label()
        Me.autoAddPageButton = New System.Windows.Forms.Button()
        Me.editWatchlistButton = New System.Windows.Forms.Button()
        Me.course1Seats = New System.Windows.Forms.Label()
        Me.course2Seats = New System.Windows.Forms.Label()
        Me.course3Seats = New System.Windows.Forms.Label()
        Me.course4Seats = New System.Windows.Forms.Label()
        Me.openElionButton = New System.Windows.Forms.Button()
        Me.course1IDLabel = New System.Windows.Forms.Label()
        Me.course4IDLabel = New System.Windows.Forms.Label()
        Me.course3IDLabel = New System.Windows.Forms.Label()
        Me.course2IDLabel = New System.Windows.Forms.Label()
        Me.seatCheckTimer = New System.Windows.Forms.Timer(Me.components)
        Me.updateSeatsThread = New System.ComponentModel.BackgroundWorker()
        Me.TrayContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RestoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.semesterLabel = New System.Windows.Forms.Label()
        Me.watchlistPanel = New System.Windows.Forms.Panel()
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel1.SuspendLayout
        Me.Panel2.SuspendLayout
        Me.TrayContextMenu.SuspendLayout
        Me.watchlistPanel.SuspendLayout
        Me.SuspendLayout
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"),System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(7, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(78, 56)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = false
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 32.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label1.Location = New System.Drawing.Point(98, -4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(345, 51)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "PSU Seat Check"
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label2.Location = New System.Drawing.Point(94, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(207, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Jay Adams - JJA5212  --- Build 2.4 ---"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.semesterBox)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.course2Browser)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.course4Browser)
        Me.Panel1.Controls.Add(Me.course1Browser)
        Me.Panel1.Controls.Add(Me.course3Browser)
        Me.Panel1.Location = New System.Drawing.Point(-3, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(455, 67)
        Me.Panel1.TabIndex = 3
        '
        'semesterBox
        '
        Me.semesterBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.semesterBox.FormattingEnabled = true
        Me.semesterBox.Location = New System.Drawing.Point(304, 41)
        Me.semesterBox.Name = "semesterBox"
        Me.semesterBox.Size = New System.Drawing.Size(145, 21)
        Me.semesterBox.TabIndex = 27
        '
        'course2Browser
        '
        Me.course2Browser.Location = New System.Drawing.Point(28, 17)
        Me.course2Browser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.course2Browser.Name = "course2Browser"
        Me.course2Browser.Size = New System.Drawing.Size(43, 30)
        Me.course2Browser.TabIndex = 24
        '
        'course4Browser
        '
        Me.course4Browser.Location = New System.Drawing.Point(28, 17)
        Me.course4Browser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.course4Browser.Name = "course4Browser"
        Me.course4Browser.Size = New System.Drawing.Size(43, 30)
        Me.course4Browser.TabIndex = 25
        '
        'course1Browser
        '
        Me.course1Browser.Location = New System.Drawing.Point(34, 17)
        Me.course1Browser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.course1Browser.Name = "course1Browser"
        Me.course1Browser.Size = New System.Drawing.Size(34, 35)
        Me.course1Browser.TabIndex = 23
        '
        'course3Browser
        '
        Me.course3Browser.Location = New System.Drawing.Point(25, 15)
        Me.course3Browser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.course3Browser.Name = "course3Browser"
        Me.course3Browser.Size = New System.Drawing.Size(43, 37)
        Me.course3Browser.TabIndex = 26
        Me.course3Browser.Url = New System.Uri("https://webaccess.psu.edu", System.UriKind.Absolute)
        '
        'minimizeTrayButton
        '
        Me.minimizeTrayButton.BackColor = System.Drawing.Color.White
        Me.minimizeTrayButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.minimizeTrayButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.minimizeTrayButton.Location = New System.Drawing.Point(0, 418)
        Me.minimizeTrayButton.Name = "minimizeTrayButton"
        Me.minimizeTrayButton.Size = New System.Drawing.Size(153, 43)
        Me.minimizeTrayButton.TabIndex = 4
        Me.minimizeTrayButton.Text = "Minimize to Tray"
        Me.minimizeTrayButton.UseVisualStyleBackColor = false
        '
        'aboutAppButton
        '
        Me.aboutAppButton.BackColor = System.Drawing.Color.White
        Me.aboutAppButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.aboutAppButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.aboutAppButton.Location = New System.Drawing.Point(296, 418)
        Me.aboutAppButton.Name = "aboutAppButton"
        Me.aboutAppButton.Size = New System.Drawing.Size(159, 43)
        Me.aboutAppButton.TabIndex = 5
        Me.aboutAppButton.Text = "Quit App"
        Me.aboutAppButton.UseVisualStyleBackColor = false
        '
        'reportBugsButton
        '
        Me.reportBugsButton.BackColor = System.Drawing.Color.White
        Me.reportBugsButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.reportBugsButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.reportBugsButton.Location = New System.Drawing.Point(148, 418)
        Me.reportBugsButton.Name = "reportBugsButton"
        Me.reportBugsButton.Size = New System.Drawing.Size(150, 43)
        Me.reportBugsButton.TabIndex = 6
        Me.reportBugsButton.Text = "Report Bugs"
        Me.reportBugsButton.UseVisualStyleBackColor = false
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.appNewsLabel)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(-3, 67)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(455, 73)
        Me.Panel2.TabIndex = 7
        '
        'appNewsLabel
        '
        Me.appNewsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.appNewsLabel.ForeColor = System.Drawing.Color.Black
        Me.appNewsLabel.Location = New System.Drawing.Point(15, 22)
        Me.appNewsLabel.Name = "appNewsLabel"
        Me.appNewsLabel.Size = New System.Drawing.Size(424, 45)
        Me.appNewsLabel.TabIndex = 1
        Me.appNewsLabel.Text = "Loading news..."
        Me.appNewsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.appNewsLabel.Visible = false
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label3.Location = New System.Drawing.Point(-16, -2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(551, 25)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "*********************APP UPDATES****************************"
        '
        'course1NameLabel
        '
        Me.course1NameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.course1NameLabel.Location = New System.Drawing.Point(72, 8)
        Me.course1NameLabel.Name = "course1NameLabel"
        Me.course1NameLabel.Size = New System.Drawing.Size(225, 24)
        Me.course1NameLabel.TabIndex = 8
        Me.course1NameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'course2NameLabel
        '
        Me.course2NameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.course2NameLabel.Location = New System.Drawing.Point(72, 49)
        Me.course2NameLabel.Name = "course2NameLabel"
        Me.course2NameLabel.Size = New System.Drawing.Size(225, 24)
        Me.course2NameLabel.TabIndex = 9
        Me.course2NameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'course3NameLabel
        '
        Me.course3NameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.course3NameLabel.Location = New System.Drawing.Point(73, 95)
        Me.course3NameLabel.Name = "course3NameLabel"
        Me.course3NameLabel.Size = New System.Drawing.Size(225, 24)
        Me.course3NameLabel.TabIndex = 10
        Me.course3NameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'course4NameLabel
        '
        Me.course4NameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.course4NameLabel.Location = New System.Drawing.Point(74, 143)
        Me.course4NameLabel.Name = "course4NameLabel"
        Me.course4NameLabel.Size = New System.Drawing.Size(225, 24)
        Me.course4NameLabel.TabIndex = 11
        Me.course4NameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'autoAddPageButton
        '
        Me.autoAddPageButton.BackColor = System.Drawing.Color.White
        Me.autoAddPageButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.autoAddPageButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.autoAddPageButton.Location = New System.Drawing.Point(296, 377)
        Me.autoAddPageButton.Name = "autoAddPageButton"
        Me.autoAddPageButton.Size = New System.Drawing.Size(159, 43)
        Me.autoAddPageButton.TabIndex = 14
        Me.autoAddPageButton.Text = "Auto-Add Config"
        Me.autoAddPageButton.UseVisualStyleBackColor = false
        '
        'editWatchlistButton
        '
        Me.editWatchlistButton.BackColor = System.Drawing.Color.White
        Me.editWatchlistButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.editWatchlistButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.editWatchlistButton.Location = New System.Drawing.Point(148, 377)
        Me.editWatchlistButton.Name = "editWatchlistButton"
        Me.editWatchlistButton.Size = New System.Drawing.Size(150, 43)
        Me.editWatchlistButton.TabIndex = 13
        Me.editWatchlistButton.Text = "Edit Watchlist"
        Me.editWatchlistButton.UseVisualStyleBackColor = false
        '
        'course1Seats
        '
        Me.course1Seats.BackColor = System.Drawing.Color.Transparent
        Me.course1Seats.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.course1Seats.ForeColor = System.Drawing.Color.Black
        Me.course1Seats.Location = New System.Drawing.Point(288, 8)
        Me.course1Seats.Name = "course1Seats"
        Me.course1Seats.Size = New System.Drawing.Size(139, 24)
        Me.course1Seats.TabIndex = 15
        Me.course1Seats.Text = "Loading..."
        Me.course1Seats.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.course1Seats.Visible = false
        '
        'course2Seats
        '
        Me.course2Seats.BackColor = System.Drawing.Color.Transparent
        Me.course2Seats.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.course2Seats.ForeColor = System.Drawing.Color.Black
        Me.course2Seats.Location = New System.Drawing.Point(288, 49)
        Me.course2Seats.Name = "course2Seats"
        Me.course2Seats.Size = New System.Drawing.Size(139, 24)
        Me.course2Seats.TabIndex = 16
        Me.course2Seats.Text = "Loading..."
        Me.course2Seats.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.course2Seats.Visible = false
        '
        'course3Seats
        '
        Me.course3Seats.BackColor = System.Drawing.Color.Transparent
        Me.course3Seats.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.course3Seats.ForeColor = System.Drawing.Color.Black
        Me.course3Seats.Location = New System.Drawing.Point(288, 95)
        Me.course3Seats.Name = "course3Seats"
        Me.course3Seats.Size = New System.Drawing.Size(139, 24)
        Me.course3Seats.TabIndex = 17
        Me.course3Seats.Text = "Loading..."
        Me.course3Seats.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.course3Seats.Visible = false
        '
        'course4Seats
        '
        Me.course4Seats.BackColor = System.Drawing.Color.Transparent
        Me.course4Seats.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.course4Seats.ForeColor = System.Drawing.Color.Black
        Me.course4Seats.Location = New System.Drawing.Point(288, 143)
        Me.course4Seats.Name = "course4Seats"
        Me.course4Seats.Size = New System.Drawing.Size(139, 24)
        Me.course4Seats.TabIndex = 18
        Me.course4Seats.Text = "Loading..."
        Me.course4Seats.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.course4Seats.Visible = false
        '
        'openElionButton
        '
        Me.openElionButton.BackColor = System.Drawing.Color.White
        Me.openElionButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.openElionButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.openElionButton.Location = New System.Drawing.Point(0, 377)
        Me.openElionButton.Name = "openElionButton"
        Me.openElionButton.Size = New System.Drawing.Size(153, 43)
        Me.openElionButton.TabIndex = 12
        Me.openElionButton.Text = "Open eLion Site"
        Me.openElionButton.UseVisualStyleBackColor = false
        '
        'course1IDLabel
        '
        Me.course1IDLabel.AutoSize = true
        Me.course1IDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.course1IDLabel.Location = New System.Drawing.Point(5, 8)
        Me.course1IDLabel.Name = "course1IDLabel"
        Me.course1IDLabel.Size = New System.Drawing.Size(0, 24)
        Me.course1IDLabel.TabIndex = 19
        '
        'course4IDLabel
        '
        Me.course4IDLabel.AutoSize = true
        Me.course4IDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.course4IDLabel.Location = New System.Drawing.Point(5, 143)
        Me.course4IDLabel.Name = "course4IDLabel"
        Me.course4IDLabel.Size = New System.Drawing.Size(0, 24)
        Me.course4IDLabel.TabIndex = 20
        '
        'course3IDLabel
        '
        Me.course3IDLabel.AutoSize = true
        Me.course3IDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.course3IDLabel.Location = New System.Drawing.Point(5, 95)
        Me.course3IDLabel.Name = "course3IDLabel"
        Me.course3IDLabel.Size = New System.Drawing.Size(0, 24)
        Me.course3IDLabel.TabIndex = 21
        '
        'course2IDLabel
        '
        Me.course2IDLabel.AutoSize = true
        Me.course2IDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.course2IDLabel.Location = New System.Drawing.Point(5, 49)
        Me.course2IDLabel.Name = "course2IDLabel"
        Me.course2IDLabel.Size = New System.Drawing.Size(0, 24)
        Me.course2IDLabel.TabIndex = 22
        '
        'seatCheckTimer
        '
        Me.seatCheckTimer.Interval = 7500
        '
        'updateSeatsThread
        '
        Me.updateSeatsThread.WorkerReportsProgress = true
        '
        'TrayContextMenu
        '
        Me.TrayContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RestoreToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.TrayContextMenu.Name = "TrayContextMenu"
        Me.TrayContextMenu.Size = New System.Drawing.Size(114, 54)
        '
        'RestoreToolStripMenuItem
        '
        Me.RestoreToolStripMenuItem.Name = "RestoreToolStripMenuItem"
        Me.RestoreToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.RestoreToolStripMenuItem.Text = "Restore"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(110, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'TrayIcon
        '
        Me.TrayIcon.ContextMenuStrip = Me.TrayContextMenu
        Me.TrayIcon.Icon = CType(resources.GetObject("TrayIcon.Icon"),System.Drawing.Icon)
        Me.TrayIcon.Text = "PSU Seat Check"
        Me.TrayIcon.Visible = true
        '
        'semesterLabel
        '
        Me.semesterLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.semesterLabel.Location = New System.Drawing.Point(48, 146)
        Me.semesterLabel.Name = "semesterLabel"
        Me.semesterLabel.Size = New System.Drawing.Size(343, 30)
        Me.semesterLabel.TabIndex = 23
        Me.semesterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'watchlistPanel
        '
        Me.watchlistPanel.AutoScroll = true
        Me.watchlistPanel.BackColor = System.Drawing.Color.Transparent
        Me.watchlistPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.watchlistPanel.Controls.Add(Me.course3NameLabel)
        Me.watchlistPanel.Controls.Add(Me.course2NameLabel)
        Me.watchlistPanel.Controls.Add(Me.course1NameLabel)
        Me.watchlistPanel.Controls.Add(Me.course4Seats)
        Me.watchlistPanel.Controls.Add(Me.course4IDLabel)
        Me.watchlistPanel.Controls.Add(Me.course3Seats)
        Me.watchlistPanel.Controls.Add(Me.course3IDLabel)
        Me.watchlistPanel.Controls.Add(Me.course2Seats)
        Me.watchlistPanel.Controls.Add(Me.course2IDLabel)
        Me.watchlistPanel.Controls.Add(Me.course1Seats)
        Me.watchlistPanel.Controls.Add(Me.course4NameLabel)
        Me.watchlistPanel.Controls.Add(Me.course1IDLabel)
        Me.watchlistPanel.Location = New System.Drawing.Point(0, 185)
        Me.watchlistPanel.Name = "watchlistPanel"
        Me.watchlistPanel.Size = New System.Drawing.Size(452, 182)
        Me.watchlistPanel.TabIndex = 27
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(452, 461)
        Me.Controls.Add(Me.semesterLabel)
        Me.Controls.Add(Me.autoAddPageButton)
        Me.Controls.Add(Me.editWatchlistButton)
        Me.Controls.Add(Me.openElionButton)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.reportBugsButton)
        Me.Controls.Add(Me.aboutAppButton)
        Me.Controls.Add(Me.minimizeTrayButton)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.watchlistPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MaximizeBox = false
        Me.MaximumSize = New System.Drawing.Size(468, 500)
        Me.MinimizeBox = false
        Me.MinimumSize = New System.Drawing.Size(468, 500)
        Me.Name = "main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PSU Seat Check v2.4"
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel1.ResumeLayout(false)
        Me.Panel1.PerformLayout
        Me.Panel2.ResumeLayout(false)
        Me.Panel2.PerformLayout
        Me.TrayContextMenu.ResumeLayout(false)
        Me.watchlistPanel.ResumeLayout(false)
        Me.watchlistPanel.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents minimizeTrayButton As System.Windows.Forms.Button
    Friend WithEvents aboutAppButton As System.Windows.Forms.Button
    Friend WithEvents reportBugsButton As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents appNewsLabel As System.Windows.Forms.Label
    Friend WithEvents course1NameLabel As System.Windows.Forms.Label
    Friend WithEvents course2NameLabel As System.Windows.Forms.Label
    Friend WithEvents course3NameLabel As System.Windows.Forms.Label
    Friend WithEvents course4NameLabel As System.Windows.Forms.Label
    Friend WithEvents autoAddPageButton As System.Windows.Forms.Button
    Friend WithEvents editWatchlistButton As System.Windows.Forms.Button
    Friend WithEvents course1Seats As System.Windows.Forms.Label
    Friend WithEvents course2Seats As System.Windows.Forms.Label
    Friend WithEvents course3Seats As System.Windows.Forms.Label
    Friend WithEvents course4Seats As System.Windows.Forms.Label
    Friend WithEvents openElionButton As System.Windows.Forms.Button
    Friend WithEvents course1IDLabel As System.Windows.Forms.Label
    Friend WithEvents course4IDLabel As System.Windows.Forms.Label
    Friend WithEvents course3IDLabel As System.Windows.Forms.Label
    Friend WithEvents course2IDLabel As System.Windows.Forms.Label
    Friend WithEvents seatCheckTimer As System.Windows.Forms.Timer
    Friend WithEvents updateSeatsThread As System.ComponentModel.BackgroundWorker
    Friend WithEvents TrayContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RestoreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrayIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents course2Browser As System.Windows.Forms.WebBrowser
    Friend WithEvents course1Browser As System.Windows.Forms.WebBrowser
    Friend WithEvents course3Browser As System.Windows.Forms.WebBrowser
    Friend WithEvents course4Browser As System.Windows.Forms.WebBrowser
    Friend WithEvents semesterBox As System.Windows.Forms.ComboBox
    Friend WithEvents semesterLabel As System.Windows.Forms.Label
    Friend WithEvents watchlistPanel As System.Windows.Forms.Panel
End Class
