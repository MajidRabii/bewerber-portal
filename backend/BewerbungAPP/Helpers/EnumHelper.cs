namespace BewerbungAPP.Helpers
{
    public static class EnumHelper
    {
        public static List<KeyValuePair<int, string>> ToKeyValueList<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T))
                        .Cast<T>()
                        .Select(e => new KeyValuePair<int, string>(Convert.ToInt32(e), e.ToString()))
                        .ToList();
        }
    }
}
