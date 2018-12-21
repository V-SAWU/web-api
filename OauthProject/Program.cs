using OauthCommon;
using OauthModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OauthProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Get user list");
            Console.WriteLine();
            ReturnObject returnObj = new ReturnObject();
            var json = HttpTools.HttpGet(ReadHelper.HttpUrl + "api/GetUserList");
            if (!string.IsNullOrEmpty(json))
            {
                returnObj = JsonHelper.DeserializeObject<ReturnObject>(json);
                if (returnObj.Result != 100)
                {
                    Console.WriteLine("Result :{0} Message :{1}", returnObj.Result, returnObj.Message); 
                    Console.WriteLine("Sorry, you can't get the list of users ,please log in");
                    Console.WriteLine("");
                }
            }
             
            Console.WriteLine("Please enter your username and password");
            Console.Write("please input username:");
            string name = Convert.ToString(Console.ReadLine());
            Console.Write("please input password:");
            string password = Convert.ToString(Console.ReadLine()); 
            Console.WriteLine("");

            User user = new User();
            user.Name = name;
            user.Password = password;

            json = HttpTools.HttpPost(ReadHelper.HttpUrl + "api/GetToken",user);
            if (!string.IsNullOrEmpty(json))
            {
                returnObj = JsonHelper.DeserializeObject<ReturnObject>(json);
                if (returnObj.Result == 100)
                {
                    ReadHelper.Token = returnObj.Data.ToString();
                    Console.WriteLine("Login successful");
                    Console.WriteLine("");
                }
            }
            Console.WriteLine("Get the user list again");
            json = HttpTools.HttpGet(ReadHelper.HttpUrl + "api/GetUserList");
            List<User> userList = null;
            if (!string.IsNullOrEmpty(json))
            {
                returnObj = JsonHelper.DeserializeObject<ReturnObject>(json);
                if (returnObj.Result == 100)
                {
                    userList = JsonHelper.DeserializeObject<List<User>>(returnObj.Data.ToString());
                }
            }
            if (userList != null && userList.Count > 0)
            {
                foreach (var item in userList)
                {
                    Console.WriteLine("ID :{0} Name :{1} Password :{2}", item.ID, item.Name,item.Password);
                }
            }

            Console.WriteLine("");
            Console.ReadLine();
        } 
    }
}
