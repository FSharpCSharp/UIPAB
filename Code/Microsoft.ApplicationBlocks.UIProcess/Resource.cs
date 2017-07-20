//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// Resource.cs
//
// This file contains the implementations of the Resource class
//
// For more information see the User Interface Process Application Block Implementation Overview. 
// 
//===============================================================================
// Copyright (C) 2000-2001 Microsoft Corporation
// All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
// FITNESS FOR A PARTICULAR PURPOSE.
//==============================================================================

using System;
using System.Resources;
using System.Reflection; 
using System.IO;

namespace Microsoft.ApplicationBlocks.UIProcess
{
    /// <summary>
    /// Helper class used to manage application resources.
    /// </summary>
    internal sealed class Resource
    {
			/// <summary>
			/// Class used to expose constants that represent keys in the resource file.
			/// </summary>
			internal abstract class Exceptions
			{
				internal const string RES_ExceptionCantCreateStatePersistenceProvider = "RES_ExceptionCantCreateStatePersistenceProvider";
				internal const string RES_ExceptionCantCreateState = "RES_ExceptionCantCreateState";
				internal const string RES_ExceptionUIPConfigNotFound = "RES_ExceptionUIPConfigNotFound";
				internal const string RES_ExceptionIViewManagerNotFound = "RES_ExceptionIViewManagerNotFound";
				internal const string RES_ExceptionControllerNotFound = "RES_ExceptionControllerNotFound";
				internal const string RES_ExceptionLoadUIPConfig = "RES_ExceptionLoadUIPConfig";
				internal const string RES_ExceptionSQLStatePersistenceProviderInit = "RES_ExceptionSQLStatePersistenceProviderInit";
				internal const string RES_ExceptionSQLStatePersistenceProviderDehydrate = "RES_ExceptionSQLStatePersistenceProviderDehydrate";
				internal const string RES_ExceptionSQLStatePersistenceProviderRehydrate = "RES_ExceptionSQLStatePersistenceProviderRehydrate";
				internal const string RES_ExceptionStartViewConfigNotFound = "RES_ExceptionStartViewConfigNotFound";
				internal const string RES_ExceptionViewConfigNotFound = "RES_ExceptionViewConfigNotFound";
				internal const string RES_ExceptionStatePersistenceProviderConfigNotFound = "RES_ExceptionStatePersistenceProviderConfigNotFound";
				internal const string RES_ExceptionCouldNotGetNextViewType = "RES_ExceptionCouldNotGetNextViewType";
				internal const string RES_ExceptionInvalidXmlAttributeValue = "RES_ExceptionInvalidXmlAttributeValue";
				internal const string RES_ExceptionInvalidCacheExpirationInterval = "RES_ExceptionInvalidCacheExpirationInterval";
				internal const string RES_ExceptionSecureSqlProviderRegistryPermissions = "RES_ExceptionSecureSqlProviderRegistryPermissions";
				internal const string RES_ExceptionSecureSqlProviderSymmetricKey = "RES_ExceptionSecureSqlProviderSymmetricKey";
				internal const string RES_ExceptionSecureSqlProviderCantEncrypt = "RES_ExceptionSecureSqlProviderCantEncrypt";
				internal const string RES_ExceptionSecureSqlProviderCantDecrypt = "RES_ExceptionSecureSqlProviderCantDecrypt";
				internal const string RES_ExceptionCantInitializeController = "RES_ExceptionCantInitializeController";
				internal const string RES_ExceptionCantSetViewProperty = "RES_ExceptionCantSetViewProperty";
				internal const string RES_ExceptionCantActivateView = "RES_ExceptionCantActivateView";
				internal const string RES_ExceptionCantGetSessionMoniker = "RES_ExceptionCantGetSessionMoniker";
				internal const string RES_ExceptionCantCreateIViewManager = "RES_ExceptionCantCreateIViewManager";
				internal const string RES_ExceptionCantLoadAssembly = "RES_ExceptionCantLoadAssembly";
				internal const string RES_ExceptionInvalidCastInCopyToArray ="RES_ExceptionInvalidCastInCopyToArray";
				internal const string RES_ExceptionIncorrectNumberOfItemsInTaskMonikerString = "RES_ExceptionIncorrectNumberOfItemsInTaskMonikerString";
				internal const string RES_ExceptionNullArrayInCopyToArray = "RES_ExceptionNullArrayInCopyToArray";
				internal const string RES_ExceptionInvalidArrayDimensionsInCopyToArray = "RES_ExceptionInvalidArrayDimensionsInCopyToArray";
				internal const string RES_ExceptionOutOfBoundsIndexInCopyToArray = "RES_ExceptionOutOfBoundsIndexInCopyToArray";
				internal const string RES_ExceptionTaskNotFound = "RES_ExceptionTaskNotFound";
				internal const string RES_ExceptionBadTypeArgumentInFactory = "RES_ExceptionBadTypeArgumentInFactory";
				internal const string RES_ExceptionDocumentNotValidated = "RES_ExceptionDocumentNotValidated";
				internal const string RES_ExceptionInvalidAbsoluteInterval = "RES_ExceptionInvalidAbsoluteInterval";
				internal const string RES_ExceptionNavigationGraphNotFound = "RES_ExceptionNavigationGraphNotFound";
				internal const string RES_ExceptionHostedControlsNotFound = "RES_ExceptionHostedControlsNotFound";
				internal const string RES_ExceptionStateConfigNotFound = "RES_ExceptionStateConfigNotFound";
				internal const string RES_ExceptionViewSettingAlreadyConfigured = "RES_ExceptionViewSettingAlreadyConfigured";			
				internal const string RES_ExceptionCantCreateInstanceUsingActivate = "RES_ExceptionCantCreateInstanceUsingActivate";
				internal const string RES_ExceptionStateNotInitialized = "RES_ExceptionStateNotInitialized";
				internal const string RES_ExceptionDuplicateNavigateGraphSharedTransition = "RES_ExceptionDuplicateNavigateGraphSharedTransition";
				internal const string RES_ExceptionDuplicateGlobalSharedTransition = "RES_ExceptionDuplicateGlobalSharedTransition";
				internal const string RES_ExceptionLayoutManagerNotFound = "RES_ExceptionLayoutManagerNotFound";
				internal const string RES_ExceptionConflictingFloatingWindowsAttribute = "RES_ExceptionConflictingFloatingWindowsAttribute";																																																																																				
				internal const string RES_ExceptionCantGetTypeFromAssembly = "RES_ExceptionCantGetTypeFromAssembly";
				internal const string RES_ExceptionWizardViewManagerIsRequired="RES_ExceptionWizardViewManagerIsRequired";
				internal const string RES_ExceptionFirstExceptionMessage = "RES_ExceptionFirstExceptionMessage";
				internal const string RES_ExceptionInvalidWizardName = "RES_ExceptionInvalidWizardName";
			}

