//  This file was generated by CSLA Object Generator - CslaGenFork v4.3.0
//
// Filename:    NoticeDto
// ObjectType:  DTO for Notice
// CSLAType:    EditableRoot

using System;
using Csla;

namespace Noticer.Dto
{
    /// <summary>
    /// DTO for Notice type
    /// </summary>
    public partial class NoticeDto
    {
        /// <summary>
        /// Gets or sets the Notice Id.
        /// </summary>
        /// <value>The Notice Id.</value>
        public Int64 NoticeId { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        /// <value>The Title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Content.
        /// </summary>
        /// <value>The Content.</value>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the Url.
        /// </summary>
        /// <value>The Url.</value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the Last User.
        /// </summary>
        /// <value>The Last User.</value>
        public int LastUser { get; set; }

        /// <summary>
        /// Gets or sets the Last Modefied.
        /// </summary>
        /// <value>The Last Modefied.</value>
        public SmartDate LastModefied { get; set; }
    }
}