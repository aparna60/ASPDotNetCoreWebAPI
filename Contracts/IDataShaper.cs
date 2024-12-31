using Entities.Models;
using System.Dynamic;


namespace Contracts
{
    public interface IDataShaper<T>
    {
        //Dynamically added and removed objects in ExpandoObject
        IEnumerable<ShapedEntity> ShapeData(IEnumerable<T> entities, string fieldsString);
        ShapedEntity ShapeData(T entity, string fieldsString);
    }
}
