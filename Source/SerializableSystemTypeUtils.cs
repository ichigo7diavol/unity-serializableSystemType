using System;
using System.Collections.Generic;
using System.Linq;

namespace SPG.Utils.SerializableType
{
    public static class SerializableSystemTypeUtils
    {
        private static List<Type> _types;

        private static IReadOnlyCollection<Type> Types
            => _types ??= AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .ToList();

        public static IEnumerable<SerializableSystemType> GetTypes(IEnumerable<Type> filteringTypes = null)
        {
            if (filteringTypes == null || !filteringTypes.Any())
            {
                return Types
                    .Select(t => new SerializableSystemType(t));
            }
            return Types
                .Where(t => filteringTypes.Any(f => f.IsAssignableFrom(t)))
                .Select(t => new SerializableSystemType(t));
        }
    }
}