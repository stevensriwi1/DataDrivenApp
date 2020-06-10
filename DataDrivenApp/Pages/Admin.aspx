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
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3>Employee Search Form</h3>
            </div>
            <div class="panel-body" style="display:flex;flex-direction: row; width: 100%; margin: auto;">
                <div style="width: 20%;">
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
                        <label for="inputPostcode" class="control-label col-xs-2">
                            Postcode
                        </label>
                        <div class="col-xs-10">
                            <input type="text" runat="server" class="form-control"
                                id="inputPostcode" placeholder="Postcode" />
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="inputSuburb" class="control-label col-xs-2">
                            Suburb
                        </label>
                        <div class="col-xs-10">
                            <input type="text" runat="server" class="form-control"
                                id="inputSuburb" placeholder="Suburb" />
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="inputEmailAddress" class="control-label col-xs-2">
                            Email Address
                        </label>
                        <div class="col-xs-10">
                            <input type="text" runat="server" class="form-control"
                                id="inputEmailAddress" placeholder="Email Address" />
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="inputAgeMin" class="control-label col-xs-2">
                            Age (Min)
                        </label>
                        <div class="col-xs-10">
                            <input type="number" runat="server" class="form-control"
                                id="inputAgeMin" placeholder="Age Min" />
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="inputAgeMax" class="control-label col-xs-2">
                            Age (Max)
                        </label>
                        <div class="col-xs-10">
                            <input type="number" runat="server" class="form-control"
                                id="inputAgeMax" placeholder="Age Max" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-10 col-xs-offset-2">
                            <asp:Button ID="btnSearch" runat="server" Text="Search"
                                CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                        </div>
                    </div>
                </div>
                <div style="width: 12.5%;">
                    <div class="form-group">
                        <label for="CheckBoxListInputState" class="control-label col-xs-2">
                            State/Teritory
                        </label>
                        <div class="col-xs-10">
                            <asp:CheckBoxList ID="CheckBoxListInputState" runat="server" class="form-control"></asp:CheckBoxList>
                            
                        </div>
                    </div>
                </div>
                <div style="width: 12.5%;">
                    <div class="form-group">
                        <label for="CheckBoxListGender" class="control-label col-xs-2">
                            Gender
                        </label>
                        <div class="col-xs-10">
                            <asp:CheckBoxList ID="CheckBoxListGender" runat="server" class="form-control"></asp:CheckBoxList>
                            
                        </div>
                    </div>
                </div>
                <div style="width: 12.5%;">
                    <div class="form-group">
                        <label for="CheckBoxListBank" class="control-label col-xs-2">
                            Bank
                        </label>
                        <div class="col-xs-10">
                            <asp:CheckBoxList ID="CheckBoxListBank" runat="server" class="form-control"></asp:CheckBoxList>
                            
                        </div>
                    </div>
                </div>
                <div style="width: 12.5%;">
                    <div class="form-group">
                        <label for="CheckBoxListBankServicesCommbank" class="control-label col-xs-2">
                           Commbank Bank Services
                        </label>
                        <div class="col-xs-10">
                            <asp:CheckBoxList ID="CheckBoxListBankServicesCommbank" runat="server" class="form-control"></asp:CheckBoxList>
                            
                        </div>
                    </div>
                </div>
                <div style="width: 12.5%;">
                    <div class="form-group">
                        <label for="CheckBoxListBankServicesNAB" class="control-label col-xs-2">
                           NAB Bank Services
                        </label>
                        <div class="col-xs-10">
                            <asp:CheckBoxList ID="CheckBoxListBankServicesNAB" runat="server" class="form-control"></asp:CheckBoxList>
                            
                        </div>
                    </div>
                </div>
                <div style="width: 12.5%;">
                    <div class="form-group">
                        <label for="CheckBoxListBankServicesANZ" class="control-label col-xs-2">
                           ANZ Bank Services
                        </label>
                        <div class="col-xs-10">
                            <asp:CheckBoxList ID="CheckBoxListBankServicesANZ" runat="server" class="form-control"></asp:CheckBoxList>
                            
                        </div>
                    </div>
                </div>
                <div style="width: 12.5%;">
                    <div class="form-group">
                        <label for="CheckBoxListNewspaper" class="control-label col-xs-2">
                            Newspaper
                        </label>
                        <div class="col-xs-10">
                            <asp:CheckBoxList ID="CheckBoxListNewspaper" runat="server" class="form-control"></asp:CheckBoxList>
                            
                        </div>
                    </div>
                </div>
                <div style="width: 12.5%;">
                    <div class="form-group">
                        <label for="CheckBoxListSports" class="control-label col-xs-2">
                            Sports
                        </label>
                        <div class="col-xs-10">
                            <asp:CheckBoxList ID="CheckBoxListSports" runat="server" class="form-control"></asp:CheckBoxList>
                            
                        </div>
                    </div>
                </div>
                <div style="width: 12.5%;">
                    <div class="form-group">
                        <label for="CheckBoxListTravel" class="control-label col-xs-2">
                            Travel Destination
                        </label>
                        <div class="col-xs-10">
                            <asp:CheckBoxList ID="CheckBoxListTravel" runat="server" class="form-control"></asp:CheckBoxList>
                            
                        </div>
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
                        ID="SearchResultsGridView" runat="server">
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
