using System;
using System.Collections.Generic;
using System.Text;

namespace Alejandria.NotificationService.Contract.Dtos
{
    public class SendEmailRequestDto
    {
        public string To { get; set; }
        public string From { get; set; }
        public object Params { get; set; }
        public Guid TemplateId { get; set; }

    }
}
