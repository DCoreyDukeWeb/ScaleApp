﻿/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
namespace Services.Mappers.EntityToModel
{
    /// <summary>
    /// Defines a contract for converting entities to models.
    /// </summary>
    /// <typeparam name="TEntity">Represents a class type that will be transformed into a model.</typeparam>
    /// <typeparam name="TModel">Represents the model type that will be created from the entity.</typeparam>
    public interface EntityToModel<TEntity, TModel> where TEntity : class
    {
    }
}
