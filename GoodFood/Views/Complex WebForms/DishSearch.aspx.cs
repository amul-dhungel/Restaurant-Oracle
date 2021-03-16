using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoodFood.Views.Complex_WebForms
{
    public partial class DishSearch : System.Web.UI.Page
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
			cmd.CommandText = @"SELECT ds.dishname AS DishName,ds.localname,ds.dishrate, rs.restaurantname FROM Dish ds
								join dishrestaurant drs ON ds.dishID = drs.dishID join restaurant rs on drs.restaurantid = rs.restaurantid";

			cmd.CommandType = CommandType.Text;

			DataTable dt = new DataTable();

			using (OracleDataReader sdr = cmd.ExecuteReader())
			{
				dt.Load(sdr);
			}

			con.Close();

			GridViewDishes.DataSource = dt;
			GridViewDishes.DataBind();
		}



		protected void buttonSearch_Click1(object sender, EventArgs e)
		{
			string CustID = DropDownListDish.SelectedItem.Value.ToString();
			string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			OracleCommand cmd = new OracleCommand();
			OracleConnection con = new OracleConnection(constr);
			con.Open();
			cmd.Connection = con;
			cmd.CommandText = @"SELECT ds.dishname AS DishName,ds.localname,ds.dishrate, rs.restaurantname FROM Dish ds
								join dishrestaurant drs ON ds.dishID = drs.dishID join restaurant rs
								on drs.restaurantid = rs.restaurantid where ds.dishID = '"+ CustID + "'";

			cmd.CommandType = CommandType.Text;

			DataTable dt = new DataTable();

			using (OracleDataReader sdr = cmd.ExecuteReader())
			{
				dt.Load(sdr);
			}

			con.Close();

			GridViewDishes.DataSource = dt;
			GridViewDishes.DataBind();
		}
	}
}