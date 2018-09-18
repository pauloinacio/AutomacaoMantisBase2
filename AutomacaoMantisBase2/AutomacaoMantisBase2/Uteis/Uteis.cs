﻿using AutomacaoMantisBase2.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;


namespace AutomacaoMantisBase2.Uteis
{
    public class Uteis
    {
        public static String getPathSeleniumDriver()
        {
            // Função para definir o path do diretório
            String strAppDir = Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);
            //String strAppFolderData = Path.Combine(strAppDir, "\\SeleniumComum\\Drivers");

            //Função para reduzir em duas camadas a arvore do path
            var gparent = Directory.GetParent(Directory.GetParent(strAppDir).ToString());

            //Conversão var -> String
            String aux = gparent.ToString();

            //Concatenar Path diretorio + Path Drivers
            String strAppFolderData = String.Concat(aux, "\\Drivers");
            return strAppFolderData; //+ strAppFolderData;
        }

        public static String getPastaArquivos()
        {
            // Função para definir o path do diretório
            String strAppDir = Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);
            //String strAppFolderData = Path.Combine(strAppDir, "\\SeleniumComum\\Drivers");

            //Função para reduzir em duas camadas a arvore do path
            var gparent = Directory.GetParent(Directory.GetParent(strAppDir).ToString());

            //Conversão var -> String
            String aux = gparent.ToString();

            //Concatenar Path diretorio + Path Drivers
            String strAppFolderData = String.Concat(aux, "\\Arquivos");
            return strAppFolderData; //+ strAppFolderData;
        }

        public static void esperaElemento(IWebElement element)
        {
            WebDriverWait espera = new WebDriverWait(WebDriver.driver, timeout: TimeSpan.FromSeconds(30));
            espera.Until(condition: SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        public static void preencherTxtField(String value, IWebElement element)
        {
            esperaElemento(element);
            element.Clear();
            element.SendKeys(value);
        }

        public static void clicarBtn(IWebElement element)
        {
            esperaElemento(element);
            element.Click();
        }
    }
}
