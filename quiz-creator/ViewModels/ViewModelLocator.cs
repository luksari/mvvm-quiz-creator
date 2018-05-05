/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:QuizCreator"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using QuizCreator.Additionals;
using System;

namespace QuizCreator.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        /// 
        public MainWindowViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainWindowViewModel>();
            }
        }

        public QuizStartViewModel Start
        {
            get
            {
                return ServiceLocator.Current.GetInstance<QuizStartViewModel>();
            }
        }
        public QuizListViewModel QuizList
        {
            get
            {
                return ServiceLocator.Current.GetInstance<QuizListViewModel>();
            }
        }
        public QuizViewModel Quiz
        {
            get
            {
                return ServiceLocator.Current.GetInstance<QuizViewModel>();
            }
        }
        public QuizAnswersViewModel Answers
        {
            get
            {
                return ServiceLocator.Current.GetInstance<QuizAnswersViewModel>();
            }
        }
        public QuizQuestionViewModel Question
        {
            get
            {
                return ServiceLocator.Current.GetInstance<QuizQuestionViewModel>();
            }
        }

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var navigationService = new FrameNavigationService();

            navigationService.Configure("Main", new Uri("../MainWindowView.xaml", UriKind.Relative));
            navigationService.Configure("Start", new Uri("../Views/QuizStartView.xaml", UriKind.Relative));
            navigationService.Configure("QuizList", new Uri("../Views/QuizListView.xaml", UriKind.Relative));
            navigationService.Configure("Quiz", new Uri("../Views/QuizView.xaml", UriKind.Relative));
            navigationService.Configure("Question", new Uri("../Views/QuizQuestionView.xaml", UriKind.Relative));
            navigationService.Configure("Answer", new Uri("../Views/QuizAnswerView.xaml", UriKind.Relative));

            SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);


            SimpleIoc.Default.Register<MainWindowViewModel>(true);
            SimpleIoc.Default.Register<QuizStartViewModel>(true);
            SimpleIoc.Default.Register<QuizListViewModel>(true);
            SimpleIoc.Default.Register<QuizViewModel>(true);
            SimpleIoc.Default.Register<QuizQuestionViewModel>(true);
            SimpleIoc.Default.Register<QuizAnswersViewModel>(true);



        }

    }
}