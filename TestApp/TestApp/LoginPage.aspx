<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="TestApp.LoginPage" %>

<!DOCTYPE html>
<form runat ="server" style ="text-align:center">
<html>
<head>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <meta charset="utf-8" />
    <title>Login</title>
</head>
<body>
    <h1 class="display-5" style="text-align: center;">Welcome to the Salon Online Booking System</h1>

    <br><br>

    <h2 style="text-align:center">Login</h2>

    <br>
    <div class="container">
    <form style="text-align: center;">
        <div class="row mb-3 justify-content-center">
            <label for="inputEmail3" class="col-sm-1 col-form-label" style="text-align:left">Email</label>
            <div class="col-sm-3">
                <input type="email" class="form-control start-0" id="inputEmail" runat ="server">
            </div>
        </div>
        <div class="row mb-3 justify-content-center">
            <label for="inputPassword3" class="col-sm-1 col-form-label" style="text-align: left;">Password</label>
            <div class="col-sm-3">
                <input type="password" class="form-control" id="inputPassword" runat ="server">
            </div>
        </div>
        <br>
        <asp:Button runat="server" onclick="loginClick" id ="signInBtn" class="btn btn-primary" Text="Sign In"/>
        <!-- Button trigger modal -->
        <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#accountModal">Sign Up</button>
        <asp:Label ID="LoginSuccess" runat="server" Text="" Enabled="false"></asp:Label>


    </form>
    </div>

    <!-- Modal -->
    <div class="modal fade" id="accountModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Sign Up</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="mb-3">
                        <div class="input-group mb-3">
                            <span class="input-group-text col-3" id="basic-addon1">First Name</span>
                            <input type="text" class="form-control" placeholder="First Name" aria-label="Username" aria-describedby="basic-addon1">
                        </div>
                        <div class="input-group mb-3">
                            <span class="input-group-text col-3" id="basic-addon1">Last Name</span>
                            <input type="text" class="form-control" placeholder="Last Name" aria-label="Username" aria-describedby="basic-addon1">
                        </div>
                        <div class="input-group mb-3">
                            <span class="input-group-text col-3" id="basic-addon1">Email</span>
                            <input type="text" class="form-control" placeholder="Email" aria-label="Username" aria-describedby="basic-addon1">
                        </div>
                        <div class="input-group mb-3">
                            <span class="input-group-text col-3" id="basic-addon1">Password</span>
                            <input type="text" class="form-control" placeholder="Password" aria-label="Username" aria-describedby="basic-addon1">
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary">Create Account</button>
                    </div>
                </div>
            </div>
         </div>
    </div>


</body>
</html>
</form>