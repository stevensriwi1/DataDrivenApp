using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataDrivenApp
{
    public class Answers
    {
        public int answerId { get; set; }
        public int? optionId { get; set; }
        public string answerText { get; set; }
        public int userId { get; set; }
        
    }
}