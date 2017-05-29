using System;
using System.Net;
using System.Net.Http;

namespace DatePicker.Model
{
    public class ResponseModel : HttpResponseMessage
    {
        public ResponseModel() : base(HttpStatusCode.OK) { }

    }
}
