using AutoMapper;
using Entities.Models;
using PersonalFinance.Domain.DTO.Transaction;

namespace PersonalFinance.UI.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction, TransactionDTO>()
                .ReverseMap();

            CreateMap<AddTransactionDTO, Transaction>();
        }
    }
}
