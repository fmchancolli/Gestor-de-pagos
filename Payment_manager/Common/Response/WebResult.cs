namespace Payment_manager.Common.Response
{
    public static class WebResult
    {
        public static WebResultModel AddData(object data, string title = "", string description = "")
        {
            return new WebResultModel(title, description, EWebResultStatus.Info, data);
        }

        public static WebResultModel Info(string title, string description = "")
        {
            return new WebResultModel(title, description, EWebResultStatus.Info);
        }

        public static WebResultModel Success(string title, string description)
        {
            return new WebResultModel(title, description, EWebResultStatus.Success);
        }
        public static WebResultModel SuccessAndData(string title, string description, object data)
        {
            return new WebResultModel(title, description, EWebResultStatus.Success, data);
        }

        public static WebResultModel Warning(string title, string description)
        {
            return new WebResultModel(title, description, EWebResultStatus.Warning);
        }

        public static WebResultModel Error(string title, string description)
        {
            return new WebResultModel(title, description, EWebResultStatus.Error);
        }
    }
}
