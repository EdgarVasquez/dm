
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using prueba.Models;
using prueba.DTO;
namespace prueba.Services;
public interface IHabitosServices
{
    Task<Response<VwHabito>> Get(int Id);

    Task<Response<Spresult>> Set(Habitos param);
}

public class HabitosServices : IHabitosServices
{
    private readonly pruebaContext _dbContext;

    public HabitosServices(pruebaContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Response<VwHabito>> Get(int id)
    {
        var Result = new Response<VwHabito>();
        try
        {
            var data = await _dbContext.VwHabitos.FromSqlRaw("dbo.Get_Habitos {0}", id).ToListAsync();

            if (data.Any())
                Result.DataList = data;
            else
            {
                Result.Errors.Add("No se encontró ninguna Registro.");
                return Result;
            }
        }
        catch (Exception ex)
        {
            var res = _dbContext.ErrorsLogs.FromSqlRaw("dbo.SP_SET_ERRORS_LOG {0},{1},{2},{3},{4},{5}",
                                                        MethodBase.GetCurrentMethod().ReflectedType.FullName,
                                                        ex.Message, ex.StackTrace, ex.InnerException, "Admin",
                                                        ex.GetType().Name).ToList();
            Result.Errors.Add(res.SingleOrDefault().ExceptionMessage);
        }

        return Result;
    }

    public async Task<Response<Spresult>> Set(Habitos habitos)
   {
        var Result = new Response<Spresult>();
        try
        {
        var data = await _dbContext.Spresults.FromSqlRaw("dbo.Set_Habitos {0},{1},{2},{3},{4},{5}", habitos.Id,habitos.Estatus,habitos.Id_Usuario_crea,habitos.Id_Usuario_Modifica,habitos.Descripcion,habitos.Precio).ToListAsync();

            if (data.Any())
                Result.SingleData = data.FirstOrDefault();
            else
            {
                Result.Errors.Add("Error insertando param En Linea.");
                return Result;
            }
        }
        catch (Exception ex)
        {
            var res = _dbContext.ErrorsLogs.FromSqlRaw("dbo.SP_SET_ERRORS_LOG {0},{1},{2},{3},{4},{5}",
                                                        MethodBase.GetCurrentMethod().ReflectedType.FullName,
                                                        ex.Message, ex.StackTrace, ex.InnerException, "Admin",
                                                        ex.GetType().Name).ToList();
            Result.Errors.Add(res.SingleOrDefault().ExceptionMessage);
        }

        return Result;
    }
}