using Alejandria.NotificationService.Contract.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alejandria.WebAPI.Implementation.Business.NewsFeedManagment.Handlers
{
    public interface ISendFeedSyncHandler
    {
        Task<SendEmailResponseDto> SendFeed();
    }
}
