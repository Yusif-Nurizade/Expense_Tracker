using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_Scratch
{
    public class Session : NotifyPropertyChanged
    {
        private static Session instance;
        public static Session Instance
        {
            get
            {
                if (instance == null)
                    instance = new Session();
                return instance;
            }
        }

        private Session()
        {

        }
    }
}
