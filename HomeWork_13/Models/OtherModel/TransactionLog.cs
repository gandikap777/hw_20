using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13
{
    static class TransactionLog
    {
        private static uint TransactionID;
                
        /// <summary>
        /// Запись сообщение в файл
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="path"></param>
        public static void WriteTransactionLog(string msg, string path = "default.log")
        {

            using (StreamWriter sw = new StreamWriter(path,true))
            {
                sw.WriteLine($"{TransactionLog.TransactionID += 1} : #{DateTime.Now.ToString("G")}# {msg}");
            }

        }

    }


    /// <summary>
    /// Расширение функционала транзакций
    /// </summary>
    public static class ExtTransacion
    {
        /// <summary>
        /// Метод записывает строку в файл лога транзакций
        /// </summary>
        /// <param name="msg"></param>
        public static void Log(this string msg)
        {
            TransactionLog.WriteTransactionLog(msg, "log.txt");
        }
    }
}
