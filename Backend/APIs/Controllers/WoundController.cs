using System.Net.Http.Headers;
using System.Text;
using Domain.Repository;
using Model;

namespace API;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("vmapi/Wounds")]
[ApiController]
public class WoundController : ControllerBase
{
    private WoundRepository _woundRepository = new WoundRepository(new VMContext());
    private MeasurementRepository _measurementRepository = new MeasurementRepository(new VMContext());

    [HttpPost]
    [Route("PostWoundPicture")]
    public void Post([FromBody] string Image)
    {
        byte[] picture = Convert.FromBase64String(Image);
        //Either send to Database, or directly to AI-model
    }

    [HttpPost]
    [Route("PostWound")]
    public void Post([FromBody] WoundData woundData)
    {
        _woundRepository.Add(woundData.Wound);
        _measurementRepository.Add(woundData.Measurement);
    }

    [HttpPost]
    [Route("PostMeasurements")]
    public void Post([FromBody] Measurement measurement)
    {
        string apiUrl = "URL of app";
        string json = Newtonsoft.Json.JsonConvert.SerializeObject(measurement);


        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            // For authorization:
            // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            client.PostAsync(apiUrl, content);
        }
    }
    
    //GetMeasurements
    [HttpGet]
    [Route("GetMeasurements")]
    public List<Measurement> Get([FromBody] string WoundId)
    {
        return _measurementRepository.GetByWoundId(WoundId);
    }

    //UpdateWound
    [HttpPut]
    [Route("UpdateWound")]
    public void Update(Wound wound)
    {
        _woundRepository.Update(wound);
    }
    
    //DeleteWound
    [HttpDelete]
    [Route("DeleteWound")]
    public void Delete(string id)
    {
        _woundRepository.Delete(id);
    }

    [HttpPut]
    [Route("UpdateMeasurement")]
    public void Update(Measurement m)
    {
        _measurementRepository.Update(m);
    }

    [HttpDelete]
    [Route("DeleteMeasurementById/{id}")]
    public void Delete(int id)
    {
        _measurementRepository.Delete(id);
    }
    
    [HttpDelete]
    [Route("DeleteMeasurementByWoundId")]
    public void DeleteMeasurement(string WoundId)
    {
        _measurementRepository.DeleteByWound(WoundId);
    }
}

public class WoundData
{
    public Wound Wound { get; set; }
    public Measurement Measurement { get; set; }
}