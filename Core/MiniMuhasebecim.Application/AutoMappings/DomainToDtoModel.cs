using AutoMapper;
using MiniMuhasebecim.Application.Models.Dtos.AccountDtos;
using MiniMuhasebecim.Application.Models.Dtos.CategoryDtos;
using MiniMuhasebecim.Application.Models.Dtos.CustomerDtos;
using MiniMuhasebecim.Application.Models.Dtos.CustomerImageDtos;
using MiniMuhasebecim.Application.Models.Dtos.DebtDtos;
using MiniMuhasebecim.Application.Models.Dtos.IncomeDtos;
using MiniMuhasebecim.Application.Models.Dtos.OrderDtos;
using MiniMuhasebecim.Application.Models.Dtos.PaymentDtos;
using MiniMuhasebecim.Application.Models.Dtos.WholasalerDtos;
using MiniMuhasebecim.Domain.Entities;

namespace MiniMuhasebecim.Application.AutoMappings
{
    public class DomainToDtoModel : Profile
    {
        public DomainToDtoModel()
        {
            CreateMap<Account, AccountDto>();

            CreateMap<Category, CategoryDto>();

            CreateMap<Customer, CustomerDto>();

            CreateMap<CustomerImage, CustomerImageDto>();
            CreateMap<CustomerImage, CustomerImageWithCustomerDto>();

            CreateMap<Debt, DebtDto>();

            CreateMap<Income, IncomeDto>();

            CreateMap<Order, OrderDto>();

            CreateMap<Payment, PaymentDto>();

            CreateMap<Wholesaler, WholesalerDto>();

        }
    }
}
