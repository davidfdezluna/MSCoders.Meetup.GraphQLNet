using System;
using System.Collections.Generic;

namespace Meetup.GraphQLNet.Domain
{
    public class Serie
    {
        public int Id { get; set; }
        public int TheTVDBId { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public string ImageUrl { get; set; }

        public DateTime? FirstAired { get; set; }

        public ICollection<SerieActor> SerieActors { get; } = new List<SerieActor>();
    }
}
