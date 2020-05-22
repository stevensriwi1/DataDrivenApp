<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="DataDrivenApp.Pages.WebForm1" %>

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
        form {
            margin:auto;
            align-self:center;
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
        

                <form class="login100-form validate-form" id="userRegisterForm" runat="server">
                    <span class="login100-form-title">User Registration
                    </span>
                    <div class="wrap-input100 validate-input" >
                        <!--<input class="input100" type="text" name="email" placeholder="Email"> -->
                        <asp:TextBox ID="firstnameTxtbox" class="input100" runat="server" placeholder="First Name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="firstnamedValidator" runat="server" ErrorMessage="First Name required" ControlToValidate="firstnameTxtbox"></asp:RequiredFieldValidator>
                        <span class="focus-input100"></span>
                        <span class="symbol-input100">
                        </span>
                    </div>

                    <div class="wrap-input100 validate-input" >
                        <!-- <input class="input100" type="password" name="pass" placeholder="Password"> -->
                        <asp:TextBox ID="lastnameTxtbox" class="input100" placeholder="Last Name" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="lastnameValidator" runat="server" ErrorMessage="Password required" ControlToValidate="lastnameTxtbox"></asp:RequiredFieldValidator>
                        <span class="focus-input100"></span>
                        <span class="symbol-input100">
                        </span>
                    </div>
                    

                    <div class="wrap-input100 validate-input">
                        <!-- <input class="input100" type="password" name="pass" placeholder="Password"> -->
                        <asp:TextBox ID="dobTextBox" class="input100" placeholder="DOB MM/DD/YYYY" runat="server"></asp:TextBox>
                        <asp:CompareValidator id="CompareValidator1" runat="server" Type="Date" Operator="DataTypeCheck" ControlToValidate="dobTextBox" ErrorMessage="Please enter a valid date."></asp:CompareValidator>
                        <span class="focus-input100"></span>
                        <span class="symbol-input100">
                        </span>
                    </div>
                    <div class="wrap-input100 validate-input">
                        <!--<input class="input100" type="text" name="email" placeholder="Email"> -->
                        <asp:TextBox ID="phonenumberTxtbox1" class="input100" runat="server" placeholder="Phone Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="phonenumberValidator1" runat="server" ErrorMessage="Phone Number required" ControlToValidate="phonenumberTxtbox1"></asp:RequiredFieldValidator>
                        <span class="focus-input100"></span>
                        <span class="symbol-input100">
                        </span>
                    </div>

                    <div class="container-login100-form-btn">
                        <asp:Button ID="Button2" class="login100-form-btn" runat="server" Text="Login" Style="float: right;" OnClick="submitBtn_Click" />
                    </div>
                    <div class="text-center p-t-12">
                        <asp:Label ID="message" class="txt2" runat="server"></asp:Label>
                    </div>
                </form>
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
