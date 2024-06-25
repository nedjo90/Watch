using System.Reflection;
using AutoMapper.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Service;

public static class ServiceHelper
{
    public static void DisplayFullClass(Type? type)
    {
        Console.WriteLine(type?.FullName);
        if (type is null)
        {
            Console.WriteLine("\t NULL");
            return;
        }
        PropertyInfo[] properties = type.GetProperties();
        foreach (PropertyInfo property in properties)
        {
            if (property.IsPublic())
                Console.WriteLine($"\t{property.Name} => {property}");
            else
            {
                Console.WriteLine($"\t{property.Name} => PRIVATE");
            }
        }
    }
}