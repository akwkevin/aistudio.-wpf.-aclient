using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace AIStudio.Wpf.LocalConfiguration
{
    public class UserConfig : IUserConfig
    {

        public ObservableCollection<LoginInfo> LoginInfo { get; set; }


        public UserConfig()
        {
            LoginInfo = new ObservableCollection<LoginInfo>();
            Initialize();
        }

        private string _path = System.AppDomain.CurrentDomain.BaseDirectory + "Users";
        private string _dir = System.AppDomain.CurrentDomain.BaseDirectory + "Users\\LoginInfo.xml";

        public void Initialize()
        {
            try
            {
                ////获得正在运行类所在的名称空间
                //Type type = MethodBase.GetCurrentMethod().DeclaringType;
                //string _namespace = type.Namespace;
                ////获得当前运行的Assembly
                //Assembly _assembly = Assembly.GetExecutingAssembly();
                ////根据名称空间和文件名生成资源名称
                //string resourceName = _namespace + ".LoginInfo.xml";
                ////根据资源名称从Assembly中获取此资源的Stream
                //Stream stream = _assembly.GetManifestResourceStream(resourceName);
                if (!Directory.Exists(_path))
                {
                    Directory.CreateDirectory(_path);
                }
                if (!File.Exists(_dir))
                {
                    File.Create(_dir);
                }

                List<LoginInfo> list = new List<LoginInfo>();
                try
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(_dir);
                    var xmlNodeList = xmlDoc.SelectSingleNode("Root").ChildNodes;
                    foreach (XmlNode node in xmlNodeList)
                    {
                        XmlElement element = (XmlElement)node;
                        LoginInfo infoItem = new LoginInfo();
                        foreach (XmlNode xmlNode in element.ChildNodes)
                        {
                            XmlElement xmlEle = (XmlElement)xmlNode;
                            if (xmlEle.Name == "UserName")
                            {
                                infoItem.UserName = xmlEle.InnerText;
                            }
                            if (xmlEle.Name == "Password")
                            {
                                infoItem.Password = xmlEle.InnerText;
                            }
                        }
                        list.Add(infoItem);
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

                LoginInfo = new ObservableCollection<LoginInfo>(list);
            }
            catch { }
            finally
            {

            }
        }

        public void AddLoginInfo(LoginInfo info)
        {
            var first = LoginInfo.FirstOrDefault();
            if (first != null && first.UserName == info.UserName && first.Password == info.Password)
                return;

            LoginInfo.Insert(0, info);
            var list = LoginInfo.Distinct(EqualityHelper<LoginInfo>.CreateComparer(p => p.UserName)).ToArray();

            try
            {
                var arrayDataAsXElements = from c in list
                                           select
                                                new XElement
                                                ("LoginInfo",
                                                    new XElement("UserName", c.UserName),
                                                    new XElement("Password", c.Password)
                                                );
                XElement peopleDoc = new XElement("Root", arrayDataAsXElements);
                var doc = new XDocument(peopleDoc);
                doc.Save(_dir);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void WriteConfig(string file, object info)
        {
            if (!Path.IsPathRooted(file))//如果为相对路径，存在默认用户路径下
            {
                file = _path + "\\" + file;
            }

            File.WriteAllText(file, JsonConvert.SerializeObject(info));

        }

        public void WriteConfig(object obj, object info)
        {
            string file = obj.GetType().Name;
            WriteConfig(file, info);
        }


        public T ReadConfig<T>(string file) where T: new()
        {
            if (!Path.IsPathRooted(file))//如果为相对路径，存在默认用户路径下
            {
                file = _path + "\\" + file;
            }

            if (!File.Exists(file))
            {
                return new T();
            }

            var obj = JsonConvert.DeserializeObject<T>(File.ReadAllText(file));
            if (obj == null)
            {
                return new T();
            }
            else
            {
                return obj;
            }
        }

        public T ReadConfig<T>(object obj) where T : new()
        {
            string file = obj.GetType().Name;
            return ReadConfig<T>(file);
        }

    }
}
