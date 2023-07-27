using AddressBook.Api.DbContext;
using AddressBook.Api.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        protected readonly AddressBookDbContext _context;
        protected readonly DbSet<Address> _set;

        public AddressController(AddressBookDbContext context)
        {
            _context = context;
            _set = _context.Set<Address>();
        }


        [HttpGet]
        [Route("list")]
        public async Task<List<Address>> Get()
        {
            return await _set.ToListAsync();
        }

        [HttpGet]
        [Route("getById")]
        public async Task<Address?> Get(int id)
        {
            var entity = await _set.SingleOrDefaultAsync(x => x.Id == id);
            return entity;
        }

        [HttpGet]
        [Route("getByName")]
        public async Task<List<Address>?> Get(string name)
        {
            var entity = await _set.Where(x => EF.Functions.Like(x.FullName, "%" + name + "%")).ToListAsync();
            return entity;
        }

        [HttpGet]
        [Route("getByAddress")]
        public async Task<List<Address>?> GetByAddress(string address)
        {
            var entity = await _set.Where(x => EF.Functions.Like(x.Province, "%" + address + "%") ||
                                                EF.Functions.Like(x.District, "%" + address + "%") ||
                                                EF.Functions.Like(x.Neighborhood, "%" + address + "%") ||
                                                EF.Functions.Like(x.Street, "%" + address + "%")).ToListAsync();
            return entity;
        }

        [HttpPost]
        public async Task<Address> Add(Address request)
        {
            request.CreatedAt = DateTime.Now;
            _set.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }

        [HttpPut]
        public async Task<Address> Update(Address request)
        {
            request.UpdatedAt = DateTime.Now;
            _set.Update(request);
            await _context.SaveChangesAsync();
            return request;

        }

        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            var entity = await Get(id);
            if (entity != null)
            {
                _set.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
