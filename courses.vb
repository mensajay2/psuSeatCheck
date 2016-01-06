Public Class courseEntry

    Private duplicateError As Boolean

    Private Sub courseEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Activated
        Me.Show()
        mainTitle.Focus()
    End Sub

    Private Sub course1_GotFocus(sender As Object, e As EventArgs) Handles course1.Click
        If course1.Text = "133337" Then
            course1.Text = ""
        End If
    End Sub

    Private Sub textInputHandler(sender As Object, e As KeyPressEventArgs) Handles course2.KeyPress, course3.KeyPress, course4.KeyPress, course1.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub course1Name_GotFocus(sender As Object, e As EventArgs) Handles course1Name.Click
        If course1Name.Text = "(Example: Math 140 9am)" Then
            course1Name.Text = ""
        End If
    End Sub

    Private Sub submitCourses_Click(sender As Object, e As EventArgs) Handles submitCourses.Click
        'Check if entered course ID's are valid

        duplicateError = False

        Dim errorString As String
        errorString = ""
        Dim webClient As New System.Net.WebClient

        Me.Text = "PSU Seat Check .......SAVING COURSES......."
        Me.Cursor = Cursors.WaitCursor

        main.addError1 = ""
        main.addError2 = ""
        main.addError3 = ""
        main.addError4 = ""
        main.courseAdded1 = False
        main.courseAdded2 = False
        main.courseAdded3 = False
        main.courseAdded4 = False

        Try

            Dim courseList As New Dictionary(Of Integer, String)

            If course1.Text.Length > 0 Then

                Dim result1 As String
                result1 = webClient.DownloadString("http://mensajay.com/seatsLeft.php?semester=" & main.SEMESTER & "&courseID=" & course1.Text)

                For i As Integer = 1 To 10
                    If Not IsNumeric(result1) Then
                        result1 = webClient.DownloadString("http://mensajay.com/seatsLeft.php?semester=" & main.SEMESTER & "&courseID=" & course1.Text)
                    End If
                Next


                If Not IsNumeric(result1) Then
                    errorString = errorString & " 1,"
                    webClient.DownloadString("http://mensajay.com/classEntryErrors.php?entryErrorName=" & course1Name.text & "&entryErrorID=" & course1.Text)
                Else
                    If course1.Text <> main.course1 Then
                        main.addError1 = ""
                        main.courseAdded1 = False
                    End If
                    courseList.Add(course1.Text, course1Name.Text)
                End If

            End If

            If course2.Text.Length > 0 Then

                Dim result2 As String
                result2 = webClient.DownloadString("http://mensajay.com/seatsLeft.php?semester=" & main.SEMESTER & "&courseID=" & course2.Text)

                For i As Integer = 1 To 10
                    If Not IsNumeric(result2) Then
                        result2 = webClient.DownloadString("http://mensajay.com/seatsLeft.php?semester=" & main.SEMESTER & "&courseID=" & course2.Text)
                    End If
                Next

                If Not IsNumeric(result2) Then
                    errorString = errorString & " 2,"
                    webClient.DownloadString("http://mensajay.com/classEntryErrors.php?entryErrorName=" & course2Name.text & "&entryErrorID=" & course2.Text)
                Else
                    If course2.Text <> main.course2 Then
                        main.addError2 = ""
                        main.courseAdded2 = False
                    End If
                    courseList.Add(course2.Text, course2Name.Text)
                End If

            End If

            If course3.Text.Length > 0 Then

                Dim result3 As String
                result3 = webClient.DownloadString("http://mensajay.com/seatsLeft.php?semester=" & main.SEMESTER & "&courseID=" & course3.Text)

                For i As Integer = 1 To 10
                    If Not IsNumeric(result3) Then
                        result3 = webClient.DownloadString("http://mensajay.com/seatsLeft.php?semester=" & main.SEMESTER & "&courseID=" & course3.Text)
                    End If
                Next

                If Not IsNumeric(result3) Then
                    errorString = errorString & " 3,"
                    webClient.DownloadString("http://mensajay.com/classEntryErrors.php?entryErrorName=" & course3Name.text & "&entryErrorID=" & course3.Text)
                Else
                    If course3.Text <> main.course3 Then
                        main.addError3 = ""
                        main.courseAdded3 = False
                    End If
                    courseList.Add(course3.Text, course3Name.Text)
                End If

            End If

            If course4.Text.Length > 0 Then

                Dim result4 As String
                result4 = webClient.DownloadString("http://mensajay.com/seatsLeft.php?semester=" & main.SEMESTER & "&courseID=" & course4.Text)

                For i As Integer = 1 To 10
                    If Not IsNumeric(result4) Then
                        result4 = webClient.DownloadString("http://mensajay.com/seatsLeft.php?semester=" & main.SEMESTER & "&courseID=" & course4.Text)
                    End If
                Next

                If Not IsNumeric(result4) Then
                    errorString = errorString & " 4,"
                    webClient.DownloadString("http://mensajay.com/classEntryErrors.php?entryErrorName=" & course4Name.text & "&entryErrorID=" & course4.Text)
                Else
                    If course4.Text <> main.course4 Then
                        main.addError4 = ""
                        main.courseAdded4 = False
                    End If
                    courseList.Add(course4.Text, course4Name.Text)
                End If

            End If

        Catch ex As System.Net.WebException
            errorString = "Error connecting to the psu course server, please check your internet connection and try again!"
        Catch ex2 As System.ArgumentException
            duplicateError = True
        End Try

        Me.Text = "PSU Seat Check"
        Me.Cursor = Cursors.Default

        If errorString.Length > 0 Then
            errorString = "Course " & errorString & " ID(s) are not valid, please try again. (If you think the ID(s) are valid courses and you are seeing this error, submit a bug report in the support tab, I do miss classes in our scan occasionally)"
            MsgBox(errorString, MsgBoxStyle.Critical, "Error!")
        ElseIf duplicateError = True Then
            MsgBox("Duplicate Course ID's entered, each course ID must be unique", MsgBoxStyle.Critical, "Error!!! Duplicate ID's")
        Else
            'continue with name check, if names present (name check cleared) then save all date to txt files
            If course1Name.Text.Length = 0 And course1.Text.Length > 0 Then
                MsgBox("Please enter a name for Course 1", MsgBoxStyle.Exclamation, "Error! Information Missing!")
            ElseIf course2Name.Text.Length = 0 And course2.Text.Length > 0 Then
                MsgBox("Please enter a name for Course 2", MsgBoxStyle.Exclamation, "Error! Information Missing!")
            ElseIf course3Name.Text.Length = 0 And course3.Text.Length > 0 Then
                MsgBox("Please enter a name for Course 3", MsgBoxStyle.Exclamation, "Error! Information Missing!")
            ElseIf course4Name.Text.Length = 0 And course4.Text.Length > 0 Then
                MsgBox("Please enter a name for Course 4", MsgBoxStyle.Exclamation, "Error! Information Missing!")
            Else
                'Write to text files
                Dim userDocumentsDir As String
                userDocumentsDir = My.Computer.FileSystem.SpecialDirectories.MyDocuments

                If Not My.Computer.FileSystem.DirectoryExists(userDocumentsDir & "\psuSeatCheck") Then

                    My.Computer.FileSystem.CreateDirectory(userDocumentsDir & "\psuSeatCheck")

                End If

                My.Computer.FileSystem.WriteAllText(userDocumentsDir & "\psuSeatCheck\" & main.SEMESTER.Replace(" ", "_") & "_courseName1.txt", course1Name.Text, False)
                My.Computer.FileSystem.WriteAllText(userDocumentsDir & "\psuSeatCheck\" & main.SEMESTER.Replace(" ", "_") & "_course1.txt", course1.Text, False)
                main.course1Name = course1Name.Text
                main.course1 = course1.Text
                main.course1NameLabel.Text = course1Name.Text
                main.course1IDLabel.Text = course1.Text

                If main.course1.Length > 0 Then
                    main.course1NameLabel.Show()
                    main.course1IDLabel.Show()
                    main.course1Seats.Show()
                Else
                    main.course1NameLabel.Hide()
                    main.course1IDLabel.Hide()
                    main.course1Seats.Hide()
                End If

                My.Computer.FileSystem.WriteAllText(userDocumentsDir & "\psuSeatCheck\" & main.SEMESTER.Replace(" ", "_") & "_courseName2.txt", course2Name.Text, False)
                My.Computer.FileSystem.WriteAllText(userDocumentsDir & "\psuSeatCheck\" & main.SEMESTER.Replace(" ", "_") & "_course2.txt", course2.Text, False)
                main.course2Name = course2Name.Text
                main.course2 = course2.Text
                main.course2NameLabel.Text = course2Name.Text
                main.course2IDLabel.Text = course2.Text

                If main.course2.Length > 0 Then
                    main.course2NameLabel.Show()
                    main.course2IDLabel.Show()
                    main.course2Seats.Show()
                Else
                    main.course2NameLabel.Hide()
                    main.course2IDLabel.Hide()
                    main.course2Seats.Hide()
                End If

                My.Computer.FileSystem.WriteAllText(userDocumentsDir & "\psuSeatCheck\" & main.SEMESTER.Replace(" ", "_") & "_courseName3.txt", course3Name.Text, False)
                My.Computer.FileSystem.WriteAllText(userDocumentsDir & "\psuSeatCheck\" & main.SEMESTER.Replace(" ", "_") & "_course3.txt", course3.Text, False)
                main.course3Name = course3Name.Text
                main.course3 = course3.Text
                main.course3NameLabel.Text = course3Name.Text
                main.course3IDLabel.Text = course3.Text

                If main.course3.Length > 0 Then
                    main.course3NameLabel.Show()
                    main.course3IDLabel.Show()
                    main.course3Seats.Show()
                Else
                    main.course3NameLabel.Hide()
                    main.course3IDLabel.Hide()
                    main.course3Seats.Hide()
                End If

                My.Computer.FileSystem.WriteAllText(userDocumentsDir & "\psuSeatCheck\" & main.SEMESTER.Replace(" ", "_") & "_courseName4.txt", course4Name.Text, False)
                My.Computer.FileSystem.WriteAllText(userDocumentsDir & "\psuSeatCheck\" & main.SEMESTER.Replace(" ", "_") & "_course4.txt", course4.Text, False)
                main.course4Name = course4Name.Text
                main.course4 = course4.Text
                main.course4NameLabel.Text = course4Name.Text
                main.course4IDLabel.Text = course4.Text

                If main.course4.Length > 0 Then
                    main.course4NameLabel.Show()
                    main.course4IDLabel.Show()
                    main.course4Seats.Show()
                Else
                    main.course4NameLabel.Hide()
                    main.course4IDLabel.Hide()
                    main.course4Seats.Hide()
                End If

                If main.course1.Length > 0 Or main.course2.Length > 0 Or main.course3.Length > 0 Or main.course4.Length > 0 Then
                    If main.updateSeatsThread.IsBusy = False Then
                        main.appNewsLabel.Show()
                        main.updateSeatsThread.RunWorkerAsync()
                        main.seatCheckTimer.Start()
                    End If
                End If

                main.TrayIcon.BalloonTipText = ""
                MsgBox("Data saved successfully!", MsgBoxStyle.Information, "Success!")

                End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        main.Show()
        main.WindowState = FormWindowState.Normal
        main.Activate()
        main.BringToFront()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        autoAddConfig.Show()
        autoAddConfig.WindowState = FormWindowState.Normal
        autoAddConfig.Activate()
        autoAddConfig.BringToFront()
    End Sub

    Private Sub clear1_Click(sender As Object, e As EventArgs) Handles clear1.Click
        course1Name.Text = ""
        course1.Text = ""
        main.addError1 = ""
        main.courseAdded1 = False
    End Sub

    Private Sub cancel2_Click(sender As Object, e As EventArgs) Handles cancel2.Click
        course2Name.Text = ""
        course2.Text = ""
        main.addError2 = ""
        main.courseAdded2 = False
    End Sub

    Private Sub cancel3_Click(sender As Object, e As EventArgs) Handles cancel3.Click
        course3Name.Text = ""
        course3.Text = ""
        main.addError3 = ""
        main.courseAdded3 = False
    End Sub

    Private Sub cancel4_Click(sender As Object, e As EventArgs) Handles cancel4.Click
        course4Name.Text = ""
        course4.Text = ""
        main.addError4 = ""
        main.courseAdded4 = False
    End Sub

End Class
