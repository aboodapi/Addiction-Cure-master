﻿using Addiction_Cure.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.core.Service
{
    public interface IContactUsService
    {
        List<Contactusac> GetAllContactus();
        void createContactus(Contactusac contactusac);
        void updateContactus(Contactusac contactusac);
        void DeleteContactus(int contactusid);
    }
}
