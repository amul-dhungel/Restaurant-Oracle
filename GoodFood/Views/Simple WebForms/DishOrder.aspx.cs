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
    public partial class DishOrder : System.Web.UI.Page
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
            cmd.CommandText = @"SELECT ds.DishOrderID,cs.customername,ds.OrderUnit,ds.LineTotal,dsk.dishname,rs.restaurantname FROM DishOrder ds join
                               restaurant rs on ds.restaurantid=rs.restaurantid join orders ors on ds.ordernumber = ors.ordernumber
                                join customer cs on ors.customerid = cs.customerid join dish dsk on ors.dishid = dsk.dishid";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("DishOrder");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();

            GridViewDishOrder.DataSource = dt;
            GridViewDishOrder.DataBind();
        }

        //updating and deleting
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewDishOrder.Rows[e.RowIndex];
            var id = GridViewDishOrder.DataKeys[e.RowIndex].Values[0];
            string Name = (row.Cells[3].Controls[0] as TextBox).Text;
            string PhoneNumber = (row.Cells[4].Controls[0] as TextBox).Text;
            

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (OracleConnection con = new OracleConnection(constr))
            {

                using (OracleCommand cmd = new OracleCommand("UPDATE DishOrder SET OrderUnit ='" + Name + "',  LineTotal ='" + PhoneNumber + "'"))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            GridViewDishOrder.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var id = GridViewDishOrder.DataKeys[e.RowIndex].Values[0];
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM DishOrder WHERE DishOrderID ='" + id + "'"))
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
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridViewDishOrder.EditIndex)
            {
                //(e.Row.Cells[0].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row ?');";
            }
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewDishOrder.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewDishOrder.EditIndex = -1;
            this.BindGrid();
        }
    }
}