using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

/// <summary>
/// Summary description for ProductClass
/// </summary>
public class ProductClass
{
    public string prodId { get; set; }
    public string description { get; set; }
    public string unitPrice { get; set; }
    public string typ { get; set; }
    public string query { get; set; }
    public int count { get; set; }

    public string errMsg = string.Empty;
    DataAccessLayer dalObj = null; // DAL - Data Access Layer instance

    public ProductClass()
    {
        dalObj = new DataAccessLayer();
    }

    //saveProductMaster
    public bool SaveProductMaster()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "saveProductMaster";
            cmd.Parameters.AddWithValue("_description", description);
            cmd.Parameters.AddWithValue("_unitPrice", unitPrice);
            cmd.Parameters.AddWithValue("_type", typ);
            return dalObj.getExecuteData(cmd, out errMsg);
        }
    }

    //getProductMasterByProdId
    public DataTable GetProductMasterByProdId()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "getProductMasterByProdId";
            cmd.Parameters.AddWithValue("_prodId", prodId);
            return dalObj.getSelectData(cmd, out errMsg);
        }
    }

    //updateProductMaster
    public bool UpdateProductMaster()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "updateProductMaster";
            cmd.Parameters.AddWithValue("_prodId", prodId);
            cmd.Parameters.AddWithValue("_description", description);
            cmd.Parameters.AddWithValue("_unitPrice", unitPrice);
            cmd.Parameters.AddWithValue("_type", typ);
            return dalObj.getExecuteData(cmd, out errMsg);
        }
    }

    //deleteProductMasterByProdId
    public bool DeleteProductMasterByProdId()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "deleteProductMasterByProdId";
            cmd.Parameters.AddWithValue("_prodId", prodId);
            return dalObj.getExecuteData(cmd, out errMsg);
        }
    }

    //Product Add By Excel
    public int SaveProductByExcel(DataTable dtExcel)
    {
        query = "INSERT INTO productmaster (description,unitPrice,type,dateCreated,dateModified) VALUES\n";
        for (int i = 0; i < dtExcel.Rows.Count; i++)
        {
            query = query + string.Format(@"('{0}','{1}','Excel',NOW(),NOW()),",
                                        dtExcel.Rows[i]["Description"].ToString().Trim(), dtExcel.Rows[i]["Unit Price"].ToString().Trim());
        }
        query = query.TrimEnd(',');
        count = dalObj.SQLQueryInsert(query, out errMsg);
        if (count > 0)
            return count;
        else
            return 0;
    }

    //saveProductWhileAddingQuoAndIn
    public string SaveProductWhileAddingQuoAndIn()
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.CommandText = "saveProductWhileAddingQuoAndIn";
            cmd.Parameters.AddWithValue("_description", description);
            cmd.Parameters.AddWithValue("_unitPrice", unitPrice);
            cmd.Parameters.AddWithValue("_type", typ);
            return dalObj.getSelectData(cmd, out errMsg).Rows[0][0].ToString();
        }
    }
}