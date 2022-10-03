using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FooFoo
{
	public class TableReader
	{
		public DataTable GetDataTable()
		{
			var strConn = ConfigurationManager.ConnectionStrings["FooFooConnectionString"].ToString();
			var conn = new SqlConnection(strConn);
			var da = new SqlDataAdapter("SELECT * FROM [FooFoo] ORDER BY id ASC", conn);
			var ds = new DataSet();
			da.Fill(ds, "FooFoo");
			var dt = ds.Tables["FooFoo"];
			return dt;
		}
	}
}
