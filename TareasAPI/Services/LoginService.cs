using TareasAPI.Data;
using TareasAPI.Data.TareaModels;
using TareasAPI.Data.DTOs;
using Microsoft.EntityFrameworkCore;

namespace TestTareasAPI.Services;

public class LoginService
{
    private readonly GtareasContext _context;

    public LoginService(GtareasContext context)
    {

        _context = context;
    }

    public async Task<Administrador?> GetAdmin(AdminDto admin)
    {
        return await _context.Administradors.
         SingleOrDefaultAsync(t => t.Correo == admin.Correo && t.Pwd == admin.Pwd);
    }


}
