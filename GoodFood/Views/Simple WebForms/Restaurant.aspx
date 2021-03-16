<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="~/Views/Simple WebForms/Restaurant.aspx.cs" CodeFile="Restaurant.aspx.cs" Inherits="GoodFood.Views.Simple_WebForms.Restaurant" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
     <form id="form1" runat="server" class="col px-md-5">
        <div class="row col px-md-5">

        <div class="col-md-4 col-md-offset-2">
            Restaurant Name<br />
            <asp:TextBox ID="txtRestaurantName" CssClass="form-control input-sm" runat="server"></asp:TextBox><br />
             Restaurant Address<br />
            <asp:TextBox ID="txtRestaurantAddress" CssClass="form-control input-sm" runat="server"></asp:TextBox>
            <br />
            </div>
        <div class="col-md-4 col-md-offset-2">
            Contact Email<br />
            <asp:TextBox ID="txtContactEmail" CssClass="form-control input-sm" runat="server"></asp:TextBox>
        <div>
            <label></label><br />
            <label></label>
        </div>
            <asp:Button ID="btnRestaurantInsert" runat="server" Text="Insert" class ="btn btn-primary" OnClick="btnRestaurantInsert_Click"/>
        
        
            <br />
        </div>
            </div>
        <div class="col px-md-5">
        <asp:GridView ID="GridViewRestaurant" runat="server" CssClass="table" OnRowDeleting="OnRowDeleting" OnRowUpdating="OnRowUpdating" AutoGenerateColumns ="True" OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" DataKeyNames="RestaurantID"  HorizontalAlign="Center" >
        <Columns>
  <%--          <asp:BoundField HeaderText="Restaurant ID" DataField="RestaurantID" />
            <asp:BoundField HeaderText="Restaurant Name" DataField="RestaurantName" />
            <asp:BoundField HeaderText="Restaurant Email" DataField="RestaurantEmail" />
            <asp:BoundField HeaderText="Phone Number" DataField="PhoneNumber" />--%>
      
            <asp:CommandField ShowEditButton ="true" ControlStyle-CssClass="btn btn-info" HeaderText ="Actions" ButtonType="Link" />
           <asp:CommandField ShowDeleteButton ="true" ControlStyle-CssClass="btn btn-danger" HeaderText ="Actions" ButtonType="Link" />
          
        </Columns>
        </asp:GridView>
            </div>
    </form>
</body>
</html>
