using System;
using System.IO;



namespace Casablanca.IPServ {



   public static class ServerLog {



      const string Name = "ServerLog.txt";



      static StreamWriter Log;



      public static void Register(string msg,bool console=false) {

         string text = String.Format("{0}: {1}",DateTime.Now,msg);

         if(Log==null) {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(Exit);
            Log = new StreamWriter(Name);
         }

         Log.WriteLine(text);
         Log.Flush();

         //if(console) {
         //   Console.WriteLine(text);
         //}

      }



      static void Exit(object sender,EventArgs e) {
         Log.Close();
      }



   }



}
