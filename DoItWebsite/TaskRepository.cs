using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoItWebsite.Models;
using MySql.Data.MySqlClient;

namespace DoItWebsite
{
    public class TaskRepository
    {
        public List<TaskModel> GetAllTasks()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = System.IO.File.ReadAllText("ConnectionString.txt");

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT TaskID, TaskName, CompletionID FROM tasks;";

            using (conn)
            {
                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                List<TaskModel> tasks = new List<TaskModel>();

                while (reader.Read())
                {
                    TaskModel NextTask = new TaskModel();

                    NextTask.Id = reader.GetInt32("TaskID");
                    NextTask.TaskName = reader.GetString("TaskName");
                    NextTask.CompletionID = reader.GetInt32("CompletionID");


                    tasks.Add(NextTask);
                }

                return tasks;
            }
        }
    }
}
