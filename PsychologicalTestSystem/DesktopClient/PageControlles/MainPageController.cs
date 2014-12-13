using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopClient.PageControlles
{
    class MainPageController
    {
        private Window _mainWindow;

        private UserIntroductionController _userIntroductionController;
        private UserRegistrationController _userRegistrationController;
        private UserTestResultController _userTestResultController;
        private UserTestController _userTestController;

        public MainPageController(Window mainWindow)
        {
            _mainWindow = mainWindow;

            _userIntroductionController = new UserIntroductionController(mainWindow, this);
            _userRegistrationController = new UserRegistrationController(mainWindow, this);
            _userTestResultController = new UserTestResultController(mainWindow, this);
            _userTestController = new UserTestController(mainWindow, this);

            _userRegistrationController.SetupToWindow();


        }

        public void GoToUserIntroductionPage()
        {
            _userIntroductionController.SetupToWindow();
        }

        public void GoToUserRegistrationPage()
        {
            _userRegistrationController.SetupToWindow();
        }

        public void GoToTestResultPage()
        {
            _userTestResultController.SetupToWindow();
        }

        public void GoToUserTestPage()
        {
            _userTestController.SetupToWindow();
        }

    }
}
