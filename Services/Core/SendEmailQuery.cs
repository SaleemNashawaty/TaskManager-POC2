using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace TaskManager.Services.Core
{
    public class SendEmailQuery:IRequest
    {
        public List<string> Recipients { get; set; }
        public string Message { get; set; }
        public SendEmailQuery(List<string> recipients, string message)
        {
            Recipients = recipients;
            Message = message;
        }
    }
}
