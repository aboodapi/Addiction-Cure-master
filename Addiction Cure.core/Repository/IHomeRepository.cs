﻿using Addiction_Cure.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.core.Repository
{
    public interface IHomeRepository
    {
        List<Homepageac> GetAllhome();
        void createhome(Homepageac homepageac);
        void updatehome(Homepageac homepageac);
        void Deletehome(int hid);
    }
}
