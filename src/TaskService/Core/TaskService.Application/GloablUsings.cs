global using TaskService.Domain.Common;
global using BuildingBlocks.Models;
global using TaskService.Domain;
global using BuildingBlocks.Logger;
global using Microsoft.AspNetCore.Http;
global using System.Reflection;
global using Microsoft.Extensions.DependencyInjection;
global using System.Text.Json;
global using BuildingBlocks.Models.Exceptions;
global using ApplicationException = BuildingBlocks.Models.Exceptions.ApplicationException;
global using System.Text;
global using TaskService.Application.Middleware;
global using BuildingBlocks.Mapping;
global using Mapster;
global using BuildingBlocks.CQRS;
global using TaskService.Application.DTOs;
global using MediatR;
global using TaskService.Application.Contracts.Repositories;
global using TaskService.Application.Models;