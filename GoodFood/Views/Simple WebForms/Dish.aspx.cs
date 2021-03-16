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
    public partial class Dish : System.Web.UI.Page
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
            cmd.CommandText = "SELECT a.DishID,a.DishName,a.LocalName,a.DishRate,b.RestaurantName from Dish a,Restaurant b";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("Dish");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();

            GridViewDish.DataSource = dt;
            GridViewDish.DataBind();
        }

        //updating and deleting
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewDish.Rows[e.RowIndex];
            var id = GridViewDish.DataKeys[e.RowIndex].Values[0];
            string Name = (row.Cells[3].Controls[0] as TextBox).Text;
            string Local = (row.Cells[4].Controls[0] as TextBox).Text;
            string Rate = (row.Cells[5].Controls[0] as TextBox).Text;
  

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (OracleConnection con = new OracleConnection(constr))
            {

                using (OracleCommand cmd = new OracleCommand("UPDATE Dish SET DishName ='" + Name + "',  LocalName ='" + Local + "',DishRate = '" + Rate + "' WHERE DishID ='" + id + "'"))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            GridViewDish.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var id = GridViewDish.DataKeys[e.RowIndex].Values[0];
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM Dish WHERE DishID ='" + id + "'"))
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
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridViewDish.EditIndex)
            {
                //(e.Row.Cells[0].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row ?');";
            }
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewDish.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewDish.EditIndex = -1;
            this.BindGrid();
        }
        protected void btnDishInsert_Click(object sender, EventArgs e)
        {
            string name = txtDishName.Text.ToString();
            string local = txtLocalName.Text.ToString();
            string rate = txtDishRate.Text.ToString();
            string Restaurant = DropDownListRestaurant.Text.ToString();
            var id = GridViewDish.DataKeys;

            // ResID, ResName, ResAddress, ResPhone, ResEmail
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (OracleConnection con = new OracleConnection(constr))
            {
                //using (OracleCommand cmd = new OracleCommand("INSERT INTO Restaurant(RestID, RestName, Address, Phone, Email) VALUES ('"+ id +"', '"+ name +"', '"+ address +"', '"+ phone +"', '"+ email +"')"))
                using (OracleCommand cmd = new OracleCommand("INSERT INTO Dish(DishName,LocalName,DishRate) VALUES ( '" + name + "',  '" + local + "', '" + rate + "')"))
                {
                  
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    txtDishName.Text = null;
                    txtLocalName.Text = null;
                    txtDishRate.Text = null;
                    DropDownListRestaurant.Text = null;

                }

                var ids = "DSK017";
                string restaurant = DropDownListRestaurant.SelectedItem.Value.ToString();
                using (OracleCommand cmd = new OracleCommand("INSERT INTO DishRestaurant(RestaurantID,DishID) VALUES ('"+restaurant+"','"+ids+"')"))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    
                    con.Close();


                }
                //"(Select RestaurantID from Restaurant where RestaurantName ='" + "Bota" + "')"
            }
            this.BindGrid();
        }

    }
}