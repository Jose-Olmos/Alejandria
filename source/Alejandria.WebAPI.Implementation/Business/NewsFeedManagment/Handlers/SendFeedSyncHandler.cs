using Alejandria.NotificationService.Contract.Dtos;
using Devon4Net.Infrastructure.CircuitBreaker.Handler;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Alejandria.WebAPI.Implementation.Business.NewsFeedManagment.Handlers
{
    public class SendFeedSyncHandler : ISendFeedSyncHandler
    {
        private readonly IHttpClientHandler _httpClientHandler;
        private const string endpoint = "NotificationService";
        private Guid tempalteId = Guid.NewGuid();

        public SendFeedSyncHandler(IHttpClientHandler httpClientHandler)
        {
            _httpClientHandler = httpClientHandler;
        }

        public async Task<SendEmailResponseDto> SendFeed()
        {
            var request = new SendEmailRequestDto
            {
                To = "test.cap@gemini.com",
                From = "test2.cap@gemini.com",
                Params = new { Username = "Pepe", Book = "book", Author = "Juano" },
                TemplateId = tempalteId
            };

            return await _httpClientHandler.Send<SendEmailResponseDto>(
                HttpMethod.Post,
                endpoint,
                "/V1/EmailManagment/SendEmail",
                request,
                "application/json");
        }
    }
}
