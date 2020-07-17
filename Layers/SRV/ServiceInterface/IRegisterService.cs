﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Register;

namespace ServiceInterface
{
    public interface IRegisterService
    {
        UserModel GetByName(string name);
        int GetRegisterId(UserModel model);
    }
}
