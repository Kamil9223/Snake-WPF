using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeWPF.Models
{
    class Snake
    {
        public List<SnakeElement> Tail { get; set; }
        public SnakeElement Head { get; set; }

        public Snake(int headX, int headY)
        {
            Head = new SnakeElement(headX, headY);
            Tail = new List<SnakeElement>();
        }
    }
}
