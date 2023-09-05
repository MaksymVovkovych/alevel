using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkThree
{
    public interface IMoveable 
    {
        public float speed { get; init; }

        void Move (float speed);


    }
}

