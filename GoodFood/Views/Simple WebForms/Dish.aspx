<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Views/Simple WebForms/Dish.aspx.cs" CodeBehind="Dish.aspx.cs" Inherits="GoodFood.Views.Simple_WebForms.Dish" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
         <div class="row col px-md-5">

        <div class="col-md-4 col-md-offset-2">
            Dish Name<br />
            <asp:TextBox ID="txtDishName" CssClass="form-control input-sm" runat="server"></asp:TextBox><br />
             Local Name<br />
            <asp:TextBox ID="txtLocalName" CssClass="form-control input-sm" runat="server"></asp:TextBox>
            <br />
            </div>
        <div class="col-md-4 col-md-offset-2">
            Dish Rate<br />
            <asp:TextBox ID="txtDishRate" CssClass="form-control input-sm" runat="server"></asp:TextBox>
            <label></label><br />
            <label></label><br />
            <asp:DropDownList ID="DropDownListRestaurant" DataTextField="RestaurantName" DataValueField="RestaurantID" CssClass="form-control input-sm" runat="server" DataSourceID="SqlDataSource1">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;RESTAURANTID&quot;, &quot;RESTAURANTNAME&quot; FROM &quot;RESTAURANT&quot;"></asp:SqlDataSource>
            </div>

            
            <div "col-md-4 col-md-offset-2">
                    <div>
                  <label></label>
                  <label></label>
                  <label></label>
                  <label></label>
             </div>
                  <asp:Button ID="btnDishInsert" runat="server" Text="Insert" class ="btn btn-primary" OnClick="btnDishInsert_Click"/>
            </div>
          
            <br />

            </div>
        <div class="col px-md-5">
        <asp:GridView ID="GridViewDish" runat="server" CssClass="table" OnRowDeleting="OnRowDeleting" OnRowUpdating="OnRowUpdating" AutoGenerateColumns ="True" OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" DataKeyNames="DishID"  HorizontalAlign="Center" >
        <Columns>
  <%--          <asp:BoundField HeaderText="Customer ID" DataField="CustomerID" />
            <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" />
            <asp:BoundField HeaderText="Customer Email" DataField="CustomerEmail" />
            <asp:BoundField HeaderText="Phone Number" DataField="PhoneNumber" />--%>
      
            <asp:CommandField ShowEditButton ="true" ControlStyle-CssClass="btn btn-info" HeaderText ="Actions" ButtonType="Link" />
           <asp:CommandField ShowDeleteButton ="true" ControlStyle-CssClass="btn btn-danger" HeaderText ="Actions" ButtonType="Link" />
          
        </Columns>
        </asp:GridView>
            </div>
    </form>
</body>
</html>
