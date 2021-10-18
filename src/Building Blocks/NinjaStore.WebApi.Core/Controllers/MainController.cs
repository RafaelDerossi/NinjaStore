using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace NinjaStore.WebApi.Core.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected ICollection<string> Erros = new List<string>();

        protected StringContent ObterConteudo(object dado)
        {
            return new StringContent(
                JsonConvert.SerializeObject(dado),
                Encoding.UTF8,
                "application/json");
        }

        protected async Task<T> DeserializarObjetoResponse<T>(HttpResponseMessage responseMessage)
        {
           return JsonConvert.DeserializeObject<T>(await responseMessage.Content.ReadAsStringAsync());
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = Erros.ToArray()
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                AdicionarErroProcessamento(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                AdicionarErroProcessamento(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(string mensagemDeErro)
        {
            AdicionarErroProcessamento(mensagemDeErro);
            return CustomResponse();
        }

        protected bool OperacaoValida()
        {
            return !Erros.Any();
        }

        protected void AdicionarErroProcessamento(string erro)
        {
            Erros.Add(erro);
        }

        protected void LimparErrosProcessamento()
        {
            Erros.Clear();
        }
    }
}