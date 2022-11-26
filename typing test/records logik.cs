
using System.Diagnostics.Metrics;
using System.Text.Json.Nodes;
using System.Xml.Serialization;

namespace typing_test
{
    internal class records_logik
    {
        public static void records(string name, int minute,double seconds)
        { 
            string path = "C:\\Users\\geday\\OneDrive\\Рабочий стол\\рекорды.xml";
            if (File.Exists(path))
            {
                List<record> recordes = new List<record>();
                XmlSerializer xml = new XmlSerializer(typeof(List<record>));
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    recordes = (List<record>)xml.Deserialize(fs);
                }
                string[] file = new string[3+recordes.Count*3];
                file[0] = name; file[1] = Convert.ToString(minute); file[2] = Convert.ToString(seconds);
                int i = 3;
                foreach(record record in recordes)
                {
                    file[i]=record.user_name;
                    i++;
                    file[i]=Convert.ToString(record.user_record_in_minute);
                    i++;
                    file[i] = Convert.ToString(record.user_record_in_second);
                    i++;
                }
                i = 0;
                foreach(string files in file)
                {
                    if (i == 0)
                    {
                        Console.WriteLine("\t\t\t\t\t\tИмя:"+files);
                        i++;
                    }
                    else if (i == 1)
                    {
                        Console.WriteLine("\t\t\t\t\t\tсимволов в минуту:" + files);
                        i++;
                    }
                    else if (i == 2)
                    {
                        Console.WriteLine("\t\t\t\t\t\tстрок в секунду:" + files);
                        i = 0 ;
                    }
                    
                }
                i= 0;
                List<record> records_list = new List<record>();
                while (i != 3 + recordes.Count * 3)
                {
                    record first = new record();
                    first.user_name = file[i];
                    i++;
                    first.user_record_in_minute = Convert.ToInt32(file[i]);
                    i++;
                    first.user_record_in_second = Convert.ToDouble(file[i]);
                    i++;
                    records_list.Add(first);
                }
                
                XmlSerializer xmlser = new XmlSerializer(typeof(List<record>));
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    xml.Serialize(fs, records_list);
                }
            }
            else
            {
                Console.WriteLine("\t\t\t\t\t\tимя:" + name+ "\n\t\t\t\t\t\t" + minute+" Символов в минуту"+ "\n\t\t\t\t\t\t" + seconds+" символов в секунду");
                XmlSerializer xml = new XmlSerializer(typeof(List<record>));
                record recordes = new record();
                recordes.user_name = name;
                recordes.user_record_in_minute = Convert.ToInt32(minute);
                recordes.user_record_in_second = Convert.ToDouble(seconds);
                List<record> records_list = new List<record>();
                records_list.Add(recordes);
                XmlSerializer xmlser = new XmlSerializer(typeof(List<record>));
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    xml.Serialize(fs, records_list);
                }
            }
        }
    }
}
