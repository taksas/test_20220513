using AngleSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Csv;
using AngleSharp.Html.Parser;
using AngleSharp.Html.Dom;

namespace test_20220513
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {


            //Cookieを有効化?
            var config1 = Configuration.Default.WithDefaultLoader(); // WithDefaultCookies()を追加
            var context1 = BrowsingContext.New(config1);
            //URLを取得
            string hi1 = "https://tabelog.com/rstLst/sushi/1/";
            var document1 = await context1.OpenAsync(hi1);





            try
            {



                foreach (var item1 in document1.GetElementsByClassName("list-balloon__recommend-target"))
                {
                    string tdfk = item1.GetAttribute("href");

                    for (int i = 1; i <= 60; i++)
                    {
                        //Cookieを有効化?
                        var config = Configuration.Default.WithDefaultLoader(); // WithDefaultCookies()を追加
                        var context = BrowsingContext.New(config);
                        //URLを取得
                        string hi = tdfk + i + "/";
                        var document = await context.OpenAsync(hi);


                        try
                        {

                            foreach (var item in document.GetElementsByClassName("list-rst__rst-name-target cpy-rst-name"))
                            {
                                Debug.WriteLine(item.GetAttribute("href"));

                            }

                        }
                        catch (System.Exception)
                        {
                            throw;
                        }

                    }

                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        // htmlパーサー
        private static HtmlParser parser = new HtmlParser();


        private async void button2_Click(object sender, EventArgs e)
        {
            foreach (string line in System.IO.File.ReadLines(@"C:\Users\Public\Documents\outfile1.txt"))
            {

                //Cookieを有効化?
                var config = Configuration.Default.WithDefaultLoader(); // WithDefaultCookies()を追加
                var context = BrowsingContext.New(config);
                var document = await context.OpenAsync(line + "dtlmenu/");
                IHtmlDocument ParserList = (IHtmlDocument)await parser.ParseDocumentAsync(document);

                try
                {

                    foreach (var item in ParserList.GetElementsByClassName("rstdtl-menu-lst__contents"))
                    {

                            Debug.WriteLine($"{item.GetAttribute("href")}こん{item.GetAttribute("href")}");


                    }

                }
                catch (System.Exception)
                {
                    throw;
                }
            }
        }
    }
}
