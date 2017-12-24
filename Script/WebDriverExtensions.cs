using System;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace PageObjects
{
    public static class WebDriverExtensions
    {
        /// <summary>
        /// Método que recebe o elemento e aguarda por x segundos sua existência antes de interagir com o mesmo;
        /// Sobrecarga do método 'FindElement';
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by"></param>
        /// <param name="tempoEmSegundos"></param>
        /// <returns></returns>
        public static IWebElement FindElement(this IWebDriver driver, By by, int tempoEmSegundos)
        {
            if (tempoEmSegundos > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(tempoEmSegundos));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

        /// <summary>
        /// Método que retorna bool de acordo com a presença do elemento;
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by"></param>
        /// <returns></returns>
        public static bool ElementIsPresent(this IWebDriver driver, By by)
        {
            try
            {
                return driver.FindElement(by).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

    }
}
