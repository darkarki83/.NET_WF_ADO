using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NoteBook
{
    public class FileManager
    {
        static public void Load(PhoneBook phoneBook)
        {
            BinaryReader dataIn;

            try
            {
                dataIn = new BinaryReader(
                    new FileStream("SaveBook.dat", FileMode.Open));
            }
            catch (IOException exc)
            {
                Console.WriteLine("Cannot Open SaveBook File For Input");
                Console.WriteLine("Reason: " + exc.Message);
                return;
            }
            try
            {
                phoneBook.Count = dataIn.ReadInt32();

                Client client = new Client();

                for (int i = 0; i < phoneBook.Count; i++)
                {
                    client.firstName = dataIn.ReadString();
                    client.lastName = dataIn.ReadString();
                    client.foneNumber = dataIn.ReadInt32();
                    client.adress = dataIn.ReadString();
                    phoneBook.Add(client);
                    phoneBook.Count--;
                }
            }
            catch (IOException exc)
            {
                Console.WriteLine("Error Reading Inventory File");
                Console.WriteLine("Reason: " + exc.Message);
            }
            finally
            {
                dataIn.Close();
            }
        }
        
        static public void Save(PhoneBook phoneBook)
        {
            BinaryWriter dataOut;
            try
            {
                dataOut = new BinaryWriter(
                    new FileStream("SaveBook.dat", FileMode.Create));
            }
            catch (IOException exc)
            {
                Console.WriteLine("Cannot Open SaveBook File For Output");
                Console.WriteLine("Reason: " + exc.Message);
                return;
            }

            try
            {
                dataOut.Write(phoneBook.Count);

                for (int i = 0; i < phoneBook.Count; i++)
                {
                    dataOut.Write(phoneBook.PhonesBook[i].firstName);
                    dataOut.Write(phoneBook.PhonesBook[i].lastName);
                    dataOut.Write(phoneBook.PhonesBook[i].foneNumber);
                    dataOut.Write(phoneBook.PhonesBook[i].adress);
                }
            }
            catch (IOException exc)
            {
                Console.WriteLine("Error Writing SaveBook File");
                Console.WriteLine("Reason: " + exc.Message);
            }
            finally
            {
                dataOut.Close();
            }
        }

        static public void SaveSerialization(PhoneBook phoneBook)
        {
            try
            {
                using (FileStream fileStream = new FileStream("obj.dat", FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fileStream, phoneBook);
                }
            }
            catch (IOException exc)
            {
                Console.WriteLine("Error Writing SaveBook File");
                Console.WriteLine("Reason: " + exc.Message);
            }
        }

        static public void LoadSerialization(out PhoneBook phoneBook)
        {
            using (FileStream fileStream = new FileStream("obj.dat", FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                phoneBook = (PhoneBook)bf.Deserialize(fileStream);
            }
        }
    }
}
