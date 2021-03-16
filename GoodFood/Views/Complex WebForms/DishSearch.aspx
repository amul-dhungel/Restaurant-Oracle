<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DishSearch.aspx.cs" CodeFile="~/Views/Complex WebForms/DishSearch.aspx.cs" Inherits="GoodFood.Views.Complex_WebForms.DishSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
     <form id="form1" runat="server">
        <div>
            <div class="col-md-4 col px-md-5">
            Dish Search<br />
         
             <asp:DropDownList ID="DropDownListDish" CssClass="form-control input-sm" runat="server" DataSourceID="SqlDataSource1" DataTextField="DISHNAME" DataValueField="DISHID" ></asp:DropDownList>
               
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;DISHID&quot;, &quot;DISHNAME&quot; FROM &quot;DISH&quot;"></asp:SqlDataSource>
               
            <br />
             
                <asp:Button ID="buttonSearch" CssClass="btn btn-success" runat="server" Text="Search" OnClick="buttonSearch_Click1"  />
            </div>
        </div><div class="col px-md-5">
        <asp:GridView ID="GridViewDishes" runat="server" CssClass="table" HorizontalAlign="Center" ></asp:GridView></div>
  
    </form>
</body>
</html>
