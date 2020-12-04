using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Event.Models
{
    public class UserInterestCateogry
    {
        public long id { get; set; }
        public string userId { get; set; }

        [ForeignKey("eventCategory")]
        public long eventCategoryId { get; set; }
        public EventCategory eventCategory { get; set; }
    }
}