using Alejandria.WebAPI.Implementation.Business.NewsFeedManagment.Handlers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alejandria.WebAPI.Implementation.Business.NewsFeedManagment.Controllers
{
    [ApiController]
    [Route("/v1/[controller]/[action]")]
    public class NewsFeedManagmentController : ControllerBase
    {
        private readonly ISendFeedSyncHandler _sendFeedSyncHandler;

        public NewsFeedManagmentController(ISendFeedSyncHandler sendFeedSyncHandler)
        {
            _sendFeedSyncHandler = sendFeedSyncHandler;
        }

        [HttpPost]
        public async Task<IActionResult> SendFeedSyncTest()
        {
            return Ok(await _sendFeedSyncHandler.SendFeed());
        }
    }
}
