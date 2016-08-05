﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GF.Manager.Contract
{
    public class PluginItemMetadataAttribute : MetadataBaseAttribute
    {
        public string Collection { get; set; }

        public string View { get; set; }

        public PluginItemType Type { get; set; }
    }
}