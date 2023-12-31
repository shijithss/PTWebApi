﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace User.Microservice.Domain.Entities
{
    public class PostQuery : BaseEntity
    {
        [Key]
        public int postid { get; private set; }
        public string? title { get; private set; }
        public string? body { get; private set; }
        public int userId { get; private set; }

        public List<string?> tags { get; private set; }

        public bool hasFrenchTag { get; private set; }

        public bool hasFictionTag { get; private set; }

        public bool hasMorethanTwoReactions { get; private set; }
        public int reactions { get; private set; }

        public void CheckFrenchTag()
        {
            hasFrenchTag = tags.Any(x => x.Contains("french")) ? true : false;
        }
        public void CheckFictionTag()
        {
            hasFictionTag = tags.Any(x => x.Contains("fiction")) ? true : false;
        }

        public void CheckMorethanTwoReactions()
        {
            hasMorethanTwoReactions = reactions > 2 ? true: false;
        }
    }
}
