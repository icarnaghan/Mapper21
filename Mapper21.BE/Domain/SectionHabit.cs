﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Mapper21.BE.Domain
{
    public class SectionHabit
    {
        public int Id { get; set; }
        public string Context { get; set; }
        public string Description { get; set; }
        public int SectionId { get; set; }

        [ForeignKey("SectionId")]
        public Section Section { get; set; }
    }
}