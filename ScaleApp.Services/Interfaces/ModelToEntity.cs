/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using DCoreyDuke.CodeBase.Interfaces;

namespace ScaleApp.Services.Interfaces
{
    /// <summary>
    /// Defines a mapping interface between a model and an entity.
    /// </summary>
    /// <typeparam name="TModel">Represents the data structure used in the application layer.</typeparam>
    /// <typeparam name="TEntity">Represents the data structure used in the data access layer.</typeparam>
    public interface  ModelToEntity<TModel, TEntity> : IMapper<TModel, TEntity>
    {
        
    }
}
