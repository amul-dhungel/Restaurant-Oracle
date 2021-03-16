<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerOrder.aspx.cs" CodeFile="~/Views/Complex WebForms/CustomerOrder.aspx.cs" Inherits="GoodFood.Views.Complex_WebForms.CustomerOrder" %>

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
            Customer Name<br />
         
             <asp:DropDownList ID="DropDownListCustomer" CssClass="form-control input-sm" runat="server" DataSourceID="SqlDataSource1" DataTextField="CUSTOMERNAME" DataValueField="CUSTOMERID"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;CUSTOMERID&quot;, &quot;CUSTOMERNAME&quot; FROM &quot;CUSTOMER&quot;"></asp:SqlDataSource>
            <br />
             
                <asp:Button ID="buttonSearch" CssClass="btn btn-success" runat="server" Text="Search" OnClick="buttonSearch_Click1" />
            </div>
        </div><div class="col px-md-5">
        <asp:GridView ID="GridViewCustomerOrder" runat="server" CssClass="table" HorizontalAlign="Center" ></asp:GridView></div>
    </form>
</body>
</html>
