using MVCDapper.Models.BO;
using MVCDapper.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDapper.Models.BLL
{
    public class ReviewService
    {
        public readonly RatingRepository repos = new RatingRepository();
        public List<TopicReview> GetTopicReviews(int topicId, int bundleid = 0, int? pageIndex = null, int? pageLen = null, int userId = 0)
        {
            var reviews = repos.GetTopicReviews(topicId, bundleid, pageIndex, pageLen);
            return reviews;
        }
    }
}