﻿namespace NetworkService.Models
{
    public class Email
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string[] Recipients { get; set; }
    }
}
