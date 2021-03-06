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
			cmd.CommandText = @"select cs.customername as CustomerName,cs.customeremail,ol.orderamount,ol.orderdate,ds.dishname,ds.dishrate,do.orderunit,do.linetotal,ol.deliveryPoint
							from Customer cs join Orders ol ON
							cs.CustomerID = ol.CustomerID join DishOrder do
							on ol.ordernumber = do.ordernumber join Dish ds on ol.dishid=ds.dishid";

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
			cmd.CommandText = @"select cs.customername as CustomerName,cs.customeremail,ol.orderamount,ol.orderdate,ds.dishname,ds.dishrate,do.orderunit,do.linetotal,ol.deliveryPoint
								from Customer cs join Orders ol ON cs.CustomerID = ol.CustomerID join DishOrder do on ol.ordernumber = do.ordernumber join Dish ds on ol.dishid=ds.dishid
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