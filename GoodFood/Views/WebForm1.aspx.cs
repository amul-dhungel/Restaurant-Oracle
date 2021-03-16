﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoodFood.BLL;

namespace GoodFood
{
    public partial class _LoyaltyPoints : Page
    {
        BLL_LoyaltyPoints objLoyalty = new BLL_LoyaltyPoints();
        BLL_DishRestaurant objDishREs = new BLL_DishRestaurant();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();
                BindDishRes();
            }
        }

        public void BindDishRes()
        {

            DataTable dt = objDishREs.Select(null);
            dt.Columns.Add("dishRes", typeof(string));
            foreach (DataRow dr in dt.Rows)
            {
                dr["dishRes"] = dr["dishName"] + ", " + dr["restaurantName"];
            }
            ddlDishRes.DataSource = dt;
            ddlDishRes.DataValueField = "dishrestaurantId";
            ddlDishRes.DataTextField = "dishRes";
            ddlDishRes.DataBind();

            ddlDishRes.Items.Insert(0, new ListItem { Text = "--Select--", Value = "0" });

        }
        public void BindGrid()
        {
            //Select
            DataTable dt = objLoyalty.Select(null);
            if (dt.Rows.Count > 0)
            {
                gv.DataSource = dt;
                gv.DataBind();
                // gv.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                DataRow dr = dt.NewRow();
                dr["dishId"] = 1;
                dr["restaurantId"] = "Test";
                dr["loyaltyPointId"] = 1;
                dr["loyaltyPointsAmount"] = 1;
                dr["dishName"] = "Test";
                dr["restaurantName"] = "Test";

                dt.Rows.Add(dr);
                gv.DataSource = dt;
                gv.DataBind();
                int columnCount = gv.Rows[0].Cells.Count;
                gv.Rows[0].Cells.Clear();
                gv.Rows[0].Cells.Add(new TableCell());
                gv.Rows[0].Cells[0].ColumnSpan = columnCount;
                gv.Rows[0].Cells[0].Text = "No Records Found.";
            }

        }

        protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                objLoyalty.LoyaltyPointId = gv.DataKeys[e.RowIndex].Values["loyaltyPointId"].ToString();
                string result = objLoyalty.Delete();
                // = objCustomer.iud_fy();
                if (result == "success")
                {
                    Lbl_Msg.Text = "success";
                    Lbl_Msg.CssClass = "alert-success";
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                Lbl_Msg.Text = ex.Message;
                Lbl_Msg.CssClass = "alert-danger";
            }
        }
        protected void gv_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            objLoyalty.LoyaltyPointId = gv.DataKeys[e.RowIndex].Values["loyaltyPointId"].ToString();
            DataTable dt = objLoyalty.Select(objLoyalty.LoyaltyPointId);

            if (dt.Rows.Count > 0)
            {
                lbl_Variable.Value = gv.DataKeys[e.RowIndex].Values["loyaltyPointId"].ToString();
                // lbl_DishRes.Value = dt.Rows[0]["dishRestaurantId"].ToString();
                txtPoint.Text = dt.Rows[0]["loyaltypointsAmount"].ToString();
                ddlDishRes.SelectedValue = dt.Rows[0]["dishREstaurantId"].ToString();
                //ddlDishRes.
                btnSubmit.Text = "Update";


            }
            //txtId
            //DataTable dt = objCustomer.select_fy();
            //if (dt.Rows.Count > 0)
            //{
            //    multiview1.ActiveViewIndex = 0;
            //    DataRow dr = dt.Rows[0];
            //    txtFYEng.Text = dr["fyEnglish"].ToString();
            //    txtFYNep.Text = dr["fyNep"].ToString();
            //    txtDetail.Text = dr["res1"].ToString();
            //    btnSave.Text = "Update";
            //    btnCancel.Text = "Cancel";
            //}
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text == "Insert")
            {
                objLoyalty.LoyaltyPointId = Guid.NewGuid().ToString();
                objLoyalty.LoyaltyPointsAmount = Convert.ToDecimal(txtPoint.Text);
                objLoyalty.DishRestaurantId = ddlDishRes.SelectedValue.ToString();

                string result = objLoyalty.Insert();
                if (result == "success")
                {
                    Lbl_Msg.Text = "success";
                    Lbl_Msg.CssClass = "alert-success";
                    BindGrid();
                }
                else
                {
                    Lbl_Msg.Text = "Error";
                    Lbl_Msg.CssClass = "alert-dangeer";
                    BindGrid();
                }
            }
            else if (btnSubmit.Text == "Update")
            {

                objLoyalty.LoyaltyPointId = lbl_Variable.Value;
                objLoyalty.LoyaltyPointsAmount = Convert.ToDecimal(txtPoint.Text);
                objLoyalty.DishRestaurantId = ddlDishRes.SelectedValue;
                string result = objLoyalty.Update();
                if (result == "success")
                {
                    Lbl_Msg.Text = "success";
                    Lbl_Msg.CssClass = "alert-success";
                    BindGrid();
                    BindDishRes();
                }
                else
                {
                    Lbl_Msg.Text = "Error";
                    Lbl_Msg.CssClass = "alert-dangeer";
                    BindGrid();
                }

            }

        }


    }
}


