<%@  language="VBScript" %>
<!DOCTYPE html>
<html>
<head>
    <title>Benutzer registrieren</title>
</head>
<body>
    <h1>Benutzer <%= Request.QueryString("Vorname")%> <%=Request.QueryString("Nachname") %> wurde registriert!</h1>
    <div>Vorname: <%= Request.QueryString("Vorname") %></div>
    <div>Nachname: <%= Request.QueryString("Nachname") %></div>
    <div>Alter: <%= Request.QueryString("Alter") %></div>
    <br />

    <a href="BenutzerRegistrieren.asp">Noch einen Benutzer registrieren.</a>
</body>
</html>
