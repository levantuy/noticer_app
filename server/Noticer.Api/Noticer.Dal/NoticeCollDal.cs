//  This file was generated by CSLA Object Generator - CslaGenFork v4.3.0
//
// Filename:    NoticeCollDal
// ObjectType:  SQL Server implementation of INoticeCollDal (NoticeColl)
// CSLAType:    ReadOnlyCollection

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using MySql.Data.MySqlClient;
using Noticer.Dto;

namespace Noticer.Dal
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="INoticeCollDal"/>
    /// </summary>
    public partial class NoticeCollDal : INoticeCollDal
    {
        /// <summary>
        /// Loads a NoticeColl collection from the database.
        /// </summary>
        /// <returns>A list of <see cref="NoticeDto"/>.</returns>
        public List<NoticeDto> Fetch()
        {
            using (var ctx = ConnectionManager<MySqlConnection>.GetManager("Connection"))
            {
                using (var cmd = new MySqlCommand("NoticeColl_Get", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<NoticeDto> LoadCollection(IDataReader data)
        {
            var noticeColl = new List<NoticeDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    noticeColl.Add(Fetch(dr));
                }
            }
            return noticeColl;
        }

        private NoticeDto Fetch(SafeDataReader dr)
        {
            var noticeInfo = new NoticeDto();
            // Value properties
            noticeInfo.NoticeId = dr.GetInt64("NoticeId");
            noticeInfo.Title = dr.GetString("Title");
            noticeInfo.Content = dr.GetString("Content");
            noticeInfo.Url = !dr.IsDBNull("Url") ? dr.GetString("Url") : null;
            noticeInfo.LastUser = dr.GetString("LastUser");
            noticeInfo.LastModefied = !dr.IsDBNull("LastModefied") ? dr.GetSmartDate("LastModefied", true) : null;

            return noticeInfo;
        }
    }
}
