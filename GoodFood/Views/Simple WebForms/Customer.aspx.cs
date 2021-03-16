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
    public partial class Customer : System.Web.UI.Page
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
            cmd.CommandText = "SELECT CustomerID,CustomerName,PhoneNumber,CustomerEmail,CreatedDate,UpdatedDate FROM Customer";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("Customer");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();

            GridViewCustomer.DataSource = dt;
            GridViewCustomer.DataBind();
        }

        //updating and deleting
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewCustomer.Rows[e.RowIndex];
            var id = GridViewCustomer.DataKeys[e.RowIndex].Values[0];
            string Name = (row.Cells[3].Controls[0] as TextBox).Text;
            string PhoneNumber = (row.Cells[4].Controls[0] as TextBox).Text;
            string Email = (row.Cells[5].Controls[0] as TextBox).Text;

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (OracleConnection con = new OracleConnection(constr))
            {

                using (OracleCommand cmd = new OracleCommand("UPDATE Customer SET CustomerName ='" + Name + "',  PhoneNumber ='" + PhoneNumber + "',CustomerEmail = '" + Email + "' WHERE CustomerID ='" + id + "'"))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            GridViewCustomer.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var id = GridViewCustomer.DataKeys[e.RowIndex].Values[0];
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM Customer WHERE CustomerID ='" + id + "'"))
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
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridViewCustomer.EditIndex)
            {
                //(e.Row.Cells[0].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row ?');";
            }
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewCustomer.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewCustomer.EditIndex = -1;
            this.BindGrid();
        }
        protected void btnCustomerInsert_Click(object sender, EventArgs e)
        {
            string name = txtCustomerName.Text.ToString();
            string phoneNumber = txtPhoneNumber.Text.ToString();
            string email = txtCustomerEmail.Text.ToString();

            // ResID, ResName, ResAddress, ResPhone, ResEmail
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (OracleConnection con = new OracleConnection(constr))
            {
                //using (OracleCommand cmd = new OracleCommand("INSERT INTO Restaurant(RestID, RestName, Address, Phone, Email) VALUES ('"+ id +"', '"+ name +"', '"+ address +"', '"+ phone +"', '"+ email +"')"))
                using (OracleCommand cmd = new OracleCommand("INSERT INTO Customer(CustomerName,PhoneNumber,CustomerEmail) VALUES ( '" + name + "',  '" + phoneNumber+"', '" + email + "')"))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    txtCustomerName.Text = null;
                    txtPhoneNumber.Text = null;
                    txtCustomerEmail.Text = null;

                }
            }
            this.BindGrid();
        }

        protected void GridViewCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}