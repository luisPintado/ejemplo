using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MUSIC.ENTITIES
{
    [DataContract]
    public class Song
    {
        [DataMember]
        public int IdSong { get; set; }
        
        [DataMember]
        public string  Source { get; set; }

        [DataMember]
        public string Duration { get; set; }

        [DataMember]
        public string Autor { get; set; }

        [DataMember]
        public ENTITIES.Album Album  { get; set; }

    }
}
