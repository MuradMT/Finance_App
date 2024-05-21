using Microsoft.VisualBasic;

namespace api.Constants;

public static class Messages<T>
{
     public readonly static string NotFound = $"{typeof(T).FullName?.Split(".")[2]?? string.Empty} not found";
}
