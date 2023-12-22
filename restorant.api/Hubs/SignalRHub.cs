using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using restorant.data;

namespace restorant.api.Hubs
{
    public class SignalRHub : Hub
    {
        RestorantContext context = new RestorantContext();
        public async Task SendCategoryCount()
        {
            var values = context.Categorys.Count();
            await Clients.All.SendAsync("ReceiveCategoryCount", values);
        }
    }
}