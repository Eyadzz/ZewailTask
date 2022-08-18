﻿using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.GetInfo;

public class GetInfoHandler : IRequestHandler<GetInfoRequest, InfoDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetInfoHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<InfoDTO> Handle(GetInfoRequest request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.Information.GetInformationWithCategory(request.Id);
        return result;
        //TODO: FIX AUTO MAPPER
        //return _mapper.Map<InfoDTO>(result);
    }
}