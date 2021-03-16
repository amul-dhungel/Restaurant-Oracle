<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order.aspx.cs" CodeFile="~/Views/Simple WebForms/Order.aspx.cs" Inherits="GoodFood.Views.Simple_WebForms.Order" %>

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
            SN<br />
            <asp:TextBox ID="txtSN" CssClass="form-control input-sm" runat="server"></asp:TextBox><br />
             Order Amount<br />
            <asp:TextBox ID="txtOrderAmount" CssClass="form-control input-sm" runat="server"></asp:TextBox>
            <br />
                Dishes<br />
                 <asp:DropDownList ID="DropDownListDishes"  CssClass="form-control input-sm" runat="server" DataSourceID="SqlDataSource2" DataTextField="DISHNAME" DataValueField="DISHID" ></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;DISHID&quot;, &quot;DISHNAME&quot; FROM &quot;DISH&quot;"></asp:SqlDataSource>
            </div>
        <div class="col-md-4 col-md-offset-2">
            Delivery Point<br />
            <asp:TextBox ID="txtDeliveryPoint" CssClass="form-control input-sm" runat="server"></asp:TextBox>
            <label></label><br />
            Status<br />
            <asp:DropDownList ID="DropDownListStatus"  CssClass="form-control input-sm" runat="server" >
                <asp:ListItem>Early</asp:ListItem>
                <asp:ListItem>On Time</asp:ListItem>
                <asp:ListItem>Late</asp:ListItem>
            </asp:DropDownList>
            <label></label><br />
                  Customers<br />
                  <asp:DropDownList ID="DropDownListCustomers"  CssClass="form-control input-sm" runat="server" DataSourceID="SqlDataSource1" DataTextField="CUSTOMERNAME" DataValueField="CUSTOMERID" ></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;CUSTOMERNAME&quot;, &quot;CUSTOMERID&quot; FROM &quot;CUSTOMER&quot;"></asp:SqlDataSource>
            <label></label><br />

             <asp:Button ID="btnOrderInsert" runat="server" Text="Insert" class ="btn btn-primary" OnClick="btnOrderInsert_Click" />
            </div>

             <div class="col-md-4 col-md-offset-2">
            Order Unit<br />
            <asp:TextBox ID="txtOrderUnit" CssClass="form-control input-sm" runat="server"></asp:TextBox>
            <label></label><br />
            Restaurant<br />
            <asp:DropDownList ID="DropDownListRestaurant"  CssClass="form-control input-sm" runat="server" DataSourceID="SqlDataSource3" DataTextField="RESTAURANTNAME" DataValueField="RESTAURANTID" >
            
            </asp:DropDownList>
                 <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;RESTAURANTID&quot;, &quot;RESTAURANTNAME&quot; FROM &quot;RESTAURANT&quot;"></asp:SqlDataSource>
            <label></label><br />
                  Total<br />
                   <asp:TextBox ID="txtTotal" CssClass="form-control input-sm" runat="server"></asp:TextBox>
            <label></label><br />
            </div>

     
         
          
            <br />

            </div>
        <div class="col px-md-5">
        <asp:GridView ID="GridViewOrder" runat="server" CssClass="table" OnRowDeleting="OnRowDeleting" OnRowUpdating="OnRowUpdating" AutoGenerateColumns ="True" OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" DataKeyNames="OrderNumber"  HorizontalAlign="Center" >
        <Columns>

      
            <asp:CommandField ShowEditButton ="true" ControlStyle-CssClass="btn btn-info" HeaderText ="Actions" ButtonType="Link" />
           <asp:CommandField ShowDeleteButton ="true" ControlStyle-CssClass="btn btn-danger" HeaderText ="Actions" ButtonType="Link" />
          
        </Columns>
        </asp:GridView>
            </div>
    </form>
</body>
</html>
