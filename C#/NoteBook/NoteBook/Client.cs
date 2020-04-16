using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBook
{
    [Serializable]
    public struct Client
    {
        public string firstName;
        public string lastName;
        public int foneNumber;
        public string adress;

        static public void InputClient(out Client client)
        {
            Console.Write("Write the name new Client : ");
            client.firstName = Console.ReadLine();
            Console.Write("Write the lastName new Client : ");
            client.lastName = Console.ReadLine();
            Console.Write("Write the foneNumber new Client : ");
            try
            {
                client.foneNumber = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                client.foneNumber = 0;
            }
            Console.Write("Write the adress new Client : ");
            client.adress = Console.ReadLine();
        }

        static public void InputClientName(ref Client client)
        {
            Console.Write("Write the name  Client : ");
            client.firstName = Console.ReadLine();
        }

        static public void InputClientLastName(ref Client client)
        {
            Console.Write("Write the lastName Client : ");
            client.lastName = Console.ReadLine();
        }

        static public void InputClientFoneNumber(ref Client client)
        {
            Console.Write("Write the foneNumber Client : ");
            try
            { 
            client.foneNumber = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                client.foneNumber = 0;
            }
        }

        static public void InputClientAdress(ref Client client)
        {
            Console.Write("Write the adress Client : ");
            client.adress = Console.ReadLine();
        }
    }
}
