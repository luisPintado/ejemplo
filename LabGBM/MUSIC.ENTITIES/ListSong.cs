using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MUSIC.ENTITIES
{
   
    [DataContract]
    public class ListSong
    {
        [DataMember]
        public int Id { get; set; }
        
        [DataMember]
        public string Name { get; set; }
        
        [DataMember]
        public DateTime Create { get; set; }

    }
}
