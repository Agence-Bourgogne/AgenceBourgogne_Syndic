using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace TestScan
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
//            panel1.
            generate_pdf();
        }

        void axAcroPDF1_SizeChanged(object sender, EventArgs e)
        {
            Console.WriteLine("sizeChanged");
        }

        void axAcroPDF1_OnMessage(object sender, EventArgs e)
        {
            Console.WriteLine("onMessage");
            //            throw new NotImplementedException();
        }
        private void generate_pdf(bool bEditMode = false)
        {
            Cursor.Current = Cursors.WaitCursor;
//            panel1.Visible = false;
//            panel1.Hide();
            Console.WriteLine("started");
            int old = panel1.Width;
            panel1.Width = 0;
            try
            {
                string template = "c:\\dev_pdf\\fichedescriptiveformulaire_decl_2044.pdf";
                //string template = "c:\\dev_pdf\\nom2.pdf";
                string newFile = "c:\\dev_pdf\\test.pdf";
                PdfReader reader = new PdfReader(template);

                
                PdfStamper stamper = new PdfStamper(reader, new FileStream(newFile, FileMode.Create, FileAccess.Write));

                AcroFields fields = stamper.AcroFields;

                //foreach (System.Collections.Generic.KeyValuePair<string, AcroFields.Item> entry in fields.Fields)
                //{
                //    Console.WriteLine("{0} : {1} = ({2})", entry.Key.ToString(), entry.GetType(), entry.Value);
                //}

                fields.SetField("ec_nom", "Vilin Gilles");
                fields.SetField("ec_adresse_dom", "149 Ave F Mistral");
                fields.SetField("ec_ville_dom", "13380 Plan de Cuques");


                fields.SetField("ckImm1_1", "Yes");
                fields.SetField("ckImm1_2", "No");
                fields.SetField("221_imm1", "220");
                fields.SetField("221_imm2", "210");

                stamper.FormFlattening = !bEditMode;
                stamper.Close();
                reader.Close();
                
                //axAcroPDF1.src = newFile;
                //axAcroPDF1.setShowToolbar(true);
                //axAcroPDF1.setView("Fit");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                  
            }
            
            //this.Update();
            //panel1.Visible = true;

            axAcroPDF1.Update();
            panel1.Width = old;
//            panel1.Show();
            
            //this.Invoke(new InvokeDelegate(ShowPanel), panel1);
//            ShowPanel(panel1);
//            Action action = () => panel1.Show();
            //this.Invoke((MethodInvoker)delegate() {
            //    System.Threading.Thread.Sleep(5000);
            //    Console.WriteLine("Invoke");
            //    panel1.Show();
            //});
            //Console.WriteLine("after invoke");
//            this.Invoke(action);
            //SendKeys.Send("{ENTER}");
            //
            Console.WriteLine("ended");
            Cursor.Current = Cursors.Default;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            generate_pdf();
        }
        private delegate void InvokeDelegate(Panel panel);

        public void ShowPanel(Panel panel)
        {
            if (InvokeRequired)
            {
                Console.WriteLine("InvokeRequired");
                Invoke(new InvokeDelegate(ShowPanel), panel);
                return;
            }
            Console.WriteLine("noRequis");
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //panel1.Visible = true;
            if ( !axAcroPDF1.EditMode )
                generate_pdf(true);
        }

        private void Form3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("keyPresses");
        }
    }
}
