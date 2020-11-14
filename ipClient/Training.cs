using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Windows.Forms;



namespace Casablanca.IPClient {



   public partial class Training : Form {



      const int MaxPictures = 9;


      
      HaarCascade      FaceDetected;
      Capture          Camera;
      bool             Processing;
      int              PicturesToTake;
      MCvFont          Font           = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX,0.6d,0.6d);
      Image<Gray,byte> Result2;
      Image<Gray,byte> Result3;
      Image<Gray,byte> Result4;
      Image<Gray,byte> Result5;
      Image<Gray,byte> Result6;
      Image<Gray,byte> Result7;
      Image<Gray,byte> Result8;
      Image<Gray,byte> Result9;



      public Training() {

         InitializeComponent();
         TooMany.Hide();
         RemainingImages.Hide();
         PicLabel.Hide();
         Start.Enabled = false;
         Stop.Enabled  = false;
         Save.Enabled  = false;

         Client.Connect();
         if(Client.Request("start")=="ERROR") {
            MessageBox.Show("El servidor no responde.");
            Application.Exit();
         }

         try {
            FaceDetected = new HaarCascade("haarcascade_frontalface_default.xml");
         } catch(Exception e) {
            MessageBox.Show(e.Message);
            Application.Exit();
         }

         Camera            = new Capture();
         Application.Idle += new EventHandler(DisplayFrame);

      }



      void DisplayFrame(object sender,EventArgs e) {

         if(!Processing && NameBox.Text!=string.Empty && NameBox.Text.Length>2) {
            Start.Enabled = true;
         }

         Image<Bgr,Byte>  Frame            = Camera.QueryFrame().Resize(400,300,INTER.CV_INTER_CUBIC);
         CamView.Image                     = Frame;
         Image<Gray,byte> GrayFace         = Frame.Convert<Gray,Byte>();
         MCvAvgComp[][]   faceDetectedShow = GrayFace.DetectHaarCascade(FaceDetected,1.2,10,HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,new Size(20,20));

         int faces = faceDetectedShow[0].Length;
         if(faces>1) {
            TooMany.Show();
            return;
         }
         TooMany.Hide();
         if(faces==0) {
            return;
         }

         var              f      = faceDetectedShow[0][0];
         Image<Gray,byte> Result = Frame.Copy(f.rect).Convert<Gray,Byte>().Resize(100,100,INTER.CV_INTER_CUBIC);
         switch(PicturesToTake) {
         case 9:
            FaceBox1.Image = Result;
            Save1.Checked  = true;
            break;
         case 8:
            Result2        = Result;
            FaceBox2.Image = Result;
            break;
         case 7:
            Result3        = Result;
            FaceBox3.Image = Result;
            break;
         case 6:
            Result4        = Result;
            FaceBox4.Image = Result;
            break;
         case 5:
            Result5        = Result;
            FaceBox5.Image = Result;
            break;
         case 4:
            Result6        = Result;
            FaceBox6.Image = Result;
            break;
         case 3:
            Result7        = Result;
            FaceBox7.Image = Result;
            break;
         case 2:
            Result8        = Result;
            FaceBox8.Image = Result;
            break;
         case 1:
            Result9        = Result;
            FaceBox9.Image = Result;
            break;
         }
         Frame.Draw(f.rect,new Bgr(Color.Green),3);

         string   cmd   = "test?"+(PicturesToTake==MaxPictures ? "T?" : "F?")+NameBox.Text.Trim()+"?"+Convert.ToBase64String(Result.Bytes);
         string[] reply = Client.Request(cmd).Split('?');

         if(reply[0]=="OK") {

            if(reply[1]!="") {
               Frame.Draw(reply[1],ref Font,new Point(f.rect.X - 2,f.rect.Y - 2),new Bgr(Color.Black));
            }

            if(Processing) {
               if(reply[2]=="+") {
                  switch(PicturesToTake) {
                  case 8:
                     Save2.Checked = true;
                     break;
                  case 7:
                     Save3.Checked = true;
                     break;
                  case 6:
                     Save4.Checked = true;
                     break;
                  case 5:
                     Save5.Checked = true;
                     break;
                  case 4:
                     Save6.Checked = true;
                     break;
                  case 3:
                     Save7.Checked = true;
                     break;
                  case 2:
                     Save8.Checked = true;
                     break;
                  case 1:
                     Save9.Checked = true;
                     break;
                  }
               }
               PicturesToTake--;
               RemainingImages.Text = PicturesToTake.ToString();
               if(PicturesToTake==0) {
                  StopTraining();
               }
            }
         }

      }


         
      private void Start_Click(object sender,EventArgs e) {
         Save1.Checked   = false;
         Save2.Checked   = false;
         Save3.Checked   = false;
         Save4.Checked   = false;
         Save5.Checked   = false;
         Save6.Checked   = false;
         Save7.Checked   = false;
         Save8.Checked   = false;
         Save9.Checked   = false;
         FaceBox1.Image  = null;
         FaceBox2.Image  = null;
         FaceBox3.Image  = null;
         FaceBox4.Image  = null;
         FaceBox5.Image  = null;
         FaceBox6.Image  = null;
         FaceBox7.Image  = null;
         FaceBox8.Image  = null;
         FaceBox9.Image  = null;
         Processing      = true;
         Start.Enabled   = false;
         Stop.Enabled    = true;
         NameBox.Enabled = false;
         PicturesToTake  = MaxPictures;
         RemainingImages.Text = PicturesToTake.ToString();
         RemainingImages.Show();
         PicLabel.Show();
      }



