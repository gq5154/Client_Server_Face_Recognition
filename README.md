# Client/Server Face Recognition System

This is a Client/Server implementation of a Face Recognition System. The server binds names and images and stores them on a local database. The client takes an image from the WebCam and sends it to the server, the server then compares the picture taken by the client and if it finds a match returns the person's name to the client. The client can additionaly start a recognition session in which 9 pictures are taken to the subject in front of the camera, after all 9 pictures have been taken, they are sent to the server together with the person's name to be stored on the database.

Please be aware that this is just an experimental project, a proof of concept only and because of that you cannot expect robustnes.

# Before you build

- Make sure the target platform is set to x86, on both, client and server.
- Edit **Client.cs** line **18**, to set the value of **Server** to match the name of the machine running the server.
- The default port is 81, if for whatever reason you want to change it, you have to edit lines **18** on **Client.cs** and **135** on **Server.cs**

# After you build

- Copy all the contents of the **Emgu_OK** folder to the folder in which your **.exe** files were built. That is, copy these files for both client and server.
- Copy **haarcascade_frontalface_default.xml** to the folder in which your **.exe** files were built. Again this applies for both executables.
- Inside the folder that contains the server executable, create a folder named **Data**.
 
