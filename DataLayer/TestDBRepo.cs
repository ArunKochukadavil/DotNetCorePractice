using Common;
using DataLayer.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TestDBRepo
    {
        SqlConnection connection;
        public TestDBRepo()
        {
            connection = new SqlConnection(SqlServerConfiguration.ConnectionString);
        }

        public List<TestData> GetTestData()
        {
            var testDataList = new List<TestData>();
            connection.Open();
            SqlCommand cmd = new SqlCommand("Select Name from TestDB", connection);
            var data = cmd.ExecuteReader();
            while (data.Read())
            {
                var testData = new TestData();
                testData.Name = data.GetValue(data.GetOrdinal("Name")).ToString();
                testDataList.Add(testData);
            }
            return testDataList;
        } 
    }
}
