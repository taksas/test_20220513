using AngleSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            for (int i = 1; i <= 60; i++)
            {
                //Cookieを有効化?
                var config = Configuration.Default.WithDefaultLoader(); // WithDefaultCookies()を追加
                var context = BrowsingContext.New(config);
                //URLを取得
                string hi = "https://tabelog.com/rstLst/sushi/" + i + "/";
                var document = await context.OpenAsync(hi);


                //Debug.WriteLine(hi);
                //Debug.WriteLine(document.Title);
                Debug.WriteLine("started");

                try
                {
                    //var classpList1 = document.GetElementsByClassName("list-rst__rst-name-target cpy-rst-name");
                    // var classpList1 = document.GetElementsByClassName("dimmed_text");
                    var classpList1 = document.QuerySelectorAll("href[class^='list-rst__rst-name-target cpy-rst-name']");
                    //var classpList2 = document.QuerySelectorAll("div[href^='https://kadai-moodle.kagawa-u.ac.jp/course/view.php?id=']");


                    foreach (var item in document.GetElementsByClassName("list-rst__rst-name-target cpy-rst-name"))
                    {
                        Debug.WriteLine(item.GetAttribute("href"));
                    }
                    /*

                                        for (var j = 0; j < classpList1.Length; j++)
                                            {
                                                var c = classpList1[j];

                                            Debug.WriteLine(c);

                                        }
                    */
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
        }
    }
}
