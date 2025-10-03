namespace Payment_manager.Common.Response
{
    public class WebResultModel
    {
        public WebResultModel()
        {
        }

        public WebResultModel(string title, string description, EWebResultStatus status, object data)
        {
            Status = status;
            Message = new WebResultMessage(title, description);
            Data = data;
        }

        public WebResultModel(string title, string description, EWebResultStatus status)
        {
            Status = status;
            Message = new WebResultMessage(title, description);
        }

        public object Data { get; private set; }

        public WebResultMessage Message { get; private set; }

        public EWebResultStatus Status { get; private set; }
    }

    public class WebResultMessage
    {
        public WebResultMessage(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public string Title { get; private set; }

        public string Description { get; private set; }
    }
}
