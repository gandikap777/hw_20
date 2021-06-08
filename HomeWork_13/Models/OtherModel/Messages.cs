using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Models
{
    public class Messages
    {
        /// <summary>
        /// IDENTITY
        /// </summary>
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Message
        /// </summary>
        private string msg;

        public string MSG
        {
            get { return msg; }
            set { msg = value; }
        }

        /// <summary>
        /// client identity
        /// </summary>
        private int idclient;

        public int IdClient
        {
            get { return idclient; }
            set { idclient = value; }
        }


        public Messages() { }

    }
}
