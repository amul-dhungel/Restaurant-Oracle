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
    public partial class OrderActivity : System.Web.UI.Page
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
			cmd.CommandText = @"select count(ord.ordernumber) as numoforders,rs.restaurantname
								 from customer cs join orders ord
								on cs.customerid = ord.customerid join dishorder do
								on do.ordernumber = ord.ordernumber join restaurant rs on
								rs.restaurantid = do.restaurantid
								group by rs.restaurantname order by numoforders desc";

			cmd.CommandType = CommandType.Text;

			DataTable dt = new DataTable();

			using (OracleDataReader sdr = cmd.ExecuteReader())
			{
				dt.Load(sdr);
			}

			con.Close();

			GridViewOrderActivity.DataSource = dt;
			GridViewOrderActivity.DataBind();
		}

        protected void buttonSearch_Click(object sender, EventArgs e)
        {
			string CustID = DropDownListOrderActivity.SelectedValue.ToString();
			string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			OracleCommand cmd = new OracleCommand();
			OracleConnection con = new OracleConnection(constr);
			con.Open();
			cmd.Connection = con;
			cmd.CommandText = @"select count(ord.ordernumber) as numoforders,rs.restaurantname
								 from customer cs join orders ord
								on cs.customerid = ord.customerid join dishorder do
								on do.ordernumber = ord.ordernumber join restaurant rs on
								rs.restaurantid = do.restaurantid where cs.customerid = '" + CustID + "'" +
								"group by rs.restaurantname order by numoforders desc";
								
			

			cmd.CommandType = CommandType.Text;

			DataTable dt = new DataTable();

			using (OracleDataReader sdr = cmd.ExecuteReader())
			{
				dt.Load(sdr);
			}

			con.Close();

			GridViewOrderActivity.DataSource = dt;
			GridViewOrderActivity.DataBind();
		}
    }
}