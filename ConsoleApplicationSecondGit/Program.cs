//using log4net;
//using log4net.Config;
using NLog;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationSecondGit
{
    public class Program
    {
        //public static ILog log = LogManager.GetLogger(typeof(Program));  // for Log4net
        public static Logger log = LogManager.GetCurrentClassLogger(); // for NLog
        //public static Logger log = LogManager.GetLogger("rolling0");   // for NLog

        public static void Main(string[] args)
        {
            /*
            string url = "http://localhost:8080/";
            var client = new RestClient(url);
            //var request = new RestRequest("/tokenlifetime", Method.GET);
            //
            var request = new RestRequest("/login", Method.POST);
            request.AddParameter("name", "admin");
            request.AddParameter("password", "qwerty");
            //
            IRestResponse response = client.Execute(request);
            //
            var content = response.Content;
            Console.WriteLine("content: " + content);
            */
            //
            //string startupPath = Directory.GetCurrentDirectory();
            //string startupPath = System.IO.Directory.GetCurrentDirectory();
            //string startupPath = Environment.CurrentDirectory;
            //string startupPath = System.IO.Path.GetFullPath(".\\");
            //string startupPath = Path.GetFullPath(".");
            //string startupPath = Path.GetFullPath(".\\ConsoleApplicationSecondGit.vshost.exe.config");
            //string startupPath = Path.GetDirectoryName(Assembly.GetAssembly(typeof(Program)).CodeBase);
            //string startupPath = new Program().GetType().Assembly.Location; // ../${ProjectName}.exe
            //string startupPath = AppDomain.CurrentDomain.BaseDirectory; // with \
            //Console.WriteLine("startupPath = " + startupPath);
            //
            // StreamWriter writer = new StreamWriter("D:\\important.txt"); // Delete exist, create new
            //StreamWriter writer = new StreamWriter("D:\\important.txt", true); // Appennd
            //writer.Write("Word 3");
            //writer.WriteLine("word 4");
            //writer.WriteLine("Line 5");
            //writer.Close();
            //
            //using (StreamWriter writer = new StreamWriter("D:\\important.txt"))
            //{
            //    writer.Write("Word 110 ");
            //    writer.WriteLine("word 210");
            //    writer.WriteLine("Line 310");
            //}
            //
            //StreamReader reader = new StreamReader("D:\\important.txt");
            //string line;
            //while ((line = reader.ReadLine()) != null)
            //{
            //    // Do something with the line.
            //    Console.WriteLine(line);
            //}
            //reader.Close();
            //
            //string file = File.ReadAllText("D:\\important.txt");
            //Console.WriteLine("Content:\n" + file);
            //
            //string[] lines = File.ReadAllLines("D:\\important.txt");
            //foreach (string line in lines)
            //{
            //    Console.WriteLine(line);
            //}
            //
            // Write a string array to a file.
            //string[] stringArray = new string[] { "cat1", "dog1", "arrow1" };
            //File.WriteAllLines("D:\\file.txt", stringArray); // Delete Exist, Create new file
            //
            //File.WriteAllText("D:\\file.txt", "Dot Net \r\n Perls");
            //
            //File.AppendAllText("D:\\file.txt", "\r\nfirst part\r\n");
            //File.AppendAllText("D:\\file.txt", "second part\r\n");
            //
            //BasicConfigurator.Configure();
            //XmlConfigurator.Configure();
            //
            log.Trace("NLOG: Trace Level test");
            log.Debug("2*Debug Level test");
            log.Info("2*Info Level");
            log.Warn("2*Warn Level");
            log.Error("2*Error Level test");
            //log.Fatal("2*Fatal Level");
            Console.WriteLine("done");
        }
    }
}
