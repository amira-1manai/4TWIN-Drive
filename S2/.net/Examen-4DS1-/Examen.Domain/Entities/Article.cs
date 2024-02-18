using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Examen.Domain.Entities
{
    public class Article
    {
        [Key]
        public int ArticleCode { get; set; }
        public string Couleur { get; set; }
        public string Matiere { get; set; }
        public int NbAccessoires { get; set; }

        [DataType(DataType.Currency)]
        public float PrixUnitaireFabrication { get; set; }

        [DataType(DataType.Currency)]
        public float PrixUnitaireVente { get; set; }
    }
}
