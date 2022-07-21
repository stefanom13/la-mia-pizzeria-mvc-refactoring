using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


    
    public class PizzaCategorie
    {

   
        public Pizza Pizza { set; get; }
        public List<Categoria>? Categorie { get; set; }



    
        public PizzaCategorie()
        {


        }
    }

