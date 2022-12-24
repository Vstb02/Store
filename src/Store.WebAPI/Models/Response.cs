using Microsoft.AspNetCore.Http;

namespace Store.WebAPI.Models
{
    public class Response<T>
    {
        public T? Value { get; set; }
        public string? Message { get; set; }
        public bool Succeeded { get; set; }
        public int StatusCode { get; set; }

        internal Response(int statusCode, T value)
        {
            Value = value;
            Succeeded = true;
            StatusCode = statusCode;
        }

        internal Response(int statusCode, string message)
        {
            Value = default(T);
            Message = message;
            Succeeded = false;
            StatusCode = statusCode;
        }

        public static Response<T> Success(int statusCode, T value)
        {
            return new Response<T>(statusCode, value);
        }

        public static Response<T> Failure(int statusCode, string errors)
        {
            return new Response<T>(statusCode, errors);
        }
    }
}
