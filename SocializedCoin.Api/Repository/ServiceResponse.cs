using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SocializedCoin.Api.Repository
{
    [Serializable]
    public class ServiceResponse<T>
    {
        public ServiceResponse(HttpContext context)
        {
            Data = new List<T>();                       
        }
        /// <summary>
        /// Is there Any Exception
        /// </summary>
        public bool HasExceptionError { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ExceptionMessage { get; set; }

        public IEnumerable<T> Data { get; set; }

        [JsonProperty]
        public T Entity { get; set; }

        public int Count { get; set; }
        
        /// <summary>
        /// is there any error after Update, Insert  
        /// </summary>
        public bool IsValid => !HasExceptionError && string.IsNullOrEmpty(ExceptionMessage);

        public bool IsSuccessful { get; set; }       

        
    }
}