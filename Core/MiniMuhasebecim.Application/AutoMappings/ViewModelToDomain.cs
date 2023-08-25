using AutoMapper;
using MiniMuhasebecim.Application.Models.RequestModels.AccountRM;
using MiniMuhasebecim.Application.Models.RequestModels.CategoryRM;
using MiniMuhasebecim.Application.Models.RequestModels.CustomerImageRM;
using MiniMuhasebecim.Application.Models.RequestModels.CustomerRM;
using MiniMuhasebecim.Application.Models.RequestModels.DebtRM;
using MiniMuhasebecim.Application.Models.RequestModels.IncomeRM;
using MiniMuhasebecim.Application.Models.RequestModels.OrderRM;
using MiniMuhasebecim.Application.Models.RequestModels.PaymentRM;
using MiniMuhasebecim.Application.Models.RequestModels.WholasalerRM;
using MiniMuhasebecim.Domain.Entities;

namespace MiniMuhasebecim.Application.AutoMappings
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            //Kullanıcı oluşturma isteği
            CreateMap<RegisterVM, Customer>();
            CreateMap<RegisterVM, Account>()
                .ForMember(x => x.Role, y => y.MapFrom(e => Roles.User));

            CreateMap<UpdateUserVM, Customer>();

            //Customer
            CreateMap<GetCustomerByIdVM, Customer>();
            CreateMap<UpdateCustomerVM, Customer>();
            CreateMap<UpdateCustomerVM, Account>();


            //CustomerImage
            CreateMap<CreateCustomerImageVM, CustomerImage>();

            //Category
            CreateMap<CreateCategoryVM, Category>()
                .ForMember(x => x.CategoryName, y => y.MapFrom(e => e.CategoryName.ToUpper().Trim()));
            CreateMap<UpdateCategoryVM, Category>()
                .ForMember(x => x.CategoryName, y => y.MapFrom(e => e.CategoryName.ToUpper().Trim()));
            CreateMap<DeleteCategoryVM, Category>();
            CreateMap<GetCategoryByIdVM, Category>();

            //Debt
            CreateMap<CreateDebtVM, Debt>();
            CreateMap<UpdateDebtVM, Debt>();
            CreateMap<GetDebtByIdVM, Debt>();

            //Income
            CreateMap<CreateIncomeVM, Income>();
            CreateMap<UpdateIncomeVM, Income>();
            CreateMap<GetIncomeByIdVM, Income>();

            //Order
            CreateMap<CreateOrderVM, Order>();
            CreateMap<UpdateOrderVM, Order>();
            CreateMap<GetOrderByIdVM, Order>();

            //Payment
            CreateMap<CreatePaymentVM, Payment>();
            CreateMap<UpdatePaymentVM, Payment>();
            CreateMap<GetPaymentByIdVM, Payment>();

            //Wholesaler
            CreateMap<CreateWholesalerVM, Wholesaler>()
                .ForMember(x => x.WholesalerName, y => y.MapFrom(e => e.WholesalerName.ToUpper().Trim()));
            CreateMap<UpdateWholesalerVM, Wholesaler>()
                .ForMember(x => x.WholesalerName, y => y.MapFrom(e => e.WholesalerName.ToUpper().Trim()));
            CreateMap<DeleteWholesalerVM, Wholesaler>();
            CreateMap<GetWholesalerByIdVM, Wholesaler>();
        }
    }
}
