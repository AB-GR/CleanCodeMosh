using System;
using System.Web;
using System.Text;

namespace FooFoo
{
	public partial class Download : System.Web.UI.Page
    {
		private readonly DataTableCsvMapper _dataTableCsvMapper = new DataTableCsvMapper();
		private readonly TableReader _reader = new TableReader();

		protected void Page_Load(object sender, EventArgs e)
		{
			ClearResponse();
			SetCache();
			WriteContentToResponse(GetCsv());
		}

		private byte[] GetCsv()
			=> _dataTableCsvMapper.Map(_reader.GetDataTable()).ToArray();

		private void WriteContentToResponse(byte[] byteArray)
		{
			Response.Charset = UTF8Encoding.UTF8.WebName;
			Response.ContentEncoding = UTF8Encoding.UTF8;
			Response.ContentType = "text/comma-separated-values";
			Response.AddHeader("Content-Disposition", "attachment; filename=FooFoo.csv");
			Response.AddHeader("Content-Length", byteArray.Length.ToString());
            Response.BinaryWrite(byteArray);
        }

		private void SetCache()
		{
			Response.Cache.SetCacheability(HttpCacheability.Private);
			Response.CacheControl = "private";
			Response.AppendHeader("Pragma", "cache");
			Response.AppendHeader("Expires", "60");
		}

		private void ClearResponse()
		{
			Response.Clear();
			Response.ClearContent();
			Response.ClearHeaders();
			Response.Cookies.Clear();
		}

    }
}