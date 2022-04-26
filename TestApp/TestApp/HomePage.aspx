<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="TestApp.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
            <meta charset="utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <meta charset="utf-8" />
    <title>Home Page</title>
</head>
<body>
    <form id="form1" style ="text-align:center;" runat="server">
        <div>
            <h1 style="text-align: center;">Welcome to the Home Page!</h1>
            <br><br>

            <asp:Button runat="server" onclick="editAccountClick" id ="editAccountBtn" class="btn btn-primary" Text="Edit Account"/>
            <asp:Button runat="server" onclick="servicesClick" id ="servicesBtn" class="btn btn-primary" Text="Services"/>
            <asp:Button runat="server" onclick="signOutClick" id ="signOutBtn" class="btn btn-primary" Text="Sign Out"/>

        </div>
    </form>
</body>
</html>
