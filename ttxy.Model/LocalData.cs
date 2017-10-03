using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ttxy.Model
{
    public class LocalData
    {
        private int _ID;
        /// <summary>
        /// index of the data, build automactically. Primary KEY
        /// </summary>
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _Name;
        /// <summary>
        /// the full name of the organization, search from the database, Logic KEY
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private double _Lng;
        /// <summary>
        /// the Lng of the address point, local GPS information.
        /// </summary>
        public double Lng
        {
            get { return _Lng; }
            set { _Lng = value; }
        }

        private double _Lat;
        /// <summary>
        /// the Lat of the address point, local GPS information.
        /// </summary>
        public double Lat
        {
            get { return _Lat; }
            set { _Lat = value; }
        }

        private string _Address;
        /// <summary>
        /// the full address of this organization. 
        /// </summary>
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        private string _Key_W;
        /// <summary>
        /// Key word about the name
        /// </summary>
        public string Key_W
        {
            get { return _Key_W; }
            set { _Key_W = value; }
        }

        private string _Group;
        /// <summary>
        /// 
        /// </summary>
        public string Group
        {
            get { return _Group; }
            set { _Group = value; }
        }

        private string _Type;
        /// <summary>
        /// 
        /// </summary>
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        private string _Tele;
        /// <summary>
        /// 
        /// </summary>
        public string Tele
        {
            get { return _Tele; }
            set { _Tele = value; }
        }

        private string _Pic;
        /// <summary>
        /// 
        /// </summary>
        public string Pic
        {
            get { return _Pic; }
            set { _Pic = value; }
        }

        private string _Des;
        /// <summary>
        /// 
        /// </summary>
        public string Des
        {
            get { return _Des; }
            set { _Des = value; }
        }

        private short _Isused;
        /// <summary>
        /// 
        /// </summary>
        public short Isused
        {
            get { return _Isused; }
            set { _Isused = value; }
        }

        private string _OCW;
        /// <summary>
        /// perpare to describe, some important informations of this organization.
        /// </summary>
        public string OCW
        {
            get { return _OCW; }
            set { _OCW = value; }
        }


    }
}
