﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProjectBusinessLogic
{
   public class MyDatTime : IDateTime
    {
        public DateTime Now()
        {
           return DateTime.Now;
            
        }
    }
}
