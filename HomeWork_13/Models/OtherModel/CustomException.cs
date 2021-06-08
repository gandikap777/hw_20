using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13
{
    class CustomException : Exception
    {

        public int Code { get; set; }

        public CustomException(string msg, int code) : base(msg)
        {
            this.Code = code;

            WriteLog(msg);

        }

        /// <summary>
        /// Метод записывает лог в файл
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="path"></param>
        public void WriteLog(string msg, string path = "Error.log")
        {

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"{DateTime.Now.ToString("G")} : Код ошибки: {this.Code} {msg}");
            }

        }

    }
}
