using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MUSIC.ENTITIES
{
    public class Cat
    {
        public TypesSeach Type { get; set; }
    }

    public enum TypesSeach
    {
        Titulo = 1,
        Autor = 2,
        Album = 3,
        Todos = 4
    }

}
