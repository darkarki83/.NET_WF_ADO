using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class FileManager
    {
        public static void Save(List<SaveLoad> saveLoads)
        {
            try
            {
                using (FileStream fileStream = new FileStream("Score.dat", FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fileStream, saveLoads);
                }
            }
            catch (IOException exc)
            {
                Console.WriteLine("Error Writing saveLoads File");
                Console.WriteLine("Reason: " + exc.Message);
            }
        }


        public static void Load(ref List<SaveLoad> saveLoads)
        {
            try
            {
                using (FileStream fileStream = new FileStream("Score.dat", FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    saveLoads = (List<SaveLoad>)bf.Deserialize(fileStream);
                }
            }
            catch (IOException)
            {
                SaveLoad save = new SaveLoad();
                for (int i = 0; i < 10; i++)
                {
                    saveLoads.Add(save);
                }
            }
        }

        public static void Print(ref List<SaveLoad> saveLoads)
        {
            int xDrow = 20;
            int yDrow = 10;

            DrawBeforPrint(xDrow, yDrow, ref saveLoads);

            for (int i = 0; i < saveLoads.Count; i++)
            {
                ConsoleLib.GotoXY(xDrow + 1, yDrow + 1 + i * 2);
                Console.WriteLine($"Name : {saveLoads[i].name}");
                ConsoleLib.GotoXY(xDrow + 21, yDrow + 1 + i * 2);
                Console.WriteLine($"Score : {saveLoads[i].score}");
            }
        }

        public static void DrawBeforPrint(int xDrow, int yDrow, ref List<SaveLoad> saveLoads)
        {
            const char LeftUp = (char)9484;
            const char RightUp = (char)9488;
            const char Gorizont = (char)9472;
            const char Vertikal = (char)9474;
            const char RightDown = (char)9496;
            const char LeftDown = (char)9492;
            const char VertikalGorizontLeft = (char)9508;
            const char VertikalGorizontRight = (char)9500;

            int count = 39;

            ConsoleLib.WriteChar(xDrow, yDrow, LeftUp);
            ConsoleLib.WriteChar(xDrow + 40, yDrow, RightUp);
            ConsoleLib.WriteChar(xDrow, yDrow + 20, LeftDown);
            ConsoleLib.WriteChar(xDrow + 40, yDrow + 20, RightDown);

            for (int i = 0; i <= 20; i++)
            {
                if (i % 2 == 0)
                {
                    ConsoleLib.WriteChars(xDrow + 1, yDrow + i, Gorizont, count);
                    if (i > 1 && i < 20)
                    {
                        ConsoleLib.WriteChar(xDrow + 0, yDrow + i, VertikalGorizontRight);
                        ConsoleLib.WriteChar(xDrow + 40, yDrow + i, VertikalGorizontLeft);
                    }
                }
                else
                {
                    ConsoleLib.WriteChar(xDrow, yDrow + i, Vertikal);
                    ConsoleLib.WriteChar(xDrow + 20, yDrow + i, Vertikal);
                    ConsoleLib.WriteChar(xDrow + 40, yDrow + i, Vertikal);
                }
            }
        }
    }
}