        #region Static part
        private const string ResourceFileName = ".UIPText";

        private static Resource _internalResource = new Resource();
        /// <summary>
        /// Gets a resource manager for the assembly resource file.
        /// </summary>
        public static Resource ResourceManager
        {
            get
            {
                return _internalResource;
            }
        }
        #endregion
		
        #region Instance part 
        private ResourceManager _rm = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Resource()
        {
            _rm = new ResourceManager(this.GetType().Namespace + ResourceFileName, Assembly.GetExecutingAssembly());						
        }

        /// <summary>
        /// Gets the message with the specified key from the assembly resource file.
        /// </summary>
        /// <param name="key">Key of the item to retrieve from the resource file.</param>
        /// <returns>Value from the resource file identified by the key.</returns>
        public string this [ string key ]
        {
            get
            {
                return _rm.GetString( key, System.Globalization.CultureInfo.CurrentUICulture );																
            }
        }

        /// <summary>
        /// Gets a resource stream with the messages used by the UIP classes.
        /// </summary>
        /// <param name="name">The resource key.</param>
        /// <returns>A resource stream.</returns>
        public Stream GetStream( string name )
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceStream(this.GetType().Namespace + "." + name); 
        }

        /// <summary>
        /// Formats a message stored in the UIP assembly resource file.
        /// </summary>
        /// <param name="key">The resource key.</param>
        /// <param name="format">The format arguments.</param>
        /// <returns>A formatted string.</returns>
        public string FormatMessage( string key, params object[] format )
        {
            return String.Format( System.Globalization.CultureInfo.CurrentCulture, this[key], format );  
        }
        #endregion
    }
}
