<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MakeAppointment.aspx.cs" Inherits="TestApp.MakeAppointment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta charset="utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <meta charset="utf-8" />
    <title>Make Appointment</title>
</head>
<body>
    <form id="form1" runat="server">
     <h1 style="text-align: center;">Make Appointment</h1>
    <br/><br/>


    <div class="container">
        <div class="col-11">
            <div class="input-group mb-3">
                <span class="input-group-text col-1" id="basic-addon1">Service</span>
                <input type="text" class="form-control" placeholder="Service" aria-label="Username" aria-describedby="basic-addon1" id = "serviceTB" runat ="server">
            </div>
        </div>
        <div class="col-11">
            <div class="input-group mb-3">
                <span class="input-group-text col-1" id="basic-addon2">Hairdresser</span>
                <input type="text" class="form-control" placeholder="Hairdresser" aria-label="Username" aria-describedby="basic-addon1" id ="hairdresserTB" runat ="server">
            </div>
        </div>
        <div class="col-11">
            <div class="input-group mb-3">
                <span class="input-group-text col-1" id="basic-addon3">Date</span>
                <input type="text" class="form-control" placeholder="Date" aria-label="Username" aria-describedby="basic-addon1" id ="dateTB" runat ="server">
            </div>
        </div>
        <div class="col-11">
            <div class="input-group mb-3">
                <span class="input-group-text col-1" id="basic-addon4">Time</span>
                <input type="text" class="form-control" placeholder="Time" aria-label="Username" aria-describedby="basic-addon1" id ="timeTB" runat ="server">
            </div>
        </div>
        <br />

        <asp:Button runat="server" onclick="makeAppointment" id ="appointmentBtn" class="btn btn-primary" Text="Make Appointment"/>

        <asp:Button runat="server" onclick="homePageClick" id ="homePageBtn" class="btn btn-primary" Text="Home Page"/>


        <br /><br />
        <%--Label to notify of appointment creation--%>
        <asp:Label ID="StatusMessage" runat="server" Text="" Enabled="false"></asp:Label>
    </div>


    </form>
</body>
</html>
