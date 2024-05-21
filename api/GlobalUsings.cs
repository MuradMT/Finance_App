global using AutoMapper;

global using api.Data;
global using api.Models;
global using api.Repositories;
global using api.Constants;
global using api.Exceptions;
global using api.Endpoints;
global using api.ServiceRegistration;

global using api.Dtos.Stock.Request;
global using api.Dtos.Stock.Response;

global using api.Interfaces.Services;
global using api.Interfaces.Repositories;

global using Microsoft.AspNetCore.Http.HttpResults;
global using Microsoft.AspNetCore.Mvc;

global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Infrastructure;
global using Microsoft.EntityFrameworkCore.Migrations;

global using System.Reflection;
global using System.ComponentModel.DataAnnotations.Schema;

//:: is namespace alias operator
/* Example usage:
  using forwinforms = System.Drawing;
  using forwpf = System.Windows;

  public class Converters
   {
    public static forwpf::Point Convert(forwinforms::Point point) => new forwpf::Point(point.X, point.Y);
   }
*/



