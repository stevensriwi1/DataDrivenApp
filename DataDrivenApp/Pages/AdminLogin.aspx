<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="DataDrivenApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="icon" type="image/png" href="../images/icons/favicon.ico" />
    <link rel="stylesheet" type="text/css" href="../vendor/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../fonts/font-awesome-4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="../vendor/animate/animate.css" />
    <link rel="stylesheet" type="text/css" href="../vendor/css-hamburgers/hamburgers.min.css" />
    <link rel="stylesheet" type="text/css" href="../vendor/select2/select2.min.css" />
    <link rel="stylesheet" type="text/css" href="../css1/util.css" />
    <link rel="stylesheet" type="text/css" href="../css1/main.css" />
    <link href="~/CSS/Styles.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
    <style type="text/css">
        .auto-style1 {
            height: 24px;
        }
    </style>
</head>
<body>

    <div class="limiter">
        <header>
            <ul>
                <li><a class="active" href="Survey.aspx">Survey</a></li>
                <li><a class="active" href="AdminLogin.aspx">Admin</a></li>
            </ul>
        </header>
        <div class="container-login100">
            <div class="wrap-login100">
                <div class="login100-pic js-tilt" >
                    <img src="../images/img01.png" alt="IMG" />
                </div>

                <form class="login100-form validate-form" id="form1" runat="server">
                    <span class="login100-form-title">Admin Login
                    </span>

                    <div class="wrap-input100 validate-input" data-validate="Valid email is required: ex@abc.xyz">
                        <!--<input class="input100" type="text" name="email" placeholder="Email"> -->
                        <asp:TextBox ID="usernameTxtbox" class="input100" runat="server" placeholder="Email"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="usernameValidator" runat="server" ErrorMessage="Username required" ControlToValidate="usernameTxtbox"></asp:RequiredFieldValidator>
                        <span class="focus-input100"></span>
                        <span class="symbol-input100">
                            <i class="fa fa-envelope" aria-hidden="true"></i>
                        </span>
                    </div>

                    <div class="wrap-input100 validate-input" data-validate="Password is required">
                        <!-- <input class="input100" type="password" name="pass" placeholder="Password"> -->
                        <asp:TextBox ID="passwordTxtbox" class="input100" placeholder="Password" runat="server" type="password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="passwordValidator" runat="server" ErrorMessage="Password required" ControlToValidate="passwordTxtbox"></asp:RequiredFieldValidator>
                        <span class="focus-input100"></span>
                        <span class="symbol-input100">
                            <i class="fa fa-lock" aria-hidden="true"></i>
                        </span>
                    </div>

                    <div class="container-login100-form-btn">
                        <asp:Button ID="Button1" class="login100-form-btn" runat="server" Text="Login" Style="float: right;" OnClick="submitBtn_Click" />
                    </div>
                    <div class="text-center p-t-12">
                        <asp:Label ID="message" class="txt2" runat="server"></asp:Label>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <!--===============================================================================================-->
    <script src="../vendor/jquery/jquery-3.2.1.min.js"></script>
    <!--===============================================================================================-->
    <script src="../vendor/bootstrap/js/popper.js"></script>
    <script src="../vendor/bootstrap/js/bootstrap.min.js"></script>
    <!--===============================================================================================-->
    <script src="../vendor/select2/select2.min.js"></script>
    <!--===============================================================================================-->
    <script src="../vendor/tilt/tilt.jquery.min.js"></script>
    <script>
        $('.js-tilt').tilt({
            scale: 1.1
        })
    </script>
    <!--===============================================================================================-->
    <script src="../js/main.js"></script>
</body>

</html>
