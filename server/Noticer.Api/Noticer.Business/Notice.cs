//  This file was generated by CSLA Object Generator - CslaGenFork v4.3.0
//
// Filename:    Notice
// ObjectType:  Notice
// CSLAType:    EditableRoot

using System;
using Csla;
using Noticer.Dto;

namespace Noticer.Business
{

    /// <summary>
    /// Notice (editable root object).<br/>
    /// This is a generated base class of <see cref="Notice"/> business object.
    /// </summary>
    [Serializable]
    public partial class Notice : BusinessBase<Notice>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="NoticeId"/> property.
        /// </summary>
        private static readonly PropertyInfo<Int64> NoticeIdProperty = RegisterProperty<Int64>(p => p.NoticeId, "Notice Id");
        /// <summary>
        /// Gets the Notice Id.
        /// </summary>
        /// <value>The Notice Id.</value>
        public Int64 NoticeId
        {
            get { return GetProperty(NoticeIdProperty); }
            set { SetProperty(NoticeIdProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Title"/> property.
        /// </summary>
        private static readonly PropertyInfo<string> TitleProperty = RegisterProperty<string>(p => p.Title, "Title");
        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        /// <value>The Title.</value>
        public string Title
        {
            get { return GetProperty(TitleProperty); }
            set { SetProperty(TitleProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Content"/> property.
        /// </summary>
        private static readonly PropertyInfo<string> ContentProperty = RegisterProperty<string>(p => p.Content, "Content");
        /// <summary>
        /// Gets or sets the Content.
        /// </summary>
        /// <value>The Content.</value>
        public string Content
        {
            get { return GetProperty(ContentProperty); }
            set { SetProperty(ContentProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Url"/> property.
        /// </summary>
        private static readonly PropertyInfo<string> UrlProperty = RegisterProperty<string>(p => p.Url, "Url");
        /// <summary>
        /// Gets or sets the Url.
        /// </summary>
        /// <value>The Url.</value>
        public string Url
        {
            get { return GetProperty(UrlProperty); }
            set { SetProperty(UrlProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="LastUser"/> property.
        /// </summary>
        private static readonly PropertyInfo<string> LastUserProperty = RegisterProperty<string>(p => p.LastUser, "Last User");
        /// <summary>
        /// Gets or sets the Last User.
        /// </summary>
        /// <value>The Last User.</value>
        public string LastUser
        {
            get { return GetProperty(LastUserProperty); }
            set { SetProperty(LastUserProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="LastModefied"/> property.
        /// </summary>
        private static readonly PropertyInfo<SmartDate> LastModefiedProperty = RegisterProperty<SmartDate>(p => p.LastModefied, "Last Modefied");
        /// <summary>
        /// Gets or sets the Last Modefied.
        /// </summary>
        /// <value>The Last Modefied.</value>
        public string LastModefied
        {
            get { return GetPropertyConvert<SmartDate, String>(LastModefiedProperty); }
            set { SetPropertyConvert<SmartDate, String>(LastModefiedProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="Notice"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="Notice"/> object.</returns>
        public static Notice NewNotice()
        {
            return DataPortal.Create<Notice>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="Notice"/> object, based on given parameters.
        /// </summary>
        /// <param name="noticeId">The NoticeId parameter of the Notice to fetch.</param>
        /// <returns>A reference to the fetched <see cref="Notice"/> object.</returns>
        public static Notice GetNotice(Int64 noticeId)
        {
            return DataPortal.Fetch<Notice>(noticeId);
        }

        /// <summary>
        /// Factory method. Deletes a <see cref="Notice"/> object, based on given parameters.
        /// </summary>
        /// <param name="noticeId">The NoticeId of the Notice to delete.</param>
        public static void DeleteNotice(Int64 noticeId)
        {
            DataPortal.Delete<Notice>(noticeId);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Notice"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private Notice()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="Notice"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            LoadProperty(UrlProperty, null);
            LoadProperty(LastModefiedProperty, null);
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.DataPortal_Create();
        }

        /// <summary>
        /// Loads a <see cref="Notice"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="noticeId">The Notice Id.</param>
        protected void DataPortal_Fetch(Int64 noticeId)
        {
            var args = new DataPortalHookArgs(noticeId);
            OnFetchPre(args);
            using (var dalManager = DalFactoryGetManager.GetManager())
            {
                var dal = dalManager.GetProvider<INoticeDal>();
                var data = dal.Fetch(noticeId);
                Fetch(data);
            }
            OnFetchPost(args);
            // check all object rules and property rules
            BusinessRules.CheckRules();
        }

        /// <summary>
        /// Loads a <see cref="Notice"/> object from the given <see cref="NoticeDto"/>.
        /// </summary>
        /// <param name="data">The NoticeDto to use.</param>
        private void Fetch(NoticeDto data)
        {
            // Value properties
            LoadProperty(NoticeIdProperty, data.NoticeId);
            LoadProperty(TitleProperty, data.Title);
            LoadProperty(ContentProperty, data.Content);
            LoadProperty(UrlProperty, data.Url);
            LoadProperty(LastUserProperty, data.LastUser);
            LoadProperty(LastModefiedProperty, data.LastModefied);
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="Notice"/> object in the database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            var dto = new NoticeDto();
            dto.Title = Title;
            dto.Content = Content;
            dto.Url = Url;
            dto.LastUser = LastUser;
            dto.LastModefied = ReadProperty(LastModefiedProperty);
            using (var dalManager = DalFactoryGetManager.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnInsertPre(args);
                var dal = dalManager.GetProvider<INoticeDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Insert(dto);
                    LoadProperty(NoticeIdProperty, resultDto.NoticeId);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnInsertPost(args);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="Notice"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            var dto = new NoticeDto();
            dto.NoticeId = NoticeId;
            dto.Title = Title;
            dto.Content = Content;
            dto.Url = Url;
            dto.LastUser = LastUser;
            dto.LastModefied = ReadProperty(LastModefiedProperty);
            using (var dalManager = DalFactoryGetManager.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<INoticeDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Update(dto);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnUpdatePost(args);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="Notice"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(NoticeId);
        }

        /// <summary>
        /// Deletes the <see cref="Notice"/> object from database.
        /// </summary>
        /// <param name="noticeId">The delete criteria.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(Int64 noticeId)
        {
            using (var dalManager = DalFactoryGetManager.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnDeletePre(args);
                var dal = dalManager.GetProvider<INoticeDal>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(noticeId);
                }
                OnDeletePost(args);
            }
        }

        #endregion

        #region Pseudo Events

        /// <summary>
        /// Occurs after setting all defaults for object creation.
        /// </summary>
        partial void OnCreate(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Delete, after setting query parameters and before the delete operation.
        /// </summary>
        partial void OnDeletePre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Delete, after the delete operation, before Commit().
        /// </summary>
        partial void OnDeletePost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after setting query parameters and before the fetch operation.
        /// </summary>
        partial void OnFetchPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the fetch operation (object or collection is fully loaded and set up).
        /// </summary>
        partial void OnFetchPost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after setting query parameters and before the update operation.
        /// </summary>
        partial void OnUpdatePre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after the update operation, before setting back row identifiers (RowVersion) and Commit().
        /// </summary>
        partial void OnUpdatePost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after setting query parameters and before the insert operation.
        /// </summary>
        partial void OnInsertPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after the insert operation, before setting back row identifiers (ID and RowVersion) and Commit().
        /// </summary>
        partial void OnInsertPost(DataPortalHookArgs args);

        #endregion

    }
}
