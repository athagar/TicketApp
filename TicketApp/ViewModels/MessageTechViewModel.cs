using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicketApp.Models;

namespace TicketApp.ViewModels
{
    public class MessageTechViewModel
    {
        public Message Message { get; set; }
        public List<Tech> Teches { get; set; }
    }
}