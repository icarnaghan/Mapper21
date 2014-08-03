﻿using System;
using System.Collections.Generic;
using Mapper21.BE.Domain;

namespace Mapper21.DAL.Interfaces
{
    public interface ISectionRepository : IDisposable
    {
        IEnumerable<Section> GetAll();
        Section GetByGrade(int id, int type, string year);
        void InsertorUpdate(Section section);
        Section Find(int? id);
        bool Delete(int id);
        void Save();
    }

}