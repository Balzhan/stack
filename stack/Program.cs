using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace stack
{
    class Program
    {
        static void Main(string[] args)
        {
            //вводим путь, указываем папку, о которой хотим узнать информацию;
            string path = @"D:\Звездные войны, антология 1977-2005";
            //создаем информацию о папке, которая указана в путе;
            DirectoryInfo dir = new DirectoryInfo(path);
            //считает количество файлов в папке;
            int cnt = dir.GetFiles().Length;
            //выводит на экран количество файлов, находящиеся в определенной папке;
            Console.WriteLine(cnt + " files are located in " + dir.FullName);

            //создаем стек;
            Stack<DirectoryInfo> items = new Stack<DirectoryInfo>();

            //пробегаемся по массиву папок;
            foreach (DirectoryInfo ndir in dir.GetDirectories())
            {
                //все папки, находящиеся в массиве папки, добавляет в стек;
                items.Push(ndir); 
            }

            //задаем условие;
            while (true) 
            {
                //пока наш стек не пустой;
                if (items.Count > 0)
                {
                    //вытаскиваем из стека элемент самый верхний;
                    DirectoryInfo npopDir = items.Pop();
                    //считаем количество элементов, вытаскиваем и распечатываем их;
                    cnt = npopDir.GetFiles().Length; 
                    Console.WriteLine(cnt + " files are located in " + npopDir.FullName);

                    //записываем в массив количество файлов в папке, которые были удалены;
                    DirectoryInfo[] npopDirItems = npopDir.GetDirectories();
                    //пробегаемся по массиву;
                    foreach (DirectoryInfo npopDirIt in npopDirItems)
                    {
                        //пробегаемся по папкам(файлам) и добавляем их в стек;
                        items.Push(npopDirIt); 
                    }
                }
            }
           
        }
        static void Search(DirectoryInfo dir)
        {
            //заводим переменную, которая вычисляет количество файлов в папке;
            int cnt = dir.GetFiles().Length;
            //выводим на экран, информацию о папках и файлах;
            Console.WriteLine(cnt + " files are located in " + dir.FullName);
            //пробегаемся по массиву папок;
            foreach (DirectoryInfo ndir in dir.GetDirectories())
            {
                //поисковик;
                Search(ndir);
            }

        }
    }
}
