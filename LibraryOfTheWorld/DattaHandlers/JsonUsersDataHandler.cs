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
        private readonly static string filePath = "Users.json";
        public void SaveUserJson(List<User> users)
        {
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
            string json = JsonSerializer.Serialize(users, options);
            File.WriteAllText(filePath, json);
            Console.WriteLine("Users Have been saved");
        }
        public List<User> LoadUsersJson()
        {
            //User._nextId = 1;
            if (!File.Exists(filePath))
            {
                Console.WriteLine("No Saved Found");
                return new List<User>();
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
                List<User>? users = JsonSerializer.Deserialize<List<User>>(json, options);
                Console.WriteLine("Users loaded successfully");
                return users ?? new List<User>();
            }
            catch (Exception ex) { Console.WriteLine($"Error Loading pets:{ex.Message}"); return new List<User>(); }
        }
    }
}
    
    
