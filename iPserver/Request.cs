using System;
using System.Net.Sockets;
using System.Text;



namespace Casablanca.IPServ {



   internal class Request {



      public const int BufferSize = 1024;



      public Socket        Socket;
      public byte[]        Buffer    = new byte[BufferSize];
      public StringBuilder StrBulder = new StringBuilder();
      public int           CommandPt;
      public int           CommandLen;
      public int           Remaining = -1;



      public bool Read(int bRead) {

         StrBulder.Append(Encoding.ASCII.GetString(Buffer,0,bRead));

         if(Remaining==-1) {
            String command = StrBulder.ToString();
            int    pos     = command.IndexOf(":");
            if(pos>-1) {
               try {
                  CommandLen = int.Parse(command.Substring(0,pos));
               } catch(FormatException) {
                  ServerLog.Register("Solicitud inválida. Se especificó un dato no numérico en \"Tamaño\"",true);
                  return false;
               }
            } else {
               ServerLog.Register("Solicitud inválida. Falta delimitador de \"Tamaño\" (\":\").",true);
               return false;
            }
            CommandPt = pos+1;
            Remaining  = CommandLen+CommandPt;
         }

         Remaining -= bRead;
         if(Remaining<0) {
            ServerLog.Register("Tamaño manifestado en la solicitud es menor a los datos enviados",true);
            return false;
         }

         return true;

      }



      public string[] Command() {
         return StrBulder.ToString().Substring(CommandPt,CommandLen).Split('?');
      }



   }



}