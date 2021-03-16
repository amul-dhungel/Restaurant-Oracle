using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;

namespace GoodFood.Views.Simple_WebForms
{
    public partial class LoyalityPoints : System.Web.UI.Page
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
            cmd.CommandText = "SELECT a.LoyalityPointsID,a.LoyalityPoint,a.DateTime,a.Duration,b.DishName FROM LoyalityPoints a,Dish b";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("LoyalityPoints");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();

            GridViewLoyality.DataSource = dt;
            GridViewLoyality.DataBind();
        }

        //updating and deleting
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewLoyality.Rows[e.RowIndex];
            var id = GridViewLoyality.DataKeys[e.RowIndex].Values[0];
            string point = (row.Cells[3].Controls[0] as TextBox).Text;
            string date = (row.Cells[4].Controls[0] as TextBox).Text;


            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (OracleConnection con = new OracleConnection(constr))
            {

                using (OracleCommand cmd = new OracleCommand("UPDATE LoyalityPoints SET LoyalityPoint ='" + point + "',DateTime = '" + date + "' WHERE ID ='" + id + "'"))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            GridViewLoyality.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var id = GridViewLoyality.DataKeys[e.RowIndex].Values[0];
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM LoyalityPoints WHERE LoyalityPointsID ='" + id + "'"))
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
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridViewLoyality.EditIndex)
            {
                //(e.Row.Cells[0].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row ?');";
            }
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewLoyality.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewLoyality.EditIndex = -1;
            this.BindGrid();
        }
        protected void btnLoyalityInsert_Click(object sender, EventArgs e)
        {
            string name = txtLoyalityPoint.Text.ToString();
            string phoneNumber = txtDateTime.Text.ToString();
            string points = DropDownListItems.SelectedItem.Value.ToString();

            // ResID, ResName, ResAddress, ResPhone, ResEmail
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (OracleConnection con = new OracleConnection(constr))
            {
                //using (OracleCommand cmd = new OracleCommand("INSERT INTO Restaurant(RestID, RestName, Address, Phone, Email) VALUES ('"+ id +"', '"+ name +"', '"+ address +"', '"+ phone +"', '"+ email +"')"))
                using (OracleCommand cmd = new OracleCommand("INSERT INTO LoyalityPoints(LoyalityPoint,DateTime) VALUES ( '" + name + "',  '" + phoneNumber + "')"))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    txtLoyalityPoint.Text = null;
                    txtDateTime.Text = null;
         
                }
            }
            this.BindGrid();
        }

    }
}