﻿global using AutoMapper;

global using api.Data;
global using api.Models;
global using api.Repositories;
global using api.Constants;
global using api.Exceptions;
global using api.Endpoints;
global using api.ServiceRegistration;
global using api.Services;
global using api.Models.AbstractModel;
global using api.Helpers;
global using api.Helpers.AbstractConverter;
global using api.Services.UnitOfWork;
global using api.Validators.ValidationConfiguration;
global using api.Filters;
global using api.Endpoints.APIResponse;
global using api.Extensions;

global using System.Text;
global using System.Text.Json;
global using System.Security.Claims;
global using Microsoft.IdentityModel.Tokens;

global using api.Dtos.Stock.Request;
global using api.Dtos.Stock.Response;
global using api.Dtos.AbstractDto;
global using api.Dtos.Comment.Request;
global using api.Dtos.Comment.Response;
global using api.Dtos.Account;

global using api.Interfaces.Services;
global using api.Interfaces.Repositories;
global using api.Interfaces.UnitOfWork;


global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Http.HttpResults;

global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Infrastructure;
global using Microsoft.EntityFrameworkCore.Migrations;

global using System.Reflection;
global using System.ComponentModel.DataAnnotations.Schema;

global using FluentValidation;


//:: is namespace alias operator
/* Example usage:
  using forwinforms = System.Drawing;
  using forwpf = System.Windows;

  public class Converters
   {
    public static forwpf::Point Convert(forwinforms::Point point) => new forwpf::Point(point.X, point.Y);
   }
*/



