<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="OlineQuizApp.Views.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../Assests/Lib/Bootstrap/css/bootstrap.min.css" />
    <style>
        *{
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;

        }
        body{
            background-image: url("../Assests/Images/1.jpg");
            background-size: cover;
        }
    </style>
</head>
<body>
        <div class="container-fluid">
        <div class="row" style="height:60px"></div>
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-4 bg-light rounded-3 mt-2 shadow-lg">
                <h4 class="text-danger text-center">Online Quiz Application</h4>
                <h4 class="text-success text-center">Register</h4>

     <form  runat="server">
  <div class="mb-3" >
    <label for="CNameTb" class="form-label">Candidate Name</label>
    <input type="text" class="form-control" id="CNameTb" runat="server"  required="required" aria-describedby="emailHelp" autocomplete="off"/>
  </div>
  <div class="mb-3">
  <label for="CEmailTb" class="form-label">Email address</label>
  <input type="email" class="form-control" id="CEmailTb" runat="server" required="required" aria-describedby="emailHelp" autocomplete="off"/>
  </div>
  <div class="mb-3">
      <label for="PasswordTb" class="form-label">Password</label>
    <input type="password" class="form-control" runat="server" id="PasswordTb" required="required"/>
  </div>
  <div class="mb-3">
    <label for="CollegeTb" class="form-label">College Name</label>
    <input type="text" class="form-control" id="CollegeTb" runat="server" required="required" autocomplete="off"/>
  </div>
  <div class="mb-3 form-check">
    <label class="form-check-label text-Center"><a href="Login.aspx" class="text-danger">Login</a></label>
  </div>
  <div class="d-grid mb-3">
  <label id="errormsg" class="text-danger" runat="server"></label>
      <asp:Button ID="RegisterBtn" runat="server" Text="Register" class="btn btn-success btn-block" OnClick="RegisterBtn_Click" />
   </div>
</form>
            </div>
            <div class= "col-md-4"></div>
        </div>
    </div>

</body>
</html>
