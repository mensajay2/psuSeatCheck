<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class courseEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(courseEntry))
        Me.mainTitle = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.course2 = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.course3 = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.course4 = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.course1Name = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.course2Name = New System.Windows.Forms.TextBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.course3Name = New System.Windows.Forms.TextBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.course4Name = New System.Windows.Forms.TextBox()
        Me.course1 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.submitCourses = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.clear1 = New System.Windows.Forms.PictureBox()
        Me.cancel2 = New System.Windows.Forms.PictureBox()
        Me.cancel3 = New System.Windows.Forms.PictureBox()
        Me.cancel4 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.clear1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cancel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cancel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cancel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mainTitle
        '
        Me.mainTitle.AutoSize = True
        Me.mainTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mainTitle.Location = New System.Drawing.Point(132, 8)
        Me.mainTitle.Name = "mainTitle"
        Me.mainTitle.Size = New System.Drawing.Size(194, 25)
        Me.mainTitle.TabIndex = 1
        Me.mainTitle.Text = "Monitored Courses"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(75, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(313, 32)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "*Enter course ID's of courses you want to monitor," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "also enter the name (this wil" & _
    "l be displayed on alerts)"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.course2)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(242, 150)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(156, 58)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Course 2 ID"
        '
        'course2
        '
        Me.course2.Location = New System.Drawing.Point(7, 22)
        Me.course2.MaxLength = 6
        Me.course2.Name = "course2"
        Me.course2.Size = New System.Drawing.Size(143, 26)
        Me.course2.TabIndex = 3
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.course3)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(242, 219)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(156, 58)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Course 3 ID"
        '
        'course3
        '
        Me.course3.Location = New System.Drawing.Point(7, 22)
        Me.course3.MaxLength = 6
        Me.course3.Name = "course3"
        Me.course3.Size = New System.Drawing.Size(143, 26)
        Me.course3.TabIndex = 1
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.course4)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(242, 291)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(156, 58)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Course 4 ID"
        '
        'course4
        '
        Me.course4.Location = New System.Drawing.Point(7, 23)
        Me.course4.MaxLength = 6
        Me.course4.Name = "course4"
        Me.course4.Size = New System.Drawing.Size(143, 26)
        Me.course4.TabIndex = 7
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.course1Name)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(14, 78)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(206, 58)
        Me.GroupBox5.TabIndex = 7
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Course 1 Name"
        '
        'course1Name
        '
        Me.course1Name.Location = New System.Drawing.Point(6, 22)
        Me.course1Name.MaxLength = 17
        Me.course1Name.Name = "course1Name"
        Me.course1Name.Size = New System.Drawing.Size(194, 26)
        Me.course1Name.TabIndex = 1
        Me.course1Name.Text = "(Example: Math 140 9am)"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.course2Name)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(14, 150)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(206, 58)
        Me.GroupBox6.TabIndex = 8
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Course 2 Name"
        '
        'course2Name
        '
        Me.course2Name.Location = New System.Drawing.Point(6, 22)
        Me.course2Name.MaxLength = 17
        Me.course2Name.Name = "course2Name"
        Me.course2Name.Size = New System.Drawing.Size(194, 26)
        Me.course2Name.TabIndex = 2
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.course3Name)
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(14, 219)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(206, 58)
        Me.GroupBox7.TabIndex = 9
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Course 3 Name"
        '
        'course3Name
        '
        Me.course3Name.Location = New System.Drawing.Point(6, 22)
        Me.course3Name.MaxLength = 17
        Me.course3Name.Name = "course3Name"
        Me.course3Name.Size = New System.Drawing.Size(194, 26)
        Me.course3Name.TabIndex = 4
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.course4Name)
        Me.GroupBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(14, 291)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(206, 58)
        Me.GroupBox8.TabIndex = 10
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Course 4 Name"
        '
        'course4Name
        '
        Me.course4Name.Location = New System.Drawing.Point(6, 22)
        Me.course4Name.MaxLength = 17
        Me.course4Name.Name = "course4Name"
        Me.course4Name.Size = New System.Drawing.Size(194, 26)
        Me.course4Name.TabIndex = 6
        '
        'course1
        '
        Me.course1.Location = New System.Drawing.Point(6, 22)
        Me.course1.MaxLength = 6
        Me.course1.Name = "course1"
        Me.course1.Size = New System.Drawing.Size(144, 26)
        Me.course1.TabIndex = 10
        Me.course1.Text = "133337"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.course1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(242, 78)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(156, 58)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Course 1 ID"
        '
        'submitCourses
        '
        Me.submitCourses.BackColor = System.Drawing.Color.White
        Me.submitCourses.Cursor = System.Windows.Forms.Cursors.Hand
        Me.submitCourses.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.submitCourses.Location = New System.Drawing.Point(304, 366)
        Me.submitCourses.Name = "submitCourses"
        Me.submitCourses.Size = New System.Drawing.Size(152, 47)
        Me.submitCourses.TabIndex = 11
        Me.submitCourses.Text = "Save Courses"
        Me.submitCourses.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(-2, 366)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(148, 47)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Main Menu"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(143, 366)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(163, 47)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "Auto-Add Config"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'clear1
        '
        Me.clear1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.clear1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.clear1.Image = CType(resources.GetObject("clear1.Image"), System.Drawing.Image)
        Me.clear1.Location = New System.Drawing.Point(407, 96)
        Me.clear1.Name = "clear1"
        Me.clear1.Size = New System.Drawing.Size(31, 31)
        Me.clear1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.clear1.TabIndex = 14
        Me.clear1.TabStop = False
        '
        'cancel2
        '
        Me.cancel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cancel2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cancel2.Image = CType(resources.GetObject("cancel2.Image"), System.Drawing.Image)
        Me.cancel2.Location = New System.Drawing.Point(407, 167)
        Me.cancel2.Name = "cancel2"
        Me.cancel2.Size = New System.Drawing.Size(31, 31)
        Me.cancel2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.cancel2.TabIndex = 15
        Me.cancel2.TabStop = False
        '
        'cancel3
        '
        Me.cancel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cancel3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cancel3.Image = CType(resources.GetObject("cancel3.Image"), System.Drawing.Image)
        Me.cancel3.Location = New System.Drawing.Point(407, 236)
        Me.cancel3.Name = "cancel3"
        Me.cancel3.Size = New System.Drawing.Size(31, 31)
        Me.cancel3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.cancel3.TabIndex = 16
        Me.cancel3.TabStop = False
        '
        'cancel4
        '
        Me.cancel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cancel4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cancel4.Image = CType(resources.GetObject("cancel4.Image"), System.Drawing.Image)
        Me.cancel4.Location = New System.Drawing.Point(407, 309)
        Me.cancel4.Name = "cancel4"
        Me.cancel4.Size = New System.Drawing.Size(31, 31)
        Me.cancel4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.cancel4.TabIndex = 17
        Me.cancel4.TabStop = False
        '
        'courseEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(454, 412)
        Me.Controls.Add(Me.cancel4)
        Me.Controls.Add(Me.cancel3)
        Me.Controls.Add(Me.cancel2)
        Me.Controls.Add(Me.clear1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.submitCourses)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.mainTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(470, 450)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(470, 450)
        Me.Name = "courseEntry"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PSU Seat Check"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.clear1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cancel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cancel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cancel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mainTitle As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents course2 As System.Windows.Forms.TextBox
    Friend WithEvents course3 As System.Windows.Forms.TextBox
    Friend WithEvents course4 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents course1Name As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents course2Name As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents course3Name As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents course4Name As System.Windows.Forms.TextBox
    Friend WithEvents course1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents submitCourses As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents clear1 As System.Windows.Forms.PictureBox
    Friend WithEvents cancel2 As System.Windows.Forms.PictureBox
    Friend WithEvents cancel3 As System.Windows.Forms.PictureBox
    Friend WithEvents cancel4 As System.Windows.Forms.PictureBox

End Class
