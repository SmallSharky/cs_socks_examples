using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
/*
Сервер

Непрерывно получает от клиентов данные и считает их
массивами чисел типа int. Выводит эти массивы.
*/
namespace ABCDEF
{
class MainClass
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Server 3!");
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
                int[] intRec = new int[(bytesRec/sizeof(int))];
                Buffer.BlockCopy(data, 0, intRec, 0, (intRec.Length * sizeof(int))); 
                Console.Write("----------------\n");
                int i = 0;
                while(i<intRec.Length){
                    Console.Write("M[{0}] = {1};\n", i, intRec[i]);
                    i++;
                }
                Console.Write("\n----------------\n");
                
                sock.Shutdown(SocketShutdown.Both);
                sock.Close();
            }
            Thread.Sleep(10);
        }

    }
}
}
