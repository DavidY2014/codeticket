using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ViewModels
{
    public class ResultMsg<T>
    {
        public int code { get; set; }
        public string messge { get; set; }
        public T data { get; set; }
    }
}
