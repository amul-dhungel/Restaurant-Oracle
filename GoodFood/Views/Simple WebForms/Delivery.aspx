<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delivery.aspx.cs" CodeFile="~/Views/Simple WebForms/Delivery.aspx.cs" Inherits="GoodFood.Views.Simple_WebForms.Delivery" %>

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
            Customer Name<br />
            <asp:TextBox ID="txtCustomerName" CssClass="form-control input-sm" runat="server"></asp:TextBox><br />
             Customer Email<br />
            <asp:TextBox ID="txtCustomerEmail" CssClass="form-control input-sm" runat="server"></asp:TextBox>
            <br />
            </div>
        <div class="col-md-4 col-md-offset-2">
            Phone Number<br />
            <asp:TextBox ID="txtPhoneNumber" CssClass="form-control input-sm" runat="server"></asp:TextBox>
        <div>
            <label></label><br />
            <label></label>
        </div>
            <asp:Button ID="btnCustomerInsert" runat="server" Text="Insert" class ="btn btn-primary" OnClick="btnCustomerInsert_Click"/>
        
        
            <br />
        </div>
            </div>
        <div class="col px-md-5">
        <asp:GridView ID="GridViewCustomer" runat="server" CssClass="table" OnRowDeleting="OnRowDeleting" OnRowUpdating="OnRowUpdating" AutoGenerateColumns ="True" OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" DataKeyNames="CustomerID" OnSelectedIndexChanged="GridViewCustomer_SelectedIndexChanged" HorizontalAlign="Center" >
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
