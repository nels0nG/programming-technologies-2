using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StadiumManagement.Models
{
    public class GruposDetalhes
    {
        [Key]
        public int GruposDetalhesId { get; set; }

        public int GruposId { get; set; }

        public int UserId { get; set; }

        public virtual Grupos Grupos { get; set; }

        public virtual Usuario Trabalhador { get; set; }

        public string GrupoTrabalhador { get { return string.Format("{0} / {1}", Grupos.Descricao, Trabalhador.NomeCompleto); } }

        public virtual ICollection<Notas> Notas { get; set; }
    }
}