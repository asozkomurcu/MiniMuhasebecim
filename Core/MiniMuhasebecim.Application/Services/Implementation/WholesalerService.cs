using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MiniMuhasebecim.Application.Behaviors;
using MiniMuhasebecim.Application.Exceptions;
using MiniMuhasebecim.Application.Models.Dtos.WholasalerDtos;
using MiniMuhasebecim.Application.Models.RequestModels.WholasalerRM;
using MiniMuhasebecim.Application.Services.Abstraction;
using MiniMuhasebecim.Application.Validators.WholesalersValidators;
using MiniMuhasebecim.Application.Wrapper;
using MiniMuhasebecim.Domain.Entities;
using MiniMuhasebecim.Domain.UWork;

namespace MiniMuhasebecim.Application.Services.Implementation
{
    public class WholesalerService : IWholesalerService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _uwork;

        public WholesalerService(IMapper mapper, IUnitWork uwork)
        {
            _mapper = mapper;
            _uwork = uwork;
        }

        public async Task<Result<List<WholesalerDto>>> GetAllWholesaler()
        {
            var result = new Result<List<WholesalerDto>>();

            var wholesalerEntites = await _uwork.GetRepository<Wholesaler>().GetAllAsync();

            var wholesalerDtos = await wholesalerEntites.ProjectTo<WholesalerDto>(_mapper.ConfigurationProvider).ToListAsync();
            result.Data = wholesalerDtos;
            _uwork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(GetWholesalerByIdValidator))]
        public async Task<Result<WholesalerDto>> GetWholesalerById(GetWholesalerByIdVM getWholesalerByIdVM)
        {
            var result = new Result<WholesalerDto>();

            var wholesalerEntites = await _uwork.GetRepository<Wholesaler>().GetSingleByFilterAsync(x => x.Id == getWholesalerByIdVM.Id);
            if (wholesalerEntites == null)
            {
                throw new NotFoundException($"{getWholesalerByIdVM.Id} numaralı tedarikci bulunamadı.");
            }

            var wholesalerDtos = _mapper.Map<WholesalerDto>(wholesalerEntites);
            result.Data = wholesalerDtos;
            return result;
        }

        [ValidationBehavior(typeof(CreateWholesalerValidator))]
        public async Task<Result<int>> CreateWholesaler(CreateWholesalerVM createWholesalerVM)
        {
            var result = new Result<int>();

            var wholesalerEntites = _mapper.Map<CreateWholesalerVM, Wholesaler>(createWholesalerVM);

            _uwork.GetRepository<Wholesaler>().Add(wholesalerEntites);
            await _uwork.CommitAsync();

            result.Data = wholesalerEntites.Id;
            _uwork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(UpdateWholesalerValidator))]
        public async Task<Result<bool>> UpdateWholesaler(UpdateWholesalerVM updateWholesalerVM)
        {
            var result = new Result<bool>();

            var wholesalerEntites = await _uwork.GetRepository<Wholesaler>().GetSingleByFilterAsync(x => x.Id == updateWholesalerVM.Id);
            if (wholesalerEntites == null)
            {
                throw new NotFoundException($"{updateWholesalerVM.Id} numaralı tedarikci bulunamadı.");
            }

            var existsWholesalerEntity = await _uwork.GetRepository<Wholesaler>().GetById(updateWholesalerVM.Id.Value);

            _mapper.Map(updateWholesalerVM, existsWholesalerEntity);

            _uwork.GetRepository<Wholesaler>().Update(existsWholesalerEntity);

            result.Data = await _uwork.CommitAsync();
            return result;
        }

        [ValidationBehavior(typeof(DeleteWholesalerValidator))]
        public async Task<Result<bool>> DeleteWholesaler(DeleteWholesalerVM deleteWholesalerVM)
        {
            var result = new Result<bool>();

            var wholesalerEntites = await _uwork.GetRepository<Wholesaler>().GetSingleByFilterAsync(x => x.Id == deleteWholesalerVM.Id);
            if (wholesalerEntites is null)
            {
                throw new NotFoundException($"{deleteWholesalerVM.Id} numaralı tedarikci bulunamadı.");
            }


            _uwork.GetRepository<Wholesaler>().Delete(deleteWholesalerVM.Id);

            result.Data = await _uwork.CommitAsync();

            return result;
        }

    }
}
