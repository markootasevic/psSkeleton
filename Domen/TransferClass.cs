using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class TransferClass
    {
        public object TransferObject { get; set; }
        public int Operation { get; set; }
    }

    public enum Operations
    {
        End = 1
    }
}
