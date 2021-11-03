using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;

namespace Api.Infra.CrossCutting.Logger
{
    public class LoggerPrint
    {
        public static void WriteLog(string type, HttpContext httpContext, Exception exception)
        {
            var folder = Path.Combine("Resources", "Logs");
            var fileName = DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss.fffffff") + ".txt";
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folder, fileName);

            StringBuilder log = new StringBuilder();

            FileInfo file = new FileInfo(pathToSave);

            switch (type)
            {
                case "HTTP":
                    var request = httpContext.Request;
                    var response = httpContext.Response;

                    log.Append("[" + DateTime.Now.TimeOfDay + "] ").Append(type + " ")
                        .Append(request.Host + " ").Append(request.Protocol);
                    break;
                case "REST ERROR":
                    log.Append("[" + DateTime.Now.TimeOfDay + "] ").Append(type + " ")
                        .Append(exception.Message + " ").Append(exception.StackTrace);
                    break;
                case "SERVER ERROR":
                    log.Append("[" + DateTime.Now.TimeOfDay + "] ").Append(type + " ")
                        .Append(exception.Message + " ").Append(exception.StackTrace);
                    break;
            }

            if (file != null)
            {
                using (StreamWriter outputFile = new StreamWriter(pathToSave, true))
                {
                    outputFile.WriteLine(log);
                }
            }
            else
            {
                using (StreamWriter outputFile = new StreamWriter(pathToSave))
                {
                    outputFile.WriteLine(log);
                }
            }
        }
    }
}
