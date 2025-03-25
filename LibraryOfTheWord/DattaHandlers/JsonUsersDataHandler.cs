using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json.Serialization;
using LibraryOfTheWorld.Interfaces;
using LibraryOfTheWorld.Users;
using LibraryOfTheWorld;
using System.Drawing;
using System.Reflection;


namespace LibraryOfTheWorld.DattaHandlers
{
    public class JsonUsersDataHandler : IuserDataHandlerJson
    {
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
            Console.WriteLine($"{typeof(T).Name} Have been saved");
        }
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
                Console.WriteLine("No Saved Found");
                return new List<T>();
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
                Console.WriteLine($"{typeof(T).Name}s loaded successfully");
                return data ?? new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Loading {typeof(T).Name}s: {ex.Message}");
                return new List<T>();
            }
        }
    }
}
    
    
