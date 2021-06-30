using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Errors
{
    public class ResponseTopicTwister<T>
    {
        public string DtoName { get { return typeof(T).FullName; } }
        public T Dto { get; set; }
        public int ResponseCode { get; set; } = 0;
        public string ResponseMessage { get; set; } = string.Empty;

        public ResponseTopicTwister() {
        }

        public ResponseTopicTwister(T Dto, int ResponseCode = 0, string ResponseMessage = "") {
            this.Dto = Dto;
            this.ResponseCode = ResponseCode;
            this.ResponseMessage = ResponseMessage;
        }
    }
}
