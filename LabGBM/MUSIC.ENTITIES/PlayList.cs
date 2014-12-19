using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MUSIC.ENTITIES
{
     [DataContract]
    public class PlayList
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public ENTITIES.Song Song { get; set; }

        [DataMember]
        public ENTITIES.ListSong List { get; set; }

        [DataMember] 
        public DateTime DateCreation { get; set; }
    }
}
