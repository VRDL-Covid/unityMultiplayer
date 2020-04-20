using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using UnityEngine;

public class clientManager : MonoBehaviour
{
    Socket clientSocket;

    byte[] dataBuffer;
    private void Awake()
    {
        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        dataBuffer = new byte[1024];
        try
        {
            clientSocket.Connect("127.0.0.1", 8002);
            Debug.Log("connected!");
        } catch (Exception e)
        {
            Debug.Log(e);
        }
    }
    private void Start()
    {
     clientSocket.BeginReceive(dataBuffer, 0, dataBuffer.Length, SocketFlags.None, recieveCallback, null);
    }
    private void recieveCallback(IAsyncResult ar)
    {
        int count = clientSocket.EndReceive(ar);
        string msgRecieve = Encoding.UTF8.GetString(dataBuffer, 0, dataBuffer.Length);
        Debug.Log(msgRecieve);
        Array.Clear(dataBuffer, 0, dataBuffer.Length);
        clientSocket.BeginReceive(dataBuffer, 0, dataBuffer.Length, SocketFlags.None, recieveCallback, null);
    }

    private void OnDestroy()
    {
        try
        {
            clientSocket.Close();
            Debug.Log("closed!");
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }


}
