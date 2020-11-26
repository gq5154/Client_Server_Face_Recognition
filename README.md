# Client/Server Face Recognition System

This is projects implements a Client/Server, Face Recognition System based on EmguCV. The client can starts a recognition session in which 9 pictures are taken to the subject in front of the camera, after all 9 pictures have been taken, they are sent to the server together with the person's name. The server then binds the name and images together and stores them on a local database. The client is continouslly analizing the images from the WebCam and when it detects a face, it and sends the corresponding picture to the server. The server seeks the image on its database and if it finds a match, it returns the person's name to the client, so the client can dispaly that name above the detected face. Theoretically it can identify two or more persons standing in fron the camera.  

Please be aware that this is just an experimental project, a proof of concept only and because of that you cannot expect robustnes.

# Before you build

- Make sure the target platform is set to x86, on both, client and server.
- Edit **Client.cs** line **18**, to set the value of **Server** to match the name or the IP address of the machine running the server.
- The default port is 81, if for whatever reason you want to change it, you have to edit lines **18** on **Client.cs** and **135** on **Server.cs**

# After you build

- Copy all the files inside of the **Emgu_OK** folder to the folder in which your **.exe** files were built. That is, copy these files for both client and server.
- Copy **haarcascade_frontalface_default.xml** to the folder in which your **.exe** files were built. Again, this applies for both executables.
- Inside the folder that contains the server executable, create a folder named **Data**.
- Once you reach this point you're ready to go.
 
