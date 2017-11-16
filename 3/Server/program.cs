using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
/*
Сервер
*/
namespace ABCDEF
{
class MainClass
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Server 2!");
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
//Принимаем соединение.
                Socket sock = listener.AcceptSocket();
/*
Вот здесь надо получить данные, если они есть
*/  
                int bytesRec = sock.ReceiveBufferSize;
                byte[] data = new byte[bytesRec];
                bytesRec = sock.Receive(data);
                string message = Encoding.UTF8.GetString(data, 0, bytesRec);
                Console.Write("----------------\n");
                Console.Write(message);
                Console.Write("\n----------------\n");
                
                sock.Shutdown(SocketShutdown.Both);
                sock.Close();
            }
            Thread.Sleep(10);
        }

    }
}
}
