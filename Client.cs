using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkCommsDotNet;

namespace ClientApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //Printing a message that requests from the client to enter the IP of the server to connect (Stage 1)
            Console.WriteLine("Please enter the IP of the server along with the port:");
            string serverInfo = Console.ReadLine();

            //Parse the information that we got from stage 1 to the exact info we need to run the connection.
            // the serverIP will be a string
            string serverIP = serverInfo.Split(':').First();
            // the Port will be a port
            int serverPort = int.Parse(serverInfo.Split(':').Last());

            //Stored a integer that will count the message number
            int message_number = 1;

            while (true)
            {
                //Requseting the client to enter a message
                Console.WriteLine("What message do you want to send?");
                string ClientMessage = Console.ReadLine();

                //Stroing the message and then sending the message the client sent to the Client console
                string messageToSend = "This is message #"+message_number+ " - " +ClientMessage;
                Console.WriteLine("Sending message to server saying '" + messageToSend + "'");

                //Sending the message to the server console
                NetworkComms.SendObject("Message", serverIP, serverPort, messageToSend);

                //Asking the client if he would like to continue messaging with the server, else the client
                //can press 'Q' to break the operation and close the connection
                Console.WriteLine("\nPress q to quit or any other key to send another message.");
                if (Console.ReadKey(true).Key == ConsoleKey.Q) break;
                else message_number++;
            }

            //We have used comms so we make sure to call shutdown
            NetworkComms.Shutdown();
        }
    }
}