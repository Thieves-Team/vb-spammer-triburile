Imports System.IO

Public Class Form1

    

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

        Dim c As HtmlElementCollection = WebBrowser1.Document.GetElementsByTagName("a")
        For Each b As HtmlElement In c
            If b.GetAttribute("href").Contains("info_player") Then
                ListBox1.Items.Add(b.InnerHtml & ";")

                Dim FileNumber As Integer = FreeFile()
                FileOpen(FileNumber, Application.StartupPath & "/useri.txt", OpenMode.Output)
                For Each Item As Object In ListBox1.Items
                    PrintLine(FileNumber, Item.ToString)
                Next
                FileClose(FileNumber)

            End If
        Next

        For Each sel5 As HtmlElement In WebBrowser1.Document.All

            If sel5.Name = "to" Then
                Dim r As New Random
                Dim str As String = TextBox6.Text.Replace(vbNewLine, "")
                sel5.SetAttribute("value", str)
            End If

        Next

        For Each sel5 As HtmlElement In WebBrowser1.Document.All
            If sel5.Name = "subject" Then
                sel5.SetAttribute("value", TextBox3.Text)
            End If

        Next
        For Each sel5 As HtmlElement In WebBrowser1.Document.All
            If sel5.Name = "text" Then
                sel5.SetAttribute("value", TextBox4.Text)
            End If

        Next
        For Each sel5 As HtmlElement In WebBrowser1.Document.All
            If sel5.Name = "send" Then
                sel5.InvokeMember("click")

            End If
        Next
    End Sub
    Private Sub loginnew()



        Dim y As HtmlElementCollection = WebBrowser1.Document.GetElementsByTagName("input")

        For Each b As HtmlElement In y

            If b.Name = "user" Then
                Dim r As New Random

                '  Dim str As String = TextBox5.Lines(r.Next(0, TextBox5.Lines.Length - 1))
                b.SetAttribute("value", TextBox1.Text)

            End If

            If b.Name = "password" Then
                b.SetAttribute("value", TextBox2.Text)


            End If

        Next
        Dim z As HtmlElementCollection = WebBrowser1.Document.GetElementsByTagName("span")
        For Each c As HtmlElement In z
            If c.InnerHtml = "Login" Then
                c.InvokeMember("click")


            End If
        Next
        Timer1.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox5.Text = "" Then
            MsgBox("Introdu User/Parola/Lumea", vbInformation)
        Else
            loginnew()
            Timer2.Enabled = True
        End If
       

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim x As HtmlElementCollection = WebBrowser1.Document.GetElementsByTagName("span")
        For Each b As HtmlElement In x


            If b.InnerHtml = "Lumea " & TextBox5.Text Then
                b.InvokeMember("click")


            End If


            Timer1.Enabled = False

        Next

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        Dim x As HtmlElementCollection = WebBrowser1.Document.GetElementsByTagName("a")
        For Each b As HtmlElement In x


            If b.InnerText = "Trib" Then
                b.InvokeMember("click")

            End If

        Next
        For Each b As HtmlElement In x


            If b.InnerText = "Membri" Then
                b.InvokeMember("click")
                Timer2.Enabled = False
            End If

        Next


    End Sub
    Private Sub mesaj()

        Dim FileNumber As Integer = FreeFile()
        FileOpen(FileNumber, Application.StartupPath & "/useri.txt", OpenMode.Output)
        For Each Item As Object In ListBox1.Items
            PrintLine(FileNumber, Item.ToString)
        Next
        FileClose(FileNumber)

    
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim FileReader1 As StreamReader
        FileReader1 = New StreamReader(Application.StartupPath & "/useri.txt")
        TextBox6.Text = FileReader1.ReadToEnd()
        FileReader1.Close() '
       
      
        Dim x As HtmlElementCollection = WebBrowser1.Document.GetElementsByTagName("a")
        For Each b As HtmlElement In x
            If b.InnerHtml = "Mesaje" Then
                b.InvokeMember("click")

            End If

            'send
        Next
        For Each b As HtmlElement In x
            If b.InnerHtml = "Scrie un mesaj" Then
                b.InvokeMember("click")
            End If
        Next



    End Sub
End Class
