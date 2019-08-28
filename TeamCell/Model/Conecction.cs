using System.Data;
using System.Data.Entity.Core.EntityClient;
namespace Model
{
    public class Conecction
    {
        //private static EntityConnectionStringBuilder EntityStringBuilder;
        //public static string GetConnectionString(string ServerName, string DatabaseName)
        //{
        //    if (EntityStringBuilder == null)
        //    {
        //        //string ConnectionString ="Data Source="+ServerName+";Initial Catalog="+DatabaseName+";User ID=sa;Password=1234;multipleactiveresultsets=True;application name=EntityFramework";
        //        string ConnectionString = "Data Source=" + ServerName + ";Initial Catalog=" + DatabaseName + ";multipleactiveresultsets=True;application name=EntityFramework";
        //        // Initialize the EntityConnectionStringBuilder.
        //        EntityStringBuilder = new EntityConnectionStringBuilder();

        //        //Set the provider name.
        //        EntityStringBuilder.Provider = "System.Data.SqlClient";

        //        // Set the provider-specific connection string.
        //        EntityStringBuilder.ProviderConnectionString = ConnectionString;

        //        // Set the Metadata location.
        //        EntityStringBuilder.Metadata = "res://*/";
        //    }
        //    //return the string now
        //    return EntityStringBuilder.ToString();
        //}
    }
}
