using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSQL.Models;
using System.Configuration;

namespace MiniSQL
{
    internal class DataAccess
    {
        internal static List<UserModel> LoadUser()
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UserModel>($"SELECT * FROM san_person", new DynamicParameters());
                return output.ToList();
            }
        }

        internal static List<ProjectModel> LoadProject()
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ProjectModel>("SELECT * FROM san_project", new DynamicParameters());
                return output.ToList();
            }
        }
        internal static List<ProjectPerson> LoadProjectandPerson()
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ProjectPerson>($"SELECT * FROM san_project_person", new DynamicParameters());
                return output.ToList();
            }
        }

        public static int GetUserIdByName(string name)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault<int>($"SELECT id FROM san_person WHERE person_name='{name}'", new DynamicParameters());
                return output;
            }
        }
        public static int GetProjectIdByName(string name)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault<int>($"SELECT id FROM san_project WHERE project_name='{name}'", new DynamicParameters());
                return output;
            }
        }

        public static void CreateNewUser(string person_name)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute($@"INSERT INTO san_person (person_name) VALUES('{person_name}')", new DynamicParameters());
            }
        }
        public static void UpdateNewUser(int old_name, string new_name)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute($@"UPDATE san_person SET person_name ='{new_name}' WHERE id ={old_name}", new DynamicParameters());
            }
        }
        public static void CreateNewProject(string project_name)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute($@"INSERT INTO san_project (project_name) VALUES('{project_name}')", new DynamicParameters());
            }
        }

        public static void UpdateNewProject(int old_name, string new_name)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute($@"UPDATE san_project SET project_name ='{new_name}' WHERE id ={old_name}", new DynamicParameters());
            }
        }

        public static void TimeReport(int projectId, int personId, int hoursWorked)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute($@"INSERT INTO san_project_person (project_id,person_id,hours) VALUES({projectId},{personId},{hoursWorked})", new DynamicParameters());

            }
        }

        public static void UpdateProjectPerson(int day, int hours)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Query($"UPDATE san_project_person SET hours='{hours}' WHERE id='{day}'", new DynamicParameters());
            }
        }
        private static string LoadConnectionString(string id = "Default")
        {
            using (IDbConnection cnn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings[id].ConnectionString))
            {

                return ConfigurationManager.ConnectionStrings[id].ConnectionString;
            };

        }
    }
}
