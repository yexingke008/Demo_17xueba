using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.Threading;

namespace Demo_17xueba
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //    driver.Navigate().GoToUrl("https://xue.17xueba.com/views/activity/wishes/view.vpage?id=35&type=3&p=5e09a152246cff75f8669c69");  //driver.Url = "http://www.baidu.com"是一样的

            DateTime startTime,ones ;
            startTime = DateTime.Now;

            int count = 100;
            for (int i = 0; i < count; i++)
            {
                try
                {
                    Stopwatch sw = new Stopwatch();

                    using (IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver())
                    {
                        sw.Start();
                        driver.Navigate().GoToUrl("https://xue.17xueba.com/views/activity/wishes/view.vpage?id=35&type=3&p=5e09a152246cff75f8669c69");
                        Thread.Sleep(new Random().Next(2, 10) * 1000);
                        driver.FindElements(By.ClassName("wishes-btn"))[0].Click(); //模拟鼠标点击元素
                        Thread.Sleep(new Random().Next(2, 10) * 1000);

                        var byXPath = driver.FindElements(By.XPath("/html/body/div/section/div/section/div[2]/div[1]/div/div/div[2]/div[3]/div"));

                        sw.Stop();
                        ones = DateTime.Now;
                        TimeSpan tss = startTime.Subtract(ones);
                        Console.WriteLine("\r\n目前点赞票数：" + byXPath[0].Text + "\r\n本次刷票计划点赞票数：" + count + "\r\n本次刷票已点赞票数：" + (i + 1) + "\r\n本次剩余点赞票数：" + (count - i - 1) + "\r\n本次点赞耗时(秒)：" + sw.Elapsed.TotalSeconds.ToString()+"\r\n程序执行时间："+ tss.ToString(@"hh\:mm\:ss"));
                        driver.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\r\n" + ex + "\r\n");
                    //throw;
                }


            }
            Console.WriteLine("\r\n本次刷票结束,按任意键退出");
            Console.ReadLine();
        }
    }
}
