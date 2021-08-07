using System;
using System.Collections.Generic;

#nullable disable

namespace WM_Dev_Challenge_API_1
{
    public partial class StoryLine
    {
        public int TitleId { get; set; }
        public string Type { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }

        public virtual Title Title { get; set; }
    }
}
