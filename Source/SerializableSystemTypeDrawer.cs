using System.Linq;
using UnityEditor;
using UnityEngine.UIElements;

namespace SPG.Utils.SerializableType
{
    [CustomPropertyDrawer(typeof(SerializableSystemType))]
    public class SerializableSystemTypeDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new VisualElement();

            var dropDown = new DropdownField();

            var filteringAttributes = fieldInfo
                .GetCustomAttributes(typeof(SerializableSystemTypeFilter), true)
                .Cast<SerializableSystemTypeFilter>()
                .SelectMany(a => a.FilteringTypes);
    
            var items = SerializableSystemTypeUtils
                .GetTypes(filteringAttributes);

            dropDown.choices = items.Select(i => i.Value.Name)
                .ToList();
            
            container.Add(dropDown);
            
            return container;
        }
    }
}