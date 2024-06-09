using Application.Abtraction.IServices;
using Application.Models.WalletHistory;
using AutoMapper;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class WalletHistoryService : IWalletHistoryService
    {
        private readonly IWalletHistoryRepository _walletHistoryRepository;
        private readonly IMapper _mapper;
        public WalletHistoryService(IWalletHistoryRepository walletHistoryRepository, IMapper mapper)
        {
            _walletHistoryRepository = walletHistoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WalletHistoryResponse>> GetWalletHistoriesAsync(int walletId)
        {
            var wallets = await _walletHistoryRepository.FindByCondition(w => w.WalletId == walletId).OrderByDescending(w => w.CreateAt).ToListAsync();
      
            return _mapper.Map<IEnumerable<WalletHistoryResponse>>(wallets);
        }
    }
}
