using MongoDB.Bson;
using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace DatePicker.Model
{
    public class HttpResponseModel<T> : HttpResponseMessage
    {
        public ResponseModel<T> ResponseModel { get; set; }
        public HttpResponseModel(ErrorCode code, T result) : base(HttpStatusCode.OK)
        {
            ResponseModel = new ResponseModel<T>
            {
                code = code,
                message = code.ToString(),
                result = result
            };
            string res = ResponseModel.ToJson();
            Content = new StringContent(res, Encoding.UTF8, "application/json");
        }

    }
    public class ResponseModel<T>
    {
        public ErrorCode code { get; set; }
        public string message { get; set; }
        public T result { get; set; }
    }
    public enum ErrorCode
    {
        success = 0,

    }
}
