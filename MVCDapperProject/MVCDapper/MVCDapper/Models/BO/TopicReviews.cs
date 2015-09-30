using Dapper.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDapper.Models.BO
{
    [Table("TopicReviews")]
    public class TopicReview
    {
        public Int32 Id { get; set; }
        public int TopicId { get; set; }
        public long UserId { get; set; }
        public decimal Ratings { get; set; }
        public string Reviews { get; set; }
        public DateTime? EditedOn { get; set; }
        public DateTime PostedOn { get; set; }

        [Write(false)]
        public string PostDate { get; set; }

        [Write(false)]
        public double TopicRating { get; set; }

        [Write(false)]
        public int TotalRecords { get; set; }
    }
}