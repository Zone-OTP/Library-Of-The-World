using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json;
using LibraryOfTheWorld.DBData;
using LibraryOfTheWorld.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace LibraryOfTheWorld.DattaHandlers
{
    public class DataHandler //: IuserDataHandlerJson
    {
        private readonly string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlDataBaseConnection"].ConnectionString;
        private static readonly HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:5160") };
        public DataHandler()
        {
            EnsureDatabaseExists();
        }

        public void TestConnection()
        {
            using var context = CreateContext();
            context.Database.OpenConnection();
            Console.WriteLine("Connection successful!");
        }

        public LibraryContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<LibraryContext>()
                .UseSqlServer(_connectionString)
                .Options;
            return new LibraryContext(options);
        }



        // SAVE JSON TO DATABASE AND LOCAL
        //public void SaveDataJson<T>(List<T> data, string fileName)
        //{
        //    string filePath = $"{fileName.Trim()}.json";
        //    var options = new JsonSerializerOptions
        //    {
        //        WriteIndented = true,
        //        PropertyNameCaseInsensitive = true,
        //        IncludeFields = true,
        //    };
        //    string json = JsonSerializer.Serialize(data, options);
        //    File.WriteAllText(filePath, json);
        //    Console.WriteLine($"{typeof(T).Name} have been saved to {filePath}");

        //    SaveJsonToDatabase(fileName, json);
        //}

        // LOAD JSON FROM DATABASE AND LOCAL
        //public List<T> LoadDataJson<T>(string fileName)
        //{
        //    var _nextId = typeof(T).GetField("_nextId", BindingFlags.Static | BindingFlags.NonPublic);
        //    if (_nextId != null)
        //    {
        //        _nextId.SetValue(null, 1);
        //    }

        //    string filePath = $"{fileName.Trim()}.json";
        //    if (!File.Exists(filePath))
        //    {
        //        Console.WriteLine($"No file found at {filePath}, attempting to load from database");
        //        return LoadJsonDataFromDatabase<T>(fileName);
        //    }

        //    string json = File.ReadAllText(filePath);
        //    var options = new JsonSerializerOptions
        //    {
        //        WriteIndented = true,
        //        PropertyNameCaseInsensitive = true,
        //        IncludeFields = true,
        //    };

        //    try
        //    {
        //        List<T>? data = JsonSerializer.Deserialize<List<T>>(json, options);
        //        if (data != null && data.Count > 0)
        //        {
        //            string idPropertyName = typeof(T).Name + "Id";
        //            int maxId = data.Max(item => (int)typeof(T).GetProperty(idPropertyName).GetValue(item));
        //            var nextIdField = typeof(T).GetField("_nextId", BindingFlags.Static | BindingFlags.NonPublic);
        //            if (nextIdField != null)
        //            {
        //                nextIdField.SetValue(null, maxId + 1);
        //            }
        //        }
        //        else
        //        {
        //            var nextIdField = typeof(T).GetField("_nextId", BindingFlags.Static | BindingFlags.NonPublic);
        //            if (nextIdField != null)
        //            {
        //                nextIdField.SetValue(null, 1);
        //            }
        //        }
        //        Console.WriteLine($"{typeof(T).Name}s loaded successfully from file");
        //        return data ?? new List<T>();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error loading {typeof(T).Name}s from file: {ex.Message}");
        //        return LoadJsonDataFromDatabase<T>(fileName);
        //    }
        //}

        // SAVE JSON TO DATABASE 
        //private void SaveJsonToDatabase(string fileName, string jsonContent)
        //{
        //    using var context = CreateContext();
        //    try
        //    {
        //        string tableName = $"{fileName}Json";
        //        EnsureTableExists(tableName, context); // IF WE WANT IT TO WORK GET RID OF THE <T> IN THE FUNCTION 


        //        var count = context.Database
        //            .ExecuteSqlRaw($"SELECT 1 FROM {tableName} WHERE FileName = @p0", fileName) > 0;

        //        if (!count)
        //        {
        //            context.Database.ExecuteSqlRaw(
        //                $"INSERT INTO {tableName} (FileName, Content) VALUES (@p0, @p1)",
        //                fileName, jsonContent);
        //        }
        //        else
        //        {
        //            context.Database.ExecuteSqlRaw(
        //                $"UPDATE {tableName} SET Content = @p0 WHERE FileName = @p1",
        //                jsonContent, fileName);
        //        }
        //        Console.WriteLine($"{fileName} saved to database table {tableName}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error saving {fileName} to database: {ex.Message}");
        //        throw;
        //    }
        //}

        // LOAD JSON FROM DATABASE 
        //public List<T> LoadJsonDataFromDatabase<T>(string fileName)
        //{
        //    using var context = CreateContext();
        //    try
        //    {
        //        string tableName = $"{fileName}Json";
        //        EnsureTableExists(tableName, context); // IF WE WANT IT TO WORK GET RID OF THE <T> IN THE FUNCTION


        //        var jsonContent = context.Database
        //            .SqlQueryRaw<string>($"SELECT Content FROM {tableName} WHERE FileName = @p0", fileName)
        //            .FirstOrDefault();

        //        if (string.IsNullOrEmpty(jsonContent))
        //        {
        //            Console.WriteLine($"No database entry found for {fileName} in {tableName}");
        //            return new List<T>();
        //        }

        //        var options = new JsonSerializerOptions
        //        {
        //            PropertyNameCaseInsensitive = true,
        //            IncludeFields = true,
        //        };

        //        List<T>? data = JsonSerializer.Deserialize<List<T>>(jsonContent, options);
        //        if (data != null && data.Count > 0)
        //        {
        //            string idPropertyName = typeof(T).Name + "Id";
        //            int maxId = data.Max(item => (int)typeof(T).GetProperty(idPropertyName).GetValue(item));
        //            var nextIdField = typeof(T).GetField("_nextId", BindingFlags.Static | BindingFlags.NonPublic);
        //            if (nextIdField != null)
        //            {
        //                nextIdField.SetValue(null, maxId + 1);
        //            }
        //        }
        //        else
        //        {
        //            var nextIdField = typeof(T).GetField("_nextId", BindingFlags.Static | BindingFlags.NonPublic);
        //            if (nextIdField != null)
        //            {
        //                nextIdField.SetValue(null, 1);
        //            }
        //        }
        //        Console.WriteLine($"{typeof(T).Name}s loaded successfully from database table {tableName}");
        //        return data ?? new List<T>();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error loading {typeof(T).Name}s from database: {ex.Message}");
        //        return new List<T>();
        //    }
        //}



        private void EnsureDatabaseExists()
        {
            using var context = CreateContext();
            context.Database.EnsureCreated();
        }

        public void SaveToDatabase<T>(List<T> data, bool useIdentityInsert = false) where T : class
        {
            string tableName = typeof(T).Name + "s";
            using var context = CreateContext();
            context.Database.OpenConnection();
            try
            {
                bool tableExists = context.Database.GetDbConnection().GetSchema("Tables").Rows
                    .Cast<System.Data.DataRow>().Any(row => row["TABLE_NAME"].ToString() == tableName);

                if (!tableExists)
                {
                    Console.WriteLine($"Table '{tableName}' does not exist. Creating it...");
                    string createTableSql = GenerateCreateTableSql<T>(tableName);
                    context.Database.ExecuteSqlRaw(createTableSql);
                    Console.WriteLine($"Table '{tableName}' created successfully.");
                    tableExists = true;
                }
            }
            finally
            {
                context.Database.CloseConnection();
            }

            string idColumnName = typeof(T).Name + "Id";
            var idProperty = typeof(T).GetProperty(idColumnName);
            if (idProperty == null)
            {
                throw new ArgumentException($"Entity {typeof(T).Name} must have a {idColumnName} property");
            }

            using var transaction = context.Database.BeginTransaction();
            try
            {
                var dbSet = context.Set<T>();
                var properties = typeof(T).GetProperties()
                    .Where(p => p.CanWrite && (!p.PropertyType.IsClass || p.PropertyType == typeof(string)))
                    .ToArray();

                if (useIdentityInsert)
                {
                    context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {tableName} ON");

                }

                foreach (var item in data)
                {
                    var idValue = idProperty.GetValue(item) ?? throw new ArgumentNullException($"{idColumnName} cannot be null for {item}");
                    bool recordExists = false;

                    if (TableExists(tableName))
                    {
                        recordExists = dbSet.Any(e => EF.Property<object>(e, idColumnName).Equals(idValue));
                    }

                    if (recordExists)
                    {
                        var existingEntity = dbSet.Find(idValue);
                        context.Entry(existingEntity).CurrentValues.SetValues(item);
                    }
                    else
                    {
                        dbSet.Add(item);
                    }
                }

                context.SaveChanges();

                if (useIdentityInsert)
                {
                    context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {tableName} OFF");
                }

                transaction.Commit();
                Console.WriteLine($"{typeof(T).Name}s saved/updated successfully.");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine($"Error in SaveToDatabase: {ex.Message}");
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                NotificationService.ShowMessage($"Error in SaveToDatabase: {ex.Message}");
                NotificationService.ShowMessage($"Inner Exception: {ex.InnerException?.Message}");
                NotificationService.ShowMessage($"Stack Trace: {ex.StackTrace}");

                if (useIdentityInsert)
                {
                    try
                    {
                        context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {tableName} OFF");
                    }
                    catch { }
                }
                throw;
            }
        }

        private bool TableExists(string tableName)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand(
                "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @tableName",
                connection);
            command.Parameters.AddWithValue("@tableName", tableName);
            var count = (int)command.ExecuteScalar();
            return count > 0;
        }

        public List<T> LoadFromDatabase<T>() where T : class, new()
        {
            string tableName = typeof(T).Name + "s";
            using var context = CreateContext();

            if (!TableExists(tableName))
            {
                Console.WriteLine($"No table found for {typeof(T).Name}s.");
                return new List<T>();
            }

            try
            {
                var result = context.Set<T>().ToList();
                Console.WriteLine($"{typeof(T).Name}s loaded successfully from database. Count: {result.Count}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading {typeof(T).Name}s from database: {ex.Message}");
                return new List<T>();
            }
        }

        private string GenerateCreateTableSql<T>(string tableName)
        {
            using var context = CreateContext();
            var type = typeof(T);
            var properties = type.GetProperties()
                .Where(p => p.Name != "AuthorName" && (!p.PropertyType.IsClass || p.PropertyType == typeof(string)));

            var keyProperty = type.GetProperties()
                .FirstOrDefault(p => p.GetCustomAttributes(typeof(KeyAttribute), true).Any());
            string keyName;

            if (keyProperty != null)
            {
                keyName = keyProperty.Name;
            }
            else
            {
                keyName = $"{type.Name}Id";
                keyProperty = type.GetProperty(keyName);
                if (keyProperty == null)
                {
                    keyName = "Id";
                    keyProperty = type.GetProperty(keyName);
                }
            }

            if (keyProperty == null)
            {
                throw new InvalidOperationException($"No key property ([Key], {type.Name}Id, or Id) found for type {type.Name}.");
            }

            var typeMappingSource = context.GetService<IRelationalTypeMappingSource>();

            var columns = new List<string>();
            foreach (var prop in properties)
            {
                string columnName = prop.Name;

                Type propType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                bool isNullable = Nullable.GetUnderlyingType(prop.PropertyType) != null;

                var typeMapping = typeMappingSource.FindMapping(propType);
                if (typeMapping == null)
                {
                    throw new NotSupportedException($"No type mapping found for {propType.Name} in property {prop.Name}.");
                }

                string sqlType;
                if (prop.Name == keyName)
                {
                    if (propType == typeof(int) || propType == typeof(long))
                    {
                        sqlType = $"{typeMapping.StoreType} IDENTITY(1,1) PRIMARY KEY";
                    }
                    else
                    {
                        sqlType = $"{typeMapping.StoreType} PRIMARY KEY";
                    }
                }
                else
                {
                    sqlType = typeMapping.StoreType;
                    sqlType += isNullable ? " NULL" : " NOT NULL";
                }

                columns.Add($"{columnName} {sqlType}");
            }

            string columnsDefinition = string.Join(", ", columns);
            return $"CREATE TABLE {tableName} ({columnsDefinition})";
        }
        public void RemoveFromDatabase<T>(int id) where T : class
        {
            string tableName = typeof(T).Name + "s";
            string idColumnName = typeof(T).Name + "Id";
            string connectionString = _connectionString;

            if (!TableExists(tableName))
            {
                Console.WriteLine($"No table found for {typeof(T).Name}s.");
                return;
            }

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string deleteSql = $"DELETE FROM {tableName} WHERE {idColumnName} = @id";

                        using (var command = new SqlCommand(deleteSql, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                Console.WriteLine($"{typeof(T).Name} with ID {id} removed successfully.");
                            }
                            else
                            {
                                Console.WriteLine($"No {typeof(T).Name} found with ID {id}.");
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Error removing {typeof(T).Name} from database: {ex.Message}");
                        Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                        Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                        throw;
                    }
                }
            }
        }

        public async Task<List<T>> GetViaApi<T>() where T : class
        {
            var type = typeof(T);
            string endpoint = $"/api/{type.Name.ToLower()}s";

            try
            {
                HttpResponseMessage response = await client.GetAsync(endpoint);

                string json = await response.Content.ReadAsStringAsync();
                List<T> result = JsonSerializer.Deserialize<List<T>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    IncludeFields = true,
                });
                response.EnsureSuccessStatusCode();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching {type.Name}s from API: {ex.Message}");
                return new List<T>();
            }
        }

        public async Task<T> GetViaApiById<T>(int id) where T : class
        {
            string endpoint = $"/api/{typeof(T).Name.ToLower()}s/{id}";
            try
            {
                HttpResponseMessage response = await client.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();
                T result = JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching {typeof(T).Name} with ID {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<T> PostViaApi<T>(T entity) where T : class
        {
            string endpoint = $"/api/{typeof(T).Name.ToLower()}s";

            try
            {
                string json = JsonSerializer.Serialize(entity);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(endpoint, content);
                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();
                T createdEntity = JsonSerializer.Deserialize<T>(responseJson,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return createdEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error posting {typeof(T).Name} to API: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Checks if an entity with the specified ID exists.
        /// </summary>
        /// <param name="type">The entity type (e.g., "author", "book")</param>
        /// <param name="entityName)">The ID of the entity to check</param>
        /// <returns>True if the entity exists, false otherwise</returns>
        public async Task<bool> EntityExistsByIdAsync<T>(string entityName) where T : class
        {
            var type = typeof(T).Name;
            string endpoint = $"/api/checks/{type}/id/{entityName}";

            try
            {
                HttpResponseMessage response = await client.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();
                bool exists = JsonSerializer.Deserialize<bool>(json);
                return exists;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking if {type} with ID {entityName} exists: {ex.Message}");
                return false;
            }
        }

    }
}



