using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;


/*
try {
Код, который нужно попробовать выполнить
}
catch (...) {
Код, который будет выполнен, если не получилось выполнить код,
который нужно было попробовать выполнить
}


*/

/*

try {
установить соединение с сервером
}
catch () {
сказать, что соединиться с сервером не получилось
}

*/



namespace ABCDEF
{
class MainClass
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Client!");
//Данные о сервере
        IPAddress srvAddr = IPAddress.Parse("127.0.0.1");
        int srvPort = 65432;
//Создаем оконечную точку, чтобы к ней можно было подключиться
        IPEndPoint ep = new IPEndPoint(srvAddr, srvPort);
        
        int i = 0;
        while(i<5) {
//Создаем сокет
            Socket sock = new Socket(srvAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try {
                Console.Write("Пытаюсь соединиться\n");
//Пытаемся соединить сокет с оконечной точкой
                sock.Connect(ep);
//Выключаем соединение
                
                sock.Shutdown(SocketShutdown.Both);
                
//Удаляем сокет
                sock.Close();

            }
            catch (Exception ex) {
                Console.Write("При соединении возникла проблема\n");
            }
            i++;
        }



    }
}
}

