using System.Collections.Generic;



namespace Casablanca.IPServ {



   internal static class DB {



      internal const byte FieldTypeString  = 0x01;
      internal const byte FieldTypeNumeric = 0x02;



      static Dictionary<string,DBFile> Tables;



      internal static void Start() {
         Tables = new Dictionary<string, DBFile>();
      }



      internal static bool Exists(string name) {
         return DBFile.Exists(name);
      }



      internal static DBStatus CreateStruct(string name,int fields) {
         DBFile   table  = new DBFile(name);
         DBStatus status = new DBStatus();
         status.Table    = table;
         table.CreateStruct(fields);
         return status;
      }



      internal static bool CanSaveStruct(string name) {
         if(Tables.ContainsKey(name)) {
            ServerLog.Register("Se intentó crear \""+name+"\" pero la tabla ya está abierta.");
            return false;
         }
         if(DBFile.Exists(name)) {
            ServerLog.Register("Se intentó crear \""+name+"\" pero la tabla ya existe.");
            return false;
         }
         return true;
      }



      internal static DBStatus Open(string name) {
         if(Tables.ContainsKey(name)) {
            DBFile tab = Tables[name];
            return tab.Open();
         }
         if(!DBFile.Exists(name)) {
            ServerLog.Register("No se pudo abrir la table \""+name+"\", debido a que no existe.");
            return null;
         }
         DBFile   table  = new DBFile(name);
         DBStatus status = table.Open();
         Tables.Add(name,table);
         return status;
      }



   }



}