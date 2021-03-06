﻿using System;
using System.Data;
using System.Text;
using System.Web.Services;

public partial class ShowMap : System.Web.UI.Page
{
    public static DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    public static string GetData(string xmlUrl)
    {
        ds = new DataSet();
        ds.ReadXml(xmlUrl);
        char[] labels = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'R', 'S', 'T', 'U', 'V', 'W', 'Y', 'Z' };
        StringBuilder sb = new StringBuilder();
        int i = 0;
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            sb.Append("<a onclick=\"ShowPoint('" + i + "')\" class='list-group-item' style='cursor:pointer;'>");
            sb.Append("<span class='badge'>" + labels[i % labels.Length] + "</span>");
            sb.Append("<h4 class='list-group-item-heading'>" + row["dc_Name"] + "</h4>");
            sb.Append("<p class='list-group-item-text'>Latitude:" + row["dc_Latitude"] + "<br/>Longitude:" + row["dc_Longitude"] + "</p>");
            sb.Append("</a>");
            i++;
        }
        return sb.ToString();
    }
    [WebMethod]
    public static string[] GetMarker(string xmlUrl)
    {
        ds = new DataSet();
        ds.ReadXml(xmlUrl);
        string[] data = new string[ds.Tables[0].Rows.Count];
        int i = 0;
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            data[i] = row["dc_Latitude"].ToString() + "," + row["dc_Longitude"].ToString() + "," + row["dc_Name"] + "," + row["ID"];
            i++;
        }
        return data;
    }
}