using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace libHitron2
{
    public class Authentication
    {
        public void ConnectAndLogin(string Username = "cusadmin", string Password = "password", string ip = "192.168.0.1")
        {
            //This is the login method. It will connect to the device and login with the given credentials.
            //It cannot use the Session.client because we don't know the values for things it needs yet - this provides them by
            //setting host, and storing the cookie in a retrivable format.
            Session.host = ip;
            var client = Session.client;
            using (var request = new HttpRequestMessage(new HttpMethod("POST"), "http://192.168.0.1/1/Device/Users/Login"))
            {
                //request.Content = new StringContent("model=%7B%22username%22%3A%22cusadmin%22%2C%22password%22%3A%22Boadway1%22%7D");
                request.Content = new StringContent("model={\"username\":\"" + Username + "\",\"password\":\"" + Password + "\"}");
                request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded; charset=UTF-8");
                var response = client.Send(request);
                Session.addCookie(Session.getPHPSessionID());
            }
        }
    }
}