using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/aluno")]
    public class AlunoController : ControllerBase
    {
        private static List<Aluno> ListaAlunos = new List<Aluno>();


        
    
        [HttpPost]
        [Route("CriarAluno")]
        public IActionResult CriarAluno(Aluno novoAluno)
        {
            ListaAlunos.Add(novoAluno);
            return Ok($"Aluno(a) criado com sucesso.");
        }

        [HttpDelete]
        [Route("remover")]
        public IActionResult Remover(string cpfbusca)
        {
            Aluno? resultadoBusca = ListaAlunos
                 .Where(Aluno => Aluno.cpf ==cpfbusca)
                 .firstordefault();

            if (resultadoBusca == null)
                return NotFound($"O cpf {cpfbusca} nao encontrado");

            ListaAlunos.Remove(resultadoBusca)
            return Ok("aluno removido com sucesso");
        }

        [HttpPut]
        [Route("atualizar/{cpfBusca}")]
        public IActionResult Atualizar(string cpfbusca, Aluno alunoAtualizado)
        {
            Aluno? resultadoBusca = ListaAlunos
                .Where(aluno => aluno.cpf == cpfbusca)
                .FirstOrDefault();
            if (resultadoBusca == null)
                return NotFound($"cpf {cpfbusca} nao encontrado");

            resultadoBusca.nome = alunoAtualizado.nome;
            resultadoBusca.idade = alunoAtualizado.idade;

            return Ok("aluno atualizado com sucesso");
        }

        

    
    }
}