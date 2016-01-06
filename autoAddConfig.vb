Public Class autoAddConfig

    Public username, password As String
    Public autoAddEnabled As Boolean = False
    Private hasShownPolicy As Boolean = False

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

        If autoAddEnabled = False Then

            If WebBrowser1.Document.Url.ToString <> "https://webaccess.psu.edu/" And WebBrowser1.Document.Url.ToString <> "https://webaccess.psu.edu/services/" And My.Computer.Network.IsAvailable Then
                WebBrowser1.Navigate(New Uri("https://webaccess.psu.edu/"))
            ElseIf Not My.Computer.Network.IsAvailable Then
                MsgBox("The app was unable to connect to the internet, please check your connection and then restart the app", MsgBoxStyle.Critical, "Network Error!")
            End If

            If WebBrowser1.Document.Url.ToString = "https://webaccess.psu.edu/services/" Then
                WebBrowser1.Hide()
                usernameLabel.Text = username

                Dim userDocDir = My.Computer.FileSystem.SpecialDirectories.MyDocuments.ToString

                If Not My.Computer.FileSystem.DirectoryExists(userDocDir & "\psuSeatCheck") Then
                    My.Computer.FileSystem.CreateDirectory(userDocDir & "\psuSeatCheck")
                End If

                My.Computer.FileSystem.WriteAllText(userDocDir & "\psuSeatCheck\myUsername.txt", username, False)
                My.Computer.FileSystem.WriteAllText(userDocDir & "\psuSeatCheck\myPassword.txt", password, False)

                autoAddEnabled = True
                main.autoAdd = true

                MsgBox("Auto Add successfully authenticated, you may disable this function and or delete your credentials from this program and the local machine at any time by revisiting this page (or manually deleting the text files from the 'My Documents' directory and restarting the program)")

            End If
        End If

        If WebBrowser1.Url.ToString = "https://webaccess.psu.edu/cgi-bin/logout" Then
            For Each inputElement As System.Windows.Forms.HtmlElement In WebBrowser1.Document.GetElementsByTagName("input")
                If inputElement.GetAttribute("value") = "Logout" Then
                    inputElement.InvokeMember("click")
                End If
            Next

            autoAddEnabled = False

            main.addError1 = ""
            main.addError2 = ""
            main.addError3 = ""
            main.addError4 = ""
            main.courseAdded1 = False
            main.courseAdded2 = False
            main.courseAdded3 = False
            main.courseAdded4 = False

            WebBrowser1.Show()

        End If
    End Sub

    Private Sub WebBrowser1_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles WebBrowser1.Navigating
        Try
            If WebBrowser1.Document.Url.ToString = "https://webaccess.psu.edu/" And WebBrowser1.DocumentText.IndexOf("Two-Factor") = -1 Then
                Console.WriteLine("Username: " & WebBrowser1.Document.GetElementById("login").GetAttribute("value").ToString)
                Console.WriteLine("Password: " & WebBrowser1.Document.GetElementById("password").GetAttribute("value").ToString)
                username = WebBrowser1.Document.GetElementById("login").GetAttribute("value").ToString
                password = WebBrowser1.Document.GetElementById("password").GetAttribute("value").ToString
            End If
        Catch ex As System.NullReferenceException

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Disable course auto add button
        Dim response As MsgBoxResult = MsgBox("Pressing yes will disable the auto-add/auto register function of this app as well as delete your PSU username and password from your documents folder, are you sure you wish to do this?", MsgBoxStyle.YesNo, "Are you sure?")
        If response = MsgBoxResult.Yes Then
            Dim userDocumentDir As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            If My.Computer.FileSystem.FileExists(userDocumentDir & "\psuSeatCheck\myUsername.txt") Then
                My.Computer.FileSystem.DeleteFile(userDocumentDir & "\psuSeatCheck\myUsername.txt")
            End If
            If My.Computer.FileSystem.FileExists(userDocumentDir & "\psuSeatCheck\myPassword.txt") Then
                My.Computer.FileSystem.DeleteFile(userDocumentDir & "\psuSeatCheck\myPassword.txt")
            End If
            usernameLabel.Text = ""
            username = ""
            password = ""
            WebBrowser1.Navigate(New Uri("https://webaccess.psu.edu/cgi-bin/logout"))
            For Each inputElement As System.Windows.Forms.HtmlElement In WebBrowser1.Document.GetElementsByTagName("input")
                If inputElement.GetAttribute("value") = "Logout" Then
                    inputElement.InvokeMember("click")
                End If
            Next

            'WebBrowser1.Show()
            'autoAddEnabled = False

            main.autoAdd = false

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'View privacy policy
        MsgBox("I NEVER SEE YOUR CREDENTIALS!!!! PLAIN AND SIMPLE!!!! There is only ONE place which this program sends your data and that is to Penn State's authentication server (Webaccess.psu.edu). The only place they are stored is:" & vbNewLine & vbNewLine &
        "1) The programs runtime memory (as long as the program is running incase a seat becomes avalible and the program needs to reauthenticate)" & vbNewLine &
        "2) In your 'My Documents' directory with the Course names & ID's (So you don't have to keep typing it in)", MsgBoxStyle.Information, "PSU Seat Check - Privacy/Data Usage")

        MsgBox("***Also note that the Auto-Add/Auto Register feature cannot drop a course once it is added, this program ONLY can ADD courses. If you need to drop a course you must do so manually through eLion." & vbNewLine & vbNewLine & "In addition to that this program will not (At least not now I may work this into future versions) add a course which has controls/prerequisites or any requirement which is not satisfied. If that is the case it will simply say 'Error Adding Course' otherwise any other instance should be fine", MsgBoxStyle.Information, "Use of the Auto-Add feature")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        main.Show()
        main.WindowState = FormWindowState.Normal
        main.Activate()
        main.BringToFront()
    End Sub

    Private Sub autoAddConfig_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If hasShownPolicy = False And Me.Visible Then
            MsgBox("I NEVER SEE YOUR CREDENTIALS!!!! PLAIN AND SIMPLE!!!! There is only ONE place which this program sends your data and that is to Penn State's authentication server (Webaccess.psu.edu). The only place they are stored is:" & vbNewLine & vbNewLine &
            "1) The programs runtime memory (as long as the program is running incase a seat becomes avalible and the program needs to reauthenticate)" & vbNewLine &
            "2) In your 'My Documents' directory with the Course names & ID's (So you don't have to keep typing it in)", MsgBoxStyle.Information, "PSU Seat Check - Privacy/Data Usage")

            MsgBox("***Also note that the Auto-Add/Auto Register feature cannot drop a course once it is added, this program ONLY can ADD courses. If you need to drop a course you must do so manually through eLion." & vbNewLine & vbNewLine & "In addition to that this program will not (At least not now I may work this into future versions) add a course which has controls/prerequisites or any requirement which is not satisfied. If that is the case it will simply say 'Error Adding Course' otherwise any other instance should be fine", MsgBoxStyle.Information, "Use of the Auto-Add feature")

            hasShownPolicy = True
        End If
    End Sub

End Class