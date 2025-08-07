public static class PatchHelper
{
    public static void CopyAllFieldsExceptId<T>(T source, T destination)
        where T : class
    {
        var props = typeof(T).GetProperties();

        foreach (var prop in props)
        {
            // Ignore the Id field
            if (prop.Name == "Id")
                continue;

            // Only copy if the property has a public setter
            if (!prop.CanWrite || prop.SetMethod == null || !prop.SetMethod.IsPublic)
                continue;

            var value = prop.GetValue(source);
            prop.SetValue(destination, value);
        }
    }
}
