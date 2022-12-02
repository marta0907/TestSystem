using BLL.Managers;
using BLL.Services;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientServer
{
    public class Server
    {
        private UserService userService = new UserService();
        private ResultService resultService = new ResultService();
        private Socket serverSocket = new Socket(AddressFamily.InterNetwork,
                                            SocketType.Stream,
                                            ProtocolType.Tcp);
        private byte[] buffer = new byte[1024 * 1024];
        private int port = 8080;
        private IPAddress ip = IPAddress.Parse("127.0.0.1");
        private List<Socket> clientSockets = new List<Socket>();
        public Dictionary<Socket,string> _clientsNames = new Dictionary<Socket, string>();
        public void SetupServer()
        {
            try
            {
                serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
                serverSocket.Listen(1);
                serverSocket.BeginAccept(AcceptCallback, null);
            }
            catch 
            {
                return;
            }
        }

        void AcceptCallback(IAsyncResult AR)
        {
            Socket socket;

            try
            {
                socket = serverSocket.EndAccept(AR);
            }
            catch (ObjectDisposedException)
            {
                return;
            }

            clientSockets.Add(socket);
            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallback, socket);
            Console.WriteLine("Client connected, waiting for request...");
            serverSocket.BeginAccept(AcceptCallback, null);
        }

        void ReceiveCallback(IAsyncResult AR)
        {
            Socket current = (Socket)AR.AsyncState;
            int received;

            try
            {
                received = current.EndReceive(AR);
            }
            catch (SocketException)
            {
                Console.WriteLine("Client forcefully disconnected");
                current.Close();
                clientSockets.Remove(current);
                _clientsNames.Remove(current);
                return;
            }

            byte[] recBuf = new byte[received];
            Array.Copy(buffer, recBuf, received);
            string text = Encoding.ASCII.GetString(recBuf);
            Console.WriteLine(text);

            if (text.ToLower() == Constants.exitRequest)
            {
                current.Shutdown(SocketShutdown.Both);
                current.Close();
                clientSockets.Remove(current);
                _clientsNames.Remove(current);
                Console.WriteLine("Client disconnected");
            }
            else
            { 
                try
                {
                    string response = Response(text,current);
                    byte[] data = Encoding.ASCII.GetBytes(response);
                    current.Send(data);
                }
                catch 
                { 
                    return; 
                };
                current.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallback, current);
            }
        }

        string Response(string request, Socket socket)
        {
            if (request.StartsWith(Constants.loginRequest))
            {
                return LoginResponse(request, socket);
            }
            else if (request.StartsWith(Constants.saveResultRequest))
            {
                Console.WriteLine("SaveResultResponse");
                return SaveResultResponse(request);
            }
            else if (request.StartsWith(Constants.getAssignedTestsRequest))
            {
                return SendAssignedTestsToUser(request);
            }
            else return "invalid request";
        }

        string LoginResponse(string request, Socket socket)
        {
            var originalrequst = request.Remove(0, Constants.loginRequest.Length);
            var credentialsManager = new JsonSerializationManager<Credentials>();
            var credentials = credentialsManager.Deserialize(originalrequst);

            if (credentials == null) return Constants.failResponse;

            var user = userService.AuthenticateUser(credentials.Login, credentials.Password);
            _clientsNames.Add(socket,$"{user?.First_Name} {user?.Last_Name}");
            var manager = new JsonSerializationManager<User>();
            var res = manager.Serialize(user);

            if (res is null) return Constants.failResponse;
            return res;
        }

        string SaveResultResponse(string request)
        {
            var originalrequst = request.Remove(0, Constants.saveResultRequest.Length);
            var manager = new JsonSerializationManager<TestingInformation>();
            var userTest = manager.Deserialize(originalrequst);

            if (userTest == null) return Constants.failResponse;

            var result = resultService.CalculateResult( userTest.userId,
                                                        userTest.testId,
                                                        userTest.test, 
                                                        userTest.date);
            resultService.SaveResult(result);
            var resultManager = new JsonSerializationManager<Result>();
            var res = resultManager.Serialize(result);

            if (res is null) return Constants.failResponse;
            return res;
        }

        string SendAssignedTestsToUser(string request)
        {
            var originalrequst = request.Remove(0, Constants.getAssignedTestsRequest.Length);
            var manager = new JsonSerializationManager<User>();
            var user = manager.Deserialize(originalrequst);

            var tests = userService.GetAssignedTests(user);
            var testsList = new TestsList() { tests = tests };

            var manager1 = new JsonSerializationManager<TestsList>();
            var res = manager1.Serialize(testsList);
            return res;
        }

        public void CloseAllSockets()
        {
            foreach (Socket socket in clientSockets)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }

            serverSocket.Close();
        }
    }
}
