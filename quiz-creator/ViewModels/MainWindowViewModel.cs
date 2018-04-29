using QuizCreator.Additionals;
using QuizCreator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizCreator.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        #region Fields

        private ICommand _changePageCommand;

        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;


        #endregion

        public MainWindowViewModel()
        {
            // Add available pages
            PageViewModels.Add(new QuizStartViewModel());
            PageViewModels.Add(new QuizListViewModel());
            PageViewModels.Add(new QuizQuestionsViewModel());
            PageViewModels.Add(new QuizAnswersViewModel());

            // Set starting page
            CurrentPageViewModel = PageViewModels[0];
        }

        #region Properties / Commands

        public ICommand ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new RelayCommand(
                        p => ChangeViewModel((IPageViewModel)p),
                        p => p is IPageViewModel);
                }

                return _changePageCommand;
            }
        }
        public ICommand DisplayQuizListViewCommand
        {
            get
            {
                return new RelayCommand(action => CurrentPageViewModel = new QuizListViewModel(),
                param => true);
            }
        }
        public ICommand DisplayQuizAnswersViewCommand
        {
            get
            {
                return new RelayCommand(action => CurrentPageViewModel = new QuizAnswersViewModel(),
                param => true);
            }
        }
        public ICommand DisplayQuizQuestionsViewCommand
        {
            get
            {
                return new RelayCommand(action => CurrentPageViewModel = new QuizQuestionsViewModel(),
                param => true);
            }
        }

        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<IPageViewModel>();

                return _pageViewModels;
            }
        }

        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    OnPropertyChanged("CurrentPageViewModel");
                }
            }
        }

        #endregion

        #region Methods

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }


        #endregion
    }
}
