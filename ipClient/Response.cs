using System;
using System.Text;
using System.Windows.Forms;




namespace Casablanca.IPClient {



   public class Response {



      public const int BufferSize = 1024;



      public byte[]        Buffer    = new byte[BufferSize];
      public StringBuilder StrBulder = new StringBuilder();
      public int           ResponsePt;
      public int           ResponseLen;
      public int           Remaining = -1;



      public bool Read(int bRead) {

         StrBulder.Append(Encoding.ASCII.GetString(Buffer,0,bRead));

         if(Remaining==-1) {
            String command = StrBulder.ToString();
            int pos = command.IndexOf(":");
            if(pos>-1) {
               try {
                  ResponseLen = int.Parse(command.Substring(0,pos));
               } catch(FormatException) {
                  MessageBox.Show("Respuesta del servidor inválida. Se especificó un dato no numérico en \"Tamaño\".");
                  return false;
               }
            } else {
               MessageBox.Show("Respuesta del servidor inválida. Falta delimitador de \"Tamaño\" (\":\").");
               return false;
            }
            ResponsePt = pos+1;
            Remaining  = ResponseLen+ResponsePt;
         }

         Remaining -= bRead;
         if(Remaining<0) {
            MessageBox.Show("Tamaño manifestado en la respuesta del servdor es menor a los datos enviados.");
            return false;
         }

         return true;

      }



      public string Reply() {
         return StrBulder.ToString().Substring(ResponsePt,ResponseLen);
      }



   }



}