using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch.AppCore.DTOs
{
    public record ResponseDto<T>
    {
        public T? Data { get; set; }

        public List<string>? Errors { get; set; }

        public HttpStatusCode Status { get; set; }


        //static factory
        public static ResponseDto<T> Success(T Data, HttpStatusCode status)
        {
            return new ResponseDto<T> { Data = Data, Status = status };
        }

        public static ResponseDto<T> Fail(List<string> errors, HttpStatusCode status)
        {
            return new ResponseDto<T> { Errors = errors, Status = status };
        }

    }
}
