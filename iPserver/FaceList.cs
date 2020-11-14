using System;
using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;



namespace Casablanca.IPServ {



   public static class FaceList {



      const string Name = "FaceList";



      static DBStatus               Table;
      static List<string>           Names;
      static List<Image<Gray,byte>> TrainingImages = new List<Image<Gray,byte>>();



      public static bool Open(){

         if(Table==null) {
            if(DB.Exists(Name)) {
               Table = DB.Open(Name);
               return Table!=null;
            }
            Table = DB.CreateStruct(Name,2);
            Table.SetStructField(0,"id"  ,DB.FieldTypeString,20,0);
            Table.SetStructField(1,"name",DB.FieldTypeString,50,0);
            return Table.SaveStruct();
         }
         return false;
      }



      public static void LoadFaces() {
         Names     = new List<string>();
         long rows = Table.Rows();
         for(long i=1;i<=rows;i++) {
            Table.LoadRow(i);
            string imgFile = DBFile.DataFileName("FACE"+Table.ReadString("id").Trim()+".BMP");
            TrainingImages.Add(new Image<Gray,byte>(imgFile));
            Names.Add(Table.ReadString("name").Trim());
         }
      }



      public static string Test(bool save,string name,Image<Gray,byte> img) {

         string rname = "";
         int    count = TrainingImages.Count;
         if(TrainingImages.Count>0) {
            MCvTermCriteria       termCriterias = new MCvTermCriteria(count,0.001);
            EigenObjectRecognizer recognizer    = new EigenObjectRecognizer(TrainingImages.ToArray(),Names.ToArray(),3000,ref termCriterias);
            rname                               = recognizer.Recognize(img);
         }

         if(save) {
            Save(name,img);
         }

         return "OK?"+rname+(name==rname ? "?-" : "?+");

      }



      public static void Save(string name,Image<Gray,byte> img) {
         TrainingImages.Add(img);
         Names.Add(name);
         string id = (DateTime.Now.Ticks).ToString();
         Table.BlankRow();
         Table.ReplaceString("id",id);
         Table.ReplaceString("name",name);
         Table.Append();
         img.Save(DBFile.DataFileName("FACE"+id+".BMP"));
      }



   }



}