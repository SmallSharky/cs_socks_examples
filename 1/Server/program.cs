using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ABCDEF
{
class MainClass
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
//Начать слушать порт 65432 по адресу 0.0.0.0
        IPAddress addr = IPAddress.Parse("0.0.0.0");
        int port = 65432;
        TcpListener listener = new TcpListener(addr, port);
        listener.Start();

//До посинения принимать входящие соединения
        while ( true ) {
            if (listener.Pending())
            {
                Console.WriteLine("Соединение добавлено в очередь");
//Принимаем соединение и сбрасываем его.
                listener.AcceptSocket().Close();
            }
            Thread.Sleep(10);
        }

    }
}
}
