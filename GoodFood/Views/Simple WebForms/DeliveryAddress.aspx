<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeliveryAddress.aspx.cs" CodeFile="~/Views/Simple WebForms/DeliveryAddress.aspx.cs" Inherits="GoodFood.Views.Simple_WebForms.DeliveryAddress" %>

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
            Latitude<br />
            <asp:TextBox ID="txtLatitude" CssClass="form-control input-sm" runat="server"></asp:TextBox><br />
             Longitude<br />
            <asp:TextBox ID="txtLongitude" CssClass="form-control input-sm" runat="server"></asp:TextBox>
            <br />
            </div>
        <div class="col-md-4 col-md-offset-2">
            Order<br />
            <asp:DropDownList ID="DropDownListOrders" CssClass="form-control input-sm" runat="server" DataSourceID="SqlDataSource1" DataTextField="ORDERNUMBER" DataValueField="ORDERNUMBER"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;ORDERNUMBER&quot;, &quot;DELIVERYPOINT&quot; FROM &quot;ORDERS&quot;"></asp:SqlDataSource>
        <div>
            <label></label><br />
            <label></label>
        </div>
            <asp:Button ID="btnDeliveryInsert" runat="server" Text="Insert" class ="btn btn-primary" OnClick="btnDeliveryInsert_Click"/>
        
        
            <br />
        </div>
            </div>
        <div class="col px-md-5">
        <asp:GridView ID="GridViewDeliveryAddress" runat="server" CssClass="table" OnRowDeleting="OnRowDeleting" OnRowUpdating="OnRowUpdating" AutoGenerateColumns ="True" OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" DataKeyNames="DeliveryAddressID" HorizontalAlign="Center" >
        <Columns>
      
            <asp:CommandField ShowEditButton ="true" ControlStyle-CssClass="btn btn-info" HeaderText ="Actions" ButtonType="Link" />
           <asp:CommandField ShowDeleteButton ="true" ControlStyle-CssClass="btn btn-danger" HeaderText ="Actions" ButtonType="Link" />
          
        </Columns>
        </asp:GridView>
            </div>
    </form>
</body>
</html>
