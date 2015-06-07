using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Db.Core.Helpers;
using Db.Core.Loading;
using Db.Core.Repositoryes;
using Helpers.Keys;
using System.Configuration;

namespace DesktopClient.PageControlles
{
    class MainPageController
    {
        private Window _mainWindow;

        private readonly UserIntroductionController _userIntroductionController;
        private readonly UserRegistrationController _userRegistrationController;
        private readonly UserTestResultController _userTestResultController;
        private readonly UserTestController _userTestController;
        private readonly UserChoiceController _userChoiceController;
        private readonly TestChoiceController _testChoiceController;

        public ITestingRepository Repository { get; private set; }

        public MainPageController(Window mainWindow)
        {
            _mainWindow = mainWindow;

            var folder = ConfigurationManager.AppSettings[ConfigKeys.WorkFolderKey];
            
            Repository = new FolderTestingRepository(folder);

            _userIntroductionController = new UserIntroductionController(mainWindow, this);
            _userRegistrationController = new UserRegistrationController(mainWindow, this);
            _userTestResultController = new UserTestResultController(mainWindow, this);
            _userTestController = new UserTestController(mainWindow, this);
            _userChoiceController = new UserChoiceController(mainWindow, this);
            _testChoiceController = new TestChoiceController(mainWindow, this);

            _userChoiceController.SetupToWindow();
        }

        public void GoToUserIntroductionPage()
        {
            _userIntroductionController.SetupToWindow();
        }

        public void GoToUserRegistrationPage()
        {
            _userRegistrationController.SetupToWindow();
        }

        public void GoToTestResultPage(List<string> report)
        {
            _userTestResultController.Report = report;
            _userTestResultController.SetupToWindow();
        }

        public void GoToUserTestPage()
        {
            _userTestController.SetupToWindow();
        }

        public void GoToUserChoicePage()
        {
            _userChoiceController.SetupToWindow();
        }

        public void GoToTestChoicePage()
        {
            _testChoiceController.SetupToWindow();
        }

        public void Exit()
        {
            _mainWindow.Close();
        }

        public void ConnectToLocalDb()
        {
            Repository = new TestingRepository();
        }

        public void ConnectToLocalFolder()
        {
            var folder = ConfigurationManager.AppSettings[ConfigKeys.WorkFolderKey];

            Repository = new FolderTestingRepository(folder);
        }
    }
}
