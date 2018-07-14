//  This file was generated by CSLA Object Generator - CslaGenFork v4.3.0
//
// Filename:    INoticeCollDal
// ObjectType:  DAL interface for NoticeColl
// CSLAType:    ReadOnlyCollection

using System;
using System.Collections.Generic;
using Csla;

namespace Noticer.Dto
{
    /// <summary>
    /// DAL Interface for NoticeColl type
    /// </summary>
    public partial interface INoticeCollDal
    {
        /// <summary>
        /// Loads a NoticeColl collection from the database.
        /// </summary>
        /// <returns>A list of <see cref="NoticeInfoDto"/>.</returns>
        List<NoticeDto> Fetch();
    }
}