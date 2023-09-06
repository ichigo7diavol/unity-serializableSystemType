using System;
using System.Collections.Generic;

namespace SPG.Utils.SerializableType
{
    [AttributeUsage(AttributeTargets.Field, Inherited = true)]
    public class SerializableSystemTypeFilter 
        : Attribute
    {
        public IReadOnlyCollection<Type> FilteringTypes;

        public SerializableSystemTypeFilter(params Type[] filteringTypes)
        {
            FilteringTypes = filteringTypes;
        }
    }
}