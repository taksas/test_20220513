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
using AngleSharp.Html.Parser;
using AngleSharp.Html.Dom;
using AngleSharp.Dom;
using Jitbit.Utils;
using System.Text.RegularExpressions;
using System.Net;
using System.Runtime.InteropServices;


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





        private async void button2_Click(object sender, EventArgs e)
        {
            var myExport = new CsvExport();

            int[,] label = new int[100, 2];
            int pricerange = 0;


            foreach (string line in System.IO.File.ReadLines(@"C:\Users\Public\Documents\outfile2.txt"))  //店舗URL設定
            {

                //Cookieを有効化?
                var config = Configuration.Default.WithDefaultLoader(); // WithDefaultCookies()を追加
                var context = BrowsingContext.New(config);
                var document = await context.OpenAsync(line + "dtlmenu/");



                


                try
                {

                    foreach (var item in document.GetElementsByClassName("rstdtl-menu-lst__contents"))
                    {
                        foreach (var item2 in item.GetElementsByClassName("js-imagebox-trigger"))
                        {
                            if (item2.GetAttribute("href") != null)
                            {
                                foreach (var itemname in item.GetElementsByClassName("rstdtl-menu-lst__menu-title")) {  
                                    foreach (var itemprice in item.GetElementsByClassName("rstdtl-menu-lst__price"))
                                    {
                                        foreach (string line2 in System.IO.File.ReadLines(@"C:\Users\Public\Documents\neta3.txt"))
                                        {

                                                if (itemname.TextContent.Contains(line2.Remove(0, 2))

                                                

                                                && !itemname.TextContent.Contains("刺")
                                                && !itemname.TextContent.Contains("さしみ")
                                                && !itemname.TextContent.Contains("手作り")
                                                && !itemname.TextContent.Contains("サラダ")
                                                && !itemname.TextContent.Contains("焼")
                                                && !itemname.TextContent.Contains("丼")
                                                && !itemname.TextContent.Contains("比べ")
                                                && !itemname.TextContent.Contains("飯")
                                                && !itemname.TextContent.Contains("まき")
                                                && !itemname.TextContent.Contains("巻")
                                                && !itemname.TextContent.Contains("切")
                                                && !itemname.TextContent.Contains("g")
                                                && !itemname.TextContent.Contains("本")
                                                && !itemname.TextContent.Contains("個")
                                                && !itemname.TextContent.Contains("鍋")
                                                && !itemname.TextContent.Contains("汁")
                                                && !itemname.TextContent.Contains("鉢")
                                                && !itemname.TextContent.Contains("蒸")
                                                && !itemname.TextContent.Contains("膳")
                                                && !itemname.TextContent.Contains("塩辛")
                                                && !itemname.TextContent.Contains("たこわさ")
                                                && !itemname.TextContent.Contains("活")
                                                && !itemname.TextContent.Contains("雑炊")
                                                && !itemname.TextContent.Contains("ザンギ")
                                                && !itemname.TextContent.Contains(" ハラス")
                                                && !itemname.TextContent.Contains("のせ")
                                                && !itemname.TextContent.Contains("げそ")
                                                && !itemname.TextContent.Contains("ゲソ")
                                                && !itemname.TextContent.Contains("「")
                                                && !itemname.TextContent.Contains("」")
                                                && !itemname.TextContent.Contains("『")
                                                && !itemname.TextContent.Contains("』")
                                                && !itemname.TextContent.Contains("【")
                                                && !itemname.TextContent.Contains("】")

                                                && itemname.TextContent

                                                .Replace(line2.Remove(0, 2), "")
                                                .Replace("寿司", "")
                                                .Replace("握り", "")
                                                .Replace("道産", "")
                                                .Replace("県産", "")
                                                .Replace("国産", "")
                                                .Replace("産", "")
                                                .Replace("まぐろ", "")
                                                .Replace("マグロ", "")
                                                .Replace("鮪", "")
                                                .Replace("生", "")
                                                .Replace("本", "")
                                                .Replace("本場", "")
                                                .Replace("名物", "")
                                                .Replace("赤身", "")
                                                .Replace("身", "")
                                                .Replace("トロ", "")
                                                .Replace("とろ", "")
                                                .Replace("名物", "")
                                                .Replace("特上", "")
                                                .Replace("上", "")




                                                .Length <= 3

                                                )
                                            {
                                                
                                                var sushilabel = line2.Substring(0, 2).Replace("/", "");
                                                string itempricestr = Regex.Replace(itemprice.TextContent, @"[^0-9]", "");

                                                if ( Int32.Parse(itempricestr) >= 1000) 
                                                { 
                                                    pricerange = 1; 
                                                } else {
                                                    pricerange = 0; 
                                                }


                                                DirectoryInfo di = new DirectoryInfo($"{"C:\\Users\\Public\\Documents\\sushi\\" + sushilabel.ToString() + "\\" + pricerange.ToString() }");
                                                di.Create();


                                                WebClient wc = new WebClient();
                                                try
                                                {
                                                    wc.DownloadFile(item2.GetAttribute("href"), $"{"C:\\Users\\Public\\Documents\\sushi\\" + sushilabel.ToString() + "\\" + pricerange.ToString() + "\\" + label[Int32.Parse(sushilabel), pricerange].ToString() + ".jpg"}");

                                                }
                                                catch (WebException)
                                                {
                                                    throw;
                                                }
                                                /*
                                                var doc = new Aspose.Words.Document();
                                                var builder = new DocumentBuilder(doc);
                                                var shape = builder.InsertImage("C:\\Users\\Public\\Documents\\sushi\\" + num + ".jpg");
                                                shape.ImageData.Save("C:\\Users\\Public\\Documents\\sushi\\" + num + ".png");
                                                */
                                                //var imgArray = LoadImage("C:\\Users\\Public\\Documents\\sushi\\" + num++ + ".jpg");

                                                Debug.WriteLine($"{sushilabel + "\\" + pricerange + "\\" + label[Int32.Parse(sushilabel), pricerange] + ".jpg"}／{itemname.TextContent}／{sushilabel}／{itempricestr}");


                                                myExport.AddRow();
                                                myExport["imagehere"] = sushilabel + "\\" + pricerange + "\\" + label[Int32.Parse(sushilabel), pricerange]++ + ".jpg";
                                                myExport["name"] = itemname.TextContent;
                                                myExport["label"] = sushilabel;
                                                myExport["price"] = itempricestr;

                                                break;
                                            
                                            }
                                        }
                                    }
                                }
                            }
                            


                        }


                    }

                }
                catch (System.Exception)
                {
                    throw;
                }
                File.WriteAllBytes("C:\\Users\\Public\\Documents\\traindata1.csv", myExport.ExportToBytes());
            }


            
        }

    }
}
