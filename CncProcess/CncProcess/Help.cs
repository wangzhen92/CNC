﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CncProcess
{
    public class Help
    {
        //返回对象ob中字段data
        public static Object getfield(Object ob, string data)
        {
            System.Type type=ob.GetType();
            return type.GetField(data).GetValue(ob);
        }


    }
}
