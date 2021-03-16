<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoyalityPoints.aspx.cs" CodeFile="~/Views/Simple WebForms/LoyalityPoints.aspx.cs" Inherits="GoodFood.Views.Simple_WebForms.LoyalityPoints" %>

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
            Loyality Point<br />
            <asp:TextBox ID="txtLoyalityPoint" CssClass="form-control input-sm" runat="server"></asp:TextBox><br />
             DateTime<br />
            <asp:TextBox ID="txtDateTime" CssClass="form-control input-sm" runat="server"></asp:TextBox>
            <br />
            </div>
        <div class="col-md-4 col-md-offset-2">
            Choose Items<br />
            <asp:DropDownList ID="DropDownListItems" runat="server" DataSourceID="SqlDataSource1" DataTextField="DISHNAME" DataValueField="DISHID" CssClass="form-control input-sm"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;DISHID&quot;, &quot;DISHNAME&quot; FROM &quot;DISH&quot;"></asp:SqlDataSource>
        <div>
            <label></label><br />
            <label></label>
        </div>
            <asp:Button ID="btnLoyalityInsert" runat="server" Text="Insert" class ="btn btn-primary" OnClick="btnLoyalityInsert_Click"/>
        
        
            <br />
        </div>
            </div>
        <div class="col px-md-5">
        <asp:GridView ID="GridViewLoyality" runat="server" CssClass="table" OnRowDeleting="OnRowDeleting" OnRowUpdating="OnRowUpdating" AutoGenerateColumns ="True" OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" DataKeyNames="LoyalityPointsID" HorizontalAlign="Center" >
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
