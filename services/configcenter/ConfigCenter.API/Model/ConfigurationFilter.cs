﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigCenter.API.Model
{
    public class ConfigurationFilter
    {
        public string Environment { set; get; }

        public string AppId { set; get; }
    }
}
