using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;



namespace Casablanca.IPClient {



   public static class Client {



      const string Server = "UD02";
      const int    Port   = 81;



      static Socket           Connection;
      static ManualResetEvent SendDone    = new ManualResetEvent(false);
      static ManualResetEvent ReceiveDone = new ManualResetEvent(false);
      static string           Reply       = String.Empty;



      public static void Connect() {

         try {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Server);
            IPAddress   ipAddress  = ipHostInfo.AddressList[0];
            IPEndPoint  remoteEP   = new IPEndPoint(ipAddress,Port);
            Connection             = new Socket(ipAddress.AddressFamily,SocketType.Stream,ProtocolType.Tcp);
            Connection.Connect(remoteEP);
         } catch(Exception e) {
            MessageBox.Show("No fue posible conectar con el servidor: \""+Server+"\".\n\r\n\r"+e.Message);
            throw e;
         }

      }



      public static string Request(string request) {
         string command = String.Format("{0}:{1}",request.Length,request);
         byte[] data    = Encoding.ASCII.GetBytes(command);
         Connection.Send(data);
         Response response = new Response();
         while(true) {
            int bRead = Connection.Receive(response.Buffer);
            response.Read(bRead);
            if(response.Remaining==0) {
               break;
            }
         }
         return response.Reply();
      }



      public static void EndSend(IAsyncResult resul) {
         Connection.EndSend(resul);
         SendDone.Set();
      }



      public static void EndReceive(IAsyncResult resul) {
         Response response = (Response) resul.AsyncState;
         int      bRead    = Connection.EndReceive(resul);
         if(bRead>0) {
            if(response.Read(bRead)) {
               if(response.Remaining==0) {
                  Reply = response.Reply();
                  ReceiveDone.Set();
               } else {
                  Connection.BeginReceive(response.Buffer,0,Response.BufferSize,0,new AsyncCallback(EndReceive),response);
               }
            }
         } else {
            Reply = response.Reply();
            ReceiveDone.Set();
         }
      }



      public static void Disconnect() {
         Connection.Shutdown(SocketShutdown.Both);
         Connection.Close();
      }



   }



}
