using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

/*
Клиент

Пять раз отправляет массив чисел типа int на сервер
*/

namespace ABCDEF
{
class MainClass
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Client 3!");
//Данные о сервере
        IPAddress srvAddr = IPAddress.Parse("127.0.0.1");
        int srvPort = 65432;
//Создаем оконечную точку, чтобы к ней можно было подключиться
        IPEndPoint ep = new IPEndPoint(srvAddr, srvPort);

        int i = 0;
        while (i < 5)
        {
//Создаем сокет
            Socket sock = new Socket(srvAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                Console.Write("\nПытаюсь соединиться\n");
//Пытаемся соединить сокет с оконечной точкой
                sock.Connect(ep);
//Выключаем соединение

                int[] mas = { 1024, 65535, 123,9797, 77571};
                byte[] bmas = new byte[mas.Length * sizeof(int)];
                Buffer.BlockCopy(mas, 0, bmas, 0, bmas.Length);
                sock.Send(bmas);
                sock.Shutdown(SocketShutdown.Both);
//Удаляем сокет
                sock.Close();

            }
            catch (Exception ex)
            {
                Console.Write("При соединении возникла проблема: \n{0}\n",ex.Message);

            }
            i++;
        }

    }
}
}
