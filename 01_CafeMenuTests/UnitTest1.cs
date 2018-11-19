using System;
using System.Collections.Generic;
using _01_CafeMenu;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_CafeMenuTests
{

    [TestClass]
    public class MenuRepositoryTests
    {
        [TestMethod]
        public void MenuRepository_CreateMenuItemTest_ExpectedCountShouldBeCorrect()
        {
            //--Arrange
            MenuRepository menuRepository = new MenuRepository();
            Menu menu = new Menu();
            menuRepository.AddMenuToList(menu);
            List<Menu> menu1 = menuRepository.DisplayMenu();

            //--Act
            var actual = menu1.Count;
            var expected = 1;

            //--Assert
            Assert.AreEqual(expected, actual);

        }
    }
}

