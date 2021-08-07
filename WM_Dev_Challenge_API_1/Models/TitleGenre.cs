using System;
using System.Collections.Generic;

#nullable disable

namespace WM_Dev_Challenge_API_1
{
    public partial class TitleGenre
    {
        public int Id { get; set; }
        public int TitleId { get; set; }
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Title Title { get; set; }
    }
}
