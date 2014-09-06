﻿using System;
using System.Collections.Generic;
using Mapper21.Business.Dto;

namespace Mapper21.Business.Interfaces
{
    public interface IStaManager
    {
        IList<StaGridDto> GetStaGrids(Guid id);
        SubSectionStaDto SaveOrUpdate(SubSectionStaDto subSectionSta);
        SubSectionStaDto Find(Guid id);
        bool Delete(Guid id);
    }
}