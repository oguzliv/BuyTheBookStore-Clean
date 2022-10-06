using BuyTheBookStore.Core.Entities;
using BuyTheBookStore.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTheBookStore.Application.Services.RecommendationService
{
    public class RecommendationService:IRecommendationService
    {
        private readonly IBookRepository _bookRepository;
        public RecommendationService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<object> RecommendBook(string genre)
        {
            var recommendedBooks = await _bookRepository.GetRecommendedBooks(genre);
            if (recommendedBooks == null)
                return null;
            else
                return recommendedBooks;
        }
    }
}
