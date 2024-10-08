﻿namespace NynaeveLib.ViewModel
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using System;

    /// <summary>
    /// Generic view model base class. It uses Community Toolkit MVVM to provide the MVVM pattern.
    /// </summary>
    public class ViewModelBase : ObservableRecipient, IViewModelBase
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ViewModelBase"/> class.
        /// </summary>
        public ViewModelBase()
        {
        }

        /// <summary>
        /// view close request event handler
        /// </summary>
        public event EventHandler ClosingRequest;

        /// <summary>
        /// Request that the view is closed.
        /// </summary>
        protected void OnClosingRequest()
        {
            if (this.ClosingRequest != null)
            {
                this.ClosingRequest(this, EventArgs.Empty);
            }
        }
    }
}