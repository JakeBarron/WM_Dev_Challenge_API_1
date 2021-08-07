using System;
using System.Collections.Generic;

#nullable disable

namespace WM_Dev_Challenge_API_1
{
    public partial class Title
    {
        public Title()
        {
            Awards = new HashSet<Award>();
            OtherNames = new HashSet<OtherName>();
            StoryLines = new HashSet<StoryLine>();
            TitleGenres = new HashSet<TitleGenre>();
            TitleParticipants = new HashSet<TitleParticipant>();
        }

        public int TitleId { get; set; }
        public string TitleName { get; set; }
        public string TitleNameSortable { get; set; }
        public int? TitleTypeId { get; set; }
        public int? ReleaseYear { get; set; }
        public DateTime? ProcessedDateTimeUtc { get; set; }

        public virtual ICollection<Award> Awards { get; set; }
        public virtual ICollection<OtherName> OtherNames { get; set; }
        public virtual ICollection<StoryLine> StoryLines { get; set; }
        public virtual ICollection<TitleGenre> TitleGenres { get; set; }
        public virtual ICollection<TitleParticipant> TitleParticipants { get; set; }
    }
}
