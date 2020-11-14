using System;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;



namespace Casablanca.IPServ {
   internal class DBFile {



      [Serializable]
      class DBHeader {



         const long DBFSIGNATURE = 0x4B494C424F47;



         private  long R0;
         private  long R1;
         private  long R2;
         private  long R3;
         private  long R4;
         internal int  Fields;
         internal int  RowSize;
         internal long RowCount;
         internal long HeaderSize;
         internal long VirtualEOF;
         internal byte Status;
         private  long Signature;



         internal DBHeader() {
            R0         = 0;
            R1         = 0;
            R2         = 0;
            R3         = 0;
            R4         = 0;
            Fields     = 0;
            RowSize    = 0;
            RowCount   = 0;
            HeaderSize = 0;
            VirtualEOF = 0;
            Status     = 0;
            Signature  = DBFSIGNATURE;
         }



         internal bool IsValid() {
            return Signature==DBFSIGNATURE;
         }



      }



      [Serializable]
      internal class DBField {



         [NonSerialized]
         internal string Name;
         internal byte[] BName = new byte[30];
         internal byte   Type;
         internal int    Size;
         internal byte   Decimals;
         internal int    Offset;



         internal DBField(string name,byte type,int size,byte decimals) {
            if(size<1) {
               size = 1;
            }
            if(decimals>size-2) {
               decimals = (byte)(size-2);
            }
            Name     = name.Trim().ToUpper();
            BName    = Encoding.ASCII.GetBytes((Name.PadRight(30,' ')).Substring(0,30));
            Type     = type;
            Size     = size;
            Decimals = decimals;
         }



      }



      const string DBFEXENSION = ".GOBLIKDBF";



      static string DBPath = NoFile(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)+"/Data");



      internal string    Name       { get; private set; }
      internal DBField[] Fields     { get; private set; }
      internal int       FieldCount { get; private set; }



      DBHeader     Header;
      FileStream   DBStream;
      IFormatter   Formatter;
      int          OpenCount;



      internal DBFile(string name) {
         Name      = name;
         OpenCount = 0;
      }
            


      static string NoFile(string s) {
         if(s.StartsWith("file:\\")) return s.Substring(6,s.Length-6);
         if(s.StartsWith("file:/"))  return s.Substring(5,s.Length-5);
         return s;
      }



      void LogError(Exception e) {
         ServerLog.Register(String.Format("Tabla \"{0}\": {1}",Name,e.Message),true);
      }



      internal static string DataFileName(string name) {
         return DBPath+"/"+name;
      }



      internal static bool Exists(string name) {
         return File.Exists(DBPath+"/"+name+DBFEXENSION);
      }



      internal bool Delete() {
         try {
            File.Delete(DBPath+"/"+Name+DBFEXENSION);
         } catch(Exception e) {
            LogError(e);
            return false;
         }
         return true;
      }



      internal void CreateStruct(int fields) {
         Fields     = new DBField[fields];
         FieldCount = fields;
      }



      internal void SetField(int ix,string name,byte type,int size,byte decimals) {
         if(DBStream!=null) {
            ServerLog.Register("Se intentó inicializar la columna  \""+name+"\" en la tabla \""+Name+"\" pero la tabla ya está abierta.");
            return;
         }
         if(ix>FieldCount) {
            ServerLog.Register("Se intentó inicializar la columna "+ix.ToString()+" en la tabla \""+Name+"\" pero la estructura solo contiene "+FieldCount.ToString()+" columnas.");
            return;
         }
         Fields[ix] = new DBField(name,type,size,decimals);
      }



      internal string[] SaveStruct() {

         int          rsize   = 0;
         int          fieldCt = Fields.Length;
         MemoryStream stream  = new MemoryStream();
         Formatter            = new BinaryFormatter();
         Header               = new DBHeader();
         FieldCount           = 0;
         Formatter.Serialize(stream,Header);
         int ix;
         for(int i = 0;i<fieldCt;i++) {
            DBField field = Fields[i];
            switch(field.Type) {
            case DB.FieldTypeString:
               break;
            case DB.FieldTypeNumeric:
               break;
            default:
               ServerLog.Register("Se intentó crear \""+Name+"\" con al menos un tipo de dato inválido.");
               return null;
            }
            if(FetchField(field.Name,out ix)!=null) {
               ServerLog.Register("Se intentó crear \""+Name+"\" con al menos un campo duplicado.");
               return null;
            }
            FieldCount++;
            field.Offset  = rsize;
            rsize        += field.Size;
            Formatter.Serialize(stream,field);
         }
         if(rsize==0) {
            ServerLog.Register("Se intentó crear \""+Name+"\" pero la longitud del registro es cero.");
            return null;
         }

         Header.Fields     = fieldCt;
         Header.RowSize    = rsize;
         Header.HeaderSize = stream.Position;
         Header.VirtualEOF = stream.Position;
         stream.Position   = 0;
         Formatter.Serialize(stream,Header);

         try {
            DBStream     = new FileStream(DataFileName(Name+DBFEXENSION),FileMode.CreateNew);
            byte[] bytes = stream.ToArray();
            DBStream.Write(bytes,0,bytes.Length);
            stream.Close();
            DBStream.Flush();
            OpenCount++;
         } catch(Exception e) {
            LogError(e);
            return null;
         }
         string[] values = new string[FieldCount];
         BlankRow(values);
         return values;

      }



