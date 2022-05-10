<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyService.aspx.cs" Inherits="TestApp.ModifyService" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta charset="utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <meta charset="utf-8" />
    <title>Modify Service</title>
</head>
<body>
    <form id="form1" runat="server">
     <h1 style="text-align: center;">Modify Service</h1>
    <br/><br/>


    <div class="container">
        <div class="col-11">
            <div class="input-group mb-3">
                <span class="input-group-text col-1" id="basic-addon1">Title</span>
                <input type="text" class="form-control" placeholder="Title" aria-label="Username" aria-describedby="basic-addon1" id = "titleTB" runat ="server">
            </div>
        </div>
        <div class="col-11">
            <div class="input-group mb-3">
                <span class="input-group-text col-1" id="basic-addon2">Description</span>
                <input type="text" class="form-control" placeholder="Description" aria-label="Username" aria-describedby="basic-addon1" id ="descrTB" runat ="server">
            </div>
        </div>
        <div class="col-11">
            <div class="input-group mb-3">
                <span class="input-group-text col-1" id="basic-addon3">Price</span>
                <input type="text" class="form-control" placeholder="Price" aria-label="Username" aria-describedby="basic-addon1" id ="priceTB" runat ="server">
            </div>
        </div>
        <br />
        <asp:Button runat="server" onclick="modifyService" id ="modifyServiceBtn" class="btn btn-primary" Text="Modify Service"/>

        <asp:Button runat="server" onclick="homePageClick" id ="homePageBtn" class="btn btn-primary" Text="Home Page"/>

        <br /><br />
        <%--Label to notify of modify service success--%>
        <asp:Label ID="StatusMessage" runat="server" Text="" Enabled="false"></asp:Label>
    </div>


    </form>
</body>
</html>
