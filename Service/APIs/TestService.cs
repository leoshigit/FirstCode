using Dapper;
using DataAccess;
using Microsoft.Extensions.Configuration;
using Service.Interfaces;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Service.APIs
{
    public class TestService : ITestService
    {
        //private string connectionStr;

        //public TestService(IConfiguration configuration)
        //{
        //    this.connectionStr = configuration.GetConnectionString("dbName");
        //}

        private IGenericRepository _genericRepository;
        public TestService(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public List<TestViewModel> GetData()
        {
            //using (SqlConnection conn = new SqlConnection(connectionStr))
            //{
            //    string sql = "select Id, Name from TempTable";
            //    var result = conn.Query<TestViewModel>(sql).ToList();
            //    return result;
            //}

            string sql = "select Id, Name from TempTable";
            var result = _genericRepository.GetAll<TestViewModel>(sql);
            return result;
        }

        public TestViewModel GetTestVM()
        {
            //using (SqlConnection conn = new SqlConnection(connectionStr))
            //{
            //    string sql = "select Id, Name from TempTable";
            //    var result = conn.Query<TestViewModel>(sql).FirstOrDefault();
            //    return result;
            //}

            string sql = "select Id, Name from TempTable";
            var result = _genericRepository.Get<TestViewModel>(sql);
            return result;
        }

        public int Create(TestEditViewModel model)
        {
            //using (SqlConnection conn = new SqlConnection(connectionStr))
            //{
            //    string sql = "insert into TempTable (Name) values (@Name)";
            //    conn.Execute(sql, new { Name = model.Name });
            //}

            string sql = "insert into TempTable (Name) values (@Name)";
            int id = _genericRepository.Create(sql, model);
            return id;
        }

        public void Update(TestEditViewModel model)
        {
            //using (SqlConnection conn = new SqlConnection(connectionStr))
            //{
            //    string sql = "update TempTable set Name = @Name where Id = @Id";
            //    conn.Execute(sql, new { Id = model.Id, Name = model.Name });
            //}

            string sql = "update TempTable set Name = @Name where Id = @Id";
            _genericRepository.Update(sql, model);
        }

        public void Delete(int id)
        {
            //using (SqlConnection conn = new SqlConnection(connectionStr))
            //{
            //    string sql = "delete TempTable where Id = @Id";
            //    conn.Execute(sql, new { Id = id });
            //}

            string sql = "delete TempTable where Id = @Id";
            _genericRepository.Delete(sql, new { Id = id });
        }
    }
}
