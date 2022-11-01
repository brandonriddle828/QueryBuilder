using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace QueryBuilder
{
    public class QueryBuilder : IDisposable
    {

        private SqliteConnection connection;

        public QueryBuilder()
        {
         
                connection = new SqliteConnection("Data Source = " + ProjectRoot.Root + Path.DirectorySeparatorChar + "Data" + Path.DirectorySeparatorChar + "SQLite.db");
                connection.Open();

            ;
        }


//-----------------------------------------------------------------------------------------------------------------------------------------



        public void Dispose()
        {
            connection.Dispose();
        }
 //----------------------------------------------------------------------------------------------------------------------------------------



        public List<T> ReadAll<T>() where T : IClassModel, new()
        {
            var command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM {typeof(T).Name}";
            var reader = command.ExecuteReader();
            T data;
            var datas = new List<T>();
            while (reader.Read())
            {
                data = new T();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (typeof(T).GetProperty(reader.GetName(i)).PropertyType == typeof(int))
                        typeof(T).GetProperty(reader.GetName(i)).SetValue(data, Convert.ToInt32(reader.GetValue(i)));
                    else
                        typeof(T).GetProperty(reader.GetName(i)).SetValue(data, reader.GetValue(i));
                }
                datas.Add(data);
            }
            return datas;
        }




//-----------------------------------------------------------------------------------------------------------------------



        public T Read<T> (int Id) where T: IClassModel, new()
        {
            var command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM {typeof(T).Name} WHERE Id = {Id}";
            var reader = command.ExecuteReader();
            var data = new T();
            while (reader.Read())
            {
                data = new T();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (typeof(T).GetProperty(reader.GetName(i)).PropertyType == typeof(int))
                        typeof(T).GetProperty(reader.GetName(i)).SetValue(data, Convert.ToInt32(reader.GetValue(i)));
                    else
                        typeof(T).GetProperty(reader.GetName(i)).SetValue(data, reader.GetValue(i));
                }
            }

            return data;
        }




//--------------------------------------------------------------------------------------------------------------------------------------------------------



        public void Create<T>(T obj)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            List<string> values = new List<string>();
            List<string> names = new List<string>();


            foreach (PropertyInfo property in properties)
            {

                if (property.PropertyType == typeof(string))
                {
                
                    values.Add("\"" + property.GetValue(obj) + "\"");

                }
                else
                {
                  
                    values.Add(property.GetValue(obj).ToString());

                }
                names.Add(property.Name);
            }

            //Formatting a string to make it work in SQLite as a command
            StringBuilder sbValues = new StringBuilder();
            StringBuilder sbNames = new StringBuilder();

            for (int i = 0; i < values.Count; i++)
            {
                //we dont want commas for the last value
                if (i == values.Count-1)
                {
                    sbValues.Append($"{values[i]}");
                    sbNames.Append($"{names[i]}");
                }

                else
                {
                    sbValues.Append($"{values[i]}, ");
                    sbNames.Append($"{names[i]}, ");
                     
                }

            }

            var command = connection.CreateCommand();
            command.CommandText = $"INSERT INTO {typeof(T).Name} ({sbNames})  VALUES({sbValues})";
            command.ExecuteNonQuery();
        }





//--------------------------------------------------------------------------------------------------------------------------------------------------------




        public void Update<T>(T obj) where T : IClassModel
            {

            Console.WriteLine($"Here we are going to change the information for {obj}");

            PropertyInfo[] properties = typeof(T).GetProperties();
                List<string> values = new List<string>();
                List<string> names = new List<string>();



            var theID = obj.Id;

            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine("Please input all the new property values for " + property.Name);



                if (property.PropertyType == typeof(string))
                {

                    values.Add(Console.ReadLine());

                }
                else
                {
                    values.Add(Console.ReadLine());
                }
                names.Add(property.Name);

            }


            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < values.Count; i++)
            {


                if (i == values.Count - 1)
                {
                    builder.Append($"{names[i]} = '{values[i]}'  ");
                }
                else
                {
                    builder.Append($"{names[i]} = '{ values[i]}',");
                }
            }


            var command = connection.CreateCommand();
                command.CommandText = $"UPDATE {typeof(T).Name} SET {builder} WHERE Id = {theID}";
            command.ExecuteNonQuery();    

           

        }


 //--------------------------------------------------------------------------------------------------------------------------------------------------------




        public void Delete<T>(T obj) where T : IClassModel
        {
            var command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM {typeof(T).Name} WHERE Id ={obj.Id}";
            command.ExecuteNonQuery();

        }


//--------------------------------------------------------------------------------------------------------------------------------------------------------



        public void DeleteAll<T>() where T : IClassModel
        {
            var command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM {typeof(T).Name} WHERE Id >0";
            command.ExecuteNonQuery();

        }





    }
}
