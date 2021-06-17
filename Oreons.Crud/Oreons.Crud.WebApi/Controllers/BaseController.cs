using Infra.Transiction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebApi.Controllers
{
    public class BaseController : Controller
    {
        private readonly IUow _uow;

        public BaseController(IUow uow)
        {
            _uow = uow;
        }

        public IActionResult ApiResponse(object result)
        {
            var success = false;
            try
            {
                _uow.Commit();
                success = true;
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }
            catch (DbUpdateException dbException)
            {
                _uow.Rollback();
                return BadRequest(new
                {
                    success = false,
                    errors = new[] { dbException.Message }
                });
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                return BadRequest(new
                {
                    success = false,
                    errors = new[] { ex.Message }
                });
            }
            finally
            {
                if (!success)
                {
                    // write some logs
                }
            }
        }
    }
}
