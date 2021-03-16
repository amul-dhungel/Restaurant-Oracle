using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoodFood.Views.Simple_WebForms
{
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }

        // viewing tables data
        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT OrderNumber,SN,OrderAmount,DeliveryPoint,Status,OrderDate,DishID,CustomerID FROM Orders";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("Order");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();

            GridViewOrder.DataSource = dt;
            GridViewOrder.DataBind();
        }

        //updating and deleting
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewOrder.Rows[e.RowIndex];
            var id = GridViewOrder.DataKeys[e.RowIndex].Values[0];
            string SN = (row.Cells[3].Controls[0] as TextBox).Text;
            string OrderAmount = (row.Cells[4].Controls[0] as TextBox).Text;
            string DeliveryPoint = (row.Cells[5].Controls[0] as TextBox).Text;
            string Status = (row.Cells[5].Controls[0] as TextBox).Text;
           
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (OracleConnection con = new OracleConnection(constr))
            {

                using (OracleCommand cmd = new OracleCommand("UPDATE Orders SET SN ='" + SN + "',  OrderAmount ='" + OrderAmount + "',DeliveryPoint = '" + DeliveryPoint + "',Status ='"+ Status + "' WHERE OrderNumber ='" + id + "'"))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            GridViewOrder.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var id = GridViewOrder.DataKeys[e.RowIndex].Values[0];
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM Orders WHERE OrderNumber ='" + id + "'"))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridViewOrder.EditIndex)
            {
                //(e.Row.Cells[0].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row ?');";
            }
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewOrder.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewOrder.EditIndex = -1;
            this.BindGrid();
        }
        protected void btnOrderInsert_Click(object sender, EventArgs e)
        {
            string sn = txtSN.Text.ToString();
            var ordid = "ORD021";
            string orderamount = txtOrderAmount.Text.ToString();
            string deliverypoint = txtDeliveryPoint.Text.ToString();
            string status = DropDownListStatus.Text.ToString();
            string customer = DropDownListCustomers.SelectedItem.Value.ToString();
            string dish = DropDownListDishes.SelectedItem.Value.ToString();

            string unit = txtOrderUnit.Text.ToString();
            string total = txtTotal.Text.ToString();
            string restaurant = DropDownListRestaurant.SelectedItem.Value.ToString();

            // ResID, ResName, ResAddress, ResPhone, ResEmail
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (OracleConnection con = new OracleConnection(constr))
            {
                //using (OracleCommand cmd = new OracleCommand("INSERT INTO Restaurant(RestID, RestName, Address, Phone, Email) VALUES ('"+ id +"', '"+ name +"', '"+ address +"', '"+ phone +"', '"+ email +"')"))
                using (OracleCommand cmd = new OracleCommand("INSERT INTO Orders(SN,OrderAmount,DeliveryPoint,Status,DishID,CustomerID) VALUES ( '" + sn + "',  '" + orderamount + "', '" + deliverypoint + "','" + status + "','" + dish + "','" + customer + "')"))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                   
                    con.Close();

                    txtSN.Text = null;
                    txtOrderAmount.Text = null;
                    txtDeliveryPoint.Text = null;

                }

                using (OracleCommand cmd = new OracleCommand("INSERT INTO DishOrder(OrderNumber,OrderUnit,LineTotal,RestaurantID) VALUES ( '" + ordid + "','" + unit + "','" + total + "','" + restaurant + "')"))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    txtSN.Text = null;
                    txtOrderAmount.Text = null;
                    txtDeliveryPoint.Text = null;

                }
            }
            this.BindGrid();
        }


    }
}