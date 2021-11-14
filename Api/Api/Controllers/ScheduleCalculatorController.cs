using Api.Service.Interfaces.Services;
using Api.Service.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;

namespace Api.Controllers
{
    /// <summary>
    /// Controller for schedule calculater
    /// </summary>
    public class ScheduleCalculatorController : ControllerBase
    {
        private readonly IScheduleCalculatorService _service;

        /// <summary>
        /// Contructor of schedule calculater controller
        /// </summary>
        /// <param name="service"></param>
        public ScheduleCalculatorController(IScheduleCalculatorService service)
        {
            _service = service;
        }

        /// <summary>
        /// Method to calulate the schedule
        /// </summary>
        [HttpPost("api/schedulecalculator")]
        [AllowAnonymous]
        public ActionResult<QualityScheduleViewModel> ScheduleCalculator()
        {
            Tuple<string[], List<string[]>> rooms = null;
            Tuple<string[], List<string[]>> sessions = null;
            Tuple<string[], List<string[]>> properties = null;

            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var file = Request.Form.Files[i];
                var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Replace("\"", " ").Replace(":", "-").Trim();
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "Resources");
                var fullPath = Path.Combine(pathToSave, filename);

                if (file.Length > 0)
                {
                    if (System.IO.File.Exists(fullPath))
                        System.IO.File.Delete(fullPath);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                        file.CopyTo(stream);
                }

                string[] columns = System.IO.File.ReadAllLines(fullPath)[0].Split(";");
                List<string[]> lines = new List<string[]>();

                foreach (var line in System.IO.File.ReadAllLines(fullPath).Skip(1))
                    lines.Add(line.Split(";"));

                if (filename.Contains("rooms"))
                    rooms = Tuple.Create(columns, lines);

                else if (filename.Contains("sessions"))
                    sessions = Tuple.Create(columns, lines);

                else if (filename.Contains("properties"))
                    properties = Tuple.Create(columns, lines);
            }

            return _service.AllocateRoomsToSessions(properties, rooms, sessions);
        }
    }
}
