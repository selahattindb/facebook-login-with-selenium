using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacebookBot
{
    public partial class Form1 : Form
    {
        private IWebDriver driver = (IWebDriver)null;
        private IJavaScriptExecutor js;
        private ChromeOptions options = new ChromeOptions();
        private ChromeDriverService service = ChromeDriverService.CreateDefaultService();
        private System.Windows.Forms.Timer timer1;
        public Form1()
        {
            InitializeComponent();
            CreateBrowser();
        }
        private void CreateBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            ChromeDriverService defaultService = ChromeDriverService.CreateDefaultService();
            defaultService.HideCommandPromptWindow = true;
            this.driver = (IWebDriver)new ChromeDriver(defaultService, options);
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5.0);
            this.js = this.driver as IJavaScriptExecutor;
            timer1 = new Timer();
            this.timer1.Interval = 1000;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.Wait(1000);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            this.driver.Navigate().GoToUrl("https://www.facebook.com/");
            this.Wait(1000);
            IWebElement element = this.driver.FindElement(By.Name("email"));
            element.Clear();
            element.SendKeys("");
            element.SendKeys("email");
            element = driver.FindElement(By.Name("pass"));
            element.Clear();
            element.SendKeys("");
            element.SendKeys("password");
            element = driver.FindElement(By.Name("login"));
            element.Click();
            this.Wait(5000);
        }

        public void Wait(int ms)
        {
            DateTime now = DateTime.Now;
            while ((DateTime.Now - now).TotalMilliseconds < (double)ms)
                Application.DoEvents();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
        }
    }
}
