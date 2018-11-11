using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using IBM.WatsonDeveloperCloud.Assistant.v1;
using IBM.WatsonDeveloperCloud.Assistant.v1.Model;
using WatsonAssistant.Models;
using IBM.WatsonDeveloperCloud.Util;

namespace WatsonAssistant.Controllers
{
    public class HomeController : Controller
    {
        private AssistantService _assistant;
        private MessageResponse response;
        private string v1VersionDate = "2018-02-16";

        public IActionResult Index()
        {
            _assistant = new AssistantService();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public string Message(string message)
        {

            TokenOptions iamAssistantTokenOptions = new TokenOptions()
            {
                IamApiKey = "api key",
                ServiceUrl = "https://gateway-wdc.watsonplatform.net/assistant/api"
            };

            _assistant = new AssistantService(iamAssistantTokenOptions, "2018-02-16");
            response = new MessageResponse();

            //  create message request
            MessageRequest messageRequest0 = new MessageRequest()
            {
                Input = new InputData()
                {
                    Text = message
                },
                Context = HttpContext.Session.Get("Context")
            };

            //  send a message to the assistant instance
            response = _assistant.Message("workspace id", messageRequest0);

            return response.Output["text"][0].ToString();
        }
    }
}
