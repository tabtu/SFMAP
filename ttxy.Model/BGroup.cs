using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ttxy.Model
{
    public class BGroup
    {
        private short _ID;
        /// <summary>
        /// 
        /// </summary>
        public short ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _Name;
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private double _Lng;
        /// <summary>
        /// 
        /// </summary>
        public double Lng
        {
            get { return _Lng; }
            set { _Lng = value; }
        }

        private double _Lat;
        /// <summary>
        /// 
        /// </summary>
        public double Lat
        {
            get { return _Lat; }
            set { _Lat = value; }
        }
    }
}
