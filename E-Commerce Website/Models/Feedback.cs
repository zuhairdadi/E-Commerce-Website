﻿using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Website.Models
{
    public class Feedback
    {
        [Key]
        public int feedback_id { get; set; }
        public string user_name { get; set; }
        public string user_message { get; set; }

    }
}