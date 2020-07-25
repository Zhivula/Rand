using Rand.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rand.Model
{
    class MainWindowModel
    {
        private int start;
        private int finish;
        private int count;
        public MainWindowModel(int start, int finish, int count)
        {
            this.start = start;
            this.finish = finish;
            this.count = count;
        }
        public List<int> GetList()
        {
            Random rand = new Random();
            var list = new List<int>(count);
            finish++;//finish+1 - это чтобы было включительное значение, по умолчанию не включительно 
            for(var i = 0; i < count; i++) list.Add(rand.Next(start, finish));
            return list;
        }
    }
}
