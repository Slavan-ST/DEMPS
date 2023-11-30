using Avalonia.Controls;
using Avalonia.Media.Imaging;

namespace DEMPS.Controls
{
    public partial class Captcha : Control
    {
        public Captcha()
        {
            InitializeComponent();
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
