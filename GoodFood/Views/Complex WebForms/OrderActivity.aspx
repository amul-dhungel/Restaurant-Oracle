<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderActivity.aspx.cs" Inherits="GoodFood.Views.Complex_WebForms.OrderActivity" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <div>
            <div class="col-md-4 col px-md-5">
            Customer Name<br />
         
             <asp:DropDownList ID="DropDownListOrderActivity" CssClass="form-control input-sm" runat="server" ></asp:DropDownList>
                
            <br />
             
                <asp:Button ID="buttonSearch" CssClass="btn btn-success" runat="server" Text="Search"  />
            </div>
        </div><div class="col px-md-5">
        <asp:GridView ID="GridViewOrderActivity" runat="server" CssClass="table" HorizontalAlign="Center" ></asp:GridView></div>
        </div>
    </form>
</body>
</html>
