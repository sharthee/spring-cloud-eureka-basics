using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageService.Services;
using Microsoft.AspNetCore.Mvc;

namespace MessageService.Controllers
{
    public class HealthController : Controller
    {
        private readonly ExampleHealthIndicator _exampleHealthIndicator;

        public HealthController(ExampleHealthIndicator exampleHealthIndicator)
        {
            _exampleHealthIndicator = exampleHealthIndicator;
        }

        [Route("/status")]
        public String Get()
        {
            return $"Health Checks Will Pass: {_exampleHealthIndicator.State}";
        }

        [Route("/fail")]
        public String Fail()
        {
            _exampleHealthIndicator.State = false;
            return $"Health Checks Will Pass: {_exampleHealthIndicator.State}";
        }

        [Route("/pass")]
        public String Pass()
        {
            _exampleHealthIndicator.State = true;
            return $"Health Checks Will Pass: {_exampleHealthIndicator.State}";
        }
    }
}
