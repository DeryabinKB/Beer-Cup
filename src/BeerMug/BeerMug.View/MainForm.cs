using System;
using System.Collections.Generic;
using System.Linq;
using BeerMug.Model;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace BeerMug.View
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// ��������� ������ ChangeableParametrs
        /// </summary>
        private MugParameters _beerMugParametr = new MugParameters();

        /// <summary>
        /// ���� ��������� ������������ ����
        /// </summary>  
        private Color _correctColor = Color.White;

        /// <summary>
        /// ���� �� ��������� ������������ ����
        /// </summary>  
        private Color _incorrectColor = Color.LightPink;

        /// <summary>
        /// �������, c���������� �������� ������ ������
        /// � ��� ���������
        /// </summary>
        private Dictionary<TextBox, Action<double>> _textBox
            = new Dictionary<TextBox, Action<double>>();

        public MainForm()
        {
            InitializeComponent();
            _textBox = new Dictionary<TextBox, Action<double>>();
            _textBox.Add(outerDiametrTextBox, (outerDiametr)
                => _beerMugParametr.MugNeckDiametr = outerDiametr);
            _textBox.Add(thicknessTextBox, (wallThickness)
                => _beerMugParametr.WallThickness = wallThickness);
            _textBox.Add(highTextBox, (high)
                => _beerMugParametr.HighBottomDiametr = high);
            _textBox.Add(bottomThicknessTextBox, (bottomThickness)
                => _beerMugParametr.BottomThickness = bottomThickness);
            _textBox.Add(upperRadiusOfTheBottomTextBox, (highBottomDiametr)
                => _beerMugParametr.HighBottomDiametr = highBottomDiametr);
            _textBox.Add(lowerRadiusOfTheBottomTextBox, (lowBottomDiametr)
                => _beerMugParametr.HighBottomDiametr = lowBottomDiametr);
        }

        /// <summary>
        /// ��������� ��� �����������.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxValidator_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Focus();
            if (textBox.Text == string.Empty || textBox.Text == ",")
            {
                textBox.Text = string.Empty;
                return;
            }
            try
            {
                _textBox[textBox](double.Parse(textBox.Text));
                textBox.BackColor = _correctColor;
                if (textBox == lowerRadiusOfTheBottomTextBox)
                {
                    TextBoxValidator_TextChanged(upperRadiusOfTheBottomTextBox, e);
                    lowerRadiusOfTheBottomTextBox.Focus();
                }
                else if (textBox == bottomThicknessTextBox)
                {
                    TextBoxValidator_TextChanged(highTextBox, e);
                    TextBoxValidator_TextChanged(outerDiametrTextBox, e);
                    bottomThicknessTextBox.Focus();
                }
            }
            catch
            {
                textBox.BackColor = _incorrectColor;
            }
        }

        /// <summary>
        /// ��������, ����� textbox �������� ������ ���� ������� � �����.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckForCommasAndNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsDigit(e.KeyChar))
                && !((e.KeyChar == ',')
                     && (((TextBox)sender).Text.IndexOf(",") == -1)
                    ))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// ��������, ����� textbox �������� ������ �����.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IntegerCheck_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsDigit(e.KeyChar))
                && !((e.KeyChar == ',')
                && (((TextBox)sender).Text.IndexOf(",") == 1)
            ))
            {
                e.Handled = true;
            }
        }

        private void MinimumSizeButtom_Click(object sender, EventArgs e)
        {
            outerDiametrTextBox.Text = "80";
            thicknessTextBox.Text = "5";
            highTextBox.Text = "100";
            bottomThicknessTextBox.Text ="10";
            upperRadiusOfTheBottomTextBox.Text ="80";
            lowerRadiusOfTheBottomTextBox.Text ="50";
            TextBoxValidator_TextChanged(outerDiametrTextBox, e);
            TextBoxValidator_TextChanged(thicknessTextBox, e);
            TextBoxValidator_TextChanged(highTextBox, e);
            TextBoxValidator_TextChanged(bottomThicknessTextBox, e);
            TextBoxValidator_TextChanged(upperRadiusOfTheBottomTextBox, e);
            TextBoxValidator_TextChanged(lowerRadiusOfTheBottomTextBox, e);
        }

        private void MaximumSizeButton_Click(object sender, EventArgs e)
        {
            outerDiametrTextBox.Text = "100";
            thicknessTextBox.Text = "7";
            highTextBox.Text = "165";
            bottomThicknessTextBox.Text = "16.5";
            upperRadiusOfTheBottomTextBox.Text = "100";
            lowerRadiusOfTheBottomTextBox.Text = "70";
            TextBoxValidator_TextChanged(outerDiametrTextBox, e);
            TextBoxValidator_TextChanged(thicknessTextBox, e);
            TextBoxValidator_TextChanged(highTextBox, e);
            TextBoxValidator_TextChanged(bottomThicknessTextBox, e);
            TextBoxValidator_TextChanged(upperRadiusOfTheBottomTextBox, e);
            TextBoxValidator_TextChanged(lowerRadiusOfTheBottomTextBox, e);
        }

        private void buildButton_Click(object sender, EventArgs e)
        {
            if (outerDiametrTextBox.Text == string.Empty ||
                 thicknessTextBox.Text == string.Empty ||
                 highTextBox.Text == string.Empty ||
                 bottomThicknessTextBox.Text == string.Empty ||
                 upperRadiusOfTheBottomTextBox.Text == string.Empty ||
                 lowerRadiusOfTheBottomTextBox.Text == string.Empty ||
                 _beerMugParametr.Parameters.Count > 0)
            {
                MessageBox.Show("Fill all fields correctly", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                //var builder = new Builder();
                //builder.BuildSink();
            }
        }
    }
}