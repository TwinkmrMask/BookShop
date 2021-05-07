using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_14._04
{
    interface IDefaultSettings
    {
        public string path { get { return "../../../Resources/"; } }
        public (string links, string data) data { get { return ("links", "database"); } }
    }
}
