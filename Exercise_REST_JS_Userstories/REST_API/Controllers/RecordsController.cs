using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecordsController : ControllerBase
{
    private IRecordsRepository _recordsRepository;
    public RecordsController(IRecordsRepository recordsRepository)
    {
        _recordsRepository = recordsRepository;
    }
    // GET: api/<RecordsController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult<IEnumerable<Record>> Get()
    {
        IEnumerable<Record> records = _recordsRepository.GetRecords();
        if (!records.Any())
        {
            return NoContent();
        }
        return Ok(records);
    }

    // GET api/<RecordsController>/5
    //[HttpGet("{id}")]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //public ActionResult<Record> Get(int id)
    //{
    //    Record? record = _recordsRepository.GetRecord(id);
    //    if (record == null)
    //    {
    //        return NotFound();
    //    }
    //    return Ok(record);
    //}

    // POST api/<RecordsController>
    //[HttpPost]
    //[ProducesResponseType(StatusCodes.Status201Created)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //public ActionResult<Record> Post([FromBody] Record record)
    //{
    //    try
    //    {
    //        _recordsRepository.AddRecord(record);
    //        return CreatedAtAction(nameof(Get), new { id = record.Id }, record);
    //    }
    //    catch (ArgumentNullException ex)
    //    {
    //        return BadRequest(ex.Message + "FIX YOUR JSON!");
    //    }
    //}

    // PUT api/<RecordsController>/5
    //[HttpPut("{id}")]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //public ActionResult<Record> Put(int id, [FromBody] Record value)
    //{
    //    Record? record = _recordsRepository.GetRecord(id);
    //    if (record == null)
    //    {
    //        return NotFound();
    //    }
    //    try
    //    {
    //        _recordsRepository.UpdateRecord(record.Id, value);
    //        return Ok(record);
    //    }
    //    catch (ArgumentNullException ex)
    //    {
    //        return BadRequest(ex.Message + "FIX YOUR JSON!");
    //    }
    //}

    // DELETE api/<RecordsController>/5
    //[HttpDelete("{id}")]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //public ActionResult Delete(int id)
    //{
    //    Record? record = _recordsRepository.GetRecord(id);
    //    if (record == null)
    //    {
    //        return NotFound();
    //    }
    //    return Ok(_recordsRepository.DeleteRecord(id));
    //}
}
