using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.Core.Patterns;
using FlaUI.Core.Shapes;
using FlaUI.Core.Tools;
using FlaUI.Core.WindowsAPI;
using FlaUI.UIA2;
using FlaUI.UIA3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
namespace FlaUiTests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Registration()
        {
            var app = Application.Launch(@"C:\Users\Admin\LearningRepo\FlaUIPractice\BankSystem\bin\Release\BankSystem.exe");
            var mainWindow = app.GetMainWindow(new UIA3Automation());
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            mainWindow.FindFirstDescendant(cf.ByName("Registration")).AsButton().Click();
            mainWindow.FindFirstDescendant(cf.ByAutomationId("InFName")).AsTextBox().Enter("Deepak");
            mainWindow.FindFirstDescendant(cf.ByAutomationId("InLName")).AsTextBox().Enter("Rana");
            
            mainWindow.FindFirstDescendant(cf.ByAutomationId("InPhone")).AsTextBox().Enter("7077105796");
            mainWindow.FindFirstDescendant(cf.ByAutomationId("InEmail")).AsTextBox().Enter("abc@gmail.com");
            mainWindow.FindFirstDescendant(cf.ByAutomationId("InPass")).AsTextBox().Enter("abc@1234");
            TextBox card = mainWindow.FindFirstDescendant(cf.ByAutomationId("InCard")).AsTextBox();
            card.Enter("644678927");
            mainWindow.FindFirstDescendant(cf.ByAutomationId("VipCheck")).AsCheckBox().Click();
            mainWindow.FindFirstDescendant(cf.ByAutomationId("button1")).AsButton().Click();
        }
        [TestMethod]
        public void Relations()
        {
            var app = Application.Launch(@"C:\Users\Admin\LearningRepo\FlaUIPractice\BankSystem\bin\Release\BankSystem.exe");
            var mainWindow = app.GetMainWindow(new UIA3Automation());
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            AutomationElement[] elements = mainWindow.FindAllDescendants();
            foreach (var item in elements)
            {
                item.DrawHighlight();
            }
        }
        [TestMethod]
        public void FindControlType()
        {
            var app = Application.Launch(@"C:\Users\Admin\LearningRepo\FlaUIPractice\BankSystem\bin\Release\BankSystem.exe");
            var mainWindow = app.GetMainWindow(new UIA3Automation());
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            mainWindow.FindFirstChild(cf.ByControlType(ControlType.Edit)).DrawHighlight();
        }
        [TestMethod]
        public void TestConditionFactoryWithMultipleConditions()
        {
            var app = Application.Launch(@"C:\Users\Admin\LearningRepo\FlaUIPractice\BankSystem\bin\Release\BankSystem.exe");
            var mainWindow = app.GetMainWindow(new UIA3Automation());
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            mainWindow.FindFirstDescendant(cf.ByName("Registration")).AsButton().Click();
            AutomationElement[] elements = mainWindow.FindAllDescendants(cf.ByName("First Name :").And(cf.ByControlType(ControlType.Edit)));
            foreach (var item in elements)
            {
                item.DrawHighlight();
                Thread.Sleep(300);
            }
        }
        [TestMethod]
        public void TestMenuControls()
        {
            var app = Application.Launch(@"C:\Users\Admin\source\repos\FlaUI\src\TestApplications\WinFormsApplication\bin\WinFormsApplication.exe");
            var automation = new UIA3Automation();
            var mainWindow = app.GetMainWindow(automation);

            var cf = automation.ConditionFactory;

            mainWindow.FindFirstDescendant(cf.ByName("ContextMenu"))
                      .AsButton()
                      .RightClick();

            

            //contextMenu.DrawHighlight();
        }
        [TestMethod]
        public void TestMouseActions()
        {
            Point p1 = new Point(1125,14);
            Point p2 = new Point(700, 300);
            Mouse.LeftClick(p1);
            Thread.Sleep(1000);
            Mouse.LeftClick(p2);
        }
    }
}