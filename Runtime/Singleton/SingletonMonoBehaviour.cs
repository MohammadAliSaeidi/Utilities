using UnityEngine;

namespace Chromium.Utilities.Singleton
{
	/// <summary>
	/// Other classes can derive from this If you want to implement singleton on them.
	/// </summary>
	/// <typeparam name="T">The child class that derives from this class (itself)</typeparam>
	public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : Component
	{
		private static T _instance;

		public static T Instance
		{
			get
			{
				if (_instance == null)
				{
					var objs = FindObjectsOfType(typeof(T)) as T[];
					if (objs.Length > 0)
					{
						_instance = objs[0];
					}
					if (objs.Length > 1)
					{
						Debug.LogError("There is more than one <b>" + typeof(T).Name + "</b> in the scene.");
					}
					if (Instance == null)
					{
						var obj = new GameObject();
						obj.name = string.Format("_{0}", typeof(T).Name);
						_instance = obj.AddComponent<T>();
					}
				}
				return _instance;
			}
		}
	}
}
