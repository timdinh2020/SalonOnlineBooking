<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="TestApp.LoginPage" %>

<!DOCTYPE html>
<form runat ="server" style ="text-align:center">
<html>
<head>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <script
  src="https://code.jquery.com/jquery-3.6.0.js"
  integrity="sha256-H+K7U5CnXl1h5ywQfKtSj8PCmoN9aaq30gDh27Xc0jk="
  crossorigin="anonymous"></script>

    <meta charset="utf-8" />
    <title>Login</title>



    <script type="text/javascript">
        $(document).on('click', '#createAccountBtn', function ()
        {


            //Make sure all fields are filled out
            if (document.getElementById("fName").value == null || document.getElementById("fName").value == "") {
                var script = "Please enter a value for first name.";
                alert(script);
                return;
            }
            if (document.getElementById("lName").value == null || document.getElementById("lName").value == "") {
                var script = "Please enter a value for last name.";
                alert(script);
                return;
            }
            if (document.getElementById("email").value == null || document.getElementById("email").value == "") {
                var script = "Please enter a value for email.";
                alert(script);
                return;
            }
            if (document.getElementById("password").value == null || document.getElementById("password").value == "") {
                var script = "Please enter a value for password.";
                alert(script);
                return;
            }


            // Get create account information
            var fName = document.getElementById("fName").value;
            var lName = document.getElementById("lName").value;
            var email = document.getElementById("email").value;
            var password = document.getElementById("password").value;

            //Set hidden field values that contain account information
            document.getElementById("fNameHidden").value = fName;
            document.getElementById("lNameHidden").value = lName;
            document.getElementById("emailHidden").value = email;
            document.getElementById("passwordHidden").value = password;

            console.log(fName);

            //Call button click
            document.getElementById('<%= hiddenButton.ClientID %>').click();

        });
    </script>


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
        <asp:Button runat="server" onclick="loginClick" id ="signInBtn" class="btn btn-primary" Text="Sign In"/>

        <!-- Button trigger modal -->
        <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#accountModal">Sign Up</button>
        
        <%--Hidden button to call create account--%>
        <div style = "display:none;">
            <asp:Button runat="server" onclick="createAccountClick" id ="hiddenButton" class="btn btn-primary" Text=""/>
        </div>

        <br /><br />

        <%--Label to notify of account creation success or failed login--%>
        <asp:Label ID="StatusMessage" runat="server" Text="" Enabled="false"></asp:Label>


        <%--Hidden fields to contain create account information--%>
        <asp:HiddenField ID="fNameHidden" value="" runat="server"/>
        <asp:HiddenField ID="lNameHidden" value="" runat="server" />
        <asp:HiddenField ID="emailHidden" value="" runat="server" />
        <asp:HiddenField ID="passwordHidden" value="" runat="server" />


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
                            <input type="text" runat="server" class="form-control" placeholder="First Name" aria-label="Username" aria-describedby="basic-addon1" id ="fName">
                        </div>
                        <div class="input-group mb-3">
                            <span class="input-group-text col-3" id="basic-addon2">Last Name</span>
                            <input type="text" class="form-control" placeholder="Last Name" aria-label="Username" aria-describedby="basic-addon1" value ="" id ="lName" runat="server">
                        </div>
                        <div class="input-group mb-3">
                            <span class="input-group-text col-3" id="basic-addon3">Email</span>
                            <input type="text" class="form-control" placeholder="Email" aria-label="Username" aria-describedby="basic-addon1" value ="" id ="email" runat="server">
                        </div>
                        <div class="input-group mb-3">
                            <span class="input-group-text col-3" id="basic-addon4">Password</span>
                            <input type="password" class="form-control" placeholder="Password" aria-label="Username" aria-describedby="basic-addon1" value ="" id ="password" runat="server">
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                        <%--<asp:Button runat="server" id ="createAccountBtn" class="btn btn-primary" Text="CreateAccount"/>--%>
                        <a href="#" class="btn btn-primary" onclick ="createAccountBtn" id="createAccountBtn">Create Account</a>
                        <%--<button type="button" class="btn btn-primary" onClick ="CreateAccountClick()">Create Account</button>--%>
                        <asp:Label ID="errorLabel" runat="server" Text="" Enabled="false"></asp:Label>
                    </div>
                </div>
            </div>
         </div>
    </div>

</body>
</html>
</form>