<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="DataDrivenApp.Pages.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="titleAdminPage" runat="server" Text="Label"></asp:Label>
        </div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Questions"></asp:Label>
            <br />
            <asp:GridView ID="QuestionGridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="683px"></asp:GridView>
        </div>
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3>Employee Search Form</h3>
            </div>
            <div class="panel-body">
                <div class="form-group">
                    <label for="inputFirstname" class="control-label col-xs-2">
                        Firstname
                    </label>
                    <div class="col-xs-10">
                        <input type="text" runat="server" class="form-control"
                            id="inputFirstname" placeholder="Firstname" />
                    </div>
                </div>

                <div class="form-group">
                    <label for="inputLastname" class="control-label col-xs-2">
                        Lastname
                    </label>
                    <div class="col-xs-10">
                        <input type="text" runat="server" class="form-control"
                            id="inputLastname" placeholder="Lastname" />
                    </div>
                </div>

                <div class="form-group">
                    <label for="inputGender" class="control-label col-xs-2">
                        Gender
                    </label>
                    <div class="col-xs-10">
                        <input type="text" runat="server" class="form-control"
                            id="inputGender" placeholder="Gender" />
                    </div>
                </div>

                <div class="form-group">
                    <label for="inputSalary" class="control-label col-xs-2">
                        Salary
                    </label>
                    <div class="col-xs-10">
                        <input type="number" runat="server" class="form-control"
                            id="inputSalary" placeholder="Salary" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-10 col-xs-offset-2">
                        <asp:Button ID="btnSearch" runat="server" Text="Search"
                            CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                    </div>
                </div>
            </div>
        </div>

        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3>Search Results</h3>
            </div>
            <div class="panel-body">
                <div class="col-xs-10">
                    <asp:GridView CssClass="table table-bordered"
                        ID="gvSearchResults" runat="server">
                    </asp:GridView>
    </form>
</body>
</html>
