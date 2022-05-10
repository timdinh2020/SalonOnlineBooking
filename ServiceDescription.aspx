<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceDescription.aspx.cs" Inherits="TestApp.ServiceDescription" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta charset="utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <meta charset="utf-8" />
    <title>Service Description</title>
</head>
<body>

    <h1 style="text-align: center;">Service Description</h1>
    <br/><br/>

    <form id="form1" runat="server" style ="text-align:center;">
        <div class ="container">
            <asp:Label ID="serviceLabel" runat="server" Text=""></asp:Label>

            <br />

            <asp:Label ID="descriptionLabel" runat="server" Text=""></asp:Label>


            <br /><br />

            <asp:Button runat="server" onclick="serviceList" id ="serviceListBtn" class="btn btn-primary" Text="Service List"/>
        </div>
    </form>
</body>
</html>
