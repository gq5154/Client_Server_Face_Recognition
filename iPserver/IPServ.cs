using Emgu.CV;
using Emgu.CV.Structure;
using System;



namespace Casablanca.IPServ {



   public static class IPServ {



      public static string Process(string[] command) {

         switch(command[0]) {
         case "start":
            return Start();
         case "test":
            return Test(command);
         case "save":
            return Save(command);
         }

         return "ERROR";

      }



      public static string Start() {

         if(!FaceList.Open()) {
            return "ERROR";
         }

         FaceList.LoadFaces();

         return "OK";
      }



      public static string Test(string[] param) {

         if(param.Length!=4) {
            ServerLog.Register("Esperando 3 parameteros en: test.");
            return "ERROR";
         }

         try {
            Image<Gray,byte> Img = new Image<Gray,byte>(100,100);
            Img.Bytes            = Convert.FromBase64String(param[3]);
            return FaceList.Test(param[1]=="T",param[2],Img);
         } catch(Exception e) {
            ServerLog.Register(e.Message);
            return "ERROR";
         }

      }



      public static string Save(string[] param) {
         if(param.Length!=3) {
            ServerLog.Register("Esperando 2 parameteros en: save.");
            return "ERROR";
         }
         try {
            Image<Gray,byte> Img = new Image<Gray,byte>(100,100);
            Img.Bytes            = Convert.FromBase64String(param[2]);
            FaceList.Save(param[1],Img);
            return "OK";
         } catch(Exception e) {
            ServerLog.Register(e.Message);
            return "ERROR";
         }
      }



   }



}