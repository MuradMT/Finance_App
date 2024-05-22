using Microsoft.VisualBasic;

namespace api.Constants;

public static class Messages<T>
{
     
     public readonly static string Not_Found = $"{typeof(T).FullName?.Split(".")[2] ?? string.Empty} is not found";
     
     public readonly static string Does_Not_Exist = $"{typeof(T).FullName?.Split(".")[2] ?? string.Empty} does not exist";
}
