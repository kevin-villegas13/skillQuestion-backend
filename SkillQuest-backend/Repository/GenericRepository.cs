using SkillQuest_backend.Data;
using SkillQuest_backend.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace SkillQuest_backend.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext applicationDbContext;

    public GenericRepository(ApplicationDbContext applicationDbContext) => this.applicationDbContext = applicationDbContext;

    public async Task<T> Add(T entity)
    {
        try
        {
            await applicationDbContext.Set<T>().AddAsync(entity);
            await applicationDbContext.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding entity: {ex.Message}");
            throw new Exception("An error occurred while adding the entity.");
        }
    }

    public async Task<T> Delete(int id)
    {
        try
        {
            var entity = await applicationDbContext.Set<T>().FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Entity with ID {id} not found.");

            applicationDbContext.Set<T>().Remove(entity);
            await applicationDbContext.SaveChangesAsync();
            return entity;
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine($"Key not found: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting entity: {ex.Message}");
            throw new Exception("An error occurred while deleting the entity.");
        }
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        try
        {
            return await applicationDbContext.Set<T>().ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving entities: {ex.Message}");
            throw new Exception("An error occurred while retrieving entities.");
        }
    }

    public async Task<T> GetById(int id)
    {
        try
        {
            var entity = await applicationDbContext.Set<T>().FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Entity with ID {id} not found.");
            return entity;
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine($"Key not found: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving entity: {ex.Message}");
            throw new Exception("An error occurred while retrieving the entity.");
        }
    }

    public async Task<T> Update(T entity)
    {
        try
        {
            applicationDbContext.Set<T>().Update(entity);
            await applicationDbContext.SaveChangesAsync();
            return entity;
        }
        catch (DbUpdateConcurrencyException ex)
        {
            Console.WriteLine($"Concurrency issue: {ex.Message}");
            throw new Exception("A concurrency issue occurred while updating the entity.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating entity: {ex.Message}");
            throw new Exception("An error occurred while updating the entity.");
        }
    }

    public async Task<(IEnumerable<T> Items, int TotalCount)> GetPaged(int pageNumber, int pageSize, string? searchQuery = null)
    {
        try
        {
            if (pageNumber <= 0 || pageSize <= 0)
                throw new ArgumentException("Page number and page size must be greater than zero.");

            var query = applicationDbContext.Set<T>().AsQueryable();

            // Aplicar el filtro de búsqueda si hay un término
            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(e =>
                    EF.Property<string>(e, "Name").Contains(searchQuery) ||
                    EF.Property<string>(e, "Description").Contains(searchQuery));
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException($"Invalid arguments: {ex.Message}", ex);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while fetching paginated data.", ex);
        }
    }
}

