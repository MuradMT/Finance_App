namespace api.Constants;

public static class ConstantMessages
{

    #region Comment Validation Messages
    public const string Title_Not_Empty = "Title is required";
    public const string Content_Not_Empty = "Content is required";

    public const string Title_Min_Length = "Title length must be at least 5 characters";
    public const string Content_Min_Length = "Content length must be at least 5 characters";

    public const string Title_Max_Length = "Title can not be over 280 characters";
    public const string Content_Max_Length = "Content can not be over 280 characters";
    
    #endregion

    #region Stock Validation Messages

    public const string Symbol_Not_Empty = "Symbol is required";
    public const string Company_Name_Not_Empty = "Company Name is required";
    public const string Purchase_Not_Empty = "Purchase is required";
    public const string Last_Div_Not_Empty = "Last Div is required";
    public const string Industry_Not_Empty = "Industry is required";
    public const string Market_Cap_Not_Empty = "Market Cap is required";

    public const string Purchase_Range="Purchase must be between 1 and 1000000000";
    public const string Last_Div_Range="Last Divident must be between 0.001 and 100";
    public const string Market_Cap_Range="Market Cap must be between 1 and 5000000000";

    public const string Symbol_Max_Length = "Symbol can not be over 10 characters";
    public const string Company_Name_Max_Length = "Company Name can not be over 10 characters";
    public const string Industry_Max_Length = "Industry can not be over 10 characters";

    #endregion
}
