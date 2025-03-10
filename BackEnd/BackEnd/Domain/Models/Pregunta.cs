﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Domain.Models
{
    public class Pregunta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName ="varchar(100)")]
        public string Descripcion { get; set; }

     
        public int CuestionarioId { get; set; }
        public Cuestionario? Cuestionario { get; set; }

      
        public List<Respuesta>? listRespuestas{ get; set; }
    }
}
