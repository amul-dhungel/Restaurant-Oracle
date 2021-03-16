using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CWOracleWebForms.Complex_WebForms
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
			string constr = ConfigurationManager.ConnectionStrings["GoodFoodConnection"].ConnectionString;
			OracleCommand cmd = new OracleCommand();
			OracleConnection con = new OracleConnection(constr);
			con.Open();
			cmd.Connection = con;
			cmd.CommandText = @"SELECT fd.name AS FoodName, rst.restname FROM Food fd
								join availability avb ON avb.foodID = fd.FoodID
								join restaurant rst ON rst.restid = avb.resid
								WHERE avb.availability = 'True'";

			cmd.CommandType = CommandType.Text;

			DataTable dt = new DataTable();

			using (OracleDataReader sdr = cmd.ExecuteReader())
			{
				dt.Load(sdr);
			}

			con.Close();

			GridView1.DataSource = dt;
			GridView1.DataBind();
		}

        protected void buttonSearch_Click(object sender, EventArgs e)
        {
			string FoodID = DishList.SelectedValue.ToString();
			string constr = ConfigurationManager.ConnectionStrings["GoodFoodConnection"].ConnectionString;
			OracleCommand cmd = new OracleCommand();
			OracleConnection con = new OracleConnection(constr);
			con.Open();
			cmd.Connection = con;
			cmd.CommandText = @"SELECT fd.name AS FoodName, rst.restname FROM Food fd
								join availability avb ON avb.foodID = fd.FoodID
								join restaurant rst ON rst.restid = avb.resid
								WHERE avb.availability = 'True' AND
								cs.CustID = " + FoodID + " ";

			cmd.CommandType = CommandType.Text;

			DataTable dt = new DataTable();

			using (OracleDataReader sdr = cmd.ExecuteReader())
			{
				dt.Load(sdr);
			}

			con.Close();

			GridView1.DataSource = dt;
			GridView1.DataBind();
		}
    }
}