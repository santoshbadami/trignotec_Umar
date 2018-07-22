using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for CustomerClass
/// </summary>
public class CustomerClass
{
    public string custId { get; set; }
    public string custName { get; set; }
    public string address { get; set; }
    public string phone { get; set; }
    public string mobile { get; set; }
    public string emailId { get; set; }
    public string vatNo { get; set; }
    public string typ { get; set; }
    public string query { get; set; }
    public int count { get; set; }

    public string errMsg = string.Empty;
    DataAccessLayer dalObj = null; // DAL - Data Access Layer instance

    public CustomerClass()
    {
        dalObj = new DataAccessLayer();
    }

    //saveCustomerMaster
    public bool SaveCustomerMaster()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "saveCustomerMaster";
            cmd.Parameters.AddWithValue("_custName", custName);
            cmd.Parameters.AddWithValue("_address", address);
            cmd.Parameters.AddWithValue("_phone", phone);
            cmd.Parameters.AddWithValue("_mobile", mobile);
            cmd.Parameters.AddWithValue("_emailId", emailId);
            cmd.Parameters.AddWithValue("_vatNo", vatNo);
            cmd.Parameters.AddWithValue("_type", typ);
            return dalObj.getExecuteData(cmd, out errMsg);
        }
    }

    //getCustomerMasterByCustId
    public DataTable GetCustomerMasterByCustId()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "getCustomerMasterByCustId";
            cmd.Parameters.AddWithValue("_custId", custId);
            return dalObj.getSelectData(cmd, out errMsg);
        }
    }

    //updateCustomerMaster
    public bool UpdateCustomerMaster()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "updateCustomerMaster";
            cmd.Parameters.AddWithValue("_custId", custId);
            cmd.Parameters.AddWithValue("_custName", custName);
            cmd.Parameters.AddWithValue("_address", address);
            cmd.Parameters.AddWithValue("_phone", phone);
            cmd.Parameters.AddWithValue("_mobile", mobile);
            cmd.Parameters.AddWithValue("_emailId", emailId);
            cmd.Parameters.AddWithValue("_vatNo", vatNo);
            return dalObj.getExecuteData(cmd, out errMsg);
        }
    }

    //deleteCustomerMasterByCustId
    public bool DeleteCustomerMasterByCustId()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "deleteCustomerMasterByCustId";
            cmd.Parameters.AddWithValue("_custId", custId);
            return dalObj.getExecuteData(cmd, out errMsg);
        }
    }

    //Customer Add By Excel
    public int SaveCustomerByExcel(DataTable dtExcel)
    {
        query = "INSERT INTO customermaster (custName,address,phone,mobile,emailId,vatNo,type,dateCreated,dateModified) VALUES\n";
        for (int i = 0; i < dtExcel.Rows.Count; i++)
        {
            query = query + string.Format(@"('{0}','{1}','{2}','{3}','{4}','{5}','Excel',NOW(),NOW()),",
                                        dtExcel.Rows[i]["Company Name"].ToString().Trim(), dtExcel.Rows[i]["Address"].ToString().Trim(),
                                        dtExcel.Rows[i]["Mobile"].ToString().Trim(), dtExcel.Rows[i]["Phone No"].ToString().Trim(),
                                        dtExcel.Rows[i]["Email ID"].ToString().Trim(), dtExcel.Rows[i]["Vat No"].ToString().Trim());
        }
        query = query.TrimEnd(',');
        count = dalObj.SQLQueryInsert(query, out errMsg);
        if (count > 0)
            return count;
        else
            return 0;
    }
}