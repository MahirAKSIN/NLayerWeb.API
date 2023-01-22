using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class CustomResposeDto<T>
    {

        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }

        public static CustomResposeDto<T> Success(int statusCode,T data)
        {

            return new CustomResposeDto<T> { Data = data, StatusCode=statusCode};

        }
        public static CustomResposeDto<T> Success(int statusCode)
        {

            return new CustomResposeDto<T> {  StatusCode = statusCode };

        }
        public static CustomResposeDto<T> Fail(int statusCode,List<string> errors)
        {

            return new CustomResposeDto<T> {StatusCode = statusCode,Errors=errors };

        }
        public static CustomResposeDto<T> Fail(int statusCode, string error)
        {

            return new CustomResposeDto<T> { StatusCode = statusCode, Errors = new List<string> { error } };

        } 

    }
}
