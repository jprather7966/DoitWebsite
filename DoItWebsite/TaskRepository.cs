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
        public void AddTaskToDatabase(TaskModel NewTask)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = System.IO.File.ReadAllText("ConnectionString.txt");

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO tasks (TaskName) " +
                              "VALUES (@TaskName);";
            // parameterized query to prevent SQL injection
            cmd.Parameters.AddWithValue("TaskName", NewTask.TaskName);
            
            using (conn)
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }

        }
        public TaskModel GetTask(int id)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = System.IO.File.ReadAllText("ConnectionString.txt");

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT TaskID, TaskName, CompletionID " +
                              "FROM tasks " +
                              "WHERE TaskID = @id;";
            // parameterized query to prevent SQL injection
            cmd.Parameters.AddWithValue("id", id);

            using (conn)
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    TaskModel task = new TaskModel();

                    task.Id = reader.GetInt32("TaskID");
                    task.TaskName = reader.GetString("TaskName");
                   
                    return task;
                }
                else
                {
                    return null;
                }

            }
        }
        public void UpdateTask(TaskModel task)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = System.IO.File.ReadAllText("ConnectionString.txt");

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE tasks " +
                              "SET TaskName = @TaskName, CompletionID = @CompletionID  " +
                              "WHERE TaskID = @id;";
            // parameterized query to prevent SQL injection
            cmd.Parameters.AddWithValue("TaskName", task.TaskName);
            cmd.Parameters.AddWithValue("CompletionID", task.CompletionID);
            cmd.Parameters.AddWithValue("id", task.Id);

            using (conn)
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
