using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTheBookStore.Application.Services.RecommendationService
{
    public interface IRecommendationService
    {
        Task<object> RecommendBook(string genre);
    }
}
