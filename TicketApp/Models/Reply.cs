using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace TicketApp.Models
{
    public class Reply
    {
        public int Id { get; set; }
   
        public string Name { get; set; }
        
        public string Body { get; set; }

        public DateTime DatePosted { get; set; }

        public int MessageId { get; set; }
    }
}