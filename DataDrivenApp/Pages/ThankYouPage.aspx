<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThankYouPage.aspx.cs" Inherits="DataDrivenApp.Pages.ThankYouPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thank you</title>
    <link rel="icon" type="image/png" href="../images/icons/favicon.ico" />
    <link rel="stylesheet" type="text/css" href="../vendor/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../fonts/font-awesome-4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="../vendor/animate/animate.css" />
    <link rel="stylesheet" type="text/css" href="../vendor/css-hamburgers/hamburgers.min.css" />
    <link rel="stylesheet" type="text/css" href="../vendor/select2/select2.min.css" />
    <link rel="stylesheet" type="text/css" href="../css1/util.css" />
    <link rel="stylesheet" type="text/css" href="../css1/main.css" />
    <link href="~/CSS/Styles.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
</head>
<body>
    <div class="container-login100">
        <div class="wrap-login100">
            <form id="form1" runat="server">
                <div>
                    Thank You!
                </div>
                <div class="container-login100-form-btn">
                    <asp:Button ID="backButton" class="login100-form-btn" runat="server" Text="<< Back" Style="float: right;" OnClick="backBtn_Click" />
                </div>
            </form>
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