using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace GoodFood.BLL
{
    public class BLL_LoyaltyPoints
    {
        public string LoyaltyPointId { get; set; }
        public decimal LoyaltyPointsAmount { get; set; }
        public string DishRestaurantId { get; set; }
        public DataTable Select(string id)
        {
            //u
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            if (id == null)
            {
                cmd.CommandText = @" select  L.*,d.dishName, r.restaurantName,d.DishId, r.restaurantId from loyaltyPoints L
                                   left join dishRestaurant dr on L.dishRestaurantId = dr.DishRestaurantId 
                                     inner  join Dish d on dr.dishId = d.dishId 
                                     inner  join restaurant r on dr.restaurantId = r.restaurantId";


                //"SELECT L.*,D.dishName, D.LocalName, R.restaurantName,D.DishId, R.restaurantId  FROM LoyaltyPoints L , DishRestaurant Dr, Dish D, Restaurant R " +
                //               "where L.DishRestaurantId=Dr.DishRestaurantId and Dr.DishId=D.DishId and" +
                //               " Dr.RestaurantId=R.RestaurantId";

            }
            else
            {
                cmd.CommandText = @" select  L.*,d.dishName, r.restaurantName,d.DishId, r.restaurantId from loyaltyPoints L
                                   left join dishRestaurant dr on L.dishRestaurantId = dr.DishRestaurantId 
                                     inner  join Dish d on dr.dishId = d.dishId 
                                     inner  join restaurant r on dr.restaurantId = r.restaurantId where loyaltypointId='" + id.ToString() + "'";

            }
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("loyaltyPoints");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }
            con.Close();

            return dt;
            // return null;
        }
        public string Insert()
        {
            //uqery           
            try
            {

                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (OracleConnection con = new OracleConnection(constr))
                {
                    using (OracleCommand cmd = new OracleCommand("Insert into loyaltypoints(loyaltyPointId,loyaltypointsAmount, DishRestaurantId)Values('" + Guid.NewGuid() + "','" + this.LoyaltyPointsAmount + "','" + this.DishRestaurantId + "')"))
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                return "success";
            }
            catch (Exception ex)
            {
                return "Error";
            }

            // this.BindGrid();
            //  return null;


        }
        public string Update()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (OracleConnection con = new OracleConnection(constr))
                {
                    using (OracleCommand cmd = new OracleCommand(@"update loyaltyPoints set
                                                    loyaltyPointsAmount = '" + this.LoyaltyPointsAmount +
                                                        "',dishRestaurantId = '" + this.DishRestaurantId +
                                                        "' where loyaltypointId = '" + this.LoyaltyPointId + "'"))
                    {

                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                // GridView1.EditIndex = -1;
                //            this.BindGrid();
                return "success";
            }
            catch (Exception ex)
            {
                return "error";
            }

        }
        public string Delete()
        {
            //uqery
            // int ID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (OracleConnection con = new OracleConnection(constr))
                {

                    using (OracleCommand cmd = new OracleCommand("DELETE FROM loyaltypoints WHERE loyaltypointId ='" + this.LoyaltyPointId + "'"))
                    {

                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                return "success";
            }
            catch (Exception ex)
            {
                return "error";
            }

            //            this.BindGrid();
            // return null;

        }

    }
}




//using Oracle.ManagedDataAccess.Client;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//namespace LMS1
//{
//    public partial class Author : System.Web.UI.Page
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            // data load k garaune
//            if (!this.IsPostBack)
//            {
//                this.BindGrid();
//            }

//        }

//        protected void Button1_Click(object sender, EventArgs e)
//        {
//            // insert Code
//            string name = txtauthor.Text.ToString();
//            string gender = txtgender.Text.ToString();
//            string qualification = txtqualification.Text.ToString();

//            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
//            using (OracleConnection con = new OracleConnection(constr))
//            {
//                using (OracleCommand cmd = new OracleCommand("Insert into author(ID, Name, Gender, Qualification)Values(101,'" + name + "','" + gender + "','" + qualification + "')"))
//                {
//                    cmd.Connection = con;
//                    con.Open();
//                    cmd.ExecuteNonQuery();
//                    con.Close();
//                    txtauthor.Text = "";
//                    txtgender.Text = "";
//                    txtqualification.Text = "";
//                }
//            }


//            this.BindGrid();
//        }

//        private void BindGrid()
//        {
//            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
//            OracleCommand cmd = new OracleCommand();
//            OracleConnection con = new OracleConnection(constr);
//            con.Open();
//            cmd.Connection = con;
//            cmd.CommandText = "SELECT ID, Name, Gender, Qualification FROM Author";
//            cmd.CommandType = CommandType.Text;

//            DataTable dt = new DataTable("author");

//            using (OracleDataReader sdr = cmd.ExecuteReader())
//            {
//                dt.Load(sdr);
//            }
//            con.Close();

//            GridView1.DataSource = dt;
//            GridView1.DataBind();
//        }

//        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
//        {
//            // Update Funcations:
//            GridViewRow row = GridView1.Rows[e.RowIndex];
//            int ID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
//            string Name = (row.Cells[2].Controls[0] as TextBox).Text;
//            string Gender = (row.Cells[3].Controls[0] as TextBox).Text;
//            string Qualification = (row.Cells[4].Controls[0] as TextBox).Text;

//            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
//            using (OracleConnection con = new OracleConnection(constr))
//            {
//                using (OracleCommand cmd = new OracleCommand("update author set Name = '" + Name + "',Gender = '" + Gender + "',Qualification = '" + Qualification + "' where ID = " + ID))
//                {

//                    cmd.Connection = con;
//                    con.Open();
//                    cmd.ExecuteNonQuery();
//                    con.Close();
//                }
//            }

//            GridView1.EditIndex = -1;
//            this.BindGrid();

//        }
//        protected void OnRowCancelingEdit(object sender, EventArgs e)
//        {
//            GridView1.EditIndex = -1;
//            this.BindGrid();
//        }
//        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
//        {
//            // Delete Functions:
//            int ID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
//            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
//            using (OracleConnection con = new OracleConnection(constr))
//            {

//                using (OracleCommand cmd = new OracleCommand("DELETE FROM Author WHERE ID =" + ID))
//                {

//                    cmd.Connection = con;
//                    con.Open();
//                    cmd.ExecuteNonQuery();
//                    con.Close();
//                }
//            }

//            this.BindGrid();
//        }
//        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
//        {
//            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
//            {
//                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
//            }

//        }
//        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
//        {
//            GridView1.EditIndex = e.NewEditIndex;
//            this.BindGrid();
//        }
//    }
//}