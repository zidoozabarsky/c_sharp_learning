﻿using System;

namespace Dodo.ExtractAndOverride
{
    public class Terminal
    {
        public virtual void PrintLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
