/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using DCoreyDuke.CodeBase.Interfaces;

namespace ScaleApp.Services.Interfaces
{
    /// <summary>
    /// Defines a contract for converting entities to models.
    /// </summary>
    /// <typeparam name="TEntity">Represents a class type that will be transformed into a model.</typeparam>
    /// <typeparam name="TModel">Represents the model type that will be created from the entity.</typeparam>
    public interface EntityToModel<TEntity, TModel> : IMapper<TEntity, TModel>
    {
    }
}
