'Jay Adams PSU Seat Check 2.4
'jja5212@psu.edu
'Program is entirely open source feel free to do whatever with it
'maybe give me some credit tho?? If not I won't get mad. Enjoy :)

'BIG KUDOS TO MR. JACE BOBY FOR POINTING OUT AND COMING UP WITH A CONCISE
'EASILY IMPLEMENTABLE SOLUTION TO THE WATCHLIST/ENROLLED BUG, THANKS!!!

Public Class main

    Public VERSION As Double = 2.4 'Current app version
    Public SEMESTER As String 'String which decides the semester, URL Encode the space
    Public course1Name, course2Name, course3Name, course4Name As String 'Course name strings (user input)
    Public course1, course2, course3, course4 As String 'User inputted course ID's
    Public result1, result2, result3, result4 As String 'HTTP request responses
    Public successfulQueries, failedQueries As Integer 'Number of successful/failed queries, mostly for debugging
    Private appNewsString As String 'Used for storing app update/news string (HTTP response from server)
    Private fileDuplicateCheck As New Dictionary(Of String, String) 'used for duplicate txt file check
    Private WithEvents authenticationBrowser As New System.Windows.Forms.WebBrowser
    Public autoAdd As Boolean = false
    Private updateHasShownToday = False
    Private updateBoxIsShowing = False

    Dim userDocumentsDir As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments
    'User documents directory, independant of Windows OS version

    Public restartFlag As Boolean = False
    Public twoFactorFlag As Boolean = False

    Private addingCourse1 As Boolean = False 'Course adding checks, used to prevent conflicting/duplicate adding actions
    Private addingCourse2 As Boolean = False
    Private addingCourse3 As Boolean = False
    Private addingCourse4 As Boolean = False
    Public courseAdded1 As Boolean = False
    Public courseAdded2 As Boolean = False
    Public courseAdded3 As Boolean = False
    Public courseAdded4 As Boolean = False
    Public addError1 As String = "" 'Used to store any possible errors (returned from the server)
    Public addError2 As String = ""
    Public addError3 As String = ""
    Public addError4 As String = ""

    'Amazing sound methods taken from these lovely programmers (THANKS GUYS YOU ROCK!!!)
    'http://www.codeproject.com/Tips/75464/Disable-click-sound-when-accesing-WebBrower-cont
    'Thanks emolina :)

    'Methods to temporarily enable/disable navigation clicking present in internet explorer
    Public Sub DisableSound()
        Dim keyValue As String
        keyValue = "%SystemRoot%\Media\"
        If Environment.OSVersion.Version.Major = 5 AndAlso Environment.OSVersion.Version.Minor > 0 Then
            keyValue += "Windows XP Start.wav"
        ElseIf Environment.OSVersion.Version.Major = 6 Then
            keyValue += "Windows Navigation Start.wav"
        Else
            Return
        End If

        Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey( _
        "AppEvents\Schemes\Apps\Explorer\Navigating\.Current", True)
        key.SetValue(Nothing, "", Microsoft.Win32.RegistryValueKind.ExpandString)
    End Sub

    Public Sub EnableSound()
        Dim keyValue As String
        keyValue = "%SystemRoot%\Media\"
        If Environment.OSVersion.Version.Major = 5 AndAlso Environment.OSVersion.Version.Minor > 0 Then
            keyValue += "Windows XP Start.wav"
        ElseIf Environment.OSVersion.Version.Major = 6 Then
            keyValue += "Windows Navigation Start.wav"
        Else
            Return
        End If
        Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey( _
            "AppEvents\Schemes\Apps\Explorer\Navigating\.Current", True)
        key.SetValue(Nothing, keyValue, Microsoft.Win32.RegistryValueKind.ExpandString)
    End Sub

    Public Sub initUpdate(latestVersion As Double, latestLink As String)

        'MsgBox(Application.ExecutablePath)
        'MsgBox(Application.StartupPath)

        updateHasShownToday = True
        updateBoxIsShowing = True

        Dim answer As Integer = MsgBox("A newer version of Seat Check (v" & latestVersion & ") is available, you are currently running v" & VERSION & ", Do you wish to update the app?" & vbNewLine & vbNewLine & "NOTE! All course data will be preserved", MsgBoxStyle.YesNo, "Update Available")

        If answer = DialogResult.No Then
            'do nothing
            updateBoxIsShowing = False
        ElseIf answer = DialogResult.Yes Then
            'proceed with update
            Try
                My.Computer.Network.DownloadFile("http://mensajay.com/psuSeatCheck/" & latestLink, Application.StartupPath & "/" & latestLink, "", "", True, 1000, True)
                'My.Computer.FileSystem.DeleteFile(Application.ExecutablePath, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.DeletePermanently)
                Process.Start(Application.StartupPath & "/" & latestLink)
                Environment.Exit(0)
            Catch ex As Exception
                MsgBox("There was an error downloading the update:" & ex.ToString(), MsgBoxStyle.Critical)
            End Try
        End If

    End Sub

    Public Sub checkVersion()

        Dim webClient As New System.Net.WebClient

        Dim latestVersion As Double
        Dim latestLink As String

        Try
            latestVersion = Double.Parse(webClient.DownloadString("http://mensajay.com/getVersion.php"))
            latestLink = webClient.DownloadString("http://mensajay.com/getVersion.php?download")
        Catch ex As Exception

        End Try

        If (latestVersion > VERSION) Then
            'there is a newer version out trigger update
            Console.WriteLine("Running v" & VERSION & " --- There is a newer version v" & latestVersion)
            initUpdate(latestVersion, latestLink)
        Else
            'running latest version
            Console.WriteLine("Running v" & VERSION & " (Latest Version)")
        End If

    End Sub

    Public Sub getSemesters()

        Dim webClient As New System.Net.WebClient
        Dim semesterData() As String

        Try
            semesterData = webClient.DownloadString("http://mensajay.com/getSemesters.php").Split(",")
        Catch ex As Exception
            MsgBox("There was an error fetching required information, the application will now exit. Please check your internet and retry." & vbNewLine & vbNewLine & ex.ToString(), MsgBoxStyle.Critical)
            Environment.Exit(0)
        End Try

        Console.WriteLine("data downloaded")

        semesterBox.Items.AddRange(semesterData)

    End Sub

    Private Sub updateSeatCount()

        Dim webClient As New System.Net.WebClient

        Try
            If My.Computer.Network.IsAvailable Then

                updateSeatsThread.ReportProgress(0)

                'Me.Text = "PSU Seat Check ........LOADING COURSES & SEATS......."

                'download app news
                appNewsString = webClient.DownloadString("http://mensajay.com/getAppNews.php")

                For i As Integer = 1 To 10
                    appNewsString = webClient.DownloadString("http://mensajay.com/getAppNews.php")
                Next

                If course1.Length > 0 Then

                    'Dim result1 As String
                    result1 = webClient.DownloadString("http://mensajay.com/seatsLeft.php?semester=" & SEMESTER & "&courseID=" & course1)

                    For i As Integer = 1 To 10
                        If result1.Length = 0 Then
                            result1 = webClient.DownloadString("http://mensajay.com/seatsLeft.php?semester=" & SEMESTER & "&courseID=" & course1)
                        End If
                    Next
                
                    Try 
                        If IsNumeric(result1) And Integer.Parse(result1) > 0 Then
                            If addingCourse1 = False And courseAdded1 = False And addError1.Length = 0 and autoAdd = true  Then
                                course1Browser.Navigate(New Uri("https://webaccess.psu.edu/"))
                            End If
                        End If
                    Catch ex As InvalidCastException

                    End Try 

                End If

                If course2.Length > 0 Then

                    'Dim result2 As String
                    result2 = webClient.DownloadString("http://mensajay.com/seatsLeft.php?semester=" & SEMESTER & "&courseID=" & course2)

                    For i As Integer = 1 To 10
                        If result2.Length = 0 Then
                            result2 = webClient.DownloadString("http://mensajay.com/seatsLeft.php?semester=" & SEMESTER & "&courseID=" & course2)
                        End If
                    Next

                    Try
                        If IsNumeric(result2) And Integer.Parse(result2) > 0 Then
                            If addingCourse2 = False And courseAdded2 = False And addError2.Length = 0 and autoAdd = true  Then
                                course2Browser.Navigate(New Uri("https://webaccess.psu.edu/"))
                            End If
                        End If
                    Catch ex As InvalidCastException

                    End Try

                End If

                If course3.Length > 0 Then

                    'Dim result3 As String
                    result3 = webClient.DownloadString("http://mensajay.com/seatsLeft.php?semester=" & SEMESTER & "&courseID=" & course3)

                    For i As Integer = 1 To 10
                        If result3.Length = 0 Then
                            result3 = webClient.DownloadString("http://mensajay.com/seatsLeft.php?semester=" & SEMESTER & "&courseID=" & course3)
                        End If
                    Next

                    Try
                        If IsNumeric(result3) And Integer.Parse(result3) > 0 Then
                            If addingCourse3 = False And courseAdded3 = False And addError3.Length = 0 and autoAdd = true  Then
                                course3Browser.Navigate(New Uri("https://webaccess.psu.edu/"))
                            End If
                        End If
                    Catch ex As InvalidCastException

                    End Try
                End If

                If course4.Length > 0 Then

                    'Dim result4 As String
                    result4 = webClient.DownloadString("http://mensajay.com/seatsLeft.php?semester=" & SEMESTER & "&courseID=" & course4)

                    For i As Integer = 1 To 10
                        If result4.Length = 0 Then
                            result4 = webClient.DownloadString("http://mensajay.com/seatsLeft.php?semester=" & SEMESTER & "&courseID=" & course4)
                        End If
                    Next

                    Try
                        If IsNumeric(result4) And Integer.Parse(result4) > 0 Then
                            If addingCourse4 = False And courseAdded4 = False And addError4.Length = 0 and autoAdd = true  Then
                                course4Browser.Navigate(New Uri("https://webaccess.psu.edu/"))
                            End If
                        End If
                    Catch ex As InvalidCastException

                    End Try

                End If

                successfulQueries = successfulQueries + 1
                updateSeatsThread.ReportProgress(100)

            Else
                updateSeatsThread.ReportProgress(404)
            End If


        Catch ex As System.Net.WebException
            updateSeatsThread.ReportProgress(404)
            failedQueries = failedQueries + 1
            'MsgBox("Error connecting to the psu course server, please check your internet connection and try again!", MsgBoxStyle.Critical, "Network Error")
        End Try

        'Console.WriteLine("add error 1 ->" & addError1)
        'Console.WriteLine("Updated Seats at " & System.DateTime.Now.ToLongTimeString)
        'Console.WriteLine("Successful Queries: " & successfulQueries)
        'Console.WriteLine("Failed Queries: " & failedQueries)
        'Console.WriteLine()

        Console.WriteLine(addingCourse1 & "-" & addingCourse2 & "-" & addingCourse3 & "-" & addingCourse4)

    End Sub

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Show()
        Label1.Focus()
        DisableSound()
        getSemesters()
        checkVersion()

        If My.Computer.FileSystem.DirectoryExists(userDocumentsDir & "\psuSeatCheck") Then

            Try
                If My.Computer.FileSystem.FileExists(userDocumentsDir & "\psuSeatCheck\currentSemester.txt") Then
                    'read semester file
                    Dim inputSemester As String = My.Computer.FileSystem.ReadAllText(userDocumentsDir & "\psuSeatCheck\currentSemester.txt")

                    If semesterBox.Items.Contains(inputSemester) Then
                        SEMESTER = inputSemester
                        semesterBox.SelectedItem = semesterBox.Items(semesterBox.Items.IndexOf(SEMESTER))
                    Else
                        SEMESTER = semesterBox.Items(0)
                        semesterBox.SelectedItem = semesterBox.Items(semesterBox.Items.IndexOf(SEMESTER))
                        My.Computer.FileSystem.WriteAllText(userDocumentsDir & "\psuSeatCheck\currentSemester.txt", semesterBox.Items(0), False)
                    End If
                Else
                    My.Computer.FileSystem.WriteAllText(userDocumentsDir & "\psuSeatCheck\currentSemester.txt", semesterBox.Items(0), False)
                    semesterBox.SelectedItem = semesterBox.Items(0)
                End If
            Catch ex As Exception

            End Try

        Else
            'Directory not found
            'BUG FIX
            'create psuSeatCheck directory
            Try
                My.Computer.FileSystem.CreateDirectory(userDocumentsDir & "\psuSeatCheck")
                SEMESTER = semesterBox.Items(0)
                semesterBox.SelectedItem = semesterBox.Items(semesterBox.Items.IndexOf(SEMESTER))
                My.Computer.FileSystem.WriteAllText(userDocumentsDir & "\psuSeatCheck\currentSemester.txt", semesterBox.Items(0), False)

            Catch ex As Exception

            End Try
            'SET runtime semester equal to first element in fetched semester array
            'write semester to file in seatCheck directory
            'test auto-updating
            'port to iphone???
        End If

            Try
                If My.Computer.FileSystem.FileExists(userDocumentsDir & "\psuSeatCheck\" & SEMESTER.Replace(" ", "_") & "_courseName1.txt") Then
                    course1Name = My.Computer.FileSystem.ReadAllText(userDocumentsDir & "\psuSeatCheck\" & SEMESTER.Replace(" ", "_") & "_courseName1.txt")
                Else
                    course1Name = ""
                End If

                If My.Computer.FileSystem.FileExists(userDocumentsDir & "\psuSeatCheck\" & SEMESTER.Replace(" ", "_") & "_courseName2.txt") Then
                    course2Name = My.Computer.FileSystem.ReadAllText(userDocumentsDir & "\psuSeatCheck\" & SEMESTER.Replace(" ", "_") & "_courseName2.txt")
                Else
                    course2Name = ""
                End If

                If My.Computer.FileSystem.FileExists(userDocumentsDir & "\psuSeatCheck\" & SEMESTER.Replace(" ", "_") & "_courseName3.txt") Then
                    course3Name = My.Computer.FileSystem.ReadAllText(userDocumentsDir & "\psuSeatCheck\" & SEMESTER.Replace(" ", "_") & "_courseName3.txt")
                Else
                    course3Name = ""
                End If

                If My.Computer.FileSystem.FileExists(userDocumentsDir & "\psuSeatCheck\" & SEMESTER.Replace(" ", "_") & "_courseName4.txt") Then
                    course4Name = My.Computer.FileSystem.ReadAllText(userDocumentsDir & "\psuSeatCheck\" & SEMESTER.Replace(" ", "_") & "_courseName4.txt")
                Else
                    course4Name = ""
                End If

                If My.Computer.FileSystem.FileExists(userDocumentsDir & "\psuSeatCheck\" & SEMESTER.Replace(" ", "_") & "_course1.txt") Then
                    course1 = My.Computer.FileSystem.ReadAllText(userDocumentsDir & "\psuSeatCheck\" & SEMESTER.Replace(" ", "_") & "_course1.txt")
                Else
                    course1 = ""
                End If

                If My.Computer.FileSystem.FileExists(userDocumentsDir & "\psuSeatCheck\" & SEMESTER.Replace(" ", "_") & "_course2.txt") Then
                    course2 = My.Computer.FileSystem.ReadAllText(userDocumentsDir & "\psuSeatCheck\" & SEMESTER.Replace(" ", "_") & "_course2.txt")
                Else
                    course2 = ""
                End If

                If My.Computer.FileSystem.FileExists(userDocumentsDir & "\psuSeatCheck\" & SEMESTER.Replace(" ", "_") & "_course3.txt") Then
                    course3 = My.Computer.FileSystem.ReadAllText(userDocumentsDir & "\psuSeatCheck\" & SEMESTER.Replace(" ", "_") & "_course3.txt")
                Else
                    course3 = ""
                End If

                If My.Computer.FileSystem.FileExists(userDocumentsDir & "\psuSeatCheck\" & SEMESTER.Replace(" ", "_") & "_course4.txt") Then
                    course4 = My.Computer.FileSystem.ReadAllText(userDocumentsDir & "\psuSeatCheck\" & SEMESTER.Replace(" ", "_") & "_course4.txt")
                Else
                    course4 = ""
                End If

                courseEntry.course1.Text = course1
                courseEntry.course1Name.Text = course1Name
                courseEntry.course2.Text = course2
                courseEntry.course2Name.Text = course2Name
                courseEntry.course3.Text = course3
                courseEntry.course3Name.Text = course3Name
                courseEntry.course4.Text = course4
                courseEntry.course4Name.Text = course4Name

                If course1.Length > 0 And course1Name.Length > 0 Then
                    course1IDLabel.Text = course1
                    course1NameLabel.Text = course1Name
                    course1Seats.Show()
                    fileDuplicateCheck.Add(course1, course1Name)
                End If

                If course2.Length > 0 And course2Name.Length > 0 Then
                    course2IDLabel.Text = course2
                    course2NameLabel.Text = course2Name
                    course2Seats.Show()
                    fileDuplicateCheck.Add(course2, course2Name)
                End If

                If course3.Length > 0 And course3Name.Length > 0 Then
                    course3IDLabel.Text = course3
                    course3NameLabel.Text = course3Name
                    course3Seats.Show()
                    fileDuplicateCheck.Add(course3, course3Name)
                End If

                If course4.Length > 0 And course4Name.Length > 0 Then
                    course4IDLabel.Text = course4
                    course4NameLabel.Text = course4Name
                    course4Seats.Show()
                    fileDuplicateCheck.Add(course4, course4Name)
                End If

                'AUTO-ADD CONFIG

                If My.Computer.FileSystem.FileExists(userDocumentsDir & "\psuSeatCheck\myUsername.txt") And My.Computer.FileSystem.FileExists(userDocumentsDir & "\psuSeatCheck\myPassword.txt") Then
                    Dim inputUsername As String = My.Computer.FileSystem.ReadAllText(userDocumentsDir & "\psuSeatCheck\myUsername.txt")
                    Dim inputPassword As String = My.Computer.FileSystem.ReadAllText(userDocumentsDir & "\psuSeatCheck\myPassword.txt")

                    If inputUsername.Length > 0 And inputPassword.Length > 0 Then
                        autoAddConfig.username = inputUsername
                        autoAddConfig.password = inputPassword
                        authenticationBrowser.Navigate(New Uri("https://webaccess.psu.edu"))
                    End If
                Else
                    autoAddConfig.autoAddEnabled = False
                End If

                appNewsLabel.Show()
                semesterLabel.Text = SEMESTER & " Watchlist"
                updateSeatsThread.RunWorkerAsync()

                seatCheckTimer.Start()

                'Reset add function incase of two factor timeout or other error (15 second timeout)
                Dim addResetTimer As New System.Windows.Forms.Timer
                addResetTimer.Interval = 15000
                addResetTimer.Start()
                AddHandler addResetTimer.Tick, Sub()
                    addingCourse1 = False
                    addingCourse2 = False
                    addingCourse3 = False
                    addingCourse4 = False
                End Sub

                'Reset add function incase of two factor timeout or other error (15 second timeout)
                Dim updateAskTimer As New System.Windows.Forms.Timer
                updateAskTimer.Interval = (86400 * 1000) '86400 seconds * 1000 (for miliseconds. Represents 1 Day as the update re-ask timer)
                updateAskTimer.Start()
                AddHandler updateAskTimer.Tick, Sub()
                    updateHasShownToday = False
                End Sub

            Catch ex As System.ArgumentException

                If course1.Length > 0 And course1Name.Length > 0 Then
                    course1Seats.ForeColor = Color.Red
                    course1Seats.Text = "Dupli_ID_Error"
                End If

                If course2.Length > 0 And course2Name.Length > 0 Then
                    course2Seats.ForeColor = Color.Red
                    course2Seats.Text = "Dupli_ID_Error"
                End If

                If course3.Length > 0 And course3Name.Length > 0 Then
                    course3Seats.ForeColor = Color.Red
                    course3Seats.Text = "Dupli_ID_Error"
                End If

                If course4.Length > 0 And course4Name.Length > 0 Then
                    course4Seats.ForeColor = Color.Red
                    course4Seats.Text = "Dupli_ID_Error"
                End If

                MsgBox("Duplicate Course ID's entered, each course ID must be unique. Seat count cannot be updated until this is corrected. Fix this by editing your watchlist.", MsgBoxStyle.Critical, "Error!!! Duplicate ID's")
            End Try

    End Sub

    Private Sub courseEntry_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If restartFlag = False Then
            e.Cancel = True
            Me.WindowState = FormWindowState.Minimized
            Me.Visible = False
        Else
            'proceed with closing
        End If
    End Sub

    Private Sub courseEntry_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            'Me.WindowState = FormWindowState.Minimized
            Me.Visible = False
            TrayIcon.ShowBalloonTip(1000, "PSU Seat Check", "PSU Seacheck will continue running in the tray, double click the tray icon to restore the program", ToolTipIcon.Info)
        End If
    End Sub

    Private Sub TrayIcon_DblClick(sender As Object, e As MouseEventArgs) Handles TrayIcon.DoubleClick

        For Each Form As System.Windows.Forms.Form In Application.OpenForms()
            Form.Hide()
        Next

        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub browserDocumentComplete(sender As System.Windows.Forms.WebBrowser, e As WebBrowserDocumentCompletedEventArgs) Handles authenticationBrowser.DocumentCompleted,
        course1Browser.DocumentCompleted, course2Browser.DocumentCompleted, course3Browser.DocumentCompleted, course4Browser.DocumentCompleted

        If sender Is authenticationBrowser Then

            If Not authenticationBrowser.IsBusy And authenticationBrowser.Document.Url.ToString = "https://webaccess.psu.edu/" And authenticationBrowser.DocumentText.IndexOf("incorrect") = -1 And authenticationBrowser.DocumentText.IndexOf("value=""2fa""") = -1 Then

                authenticationBrowser.Document.GetElementById("login").SetAttribute("value", autoAddConfig.username)
                authenticationBrowser.Document.GetElementById("password").SetAttribute("value", autoAddConfig.password)
                authenticationBrowser.Document.Forms.Item(0).InvokeMember("submit")
                'Console.WriteLine("completed normal page")
                'Else
                'Console.WriteLine("on two factor prompt page")
                'twoFactorFlag = True
                'authenticationBrowser.Document.Forms.Item(0).Children.Item(8).FirstChild.InvokeMember("click")
                'Console.WriteLine("submitted request")
            End If

            'Console.WriteLine("done")

            If Not authenticationBrowser.IsBusy And (authenticationBrowser.Document.Url.ToString = "https://webaccess.psu.edu/services/" Or authenticationBrowser.DocumentText.IndexOf("value=""2fa""") <> -1) Then
                autoAddConfig.autoAddEnabled = True
                autoAddConfig.WebBrowser1.Hide() 'CHANGE TO WEB BROWSER 1
                autoAddConfig.usernameLabel.Text = autoAddConfig.username
                Console.WriteLine("User Authenticated")
                autoAdd = True 
            ElseIf authenticationBrowser.DocumentText.IndexOf("incorrect") <> -1 Then
                autoAddConfig.username = ""
                autoAddConfig.password = ""
                MsgBox("PSU authentication failed with the supplied credentials, try re-entering them on the Auto-Add Page", MsgBoxStyle.Critical, "Invalid Credentials")
            End If

        ElseIf autoAddConfig.autoAddEnabled = True Then

        If sender Is course1Browser Then

            addingCourse1 = True

            'Reset add function incase of two factor timeout or other error (15 second timeout)
            Dim addResetTimer As New System.Windows.Forms.Timer
            addResetTimer.Interval = 15000
            'addResetTimer.Start()
            AddHandler addResetTimer.Tick, Sub()
                addResetTimer.Stop()
                If addingCourse1 = True
                    addingCourse1 = False
                End If
            End Sub

            Dim course1Browser As System.Windows.Forms.WebBrowser = sender

            If Not course1Browser.IsBusy And course1Browser.Document.Url.ToString = "https://webaccess.psu.edu/" Then
                course1Browser.Document.GetElementById("login").SetAttribute("value", autoAddConfig.username)
                course1Browser.Document.GetElementById("password").SetAttribute("value", autoAddConfig.password)
                course1Browser.Document.Forms.Item(0).InvokeMember("submit")
            End If

            If Not course1Browser.IsBusy And course1Browser.Document.Url.ToString = "https://webaccess.psu.edu/services/" Then
                course1Browser.Navigate(New Uri("https://elionvw.ais.psu.edu/cgi-bin/elion-student.exe/submit/goRegistration"))
            End If

            If Not course1Browser.IsBusy And course1Browser.Document.Url.ToString = "https://webaccess.psu.edu/?cosign-elionvw.ais.psu.edu&https://elionvw.ais.psu.edu/cgi-bin/elion-student.exe/submit/goRegistration"
                Dim twoFactorTimer As New System.Windows.Forms.Timer
                twoFactorTimer.Interval = 500
                twoFactorTimer.Start()
                AddHandler twoFactorTimer.Tick, Sub()
                    twoFactorTimer.Stop()
                    course1Browser.Document.Forms.Item(0).Children.Item(8).FirstChild.InvokeMember("click")
                End Sub
            End If

            If Not course1Browser.IsBusy And course1Browser.Document.Url.ToString = "https://elionvw.ais.psu.edu/cgi-bin/elion-student.exe/submit/goRegistration" Then

                'grab all input elements as collections
                Dim submitElement As System.Windows.Forms.HtmlElement
                Dim inputElements As System.Windows.Forms.HtmlElementCollection
                inputElements = course1Browser.Document.GetElementsByTagName("input")
                'iterate through each and if getattribute type = radio then store those in html element dictionary
                Dim radioButtons As New Dictionary(Of String, System.Windows.Forms.HtmlElement)
                For Each element As System.Windows.Forms.HtmlElement In inputElements
                    If element.GetAttribute("type") = "radio" Then
                        radioButtons.Add(element.GetAttribute("value"), element)
                    End If

                    If element.GetAttribute("type") = "submit" Then
                        submitElement = element
                    End If
                Next
                'from there use radio ID attribute to get respective label string & location
                Dim finalRadioArray As New Dictionary(Of String, System.Windows.Forms.HtmlElement)
                For Each radioValue As String In radioButtons.Keys
                    Dim labelStart As Integer = course1Browser.DocumentText.LastIndexOf(radioValue & """ />", StringComparison.OrdinalIgnoreCase) + 2
                    'Console.WriteLine(labelStart)
                    Dim newSubstring As String = course1Browser.DocumentText.Substring(labelStart + 7)
                    Dim tdEnd As Integer = newSubstring.IndexOf("</td>", StringComparison.OrdinalIgnoreCase)
                    finalRadioArray.Add(newSubstring.Substring(0, tdEnd).Trim, radioButtons.Item(radioValue))
                Next

                Try
                    finalRadioArray.Item(SEMESTER).InvokeMember("click")
                Catch ex As System.Collections.Generic.KeyNotFoundException
                    ''Not sure how to respond to this error quite yet will take time, but this prevents crashing
                End Try

                submitElement.InvokeMember("click")

            End If

            If Not course1Browser.IsBusy And course1Browser.DocumentText.IndexOf("re-enter your password") <> -1 Then
                course1Browser.Document.GetElementsByTagName("input").Item(0).SetAttribute("value", autoAddConfig.password)
                course1Browser.Document.GetElementsByTagName("input").Item(1).InvokeMember("click")
            End If

            If Not course1Browser.IsBusy And course1Browser.DocumentText.IndexOf("Courses Scheduled - " & SEMESTER, StringComparison.OrdinalIgnoreCase) <> -1 And course1Browser.DocumentText.IndexOf("Enrollment request successfully updated") = -1 And course1Browser.DocumentText.IndexOf("Error Message") = -1 And course1Browser.DocumentText.IndexOf(course1, StringComparison.OrdinalIgnoreCase) = -1 And course1Browser.DocumentText.IndexOf("time conflict", StringComparison.OrdinalIgnoreCase) = -1 Then

                For Each element As HtmlElement In course1Browser.Document.GetElementsByTagName("input")

                    If element.GetAttribute("type") = "text" Then
                        element.SetAttribute("value", course1)
                    End If

                    If element.GetAttribute("value") = "Add course to schedule" Then
                        element.InvokeMember("click")
                    End If

                Next

            ElseIf course1Browser.DocumentText.IndexOf(course1, StringComparison.OrdinalIgnoreCase) <> -1 And course1Browser.DocumentText.IndexOf("Watch List", StringComparison.OrdinalIgnoreCase) > course1Browser.DocumentText.IndexOf(course1, StringComparison.OrdinalIgnoreCase) And course1Browser.DocumentText.IndexOf("Enrollment request successfully updated", StringComparison.OrdinalIgnoreCase) = -1 Then
                addError1 = "Already Enrolled"
                course1Seats.ForeColor = Color.Red
                course1Seats.Text = "Crse_Add_Err"
                courseAdded1 = False
                addingCourse1 = False

            ElseIf course1Browser.DocumentText.IndexOf("time conflict", StringComparison.OrdinalIgnoreCase) <> -1 Then
                addError1 = "Time Conflict"
                course1Seats.ForeColor = Color.Red
                course1Seats.Text = "Crse_Add_Err"
                courseAdded1 = False
                addingCourse1 = False

            ElseIf course1Browser.DocumentText.IndexOf("Enrollment request successfully updated") <> -1 Or course1Browser.DocumentText.IndexOf("Error Message") <> -1 Then

                If course1Browser.DocumentText.IndexOf("Enrollment request successfully updated") <> -1 Then
                    course1Seats.ForeColor = Color.Green
                    course1Seats.Text = "Crse_Added"
                    courseAdded1 = True
                    addingCourse1 = False

                ElseIf course1Browser.DocumentText.IndexOf("Error Message") <> -1 Then
                    addError1 = "Error Adding Course. Try manually on eLion"
                    course1Seats.ForeColor = Color.Red
                    course1Seats.Text = "Crse_Add_Err"
                    courseAdded1 = False
                    addingCourse1 = False

                End If

            End If

        End If

        If sender Is course2Browser Then

            addingCourse2 = True

            'Reset add function incase of two factor timeout or other error (15 second timeout)
            Dim addResetTimer As New System.Windows.Forms.Timer
            addResetTimer.Interval = 15000
            'addResetTimer.Start()
            AddHandler addResetTimer.Tick, Sub()
                addResetTimer.Stop()
                If addingCourse2 = True
                    addingCourse2 = False
                End If
            End Sub

            Dim course2Browser As System.Windows.Forms.WebBrowser = sender

            If Not course2Browser.IsBusy And course2Browser.Document.Url.ToString = "https://webaccess.psu.edu/" Then
                course2Browser.Document.GetElementById("login").SetAttribute("value", autoAddConfig.username)
                course2Browser.Document.GetElementById("password").SetAttribute("value", autoAddConfig.password)
                course2Browser.Document.Forms.Item(0).InvokeMember("submit")
            End If

            If Not course2Browser.IsBusy And course2Browser.Document.Url.ToString = "https://webaccess.psu.edu/services/" Then
                course2Browser.Navigate(New Uri("https://elionvw.ais.psu.edu/cgi-bin/elion-student.exe/submit/goRegistration"))
            End If

            If Not course2Browser.IsBusy And course2Browser.Document.Url.ToString = "https://webaccess.psu.edu/?cosign-elionvw.ais.psu.edu&https://elionvw.ais.psu.edu/cgi-bin/elion-student.exe/submit/goRegistration"
                Dim twoFactorTimer As New System.Windows.Forms.Timer
                twoFactorTimer.Interval = 500
                'twoFactorTimer.Start()
                AddHandler twoFactorTimer.Tick, Sub()
                    twoFactorTimer.Stop()
                    course2Browser.Document.Forms.Item(0).Children.Item(8).FirstChild.InvokeMember("click")
                End Sub
            End If

            If Not course2Browser.IsBusy And course2Browser.Document.Url.ToString = "https://elionvw.ais.psu.edu/cgi-bin/elion-student.exe/submit/goRegistration" Then

                'grab all input elements as collections
                Dim submitElement As System.Windows.Forms.HtmlElement
                Dim inputElements As System.Windows.Forms.HtmlElementCollection
                inputElements = course2Browser.Document.GetElementsByTagName("input")
                'iterate through each and if getattribute type = radio then store those in html element dictionary
                Dim radioButtons As New Dictionary(Of String, System.Windows.Forms.HtmlElement)
                For Each element As System.Windows.Forms.HtmlElement In inputElements
                    If element.GetAttribute("type") = "radio" Then
                        radioButtons.Add(element.GetAttribute("value"), element)
                    End If

                    If element.GetAttribute("type") = "submit" Then
                        submitElement = element
                    End If
                Next
                'from there use radio ID attribute to get respective label string & location
                Dim finalRadioArray As New Dictionary(Of String, System.Windows.Forms.HtmlElement)
                For Each radioValue As String In radioButtons.Keys
                    Dim labelStart As Integer = course2Browser.DocumentText.LastIndexOf(radioValue & """ />", StringComparison.OrdinalIgnoreCase) + 2
                    'Console.WriteLine(labelStart)
                    Dim newSubstring As String = course2Browser.DocumentText.Substring(labelStart + 7)
                    Dim tdEnd As Integer = newSubstring.IndexOf("</td>", StringComparison.OrdinalIgnoreCase)
                    finalRadioArray.Add(newSubstring.Substring(0, tdEnd).Trim, radioButtons.Item(radioValue))
                Next

                Try
                    finalRadioArray.Item(SEMESTER).InvokeMember("click")
                Catch ex As System.Collections.Generic.KeyNotFoundException
                    ''Not sure how to respond to this error quite yet will take time, but this prevents crashing
                End Try

                submitElement.InvokeMember("click")

            End If

            If Not course2Browser.IsBusy And course2Browser.DocumentText.IndexOf("re-enter your password") <> -1 Then
                course2Browser.Document.GetElementsByTagName("input").Item(0).SetAttribute("value", autoAddConfig.password)
                course2Browser.Document.GetElementsByTagName("input").Item(1).InvokeMember("click")
            End If

            If Not course2Browser.IsBusy And course2Browser.DocumentText.IndexOf("Courses Scheduled - " & SEMESTER, StringComparison.OrdinalIgnoreCase) <> -1 And course2Browser.DocumentText.IndexOf("Enrollment request successfully updated") = -1 And course2Browser.DocumentText.IndexOf("Error Message") = -1 And course2Browser.DocumentText.IndexOf(course2, StringComparison.OrdinalIgnoreCase) = -1 And course2Browser.DocumentText.IndexOf("time conflict", StringComparison.OrdinalIgnoreCase) = -1 Then

                For Each element As HtmlElement In course2Browser.Document.GetElementsByTagName("input")

                    If element.GetAttribute("type") = "text" Then
                        element.SetAttribute("value", course2)
                    End If

                    If element.GetAttribute("value") = "Add course to schedule" Then
                        element.InvokeMember("click")
                    End If

                Next
            ElseIf course2Browser.DocumentText.IndexOf(course2, StringComparison.OrdinalIgnoreCase) <> -1 And course2Browser.DocumentText.IndexOf("Watch List", StringComparison.OrdinalIgnoreCase) > course2Browser.DocumentText.IndexOf(course2, StringComparison.OrdinalIgnoreCase) And course2Browser.DocumentText.IndexOf("Enrollment request successfully updated", StringComparison.OrdinalIgnoreCase) = -1 Then
                addError2 = "Already Enrolled"
                course2Seats.ForeColor = Color.Red
                course2Seats.Text = "Crse_Add_Err"
                courseAdded2 = False
                addingCourse2 = False

            ElseIf course2Browser.DocumentText.IndexOf("time conflict", StringComparison.OrdinalIgnoreCase) <> -1 Then
                addError2 = "Time Conflict"
                course2Seats.ForeColor = Color.Red
                course2Seats.Text = "Crse_Add_Err"
                courseAdded2 = False
                addingCourse2 = False

            ElseIf course2Browser.DocumentText.IndexOf("Enrollment request successfully updated") <> -1 Or course2Browser.DocumentText.IndexOf("Error Message") <> -1 Then

                If course2Browser.DocumentText.IndexOf("Enrollment request successfully updated") <> -1 Then
                    course2Seats.ForeColor = Color.Green
                    course2Seats.Text = "Crse_Added"
                    courseAdded2 = True
                    addingCourse2 = False

                ElseIf course2Browser.DocumentText.IndexOf("Error Message") <> -1 Then

                    addError2 = "Error Adding Course. Try manually on eLion"
                    course2Seats.ForeColor = Color.Red
                    course2Seats.Text = "Crse_Add_Err"
                    courseAdded2 = False
                    addingCourse2 = False

                End If

            End If

        End If

        If sender Is course3Browser Then

            addingCourse3 = True

            'Reset add function incase of two factor timeout or other error (15 second timeout)
            Dim addResetTimer As New System.Windows.Forms.Timer
            addResetTimer.Interval = 15000
            'addResetTimer.Start()
            AddHandler addResetTimer.Tick, Sub()
                addResetTimer.Stop()
                If addingCourse3 = True
                    addingCourse3 = False
                End If
            End Sub

            Dim course3Browser As System.Windows.Forms.WebBrowser = sender

            'MsgBox(course3Browser.Document.Url.ToString)

            If Not course3Browser.IsBusy And course3Browser.Document.Url.ToString = "https://webaccess.psu.edu/" Then
                'Non two-factor login page
                course3Browser.Document.GetElementById("login").SetAttribute("value", autoAddConfig.username)
                course3Browser.Document.GetElementById("password").SetAttribute("value", autoAddConfig.password)
                course3Browser.Document.Forms.Item(0).InvokeMember("submit")
            End If

            If Not course3Browser.IsBusy And course3Browser.Document.Url.ToString = "https://webaccess.psu.edu/services/" Then
                course3Browser.Navigate(New Uri("https://elionvw.ais.psu.edu/cgi-bin/elion-student.exe/submit/goRegistration"))
            End If

            If Not course3Browser.IsBusy And course3Browser.Document.Url.ToString = "https://webaccess.psu.edu/?cosign-elionvw.ais.psu.edu&https://elionvw.ais.psu.edu/cgi-bin/elion-student.exe/submit/goRegistration"
                Dim twoFactorTimer As New System.Windows.Forms.Timer
                twoFactorTimer.Interval = 500
                twoFactorTimer.Start()
                AddHandler twoFactorTimer.Tick, Sub()
                    twoFactorTimer.Stop()
                    course3Browser.Document.Forms.Item(0).Children.Item(8).FirstChild.InvokeMember("click")
                End Sub
            End If

            If Not course3Browser.IsBusy And course3Browser.Document.Url.ToString = "https://elionvw.ais.psu.edu/cgi-bin/elion-student.exe/submit/goRegistration" Then

                'grab all input elements as collections
                Dim submitElement As System.Windows.Forms.HtmlElement
                Dim inputElements As System.Windows.Forms.HtmlElementCollection
                inputElements = course3Browser.Document.GetElementsByTagName("input")
                'iterate through each and if getattribute type = radio then store those in html element dictionary
                Dim radioButtons As New Dictionary(Of String, System.Windows.Forms.HtmlElement)
                For Each element As System.Windows.Forms.HtmlElement In inputElements
                    If element.GetAttribute("type") = "radio" Then
                        radioButtons.Add(element.GetAttribute("value"), element)
                    End If

                    If element.GetAttribute("type") = "submit" Then
                        submitElement = element
                    End If
                Next
                'from there use radio ID attribute to get respective label string & location
                Dim finalRadioArray As New Dictionary(Of String, System.Windows.Forms.HtmlElement)
                For Each radioValue As String In radioButtons.Keys
                    Dim labelStart As Integer = course3Browser.DocumentText.LastIndexOf(radioValue & """ />", StringComparison.OrdinalIgnoreCase) + 2
                    'Console.WriteLine(labelStart)
                    Dim newSubstring As String = course3Browser.DocumentText.Substring(labelStart + 7)
                    Dim tdEnd As Integer = newSubstring.IndexOf("</td>", StringComparison.OrdinalIgnoreCase)
                    finalRadioArray.Add(newSubstring.Substring(0, tdEnd).Trim, radioButtons.Item(radioValue))
                Next

                Try
                    finalRadioArray.Item(SEMESTER).InvokeMember("click")
                Catch ex As System.Collections.Generic.KeyNotFoundException
                    ''Not sure how to respond to this error quite yet will take time, but this prevents crashing
                End Try

                submitElement.InvokeMember("click")

            End If

            If Not course3Browser.IsBusy And course3Browser.DocumentText.IndexOf("re-enter your password") <> -1 Then
                course3Browser.Document.GetElementsByTagName("input").Item(0).SetAttribute("value", autoAddConfig.password)
                course3Browser.Document.GetElementsByTagName("input").Item(1).InvokeMember("click")
            End If

            If Not course3Browser.IsBusy And course3Browser.DocumentText.IndexOf("Courses Scheduled - " & SEMESTER, StringComparison.OrdinalIgnoreCase) <> -1 And course3Browser.DocumentText.IndexOf("Enrollment request successfully updated") = -1 And course3Browser.DocumentText.IndexOf("Error Message") = -1 And course3Browser.DocumentText.IndexOf(course3, StringComparison.OrdinalIgnoreCase) = -1 And course3Browser.DocumentText.IndexOf("time conflict", StringComparison.OrdinalIgnoreCase) = -1 Then

                For Each element As HtmlElement In course3Browser.Document.GetElementsByTagName("input")

                    If element.GetAttribute("type") = "text" Then
                        element.SetAttribute("value", course3)
                    End If

                    If element.GetAttribute("value") = "Add course to schedule" Then
                        element.InvokeMember("click")
                    End If

                Next

            ElseIf course3Browser.DocumentText.IndexOf(course3, StringComparison.OrdinalIgnoreCase) <> -1 And course3Browser.DocumentText.IndexOf("Watch List", StringComparison.OrdinalIgnoreCase) > course3Browser.DocumentText.IndexOf(course3, StringComparison.OrdinalIgnoreCase) And course3Browser.DocumentText.IndexOf("Enrollment request successfully updated", StringComparison.OrdinalIgnoreCase) = -1 Then
                addError3 = "Already Enrolled"
                course3Seats.ForeColor = Color.Red
                course3Seats.Text = "Crse_Add_Err"
                courseAdded3 = false
                addingCourse3 = False
            ElseIf course3Browser.DocumentText.IndexOf("time conflict", StringComparison.OrdinalIgnoreCase) <> -1 Then
                addError3 = "Time Conflict"
                course3Seats.ForeColor = Color.Red
                course3Seats.Text = "Crse_Add_Err"
                courseAdded3  = false
                addingCourse3 = False
            ElseIf course3Browser.DocumentText.IndexOf("Enrollment request successfully updated") <> -1 Or course3Browser.DocumentText.IndexOf("Error Message") <> -1 Then

                If course3Browser.DocumentText.IndexOf("Enrollment request successfully updated") <> -1 Then

                    'MsgBox("Course Successfully Added")
                    course3Seats.ForeColor = Color.Green
                    course3Seats.Text = "Crse_Added"
                    courseAdded3 = True
                    addingCourse3 = False

                ElseIf course3Browser.DocumentText.IndexOf("Error Message") <> -1 Then

                    'MsgBox("Error Adding Course. Check Elion to see if all requirements have been met, and that there are no time conflicts.")
                    addError3 = "Error Adding Course. Try manually on eLion"
                    course3Seats.ForeColor = Color.Red
                    course3Seats.Text = "Crse_Add_Err"
                    courseAdded3 = False
                    addingCourse3 = False

                End If

            End If

        End If

        If sender Is course4Browser Then

            addingCourse4 = True

            'Reset add function incase of two factor timeout or other error (15 second timeout)
            Dim addResetTimer As New System.Windows.Forms.Timer
            addResetTimer.Interval = 15000
            'addResetTimer.Start()
            AddHandler addResetTimer.Tick, Sub()
                addResetTimer.Stop()
                If addingCourse1 = True
                    addingCourse1 = False
                End If
            End Sub

            Dim course4Browser As System.Windows.Forms.WebBrowser = sender

            If Not course4Browser.IsBusy And course4Browser.Document.Url.ToString = "https://webaccess.psu.edu/" Then
                course4Browser.Document.GetElementById("login").SetAttribute("value", autoAddConfig.username)
                course4Browser.Document.GetElementById("password").SetAttribute("value", autoAddConfig.password)
                course4Browser.Document.Forms.Item(0).InvokeMember("submit")
            End If

            If Not course4Browser.IsBusy And course4Browser.Document.Url.ToString = "https://webaccess.psu.edu/services/" Then
                course4Browser.Navigate(New Uri("https://elionvw.ais.psu.edu/cgi-bin/elion-student.exe/submit/goRegistration"))
            End If

            If Not course4Browser.IsBusy And course4Browser.Document.Url.ToString = "https://webaccess.psu.edu/?cosign-elionvw.ais.psu.edu&https://elionvw.ais.psu.edu/cgi-bin/elion-student.exe/submit/goRegistration"
                Dim twoFactorTimer As New System.Windows.Forms.Timer
                twoFactorTimer.Interval = 500
                twoFactorTimer.Start()
                AddHandler twoFactorTimer.Tick, Sub()
                    twoFactorTimer.Stop()
                End Sub
            End If

            If Not course4Browser.IsBusy And course4Browser.Document.Url.ToString = "https://elionvw.ais.psu.edu/cgi-bin/elion-student.exe/submit/goRegistration" Then

                'grab all input elements as collections
                Dim submitElement As System.Windows.Forms.HtmlElement
                Dim inputElements As System.Windows.Forms.HtmlElementCollection
                inputElements = course4Browser.Document.GetElementsByTagName("input")
                'iterate through each and if getattribute type = radio then store those in html element dictionary
                Dim radioButtons As New Dictionary(Of String, System.Windows.Forms.HtmlElement)
                For Each element As System.Windows.Forms.HtmlElement In inputElements
                    If element.GetAttribute("type") = "radio" Then
                        radioButtons.Add(element.GetAttribute("value"), element)
                    End If

                    If element.GetAttribute("type") = "submit" Then
                        submitElement = element
                    End If
                Next
                'from there use radio ID attribute to get respective label string & location
                Dim finalRadioArray As New Dictionary(Of String, System.Windows.Forms.HtmlElement)
                For Each radioValue As String In radioButtons.Keys
                    Dim labelStart As Integer = course4Browser.DocumentText.LastIndexOf(radioValue & """ />", StringComparison.OrdinalIgnoreCase) + 2
                    'Console.WriteLine(labelStart)
                    Dim newSubstring As String = course4Browser.DocumentText.Substring(labelStart + 7)
                    Dim tdEnd As Integer = newSubstring.IndexOf("</td>", StringComparison.OrdinalIgnoreCase)
                    finalRadioArray.Add(newSubstring.Substring(0, tdEnd).Trim, radioButtons.Item(radioValue))
                Next

                Try
                    finalRadioArray.Item(SEMESTER).InvokeMember("click")
                Catch ex As System.Collections.Generic.KeyNotFoundException
                    ''Not sure how to respond to this error quite yet will take time, but this prevents crashing
                End Try

                submitElement.InvokeMember("click")

            End If

            If Not course4Browser.IsBusy And course4Browser.DocumentText.IndexOf("re-enter your password") <> -1 Then
                course4Browser.Document.GetElementsByTagName("input").Item(0).SetAttribute("value", autoAddConfig.password)
                course4Browser.Document.GetElementsByTagName("input").Item(1).InvokeMember("click")
            End If

            If Not course4Browser.IsBusy And course4Browser.DocumentText.IndexOf("Courses Scheduled - " & SEMESTER, StringComparison.OrdinalIgnoreCase) <> -1 And course4Browser.DocumentText.IndexOf("Enrollment request successfully updated") = -1 And course4Browser.DocumentText.IndexOf("Error Message") = -1 And course4Browser.DocumentText.IndexOf(course4, StringComparison.OrdinalIgnoreCase) = -1 And course4Browser.DocumentText.IndexOf("time conflict", StringComparison.OrdinalIgnoreCase) = -1 Then

                For Each element As HtmlElement In course4Browser.Document.GetElementsByTagName("input")

                    If element.GetAttribute("type") = "text" Then
                        element.SetAttribute("value", course4)
                    End If

                    If element.GetAttribute("value") = "Add course to schedule" Then
                        element.InvokeMember("click")
                    End If

                Next

            ElseIf course4Browser.DocumentText.IndexOf(course4, StringComparison.OrdinalIgnoreCase) <> -1 And course4Browser.DocumentText.IndexOf("Watch List", StringComparison.OrdinalIgnoreCase) > course4Browser.DocumentText.IndexOf(course4, StringComparison.OrdinalIgnoreCase) And course4Browser.DocumentText.IndexOf("Enrollment request successfully updated", StringComparison.OrdinalIgnoreCase) = -1 Then
                addError4 = "Already Enrolled"
                course4Seats.ForeColor = Color.Red
                course4Seats.Text = "Crse_Add_Err"
                courseAdded4 = False
                addingCourse4 = False

            ElseIf course4Browser.DocumentText.IndexOf("time conflict", StringComparison.OrdinalIgnoreCase) <> -1 Then
                addError4 = "Time Conflict"
                course4Seats.ForeColor = Color.Red
                course4Seats.Text = "Crse_Add_Err"
                courseAdded4 = False
                addingCourse4 = False

            ElseIf course4Browser.DocumentText.IndexOf("Enrollment request successfully updated") <> -1 Or course4Browser.DocumentText.IndexOf("Error Message") <> -1 Then

                If course4Browser.DocumentText.IndexOf("Enrollment request successfully updated") <> -1 Then

                    'MsgBox("Course Successfully Added")
                    course4Seats.ForeColor = Color.Green
                    course4Seats.Text = "Crse_Added"
                    courseAdded4 = True
                    addingCourse4 = false

                ElseIf course4Browser.DocumentText.IndexOf("Error Message") <> -1 Then

                    'MsgBox("Error Adding Course. Check Elion to see if all requirements have been met, and that there are no time conflicts.")
                    addError4 = "Error Adding Course. Try manually on eLion"
                    course4Seats.ForeColor = Color.Red
                    course4Seats.Text = "Crse_Add_Err"
                    courseAdded4 = False
                    addingCourse4 = False

                End If

            End If

        End If

        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles editWatchlistButton.Click
        Me.Hide()
        courseEntry.Show()
        courseEntry.WindowState = FormWindowState.Normal
        courseEntry.Activate()
        courseEntry.BringToFront()
    End Sub

    Private Sub openElionButton_Click(sender As Object, e As EventArgs) Handles openElionButton.Click
        Process.Start("https://elionvw.ais.psu.edu/cgi-bin/elion-student.exe/submit/goRegistration")
    End Sub

    Private Sub seatCheckTimer_Tick(sender As Object, e As EventArgs) Handles seatCheckTimer.Tick
        If Not updateSeatsThread.IsBusy Then
            updateSeatsThread.RunWorkerAsync()
        End If
    End Sub

    Private Sub updateSeatsThread_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles updateSeatsThread.DoWork
        updateSeatCount()
    End Sub

    Private Sub updateSeatsThread_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles updateSeatsThread.ProgressChanged
        'Console.WriteLine(e.ProgressPercentage)
        If e.ProgressPercentage = 0 Then
            Me.Text = "PSU Seat Check v" & VERSION & " ........UPDATING SEAT COUNT......."
        End If

        If e.ProgressPercentage = 404 Then

            If My.Computer.FileSystem.DirectoryExists(userDocumentsDir & "\psuSeatCheck") Then

                Try
                    My.Computer.FileSystem.WriteAllText(userDocumentsDir & "\psuSeatCheck\lastError.txt", System.DateTime.Now.ToLongDateString & " --- " & System.DateTime.Now.ToLongTimeString & vbNewLine, true)
                Catch ex As Exception

                End Try

            End If


            Me.Text = "PSU Seat Check ....CANNOT ACCESS SERVER!! NETWORK ERROR!!!"
            course1Seats.ForeColor = Color.Red
            course1Seats.Text = "Network_Error!"
            course2Seats.ForeColor = Color.Red
            course2Seats.Text = "Network_Error!"
            course3Seats.ForeColor = Color.Red
            course3Seats.Text = "Network_Error!"
            course4Seats.ForeColor = Color.Red
            course4Seats.Text = "Network_Error!"

            TrayIcon.BalloonTipIcon = ToolTipIcon.Error
            TrayIcon.BalloonTipTitle = "Network Issues... PSU Seat Check"
            TrayIcon.BalloonTipText = "PSU Seat Check is having issues accessing the internet, please check your connection. PSU Seat check requires an active internet connection to monitor for seat openings"
            TrayIcon.ShowBalloonTip(7500)
            Me.Focus()
        End If

        If e.ProgressPercentage = 100 Then

            Dim seatsAvalible As New Dictionary(Of Integer, Integer)
            Dim courseNames As New Dictionary(Of Integer, String)

            'update app news feed
            If appNewsString.Contains("[URGENT]") Then
                appNewsLabel.ForeColor = Color.Red
            Else
                appNewsLabel.ForeColor = Color.Black
            End If

            appNewsLabel.Text = appNewsString

            If course1.Length > 0 And courseAdded1 = False And addError1.Length = 0 Then
                course1Seats.Text = result1 & " Seat(s) Left"
                If result1 > 0 Then
                    course1Seats.ForeColor = Color.Green
                    seatsAvalible.Add(course1, result1)
                Else
                    course1Seats.ForeColor = Color.Red
                End If
                courseNames.Add(course1, course1Name)
            ElseIf courseAdded1 = True Then
                course1Seats.ForeColor = Color.Green
                course1Seats.Text = "Crse_Added"
            ElseIf addError1.Length > 0 Then
                course1Seats.ForeColor = Color.Red
                course1Seats.Text = "Crse_Add_Error"
            End If

            If course2.Length > 0 And courseAdded2 = False And addError2.Length = 0 Then
                course2Seats.Text = result2 & " Seat(s) Left"
                If result2 > 0 Then
                    course2Seats.ForeColor = Color.Green
                    seatsAvalible.Add(course2, result2)
                Else
                    course2Seats.ForeColor = Color.Red
                End If
                courseNames.Add(course2, course2Name)
            ElseIf courseAdded2 = True Then
                course2Seats.ForeColor = Color.Green
                course2Seats.Text = "Crse_Added"
            ElseIf addError2.Length > 0 Then
                course2Seats.ForeColor = Color.Red
                course2Seats.Text = "Crse_Add_Error"
            End If

            If course3.Length > 0 And courseAdded3 = False And addError3.Length = 0 Then
                course3Seats.Text = result3 & " Seat(s) Left"
                If result3 > 0 Then
                    course3Seats.ForeColor = Color.Green
                    seatsAvalible.Add(course3, result3)
                Else '
                    course3Seats.ForeColor = Color.Red
                End If
                courseNames.Add(course3, course3Name)
            ElseIf courseAdded3 = True Then
                course3Seats.ForeColor = Color.Green
                course3Seats.Text = "Crse_Added"
            ElseIf addError3.Length > 0 Then
                course3Seats.ForeColor = Color.Red
                course3Seats.Text = "Crse_Add_Error"
            End If

            If course4.Length > 0 And courseAdded4 = False And addError4.Length = 0 Then
                course4Seats.Text = result4 & " Seat(s) Left"
                If result4 > 0 Then
                    course4Seats.ForeColor = Color.Green
                    seatsAvalible.Add(course4, result4)
                Else
                    course4Seats.ForeColor = Color.Red
                End If
                courseNames.Add(course4, course4Name)
            ElseIf courseAdded4 = True Then
                course4Seats.ForeColor = Color.Green
                course4Seats.Text = "Crse_Added"
            ElseIf addError4.Length > 0 Then
                course4Seats.ForeColor = Color.Red
                course4Seats.Text = "Crse_Add_Error"
            End If

            TrayIcon.BalloonTipIcon = ToolTipIcon.Info

            If autoAddConfig.autoAddEnabled = False Then

                If seatsAvalible.Count = 1 Then
                    '1 course has seats avalible
                    If seatsAvalible.First.Value > 1 Then
                        'single course has multiple seats avalible
                        Dim courseName As String = courseNames.Item(seatsAvalible.First.Key)
                        TrayIcon.BalloonTipTitle = courseName & " ... SEATS AVAILBLE!!!"
                        TrayIcon.BalloonTipText = courseName & " (ID -> " & seatsAvalible.First.Key & ") has " & seatsAvalible.First.Value & " seats avalible!!! Click this tooltip to bring up PSU Seat Check, and open eLion"
                    Else
                        'single course has one seat avalible
                        Dim courseName As String = courseNames.Item(seatsAvalible.First.Key)
                        TrayIcon.BalloonTipTitle = courseName & " ... SEAT AVAILBLE!!!"
                        TrayIcon.BalloonTipText = courseName & " (ID -> " & seatsAvalible.First.Key & ") has " & seatsAvalible.First.Value & " seat avalible!!! Click this tooltip to bring up PSU Seat Check, and open eLion"
                    End If
                ElseIf seatsAvalible.Count > 1 Then
                    'multiple courses have seats availible
                    Dim courseList As String
                    For Each course As KeyValuePair(Of Integer, Integer) In seatsAvalible
                        'Console.WriteLine(course.Key & " --> " & course.Value)
                        courseList = courseList & courseNames.Item(course.Key) & " (" & course.Key & ") --> " & seatsAvalible.Item(course.Key) & " Seat(s) Left" & vbNewLine
                    Next
                    TrayIcon.BalloonTipTitle = "Multiple Courses Have Seats Availible!!!"
                    TrayIcon.BalloonTipText = courseList & vbNewLine & "Click this tooltip to bring up PSU Seat Check"
                End If

                If seatsAvalible.Count > 0 Then
                    TrayIcon.ShowBalloonTip(60000)
                    Me.Focus()
                End If

            ElseIf autoAddConfig.autoAddEnabled = True Then

                'show specialized notification
                TrayIcon.BalloonTipTitle = "PSU Seat Check - Auto Registration Update"
                TrayIcon.BalloonTipText = ""

               'FOR EACH ADD ERROR IF NAME AND ID ARE EMPTY, THEN ADDERROR = ""
                If course1Name = "" or course1 = ""
                    addError1 = ""
                    courseAdded1 = false
                End If
                If course2Name = "" or course2 = ""
                    addError2 = ""
                    courseAdded2 = false
                End If
                If course3Name = "" or course3 = ""
                    addError3 = ""
                    courseAdded3 = false
                End If
                If course4Name = "" or course4 = ""
                    addError4 = ""
                    courseAdded4 = false
                End If

                If courseAdded1 = True Then
                    TrayIcon.BalloonTipText = course1Name & " (ID -> " & course1 & ") successfully added" & vbNewLine
                End If
                If courseAdded2 = True Then
                    TrayIcon.BalloonTipText = TrayIcon.BalloonTipText & course2Name & " (ID -> " & course2 & ") successfully added" & vbNewLine
                End If
                If courseAdded3 = True Then
                    TrayIcon.BalloonTipText = TrayIcon.BalloonTipText & course3Name & " (ID -> " & course3 & ") successfully added" & vbNewLine
                End If
                If courseAdded4 = True Then
                    TrayIcon.BalloonTipText = TrayIcon.BalloonTipText & course4Name & " (ID -> " & course4 & ") successfully added" & vbNewLine
                End If

                'MsgBox(addError1 & " ---- " & addError4)

                If addError1.Length > 0 Then
                    TrayIcon.BalloonTipText = TrayIcon.BalloonTipText & course1Name & " (ID -> " & course1 & ") Error adding --> " & addError1 & vbNewLine
                End If
                If addError2.Length > 0 Then
                    TrayIcon.BalloonTipText = TrayIcon.BalloonTipText & course2Name & " (ID -> " & course2 & ") Error adding --> " & addError2 & vbNewLine
                End If
                If addError3.Length > 0 Then
                    TrayIcon.BalloonTipText = TrayIcon.BalloonTipText & course3Name & " (ID -> " & course3 & ") Error adding --> " & addError3 & vbNewLine
                End If
                If addError4.Length > 0 Then
                    TrayIcon.BalloonTipText = TrayIcon.BalloonTipText & course4Name & " (ID -> " & course4 & ") Error adding --> " & addError4 & vbNewLine
                End If

                If TrayIcon.BalloonTipText.Length > 0 Then
                    TrayIcon.ShowBalloonTip(60000)
                    'Console.WriteLine("error 3->" & addError3 & " name3-> " & course3Name & " id3-> " & course3)
                    Me.Focus()
                Else
                    TrayIcon.BalloonTipTitle = ""
                    TrayIcon.BalloonTipText = ""
                    'Me.Focus()
                End If

            End If

            If My.Computer.FileSystem.DirectoryExists(userDocumentsDir & "\psuSeatCheck") Then

                Try
                    My.Computer.FileSystem.WriteAllText(userDocumentsDir & "\psuSeatCheck\lastUpdate.txt", System.DateTime.Now.ToLongDateString & " --- " & System.DateTime.Now.ToLongTimeString, false)
                Catch ex As Exception

                End Try

            End If

            Me.Text = "PSU Seat Check v" & VERSION & " LAST UPDATED -> " & System.DateTime.Now.ToLongTimeString

            If updateHasShownToday = False and updateBoxIsShowing = false
                checkVersion()
            End If

        End If

    End Sub

    Private Sub autoAddPageButton_Click(sender As Object, e As EventArgs) Handles autoAddPageButton.Click
        Me.Hide()
        autoAddConfig.Show()
        autoAddConfig.WindowState = FormWindowState.Normal
        autoAddConfig.Activate()
        autoAddConfig.BringToFront()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Dim response As MsgBoxResult = MsgBox("If you close the app it will not be able to check for seat openings and/or register classes, are you sure you want to terminate the app?", MsgBoxStyle.YesNo, "Warning!")
        If response = MsgBoxResult.Yes Then
            TrayIcon.Visible = False
            EnableSound()
            Environment.Exit(0)
        End If
    End Sub

    Private Sub RestoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestoreToolStripMenuItem.Click

        For Each Form As System.Windows.Forms.Form In Application.OpenForms()
            Form.Hide()
        Next

        Me.Show()
        Me.WindowState = FormWindowState.Normal
        Me.Activate()
        Me.BringToFront()

    End Sub

    Private Sub aboutAppButton_Click(sender As Object, e As EventArgs) Handles aboutAppButton.Click
        Dim response As MsgBoxResult = MsgBox("If you close the app it will not be able to check for seat openings and/or register classes, are you sure you want to terminate the app?", MsgBoxStyle.YesNo, "Warning!")
        If response = MsgBoxResult.Yes Then
            TrayIcon.Visible = False
            EnableSound()
            Application.Exit()
            Environment.Exit(0)
        End If
    End Sub

    Private Sub minimizeTrayButton_Click(sender As Object, e As EventArgs) Handles minimizeTrayButton.Click
        Me.WindowState = FormWindowState.Minimized
        Me.Visible = False
    End Sub

    Private Sub reportBugsButton_Click(sender As Object, e As EventArgs) Handles reportBugsButton.Click
        Dim bugMessage As String = InputBox("Describe whatever issue(s) you are having, if you want a response include your email", "Submit Bug Report")

        If bugMessage.Length > 0 Then
            Dim webClient As New System.Net.WebClient
            Dim serverResponse As String = webClient.DownloadString("http://mensajay.com/bugReports.php?message=" & bugMessage)
            If serverResponse = "success" Then
                MsgBox("Your message was successfully submitted", MsgBoxStyle.Information, "Success!")
            Else
                MsgBox("There was an error with your request, check your internet connection and try again", MsgBoxStyle.Critical, "Error")
            End If
        End If
    End Sub

    Private Sub trayBalloon_Click(sender As Object, e As EventArgs) Handles TrayIcon.BalloonTipClicked

        For Each Form As System.Windows.Forms.Form In Application.OpenForms()
            Form.Hide()
        Next

        Me.Show()
        Me.WindowState = FormWindowState.Normal
        Me.Activate()
        Me.BringToFront()
    End Sub

    Private Sub semesterBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles semesterBox.SelectedIndexChanged
        If semesterBox.SelectedItem <> SEMESTER Then
            My.Computer.FileSystem.WriteAllText(userDocumentsDir & "\psuSeatCheck\currentSemester.txt", semesterBox.SelectedItem, False)
            restartFlag = True
            MsgBox("Changing semesters requires the app to restart, press 'ok' to restart the app", MsgBoxStyle.Critical, "Warning!")
            Application.Restart()
            'Me.main_Load()
            'Environment.Exit(0)
            'Process.Start(Application.ExecutablePath)
            'MsgBox(Application.ExecutablePath)
        End If
    End Sub

    Private Sub main_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        'Me.Focus()
        'courseEntry.Focus()
    End Sub
End Class