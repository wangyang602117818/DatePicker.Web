using MongoDB.Bson;
using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace DatePicker.Common.Model
{
    public class HttpResponseModel<T> : HttpResponseMessage
    {
        public ResponseModel<T> ResponseModel { get; set; }
        public HttpResponseModel(ErrorCode code, T result) : base(HttpStatusCode.OK)
        {
            ResponseModel = new ResponseModel<T>(code, result);
            Content = new StringContent(ResponseModel.ToJson(), Encoding.UTF8, "application/json");
        }

    }
    
    public class ResponseModel<T>
    {
        public ResponseModel(ErrorCode code, T t)
        {
            this.code = code;
            message = code.ToString();
            result = t;
        }
        public ErrorCode code { get; set; }
        public string message { get; set; }
        public T result { get; set; }
    }
    public enum ErrorCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        success = 0,
        /// <summary>
        /// 记录不存在
        /// </summary>
        record_not_exist = 100,
        /// <summary>
        /// 参数不合法错误，主要针对null值
        /// </summary>
        invalid_params = 101,
        /// <summary>
        /// 参数验证失败，主要正对ModelState验证结果
        /// </summary>
        params_valid_fault = 102,
        /// <summary>
        /// url不存在错误
        /// </summary>
        uri_not_found = 103,
        /// <summary>
        /// 权限错误
        /// </summary>
        error_permission = 104,

        server_exception = -1000,
        unknow_error = -1001,

    }
}
