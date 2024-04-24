using System.Dynamic;
using Entities.Models;

namespace Contracts;

public interface IDataShaper<TEntity>
{
    IEnumerable<ShapedEntity> ShapeData(IEnumerable<TEntity> entities, string fieldsString);
    ShapedEntity ShapeData(TEntity entity, string fieldsString);
}
