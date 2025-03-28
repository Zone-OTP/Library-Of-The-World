using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using LibraryOfTheWorld.DBData;
using LibraryOfTheWorld.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient; 

namespace LibraryOfTheWorld.DattaHandlers
{
    public class JsonUsersDataHandler : IuserDataHandlerJson
    {
        private readonly string _connectionString = "Server=DESKTOP-LTO7H71;Database=LibraryDb;Trusted_Connection=True;TrustServerCertificate=True;";

        public JsonUsersDataHandler()
        {
            EnsureDatabaseExists();
        }

        private LibraryContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<LibraryContext>()
                .UseSqlServer(_connectionString)
                .Options;
            return new LibraryContext(options);
        }

        // SAVE JSON 
        public void SaveDataJson<T>(List<T> data, string fileName)
        {
            string filePath = $"{fileName.Trim()}.json";
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
                IncludeFields = true,
            };
            string json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(filePath, json);
            Console.WriteLine($"{typeof(T).Name} have been saved to {filePath}");

            SaveToDatabase(fileName, json);
        }

        // LOAD JSON 
        public List<T> LoadDataJson<T>(string fileName)
        {
            var _nextId = typeof(T).GetField("_nextId", BindingFlags.Static | BindingFlags.NonPublic);
            if (_nextId != null)
            {
                _nextId.SetValue(null, 1);
            }

            string filePath = $"{fileName.Trim()}.json";
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"No file found at {filePath}, attempting to load from database");
                return LoadDataFromDatabase<T>(fileName);
            }

            string json = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
                IncludeFields = true,
            };

            try
            {
                List<T>? data = JsonSerializer.Deserialize<List<T>>(json, options);
                if (data != null && data.Count > 0)
                {
                    string idPropertyName = typeof(T).Name + "Id";
                    int maxId = data.Max(item => (int)typeof(T).GetProperty(idPropertyName).GetValue(item));
                    var nextIdField = typeof(T).GetField("_nextId", BindingFlags.Static | BindingFlags.NonPublic);
                    if (nextIdField != null)
                    {
                        nextIdField.SetValue(null, maxId + 1);
                    }
                }
                else
                {
                    var nextIdField = typeof(T).GetField("_nextId", BindingFlags.Static | BindingFlags.NonPublic);
                    if (nextIdField != null)
                    {
                        nextIdField.SetValue(null, 1);
                    }
                }
                Console.WriteLine($"{typeof(T).Name}s loaded successfully from file");
                return data ?? new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading {typeof(T).Name}s from file: {ex.Message}");
                return LoadDataFromDatabase<T>(fileName);
            }
        }

        // SAVE TO DATABASE 
        private void SaveToDatabase(string fileName, string jsonContent)
        {
            using var context = CreateContext();
            try
            {
                string tableName = $"{fileName}Json";
                EnsureTableExists(tableName, context);

                
                var count = context.Database
                    .ExecuteSqlRaw($"SELECT 1 FROM {tableName} WHERE FileName = @p0", fileName) > 0;

                if (!count)
                {
                    context.Database.ExecuteSqlRaw(
                        $"INSERT INTO {tableName} (FileName, Content) VALUES (@p0, @p1)",
                        fileName, jsonContent);
                }
                else
                {
                    context.Database.ExecuteSqlRaw(
                        $"UPDATE {tableName} SET Content = @p0 WHERE FileName = @p1",
                        jsonContent, fileName);
                }
                Console.WriteLine($"{fileName} saved to database table {tableName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving {fileName} to database: {ex.Message}");
                throw;
            }
        }

        // LOAD FROM DATABASE 
        public List<T> LoadDataFromDatabase<T>(string fileName)
        {
            using var context = CreateContext();
            try
            {
                string tableName = $"{fileName}Json";
                EnsureTableExists(tableName, context);

                
                var jsonContent = context.Database
                    .SqlQueryRaw<string>($"SELECT Content FROM {tableName} WHERE FileName = @p0", fileName)
                    .FirstOrDefault();

                if (string.IsNullOrEmpty(jsonContent))
                {
                    Console.WriteLine($"No database entry found for {fileName} in {tableName}");
                    return new List<T>();
                }

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    IncludeFields = true,
                };

                List<T>? data = JsonSerializer.Deserialize<List<T>>(jsonContent, options);
                if (data != null && data.Count > 0)
                {
                    string idPropertyName = typeof(T).Name + "Id";
                    int maxId = data.Max(item => (int)typeof(T).GetProperty(idPropertyName).GetValue(item));
                    var nextIdField = typeof(T).GetField("_nextId", BindingFlags.Static | BindingFlags.NonPublic);
                    if (nextIdField != null)
                    {
                        nextIdField.SetValue(null, maxId + 1);
                    }
                }
                else
                {
                    var nextIdField = typeof(T).GetField("_nextId", BindingFlags.Static | BindingFlags.NonPublic);
                    if (nextIdField != null)
                    {
                        nextIdField.SetValue(null, 1);
                    }
                }
                Console.WriteLine($"{typeof(T).Name}s loaded successfully from database table {tableName}");
                return data ?? new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading {typeof(T).Name}s from database: {ex.Message}");
                return new List<T>();
            }
        }

        // CREATE TABLE IF NOT EXISTS 
        private void EnsureTableExists(string tableName, LibraryContext context)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                using var command = new SqlCommand(
                    "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @tableName",
                    connection);
                command.Parameters.AddWithValue("@tableName", tableName);
                var count = (int)command.ExecuteScalar();
                var exists = count > 0;

                if (!exists)
                {
                    context.Database.ExecuteSqlRaw($@"
                        CREATE TABLE {tableName} (
                            Id INT IDENTITY(1,1) PRIMARY KEY,
                            FileName NVARCHAR(255),
                            Content NVARCHAR(MAX)
                        )");
                    System.Diagnostics.Debug.WriteLine($"Created table {tableName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking or creating table {tableName}: {ex.Message}");
                throw;
            }
        }

        private void EnsureDatabaseExists()
        {
            using var context = CreateContext();
            context.Database.EnsureCreated();
        }
    }
}