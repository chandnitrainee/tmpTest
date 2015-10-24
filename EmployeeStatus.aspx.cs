using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class EmployeeStatus : System.Web.UI.Page
{
    public string storeId;
    wt_Store rStoreInfo = new wt_Store();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["StoreAccountInfo"] != null)
        {
             
     
            rStoreInfo = (wt_Store)Session["StoreAccountInfo"];
            lblCompanyName.Text = rStoreInfo.store_name;
            double timeOffset = TimeoffsetHelper.GetTimeoffsetValueFromTimeZone(rStoreInfo.store_TimeZone);
            string dt = DateTime.UtcNow.AddHours(timeOffset).ToString("dddd,MM/dd/yyyy");
     
            lblHeaderDescription.Text = "Employee Current Satus for "+dt;
        }
        //if (!IsPostBack)
        //{
        //    bindGridView(rStoreInfo);
        //}
        
    }


    //public List<wt_StoreUserCurrentDayStatus> getStoreUesrCurrentDayStatusList(wt_Store rStoreInfo)
    //{
    //    List<wt_StoreUserCurrentDayStatus> wt_StoreUserCurrentDayStatusList = new List<wt_StoreUserCurrentDayStatus>();
    //    double timeOffset = TimeoffsetHelper.GetTimeoffsetValueFromTimeZone(rStoreInfo.store_TimeZone);
    //    string dt = DateTime.UtcNow.AddHours(timeOffset).ToString("MM/dd/yyyy");
    //    string connectionSting = ConfigurationManager.ConnectionStrings["VrindiAttendance"].ConnectionString;
    //    using (SqlConnection con = new SqlConnection(connectionSting))
    //    {
    //        using (SqlCommand cmd = new SqlCommand("Attendance_sp_get_StoreUserCurrentStatus"))
    //        {
    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cmd.Parameters.AddWithValue("@MasterAccountStoreID", rStoreInfo.storeId);
    //            cmd.Parameters.AddWithValue("@date", dt);
    //            cmd.Connection = con;
    //            con.Open();

    //            SqlDataReader idr = cmd.ExecuteReader();
    //            while (idr.Read())
    //            {
    //                wt_StoreUserCurrentDayStatus wt_StoreUserCurrentDayStatus = new wt_StoreUserCurrentDayStatus();
    //                if (idr["EmployeeName"] != DBNull.Value)
    //                {
    //                    wt_StoreUserCurrentDayStatus.employeeName = Convert.ToString(idr["EmployeeName"]);
    //                }
    //                //if (idr["CurrentStatus"] != DBNull.Value)
    //                //{
    //                //    wt_StoreUserCurrentDayStatus.currentStatus = Convert.ToString(idr["CurrentStatus"]);
    //                //}
    //                //if (idr["EntryDescription"] != DBNull.Value)
    //                //{
    //                //    wt_StoreUserCurrentDayStatus.EntryDescription = Convert.ToString(idr["EntryDescription"]);
    //                //}
    //                //if (idr["EntryDateTime"] != DBNull.Value)
    //                //{
    //                //    wt_StoreUserCurrentDayStatus.EntryDatetime = Convert.ToDateTime(idr["EntryDateTime"]);
    //                //}
    //                if (idr["totalHoursWork"] == DBNull.Value)
    //                {
    //                    wt_StoreUserCurrentDayStatus.totalWorkHours ="0";
    //                }
    //                else
    //                {
    //                    int minutes = 0, hours = 0, tot=0;
    //                    tot = Convert.ToInt16(idr["totalHoursWork"]);
    //                    minutes = tot % 60;
    //                    hours = tot / 60;
    //                    wt_StoreUserCurrentDayStatus.totalWorkHours =String.Format("{0}:{1}",hours,minutes);

    //                }
    //                if (idr["totalBreakHours"] == DBNull.Value)
    //                {
    //                    wt_StoreUserCurrentDayStatus.totalBreakHours = "0";
    //                }
    //                else
    //                {
    //                     int minutes = 0, hours = 0, tot = 0;
    //                     tot = Convert.ToInt16(idr["totalBreakHours"]);
    //                     minutes = tot % 60;
    //                     hours = tot / 60;
    //                     wt_StoreUserCurrentDayStatus.totalBreakHours = String.Format("{0}:{1}", hours, minutes);

                     
    //                }
    //                wt_StoreUserCurrentDayStatusList.Add(wt_StoreUserCurrentDayStatus);
    //            }
    //            con.Close();
    //        }
    //    }
    //    return wt_StoreUserCurrentDayStatusList;
    //}

    //public void bindGridView(wt_Store rStoreInfo)
    //{
    //    List<wt_StoreUserCurrentDayStatus> userCurrentDayStatusList = getStoreUesrCurrentDayStatusList(rStoreInfo);
    //    employeeStatusGrid.DataSource = userCurrentDayStatusList;
    //    //employeeStatusGrid.DataBind();
    //    employeeStatusGrid.Rebind();
    //}
    protected void employeeStatusGrid_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        List<wt_StoreUserCurrentDayStatus> wt_StoreUserCurrentDayStatusList = new List<wt_StoreUserCurrentDayStatus>();
        double timeOffset = TimeoffsetHelper.GetTimeoffsetValueFromTimeZone(rStoreInfo.store_TimeZone);
        string dt = DateTime.UtcNow.AddHours(timeOffset).ToString("MM/dd/yyyy");
        string connectionSting = ConfigurationManager.ConnectionStrings["VrindiAttendance"].ConnectionString;
        using (SqlConnection con = new SqlConnection(connectionSting))
        {
            using (SqlCommand cmd = new SqlCommand("Attendance_sp_get_StoreUserCurrentStatus"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MasterAccountStoreID", rStoreInfo.storeId);
                cmd.Parameters.AddWithValue("@date", dt);
                cmd.Connection = con;
                con.Open();

                SqlDataReader idr = cmd.ExecuteReader();
                while (idr.Read())
                {
                    wt_StoreUserCurrentDayStatus wt_StoreUserCurrentDayStatus = new wt_StoreUserCurrentDayStatus();
                    if (idr["EmployeeName"] != DBNull.Value)
                    {
                        wt_StoreUserCurrentDayStatus.employeeName = Convert.ToString(idr["EmployeeName"]);
                    }
                    //if (idr["LastEntry"] != DBNull.Value)
                    //{
                    //    wt_StoreUserCurrentDayStatus.EntryDescription = Convert.ToString(idr["LastEntry"]);
                    //}
                    //else
                    //{
                    //    wt_StoreUserCurrentDayStatus.EntryDescription = "No Entry Done";
                    //}
                    if (idr["totalHoursWork"] == DBNull.Value)
                    {
                        wt_StoreUserCurrentDayStatus.totalWorkHours = "0";
                    }
                    else
                    {
                        int minutes = 0, hours = 0, tot = 0;
                        tot = Convert.ToInt16(idr["totalHoursWork"]);
                        minutes = tot % 60;
                        hours = tot / 60;
                        wt_StoreUserCurrentDayStatus.totalWorkHours = String.Format("{0}:{1}", hours, minutes);

                    }
                    if (idr["totalBreakHours"] == DBNull.Value)
                    {
                        wt_StoreUserCurrentDayStatus.totalBreakHours = "0";
                    }
                    else
                    {
                        int minutes = 0, hours = 0, tot = 0;
                        tot = Convert.ToInt16(idr["totalBreakHours"]);
                        minutes = tot % 60;
                        hours = tot / 60;
                        wt_StoreUserCurrentDayStatus.totalBreakHours = String.Format("{0}:{1}", hours, minutes);


                    }
                    wt_StoreUserCurrentDayStatusList.Add(wt_StoreUserCurrentDayStatus);
                }
                con.Close();
            }
        }
        employeeStatusGrid.DataSource = wt_StoreUserCurrentDayStatusList;
    }


  
    protected void employeeStatusGrid__ItemCommand(object sender, GridCommandEventArgs e)
    {
        
    }
}