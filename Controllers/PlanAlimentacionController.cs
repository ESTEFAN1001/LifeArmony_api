using LifeArmony_api.Models;
using LifeArmony_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace LifeArmony_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanAlimentacionController : ControllerBase
    {
        S_PlanAlimentacion _service;
        public PlanAlimentacionController(S_PlanAlimentacion service)
        {
            _service = service;
        }
        [HttpPost]
        [Route("InsertPlanAlimentacion")]
        public async Task<IActionResult> InsertPlanAlimentacion([FromQuery] PlanAlimentacion newPlan)// error no puede resivir un objecto
        {
            int response = 0;
            response = await _service.InsertOne(newPlan);

            //response = await _service.InsertOne(value);
            if (response == 1)
                return StatusCode(StatusCodes.Status200OK, $"Success! {response}");
            return StatusCode(StatusCodes.Status402PaymentRequired, $"Error! {response}");
        }

        [HttpGet]
        [Route("SelectManyPlanAlimentacion")]
        public async Task<IActionResult> SelectManyPlanAlimentacion()
        {
            List<PlanAlimentacion>? response = null;
            response = await _service.SelectMany();

            if (response != null)
                return StatusCode(StatusCodes.Status200OK, response);
            return StatusCode(StatusCodes.Status402PaymentRequired, $"Error! {response}");
        }

        [HttpGet]
        [Route("SelectOnePlanAlimentacion/{id}")]
        public async Task<IActionResult> SelectOnePlanAlimentacion(string id)
        {
            PlanAlimentacion? response = null;
            response = await _service.SelectOne(id);

            if (response != null)
                return StatusCode(StatusCodes.Status200OK, response);
            return StatusCode(StatusCodes.Status402PaymentRequired, $"Error! {response}");
        }
        [HttpPut]
        [Route("UpdateOnePlanAlimentacion/{id}")]
        public async Task<IActionResult> UpdateOnePlanAlimentacion(string _id, [FromQuery] PlanAlimentacion upPlan)
        {
            int response = 0;
            response = await _service.UpdateOne(_id, upPlan);

            if (response == 1)
                return StatusCode(StatusCodes.Status200OK, $"Success! {response}");
            return StatusCode(StatusCodes.Status402PaymentRequired, $"Error! {response}");
        }

        [HttpDelete]
        [Route("DeleteOnePlanAlimentacion/{id}")]
        public async Task<IActionResult> DeleteOnePlanAlimentacion(string id)
        {
            int response = 0;
            response = await _service.DeleteOne(id);

            if (response == 1)
                return StatusCode(StatusCodes.Status200OK, $"Success! {response}");
            return StatusCode(StatusCodes.Status402PaymentRequired, $"Error! {response}");
        }

        [HttpGet]
        [Route("SelectDieta")]
        public async Task<IActionResult> SelectDieta([FromQuery] List<string> restricciones, double peso, double talla, int edad, string tipo_diabetes)
        {
            List<PlanAlimentacion>? response = await _service.SelectMany();

            if (response != null)
            {
                var dietaFiltrada = response.Where(plan =>
                    plan.alimentos.All(dieta => dieta.alimentos.All(alimento => !restricciones.Contains(alimento.ToUpper()))) &&
                    peso >= plan.peso_min && peso <= plan.peso_max &&
                    talla >= plan.talla_min && talla <= plan.talla_max &&
                    edad >= plan.edad_min && edad <= plan.edad_max &&
                    tipo_diabetes.Equals(plan.tipo_diabetes, StringComparison.OrdinalIgnoreCase)
                ).ToList();

                return Ok(dietaFiltrada.ToList());
            }

            return NotFound($"Error! No se pudo encontrar una dieta adecuada.");
        }
    }
}
