using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;




namespace Casablanca.IPServ {



   public class Server {



      static ManualResetEvent Done = new ManualResetEvent(false);



      public static void Listen(int port) {

         ServerLog.Register("Iniciando...",true);

         IPHostEntry hostInfo = Dns.GetHostEntry(Dns.GetHostName());
         IPAddress   address  = hostInfo.AddressList[0];
         EndPoint    endPoint = new IPEndPoint(address,port);
         Socket      listener = new Socket(address.AddressFamily,SocketType.Stream,ProtocolType.Tcp);

         try {

            listener.Bind(endPoint);
            listener.Listen(100);

            ServerLog.Register("¡Escuchando!",true);

            while(true) {

               Done.Reset();
               listener.BeginAccept(new AsyncCallback(Accept),listener);
               Done.WaitOne();

            }

         } catch(Exception e) {

            ServerLog.Register(e.Message,true);

         }

      }



      static void Accept(IAsyncResult resul) {

         Done.Set();

         Socket  listener = (Socket)resul.AsyncState;
         Socket  handler  = listener.EndAccept(resul);
         Request request  = new Request();
         request.Socket   = handler;

         handler.BeginReceive(request.Buffer,0,Request.BufferSize,0,new AsyncCallback(Read),request);

      }



      static void Read(IAsyncResult resul) {

         String  command = String.Empty;
         Request request = (Request)resul.AsyncState;
         Socket  handler = request.Socket;
         try {

            int bRead = handler.EndReceive(resul);

            if(bRead>0) {
               if(request.Read(bRead)) {
                  if(request.Remaining==0) {
                     Reply(request);
                  } else {
                     handler.BeginReceive(request.Buffer,0,Request.BufferSize,0,new AsyncCallback(Read),request);
                  }
               }
            } else {
               ServerLog.Register("Error de lectura. Cero bytes recibidos.",true);
            }


         } catch(Exception e) {
            ServerLog.Register(e.Message);
         }

      }



      static void Reply(Request request) {
         string[] command = request.Command();
         ServerLog.Register(command[0]);
         string reply    = IPServ.Process(command);
         byte[] response = Encoding.ASCII.GetBytes(String.Format("{0}:{1}",reply.Length,reply));
         Socket handler  = request.Socket;
         handler.BeginSend(response,0,response.Length,0,new AsyncCallback(Send),handler);
      }



      static void Send(IAsyncResult resul) {

         try {

            Socket handler = (Socket)resul.AsyncState;
            int bytesSent  = handler.EndSend(resul);

            Request request = new Request();
            request.Socket  = handler;
            handler.BeginReceive(request.Buffer,0,Request.BufferSize,0,new AsyncCallback(Read),request);

         } catch(Exception e) {

            ServerLog.Register(e.ToString());

         }

      }



      public static int Main(string[] args) {
         DB.Start();
         Listen(81);
         return 0;
      }



   }



}