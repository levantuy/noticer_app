//-----------------------------------------------------------------------
// <copyright file="DalFactoryGetManager.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Configuration;
using System.Reflection;

namespace Noticer.Dto
{
    /// <summary>
    /// Creates a GetManager DAL manager provider.
    /// </summary>
    /// <remarks>
    /// To use the generated DAL:<br/>
    /// 1) name this assembly Noticer.Dto<br/>
    /// 2) add the following line to the <strong>appSettings</strong>
    /// section of the application .config file: <br/>
    /// &lt;add key="GetManager.DalManagerType" value="Noticer.Dto.DataAccess.DalManagerGetManager, Noticer.Dto.DataAccess" /&gt;
    /// </remarks>
    public static class DalFactoryGetManager
    {
        private static Type _dalType;

        /// <summary>Gets the GetManager DAL manager type that must be set
        /// in the <strong>appSettings</strong> section of the application .config file.</summary>
        /// <returns>A new <see cref="IDalManagerGetManager"/> instance</returns>
        public static IDalManagerGetManager GetManager()
        {
            if (_dalType == null)
            {
                var dalTypeName = ConfigurationManager.AppSettings["GetManager.DalManagerType"];
                if (!string.IsNullOrEmpty(dalTypeName))
                    _dalType = Type.GetType(dalTypeName);
                else
                    throw new NullReferenceException("GetManager.DalManagerType");
                if (_dalType == null)
                    throw new ArgumentException(string.Format("Type {0} could not be found", dalTypeName));
            }
            return (IDalManagerGetManager) Activator.CreateInstance(_dalType);
        }
    }
}
