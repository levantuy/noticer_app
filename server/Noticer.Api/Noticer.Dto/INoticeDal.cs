//  This file was generated by CSLA Object Generator - CslaGenFork v4.3.0
//
// Filename:    INoticeDal
// ObjectType:  DAL interface for Notice
// CSLAType:    EditableRoot

using System;
using System.Collections.Generic;
using Csla;

namespace Noticer.Dto
{
    /// <summary>
    /// DAL Interface for Notice type
    /// </summary>
    public partial interface INoticeDal
    {
        /// <summary>
        /// Loads a Notice object from the database.
        /// </summary>
        /// <param name="noticeId">The fetch criteria.</param>
        /// <returns>A <see cref="NoticeDto"/> object.</returns>
        NoticeDto Fetch(Int64 noticeId);

        /// <summary>
        /// Inserts a new Notice object in the database.
        /// </summary>
        /// <param name="notice">The Notice DTO.</param>
        /// <returns>The new <see cref="NoticeDto"/>.</returns>
        NoticeDto Insert(NoticeDto notice);

        /// <summary>
        /// Updates in the database all changes made to the Notice object.
        /// </summary>
        /// <param name="notice">The Notice DTO.</param>
        /// <returns>The updated <see cref="NoticeDto"/>.</returns>
        NoticeDto Update(NoticeDto notice);

        /// <summary>
        /// Deletes the Notice object from database.
        /// </summary>
        /// <param name="noticeId">The delete criteria.</param>
        void Delete(Int64 noticeId);
    }
}
