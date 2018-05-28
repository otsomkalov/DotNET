using System.Collections.Generic;
using Lab5.Models;

namespace Lab5.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Message> Messages { get; set; }
        public Message Message { get; set; }
    }
}