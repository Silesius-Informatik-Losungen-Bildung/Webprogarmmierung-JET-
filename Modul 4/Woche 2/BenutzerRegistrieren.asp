<%@  language="VBScript" %>
<!DOCTYPE html>
<html>
<head>
    <title>Benutzer-Registrierung</title>
</head>
<body>
    <h1>Benutzer registrieren</h1>
    <form method="POST" action="BenutzerRegistrieren.asp">
        <div>Vorname</div>
        <input type="text" name="Vorname" value="<%=Request.Form("Vorname") %>">
        <div>Nachname</div>
        <input type="text" name="Nachname" value="<%=Request.Form("Nachname") %>">
        <div>Alter</div>
        <input type="text" name="Alter" value="<%=Request.Form("Alter") %>"><br />
        <br />
        <input type="submit" value="Speichern"><br />
    </form>

    <font color="red">
        <% 
        If Request.ServerVariables("REQUEST_METHOD") = "POST" Then
            Dim istErfolg
            istErfolg = True
            
            If Trim(Request.Form("Vorname")) = "" Or Trim(Request.Form("Vorname")) = "Einhorn" Then
               Response.Write "Vorname darf nicht leer sein  oder ""Einhorn"" lauten!<br />"
               istErfolg = False
            End If
            If Trim(Request.Form("Nachname")) = "" Then
                Response.Write "Nachname darf nicht leer sein!<br />"
                istErfolg = False
            End If
            If Not IsNumeric(Trim(Request.Form("Alter"))) Then
                Response.Write "Alter muss eine Zahl sein!<br />"
                istErfolg = False
            End If

            If istErfolg = True Then
                Dim url
                url = "BenutzerRegistrierenErfolg.asp"
                url = url & "?Vorname=" & Request.Form("Vorname")
                url = url & "&Nachname=" & Request.Form("Nachname")
                url = url & "&Alter=" & Request.Form("Alter")
        
                Response.Redirect url
            End If

        End If
        %>
    </font>

</body>
</html>

