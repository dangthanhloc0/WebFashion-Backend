using Libs.Helps;
using Libs.Repositories;
using MailKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Services
{
    public class MailServices  
    {
        private readonly IIMail _mail;
        public MailServices(IIMail mail) {
            _mail = mail;
        }    
        public bool sendEmail(MailData Mail_Data, String code) {
            return _mail.SendMail(Mail_Data,code);
        } 
    }
}
