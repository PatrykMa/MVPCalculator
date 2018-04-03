using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVPCalculator.interfaces
{
    interface iViev
    {

        event Action<object, string> Button_NumericClick;
        event Action<object, string> Button_OperatorClick;
        event Action<object> Button_EqualClick;
        event Action<object> Button_DeleteClick;
        event Action<object> Button_ClearClick;
        event Action<object> Button_ComaClick;
        event Action Initialize;

        string historyText { get; set; }
        string operationText { get; set; }
    }
}
