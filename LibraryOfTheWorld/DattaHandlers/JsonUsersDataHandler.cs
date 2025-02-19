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
                IncludeFields = true,
                TypeInfoResolver = new DefaultJsonTypeInfoResolver
                {
                    Modifiers =
                    { (typeInfo) =>
                        {
                            if (typeInfo.Type == typeof(User))
                            {
                                typeInfo.PolymorphismOptions = new JsonPolymorphismOptions
                                {
                                        TypeDiscriminatorPropertyName = "$type",
                                        DerivedTypes =
                                        {
                                        new JsonDerivedType(typeof(User), "User"),
                                        }
                                };
                            }
                        }
                    }
                }
            };
            string json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(filePath, json);
            Console.WriteLine($"{typeof(T).Name} Have been saved");
        }
        public List<T> LoadDataJson<T>(string fileName)
        {
            string filePath = $"{fileName.Trim()}.json";
            User._nextId = 1;
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
                TypeInfoResolver = new DefaultJsonTypeInfoResolver
                {
                    Modifiers =
                    { (typeInfo) =>
                        { if(typeInfo.Type == typeof(User))
                          {
                             typeInfo.PolymorphismOptions = new JsonPolymorphismOptions
                             {
                                TypeDiscriminatorPropertyName = "$type",
                                IgnoreUnrecognizedTypeDiscriminators = true,
                                DerivedTypes =
                                {
                                    new JsonDerivedType(typeof(User), "User"),
                                }
                             };
                          }
                        }

                    }
                }
            };
            try
            {
                List<T>? data = JsonSerializer.Deserialize<List<T>>(json, options);
                Console.WriteLine($"{typeof(T)}s loaded successfully");
                return data ?? new List<T>();
            }
            catch (Exception ex) { Console.WriteLine($"Error Loading users:{ex.Message}"); return new List<T>(); }
        }
    }
}
    
    
