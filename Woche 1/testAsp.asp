<%@ Language="VBScript" %>
<%
    ' Serverseitige Logik
    Dim name
    name = "Besucher"
    If Request.QueryString("name") <> "" Then
        name = Server.HTMLEncode(Request.QueryString("name"))
    End If

%>
<!DOCTYPE html>
<html>
<head>
    <title>Einfache ASP-Seite</title>
</head>
<body>
    <h1>Willkommen, <%= name %>!</h1>
    <p>Aktuelle Uhrzeit: <%= Now %></p>
    <form method="post" action="">
        <label>Gib deinen Namen ein:</label>
        <input type="text" name="name" value="<%=Request.Form("name") %>">
        <input type="submit" value="Senden">
    </form>

</body>
</html>
