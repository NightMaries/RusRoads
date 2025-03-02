using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RusRoads.API.Exceptions
{
    public class ErrorModel
    {
        public int TimeStamp {get;set;}
        public string Message {get;set;} = string.Empty;
        public string ErrorCode{get;set;} = string.Empty;
    }
}