namespace Casablanca.IPServ {



   internal class DBStatus {



      internal long     Row;  
      internal string[] Values;
      internal DBFile   Table;



      internal void SetStructField(int ix,string name,byte type,int size,byte decimals) {
         Table.SetField(ix,name,type,size,decimals);
      }



      internal bool SaveStruct() {
         if(DB.CanSaveStruct(Table.Name)) {
            Values = Table.SaveStruct();
            return true;
         }
         return false;
      }



      internal void Close() {
         Table.Close();
      }



      internal long Rows() {
         return Table.Rows();
      }



      internal void BlankRow() {
         Table.BlankRow(Values);
         Row = 0;
      }



      internal bool ReplaceNumeric(string name,double val) {
         return Table.ReplaceNumeric(name,Values,val);
      }



      internal bool ReplaceString(string name,string val) {
         return Table.ReplaceString(name,Values,val);
      }



      internal void Append() {
         Row = Table.Append(Values);
      }



      internal void LoadRow(long row) {
         Row = row;
         Table.ReadRow(Row,Values);
      }



      internal double ReadNumeric(string name) {
         return Table.ReadNumeric(name,Values);
      }



      internal string ReadString(string name) {
         return Table.ReadString(name,Values);
      }



   }



}