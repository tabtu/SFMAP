using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;
using System.Text;
using System.IO;
using System.Configuration;

// 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service”。

using ttxy.Model;

namespace ttxy
{
    public class Service : IService
    {
        private string local = ConfigurationManager.AppSettings["uploadpath"];

        public String DoWork (String name, String file, int tag)
        {
            return "TuTengxiaoyao" + name + "TuTengxiaoyao" + file + "TuTengxiaoyao" + tag + "TuTengxiaoyao";
        }

        public int UploadFile (String name, String file, int tag)
        {
            byte[] temp = Convert.FromBase64String(file);
            String filename = local + name;

            FileStream fs = null;

            if (tag == 0)
            {
                fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
            }
            else
            {
                fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
            }

            try
            {
                BinaryReader reader = new BinaryReader(new MemoryStream(temp));
                byte[] buffer;
                BinaryWriter writer = new BinaryWriter(fs);
                long offset = fs.Length;
                writer.Seek((int)offset, SeekOrigin.Begin);
                do
                {
                    buffer = reader.ReadBytes(8192);
                    writer.Write(buffer);
                } while (buffer.Length > 0);
                fs.Close();
                return tag;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        public bool UploadStream(Stream file, String filename)
        {
            FileStream fs = new FileStream(local + filename, FileMode.OpenOrCreate);
            try
            {
                BinaryReader reader = new BinaryReader(file);
                byte[] buffer;
                BinaryWriter writer = new BinaryWriter(fs);
                long offset = fs.Length;
                writer.Seek((int)offset, SeekOrigin.Begin);
                do
                {
                    buffer = reader.ReadBytes(1024);
                    writer.Write(buffer);
                } while (buffer.Length > 0);
                fs.Close();
                file.Close();
                return true;
            }
            catch// (Exception e)
            {
                //throw new Exception(e.Message);
                return false;
            }
            finally
            {
                fs.Close();
                file.Close();
            }
        }
    }
}
