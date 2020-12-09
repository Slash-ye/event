using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Event.Models
{
    public class UserParticipantsEvent
    {
        public long id { get; set; }
        public string userId { get; set; }
        public type type { get; set; }

        [ForeignKey("events")]
        public long eventId { get; set; }
        public Event events { get; set; }
    }


    public enum type
    {
        Intersting = 1,
        Goning = 2,
    }
}