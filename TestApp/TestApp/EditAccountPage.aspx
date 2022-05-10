<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditAccountPage.aspx.cs" Inherits="TestApp.EditAccountPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta charset="utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <meta charset="utf-8" />
    <title>Edit Account</title>
</head>
<body>
    <form id="form1" runat="server">
     <h1 style="text-align: center;">Edit Account Information</h1>
    <br><br>


    <div class="container">

        <asp:Label ID="Label1" runat="server" Text="&emsp;Only fill out fields that need to be updated."></asp:Label>

        <br />
        <br />

        <div class="col-11">
            <div class="input-group mb-3">
                <span class="input-group-text col-2" id="basic-addon1">First Name</span>
                <input type="text" class="form-control" placeholder="First Name" aria-label="Username" aria-describedby="basic-addon1" id = "fName" runat ="server">
            </div>
        </div>
        <div class="col-11">
            <div class="input-group mb-3">
                <span class="input-group-text col-2" id="basic-addon1">Last Name</span>
                <input type="text" class="form-control" placeholder="Last Name" aria-label="Username" aria-describedby="basic-addon1" id ="lName" runat ="server">
            </div>
        </div>
        <div class="col-11">
            <div class="input-group mb-3">
                <span class="input-group-text col-2" id="basic-addon1">New Password</span>
                <input type="password" class="form-control" placeholder="New Password" aria-label="Username" aria-describedby="basic-addon1" id ="password" runat ="server">
            </div>
        </div>
        <div class="col-11">
            <div class="input-group mb-3">
                <span class="input-group-text col-2" id="basic-addon1">Current Password</span>
                <input type="password" class="form-control" placeholder="Current Password" aria-label="Username" aria-describedby="basic-addon1" id ="curPassword" runat ="server">
            </div>
        </div>
        <br />
        <asp:Button runat="server" onclick="updateAccountInformation" id ="accountUpdateBtn" class="btn btn-primary" Text="Update Information"/>

        <asp:Button runat="server" onclick="homePageClick" id ="homePageBtn" class="btn btn-primary" Text="Home Page"/>

        <br /><br />
        <%--Label to notify of information update success--%>
        <asp:Label ID="StatusMessage" runat="server" Text="" Enabled="false"></asp:Label>
    </div>


    </form>
</body>
</html>
