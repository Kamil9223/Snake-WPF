﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeWPF.Models
{
    class Food
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Food(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
