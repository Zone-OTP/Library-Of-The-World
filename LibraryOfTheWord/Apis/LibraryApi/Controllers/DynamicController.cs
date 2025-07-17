using LibraryApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers
{
    [Route("api/data")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly LibraryContext _context;
        private readonly Dictionary<string, Type> _entityTypes;

        public DataController(LibraryContext context)
        {
            _context = context;
            _entityTypes = new Dictionary<string, Type>();

            var dbSetProperties = typeof(LibraryContext).GetProperties()
                .Where(p => p.PropertyType.IsGenericType &&
                            p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));

            foreach (var prop in dbSetProperties)
            {
                var entityType = prop.PropertyType.GetGenericArguments()[0];
                var entityName = prop.Name.ToLower();
                if (entityName.EndsWith("s"))
                {
                    entityName = entityName.Substring(0, entityName.Length - 1);
                }
                _entityTypes[entityName] = entityType;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("{type}")]
        public async Task<IActionResult> GetAll(string type)
        {
            if (!_entityTypes.TryGetValue(type.ToLower(), out var entityType))
            {
                return BadRequest("Invalid entity type");
            }

            var method = GetType().GetMethod(nameof(GetAllInternal), System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            var genericMethod = method.MakeGenericMethod(entityType);
            var result = await (Task<IActionResult>)genericMethod.Invoke(this, null);

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        [HttpGet("{type}/{id}")]
        public async Task<IActionResult> GetById(string type, string id)
        {
            if (!_entityTypes.TryGetValue(type.ToLower(), out var entityType))
            {
                return BadRequest("Invalid entity type");
            }

            var method = GetType().GetMethod(nameof(GetByIdInternal), System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            var genericMethod = method.MakeGenericMethod(entityType);
            var result = await (Task<IActionResult>)genericMethod.Invoke(this, new object[] { id });

            return result;
        }

        private async Task<IActionResult> GetAllInternal<T>() where T : class
        {
            var data = await _context.Set<T>().ToListAsync();
            return Ok(data);
        }

        private async Task<IActionResult> GetByIdInternal<T>(string id) where T : class
        {
            try
            {
                var entityType = typeof(T);
                var entityTypeMetadata = _context.Model.FindEntityType(entityType);
                var keyProperty = entityTypeMetadata.FindPrimaryKey().Properties[0];
                string keyName = keyProperty.Name;
                var keyType = keyProperty.ClrType;

                object keyValue = Convert.ChangeType(id, keyType);

                var entity = await _context.Set<T>().FirstOrDefaultAsync(e => EF.Property<object>(e, keyName).Equals(keyValue));
                if (entity == null)
                {
                    return NotFound();
                }
                return Ok(entity);
            }
            catch (FormatException)
            {
                return BadRequest("Invalid ID format for the entity type's primary key");
            }
            catch (InvalidCastException)
            {
                return BadRequest("ID type mismatch with the entity type's primary key");
            }
        }
    }
}
