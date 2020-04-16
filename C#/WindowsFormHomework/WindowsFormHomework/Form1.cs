using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormHomework
{
    public partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
        }

        /*static DialogResult ShowMessageBoxes() // мой пример на потом
        {
            //показ окна, отображающего текстовое
            //сообщение и кнопку ОК
            String message = "Окно, отображающеетекстовое сообщение";
            //MessageBox.Show(message);  // просто окно с текстом

            String caption = "Заголовок"; // заголовок окна
            //MessageBox.Show(message, caption);  // окно с текстом + заголовок

            //DialogResult result = MessageBox.Show(message, caption,MessageBoxButtons.OK); //показ окна с текстом  заголовком и кнопкой
                                                                                          //вазвращфет результат выбора кнопки
            
            //DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error); // показ окна с текстом  
                                                                                                                 //заголовком и кнопкой и 

            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                                                                                                  // показ окна с текстом
                                                                                                  //заголовком и кнопкоми error и кнопка по умолчанию
            String button = result.ToString();

            result = MessageBox.Show("Вы нажали кнопку" + button + ". Повторить?", button, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Asterisk);

            return result;
        }
        */

        /*1. Вывести на экран свое (краткое !!!) резюме с помощью
           последовательности MessageBox'ов (числом не менее трех).
           Причем на заголовке последнего должно отобразиться
           среднее число символов на странице (общее количество
            символов в резюме / количество MessageBox'ов).*/

        static DialogResult ShowMessageBoxes()
        {
            int count = 0;
            String message = "-Programmer C++ developer ,"  + " Very good knowledge data Structures and Algorithms, "
                             + "Very good knowledge OOP, " + " Very good knowledge Design Pattern,"
                             + "Good knowledge.Net based on C# ," + "Good knowledge WPF, " + "Intermediate level English";
            String caption = "Key knowledge and skills"; // заголовок окна

            count += message.Length;
            count += caption.Length;

            MessageBox.Show(message, caption, MessageBoxButtons.OK);  // окно с текстом + заголовок

            message = "freelancer C++ programmer, " + "doing custom work in C++, " +
                "doing Tutoring with two students(looking and correcting errors) explain to them the training material, " +
                " Mercurial repository hg clone https://darkarki@bitbucket.org/darkarki/oop-c ";
           
            caption = "Work Experience";

            count += message.Length;
            count += caption.Length;

            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);

            message = "I think it is all. Do you want to see how many letters are in my resume";
            caption = "Choice";

            count += message.Length;
            count += caption.Length;
            
            result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            caption = count.ToString();
            message = "Avarege Letters in this resume : " + count / 3;
            if (result == DialogResult.Yes)
                MessageBox.Show(message, caption);
            else
                MessageBox.Show("Bay--Bay", caption);

            return result;
        }
        private void Resume_Click(object sender, EventArgs e)
        {
            DialogResult result;
            do
            {
                result = ShowMessageBoxes();
            } while (result == DialogResult.Retry);
        }
    }
}
    

