<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SurveyQuestions.aspx.cs" Inherits="DataDrivenApp.Pages.SurveyQuestions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="titleSurvey" runat="server" Text=""></asp:Label>
        <%--<div>

            <asp:Label ID="Label2" runat="server" Text="What Bank(s) are you using?"></asp:Label>
            <br />
            <asp:CheckBoxList ID="QuestionCheckBoxList" runat="server"></asp:CheckBoxList>
            <br />
            <asp:Button ID="SubmitBtn" runat="server" Text="Submit" OnClick="SubmitBtn_Click" />


            <asp:BulletedList ID="SelectedBulletedList" runat="server"></asp:BulletedList>
            <%--<div>
            <asp:Label ID="Label1" runat="server" Text="Questions"></asp:Label>
            <br />
            <asp:GridView ID="QuestionGridView" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="683px"></asp:GridView>
        </div>
        </div>
        <div>
            <asp:Label ID="currentQuestionLabel" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Button ID="NextButton" runat="server" Text="Next" OnClick="NextButton_Click" />
        </div>--%>
        <div>
            <asp:Label ID="questionLabel" runat="server" Text="Label"></asp:Label>
            <br />
            <!-- if there is nothing on the placeholder which is populated by code, it will not render -->
            <asp:PlaceHolder ID="QuestionPlaceHolder" runat="server"></asp:PlaceHolder>
            <br />
            <asp:Button ID="nextBtn" runat="server" Text="Next" OnClick="nextBtn_Click" />
        </div> 
        <br />
        <asp:BulletedList ID="productBulletedList" runat="server"></asp:BulletedList>

        <asp:Button ID="skipBtn" runat="server" Text="Skip" OnClick="skipBtn_Click" />
           
    </form>
</body>
</html>
