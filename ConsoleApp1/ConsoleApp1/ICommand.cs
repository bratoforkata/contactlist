﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface ICommand
    {
        void Execute(Queue<string> commandQueue);
    }
}
