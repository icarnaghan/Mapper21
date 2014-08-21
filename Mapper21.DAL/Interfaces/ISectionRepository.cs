﻿using System;
using System.Collections.Generic;
using Mapper21.BE.Domain;
using Mapper21.BE.Domain.LookUps;

namespace Mapper21.DAL.Interfaces
{
    public interface ISectionRepository : IDisposable
    {
        void InsertorUpdate(Section section);
        Section GetSection(string gradeLevel, string year, string sectionType);
        Section Find(Guid id);
        bool Delete(Guid id);
        void Save();
    }

}