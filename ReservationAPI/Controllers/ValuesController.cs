using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationAPI.Models;

namespace ReservationAPI.Controllers;

[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    private readonly ReservationDBContext _context;

    public ValuesController(ReservationDBContext context)
    {
        _context = context;
    }

    //[HttpGet]
    //public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
    //{
    //    var reservations = await _context.tb_reservations.ToListAsync();
    //    return Ok(reservations);
    //}

    //[Route("[GetReservationDataByFirstLastName]")]
    [HttpGet] //("{firstName=}/{lastName=}")
    public IEnumerable<ReservationData> Get(string? firstName, string? lastName)
    {
        //using (var dbEntities = new ReservationDBContext())
        //{ // && x.LastName == lastName
        if(firstName ==null && lastName==null)
        {
            var result = _context.tb_reservations.ToList<ReservationData>();
            return result;
        }
        else if (firstName != null && lastName != null)
        {
            var result = _context.tb_reservations.Where(x => x.firstName == firstName && x.lastName == lastName).ToList<ReservationData>();
            return result;
        }
        else if(firstName == null || lastName == null)
        {
            if (firstName == null)
            {
                var result = _context.tb_reservations.Where(x => x.lastName == lastName).ToList<ReservationData>();
                return result;
            }
            else if (lastName == null)
            {
                var result = _context.tb_reservations.Where(x => x.firstName == firstName ).ToList<ReservationData>();
                return result;
            }
        }

        return null;
        //}
    }



    //// GET api/values
    //[HttpGet]
    //public IEnumerable<string> Get()
    //{
    //    return new string[] { "value1", "value2" };
    //}

    // GET api/values/5

    //[HttpGet("{firstName}")]
    //public string Get(string firstName)
    //{
    //    return firstName;
    //}

    //[HttpGet("{id}")]
    //public string Get(int id)
    //{
    //    return "value";
    //}

    // POST api/values
    [HttpPost]
    public string Post([FromBody]ReservationData objReservation)
    {
        _context.tb_reservations.Add(objReservation);
        _context.SaveChanges();
        return  "{'result':'Data Saved Successfully'}";
    }

    // PUT api/values/5
    [HttpPost("{id}")]
    public void Post(int id, [FromBody] ReservationData objReservation)
    {
        var result = _context.tb_reservations.Where(x => x.Id == id).ToList().FirstOrDefault();
        //result.FirstName = objReservation.FirstName;
        //result.LastName = objReservation.LastName;  
        //result.Email = objReservation.Email;
        //result.Phone = objReservation.Phone;
        //result.City = objReservation.City;
        //result.ArrivalDate = objReservation.ArrivalDate;
        _context.SaveChanges();

    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}