      internal DBField FetchField(string name,out int ix) {
         string fname = name.Trim().ToUpper();
         for(int i=0;i<FieldCount;i++) {
            if(Fields[i].Name==fname) {
               ix = i;
               return Fields[i];
            }
         }
         ix = -1;
         return null;
      }



      internal DBStatus Open() {

         if(OpenCount>0) {
            OpenCount++;
            DBStatus stat = new DBStatus();
            stat.Values    = new string[FieldCount];
            stat.BlankRow();
            return stat;
         }

         try {
            DBStream = new FileStream(DataFileName(Name+DBFEXENSION),FileMode.Open);
         }catch(Exception e) {
            LogError(e);
            return null;
         }

         Formatter = new BinaryFormatter();
         Header    = (DBHeader) Formatter.Deserialize(DBStream);
         if(!Header.IsValid()) {
            DBStream.Close();
            ServerLog.Register("No se puedo abrir \""+Name+"\" debido a que el encabezado es inválido.");
            return null;
         }
         FieldCount = Header.Fields;
         Fields     = new DBField[FieldCount];
         for(int i=0;i<FieldCount;i++) {
            DBField field = (DBField) Formatter.Deserialize(DBStream);
            field.Name     = Encoding.ASCII.GetString(field.BName).Trim();
            Fields[i]      = field;
         }

         DBStatus status = new DBStatus();
         status.Table     = this;
         status.Values    = new string[FieldCount];
         status.BlankRow();
         return status;

      }



      internal void Close() {
         if(OpenCount>0) {
            OpenCount--;
         }
         if(OpenCount==0) {
            DBStream.Close();
         }
      }



      internal long Rows() {
         return Header.RowCount;
      }



      internal long Append(string[] values) {
         WriteRow(Header.RowCount+1,values);
         Header.VirtualEOF = (int) DBStream.Position;
         Header.RowCount++;
         DBStream.Position = 0;
         Formatter.Serialize(DBStream,Header);
         DBStream.Flush();
         return Header.RowCount;
      }



      internal void WriteRow(long row,string[] values) {
         DBStream.Position = Header.HeaderSize+(row-1)*Header.RowSize;
         for(int i=0;i<FieldCount;i++) {
            DBField field = Fields[i];
            DBStream.Write(Encoding.ASCII.GetBytes(values[i]),0,field.Size);
         }
      }



      internal void ReadRow(long row,string[] values) {
         DBStream.Position = Header.HeaderSize+(row-1)*Header.RowSize;
         for(int i=0;i<FieldCount;i++) {
            DBField field = Fields[i];
            byte[]   bytes = new byte[field.Size];
            DBStream.Read(bytes,0,field.Size);
            values[i] = Encoding.ASCII.GetString(bytes);
         }
      }



      internal void BlankRow(string[] values) {
         for(int i = 0;i<FieldCount;i++) {
            DBField field = Fields[i];
            values[i] = "".PadRight(field.Size,' ');
         }
      }



      internal bool ReplaceNumeric(string name,string[] values,double val) {
         int ix;
         DBField field = FetchField(name,out ix);
         if(field==null) {
            ServerLog.Register("El campo \""+name+"\" no existe en la tabla \""+Name+"\".");
            return false;
         }
         if(field.Type!=DB.FieldTypeNumeric) {
            ServerLog.Register("El campo \""+name+"\" en la tabla \""+Name+"\" no es numérico.");
            return false;
         }
         string fmt;
         if(field.Decimals>0) {
            int intpos = field.Size-field.Decimals-1;
            fmt = "{0:".PadRight(intpos+3,'0')+"."+"".PadRight(field.Decimals,'0')+"}";
         } else {
            fmt = "{0:".PadRight(field.Size+3,'0')+"}";
         }
         values[ix] = String.Format(fmt,val);
         return true;
      }



      internal bool ReplaceString(string name,string[] values,string val) {
         int ix;
         DBField field = FetchField(name,out ix);
         if(field==null) {
            ServerLog.Register("El campo \""+name+"\" no existe en la tabla \""+Name+"\".");
            return false;
         }
         if(field.Type!=DB.FieldTypeString) {
            ServerLog.Register("El campo \""+name+"\" en la tabla \""+Name+"\" no es texto.");
            return false;
         }
         values[ix] = val.PadRight(field.Size).Substring(0,field.Size);
         return true;
      }



      internal double ReadNumeric(string name,string[] values) {
         int ix;
         DBField field = FetchField(name,out ix);
         if(field==null) {
            ServerLog.Register("El campo \""+name+"\" no existe en la tabla \""+Name+"\".");
            return 0;
         }
         if(field.Type!=DB.FieldTypeString) {
            ServerLog.Register("El campo \""+name+"\" en la tabla \""+Name+"\" no es texto.");
            return 0;
         }
         try {
            return Convert.ToDouble(values[ix]);
         } catch(Exception) {
            ServerLog.Register("El campo \""+name+"\" de la tabla \""+Name+"\" no se puede convertir a \"double\".");
            return 0;
         }
      }



      internal string ReadString(string name,string[] values) {
         int ix;
         DBField field = FetchField(name,out ix);
         if(field==null) {
            ServerLog.Register("El campo \""+name+"\" no existe en la tabla \""+Name+"\".");
            return String.Empty;
         }
         if(field.Type!=DB.FieldTypeString) {
            ServerLog.Register("El campo \""+name+"\" en la tabla \""+Name+"\" no es texto.");
            return String.Empty;
         }
         return values[ix];
      }


   }



}