using System;
using JetBrains.Annotations;
using UnityEngine;

namespace SPG.Utils.SerializableType
{
	[System.Serializable]
	public class SerializableSystemType : ISerializationCallbackReceiver
	{
		[SerializeField] 
		private string _assemblyQualifiedName;
		
		public Type Value { get; set; }

		public SerializableSystemType([NotNull] Type type)
		{
			Value = type;

			_assemblyQualifiedName = type.AssemblyQualifiedName;
		}

		public void OnBeforeSerialize()
		{
			_assemblyQualifiedName = Value?.AssemblyQualifiedName;
		}

		public void OnAfterDeserialize()
		{
			if (string.IsNullOrEmpty(_assemblyQualifiedName))
			{
				Value = null;
			}
			else
			{
				try
				{
					Value = Type.GetType(_assemblyQualifiedName);
				}
				catch (Exception e)
				{
					Debug.LogException(e);
				}
			}
		}

		public override string ToString()
		{
			return Value?.ToString() ?? string.Empty;
		}

		public override int GetHashCode()
		{
			return Value.GetHashCode();
		}
	}
}