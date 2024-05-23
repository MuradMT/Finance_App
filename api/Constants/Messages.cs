using Microsoft.VisualBasic;

namespace api.Constants;

public static class Messages<T>
{
     private static string _messageType = typeof(T).FullName?.Split(".")[2] ?? string.Empty;
     #region Dynamic Exception Messages

     public readonly static string Not_Found = $"{_messageType} is not found";

     public readonly static string Does_Not_Exist = $"{_messageType} does not exist";

     #endregion

     #region Dynamic Endpoint Summary Messages
     public readonly static string GetAll = $"Get All {_messageType}s";
     public readonly static string GetById = $"Get {_messageType} by ID";
     public readonly static string Create = $"Create {_messageType}";
     public readonly static string Update = $"Update {_messageType}";
     public readonly static string Delete = $"Delete {_messageType}";
     #endregion

}
