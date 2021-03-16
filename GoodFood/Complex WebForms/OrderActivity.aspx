<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderActivity.aspx.cs" Inherits="CWOracleWebForms.Complex_WebForms.OrderActivity" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Label ID="Label1" runat="server" Text="Customer Order Details"></asp:Label>
            </div>
            <div>
                <asp:Label ID="Label2" runat="server" Text="Customer List"></asp:Label>
                <asp:DropDownList ID="orderDropDown" runat="server" DataSourceID="SqlDataSource1" DataTextField="NAME" DataValueField="CUSTID"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GoodFoodConnection %>" ProviderName="<%$ ConnectionStrings:GoodFoodConnection.ProviderName %>" SelectCommand="SELECT &quot;CUSTID&quot;, &quot;NAME&quot; FROM &quot;CUSTOMER&quot;"></asp:SqlDataSource>
            </div>
            <div>
                <asp:Button ID="buttonSearch" runat="server" Text="Search" OnClick="buttonSearch_Click" />
            </div>
            <div>
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
