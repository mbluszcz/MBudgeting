using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MBudgeting.Core.Standard.Interfaces;
using MBudgeting.Core.Standard.Models;

namespace MBudgeting.WPF.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ExpenseCategoriesViewModel : ViewModelBase
    {
        #region Private members
        private readonly IExpenseModule _expenseModule;
        #endregion


        #region Commands
        public RelayCommand AddCommand
        {
            get;
            private set;
        }

        public RelayCommand DeleteCommand
        {
            get;
            private set;
        }

        public RelayCommand<DataGridCellEditEndingEventArgs> UpdateCommand
        {
            get;
            private set;
        }
        #endregion

        #region Properties
        private ObservableCollection<BoExpenseCategory> _testCollection;
        public ObservableCollection<BoExpenseCategory> ExpenseCategoriesCollection
        {
            get
            {
                return _testCollection;
            }
            set
            {
                if (_testCollection != value)
                {
                    _testCollection = value;
                    // RaisePropertyChanged(nameof(TestCollection))
                    RaisePropertyChanged(() => ExpenseCategoriesCollection);
                }
            }
        }

        public BoExpenseCategory SelectedExpenseCategory
        {
            get; set;
        }

        #endregion


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public ExpenseCategoriesViewModel(IExpenseModule expenseModule)
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            ///
            _expenseModule = expenseModule;
            AddCommand = new RelayCommand(() => AddNewExpenseCategory());
            ExpenseCategoriesCollection = new ObservableCollection<BoExpenseCategory>(_expenseModule.GetAll());
            DeleteCommand = new RelayCommand(() => DeleteSelectedExpenseCategory());
            UpdateCommand = new RelayCommand<DataGridCellEditEndingEventArgs>((x) => UpdateSelectedExpenseCategory(x));
        }

        private void UpdateSelectedExpenseCategory(DataGridCellEditEndingEventArgs boExpenseCategory)
        {
          
          var xx=  boExpenseCategory.Row.Item;
            ;
        }

        private void DeleteSelectedExpenseCategory()
        {
            if (SelectedExpenseCategory != null)
            {
                _expenseModule.Delete(SelectedExpenseCategory);
                ExpenseCategoriesCollection.Remove(SelectedExpenseCategory);
                SelectedExpenseCategory = null;
            }
        }

        private void AddNewExpenseCategory()
        {
            var newExpenseCategory = new BoExpenseCategory() { ExpenseName = "New Expense" };
            var saved = _expenseModule.Save(newExpenseCategory);

            ExpenseCategoriesCollection.Add(saved);
        }
    }
}