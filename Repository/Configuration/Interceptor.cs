using Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Repository.Configuration
{
    public class Interceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            var context = eventData.Context;

            var entitiesWithRelationship = context.ChangeTracker.Entries()
                .Where(e =>
                    e.State == EntityState.Added ||
                    e.State == EntityState.Modified || 
                    e.State == EntityState.Deleted)
                .Select(e => e.Entity)
                .OfType<BaseEntity>()
                .ToList();

            foreach (var entity in entitiesWithRelationship)
            {
                foreach (var property in entity.GetType().GetProperties())
                {
                    if (typeof(BaseEntity).IsAssignableFrom(property.PropertyType))
                    {
                        var relatedEntity = property.GetValue(entity) as BaseEntity;
                        if (relatedEntity != null)
                        {
                            context.Entry(relatedEntity).State = EntityState.Unchanged;
                        }
                    }
                }
            }

            return base.SavingChanges(eventData, result);
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            var context = eventData.Context;

            var entitiesWithRelationship = context.ChangeTracker.Entries()
                .Where(e => 
                    e.State == EntityState.Added || 
                    e.State == EntityState.Modified || 
                    e.State == EntityState.Deleted)
                .Select(e => e.Entity)
                .OfType<BaseEntity>()
                .ToList();

            foreach (var entity in entitiesWithRelationship)
            {
                foreach (var property in entity.GetType().GetProperties())
                {
                    if (typeof(BaseEntity).IsAssignableFrom(property.PropertyType))
                    {
                        var relatedEntity = property.GetValue(entity) as BaseEntity;
                        if (relatedEntity != null)
                        {
                            context.Entry(relatedEntity).State = EntityState.Unchanged;
                        }
                    }
                }
            }

            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
