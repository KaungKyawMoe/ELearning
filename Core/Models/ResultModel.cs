using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ResultModel<T> where T : class
    {
        public T Data { get; set; }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }
}
