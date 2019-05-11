using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicketApp.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTime DatePosted { get; set; }

        public virtual ICollection<Reply> Replies { get; set; }

        public Tech Tech { get; set; }

        [Display(Name = "Tech Name")]
        public int TechId { get; set; }
    }
}