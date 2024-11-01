//----------System
//-----------FluentValidation
global using FluentValidation;
global using Inventory.Api.Extensions;
global using Inventory.Application;
global using Inventory.Application.Behaviors;
global using Inventory.Application.Command.CategoryCommand.AddCategoryCommand;
global using Inventory.Application.Command.CategoryCommand.DeleteCategoryCommand;
global using Inventory.Application.Command.CategoryCommand.EditCategoryCommand;
global using Inventory.Application.IRepository;
global using Inventory.Application.IRepository.ICustomRepositories;
//----------Inventory
global using Inventory.Domain.Shared;
global using Inventory.Infrastructure.Data;
global using Inventory.Infrastructure.Repository;
global using Inventory.Infrastructure.Repository.CustomRepositories;
//-----------MediatR
global using MediatR;
global using Microsoft.AspNetCore.Mvc;
//----------Microsoft
global using Microsoft.EntityFrameworkCore;
//-----------SharedProject
global using SharedProject.ActionFilters;
global using SharedProject.Middlewars;
global using System.Reflection;
