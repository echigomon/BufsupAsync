using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using LRSkipAsync;
using BufsupAsync;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 を参照してください

namespace MyWindows
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region 初期設定
        private CS_BufsupAsync bufsup;
        #endregion

        public MainPage()
        {
            this.InitializeComponent();

            bufsup = new CS_BufsupAsync();

            textBox01.Text = "";
            textBox02.Text = "";

            ClearResultTextBox();			// 初期表示をクリアする
        }

        #region ［Ｂｕｆｓｕｐ］ボタン押下
        private async void button01_Click(object sender, RoutedEventArgs e)
        {   // [Bufsup]ボタン押下
            //            WriteLineResult("\n[Bufsup]ボタン押下");
//            ClearResultTextBox();           // 初期表示をクリアする
            String KeyWord = textBox02.Text;

            await bufsup.ClearAsync();
            bufsup.Wbuf = KeyWord;
            await bufsup.ExecAsync();

            WriteLineResult("Result : Wbuf[{0}]", bufsup.Wbuf);
            WriteLineResult("\n       : Rem[{0}]", bufsup.Rem);
            WriteLineResult("\n       : Remark[{0}]", bufsup.Remark);
        }
        #endregion

        #region ［Ｒｅｓｅｔ］ボタン押下
        private void button02_Click(object sender, RoutedEventArgs e)
        {   // [Reset]ボタン押下
            ClearResultTextBox();			// 初期表示をクリアする


            textBox01.Text = "";
            textBox02.Text = "";
        }
        #endregion

        #region ［Ｂｕｆｓｕｐ(Other)］ボタン押下
        private async void button03_Click(object sender, RoutedEventArgs e)
        {   // [Bufsup(Other)]ボタン押下
            Boolean Judge = false;
            String KeyWord = textBox02.Text;

            await bufsup.ClearAsync();
            Judge = await bufsup.ExecAsync(Judge, KeyWord);

            WriteLineResult("Result : Wbuf[{0}]", bufsup.Wbuf);
            WriteLineResult("\n       : Rem[{0}]", bufsup.Rem);
            WriteLineResult("\n       : Judge[{0}]", Judge);
        }
        #endregion
    }
}
