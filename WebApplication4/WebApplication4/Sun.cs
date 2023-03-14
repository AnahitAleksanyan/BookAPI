namespace WebApplication4
{
    public class Sun
    {
        public decimal Weight { get; set; }

        private static Sun? _instance;
        public static Sun Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Sun();
                }
                return _instance;
            }
        }

        private Sun() { }
    }
}
