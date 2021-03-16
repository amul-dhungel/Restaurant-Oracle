<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DishOrder.aspx.cs" CodeFile="~/Views/Simple WebForms/DishOrder.aspx.cs" Inherits="GoodFood.Views.Simple_WebForms.DishOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
             <div class="col px-md-5">
                 Dish Order Details<br /><br />
        <asp:GridView ID="GridViewDishOrder" runat="server" CssClass="table" OnRowDeleting="OnRowDeleting" OnRowUpdating="OnRowUpdating" AutoGenerateColumns ="True" OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" DataKeyNames="DishOrderID" HorizontalAlign="Center" >
        <Columns>
            <asp:CommandField ShowEditButton ="true" ControlStyle-CssClass="btn btn-info" HeaderText ="Actions" ButtonType="Link" />
           <asp:CommandField ShowDeleteButton ="true" ControlStyle-CssClass="btn btn-danger" HeaderText ="Actions" ButtonType="Link" />
          
        </Columns>
        </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
