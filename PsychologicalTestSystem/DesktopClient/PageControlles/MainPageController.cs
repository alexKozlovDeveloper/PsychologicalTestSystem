using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Db.Core.Helpers;
using Db.Core.Loading;
using Db.Core.Repositoryes;

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

        //public XmlGroups Groups { get; private set; }
        //public XmlTest Test { get; private set; }

        public ITestingRepository Repository { get; private set; }
        //public Guid CurrentTestId { get; set; }
        public FolderTestingRepository folderRepository { get; private set; }
        //public XmlToDbLoader XmlLoader { get; private set; }

        public MainPageController(Window mainWindow)
        {
            _mainWindow = mainWindow;

            //XmlLoader = new XmlToDbLoader();
            var folder = @"C:\Users\Алексей\Documents\PsychologicalTestSystem\PsychologicalTestSystem\DesktopAdministrator\bin\Debug\XmlDb";

            folderRepository = new FolderTestingRepository(folder);

            //Groups = FileReaderHelper.ReadFromFileWithDeserialize<XmlGroups>("Groups.xml");
            //Test = FileReaderHelper.ReadFromFileWithDeserialize<XmlTest>("Tests.xml");

            Repository = new FolderTestingRepository(folder);//new TestingRepository();

            //CurrentTestId = Repository.GetAllTest().FirstOrDefault().Id;

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

        public void GoToTestResultPage()
        {
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
    }
}
