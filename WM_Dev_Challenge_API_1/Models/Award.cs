using System;
using System.Collections.Generic;

#nullable disable

namespace WM_Dev_Challenge_API_1
{
    public partial class Award
    {
        public int TitleId { get; set; }
        public bool? AwardWon { get; set; }
        public int? AwardYear { get; set; }
        public string Award1 { get; set; }
        public string AwardCompany { get; set; }
        public int Id { get; set; }

        public virtual Title Title { get; set; }
    }
}
