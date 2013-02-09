// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CultureInfoScope.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// <summary>
//   An object that can be used in a <c>using</c> statement to set the UI culture
//   to a particular value, then put it back after the <c>using</c> goes out of scope.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace FluentConversions.Tests
{
    using System;
    using System.Globalization;
    using System.Threading;

    /// <summary>
    ///     An object that can be used in a <c>using</c> statement to set the UI culture
    ///     to a particular value, then put it back after the <c>using</c> goes out of scope.
    /// </summary>
    public class CultureInfoScope : IDisposable
    {
        private Thread _originalThread;

        public CultureInfoScope(CultureInfo localCulture, CultureInfo localUICulture = null)
        {
            SetCultures(localCulture, localUICulture);
        }

        public CultureInfoScope(int localCultureId, int? localUICultureId = null)
        {
            SetCultures(CultureInfo.GetCultureInfo(localCultureId), 
                localUICultureId.HasValue ? CultureInfo.GetCultureInfo(localUICultureId.Value) : null);
        }

        public CultureInfoScope(string localCultureName, string localUICultureName = null)
        {
            SetCultures(CultureInfo.GetCultureInfo(localCultureName),
                string.IsNullOrWhiteSpace(localUICultureName) ? null : CultureInfo.GetCultureInfo(localUICultureName));
        }

        private void SetCultures(CultureInfo localCulture, CultureInfo localUICulture = null)
        {
            if (localCulture == null)
                throw new ArgumentNullException("localCulture");

            if (localUICulture == null)
                localUICulture = localCulture;

            _originalThread = Thread.CurrentThread;

            OriginalCulture = _originalThread.CurrentCulture;
            OriginalUICulture = _originalThread.CurrentUICulture;

            _originalThread.CurrentCulture = localCulture;
            _originalThread.CurrentUICulture = localUICulture;

            LocalCulture = localCulture;
            LocalUICulture = localUICulture;
        }

        ~CultureInfoScope()
        {
            Dispose(false);
        }

        /// <summary>
        ///     Gets the culture in effect when the <c>using</c> scope was entered.
        /// </summary>
        public CultureInfo OriginalCulture { get; private set; }

        /// <summary>
        ///     Gets the culture in effect when the <c>using</c> scope was entered.
        /// </summary>
        public CultureInfo OriginalUICulture { get; private set; }

        /// <summary>
        ///     Gets the culture being applied in the current <c>using</c> scope.
        /// </summary>
        public CultureInfo LocalCulture { get; private set; }

        /// <summary>
        ///     Gets the culture being applied in the current <c>using</c> scope.
        /// </summary>
        public CultureInfo LocalUICulture { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (_originalThread == null || !isDisposing)
                return;

            _originalThread.CurrentCulture = OriginalCulture;
            _originalThread.CurrentUICulture = OriginalUICulture;

            OriginalCulture = null;
            OriginalUICulture = null;
            _originalThread = null;
        }
    }
}
