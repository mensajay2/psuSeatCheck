Public Class TestBrowserForm

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        'grab all input elements as collections
        Dim submitElement As System.Windows.Forms.HtmlElement
        Dim inputElements As System.Windows.Forms.HtmlElementCollection
        inputElements = WebBrowser1.Document.GetElementsByTagName("input")
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
            Dim labelStart As Integer = WebBrowser1.DocumentText.LastIndexOf(radioValue & """ />", StringComparison.OrdinalIgnoreCase)
            'Console.WriteLine(labelStart)
            Dim newSubstring As String = WebBrowser1.DocumentText.Substring(labelStart + 7)
            Dim tdEnd As Integer = newSubstring.IndexOf("</td>", StringComparison.OrdinalIgnoreCase)
            finalRadioArray.Add(newSubstring.Substring(0, tdEnd).Trim, radioButtons.Item(radioValue))
        Next

    End Sub

End Class