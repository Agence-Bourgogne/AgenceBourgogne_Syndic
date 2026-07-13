using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
namespace TestEvent
{
    public partial class Form1 : Form
    {
        public static SyndicChangedEvent syndicEvent = new SyndicChangedEvent();
        public Form1()
        {
            InitializeComponent();
        }
        public static void AddListener(ChangedEventHandler changed)
        {
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Load += new System.EventHandler(this.GenerericForm_Load);
            form2.Show();
            Form2 form3 = new Form2();
            form3.Load += new System.EventHandler(this.GenerericForm_Load);
            form3.Show();
            Form2 form4 = new Form2();
            form4.Load += new System.EventHandler(this.GenerericForm_Load);
            form4.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void tbImmeuble_TextChanged(object sender, EventArgs e)
        {

        }
        private void GenerericForm_Load(object sender,  EventArgs e)
        {
            if (sender is ISyndicListener)
            {
                ISyndicListener form = (ISyndicListener)sender;
                syndicEvent.Changed += new SyndicChangedEventHandler(form.ChangedReference);
            }
        }
    }
}
