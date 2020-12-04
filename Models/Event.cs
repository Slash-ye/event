using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Event.Models
{
    public class Event : MainModel
    {
        public string subject { get; set; }
        public string description { get; set; }
        public int eventStatus { get; set; }
        public string Image { get; set; }

        [ForeignKey("eventCategory")]
        public long eventCategoryId { get; set; }
        public EventCategory eventCategory { get; set; }
    }
}