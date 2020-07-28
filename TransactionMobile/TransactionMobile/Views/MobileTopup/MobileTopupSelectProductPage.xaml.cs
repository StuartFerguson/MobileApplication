﻿namespace TransactionMobile.Views.MobileTopup
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Events;
    using Models;
    using Pages;
    using Syncfusion.XForms.Buttons;
    using ViewModels;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    /// <seealso cref="TransactionMobile.Pages.IMobileTopupSelectProductPage" />
    /// <seealso cref="TransactionMobile.Pages.IPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [ExcludeFromCodeCoverage]
    public partial class MobileTopupSelectProductPage : ContentPage, IMobileTopupSelectProductPage, IPage
    {
        #region Fields

        /// <summary>
        /// The analysis logger
        /// </summary>
        private readonly IAnalysisLogger AnalysisLogger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MobileTopupSelectProductPage" /> class.
        /// </summary>
        /// <param name="analysisLogger">The analysis logger.</param>
        public MobileTopupSelectProductPage(IAnalysisLogger analysisLogger)
        {
            this.AnalysisLogger = analysisLogger;
            this.AnalysisLogger.TrackEvent(PageRequestedEvent.Create(this.GetType().Name));
            this.InitializeComponent();
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when [product selected].
        /// </summary>
        public event EventHandler<SelectedItemChangedEventArgs> ProductSelected;

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public void Init(MobileTopupSelectProductViewModel viewModel)
        {
            this.AnalysisLogger.TrackEvent(PageInitialisedEvent.Create(this.GetType().Name));
            this.LoadOperators(viewModel);
        }

        /// <summary>
        /// Executes the specified e.
        /// </summary>
        /// <param name="e">The <see cref="SelectedItemChangedEventArgs" /> instance containing the event data.</param>
        private void Execute(SelectedItemChangedEventArgs e)
        {
            this.ProductSelected(this, e);
        }

        /// <summary>
        /// Loads the operators.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        private void LoadOperators(MobileTopupSelectProductViewModel viewModel)
        {
            RowDefinitionCollection rowDefinitionCollection = new RowDefinitionCollection();
            for (Int32 i = 0; i < viewModel.Products.Count; i++)
            {
                rowDefinitionCollection.Add(new RowDefinition
                                            {
                                                Height = 80
                                            });
            }

            this.ProductsGrid.RowDefinitions = rowDefinitionCollection;

            Int32 rowCount = 0;
            foreach (ContractProductModel modelProduct in viewModel.Products)
            {
                SfButton button = new SfButton
                                  {
                                      Text = modelProduct.ProductDisplayText,
                                      HorizontalOptions = LayoutOptions.FillAndExpand,
                                      //HeightRequest = 100,
                                      //WidthRequest = 400,
                                      AutomationId = modelProduct.ProductDisplayText,
                                      Command = new Command<SelectedItemChangedEventArgs>(this.Execute),
                                      CommandParameter = new SelectedItemChangedEventArgs(modelProduct, rowCount)
                                  };
                button.SetDynamicResource(VisualElement.StyleProperty, "SfButtonStyleMobileTopup");

                this.ProductsGrid.Children.Add(button, 0, rowCount);
                rowCount++;
            }
        }

        #endregion
    }
}