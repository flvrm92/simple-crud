
namespace Shared
{
    public static class Runtime
    {
        private static string _connString = "server=flvrm92-ntb;database=oreonsdb;Integrated Security=SSPI;MultipleActiveResultSets=true";
        public static string ConnectionString
        {
            get => _connString;
            set
            {
                if (!string.IsNullOrEmpty(value.Trim()))
                    _connString = value;
            }
        }
    }
}
