﻿using System;

namespace Mapper21.UI.Models
{
    public class AssessmentViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid SubSectionStaId { get; set; }
    }
}