      private void Stop_Click(object sender,EventArgs e) {
         StopTraining();
      }



      void StopTraining() {
         Processing      = false;
         Start.Enabled   = true;
         Stop.Enabled    = false;
         Save.Enabled    = true;
         RemainingImages.Hide();
         PicLabel.Hide();
      }



      private void Save_Click(object sender,EventArgs e) {
         if(Save2.Checked && FaceBox2.Image!=null) {
            Client.Request("save?"+NameBox.Text.Trim()+"?"+Convert.ToBase64String(Result2.Bytes));
         }
         if(Save3.Checked && FaceBox3.Image!=null) {
            Client.Request("save?"+NameBox.Text.Trim()+"?"+Convert.ToBase64String(Result3.Bytes));
         }
         if(Save4.Checked && FaceBox4.Image!=null) {
            Client.Request("save?"+NameBox.Text.Trim()+"?"+Convert.ToBase64String(Result4.Bytes));
         }
         if(Save5.Checked && FaceBox5.Image!=null) {
            Client.Request("save?"+NameBox.Text.Trim()+"?"+Convert.ToBase64String(Result5.Bytes));
         }
         if(Save6.Checked && FaceBox6.Image!=null) {
            Client.Request("save?"+NameBox.Text.Trim()+"?"+Convert.ToBase64String(Result6.Bytes));
         }
         if(Save7.Checked && FaceBox7.Image!=null) {
            Client.Request("save?"+NameBox.Text.Trim()+"?"+Convert.ToBase64String(Result7.Bytes));
         }
         if(Save8.Checked && FaceBox8.Image!=null) {
            Client.Request("save?"+NameBox.Text.Trim()+"?"+Convert.ToBase64String(Result8.Bytes));
         }
         if(Save9.Checked && FaceBox9.Image!=null) {
            Client.Request("save?"+NameBox.Text.Trim()+"?"+Convert.ToBase64String(Result9.Bytes));
         }
         Save1.Checked        = false;
         Save2.Checked        = false;
         Save3.Checked        = false;
         Save4.Checked        = false;
         Save5.Checked        = false;
         Save6.Checked        = false;
         Save7.Checked        = false;
         Save8.Checked        = false;
         Save9.Checked        = false;
         FaceBox1.Image       = null;
         FaceBox2.Image       = null;
         FaceBox3.Image       = null;
         FaceBox4.Image       = null;
         FaceBox5.Image       = null;
         FaceBox6.Image       = null;
         FaceBox7.Image       = null;
         FaceBox8.Image       = null;
         FaceBox9.Image       = null;
         RemainingImages.Text = "0";
         NameBox.Text         = "";
         Start.Enabled        = false;
         Stop.Enabled         = false;
         Save.Enabled         = false;
      }



   }



}