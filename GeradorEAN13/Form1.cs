using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GeradorEAN13
{
    public partial class Form1 : Form
    {
        //WaitWndFun waitForm = new WaitWndFun();
        //waitForm.Show(this);
        //waitForm.Close();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string link = string.Format(@"{0}", textBox1.Text);
            webBrowser1.Url = new Uri(link);
            contador = 0;
        }

        int contador = 0;

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            ////se vazio
            //if (webBrowser1.Url.AbsoluteUri == "about:blank") return;

            //if (string.IsNullOrEmpty(textBox1.Text))
            //{
            //    return;
            //}
            ////-----------------



            //foreach (HtmlElement item in webBrowser1.Document.All)
            //{
            //    var lkjljlj = item.InnerHtml;
            //    if (item.InnerHtml == "<!DOCTYPE html PUBLIC \"\" \"\">")
            //        continue;

            //    if (item.TagName == "META") return;
            //    if (item.TagName == "HEAD") return;
            //    if (item.TagName == "") return;
            //    if (item.Name == "") return;

            //    if (item.Name == "codes")
            //    {
            //        webBrowser1.Document.GetElementsByTagName("textarea")[0].InnerText = textBox2.Text.ToString();
            //        webBrowser1.Document.GetElementsByTagName("textarea")[0].InnerText = "teste";
            //    }
            //    //<input class="tr-all-05-ease" type="submit" name="submit" value="Generate">
            //    if (item.Name == "submit")
            //    {
            //        if (item.OuterHtml.Contains("Generate"))
            //        {
            //            contador++;
            //            //if (contador <= 28) return;


            //            item.Focus();
            //            //webBrowser1.Stop();
            //            //SendKeys.Send("{ENTER}");
            //            return;
            //        }
            //    }

            //    //Barcode
            //    //< h3 > Barcode < span class="cname">EAN-13</span>: 7898348600869 (1 / 30)</h3>
            //    if (item.TagName == "h3" || item.Name == "h3")
            //    {
            //        if (item.InnerText.Contains("Barcode") || item.InnerText.Contains("EAN-13"))
            //        {

            //        }
            //    }
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string novoValor = string.Empty;
            foreach (HtmlElement item in webBrowser1.Document.GetElementsByTagName("h3"))
            {
                if (item.InnerText.Contains("Barcode EAN-13:"))
                {

                    string valor = item.InnerText.Replace("Barcode EAN-13: ", "");
                    valor = valor.Substring(0, 13);
                    novoValor += valor + "\n";
                }
            }
            textBox3.Text = novoValor;
            Clipboard.SetText(novoValor);
            webBrowser1.Stop();
            //this.Close();
        }
    }
}
