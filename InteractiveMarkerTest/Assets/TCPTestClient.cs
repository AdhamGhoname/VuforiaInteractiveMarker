using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class TCPTestClient : MonoBehaviour
{
    private TcpClient socketConnection;
    private Thread clientReceiveThread;


    void Start()
    {
        Connect();
    }


    private void Connect()
    {
        try
        {
            clientReceiveThread = new Thread(new ThreadStart(Listen));
            clientReceiveThread.IsBackground = true;
            clientReceiveThread.Start();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    
    private void Listen()
    {
        try
        {
            socketConnection = new TcpClient("192.168.43.1", 8052);
            Byte[] bytes = new Byte[1024];
            while (true)
            {
                using (NetworkStream stream = socketConnection.GetStream())
                {
                    int length;
                    while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        var read = new byte[length];
                        Array.Copy(bytes, 0, read, 0, length);
                        string serverMessage = Encoding.ASCII.GetString(read);
                    }
                }
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }

    public new void SendMessage(string s)
    {
        if (socketConnection == null)
        {
            return;
        }
        try
        {
            NetworkStream stream = socketConnection.GetStream();
            if (stream.CanWrite)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(s);
                stream.Write(buffer, 0, buffer.Length);
            }
        }
        catch (SocketException e)
        {
            Debug.Log(e);
        }
    }
}