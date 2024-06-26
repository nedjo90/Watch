using System.Reflection;
using Contracts;
using Entities.Models;

namespace Service.DataShaping;

public class DataShaper<T> : IDataShaper<T> where T : class
{
	public PropertyInfo[] Properties { get; set; }

	public DataShaper()
	{
		Properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
	}

	public IEnumerable<ShapedEntity> ShapeData(IEnumerable<T> entities, string fieldsString)
	{
		IEnumerable<PropertyInfo> requiredProperties = GetRequiredProperties(fieldsString);

		return FetchData(entities, requiredProperties);
	}

	public ShapedEntity ShapeData(T entity, string fieldsString)
	{
		IEnumerable<PropertyInfo> requiredProperties = GetRequiredProperties(fieldsString);

		return FetchDataForEntity(entity, requiredProperties);
	}

	private IEnumerable<PropertyInfo> GetRequiredProperties(string fieldsString)
	{
		List<PropertyInfo> requiredProperties = new List<PropertyInfo>();

		if (!string.IsNullOrWhiteSpace(fieldsString))
		{
			string[] fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);

			foreach (string field in fields)
			{
				PropertyInfo? property = Properties
					.FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));

				if (property == null)
					continue;

				requiredProperties.Add(property);
			}
		}
		else
		{
			requiredProperties = Properties.ToList();
		}

		return requiredProperties;
	}

	private IEnumerable<ShapedEntity> FetchData(IEnumerable<T> entities, IEnumerable<PropertyInfo> requiredProperties)
	{
		List<ShapedEntity> shapedData = new List<ShapedEntity>();

		foreach (T entity in entities)
		{
			ShapedEntity shapedObject = FetchDataForEntity(entity, requiredProperties);
			shapedData.Add(shapedObject);
		}

		return shapedData;
	}

	private ShapedEntity FetchDataForEntity(T entity, IEnumerable<PropertyInfo> requiredProperties)
	{
		ShapedEntity shapedObject = new ShapedEntity();

		foreach (PropertyInfo property in requiredProperties)
		{
			object? objectPropertyValue = property.GetValue(entity);
			shapedObject.Entity.TryAdd(property.Name, objectPropertyValue);
		}

		PropertyInfo? objectProperty = entity.GetType().GetProperty("Id");
		shapedObject.Id = (Guid)objectProperty.GetValue(entity);

		return shapedObject;
	}
}
