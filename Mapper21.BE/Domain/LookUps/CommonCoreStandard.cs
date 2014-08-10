﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Mapper21.BE.Domain.LookUps
{
    public class CommonCoreStandard
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string GradeLevelId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Strand { get; set; }
        public string SubCategory { get; set; }
        public string Domain { get; set; }
        public string ClusterStatement { get; set; }

        [ForeignKey("GradeLevelId")]
        public GradeLevel GradeLevel { get; set; }
    }
}