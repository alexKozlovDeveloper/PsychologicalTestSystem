﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DbController.Repositoryes;
using DbController.TableEntityes;

namespace PsychologicalTestSystem
{
    class Program
    {
        public static void Main()
        {
        }

        //public static void Main()
        //{

        //    var rep = new TestingRepository();

        //    var groups = rep.GetAllGroup();//rep.AddGroup("151515");

        //    var group = groups.FirstOrDefault();

        //    rep.AddUser("Alexey", "Griboedov", group.Id);
        //    rep.AddUser("Ivan", "Genry", group.Id);
        //    rep.AddUser("Slava", "Pobeda", group.Id);
        //    rep.AddUser("Dovakin", "IsVindhelma", group.Id);


        //    String server = "";
        //    String message = "";

        //    try
        //    {
        //        // Create a TcpClient.
        //        // Note, for this client to work you need to have a TcpServer 
        //        // connected to the same address as specified by the server, port
        //        // combination.
        //        int port = 13000;
        //        TcpClient client = new TcpClient(server, port);

        //        // Translate the passed message into ASCII and store it as a Byte array.
        //        Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

        //        // Get a client stream for reading and writing.
        //        //  Stream stream = client.GetStream();

        //        NetworkStream stream = client.GetStream();

        //        // Send the message to the connected TcpServer. 
        //        stream.Write(data, 0, data.Length);

        //        Console.WriteLine("Sent: {0}", message);

        //        // Receive the TcpServer.response.

        //        // Buffer to store the response bytes.
        //        data = new Byte[256];

        //        // String to store the response ASCII representation.
        //        String responseData = String.Empty;

        //        // Read the first batch of the TcpServer response bytes.
        //        int bytes = stream.Read(data, 0, data.Length);
        //        responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
        //        Console.WriteLine("Received: {0}", responseData);

        //        // Close everything.
        //        stream.Close();
        //        client.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("ArgumentNullException: {0}", e);
        //    }

        //    Console.WriteLine("\n Press Enter to continue...");
        //    Console.Read();
        //}
    }
}
