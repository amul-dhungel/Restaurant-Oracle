<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DishSearch.aspx.cs" Inherits="CWOracleWebForms.Complex_WebForms.DishSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Dish Search"></asp:Label>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Dish"></asp:Label>
            <asp:DropDownList ID="DishList" runat="server" DataSourceID="SqlDataSource2" DataTextField="NAME" DataValueField="FOODID"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GoodFoodConnection %>" ProviderName="<%$ ConnectionStrings:GoodFoodConnection.ProviderName %>" SelectCommand="SELECT &quot;FOODID&quot;, &quot;NAME&quot; FROM &quot;FOOD&quot;"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GoodFoodConnection %>" ProviderName="<%$ ConnectionStrings:GoodFoodConnection.ProviderName %>" SelectCommand="SELECT &quot;FOODID&quot;, &quot;NAME&quot; FROM &quot;FOOD&quot;"></asp:SqlDataSource>
        </div>
        <div>
            <asp:Button ID="buttonSearch" runat="server" Text="Search" OnClick="buttonSearch_Click" />
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
