﻿namespace TransactionMobile.Views.MobileTopup
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Database;
    using Pages;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// Page to show the payment success.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    /// <seealso cref="TransactionMobile.Pages.IMobileTopupPaymentSuccessPage" />
    /// <seealso cref="TransactionMobile.Pages.IPage" />
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [ExcludeFromCodeCoverage]
    public partial class MobileTopupPaymentSuccessPage : ContentPage, IMobileTopupPaymentSuccessPage, IPage
    {
        private readonly ILoggingDatabaseContext LoggingDatabase;

        #region Fields


        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MobileTopupPaymentSuccessPage" /> class.
        /// </summary>
        /// <param name="loggingDatabase">The logging database.</param>
        public MobileTopupPaymentSuccessPage(ILoggingDatabaseContext loggingDatabase)
        {
            this.LoggingDatabase = loggingDatabase;
            this.LoggingDatabase.InsertLogMessage(LoggingDatabaseContext.CreateDebugLogMessage($"In {this.GetType().Name} ctor"));
            this.InitializeComponent();
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when [complete button clicked].
        /// </summary>
        public event EventHandler CompleteButtonClicked;

        #endregion

        #region Methods

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Init()
        {
            this.LoggingDatabase.InsertLogMessage(LoggingDatabaseContext.CreateDebugLogMessage($"In {this.GetType().Name} Init"));
            this.CompleteButton.Clicked += this.CompleteButton_Clicked;
        }

        /// <summary>
        /// Handles the Clicked event of the CompleteButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void CompleteButton_Clicked(Object sender,
                                            EventArgs e)
        {
            this.CompleteButtonClicked(sender, e);
        }

        #endregion
    }
}