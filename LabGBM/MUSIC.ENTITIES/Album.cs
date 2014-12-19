using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MUSIC.ENTITIES
{
    [DataContract]
    public class Album
    {
        [DataMember]
        public int IdAlbum { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]       
        public int Year { get; set; }

        [DataMember]
        public ENTITIES.GenreMusic Genre { get; set; }
    }
}
