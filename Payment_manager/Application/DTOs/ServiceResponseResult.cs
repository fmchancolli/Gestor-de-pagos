
using Newtonsoft.Json;
using System.Text.Json.Serialization;
namespace Payment_manager.Application.DTOs
{
    public class ServiceResponseResult
    {
        public static ServiceResponse SetOkResponse(string message, object value = null)
        {
            return new ServiceResponse
            {
                Object = value,
                Message = message,
                Status = EStatusResponse.Ok
            };
        }

        public static ServiceResponse SetWarningResponse(string message, object value = null)
        {
            return new ServiceResponse
            {
                Object = value,
                Message = message,
                Status = EStatusResponse.Warning
            };
        }

        public static ServiceResponse SetErrorResponse(string message)
        {
            return new ServiceResponse
            {
                Message = message,
                Status = EStatusResponse.Error
            };
        }
    }
    public class ServiceResponse : IServiceResponse
    {
        public object? Object { get; set; }
        public string Message { get; set; } = string.Empty;
        public EStatusResponse Status { get; set; }

        public T GetObject<T>()
        {
            var result = default(T);
            if (Object != null)
            {
                result = (T)Object;
            }

            return result;
        }
    }
    public interface IServiceResponse
    {
        object? Object { get; set; }
        string Message { get; set; }
        EStatusResponse Status { get; set; }
    }
    public enum EStatusResponse
    {
        Ok = 1,
        Warning = 2,
        Error = 3
    }
    public class ResponseApi
    {
        [JsonProperty(PropertyName = "result")]
        public string Result { get; set; }
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }

}
