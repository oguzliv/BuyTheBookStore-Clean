using BuyTheBookStore.Application.Dtos.OrderAPIDtos;
using BuyTheBookStore.BuyTheBookStore.Core.Entities;
using BuyTheBookStore.DataAccess.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTheBookStore.Application.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBookRepository _bookRepository;
        public OrderService(IOrderRepository orderRepository, IBookRepository bookRepository)
        {
            _orderRepository = orderRepository;
            _bookRepository = bookRepository;
        }
        public async Task<object> CreateOrder(Guid id, OrderDto orderDto)
        {
            Order order = new Order();
            order.UserId = id;
            order.Id = Guid.NewGuid();
            order.OrderedBooks = new Dictionary<Guid, int>();

            //double ordertotalPrice = 0;
            foreach (var book in orderDto.OrderItems)
            {
                //validate books
                var orderedBook = await _bookRepository.GetById(book.BookId); /*await _db.Books.FirstOrDefaultAsync(b => b.Id == book.BookId);*/

                if (orderedBook == null)
                    return null;
                //calculate total
                order.Price += orderedBook.Price * book.Count;
                orderedBook.SellCount += book.Count;

                order.OrderedBooks.Add(book.BookId, book.Count);
                //update book table
                //_db.Books.Update(orderedBook);
                await _bookRepository.Update(orderedBook);
                //_db.SaveChanges();
            }

            //write order into db
            //_db.Orders.Add(order);
            //try
            //{

            //}catch (Exception ex)
            //{
            //    return null;
            //}
            await _orderRepository.Create(order);

            //_db.SaveChanges();

            return order;
            //throw new NotImplementedException();
        }

        public async Task<object> DeleteOrder(Guid id)
        {
            var order = await _orderRepository.GetById(id);/*await _db.Orders.FirstOrDefaultAsync(o => o.OrderId == id);*/
            

            foreach (var item in order.OrderedBooks)
            {
                //var bookId = Guid.Parse(item["BookId"].ToString());
                var book = await _bookRepository.GetById(item.Key);/*await _db.Books.FirstOrDefaultAsync(b => b.Id == item.Key);*/

                if (book == null)
                    return null;

                book.SellCount -= (int)item.Value;

                //_db.Books.Update(book);
                await _bookRepository.Update(book);
            }
            //_db.Orders.Remove(order);
            //_db.SaveChanges();

            await _orderRepository.Delete(order);
            return order;
        }

        public async Task<object> GetOrder(Guid id)
        {
            var order = await _orderRepository.GetById(id);
            if (order == null)
                return null;
            else
                return order;
        }

        public async Task<object> GetOrders()
        {
            var orders = await _orderRepository.Get();
            if (orders == null)
                return null;
            else
                return orders;
        }

        public async Task<object> GetUserOrders(Guid id)
        {
            var orders = await _orderRepository.GetOrderByUser(id);
            if (orders == null)
                return null;
            else
                return orders;
        }

        public async Task<object> UpdateOrder(Guid id, OrderUpdateDto orderDto)
        {
            double newPrice = 0;

            var order = await _orderRepository.GetById(id); /*await _db.Orders.FirstOrDefaultAsync(o => o.OrderId == id);*/

            if (order == null)
                return null;

            var jOrderUpdateDto = JObject.Parse(JsonConvert.SerializeObject(orderDto));
            var jOrderItems = jOrderUpdateDto["Orders"];

            foreach (var item in jOrderItems)
            {
                var bookId = Guid.Parse(item["BookId"].ToString());
                var book = await _bookRepository.GetById(bookId); /*await _db.Books.FirstOrDefaultAsync(b => b.Id == bookId);*/

                if (book == null)
                    continue;

                var oldSellCount = book.SellCount - order.OrderedBooks[bookId];
                order.OrderedBooks[bookId] = (int)item["Count"];
                newPrice += book.Price * (int)item["Count"];
                book.SellCount = oldSellCount + (int)item["Count"];

                //_db.Books.Update(book);
                await _bookRepository.Update(book);
            }
            order.Price = newPrice;

            //_db.Orders.Update(order);

            //_db.SaveChanges();
            await _orderRepository.Update(order);

            return order;
        }
    }
}
