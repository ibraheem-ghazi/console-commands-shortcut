using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ConsoleCommandsShortcut.Helpers
{
    internal class GeneralHelper
    {
        private static String STREAM_PATH = "commands.xml";

        internal static String IncludePath { get; set; } = @"C:\ProgramData\ConsoleCommandsShortcut\Commands\";

        internal static void CheckIncludePath()
        {
            if (!Directory.Exists(IncludePath))
            {
                Directory.CreateDirectory(IncludePath);
            }
            String PathEnv = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine);
            if (!PathEnv.Contains(IncludePath))
                Environment.SetEnvironmentVariable("PATH", ";" + PathEnv + IncludePath + ";", EnvironmentVariableTarget.Machine);
        }

        internal static void SaveData(IBindingList list)
        {
            try
            {
                
                // Serialize     
                XmlSerializer vXmlSerializer = new XmlSerializer(list.GetType());
                Stream fs = new FileStream(STREAM_PATH, FileMode.Create);
                vXmlSerializer.Serialize(fs, list);
                fs.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(null, e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        internal static T LoadData<T>()
        {
            T LoadedList=default(T); //default usually is null

            if (File.Exists(STREAM_PATH))
            {
                try
                {
                    XmlSerializer vXmlSerializer = new XmlSerializer(typeof(T));
                    Stream fs = new FileStream(STREAM_PATH, FileMode.Open);
                    LoadedList = (T)vXmlSerializer.Deserialize(fs);
                    fs.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(null, e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            

            return (T)LoadedList ;
        }
    }
}
