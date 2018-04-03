using MVPCalculator.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVPCalculator
{
    public partial class Form1 : Form, iViev
    {
        public event Action<object, string> Button_NumericClick;
        public event Action<object, string> Button_OperatorClick;
        public event Action<object> Button_EqualClick;
        public event Action<object> Button_DeleteClick;
        public event Action<object> Button_ClearClick;
        public event Action<object> Button_ComaClick;
        public event Action Initialize;

        public string historyText
        {
            get { return label_history.Text;}
            set { label_history.Text = value; }
        }
        public string operationText
        {
            get { return label_operation.Text; }
            set { label_operation.Text = value; }
        }

        public Form1()
        {
            InitializeComponent();
            if (Initialize != null)
            {
                Initialize();
            }
            
        }

        private void button_Numeric_Click(object sender, EventArgs e)
        {
            if(Button_NumericClick!=null)
            {
                Button but = sender as Button;
                if(but!=null)
                    Button_NumericClick(sender,but.Text);
            }
        }

        private void button_coma_Click(object sender, EventArgs e)
        {
            if (Button_ComaClick != null)
            {
                Button_ComaClick(sender);
            }
        }

        private void button_Operator_Click(object sender, EventArgs e)
        {
            if (Button_OperatorClick != null)
            {
                Button but = sender as Button;
                if (but != null)
                    Button_OperatorClick(sender, but.Text);
            }
        }

        private void button_equal_Click(object sender, EventArgs e)
        {
            if (Button_EqualClick != null)
            {
                Button_EqualClick(sender);
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            if (Button_ClearClick != null)
            {
                Button_ClearClick(sender);
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (Button_DeleteClick != null)
            {
                Button_DeleteClick(sender);
            }
        }
    }
}
