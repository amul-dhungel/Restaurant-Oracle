<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoyalityPoints.aspx.cs" CodeFile="~/Views/Simple WebForms/LoyalityPoints.aspx.cs" Inherits="GoodFood.Views.Simple_WebForms.LoyalityPoints" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
         <meta content='width=device-width, initial-scale=1.0, shrink-to-fit=no' name='viewport' />
  <!--     Fonts and icons     -->
  <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css">
  <!-- CSS Files -->
  <link href="../assets/css/material-dashboard.css?v=2.1.2" rel="stylesheet" />
  <!-- CSS Just for demo purpose, don't include it in your project -->
  <link href="../assets/demo/demo.css" rel="stylesheet" />
</head>
<body>
     <div class="wrapper ">
    <div class="sidebar" data-color="purple" data-background-color="white" data-image="../assets/img/sidebar-1.jpg">
      <!--
        Tip 1: You can change the color of the sidebar using: data-color="purple | azure | green | orange | danger"

        Tip 2: you can also add an image using data-image tag
    -->
      <div class="logo"><a href="http://www.creative-tim.com" class="simple-text logo-normal">
          Amul Dhungel
        </a></div>
      <div class="sidebar-wrapper">
        <ul class="nav">
          <li class="nav-item  ">
            <a class="nav-link" href="../Homepage/Dashboard.aspx">
              <i class="material-icons">dashboard</i>
              <p>Dashboard</p>
            </a>
          </li>
          <li class="nav-item ">
            <a class="nav-link" href="../Simple WebForms/Customer.aspx">
              <i class="material-icons">person</i>
              <p>Customer</p>
            </a>
          </li>
          <li class="nav-item ">
            <a class="nav-link" href="../Simple WebForms/Restaurant.aspx">
              <i class="material-icons">takeout_dining</i>
              <p>Restaurant</p>
            </a>
          </li>
          <li class="nav-item ">
            <a class="nav-link" href="../Simple WebForms/Dish.aspx">
              <i class="material-icons">ramen_dining</i>
              <p>Dish</p>
            </a>
          </li>
          <li class="nav-item  active ">
            <a class="nav-link" href="../Simple WebForms/LoyalityPoints.aspx">
              <i class="material-icons">bubble_chart</i>
              <p>Loyalty Points</p>
            </a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="../Simple WebForms/Order.aspx">
              <i class="material-icons">content_paste</i>
              <p>Order</p>
            </a>
          </li>
          <li class="nav-item ">
            <a class="nav-link" href="../Simple WebForms/DeliveryAddress.aspx">
              <i class="material-icons">location_ons</i>
              <p>Delivery Address</p>
            </a>
          </li>
             <li class="nav-item ">
            <a class="nav-link" href="../Simple WebForms/DishOrder.aspx">
              <i class="material-icons">content_paste</i>
              <p>Dish Order</p>
            </a>
          </li>
             <li class="nav-item ">
            <a class="nav-link" href="../Complex WebForms/CustomerOrder.aspx">
              <i class="material-icons">person_search</i>
              <p>Customer Order</p>
            </a>
          </li>
             <li class="nav-item ">
            <a class="nav-link" href="../Complex WebForms/DishSearch.aspx">
              <i class="material-icons">fastfood</i>
              <p>Dish Search</p>
            </a>
          </li>
             <li class="nav-item ">
            <a class="nav-link" href="../Complex WebForms/OrderActivity.aspx">
              <i class="material-icons">menu_book</i>
              <p>Order Activity</p>
            </a>
          </li>
        </ul>
      </div>
    </div>
    <div class="main-panel" data-background-color="white">
      <!-- Navbar -->
        <nav class="navbar navbar-expand-lg navbar-transparent navbar-absolute fixed-top ">
        <div data-background-color="white">
          <div class="navbar-wrapper">
            <a class="navbar-brand" href="javascript:;">Loyalty Points Details</a>
          </div>
            </div>
            </nav>
        <div>
            <label></label><br />
             <label></label><br />
             <label></label><br />
             <label></label><br />
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
           <div class="card">
                <div class="card-header card-header-primary">
                  <h4 class="card-title ">Loyalty Points Details</h4>
                  <p class="card-category">Here, is the list of Loyalty Points to the dishes.</p>
                </div>
                <div class="card-body">
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
            </div></div>
    </form>
            </div></div></div>
</body>
</html>
