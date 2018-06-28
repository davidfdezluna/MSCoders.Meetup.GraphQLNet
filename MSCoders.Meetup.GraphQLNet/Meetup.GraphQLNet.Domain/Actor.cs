using System;
using System.Collections.Generic;
using System.Text;

namespace Meetup.GraphQLNet.Domain
{
    public class Actor
    {
        public int Id { get; set; }
        public int TheTVDBId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<SerieActor> SerieActors { get; } = new List<SerieActor>();        
    }
}
