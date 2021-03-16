using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data;


namespace GoodFood.Views.Simple_WebForms
{
    public partial class Restaurant : System.Web.UI.Page
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
            cmd.CommandText = "SELECT RestaurantID,RestaurantName,RestaurantAddress,ContactEmail FROM Restaurant";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("Restaurant");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();

            GridViewRestaurant.DataSource = dt;
            GridViewRestaurant.DataBind();
        }

        //updating and deleting
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewRestaurant.Rows[e.RowIndex];
            var id = GridViewRestaurant.DataKeys[e.RowIndex].Values[0];
            string Name = (row.Cells[3].Controls[0] as TextBox).Text;
            string Address = (row.Cells[4].Controls[0] as TextBox).Text;
            string Email = (row.Cells[5].Controls[0] as TextBox).Text;

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (OracleConnection con = new OracleConnection(constr))
            {

                using (OracleCommand cmd = new OracleCommand("UPDATE Restaurant SET RestaurantName ='" + Name + "',  RestaurantAddress ='" + Address + "',ContactEmail = '" + Email + "' WHERE RestaurantID ='" + id + "'"))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            GridViewRestaurant.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var id = GridViewRestaurant.DataKeys[e.RowIndex].Values[0];
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM Restaurant WHERE RestaurantID ='" + id + "'"))
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
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridViewRestaurant.EditIndex)
            {
                //(e.Row.Cells[0].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row ?');";
            }
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRestaurant.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewRestaurant.EditIndex = -1;
            this.BindGrid();
        }

        protected void btnRestaurantInsert_Click(object sender, EventArgs e)
        {
            string name = txtRestaurantName.Text.ToString();
            string address = txtRestaurantAddress.Text.ToString();
            string email = txtContactEmail.Text.ToString();

            // ResID, ResName, ResAddress, ResPhone, ResEmail
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (OracleConnection con = new OracleConnection(constr))
            {
                //using (OracleCommand cmd = new OracleCommand("INSERT INTO Restaurant(RestID, RestName, Address, Phone, Email) VALUES ('"+ id +"', '"+ name +"', '"+ address +"', '"+ phone +"', '"+ email +"')"))
                using (OracleCommand cmd = new OracleCommand("INSERT INTO Restaurant(RestaurantName,RestaurantAddress,ContactEmail) VALUES ( '" + name + "',  '" + address + "', '" + email + "')"))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    txtRestaurantName.Text = null;
                    txtRestaurantAddress.Text = null;
                    txtContactEmail.Text = null;

                }
            }
            this.BindGrid();
        }
    }
}