using System;
using System.Collections.Generic;
using System.Text;

namespace Meetup.GraphQLNet.Domain
{
    public class SerieActor
    {
        public int SerieId { get; set; }
        public Serie Serie { get; set; }

        public int ActorId { get; set; }
        public Actor Actor { get; set; }
        public int SortOrder { get; set; }

    }
}
