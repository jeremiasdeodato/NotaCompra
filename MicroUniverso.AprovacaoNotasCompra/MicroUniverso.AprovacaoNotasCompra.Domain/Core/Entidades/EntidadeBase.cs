using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroUniverso.AprovacaoNotasCompra.Domain.Core.Entidades
{
    public abstract class EntidadeBase
    {
        public Guid Id { get; protected set; }
        public bool Ativo { get; private set; }
        public DateTime DataCriacao { get; private set; }

        protected EntidadeBase()
        {
            CriarInstancia();
        }

        protected void CriarInstancia()
        {
            Id = Guid.NewGuid();
            Ativo = true;
            DataCriacao = DateTime.Now;
        }

        public virtual void Ativar()
        {
            Ativo = true;
        }

        public virtual void Desativar()
        {
            Ativo = false;
        }

        public abstract bool EhValido();
        public abstract string? MensagemValidacao();
    }
}
