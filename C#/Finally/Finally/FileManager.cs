using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Finally
{
    class FileManager : Observer
    {
        string FilePath = "";


        public void SaveFile(Noot ourTask)
        {
            
            FileStream file = new FileStream("1.dat", FileMode.Create, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(file);
            writer.Write(ourTask.AllTask.Count());
            for (int i = 0; i < ourTask.AllTask.Count(); i++)
            {
                writer.Write(ourTask.AllTask[i].Tage);
                writer.Write(ourTask.AllTask[i].Task);
                writer.Write(ourTask.AllTask[i].priority);
                writer.Write(ourTask.AllTask[i].dateTime.ToString());
            }
            writer.Close();
            file.Close();
        }
        public void LoadFile(ref Noot ourTask)
        {
            FileStream file = new FileStream("1.dat", FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(file);
            int count = reader.ReadInt32();
            ourTask = new Noot();
            ourTask.AllTask = new List<TaskList>(count);
            TaskList one;
            for (int i = 0; i < count; i++)
            {
                one.Tage = reader.ReadString();
                one.Task = reader.ReadString();
                one.priority = reader.ReadInt32();
                one.dateTime = DateTime.Parse(reader.ReadString());
                ourTask.AllTask.Add(one);
            }
            reader.Close();
            file.Close();
        }

        public override void UpDate(Subject somechange)
        {
            SaveFile(somechange);
        }

    }
}
    