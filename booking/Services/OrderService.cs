using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using booking.common.ViewModel;
using booking.Infrustructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace booking.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<OrderService> _logger;
        private readonly UrlHosts _urls;


        public OrderService(HttpClient httpClient, ILogger<OrderService> logger, IOptions<UrlHosts> config)
        {
            _httpClient = httpClient;
            _logger = logger;
            _urls = config.Value;
        }

        public async Task Create(OrderModel model)
        {
            await _httpClient.PostAsJsonAsync(_urls.Flight + "/api/order", model);
        }

        public async Task<IEnumerable<OrderModel>> GetAll(int page, int size)
        {
            var data = await _httpClient.GetStringAsync(_urls.Flight + $"/api/order?page={page}&size={size}");
            var aircrafts = !string.IsNullOrEmpty(data)
                ? JsonConvert.DeserializeObject<IEnumerable<OrderModel>>(data)
                : null;
            return aircrafts;
        }

        public async Task<OrderModel> GetByFlightId(string id)
        {
            var data = await _httpClient.GetStringAsync(_urls.Flight + $"/api/getbyflightid/{id}");
            var aircraft = !string.IsNullOrEmpty(data) ? JsonConvert.DeserializeObject<OrderModel>(data) : null;
            return aircraft;
        }

        public async Task<OrderModel> GetById(string id)
        {
            var data = await _httpClient.GetStringAsync(_urls.Flight + $"/api/order/{id}");
            var aircraft = !string.IsNullOrEmpty(data) ? JsonConvert.DeserializeObject<OrderModel>(data) : null;
            return aircraft;
        }

        public async Task Remove(string id)
        {
            await _httpClient.DeleteAsync(_urls.Flight + $"/api/order/{id}");
        }

        public async Task Update(string id, OrderModel model)
        {
            await _httpClient.PutAsJsonAsync(_urls.Flight + $"/api/order/{id}", model);
        }
    }
}
