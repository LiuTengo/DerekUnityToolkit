namespace DerekToolkit.GeneralTool.Singleton
{
    public class USingleton<T> where T : USingleton<T>
    {
        private static T _instance;

        public static T instance => _instance;
        
        public USingleton()
        {
            _instance = this as T;
        }
    }
}