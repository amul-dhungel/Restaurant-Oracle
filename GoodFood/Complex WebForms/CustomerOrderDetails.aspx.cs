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
    public partial class CustomerOrderDetails : System.Web.UI.Page
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
			cmd.CommandText = @"SELECT cs.name AS CustName, dlvry.CustID, dlvry.latitude, dlvry.longitude 
								FROM Customer cs 
								join Delivery dlvry ON cs.CustID = dlvry.custID";

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
			string CustID = customerDropDown.SelectedValue.ToString();
			string constr = ConfigurationManager.ConnectionStrings["GoodFoodConnection"].ConnectionString;
			OracleCommand cmd = new OracleCommand();
			OracleConnection con = new OracleConnection(constr);
			con.Open();
			cmd.Connection = con;
			cmd.CommandText = @"SELECT cs.name AS CustName, dlvry.CustID, dlvry.latitude, dlvry.longitude 
								FROM Customer cs 
								join Delivery dlvry ON cs.CustID = dlvry.custID
								WHERE cs.CustID = "+ CustID +" ";

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