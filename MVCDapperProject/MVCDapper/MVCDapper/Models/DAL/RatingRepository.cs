using Dapper;
using MVCDapper.Models.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCDapper.Models.DAL
{
    public class RatingRepository
    {
        public List<TopicReview> GetTopicReviews(int topicId, int bundleId, int? pageIndex, int? pageLen)
        {
            var reviews = new List<TopicReview>();
            var reviewData = new TopicReview();
            string sql = string.Empty;

            sql = @";
declare @topicids varchar(2000)='';
SELECT @topicids=SUBSTRING((SELECT ','+CAST(TopicId AS VARCHAR(10)) FROM askiiti_askiitians.BundleTopic WHERE BundleId=@bundleid FOR XML PATH('')),2,2000);
IF @topicids IS NULL SET @topicids = @topicId;

WITH 
            AllReviews AS(SELECT rnum=ROW_NUMBER()OVER(PARTITION BY UserId ORDER BY EditedOn desc,PostedOn desc),TopicId , UserId,
				            PostedOn,Ratings,Reviews
				            FROM askiiti_askiitians.TopicReviews tr INNER JOIN dbo.Split(@topicids) s ON tr.TopicId =s.Item AND Reviews IS NOT NULL) 
                ,DistinctReviews AS (SELECT * FROM AllReviews WHERE rnum=1),
            ReviewData AS (SELECT rn=ROW_NUMBER()OVER(ORDER BY PostedOn desc), dr.*,Um.Name,TopicName=t.Name,
				            TopicImagePath=T.ImagePath, 
				            (SELECT Imagepath FROM userdetail WHERE userid=um.id)ImagePath 
				            FROM DistinctReviews DR INNER JOIN dbo.UserMaster um ON um.id = dr.userid INNER JOIN askiiti_askiitians.Topic T ON dr.TopicId = T.Id ),
			totalRecs AS (SELECT COUNT(1)Totcount FROM ReviewData)

            SELECT rn, TopicId AS Id,CONVERT(VARCHAR(12),PostedOn,113) PostDate,PostedOn,
            askiiti_askiitians.udf_GetUserTopicRating(TopicId,0)TopicRating,
            /*askiiti_askiitians.udf_GetUserTopicRating(TopicId,UserId)*/Ratings,
            Reviews,TopicImagePath,TopicName
			,(SELECT totcount FROM totalRecs) TotalRecords
            ,Userid AS Id,Name,ImagePath  
            FROM ReviewData 
            WHERE rn > (@PageIndex * @PageLen) AND rn<=((@PageIndex + 1)* @PageLen)  
            ORDER BY Ratings DESC,PostedOn DESC ";

            using (var connection = DBManager.GetOpenConnection())
            {
                reviews = connection.Query<TopicReview>(sql, new { bundleid = bundleId, topicid = topicId, PageIndex = pageIndex, PageLen = pageLen }).ToList();
            }

            return reviews;
        }
    }
}
