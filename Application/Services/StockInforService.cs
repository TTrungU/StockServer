using Application.Abtraction.IServices;
using Application.Models.StockInforModel;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.IRepositories;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class StockInforService : IStockInforService
    {
        private readonly IStockInforRepository _stockInforRepository;
        private readonly IMapper _mapper;

        public StockInforService(IStockInforRepository stockInforRepository, IMapper mapper)
        {
            _stockInforRepository = stockInforRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StockInforResponse>> GetAllStockInforAsync()
        {
            var stock = await _stockInforRepository.GetListStockInfor();
            if (stock == null)
                throw new NotFoundException("Data not found");
            return _mapper.Map<IEnumerable<StockInforResponse>>(stock);
        }

        public async Task<StockInforResponse> GetStockInforAsync(string symbol, DateTime?startDay, DateTime? endDay)
        {
            var stock = await _stockInforRepository.GetSotckData(symbol, startDay, endDay);
            if (stock == null)
                throw new NotFoundException("Data not found");
            
            return _mapper.Map<StockInforResponse>(stock);
        }

        public async Task<StockInforDetailResponse> GetStockInforDetatilAsync(int stockInforId)
        {
            var stockinfor = await _stockInforRepository.GetDetailStockInfor(stockInforId);
            if (stockinfor == null)
                throw new NotFoundException("Not found stock");
            return stockinfor;

        }
    }
}
