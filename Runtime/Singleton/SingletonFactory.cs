namespace Chromium.Utilities.Singleton
{
	/// <example>
	/// public static T Instance => SingletonFactory<T>.Instance;
	/// </example>
	public static class SingletonFactory<T> where T : new()
	{
		private static T instance = default;
		public static T Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new T();
				}
				return instance;
			}
		}
	}


}
