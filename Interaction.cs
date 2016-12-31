using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_Scratch
{
    public class Interaction: NotifyPropertyChanged
    {         
        private Singleton InteractionInstance = Singleton.Instance;

        public void SelectedExpenseEntry_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Console.Write("You made it boss");
        }
    }
}
