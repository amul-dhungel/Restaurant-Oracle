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
    public partial class DeliveryAddress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }

        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT DeliveryAddressID,Latitude,Longitude,OrderNumber FROM DeliveryAddress";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("DeliveryAddress");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();

            GridViewDeliveryAddress.DataSource = dt;
            GridViewDeliveryAddress.DataBind();
        }

        //updating and deleting
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewDeliveryAddress.Rows[e.RowIndex];
            var id = GridViewDeliveryAddress.DataKeys[e.RowIndex].Values[0];
            string lat = (row.Cells[3].Controls[0] as TextBox).Text;
            string lon = (row.Cells[4].Controls[0] as TextBox).Text;
           

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (OracleConnection con = new OracleConnection(constr))
            {

                using (OracleCommand cmd = new OracleCommand("UPDATE DeliveryAddress SET Latitude ='" + lat + "',  Longitude ='" + lon + "' WHERE DeliveryAddressID ='" + id + "'"))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            GridViewDeliveryAddress.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var id = GridViewDeliveryAddress.DataKeys[e.RowIndex].Values[0];
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM DeliveryAddress WHERE DeliveryAddressID ='" + id + "'"))
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
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridViewDeliveryAddress.EditIndex)
            {
                //(e.Row.Cells[0].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row ?');";
            }
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewDeliveryAddress.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewDeliveryAddress.EditIndex = -1;
            this.BindGrid();
        }
        protected void btnDeliveryInsert_Click(object sender, EventArgs e)
        {
            string name = txtLatitude.Text.ToString();
            string phoneNumber = txtLongitude.Text.ToString();
            string email = DropDownListOrders.SelectedItem.Value.ToString();
             

            // ResID, ResName, ResAddress, ResPhone, ResEmail
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (OracleConnection con = new OracleConnection(constr))
            {
                //using (OracleCommand cmd = new OracleCommand("INSERT INTO Restaurant(RestID, RestName, Address, Phone, Email) VALUES ('"+ id +"', '"+ name +"', '"+ address +"', '"+ phone +"', '"+ email +"')"))
                using (OracleCommand cmd = new OracleCommand("INSERT INTO DeliveryAddress(Latitude,Longitude,OrderNumber) VALUES ( '" + name + "',  '" + phoneNumber + "', '" + email + "')"))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    txtLatitude.Text = null;
                    txtLongitude.Text = null;
                    

                }
            }
            this.BindGrid();
        }
    }
}