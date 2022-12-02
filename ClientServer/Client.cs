using BLL.Managers;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientServer
{
    public class Client
    {



        private Socket _client = new Socket(AddressFamily.InterNetwork,
                                           SocketType.Stream,
                                           ProtocolType.Tcp);
        private int port = 8080;
        private IPAddress ip = IPAddress.Parse("127.0.0.1");
        public bool Connected
        {
            get => _client.Connected;
        }
        public void ConnectToServer()
        {
            while (!_client.Connected)
            {
                try
                {
                    _client.Connect(IPAddress.Loopback, port);
                }
                catch (SocketException)
                {
                }
            }
        }
        public void Exit()
        {
            SendRequest("exit");
            ReceiveResponse();
            try
            {
                _client.Shutdown(SocketShutdown.Both);
            }
            catch (SocketException ex) { }
            _client.Close();
        }
        private void SendRequest(string text)
        {
            var buffer = Encoding.UTF8.GetBytes(text);
            try
            {
                _client.Send(buffer, 0, buffer.Length, SocketFlags.None);
            }
            catch (SocketException ex) { }
        }
        private string ReceiveResponse()
        {
            var buffer = new byte[1024 * 1024];
            int received = 0;
            try
            {
                received = _client.Receive(buffer, SocketFlags.None);
            }
            catch { }
            if (received == 0) return null;

            var data = new byte[received];
            Array.Copy(buffer, data, received);
            string text = Encoding.ASCII.GetString(data);
            return text;
        }

        public User Authenticate(string login, string password)
        {
            var credentialsManager = new JsonSerializationManager<Credentials>();
            Credentials credentials = new Credentials()
            {
                Login = login,
                Password = password
            };
            string jsonCredentials = credentialsManager.Serialize(credentials);

            SendRequest(Constants.loginRequest + jsonCredentials);
            var user = ReceiveResponse();

            var userManager = new JsonSerializationManager<User>();
            var res = userManager.Deserialize(user);
            Console.WriteLine(res);
            return res;
        }

        public Result SaveTestingResult(Test test, User user)
        {
            var testingInf = new TestingInformation()
            {
                userId = user.Id,
                testId = test.Id,
                test = test,
                date = DateTime.Today
            };
            var testManager = new JsonSerializationManager<TestingInformation>();
            var jsonResult = testManager.Serialize(testingInf);

            SendRequest(Constants.saveResultRequest + jsonResult);
            var result = ReceiveResponse();

            var resultManager = new JsonSerializationManager<Result>();
            return resultManager.Deserialize(result);
        }

        public List<Test> GetAssignedTests(User user)
        {
            JsonSerializationManager<User> userManager = new JsonSerializationManager<User>();
            var jsonUser = userManager.Serialize(user);

            SendRequest(Constants.getAssignedTestsRequest + jsonUser);
            var response = ReceiveResponse();

            JsonSerializationManager<TestsList> listTestManager = new JsonSerializationManager<TestsList>();
            return listTestManager.Deserialize(response).tests;
        }
    }
}
