<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Survey.aspx.cs" Inherits="DataDrivenApp.QuestionWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="icon" type="image/png" href="~/images/icons/favicon.ico" />
    <link rel="stylesheet" type="text/css" href="~/vendor/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="~/fonts/font-awesome-4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="~/vendor/animate/animate.css" />
    <link rel="stylesheet" type="text/css" href="~/vendor/css-hamburgers/hamburgers.min.css" />
    <link rel="stylesheet" type="text/css" href="~/vendor/select2/select2.min.css" />
    <link rel="stylesheet" type="text/css" href="~/css1/util.css" />
    <link rel="stylesheet" type="text/css" href="~/css1/main.css" />
    <link href="../CSS/Styles.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <ul>
                <li><a class="active" href="#Survey">Survey</a></li>
                <li><a href="AdminLogin.aspx">Admin</a></li>
            </ul>
        </header>
        <div style="height:300px"></div>
        <div>
            <h1 class="surveyStartHeading" style="text-align:center;">Let Us Get Started!</h1>
            <h2 class="surveyStartSubHeading" style="text-align:center;">Please select whether you would like to continue anonymously or tell us who you are.</h2>
            <ul style="display: flex; justify-content: center; background-color:white">
                <li ><asp:Button ID="btnAnon" runat="server" Text="Anonymous" style="padding:10px; margin-right:5px; background-color:yellow; border:1px solid; border-radius:10px 10px;" OnClick="btnAnon_Click"/></li>
                <li ><asp:Button ID="btnRegister" runat="server" Text="Register.." style="padding:10px; margin-left:5px; background-color:darkslategrey; border:1px solid; border-radius:10px 10px;" OnClick="btnRegister_Click"/></li>
            </ul>
        </div>
    </form>
    <!--===============================================================================================-->
    <script src="vendor/jquery/jquery-3.2.1.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/bootstrap/js/popper.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/select2/select2.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/tilt/tilt.jquery.min.js"></script>
    <script>
        $('.js-tilt').tilt({
            scale: 1.1
        })
    </script>
    <!--===============================================================================================-->
    <script src="js/main.js"></script>
</body>
</html>
