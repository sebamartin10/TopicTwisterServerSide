using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Errors
{
    public class ResponseTopicTwister
    {
        public int ResponseCode { get; set; } = 0;
        public string ResponseMessage { get; set; } = String.Empty;
    }
}
