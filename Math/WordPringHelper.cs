﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Management;
using System.IO;
using System.Reflection;
using Microsoft.Office.Core;

namespace Math
{
    public class WordPrintHelper
    {
        /// <summary>
        /// 打印word
        /// </summary>
        /// <param name="filepath">word文件路径</param>
        /// <param name="printername">指定的打印机</param>
        public void Printword(string filepath, string printername)
        {
            //filepath=@"d:\b.doc";
            //printername = "Microsoft XPS Document Writer";
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                //不现实调用程序窗口,但是对于某些应用无效
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

                //采用操作系统自动识别的模式
                p.StartInfo.UseShellExecute = true;

                //要打印的文件路径
                p.StartInfo.FileName = filepath;
                ////Help help = new Help();
                ////help.LogMessage(filepath + "---------" + printername);
                //指定执行的动作，是打印，即print，打开是 open
                p.StartInfo.Verb = "print"; //print

                //获取当前默认打印机

                string defaultPrinter = GetDefaultPrinter();

                //将指定的打印机设为默认打印机
                SetDefaultPrinter(defaultPrinter);

                //开始打印
                p.Start();

                //等待十秒
                p.WaitForExit(10000);

                //将默认打印机还原
                SetDefaultPrinter(defaultPrinter);
            }
            catch (Exception ex)
            {
                //help.LogMessage(filepath + "----" + printername + "-------" + ex.Message);
            }

        }
        [DllImport("Winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetDefaultPrinter(string printerName);

        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern bool GetDefaultPrinter(StringBuilder pszBuffer, ref int pcchBuffer);
        /// <summary>
        /// 获取默认的打印机
        /// </summary>
        /// <returns></returns>
        static string GetDefaultPrinter()
        {
            const int ERROR_FILE_NOT_FOUND = 2;

            const int ERROR_INSUFFICIENT_BUFFER = 122;

            int pcchBuffer = 0;

            if (GetDefaultPrinter(null, ref pcchBuffer))
            {
                return null;
            }

            int lastWin32Error = Marshal.GetLastWin32Error();

            if (lastWin32Error == ERROR_INSUFFICIENT_BUFFER)
            {
                StringBuilder pszBuffer = new StringBuilder(pcchBuffer);
                if (GetDefaultPrinter(pszBuffer, ref pcchBuffer))
                {
                    return pszBuffer.ToString();
                }

                lastWin32Error = Marshal.GetLastWin32Error();
            }
            if (lastWin32Error == ERROR_FILE_NOT_FOUND)
            {
                return null;
            }

            throw new Win32Exception(Marshal.GetLastWin32Error());


        }

        ///打印页面不会闪动
        public void PrintMethodOther(string filepath, string printername)
        {
            try
            {
                object wordFile = filepath;
                //@"d:\b.doc";
                object oMissing = Missing.Value;
                //自定义object类型的布尔值
                object oTrue = true;
                object oFalse = false;

                object doNotSaveChanges = WdSaveOptions.wdDoNotSaveChanges;

                //定义WORD Application相关

                Application appWord = new Application();

                //WORD程序不可见
                appWord.Visible = false;
                //不弹出警告框
                appWord.DisplayAlerts = WdAlertLevel.wdAlertsNone;

                //先保存默认的打印机
                string defaultPrinter = appWord.ActivePrinter;

                //打开要打印的文件
                //如果在其它函数调用中出错（doc为null),处理办法：建立临时文件夹，还要设置服务的权限属性
                Document doc = appWord.Documents.Open(
                        ref wordFile,
                        ref oMissing,
                        ref oTrue,
                        ref oFalse,
                        ref oMissing,
                        ref oMissing,
                        ref oMissing,
                        ref oMissing,
                        ref oMissing,
                        ref oMissing,
                        ref oMissing,
                        ref oMissing,
                        ref oMissing,
                        ref oMissing,
                        ref oMissing,
                        ref oMissing);

                //设置指定的打印机
                appWord.ActivePrinter = printername;
                //"Microsoft XPS Document Writer";

                //打印

                doc.PrintOut(
                    ref oTrue, //此处为true,表示后台打印
                    ref oFalse,
                    ref oMissing,
                    ref oMissing,
                    ref oMissing,
                    ref oMissing,
                    ref oMissing,
                    ref oMissing,
                    ref oMissing,
                    ref oMissing,
                    ref oMissing,
                    ref oMissing,
                    ref oMissing,
                    ref oMissing,
                    ref oMissing,
                    ref oMissing,
                    ref oMissing,
                    ref oMissing
                    );

                //打印完关闭WORD文件
                doc.Close(ref doNotSaveChanges, ref oMissing, ref oMissing);

                //还原原来的默认打印机
                appWord.ActivePrinter = defaultPrinter;

                //退出WORD程序
                appWord.Quit(ref oMissing, ref oMissing, ref oMissing);

                doc = null;
                appWord = null;
            }
            catch (Exception ex)
            {
                ////help.LogMessage(filepath + "----" + printername + "-------" + ex.Message);
            }
        }

    }

}