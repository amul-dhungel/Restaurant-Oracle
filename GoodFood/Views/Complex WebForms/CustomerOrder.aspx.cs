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
    public partial class CustomerOrder : System.Web.UI.Page
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
			cmd.CommandText = @"select cs.customername as CustomerName,cs.phoneNumber,cs.customeremail,
							ol.ordernumber,ol.deliveryPoint from Customer cs join Orders ol ON cs.CustomerID = ol.CustomerID";

			cmd.CommandType = CommandType.Text;

			DataTable dt = new DataTable();

			using (OracleDataReader sdr = cmd.ExecuteReader())
			{
				dt.Load(sdr);
			}

			con.Close();

			GridViewCustomerOrder.DataSource = dt;
			GridViewCustomerOrder.DataBind();
		}

	

        protected void buttonSearch_Click1(object sender, EventArgs e)
        {
			string CustID = DropDownListCustomer.SelectedValue.ToString();
			string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			OracleCommand cmd = new OracleCommand();
			OracleConnection con = new OracleConnection(constr);
			con.Open();
			cmd.Connection = con;
			cmd.CommandText = @"select cs.customername as CustomerName,cs.phoneNumber,cs.customeremail,ol.ordernumber,
									ol.deliveryPoint from Customer cs join Orders ol ON cs.CustomerID = ol.CustomerID
								WHERE cs.CustomerID = '" + CustID + "'";

			cmd.CommandType = CommandType.Text;

			DataTable dt = new DataTable();

			using (OracleDataReader sdr = cmd.ExecuteReader())
			{
				dt.Load(sdr);
			}

			con.Close();

			GridViewCustomerOrder.DataSource = dt;
			GridViewCustomerOrder.DataBind();
		}
    }
}