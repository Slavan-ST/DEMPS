using Avalonia.Controls;
using Avalonia.Media.Imaging;
using DEMPS.ViewModels;

namespace DEMPS.Controls
{
    public partial class Captcha : UserControl
    {
        public Captcha()
        {
            DataContext = new CaptchaViewModel();
        }





        #region ��������

        public Bitmap? Image { get; set; } // ����������� �����
        public string Text { get; set; } = string.Empty; //����� �����
        public string InputUserText { get; set; } = string.Empty; //����� �����, ��������� �������������
        public bool IsVerified { get; set; } = false; // ���������-�� ����� ��������� ������������� � ������� �����

        #endregion

    }


    /*
     
    �� ���� ������������ ������ ��������� ����� ������ - �����, �� �����-���� ��������.. 
    ����� �� ����� �������� ������ � ���� �������� �� ����� ��� ���

    */
}
