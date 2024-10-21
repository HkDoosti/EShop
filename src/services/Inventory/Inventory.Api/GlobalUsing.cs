//----------System
global using System.Reflection;
//----------Microsoft
global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Mvc;
//----------Inventory
global using Inventory.Api;
global using Inventory.Domain.Shared;
global using Inventory.Application;
global using Inventory.Api.Extensions;
global using Inventory.Infrastructure.Data;
global using Inventory.Application.IRepository;
global using Inventory.Infrastructure.Repository;
global using Inventory.Application.IRepository.ICustomRepositories;
global using Inventory.Infrastructure.Repository.CustomRepositories;
global using Inventory.Application.Behaviors;
global using Inventory.Application.Command.CategoryCommand.AddCategoryCommand;
//-----------SharedProject
global using SharedProject.ActionFilters;
global using SharedProject.Middlewars;
//-----------MediatR
global using MediatR;
//-----------FluentValidation
global using FluentValidation;